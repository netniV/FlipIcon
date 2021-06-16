using System.Collections.Generic;

namespace FlipIcon.ViewModels
{
    public class ConnectionsGroupViewModel : ContainerItemViewModel<DeviceViewModel>
    {
        public ConnectionsGroupViewModel() : this(null, null, null)
        {

        }

        public ConnectionsGroupViewModel(string Name) : this(null, Name, null)
        {

        }

        public ConnectionsGroupViewModel(MenuItemViewModel parentViewModel, string Name, List<DeviceViewModel> connections) : base(parentViewModel, Name, connections)
        {
            
        }
    }
}
