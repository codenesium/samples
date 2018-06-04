using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOCurrency: AbstractBusinessObject
	{
		public BOCurrency() : base()
		{}

		public void SetProperties(string currencyCode,
		                          DateTime modifiedDate,
		                          string name)
		{
			this.CurrencyCode = currencyCode;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
		}

		public string CurrencyCode { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cb6a1f49dc0c6649e08ded73d9e75f89</Hash>
</Codenesium>*/