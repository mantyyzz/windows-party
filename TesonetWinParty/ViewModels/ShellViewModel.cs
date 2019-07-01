using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesonetWinParty.EventModels;

namespace TesonetWinParty.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEventModel>, IHandle<LogOutEvent>
    {
        IEventAggregator _events;
        ServersViewModel _serversViewModel;
        SimpleContainer _container;

        public ShellViewModel(IEventAggregator events, ServersViewModel serversViewModel, SimpleContainer container)
        {
            _serversViewModel = serversViewModel;
            _container = container;

            _events = events;
            _events.Subscribe(this);

            //Main app visible screen
            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEventModel message)
        {
            ActivateItem(_serversViewModel);
        }

        public void Handle(LogOutEvent message)
        {
            ActivateItem(_container.GetInstance<LoginViewModel>());
        }
    }
}
