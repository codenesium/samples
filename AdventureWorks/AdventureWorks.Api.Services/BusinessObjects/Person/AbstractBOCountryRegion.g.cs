using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOCountryRegion : AbstractBusinessObject
        {
                public AbstractBOCountryRegion()
                        : base()
                {
                }

                public virtual void SetProperties(string countryRegionCode,
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
    <Hash>4e79cb8e5a69e15334666f74e7e3cf37</Hash>
</Codenesium>*/