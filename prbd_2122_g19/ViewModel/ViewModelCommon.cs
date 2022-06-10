using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prbd_2122_g19;
using prbd_2122_g19.model;
using prbd_2122_g19.Model;
using PRBD_Framework;

namespace prbd_2122_g19.ViewModel {
    public abstract class ViewModelCommon : ViewModelBase<User, BankContext> {
        public static bool IsManager => App.IsLoggedIn && App.CurrentUser is Manager;
        public static bool IsClient => App.IsLoggedIn && App.CurrentUser is Client;
        public static bool IsAdmin => App.IsLoggedIn && App.CurrentUser is Admin;
        public static bool IsNotAdmin => !IsAdmin;
    }
}

