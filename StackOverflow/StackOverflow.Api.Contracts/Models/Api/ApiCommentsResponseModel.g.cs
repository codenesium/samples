using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiCommentsResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        DateTime creationDate,
                        int postId,
                        int? score,
                        string text,
                        int? userId)
                {
                        this.Id = id;
                        this.CreationDate = creationDate;
                        this.PostId = postId;
                        this.Score = score;
                        this.Text = text;
                        this.UserId = userId;
                }

                [Required]
                [JsonProperty]
                public DateTime CreationDate { get; private set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public int PostId { get; private set; }

                [Required]
                [JsonProperty]
                public int? Score { get; private set; }

                [Required]
                [JsonProperty]
                public string Text { get; private set; }

                [Required]
                [JsonProperty]
                public int? UserId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b17de260ad6083cfd713c5b67243f827</Hash>
</Codenesium>*/