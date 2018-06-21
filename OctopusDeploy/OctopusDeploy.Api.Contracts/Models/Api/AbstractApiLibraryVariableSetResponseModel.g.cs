using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiLibraryVariableSetResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string contentType,
                        string id,
                        string jSON,
                        string name,
                        string variableSetId)
                {
                        this.ContentType = contentType;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.VariableSetId = variableSetId;
                }

                public string ContentType { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public string VariableSetId { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeContentTypeValue { get; set; } = true;

                public bool ShouldSerializeContentType()
                {
                        return this.ShouldSerializeContentTypeValue;
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

                [JsonIgnore]
                public bool ShouldSerializeVariableSetIdValue { get; set; } = true;

                public bool ShouldSerializeVariableSetId()
                {
                        return this.ShouldSerializeVariableSetIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeContentTypeValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeVariableSetIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>db707a877dade4a2ca365e1b323d1421</Hash>
</Codenesium>*/