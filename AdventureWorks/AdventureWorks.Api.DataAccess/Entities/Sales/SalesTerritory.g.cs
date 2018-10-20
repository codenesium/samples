using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesTerritory", Schema="Sales")]
	public partial class SalesTerritory : AbstractEntity
	{
		public SalesTerritory()
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
			decimal salesYTD,
			int territoryID)
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
			this.TerritoryID = territoryID;
		}

		[Column("CostLastYear")]
		public decimal CostLastYear { get; private set; }

		[Column("CostYTD")]
		public decimal CostYTD { get; private set; }

		[MaxLength(3)]
		[Column("CountryRegionCode")]
		public string CountryRegionCode { get; private set; }

		[MaxLength(50)]
		[Column("Group")]
		public string @Group { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public string Name { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid")]
		public Guid Rowguid { get; private set; }

		[Column("SalesLastYear")]
		public decimal SalesLastYear { get; private set; }

		[Column("SalesYTD")]
		public decimal SalesYTD { get; private set; }

		[Key]
		[Column("TerritoryID")]
		public int TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>dd94be965cd67907dedf7eb165528352</Hash>
</Codenesium>*/