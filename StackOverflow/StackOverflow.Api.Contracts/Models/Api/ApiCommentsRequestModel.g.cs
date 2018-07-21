using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiCommentsRequestModel : AbstractApiRequestModel
        {
                public ApiCommentsRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime creationDate,
                        int postId,
                        int? score,
                        string text,
                        int? userId)
                {
                        this.CreationDate = creationDate;
                        this.PostId = postId;
                        this.Score = score;
                        this.Text = text;
                        this.UserId = userId;
                }

                [JsonProperty]
                public DateTime CreationDate { get; private set; }

                [JsonProperty]
                public int PostId { get; private set; }

                [JsonProperty]
                public int? Score { get; private set; }

                [JsonProperty]
                public string Text { get; private set; }

                [JsonProperty]
                public int? UserId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>bd71176c1286d40a667501ad3eb3cd9b</Hash>
</Codenesium>*/