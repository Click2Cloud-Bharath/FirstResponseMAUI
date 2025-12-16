// Helpers/Settings.cs
using System;
using Microsoft.Maui.Storage;

namespace FirstResponseMAUI.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static IPreferences AppSettings
        {
            get
            {
                return Preferences.Default;
            }
        }

        #region Setting Constants

        private const string CurrentUserKey = "authenticated_user";

        private const string SelectedCityKey = "selected_city";

        private const string UserLatitudeKey = "user_latitude";

        private const string UserLongitudeKey = "user_longitude";

        private const string AmbulanceLatitudeKey = "ambulance_latitude";

        private const string AmbulanceLongitudeKey = "ambulance_longitude";

        private const string UseMockServiceKey = "use_mock_services_key";

        private const string ServiceEndpointKey = "service_endpoint_address";

        private const string PowerBIUrlKey = "power_bi_key";

        private const string UserSpeedKey = "user_speed";
        #endregion

        public static double AmbulanceLatitude
        {
            get
            {
                return AppSettings.Get(AmbulanceLatitudeKey, GlobalSetting.UserLatitude);
            }
            set
            {
                AppSettings.Set(AmbulanceLatitudeKey, value);
            }
        }

        public static double AmbulanceLongitude
        {
            get
            {
                return AppSettings.Get(AmbulanceLongitudeKey, GlobalSetting.UserLongitude);
            }
            set
            {
                AppSettings.Set(AmbulanceLongitudeKey, value);
            }
        }

        public static double UserLatitude
        {
            get
            {
                return AppSettings.Get(UserLatitudeKey, GlobalSetting.UserLatitude);
            }
            set
            {
                AppSettings.Set(UserLatitudeKey, value);
            }
        }

        public static double UserLongitude
        {
            get
            {
                return AppSettings.Get(UserLongitudeKey, GlobalSetting.UserLongitude);
            }
            set
            {
                AppSettings.Set(UserLongitudeKey, value);
            }
        }

        public static string CurrentUser
        {
            get
            {
                return AppSettings.Get(CurrentUserKey, default(string));
            }
            set
            {
                AppSettings.Set(CurrentUserKey, value);
            }
        }


        public static int SelectedCity
        {
            get
            {
                if (!UseMockService && AppSettings.Get(SelectedCityKey, GlobalSetting.DefaultCityId) == GlobalSetting.DefaultMockCityId)
                {
                    AppSettings.Set(SelectedCityKey, GlobalSetting.DefaultCityId);
                }

                return AppSettings.Get(SelectedCityKey, GlobalSetting.DefaultCityId);
            }
            set
            {
                AppSettings.Set(SelectedCityKey, value);
            }
        }

        public static double UserSpeed
        {
            get
            {
                return AppSettings.Get(UserSpeedKey, GlobalSetting.MovementSpeed);
            }
            set
            {
                AppSettings.Set(UserSpeedKey, value);
            }
        }

        public static bool UseMockService
        {
            get
            {
                return AppSettings.Get(UseMockServiceKey, GlobalSetting.UseMockServiceDefault);
            }
            set
            {
                AppSettings.Set(UseMockServiceKey, value);
            }
        }
        
        public static string ServiceEndpoint
        {
            get
            {
                return AppSettings.Get(ServiceEndpointKey, GlobalSetting.ServiceEndpoint);
            }
            set
            {
                AppSettings.Set(ServiceEndpointKey, value);
            }
        }

        public static void RemoveCurrentUser()
        {
            AppSettings.Remove(CurrentUserKey);
        }
    }
}
