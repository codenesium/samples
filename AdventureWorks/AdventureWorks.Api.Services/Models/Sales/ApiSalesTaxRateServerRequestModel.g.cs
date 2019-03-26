using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiSalesTaxRateServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiSalesTaxRateServerRequestModel()
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
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

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
    <Hash>547938da0d413858ed0a4b7f5fe5088a</Hash>
</Codenesium>*/