using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Contracts
{
        public partial class ApiSaleResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        decimal amount,
                        string firstName,
                        string lastName,
                        int paymentTypeId,
                        int petId,
                        string phone)
                {
                        this.Id = id;
                        this.Amount = amount;
                        this.FirstName = firstName;
                        this.LastName = lastName;
                        this.PaymentTypeId = paymentTypeId;
                        this.PetId = petId;
                        this.Phone = phone;

                        this.PaymentTypeIdEntity = nameof(ApiResponse.PaymentTypes);
                        this.PetIdEntity = nameof(ApiResponse.Pets);
                }

                public decimal Amount { get; private set; }

                public string FirstName { get; private set; }

                public int Id { get; private set; }

                public string LastName { get; private set; }

                public int PaymentTypeId { get; private set; }

                public string PaymentTypeIdEntity { get; set; }

                public int PetId { get; private set; }

                public string PetIdEntity { get; set; }

                public string Phone { get; private set; }
        }
}

/*<Codenesium>
    <Hash>95895134d733ec2240ef5a7a06f2b4ea</Hash>
</Codenesium>*/