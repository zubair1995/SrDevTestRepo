using System;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SrDevTest.Models;
using System.Collections;
using Xamarin.Essentials;
using System.Linq;

namespace SrDevTest.ViewModel
{
	public partial class PageTwoViewModel: BaseViewModel
    {
        public PageTwoViewModel()
		{
          
        }
        [ObservableProperty]
        private string userCode;
        [ObservableProperty]
        private string validationErrorMessage;
        [RelayCommand]
        private void TextChange(string parameter) => UserCode = parameter;
        [RelayCommand]
        private async Task PreviousPage()
        {
            await Shell.Current.GoToAsync(AppConstant.goBack);
        }
        [RelayCommand]
        private async Task NextPage()
        {
            await Shell.Current.GoToAsync(AppConstant.pageThree);
        }
        [RelayCommand]
        private async Task Submit()
        {
             ValidationErrorMessage = ValidateCode();
            if(string.IsNullOrEmpty(ValidationErrorMessage))
            {
                List<ConnectionProfile> connections = Connectivity.ConnectionProfiles.ToList();
                 var  currentConnectedNetwork = connections.Count > 0 ? string.Join(" ", connections) : "Network not found";
                var networkFound = await App.dbContext._db.QueryAsync<NetworkInfoModel>(string.Format("select * from NetworkInfoModel where code = '{0}'and networkName = '{1}'", UserCode, currentConnectedNetwork));
                if (networkFound != null && networkFound.Count > 0)
                {
                    await  insertUser();
                    ValidationErrorMessage = string.Empty;
                    await Shell.Current.GoToAsync(AppConstant.pageThree);
                }
                else
                {
                    ValidationErrorMessage = "Not found";
                }
            }
        }
        private async Task insertUser()
        {
            List<UserModel> users = new List<UserModel>()
            {
                 new UserModel{ UserName ="Ali"},
                 new UserModel{ UserName ="Ahmad"},
                 new UserModel{ UserName ="Waqas"},
                 new UserModel{ UserName ="Jamil"},
                 new UserModel{ UserName ="Hamaad"},
                 new UserModel{ UserName ="Babar"},
            };
            await App.dbContext.DeleteAll<UserModel>();
            await App.dbContext.InsertAll<UserModel>(users);
        }
        private string ValidateCode()
        {

            if (string.IsNullOrWhiteSpace(UserCode) || UserCode.Length < 4)
                return "Please enter valid code";
            return null;
        }
    }
}

