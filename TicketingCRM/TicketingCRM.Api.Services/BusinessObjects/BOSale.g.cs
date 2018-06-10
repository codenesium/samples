using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public partial class BOSale:AbstractBusinessObject
        {
                public BOSale() : base()
                {
                }

                public void SetProperties(int id,
                                          string ipAddress,
                                          string notes,
                                          DateTime saleDate,
                                          int transactionId)
                {
                        this.Id = id;
                        this.IpAddress = ipAddress;
                        this.Notes = notes;
                        this.SaleDate = saleDate;
                        this.TransactionId = transactionId;
                }

                public int Id { get; private set; }

                public string IpAddress { get; private set; }

                public string Notes { get; private set; }

                public DateTime SaleDate { get; private set; }

                public int TransactionId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2b2ed1d278c0b981334692ce12a407b8</Hash>
</Codenesium>*/