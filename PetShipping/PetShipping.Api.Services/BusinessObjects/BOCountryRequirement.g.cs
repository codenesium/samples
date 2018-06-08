using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public partial class BOCountryRequirement: AbstractBusinessObject
        {
                public BOCountryRequirement() : base()
                {
                }

                public void SetProperties(int id,
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
    <Hash>b98aa80a39df5c8c6e0edcd120e7cba1</Hash>
</Codenesium>*/