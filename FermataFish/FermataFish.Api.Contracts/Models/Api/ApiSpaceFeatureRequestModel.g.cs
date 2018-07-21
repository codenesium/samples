using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiSpaceFeatureRequestModel : AbstractApiRequestModel
        {
                public ApiSpaceFeatureRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string name,
                        int studioId)
                {
                        this.Name = name;
                        this.StudioId = studioId;
                }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public int StudioId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>53e74a8061e75720b4e7884a242b3501</Hash>
</Codenesium>*/