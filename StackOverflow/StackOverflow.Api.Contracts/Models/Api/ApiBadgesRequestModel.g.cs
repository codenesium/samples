using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiBadgesRequestModel : AbstractApiRequestModel
        {
                public ApiBadgesRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime date,
                        string name,
                        int userId)
                {
                        this.Date = date;
                        this.Name = name;
                        this.UserId = userId;
                }

                [JsonProperty]
                public DateTime Date { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public int UserId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>5379604534403e51ca08deaded487216</Hash>
</Codenesium>*/