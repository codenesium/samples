using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class SalesTerritoryModel
	{
		public SalesTerritoryModel()
		{}

		public SalesTerritoryModel(
			string name,
			string countryRegionCode,
			string @group,
			decimal salesYTD,
			decimal salesLastYear,
			decimal costYTD,
			decimal costLastYear,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.Name = name.ToString();
			this.CountryRegionCode = countryRegionCode.ToString();
			this.@Group = @group.ToString();
			this.SalesYTD = salesYTD.ToDecimal();
			this.SalesLastYear = salesLastYear.ToDecimal();
			this.CostYTD = costYTD.ToDecimal();
			this.CostLastYear = costLastYear.ToDecimal();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
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
	}
}

/*<Codenesium>
    <Hash>d22006ec64472771442aae24eadcb5de</Hash>
</Codenesium>*/