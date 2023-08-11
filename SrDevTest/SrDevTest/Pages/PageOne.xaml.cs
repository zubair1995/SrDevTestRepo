using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using SrDevTest.ViewModel;
using Xamarin.Forms;

namespace SrDevTest.Pages
{	
	public partial class PageOne : ContentPage
	{	
		public PageOne ()
		{
			try
			{
                InitializeComponent();
                this.BindingContext = App.Current.services.GetService<PageOneViewModel>();
            }
			catch(Exception ex)
			{ throw ex; }
		
        }
	}
}

