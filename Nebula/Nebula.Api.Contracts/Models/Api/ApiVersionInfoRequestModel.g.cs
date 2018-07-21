using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiVersionInfoRequestModel : AbstractApiRequestModel
        {
                public ApiVersionInfoRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime? appliedOn,
                        string description)
                {
                        this.AppliedOn = appliedOn;
                        this.Description = description;
                }

                [JsonProperty]
                public DateTime? AppliedOn { get; private set; }

                [JsonProperty]
                public string Description { get; private set; }
        }
}

/*<Codenesium>
    <Hash>6408c87e308ea4777e0b7df5dc117453</Hash>
</Codenesium>*/