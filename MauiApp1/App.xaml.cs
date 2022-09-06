
using MauiApp1.Resources;
using System.Diagnostics;
using System.Globalization;

namespace MauiApp1;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
    }
}
