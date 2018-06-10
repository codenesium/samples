using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class DALAbstractEventMapper
        {
                public virtual Event MapBOToEF(
                        BOEvent bo)
                {
                        Event efEvent = new Event();

                        efEvent.SetProperties(
                                bo.Address1,
                                bo.Address2,
                                bo.CityId,
                                bo.Date,
                                bo.Description,
                                bo.EndDate,
                                bo.Facebook,
                                bo.Id,
                                bo.Name,
                                bo.StartDate,
                                bo.Website);
                        return efEvent;
                }

                public virtual BOEvent MapEFToBO(
                        Event ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOEvent();

                        bo.SetProperties(
                                ef.Id,
                                ef.Address1,
                                ef.Address2,
                                ef.CityId,
                                ef.Date,
                                ef.Description,
                                ef.EndDate,
                                ef.Facebook,
                                ef.Name,
                                ef.StartDate,
                                ef.Website);
                        return bo;
                }

                public virtual List<BOEvent> MapEFToBO(
                        List<Event> records)
                {
                        List<BOEvent> response = new List<BOEvent>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>f3517478c2561cb5ae2b51b9ae3c4fd1</Hash>
</Codenesium>*/