using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBOCountryRequirement : AbstractBusinessObject
        {
                public AbstractBOCountryRequirement()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  int countryId,
                                                  string details)
                {
                        this.CountryId = countryId;
                        this.Details = details;
                        this.Id = id;
                }

                public int CountryId { get; private set; }

                public string Details { get; private set; }

                public int Id { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7a3c3373f1f42a991526823c8adca129</Hash>
</Codenesium>*/