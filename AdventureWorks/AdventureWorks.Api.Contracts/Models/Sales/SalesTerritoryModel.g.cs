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

		public SalesTerritoryModel(string name,
		                           string countryRegionCode,
		                           string @group,
		                           decimal salesYTD,
		                           decimal salesLastYear,
		                           decimal costYTD,
		                           decimal costLastYear,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			this.Name = name;
			this.CountryRegionCode = countryRegionCode;
			this.@Group = @group;
			this.SalesYTD = salesYTD;
			this.SalesLastYear = salesLastYear;
			this.CostYTD = costYTD;
			this.CostLastYear = costLastYear;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public SalesTerritoryModel(POCOSalesTerritory poco)
		{
			this.Name = poco.Name;
			this.@Group = poco.@Group;
			this.SalesYTD = poco.SalesYTD;
			this.SalesLastYear = poco.SalesLastYear;
			this.CostYTD = poco.CostYTD;
			this.CostLastYear = poco.CostLastYear;
			this.Rowguid = poco.Rowguid;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.CountryRegionCode = poco.CountryRegionCode.Value.ToString();
		}

		private string _name;
		[Required]
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				this._name = value;
			}
		}

		private string _countryRegionCode;
		[Required]
		public string CountryRegionCode
		{
			get
			{
				return _countryRegionCode;
			}
			set
			{
				this._countryRegionCode = value;
			}
		}

		private string @group;
		[Required]
		public string @Group
		{
			get
			{
				return @group;
			}
			set
			{
				this.@group = value;
			}
		}

		private decimal _salesYTD;
		[Required]
		public decimal SalesYTD
		{
			get
			{
				return _salesYTD;
			}
			set
			{
				this._salesYTD = value;
			}
		}

		private decimal _salesLastYear;
		[Required]
		public decimal SalesLastYear
		{
			get
			{
				return _salesLastYear;
			}
			set
			{
				this._salesLastYear = value;
			}
		}

		private decimal _costYTD;
		[Required]
		public decimal CostYTD
		{
			get
			{
				return _costYTD;
			}
			set
			{
				this._costYTD = value;
			}
		}

		private decimal _costLastYear;
		[Required]
		public decimal CostLastYear
		{
			get
			{
				return _costLastYear;
			}
			set
			{
				this._costLastYear = value;
			}
		}

		private Guid _rowguid;
		[Required]
		public Guid Rowguid
		{
			get
			{
				return _rowguid;
			}
			set
			{
				this._rowguid = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>75e420f255461b8ebd58fa41a1c68a66</Hash>
</Codenesium>*/