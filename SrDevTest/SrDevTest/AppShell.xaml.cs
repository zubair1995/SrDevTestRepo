using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SrDevTest.Pages;
namespace SrDevTest
{	
	public partial class AppShell : Shell
    {	
		public AppShell ()
		{
            try
            {
                InitializeComponent();
                InitializeRouting();
            }
            catch(Exception){throw; }
        }
        private static void InitializeRouting()
        {
            Routing.RegisterRoute(AppConstant.pageOne, typeof(PageOne));
            Routing.RegisterRoute(AppConstant.pageTwo, typeof(PageTwo));
            Routing.RegisterRoute(AppConstant.pageThree, typeof(PageThree));
        }
    }
}