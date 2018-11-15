using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiSalesTaxRateClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int salesTaxRateID,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			int stateProvinceID,
			decimal taxRate,
			int taxType)
		{
			this.SalesTaxRateID = salesTaxRateID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.StateProvinceID = stateProvinceID;
			this.TaxRate = taxRate;
			this.TaxType = taxType;
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public int SalesTaxRateID { get; private set; }

		[JsonProperty]
		public int StateProvinceID { get; private set; }

		[JsonProperty]
		public decimal TaxRate { get; private set; }

		[JsonProperty]
		public int TaxType { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b1713bf11952b54969c55f6aa5c0365f</Hash>
</Codenesium>*/