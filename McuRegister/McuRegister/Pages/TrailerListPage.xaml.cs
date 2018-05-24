using McuRegister.PageModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace McuRegister.Pages
{
	public partial class TrailerListPage : ContentPage
	{
		public TrailerListPage ()
		{
			InitializeComponent ();
            BindingContext = new TrailerListPageModel { Navigation = Navigation };
            Debug.WriteLine("TrailerListPate() was started");
		}

    }
}