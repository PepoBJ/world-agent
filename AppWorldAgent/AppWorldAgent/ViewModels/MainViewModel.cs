using AppWorldAgent.Infrastructure.Services.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppWorldAgent.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ISettingsService _settingsService;

        public MainViewModel(ISettingsService settingsService)
        {
            Title = "Inicio";
            _settingsService = settingsService;
        }
    }
}
