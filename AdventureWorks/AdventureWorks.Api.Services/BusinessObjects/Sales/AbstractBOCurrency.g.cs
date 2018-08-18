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
    <Hash>b3d57167927fcdb61b81489db201500a</Hash>
</Codenesium>*/