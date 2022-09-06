using MauiApp1.Extensions;
using System.Globalization;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private void onLanguageClicked(object sender, EventArgs e)
    {
        if (Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower() == "en")
        {
            LocalizationResourceManager.Instance.SetCulture(new CultureInfo("es"));
        }
        else
        {
            LocalizationResourceManager.Instance.SetCulture(new CultureInfo("en"));
        }
    }
}

