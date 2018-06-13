using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class DALAbstractTransactionMapper
        {
                public virtual Transaction MapBOToEF(
                        BOTransaction bo)
                {
                        Transaction efTransaction = new Transaction();

                        efTransaction.SetProperties(
                                bo.Amount,
                                bo.GatewayConfirmationNumber,
                                bo.Id,
                                bo.TransactionStatusId);
                        return efTransaction;
                }

                public virtual BOTransaction MapEFToBO(
                        Transaction ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOTransaction();

                        bo.SetProperties(
                                ef.Id,
                                ef.Amount,
                                ef.GatewayConfirmationNumber,
                                ef.TransactionStatusId);
                        return bo;
                }

                public virtual List<BOTransaction> MapEFToBO(
                        List<Transaction> records)
                {
                        List<BOTransaction> response = new List<BOTransaction>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a26f03b39aab2b4025266882266b1765</Hash>
</Codenesium>*/