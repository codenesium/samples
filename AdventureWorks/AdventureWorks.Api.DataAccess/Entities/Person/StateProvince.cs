using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("StateProvince", Schema="Person")]
	public partial class StateProvince: AbstractEntity
	{
		public StateProvince()
		{}

		public void SetProperties(
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
			this.IsOnlyStateProvinceFlag = isOnlyStateProvinceFlag.ToBoolean();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.Rowguid = rowguid.ToGuid();
			this.StateProvinceCode = stateProvinceCode;
			this.StateProvinceID = stateProvinceID.ToInt();
			this.TerritoryID = territoryID.ToInt();
		}

		[Column("CountryRegionCode", TypeName="nvarchar(3)")]
		public string CountryRegionCode { get; private set; }

		[Column("IsOnlyStateProvinceFlag", TypeName="bit")]
		public bool IsOnlyStateProvinceFlag { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; private set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; private set; }

		[Column("StateProvinceCode", TypeName="nchar(3)")]
		public string StateProvinceCode { get; private set; }

		[Key]
		[Column("StateProvinceID", TypeName="int")]
		public int StateProvinceID { get; private set; }

		[Column("TerritoryID", TypeName="int")]
		public int TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>26c6367800edb0f1bd0f21306ae64f5b</Hash>
</Codenesium>*/