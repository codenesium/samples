using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiProjectGroupResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        byte[] dataVersion,
                        string id,
                        string jSON,
                        string name)
                {
                        this.DataVersion = dataVersion;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                }

                public byte[] DataVersion { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeDataVersionValue { get; set; } = true;

                public bool ShouldSerializeDataVersion()
                {
                        return this.ShouldSerializeDataVersionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJSONValue { get; set; } = true;

                public bool ShouldSerializeJSON()
                {
                        return this.ShouldSerializeJSONValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeDataVersionValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>574f7acd4fa7f102175c638263221513</Hash>
</Codenesium>*/