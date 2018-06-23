using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public class ApiMutexResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        string jSON)
                {
                        this.Id = id;
                        this.JSON = jSON;
                }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJSONValue { get; set; } = true;

                public bool ShouldSerializeJSON()
                {
                        return this.ShouldSerializeJSONValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>a54321b3dab91a4decacaed7467e87e8</Hash>
</Codenesium>*/