using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace libGCalendar
{
    public class Calendario
    {
        private ClientSecrets token = new ContaCalendario("ID", "SECRET").Token; 
        private static string[] Scopes = { CalendarService.Scope.Calendar };
        private static string ApplicationName = "CalendarioGoogle";
        private UserCredential credencial;
        private CalendarService servico = new CalendarService();


        public Calendario()
        {
            AutorizarCredencial();
            IniciarServico();
        }


        public Event GetEvento(string idEvento, string calendario = "primary")
        {
            var request = servico.Events.Get(calendario, idEvento);
            return request.Execute();
        }


        public Event InserirEvento(Event evento, string calendario = "primary")
        {
            var request = servico.Events.Insert(evento, calendario);
            return request.Execute();
        }


        public string DeletarEvento(string id, string calendario = "primary")
        {
            var request = servico.Events.Delete(calendario, id);
            return request.Execute();
        }


        public Event AtualizarEvento(Event evento, string calendario = "primary")
        {
            var request = servico.Events.Update(evento, calendario, evento.Id);
            return request.Execute();
        }


        public Events ListarEventos(DateTime datainicial, bool mostrarDeletado = false)
        {
            var request = servico.Events.List("primary");
            request.ShowDeleted = mostrarDeletado;
            request.TimeMin = datainicial;
            var eventos = request.Execute();
            if (eventos.Items != null && eventos.Items.Count > 0)
            {
                return eventos;
            }
            return null;
        }


        public Events ListarEventos(DateTime datainicial, DateTime dataFinal, bool mostrarDeletado = false)
        {
            var request = servico.Events.List("primary");
            request.ShowDeleted = mostrarDeletado;
            request.TimeMin = datainicial;
            request.TimeMax = dataFinal;
            var eventos = request.Execute();
            if (eventos.Items != null && eventos.Items.Count > 0)
            {
                return eventos;
            }
            return null;
        }

        
        private void IniciarServico()
        {
            servico = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credencial,
                ApplicationName = ApplicationName,
            });
        }


        private void AutorizarCredencial()
        {
            credencial = GoogleWebAuthorizationBroker.AuthorizeAsync(
                                 token,
                                 Scopes,
                                 "user",
                                 CancellationToken.None
                             ).Result;
        }

    }
}
