﻿using App1.Models;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModels
{
    class LoginViewModel 
    {
        private INavigation navigation;
        public LoginViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
        public const string UsernamePropertyName = "Username";
        private string username = string.Empty;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
                

        public const string PasswordPropertyName = "Password";
        private string password = string.Empty;
        public string Password
        {
            get { return password; }
            set {password = value;}
        }

        private Command loginCommand;
        public const string LoginCommandPropertyName = "LoginCommand";
        public Command LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommand()));
            }
        }

        protected async Task<User> ExecuteLoginCommand()
        {
            var user = DbQueryAsync.GetToken(username, password);
            return user;
        }
    }
}
