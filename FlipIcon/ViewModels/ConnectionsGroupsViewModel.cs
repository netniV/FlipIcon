using System.Collections.Generic;

namespace FlipIcon.ViewModels
{
    public class ConnectionsGroupsViewModel : ContainerItemViewModel<ConnectionsGroupViewModel>
    {
        public ConnectionsGroupsViewModel() : base(null, null, null)
        {
        }

        public ConnectionsGroupsViewModel(List<ConnectionsGroupViewModel> connectionsGroups) : base(null, null, connectionsGroups)
        {

        }
    }
}
