using DejamobileBackEnd.Services;
using Xamarin.Forms;

namespace DejamobileBackEnd
{
    public class DejamobileBackEnd
    {
        public void Initialise()
        {
            DependencyService.Register<ICardSchemeService, CardSchemeService>();

            DependencyService.Register<IDigitizedCardService, DigitizedCardService>();
            DependencyService.Get<IDigitizedCardService>().Initialise();
        }
    }
}
