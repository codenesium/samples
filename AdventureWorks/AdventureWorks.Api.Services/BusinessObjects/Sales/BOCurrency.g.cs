using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOCurrency: AbstractBusinessObject
        {
                public BOCurrency() : base()
                {
                }

                public void SetProperties(string currencyCode,
                                          DateTime modifiedDate,
                                          string name)
                {
                        this.CurrencyCode = currencyCode;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                public string CurrencyCode { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>f31a15d834237e88164803d47cbdfafa</Hash>
</Codenesium>*/