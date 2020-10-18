using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XampleUI.Views.XFShell;

namespace XampleUI.ViewModels.XFShell
{
	public class AboutViewModel : BaseViewModel
	{
		public AboutViewModel()
		{
			Title = "About";
			OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
			NavigateClickCommand = new Command(OnNavClick);
		}

		public ICommand OpenWebCommand { get; }
		public ICommand NavigateClickCommand { get; }
		private async void OnNavClick(object obj)
		{
			await Shell.Current.GoToAsync(nameof(AboutTransitionPage));
		}
	}
}