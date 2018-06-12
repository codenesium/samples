using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOSubscription: AbstractBusinessObject
        {
                public BOSubscription() : base()
                {
                }

                public void SetProperties(string id,
                                          bool isDisabled,
                                          string jSON,
                                          string name,
                                          string type)
                {
                        this.Id = id;
                        this.IsDisabled = isDisabled;
                        this.JSON = jSON;
                        this.Name = name;
                        this.Type = type;
                }

                public string Id { get; private set; }

                public bool IsDisabled { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public string Type { get; private set; }
        }
}

/*<Codenesium>
    <Hash>5bb600d7b2dfeb88a3b7fc99917fd135</Hash>
</Codenesium>*/