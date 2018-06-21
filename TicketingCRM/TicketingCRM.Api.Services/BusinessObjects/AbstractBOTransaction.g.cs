using Codenesium.DataConversionExtensions;
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
    <Hash>29314117534b8566b91fe818a8d72856</Hash>
</Codenesium>*/