using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public partial class BOProvince: AbstractBusinessObject
        {
                public BOProvince() : base()
                {
                }

                public void SetProperties(int id,
                                          int countryId,
                                          string name)
                {
                        this.CountryId = countryId;
                        this.Id = id;
                        this.Name = name;
                }

                public int CountryId { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>fe40054c8d7bbc942ca1b49a875447bc</Hash>
</Codenesium>*/