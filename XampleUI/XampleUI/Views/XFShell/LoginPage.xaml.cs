using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XampleUI.ViewModels.XFShell;

namespace XampleUI.Views.XFShell
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
			this.BindingContext = new LoginViewModel();
		}
	}
}