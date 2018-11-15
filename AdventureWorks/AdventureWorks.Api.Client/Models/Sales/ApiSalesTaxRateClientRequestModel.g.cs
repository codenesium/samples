using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiSalesTaxRateClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiSalesTaxRateClientRequestModel()
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

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[JsonProperty]
		public int StateProvinceID { get; private set; } = default(int);

		[JsonProperty]
		public decimal TaxRate { get; private set; } = default(decimal);

		[JsonProperty]
		public int TaxType { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>134b3fd98ec7c2e90fc1cc9d3d1ae16c</Hash>
</Codenesium>*/