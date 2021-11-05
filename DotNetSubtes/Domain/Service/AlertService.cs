using Core.DTO;
using Core.Enums;
using Core.Interfaces;
using Core.Models;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class AlertService : CommonService
    {
        private readonly IUnitOfWork uow;
        public AlertService(IUnitOfWork UnitOfWork) 
        {
            this.uow = UnitOfWork;
        }

        /// <summary>
        /// Transforma los datos venidos de la API
        /// </summary>
        /// <param name="AlertResponse"></param>
        /// <returns></returns>
        private IEnumerable<Alert> PrepareAlertForPersist(ServiceAlertDTO AlertResponse)
        {
            List<Alert> AlertList = new List<Alert>();

            foreach (var alert in AlertResponse.entity)
            {
                AlertList.Add(new Alert()
                {
                    AlertCode = alert.id ?? AlertResponse.header.timestamp.ToString(),
                    Header_Text = alert.header_text.FirstOrDefault(x => x.language.ToLower().Trim().Contains("es")).text,
                    Description_Text = alert.description_text.FirstOrDefault(x => x.language.ToLower().Trim().Contains("es")).text,
                    ActivePeriodStart = alert.active_period.Count() > 0 ? UnixTimeStampToDateTime((double)alert.active_period[0].start.Value) : null,
                    ActivePeriodEnd = alert.active_period.Count() > 0 ? UnixTimeStampToDateTime((double)alert.active_period[0].end.Value) : null,
                    EndActivePeriodStart = alert.active_period.Count() > 0 ? UnixTimeStampToDateTime((double)alert.active_period[1].start.Value) : null,
                    EndActivePeriodEnd = alert.active_period.Count() > 0 ? UnixTimeStampToDateTime((double)alert.active_period[1].end.Value) : null,
                    Cause = (Cause)alert.cause,
                    Effect = (Effect)alert.effect,
                    Language = "es"
                });
            }

            return AlertList;
        }

        /// <summary>
        /// Retorna todas las alertas que fueron consultadas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AlertDTO> GetAllAlerts()
        {
             var AllAlert = uow.AlertRepository.GetAll().ToList();
            List<AlertDTO> AlertsList = new List<AlertDTO>();

            foreach (var alert in AllAlert)
            {
                AlertsList.Add(new AlertDTO() 
                {
                    AlertCode = alert.AlertCode,
                    Title = alert.Header_Text,
                    Description = alert.Description_Text,
                    ActiveStart = alert.ActivePeriodStart == null ? "" : alert.ActivePeriodStart.Value.ToString("H:mm"),
                    ActiveEnd = alert.EndActivePeriodEnd == null ? "" : alert.EndActivePeriodEnd.Value.ToString("H:mm"),
                    Cause = Enum.GetName(typeof(Cause), alert.Cause),
                    Effect = Enum.GetName(typeof(Cause), alert.Effect)
                });
            }

            return AlertsList;
        }

        /// <summary>
        /// Persiste las alertas consultadas en la base de datos de la applicacion
        /// </summary>
        /// <param name="AlertList"></param>
        public void InsertList(List<Alert> AlertList)
        {
            foreach (var alert in AlertList)
            {
                if (!uow.AlertRepository.Find(x => x.AlertCode.Trim() == alert.AlertCode.Trim()).Any())
                {
                    uow.AlertRepository.Add(alert);
                }
            }
            uow.SaveChanges();
        }

        /// <summary>
        /// Metodo que retorna la lista de alertas activas que ya fueron persistidas en la base de datos
        /// </summary>
        /// <param name="AlertResponse"></param>
        /// <returns></returns>
        public IEnumerable<AlertDTO> PersistAndGetActivesAlerts(ServiceAlertDTO AlertResponse)
        {
            List<Alert> AlertsForPersist = PrepareAlertForPersist(AlertResponse).ToList();
            InsertList(AlertsForPersist);
            List<AlertDTO> ActiveAlerts = new List<AlertDTO>();

            foreach (var alert in AlertsForPersist)
            {
                ActiveAlerts.Add(new AlertDTO()
                {
                    AlertCode = alert.AlertCode,
                    Title = alert.Header_Text,
                    Description = alert.Description_Text,
                    ActiveStart = alert.ActivePeriodStart != null ? alert.EndActivePeriodEnd.Value.ToString("H:mm") : "",
                    ActiveEnd = alert.EndActivePeriodEnd != null ? alert.EndActivePeriodEnd.Value.ToString("H:mm") : "",
                    Cause = Enum.GetName(typeof(Cause), alert.Cause),
                    Effect = Enum.GetName(typeof(Cause), alert.Effect)
                });
            }
            return ActiveAlerts;
        }

    }
}
