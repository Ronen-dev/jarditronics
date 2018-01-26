using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jardicontrols
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Controls : ContentPage
    {   
        public Controls()
        {
            InitializeComponent();
            if (App.device == null)
                Msg.Text = "Please connect to a device from the tab bluetooth";
            else
                Msg.Text = "You are connected to " + App.device.Name;
        }

        public void RotationBaseRight(object sender, EventArgs e)
        {

        }
        public void RotationBaseLeft(object sender, EventArgs e)
        {

        }
        public void FirstHarmUp(object sender, EventArgs e)
        {

        }
        public void FirstHarmDown(object sender, EventArgs e)
        {

        }
        public void SecondHarmUp(object sender, EventArgs e)
        {

        }
        public void SecondHarmDown(object sender, EventArgs e)
        {

        }
        public void PlierOpen(object sender, EventArgs e)
        {

        }
        public void PlierClose(object sender, EventArgs e)
        {
            
        }
        public void PlierUp(object sender, EventArgs e)
        {

        }
        public void PlierDown(object sender, EventArgs e)
        {

        }

        public void Forward(object sender, EventArgs e)
        {

        }
        public void BackForward(object sender, EventArgs e)
        {

        }
        public void TurnRight(object sender, EventArgs e)
        {

        }
        public void TuenLeft(object sender, EventArgs e)
        {

        }
        public void Watered(object sender, EventArgs e)
        {

        }
    }
}
