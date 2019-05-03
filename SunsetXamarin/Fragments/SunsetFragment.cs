using System;
using Android.Animation;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Views;
using Android.Views.Animations;

namespace SunsetXamarin.Fragments
{
    public class SunsetFragment : Fragment
    {
        private View _sceneView;
        private View _sunView;
        private View _skyView;

        private int _blueSkyColor;
        private int _sunsetSkyColor;
        private int _nightSkyColor;

        public static SunsetFragment NewInstance()
        {
            return new SunsetFragment();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_sunset, container, false);

            _sceneView = view;
            _sunView = view.FindViewById(Resource.Id.sun);
            _skyView = view.FindViewById(Resource.Id.sky);

            _blueSkyColor = ContextCompat.GetColor(Context, Resource.Color.blue_sky);
            _sunsetSkyColor = ContextCompat.GetColor(Context, Resource.Color.sunset_sky);
            _nightSkyColor = ContextCompat.GetColor(Context, Resource.Color.night_sky);

            _sceneView.Click += SceneClicked;

            return view;
        }

        private void SceneClicked(object sender, EventArgs e)
        {
            StartAnimation();
        }

        private void StartAnimation()
        {
            var sunYStart = _sunView.Top;
            var sunYEnd = _skyView.Height;

            var heightAnimator = ObjectAnimator
                .OfFloat(_sunView, "y", sunYStart, sunYEnd)
                .SetDuration(3000);
            heightAnimator.SetInterpolator(new AccelerateInterpolator());

            var sunsetSkyAnimator = ObjectAnimator
                .OfInt(_skyView, "backgroundColor", _blueSkyColor, _sunsetSkyColor)
                .SetDuration(3000) as ObjectAnimator;
            sunsetSkyAnimator.SetEvaluator(new ArgbEvaluator());

            var nightSkyAnimator = ObjectAnimator
                .OfInt(_skyView, "backgroundColor", _sunsetSkyColor, _nightSkyColor)
                .SetDuration(1500) as ObjectAnimator;
            nightSkyAnimator.SetEvaluator(new ArgbEvaluator());

            var animatorSet = new AnimatorSet();
            animatorSet
                .Play(heightAnimator)
                .With(sunsetSkyAnimator)
                .Before(nightSkyAnimator);
            animatorSet.Start();
        }
    }
}
