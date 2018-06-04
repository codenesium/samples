using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOStateProvince: AbstractBusinessObject
	{
		public BOStateProvince() : base()
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

		public string CountryRegionCode { get; private set; }
		public bool IsOnlyStateProvinceFlag { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
		public Guid Rowguid { get; private set; }
		public string StateProvinceCode { get; private set; }
		public int StateProvinceID { get; private set; }
		public int TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5b896a37b852509f31782ea8890a049c</Hash>
</Codenesium>*/