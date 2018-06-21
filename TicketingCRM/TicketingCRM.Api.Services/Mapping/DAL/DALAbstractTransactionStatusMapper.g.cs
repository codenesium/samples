using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class DALAbstractTransactionStatusMapper
        {
                public virtual TransactionStatus MapBOToEF(
                        BOTransactionStatus bo)
                {
                        TransactionStatus efTransactionStatus = new TransactionStatus();
                        efTransactionStatus.SetProperties(
                                bo.Id,
                                bo.Name);
                        return efTransactionStatus;
                }

                public virtual BOTransactionStatus MapEFToBO(
                        TransactionStatus ef)
                {
                        var bo = new BOTransactionStatus();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOTransactionStatus> MapEFToBO(
                        List<TransactionStatus> records)
                {
                        List<BOTransactionStatus> response = new List<BOTransactionStatus>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>4f99bded86f44d145ae670ed8daa6909</Hash>
</Codenesium>*/