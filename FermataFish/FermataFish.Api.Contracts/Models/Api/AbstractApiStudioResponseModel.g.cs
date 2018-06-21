using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiStudioResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string address1,
                        string address2,
                        string city,
                        int id,
                        string name,
                        int stateId,
                        string website,
                        string zip)
                {
                        this.Address1 = address1;
                        this.Address2 = address2;
                        this.City = city;
                        this.Id = id;
                        this.Name = name;
                        this.StateId = stateId;
                        this.Website = website;
                        this.Zip = zip;

                        this.StateIdEntity = nameof(ApiResponse.States);
                }

                public string Address1 { get; private set; }

                public string Address2 { get; private set; }

                public string City { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int StateId { get; private set; }

                public string StateIdEntity { get; set; }

                public string Website { get; private set; }

                public string Zip { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAddress1Value { get; set; } = true;

                public bool ShouldSerializeAddress1()
                {
                        return this.ShouldSerializeAddress1Value;
                }

                [JsonIgnore]
                public bool ShouldSerializeAddress2Value { get; set; } = true;

                public bool ShouldSerializeAddress2()
                {
                        return this.ShouldSerializeAddress2Value;
                }

                [JsonIgnore]
                public bool ShouldSerializeCityValue { get; set; } = true;

                public bool ShouldSerializeCity()
                {
                        return this.ShouldSerializeCityValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStateIdValue { get; set; } = true;

                public bool ShouldSerializeStateId()
                {
                        return this.ShouldSerializeStateIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeWebsiteValue { get; set; } = true;

                public bool ShouldSerializeWebsite()
                {
                        return this.ShouldSerializeWebsiteValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeZipValue { get; set; } = true;

                public bool ShouldSerializeZip()
                {
                        return this.ShouldSerializeZipValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAddress1Value = false;
                        this.ShouldSerializeAddress2Value = false;
                        this.ShouldSerializeCityValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeStateIdValue = false;
                        this.ShouldSerializeWebsiteValue = false;
                        this.ShouldSerializeZipValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>49cc74bfe190407b691902d9cd4c0839</Hash>
</Codenesium>*/