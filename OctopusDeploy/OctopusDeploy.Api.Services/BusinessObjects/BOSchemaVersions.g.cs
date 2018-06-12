using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOSchemaVersions: AbstractBusinessObject
        {
                public BOSchemaVersions() : base()
                {
                }

                public void SetProperties(int id,
                                          DateTime applied,
                                          string scriptName)
                {
                        this.Applied = applied;
                        this.Id = id;
                        this.ScriptName = scriptName;
                }

                public DateTime Applied { get; private set; }

                public int Id { get; private set; }

                public string ScriptName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e421166fb1fd759267afa759b97053db</Hash>
</Codenesium>*/