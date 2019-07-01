using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesonetWinParty.EventModels;
using TesonetWinParty.Models;

namespace TesonetWinParty.ViewModels
{
    public class ServersViewModel : Screen
    {
        private IEventAggregator _events;
        private BindingList<Server> _servers;

        public ServersViewModel(IEventAggregator events)
        {
            _events = events;
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

        public void LogOut()
        {
            _events.PublishOnUIThread(new LogOutEvent());
        }
    }
}
