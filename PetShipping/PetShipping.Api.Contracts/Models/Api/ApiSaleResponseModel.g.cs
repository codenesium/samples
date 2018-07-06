using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiSaleResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        decimal amount,
                        int clientId,
                        string note,
                        int petId,
                        DateTime saleDate,
                        int salesPersonId)
                {
                        this.Id = id;
                        this.Amount = amount;
                        this.ClientId = clientId;
                        this.Note = note;
                        this.PetId = petId;
                        this.SaleDate = saleDate;
                        this.SalesPersonId = salesPersonId;

                        this.ClientIdEntity = nameof(ApiResponse.Clients);
                        this.PetIdEntity = nameof(ApiResponse.Pets);
                }

                public decimal Amount { get; private set; }

                public int ClientId { get; private set; }

                public string ClientIdEntity { get; set; }

                public int Id { get; private set; }

                public string Note { get; private set; }

                public int PetId { get; private set; }

                public string PetIdEntity { get; set; }

                public DateTime SaleDate { get; private set; }

                public int SalesPersonId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>fff54400c4a2d0a4c9541f41f62a6ec6</Hash>
</Codenesium>*/