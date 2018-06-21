using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOStateProvince : AbstractBusinessObject
        {
                public AbstractBOStateProvince()
                        : base()
                {
                }

                public virtual void SetProperties(int stateProvinceID,
                                                  string countryRegionCode,
                                                  bool isOnlyStateProvinceFlag,
                                                  DateTime modifiedDate,
                                                  string name,
                                                  Guid rowguid,
                                                  string stateProvinceCode,
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
    <Hash>529eab839401d2fc3e197e7f75d9621c</Hash>
</Codenesium>*/