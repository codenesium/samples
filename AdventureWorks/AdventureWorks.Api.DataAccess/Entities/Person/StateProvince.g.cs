using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("StateProvince", Schema="Person")]
	public partial class StateProvince : AbstractEntity
	{
		public StateProvince()
		{
		}

		public virtual void SetProperties(
			int stateProvinceID,
			string countryRegionCode,
			bool isOnlyStateProvinceFlag,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			string stateProvinceCode,
			int territoryID)
		{
			this.StateProvinceID = stateProvinceID;
			this.CountryRegionCode = countryRegionCode;
			this.IsOnlyStateProvinceFlag = isOnlyStateProvinceFlag;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.StateProvinceCode = stateProvinceCode;
			this.TerritoryID = territoryID;
		}

		[MaxLength(3)]
		[Column("CountryRegionCode")]
		public virtual string CountryRegionCode { get; private set; }

		[Column("IsOnlyStateProvinceFlag")]
		public virtual bool IsOnlyStateProvinceFlag { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[MaxLength(3)]
		[Column("StateProvinceCode")]
		public virtual string StateProvinceCode { get; private set; }

		[Key]
		[Column("StateProvinceID")]
		public virtual int StateProvinceID { get; private set; }

		[Column("TerritoryID")]
		public virtual int TerritoryID { get; private set; }

		[ForeignKey("CountryRegionCode")]
		public virtual CountryRegion CountryRegionCodeNavigation { get; private set; }

		public void SetCountryRegionCodeNavigation(CountryRegion item)
		{
			this.CountryRegionCodeNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>e281a4577785d6a235a486f500634bd7</Hash>
</Codenesium>*/