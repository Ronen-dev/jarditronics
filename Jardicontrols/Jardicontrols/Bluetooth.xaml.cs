using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
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
        Boolean isBleEnabled;
        Boolean isBleDisabled;

        public Bluetooth()
        {
            InitializeComponent();

            this.ble = CrossBluetoothLE.Current;
            this.adapter = CrossBluetoothLE.Current.Adapter;
            this.isBleEnabled = (ble.State == BluetoothState.On);
            this.isBleDisabled = !this.isBleEnabled;

            this.deviceList = new ObservableCollection<IDevice>();
            lv.ItemsSource = this.deviceList;
        }

        private async void OnScanBluetooth(object sender, EventArgs e)
        {
            if (ble.State == BluetoothState.On) {
                this.isBleEnabled = true;
                this.isBleDisabled = !this.isBleEnabled;

                this.deviceList.Clear();

                this.adapter.DeviceDiscovered += (s, a) =>
                {
                    this.deviceList.Add(a.Device);
                };

                await this.adapter.StartScanningForDevicesAsync();
            } else {
                this.isBleDisabled = true;
                this.isBleEnabled = !this.isBleDisabled;
            }
        }
    }
}
