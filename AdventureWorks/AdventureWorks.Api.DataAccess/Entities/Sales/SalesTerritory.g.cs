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
			int territoryID,
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
			this.TerritoryID = territoryID;
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

		[Column("CostLastYear")]
		public virtual decimal CostLastYear { get; private set; }

		[Column("CostYTD")]
		public virtual decimal CostYTD { get; private set; }

		[MaxLength(3)]
		[Column("CountryRegionCode")]
		public virtual string CountryRegionCode { get; private set; }

		[MaxLength(50)]
		[Column("Group")]
		public virtual string ReservedGroup { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[Column("SalesLastYear")]
		public virtual decimal SalesLastYear { get; private set; }

		[Column("SalesYTD")]
		public virtual decimal SalesYTD { get; private set; }

		[Key]
		[Column("TerritoryID")]
		public virtual int TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e2862fc8635e7fd66ed3abf8a9b700ab</Hash>
</Codenesium>*/