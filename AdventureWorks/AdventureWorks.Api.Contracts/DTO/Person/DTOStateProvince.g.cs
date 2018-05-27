using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOStateProvince: AbstractDTO
	{
		public DTOStateProvince() : base()
		{}

		public void SetProperties(int stateProvinceID,
		                          string countryRegionCode,
		                          bool isOnlyStateProvinceFlag,
		                          DateTime modifiedDate,
		                          string name,
		                          Guid rowguid,
		                          string stateProvinceCode,
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

		public string CountryRegionCode { get; set; }
		public bool IsOnlyStateProvinceFlag { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public Guid Rowguid { get; set; }
		public string StateProvinceCode { get; set; }
		public int StateProvinceID { get; set; }
		public int TerritoryID { get; set; }
	}
}

/*<Codenesium>
    <Hash>71a42455c43402cf9e9831e6afa8dc21</Hash>
</Codenesium>*/