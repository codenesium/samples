using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("StateProvince", Schema="Person")]
        public partial class StateProvince : AbstractEntity
        {
                public StateProvince()
                {
                }

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

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Column("StateProvinceCode")]
                public string StateProvinceCode { get; private set; }

                [Key]
                [Column("StateProvinceID")]
                public int StateProvinceID { get; private set; }

                [Column("TerritoryID")]
                public int TerritoryID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>35fcca30f3bf7c52b687e093e740fad9</Hash>
</Codenesium>*/