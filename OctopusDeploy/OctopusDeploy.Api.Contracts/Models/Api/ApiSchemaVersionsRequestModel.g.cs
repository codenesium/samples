using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiSchemaVersionsRequestModel : AbstractApiRequestModel
        {
                public ApiSchemaVersionsRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        DateTime applied,
                        string scriptName)
                {
                        this.Applied = applied;
                        this.ScriptName = scriptName;
                }

                private DateTime applied;

                [Required]
                public DateTime Applied
                {
                        get
                        {
                                return this.applied;
                        }

                        set
                        {
                                this.applied = value;
                        }
                }

                private string scriptName;

                [Required]
                public string ScriptName
                {
                        get
                        {
                                return this.scriptName;
                        }

                        set
                        {
                                this.scriptName = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>f371d22fb8305ce4df735e4d60500a6f</Hash>
</Codenesium>*/