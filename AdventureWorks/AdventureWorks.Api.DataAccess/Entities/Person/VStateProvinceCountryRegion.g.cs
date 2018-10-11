using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vStateProvinceCountryRegion", Schema="Person")]
	public partial class VStateProvinceCountryRegion : AbstractEntity
	{
		public VStateProvinceCountryRegion()
		{
		}

		public virtual void SetProperties(
			string countryRegionCode,
			string countryRegionName,
			bool isOnlyStateProvinceFlag,
			string stateProvinceCode,
			int stateProvinceID,
			string stateProvinceName,
			int territoryID)
		{
			this.CountryRegionCode = countryRegionCode;
			this.CountryRegionName = countryRegionName;
			this.IsOnlyStateProvinceFlag = isOnlyStateProvinceFlag;
			this.StateProvinceCode = stateProvinceCode;
			this.StateProvinceID = stateProvinceID;
			this.StateProvinceName = stateProvinceName;
			this.TerritoryID = territoryID;
		}

		[Key]
		[MaxLength(3)]
		[Column("CountryRegionCode")]
		public string CountryRegionCode { get; private set; }

		[MaxLength(50)]
		[Column("CountryRegionName")]
		public string CountryRegionName { get; private set; }

		[Column("IsOnlyStateProvinceFlag")]
		public bool IsOnlyStateProvinceFlag { get; private set; }

		[MaxLength(3)]
		[Column("StateProvinceCode")]
		public string StateProvinceCode { get; private set; }

		[Key]
		[Column("StateProvinceID")]
		public int StateProvinceID { get; private set; }

		[MaxLength(50)]
		[Column("StateProvinceName")]
		public string StateProvinceName { get; private set; }

		[Column("TerritoryID")]
		public int TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>667ab2ef75a2fd7bfc6a786dbb2a52c4</Hash>
</Codenesium>*/