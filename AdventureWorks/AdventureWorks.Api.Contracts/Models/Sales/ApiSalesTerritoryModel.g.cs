using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesTerritoryModel
	{
		public ApiSalesTerritoryModel()
		{}

		public ApiSalesTerritoryModel(
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
			this.CostLastYear = costLastYear.ToDecimal();
			this.CostYTD = costYTD.ToDecimal();
			this.CountryRegionCode = countryRegionCode.ToString();
			this.@Group = @group.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.SalesLastYear = salesLastYear.ToDecimal();
			this.SalesYTD = salesYTD.ToDecimal();
		}

		private decimal costLastYear;

		[Required]
		public decimal CostLastYear
		{
			get
			{
				return this.costLastYear;
			}

			set
			{
				this.costLastYear = value;
			}
		}

		private decimal costYTD;

		[Required]
		public decimal CostYTD
		{
			get
			{
				return this.costYTD;
			}

			set
			{
				this.costYTD = value;
			}
		}

		private string countryRegionCode;

		[Required]
		public string CountryRegionCode
		{
			get
			{
				return this.countryRegionCode;
			}

			set
			{
				this.countryRegionCode = value;
			}
		}

		private string @group;

		[Required]
		public string @Group
		{
			get
			{
				return this.@group;
			}

			set
			{
				this.@group = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}

		private string name;

		[Required]
		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				this.name = value;
			}
		}

		private Guid rowguid;

		[Required]
		public Guid Rowguid
		{
			get
			{
				return this.rowguid;
			}

			set
			{
				this.rowguid = value;
			}
		}

		private decimal salesLastYear;

		[Required]
		public decimal SalesLastYear
		{
			get
			{
				return this.salesLastYear;
			}

			set
			{
				this.salesLastYear = value;
			}
		}

		private decimal salesYTD;

		[Required]
		public decimal SalesYTD
		{
			get
			{
				return this.salesYTD;
			}

			set
			{
				this.salesYTD = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>93cf85dc7ee9da6a4a80a90076db6f57</Hash>
</Codenesium>*/