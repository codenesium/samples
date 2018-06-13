using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class DALAbstractTicketStatusMapper
        {
                public virtual TicketStatus MapBOToEF(
                        BOTicketStatus bo)
                {
                        TicketStatus efTicketStatus = new TicketStatus();

                        efTicketStatus.SetProperties(
                                bo.Id,
                                bo.Name);
                        return efTicketStatus;
                }

                public virtual BOTicketStatus MapEFToBO(
                        TicketStatus ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOTicketStatus();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOTicketStatus> MapEFToBO(
                        List<TicketStatus> records)
                {
                        List<BOTicketStatus> response = new List<BOTicketStatus>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>64377c9282d3e6325331475bc14a8625</Hash>
</Codenesium>*/