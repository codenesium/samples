using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiSchemaVersionsResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        DateTime applied,
                        string scriptName)
                {
                        this.Id = id;
                        this.Applied = applied;
                        this.ScriptName = scriptName;
                }

                public DateTime Applied { get; private set; }

                public int Id { get; private set; }

                public string ScriptName { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAppliedValue { get; set; } = true;

                public bool ShouldSerializeApplied()
                {
                        return this.ShouldSerializeAppliedValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeScriptNameValue { get; set; } = true;

                public bool ShouldSerializeScriptName()
                {
                        return this.ShouldSerializeScriptNameValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAppliedValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeScriptNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>a63077d7f63c9f268ba7b80a202a6ad7</Hash>
</Codenesium>*/