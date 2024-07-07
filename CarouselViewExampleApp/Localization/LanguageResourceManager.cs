using CarouselViewExampleApp.Resources.Localization;
using System.Globalization;

namespace CarouselViewExampleApp.Localization
{
    public class LanguageResourceManager
    {
        public LanguageResourceManager()
        {
            AppResources.Culture = CultureInfo.CurrentCulture;
        }

        public static LanguageResourceManager Instance { get; } = new LanguageResourceManager();

        public object this[string resourceKey] => AppResources.ResourceManager.GetObject(resourceKey, AppResources.Culture) ?? Array.Empty<byte>();


        public void SetCulture(CultureInfo culture)
        {
            AppResources.Culture = culture;
        }
    }
}
