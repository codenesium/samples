using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOCurrency: AbstractDTO
	{
		public DTOCurrency() : base()
		{}

		public void SetProperties(string currencyCode,
		                          DateTime modifiedDate,
		                          string name)
		{
			this.CurrencyCode = currencyCode;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
		}

		public string CurrencyCode { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>4a94dfc5c9bb3994fd04ab5c93fddec2</Hash>
</Codenesium>*/