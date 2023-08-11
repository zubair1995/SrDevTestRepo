using System;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using CommunityToolkit.Mvvm.ComponentModel;
using Xamarin.Essentials;
using System.Linq;
using static SQLite.SQLite3;
using System.Linq.Expressions;
using SrDevTest.Models;

namespace SrDevTest.ViewModel
{
	public partial class PageOneViewModel:BaseViewModel
	{
  
        public PageOneViewModel()
		{
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged; ;
            Network();
          
        }
        private void Network()
        {
            GetNetwork(Connectivity.ConnectionProfiles.ToList());
        }
        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            GetNetwork(e.ConnectionProfiles.ToList());
        }
        private void GetNetwork(List<ConnectionProfile> profiles)
        {
            try
            {
                List<ConnectionProfile> connections = profiles.ToList();
               NetworkName = connections.Count > 0? string.Join(" ", connections):"Network not found";
            }
            catch (Exception) {
                throw;
            }
        }
        [ObservableProperty]
        private string code = "Supa";
        [ObservableProperty]
        private string networkName;
        [RelayCommand]
        private async Task nextPage()
        {
            try
            {
                var model = new NetworkInfoModel
                {
                    code = Code,
                    networkName = NetworkName
                };
                await App.dbContext.Insert<NetworkInfoModel>(model);
                await Shell.Current.GoToAsync(AppConstant.pageTwo);
            }
            catch(Exception)
            {
                throw;
            }
           
        }

    }
}

