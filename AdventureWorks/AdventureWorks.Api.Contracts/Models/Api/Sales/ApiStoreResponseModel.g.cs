using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public class ApiStoreResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int businessEntityID,
                        string demographics,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid,
                        Nullable<int> salesPersonID)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.Demographics = demographics;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                        this.SalesPersonID = salesPersonID;

                        this.SalesPersonIDEntity = nameof(ApiResponse.SalesPersons);
                }

                public int BusinessEntityID { get; private set; }

                public string Demographics { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public Guid Rowguid { get; private set; }

                public Nullable<int> SalesPersonID { get; private set; }

                public string SalesPersonIDEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

                public bool ShouldSerializeBusinessEntityID()
                {
                        return this.ShouldSerializeBusinessEntityIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDemographicsValue { get; set; } = true;

                public bool ShouldSerializeDemographics()
                {
                        return this.ShouldSerializeDemographicsValue;
                }

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
                public bool ShouldSerializeSalesPersonIDValue { get; set; } = true;

                public bool ShouldSerializeSalesPersonID()
                {
                        return this.ShouldSerializeSalesPersonIDValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeBusinessEntityIDValue = false;
                        this.ShouldSerializeDemographicsValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeRowguidValue = false;
                        this.ShouldSerializeSalesPersonIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>2e29a4cc4259a5bd25a089385f127c70</Hash>
</Codenesium>*/