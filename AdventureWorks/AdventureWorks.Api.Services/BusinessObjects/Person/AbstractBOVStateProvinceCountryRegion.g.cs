using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOVStateProvinceCountryRegion : AbstractBusinessObject
	{
		public AbstractBOVStateProvinceCountryRegion()
			: base()
		{
		}

		public virtual void SetProperties(int stateProvinceID,
		                                  string countryRegionCode,
		                                  string countryRegionName,
		                                  bool isOnlyStateProvinceFlag,
		                                  string stateProvinceCode,
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

		public string CountryRegionCode { get; private set; }

		public string CountryRegionName { get; private set; }

		public bool IsOnlyStateProvinceFlag { get; private set; }

		public string StateProvinceCode { get; private set; }

		public int StateProvinceID { get; private set; }

		public string StateProvinceName { get; private set; }

		public int TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d3134ed2a8eecc10e7efeabcb866830f</Hash>
</Codenesium>*/