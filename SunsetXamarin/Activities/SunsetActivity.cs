using Android.App;
using SunsetXamarin.Fragments;

namespace SunsetXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class SunsetActivity : SingleFragmentActivity
    {
        protected override Android.Support.V4.App.Fragment CreateFragment()
        {
            return SunsetFragment.NewInstance();
        }
    }
}