using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiSchemaVersionsRequestModel: AbstractApiRequestModel
        {
                public ApiSchemaVersionsRequestModel() : base()
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
    <Hash>26e1cb8361cb9723691300a811aa807c</Hash>
</Codenesium>*/