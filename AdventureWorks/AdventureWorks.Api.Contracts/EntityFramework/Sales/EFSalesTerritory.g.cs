using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesTerritory", Schema="Sales")]
	public partial class EFSalesTerritory
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
    <Hash>7ee799e4fc68253c57ecdc9ee70fc7ae</Hash>
</Codenesium>*/