using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiSalesTerritoryServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiSalesTerritoryServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			decimal costLastYear,
			decimal costYTD,
			string countryRegionCode,
			DateTime modifiedDate,
			string name,
			string reservedGroup,
			Guid rowguid,
			decimal salesLastYear,
			decimal salesYTD)
		{
			this.CostLastYear = costLastYear;
			this.CostYTD = costYTD;
			this.CountryRegionCode = countryRegionCode;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ReservedGroup = reservedGroup;
			this.Rowguid = rowguid;
			this.SalesLastYear = salesLastYear;
			this.SalesYTD = salesYTD;
		}

		[Required]
		[JsonProperty]
		public decimal CostLastYear { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public decimal CostYTD { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public string CountryRegionCode { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string ReservedGroup { get; private set; } = default(string);

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
		public decimal SalesLastYear { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public decimal SalesYTD { get; private set; } = default(decimal);
	}
}

/*<Codenesium>
    <Hash>5a85a9e6311325042edd47a5b9cc293f</Hash>
</Codenesium>*/