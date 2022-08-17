using MauiApp1.Resources;
using System.Globalization;

namespace MauiApp1;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        var culture = new CultureInfo("es");
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
        Languages.Culture = culture;
        var value = Languages.Greetings;

        MainPage = new AppShell();
    }
}
