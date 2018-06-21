using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOCurrency : AbstractBusinessObject
        {
                public AbstractBOCurrency()
                        : base()
                {
                }

                public virtual void SetProperties(string currencyCode,
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
    <Hash>26eeb944d23c1d37ccf80e8f3192fc60</Hash>
</Codenesium>*/