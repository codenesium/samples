using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiStateProvinceRequestModel: AbstractApiRequestModel
        {
                public ApiStateProvinceRequestModel() : base()
                {
                }

                public void SetProperties(
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
                        this.TerritoryID = territoryID;
                }

                private string countryRegionCode;

                [Required]
                public string CountryRegionCode
                {
                        get
                        {
                                return this.countryRegionCode;
                        }

                        set
                        {
                                this.countryRegionCode = value;
                        }
                }

                private bool isOnlyStateProvinceFlag;

                [Required]
                public bool IsOnlyStateProvinceFlag
                {
                        get
                        {
                                return this.isOnlyStateProvinceFlag;
                        }

                        set
                        {
                                this.isOnlyStateProvinceFlag = value;
                        }
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }

                private Guid rowguid;

                [Required]
                public Guid Rowguid
                {
                        get
                        {
                                return this.rowguid;
                        }

                        set
                        {
                                this.rowguid = value;
                        }
                }

                private string stateProvinceCode;

                [Required]
                public string StateProvinceCode
                {
                        get
                        {
                                return this.stateProvinceCode;
                        }

                        set
                        {
                                this.stateProvinceCode = value;
                        }
                }

                private int territoryID;

                [Required]
                public int TerritoryID
                {
                        get
                        {
                                return this.territoryID;
                        }

                        set
                        {
                                this.territoryID = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>7c5fbb788a386f8920e642fdbd72a64c</Hash>
</Codenesium>*/