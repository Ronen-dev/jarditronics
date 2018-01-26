using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.Exceptions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jardicontrols
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bluetooth : ContentPage
    {
        IBluetoothLE ble;
        IAdapter adapter;
        ObservableCollection<IDevice> deviceList;

        public Bluetooth()
        {
            
            InitializeComponent();

            this.ble = CrossBluetoothLE.Current;
            this.adapter = CrossBluetoothLE.Current.Adapter;

            this.deviceList = new ObservableCollection<IDevice>();
            lv.ItemsSource = this.deviceList;
        }

        private async void OnScanBluetooth(object sender, EventArgs e)
        {
            if (ble.State == BluetoothState.On) {
                Msg.Text = "Scan in progress ...";
                loader.IsRunning = true;
                if (this.adapter.IsScanning == false) {
                    this.deviceList.Clear();

                    this.adapter.DeviceDiscovered += (s, a) =>
                    {
                        if (a.Device.Name != null)
                            this.deviceList.Add(a.Device);
                    };
                    await this.adapter.StartScanningForDevicesAsync();
                    // await this.adapter.StopScanningForDevicesAsync();    
                    Msg.Text = "";
                    loader.IsRunning = false;
                }
            } else {
                Msg.Text = "Please enable Bluetooth.";
            }
        }
        private async void lv_ItemSelected(object sender, SelectedItemChangedEventArgs e){
            if (lv.SelectedItem == null)
                return;
            App.device = lv.SelectedItem as IDevice;
            try
            {
                loader.IsRunning = true;
                await adapter.ConnectToDeviceAsync(App.device);
                Msg.Text = "You are connected to " + App.device.Name;
                ScanBle.IsVisible = false;
                DcDevice.IsVisible = true;
            }catch(DeviceConnectionException ex){
                App.device = null;
                Msg.Text = "Fail to connect";
            }finally{
                loader.IsRunning = false;
            }
        }
        private async void disconnected(object sender, EventArgs e){
            try{
                await this.adapter.DisconnectDeviceAsync(App.device);
                ScanBle.IsVisible = true;
                DcDevice.IsVisible = false;
           
            }catch(DeviceDiscoverException ex){
                
            }
        }
    }
}
