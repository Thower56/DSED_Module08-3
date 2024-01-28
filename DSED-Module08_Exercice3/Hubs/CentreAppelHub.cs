using DSED_Module08_Exercice3.Controllers;
using Microsoft.AspNetCore.SignalR;

namespace DSED_Module08_Exercice3.Hubs
{
    public class CentreAppelHub : Hub
    {
        public CentreAppelHub() { }

        public async Task OnConnectedAsync()
        {
            string connexionId = this.Context.ConnectionId;
            
        }
    }
}
