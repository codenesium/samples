using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOCountryRegion: AbstractBusinessObject
        {
                public BOCountryRegion() : base()
                {
                }

                public void SetProperties(string countryRegionCode,
                                          DateTime modifiedDate,
                                          string name)
                {
                        this.CountryRegionCode = countryRegionCode;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                public string CountryRegionCode { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b4e02ed5ac54779b858e2b93ae18d34c</Hash>
</Codenesium>*/