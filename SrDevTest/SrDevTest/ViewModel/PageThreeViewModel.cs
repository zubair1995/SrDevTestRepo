using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using SrDevTest.Models;

namespace SrDevTest.ViewModel
{
	public partial class PageThreeViewModel: BaseViewModel
    {
		public PageThreeViewModel()
		{
            GetUserName();

        }
        [ObservableProperty]
        private string welcomeMesage;
        private async void GetUserName()
        {
            List<UserModel> UserName = await App.dbContext._db.QueryAsync<UserModel>("select * from UserModel ORDER BY RANDOM() LIMIT 1");
            WelcomeMesage = $"Welcom {UserName[0].UserName}";

        }
        
    }
}

