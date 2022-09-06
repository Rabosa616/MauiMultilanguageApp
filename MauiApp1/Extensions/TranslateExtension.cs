using MauiApp1.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Extensions;
[ContentProperty(nameof(Name))]
public class TranslateExtension : IMarkupExtension<BindingBase>
{
    public string? Name { get; set; }
    public IValueConverter? Converter { get; set; }

    public BindingBase ProvideValue(IServiceProvider serviceProvider)
    {
        return new Binding
        {
            Mode = BindingMode.OneWay,
            Path = $"[{Name}]",
            Source = LocalizationResourceManager.Instance,
            Converter = Converter
        };
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
    {
        return ProvideValue(serviceProvider);
    }
}

public class LocalizationResourceManager : INotifyPropertyChanged
{
    private LocalizationResourceManager()
    {
        Languages.Culture = CultureInfo.CurrentCulture;
    }

    public static LocalizationResourceManager Instance { get; } = new();

    public object this[string resourceKey] =>
        Languages.ResourceManager.GetObject(resourceKey, Languages.Culture) ?? Array.Empty<byte>();

    public event PropertyChangedEventHandler? PropertyChanged;

    public void SetCulture(CultureInfo culture)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Languages.Culture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            if (App.Current.MainPage is Shell)
            {
                App.Current.MainPage = new AppShell();
            }
        });
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
    }
}
