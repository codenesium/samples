using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiStateProvinceResponseModel : AbstractApiResponseModel
        {
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
    <Hash>b41de6398f95cbc5027058c67dd03a6f</Hash>
</Codenesium>*/