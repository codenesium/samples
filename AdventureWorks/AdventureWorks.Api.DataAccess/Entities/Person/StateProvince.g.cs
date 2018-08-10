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

		[Column("CountryRegionCode")]
		public string CountryRegionCode { get; private set; }

		[Column("IsOnlyStateProvinceFlag")]
		public bool IsOnlyStateProvinceFlag { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Column("Name")]
		public string Name { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid")]
		public Guid Rowguid { get; private set; }

		[Column("StateProvinceCode")]
		public string StateProvinceCode { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("StateProvinceID")]
		public int StateProvinceID { get; private set; }

		[Column("TerritoryID")]
		public int TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>df62ba1631a8a5997169206518980516</Hash>
</Codenesium>*/