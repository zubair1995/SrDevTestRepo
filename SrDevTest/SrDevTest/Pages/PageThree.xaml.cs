using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using SrDevTest.ViewModel;
using Xamarin.Forms;

namespace SrDevTest.Pages
{	
	public partial class PageThree : ContentPage
	{	
		public PageThree ()
		{
			InitializeComponent ();
            this.BindingContext = App.Current.services.GetService<PageThreeViewModel>();
        }
	}
}

