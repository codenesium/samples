using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesTerritory", Schema="Sales")]
	public partial class SalesTerritory: AbstractEntityFrameworkPOCO
	{
		public SalesTerritory()
		{}

		public void SetProperties(
			int territoryID,
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
			this.TerritoryID = territoryID.ToInt();
		}

		[Column("CostLastYear", TypeName="money")]
		public decimal CostLastYear { get; set; }

		[Column("CostYTD", TypeName="money")]
		public decimal CostYTD { get; set; }

		[Column("CountryRegionCode", TypeName="nvarchar(3)")]
		public string CountryRegionCode { get; set; }

		[Column("Group", TypeName="nvarchar(50)")]
		public string @Group { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("SalesLastYear", TypeName="money")]
		public decimal SalesLastYear { get; set; }

		[Column("SalesYTD", TypeName="money")]
		public decimal SalesYTD { get; set; }

		[Key]
		[Column("TerritoryID", TypeName="int")]
		public int TerritoryID { get; set; }
	}
}

/*<Codenesium>
    <Hash>1f03f8a6e2114a7b1f0df72f63fb25b9</Hash>
</Codenesium>*/