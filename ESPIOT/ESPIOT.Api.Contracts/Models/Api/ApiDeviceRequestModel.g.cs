using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Contracts
{
        public partial class ApiDeviceRequestModel : AbstractApiRequestModel
        {
                public ApiDeviceRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string name,
                        Guid publicId)
                {
                        this.Name = name;
                        this.PublicId = publicId;
                }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public Guid PublicId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>526d1a7b1ce757d1cd88df70a552e349</Hash>
</Codenesium>*/