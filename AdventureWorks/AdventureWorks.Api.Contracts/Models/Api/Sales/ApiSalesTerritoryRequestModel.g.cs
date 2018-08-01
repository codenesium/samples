using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesTerritoryRequestModel : AbstractApiRequestModel
	{
		public ApiSalesTerritoryRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			decimal costLastYear,
			decimal costYTD,
			string countryRegionCode,
			string @group,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			decimal salesLastYear,
			decimal salesYTD)
		{
			this.CostLastYear = costLastYear;
			this.CostYTD = costYTD;
			this.CountryRegionCode = countryRegionCode;
			this.@Group = @group;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.SalesLastYear = salesLastYear;
			this.SalesYTD = salesYTD;
		}

		[Required]
		[JsonProperty]
		public decimal CostLastYear { get; private set; }

		[Required]
		[JsonProperty]
		public decimal CostYTD { get; private set; }

		[Required]
		[JsonProperty]
		public string CountryRegionCode { get; private set; }

		[Required]
		[JsonProperty]
		public string @Group { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[Required]
		[JsonProperty]
		public decimal SalesLastYear { get; private set; }

		[Required]
		[JsonProperty]
		public decimal SalesYTD { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5c43818c633b6be5c02135dd5cbc9054</Hash>
</Codenesium>*/