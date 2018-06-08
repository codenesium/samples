using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public partial class BODestination: AbstractBusinessObject
        {
                public BODestination() : base()
                {
                }

                public void SetProperties(int id,
                                          int countryId,
                                          string name,
                                          int order)
                {
                        this.CountryId = countryId;
                        this.Id = id;
                        this.Name = name;
                        this.Order = order;
                }

                public int CountryId { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int Order { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1e3e88086e70c576b1f0540e9dd630b7</Hash>
</Codenesium>*/