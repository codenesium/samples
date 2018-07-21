using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiMutexRequestModel : AbstractApiRequestModel
        {
                public ApiMutexRequestModel()
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
    <Hash>0907dca36cf6ece5180ccce267ca0a66</Hash>
</Codenesium>*/