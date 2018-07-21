using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiStateRequestModel : AbstractApiRequestModel
        {
                public ApiStateRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string name)
                {
                        this.Name = name;
                }

                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>644669e66f10bba8bc14cac837b799ec</Hash>
</Codenesium>*/