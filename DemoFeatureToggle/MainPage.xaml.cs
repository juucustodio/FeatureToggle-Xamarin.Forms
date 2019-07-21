using System.ComponentModel;
using ConfigCat.Client;
using Xamarin.Forms;

namespace DemoFeatureToggle
{

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        /*AutoPollConfiguration clientConfiguration = new AutoPollConfiguration
        {
            ApiKey = "API KEY",
            PollIntervalSeconds = 15
        };
        */
        /*
        ManualPollConfiguration clientConfiguration = new ManualPollConfiguration
        {
            ApiKey = "API KEY"
        };*/

        LazyLoadConfiguration clientConfiguration = new LazyLoadConfiguration
        {
          ApiKey = "API KEY",
          CacheTimeToLiveSeconds = 240
        };

        IConfigCatClient client;

        public MainPage()
        {
            InitializeComponent();
            client = new ConfigCatClient(clientConfiguration);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            //client.ForceRefresh();
            if (client.GetValue("isAwesomeFeatureEnabled", false))
            {
                LblResult.Text = "ON";
                LblResult.TextColor = Color.GreenYellow;
            }
            else
            {
                LblResult.Text = "OFF";
                LblResult.TextColor = Color.Red;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            client.Dispose();
        }
    }
}


