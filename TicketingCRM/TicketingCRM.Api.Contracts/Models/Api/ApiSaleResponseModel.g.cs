using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiSaleResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
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

                        this.TransactionIdEntity = nameof(ApiResponse.Transactions);
                }

                public int Id { get; private set; }

                public string IpAddress { get; private set; }

                public string Notes { get; private set; }

                public DateTime SaleDate { get; private set; }

                public int TransactionId { get; private set; }

                public string TransactionIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>03679fff4e1770827607c53b83c28399</Hash>
</Codenesium>*/