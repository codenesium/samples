using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractBOTransaction : AbstractBusinessObject
        {
                public AbstractBOTransaction()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  decimal amount,
                                                  string gatewayConfirmationNumber,
                                                  int transactionStatusId)
                {
                        this.Amount = amount;
                        this.GatewayConfirmationNumber = gatewayConfirmationNumber;
                        this.Id = id;
                        this.TransactionStatusId = transactionStatusId;
                }

                public decimal Amount { get; private set; }

                public string GatewayConfirmationNumber { get; private set; }

                public int Id { get; private set; }

                public int TransactionStatusId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>6dc0dfe0ff8aa94c1867cebb64becbce</Hash>
</Codenesium>*/