using Codenesium.DataConversionExtensions;
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
    <Hash>2f653e39f36bc60e7a91d2e7f41e0541</Hash>
</Codenesium>*/