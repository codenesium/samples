using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOMachinePolicy: AbstractBusinessObject
        {
                public BOMachinePolicy() : base()
                {
                }

                public void SetProperties(string id,
                                          bool isDefault,
                                          string jSON,
                                          string name)
                {
                        this.Id = id;
                        this.IsDefault = isDefault;
                        this.JSON = jSON;
                        this.Name = name;
                }

                public string Id { get; private set; }

                public bool IsDefault { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0e770b03dbb1043b5f12cb9690a8438d</Hash>
</Codenesium>*/