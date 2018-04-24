using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesTerritory", Schema="Sales")]
	public partial class EFSalesTerritory: AbstractEntityFrameworkPOCO
	{
		public EFSalesTerritory()
		{}

		public void SetProperties(
			int territoryID,
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
			this.TerritoryID = territoryID.ToInt();
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

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("TerritoryID", TypeName="int")]
		public int TerritoryID { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("CountryRegionCode", TypeName="nvarchar(3)")]
		public string CountryRegionCode { get; set; }

		[Column("Group", TypeName="nvarchar(50)")]
		public string @Group { get; set; }

		[Column("SalesYTD", TypeName="money")]
		public decimal SalesYTD { get; set; }

		[Column("SalesLastYear", TypeName="money")]
		public decimal SalesLastYear { get; set; }

		[Column("CostYTD", TypeName="money")]
		public decimal CostYTD { get; set; }

		[Column("CostLastYear", TypeName="money")]
		public decimal CostLastYear { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("CountryRegionCode")]
		public virtual EFCountryRegion CountryRegion { get; set; }
	}
}

/*<Codenesium>
    <Hash>3ca14cee3f1b3e030278a4288c41d3b8</Hash>
</Codenesium>*/