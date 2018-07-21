using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiConfigurationRequestModel : AbstractApiRequestModel
        {
                public ApiConfigurationRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string jSON)
                {
                        this.JSON = jSON;
                }

                [JsonProperty]
                public string JSON { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e6aee62b797374f9a4c4ea456961d753</Hash>
</Codenesium>*/