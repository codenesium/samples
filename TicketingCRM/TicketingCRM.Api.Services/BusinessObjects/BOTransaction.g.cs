using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public partial class BOTransaction: AbstractBusinessObject
        {
                public BOTransaction() : base()
                {
                }

                public void SetProperties(int id,
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
    <Hash>1ea222dd108f81499c0f3a77cff1cfea</Hash>
</Codenesium>*/