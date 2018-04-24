using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("StateProvince", Schema="Person")]
	public partial class EFStateProvince: AbstractEntityFrameworkPOCO
	{
		public EFStateProvince()
		{}

		public void SetProperties(
			int stateProvinceID,
			string stateProvinceCode,
			string countryRegionCode,
			bool isOnlyStateProvinceFlag,
			string name,
			int territoryID,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.StateProvinceID = stateProvinceID.ToInt();
			this.StateProvinceCode = stateProvinceCode.ToString();
			this.CountryRegionCode = countryRegionCode.ToString();
			this.IsOnlyStateProvinceFlag = isOnlyStateProvinceFlag.ToBoolean();
			this.Name = name.ToString();
			this.TerritoryID = territoryID.ToInt();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("StateProvinceID", TypeName="int")]
		public int StateProvinceID { get; set; }

		[Column("StateProvinceCode", TypeName="nchar(3)")]
		public string StateProvinceCode { get; set; }

		[Column("CountryRegionCode", TypeName="nvarchar(3)")]
		public string CountryRegionCode { get; set; }

		[Column("IsOnlyStateProvinceFlag", TypeName="bit")]
		public bool IsOnlyStateProvinceFlag { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("TerritoryID", TypeName="int")]
		public int TerritoryID { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("CountryRegionCode")]
		public virtual EFCountryRegion CountryRegion { get; set; }

		[ForeignKey("TerritoryID")]
		public virtual EFSalesTerritory SalesTerritory { get; set; }
	}
}

/*<Codenesium>
    <Hash>34e00d96a1168e53a50f52fdd5175490</Hash>
</Codenesium>*/