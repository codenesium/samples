using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesTaxRateResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int salesTaxRateID,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid,
                        int stateProvinceID,
                        decimal taxRate,
                        int taxType)
                {
                        this.SalesTaxRateID = salesTaxRateID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                        this.StateProvinceID = stateProvinceID;
                        this.TaxRate = taxRate;
                        this.TaxType = taxType;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public Guid Rowguid { get; private set; }

                public int SalesTaxRateID { get; private set; }

                public int StateProvinceID { get; private set; }

                public decimal TaxRate { get; private set; }

                public int TaxType { get; private set; }

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
                public bool ShouldSerializeSalesTaxRateIDValue { get; set; } = true;

                public bool ShouldSerializeSalesTaxRateID()
                {
                        return this.ShouldSerializeSalesTaxRateIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStateProvinceIDValue { get; set; } = true;

                public bool ShouldSerializeStateProvinceID()
                {
                        return this.ShouldSerializeStateProvinceIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTaxRateValue { get; set; } = true;

                public bool ShouldSerializeTaxRate()
                {
                        return this.ShouldSerializeTaxRateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTaxTypeValue { get; set; } = true;

                public bool ShouldSerializeTaxType()
                {
                        return this.ShouldSerializeTaxTypeValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeRowguidValue = false;
                        this.ShouldSerializeSalesTaxRateIDValue = false;
                        this.ShouldSerializeStateProvinceIDValue = false;
                        this.ShouldSerializeTaxRateValue = false;
                        this.ShouldSerializeTaxTypeValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>d7c5ec385aa9e6e69c376728d4187f94</Hash>
</Codenesium>*/