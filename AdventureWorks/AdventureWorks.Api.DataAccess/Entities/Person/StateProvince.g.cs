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
			string countryRegionCode,
			bool isOnlyStateProvinceFlag,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			string stateProvinceCode,
			int stateProvinceID,
			int territoryID)
		{
			this.CountryRegionCode = countryRegionCode;
			this.IsOnlyStateProvinceFlag = isOnlyStateProvinceFlag;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.StateProvinceCode = stateProvinceCode;
			this.StateProvinceID = stateProvinceID;
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
	}
}

/*<Codenesium>
    <Hash>c61ff7ce72115b6fe9d8d7f15b937fed</Hash>
</Codenesium>*/