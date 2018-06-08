using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Services
{
        public partial class BOSale:AbstractBusinessObject
        {
                public BOSale() : base()
                {
                }

                public void SetProperties(int id,
                                          decimal amount,
                                          string firstName,
                                          string lastName,
                                          int paymentTypeId,
                                          int petId,
                                          string phone)
                {
                        this.Amount = amount;
                        this.FirstName = firstName;
                        this.Id = id;
                        this.LastName = lastName;
                        this.PaymentTypeId = paymentTypeId;
                        this.PetId = petId;
                        this.Phone = phone;
                }

                public decimal Amount { get; private set; }

                public string FirstName { get; private set; }

                public int Id { get; private set; }

                public string LastName { get; private set; }

                public int PaymentTypeId { get; private set; }

                public int PetId { get; private set; }

                public string Phone { get; private set; }
        }
}

/*<Codenesium>
    <Hash>cdf7c71fd7d453d15ee2e319b31e2a29</Hash>
</Codenesium>*/