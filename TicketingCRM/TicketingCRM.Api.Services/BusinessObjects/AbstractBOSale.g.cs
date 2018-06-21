using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractBOSale : AbstractBusinessObject
        {
                public AbstractBOSale()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
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
    <Hash>7b0363cea072c2209354b19a16438805</Hash>
</Codenesium>*/