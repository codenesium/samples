using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiShipMethodResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid,
                        decimal shipBase,
                        int shipMethodID,
                        decimal shipRate)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                        this.ShipBase = shipBase;
                        this.ShipMethodID = shipMethodID;
                        this.ShipRate = shipRate;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public Guid Rowguid { get; private set; }

                public decimal ShipBase { get; private set; }

                public int ShipMethodID { get; private set; }

                public decimal ShipRate { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRowguidValue { get; set; } = true;

                public bool ShouldSerializeRowguid()
                {
                        return this.ShouldSerializeRowguidValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeShipBaseValue { get; set; } = true;

                public bool ShouldSerializeShipBase()
                {
                        return this.ShouldSerializeShipBaseValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeShipMethodIDValue { get; set; } = true;

                public bool ShouldSerializeShipMethodID()
                {
                        return this.ShouldSerializeShipMethodIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeShipRateValue { get; set; } = true;

                public bool ShouldSerializeShipRate()
                {
                        return this.ShouldSerializeShipRateValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeRowguidValue = false;
                        this.ShouldSerializeShipBaseValue = false;
                        this.ShouldSerializeShipMethodIDValue = false;
                        this.ShouldSerializeShipRateValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>eb8d97cfcacf7d08aee18b90a8845946</Hash>
</Codenesium>*/