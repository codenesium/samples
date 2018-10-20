using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesTaxRateRequestModel : AbstractApiRequestModel
	{
		public ApiSalesTaxRateRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			int stateProvinceID,
			decimal taxRate,
			int taxType)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.StateProvinceID = stateProvinceID;
			this.TaxRate = taxRate;
			this.TaxType = taxType;
		}

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public int StateProvinceID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public decimal TaxRate { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public int TaxType { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>674f1d42ba26f9f13c5b9dc8f4689e27</Hash>
</Codenesium>*/