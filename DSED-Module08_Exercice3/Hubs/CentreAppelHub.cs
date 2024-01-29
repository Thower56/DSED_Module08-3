using DSED_Module08_Exercice3.Controllers;
using Microsoft.AspNetCore.SignalR;

namespace DSED_Module08_Exercice3.Hubs
{
    public class CentreAppelHub : Hub
    {
        public async Task GetCurrentDayCallsCount() 
        {
            await Clients.All.SendAsync("CurrentDayCalls", Statistique.GetAppels().Where(call => call.DebutAppel.Date.Day == DateTime.Now.Date.Day).ToList().Count());
        }

        public async Task GetAverageCallDuration()
        {
            await Clients.All.SendAsync("AverageCallDuration", Statistique.GetAppels().Average(call => call.DureeAppel));
        }

        public async Task GetNumberOfAgents()
        {
            int nbAgents = Statistique.GetAppels().DistinctBy(call => call.IdAgent).ToList().Count();
            await Clients.All.SendAsync("NumberOfAgents", Statistique.GetAppels().DistinctBy(call => call.IdAgent).ToList().Count());
        }

        public async Task Update() 
        {
            GetCurrentDayCallsCount();
            GetAverageCallDuration();
            GetNumberOfAgents();
            await Clients.All.SendAsync("Update");
        }

        public async Task OnConnectedAsync()
        {
            string connexionId = this.Context.ConnectionId;
            Update();
        }
    }
}
