using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesonetWinParty.EventModels;
using TesonetWinParty.Helpers;
using TesonetWinParty.Models;

namespace TesonetWinParty.ViewModels
{
    public class ServersViewModel : Screen
    {
        private IAPIHelper _apiHelper;
        private IEventAggregator _events;
        private BindingList<Server> _servers;

        public ServersViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            _events = events;
            _apiHelper = apiHelper;
        }

        public BindingList<Server> Servers
        {
            get { return _servers; }
            set
            {
                _servers = value;
                NotifyOfPropertyChange(() => Servers);
            }
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadServers();
        }

        private async Task LoadServers()
        {
            var serversList = await _apiHelper.GetServersList("f9731b590611a5a9377fbd02f247fcdf");
            Servers = new BindingList<Server>(serversList);
        }

        public void LogOut()
        {
            _events.PublishOnUIThread(new LogOutEvent());
        }
    }
}
