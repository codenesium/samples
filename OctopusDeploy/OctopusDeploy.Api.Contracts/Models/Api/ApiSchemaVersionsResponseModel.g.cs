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
                        DateTime applied,
                        int id,
                        string scriptName)
                {
                        this.Applied = applied;
                        this.Id = id;
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
    <Hash>9db6a71f828cfe2f8561f2363fa30949</Hash>
</Codenesium>*/