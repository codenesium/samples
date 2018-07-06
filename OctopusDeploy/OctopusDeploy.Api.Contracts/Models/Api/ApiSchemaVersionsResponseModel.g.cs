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
        }
}

/*<Codenesium>
    <Hash>f4893705f9ab22d55a35b0f3fe523af7</Hash>
</Codenesium>*/