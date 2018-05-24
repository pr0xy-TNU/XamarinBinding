using McuRegister.PageModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace McuRegister.Pages
{

    public partial class TrailerPage : ContentPage
    {

        public TrailerPageModel Trailer { get; private set; }
        public TrailerPage(TrailerPageModel trailerPageModel)
        {
            Debug.WriteLine("In TrailerPage base");

            try
            {
                InitializeComponent();
                Trailer = trailerPageModel;
                BindingContext = Trailer;
            }
            catch (TargetInvocationException e)
            {
                Debug.WriteLine("Some problems");
            }

        }
    }
}