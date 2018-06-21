using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBOSale : AbstractBusinessObject
        {
                public AbstractBOSale()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  decimal amount,
                                                  int clientId,
                                                  string note,
                                                  int petId,
                                                  DateTime saleDate,
                                                  int salesPersonId)
                {
                        this.Amount = amount;
                        this.ClientId = clientId;
                        this.Id = id;
                        this.Note = note;
                        this.PetId = petId;
                        this.SaleDate = saleDate;
                        this.SalesPersonId = salesPersonId;
                }

                public decimal Amount { get; private set; }

                public int ClientId { get; private set; }

                public int Id { get; private set; }

                public string Note { get; private set; }

                public int PetId { get; private set; }

                public DateTime SaleDate { get; private set; }

                public int SalesPersonId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1ae1fd4465f520bd37d9e903b80f4be6</Hash>
</Codenesium>*/