using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiPostHistoryResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string comment,
                        DateTime creationDate,
                        int postHistoryTypeId,
                        int postId,
                        string revisionGUID,
                        string text,
                        string userDisplayName,
                        int? userId)
                {
                        this.Id = id;
                        this.Comment = comment;
                        this.CreationDate = creationDate;
                        this.PostHistoryTypeId = postHistoryTypeId;
                        this.PostId = postId;
                        this.RevisionGUID = revisionGUID;
                        this.Text = text;
                        this.UserDisplayName = userDisplayName;
                        this.UserId = userId;
                }

                [Required]
                [JsonProperty]
                public string Comment { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime CreationDate { get; private set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public int PostHistoryTypeId { get; private set; }

                [Required]
                [JsonProperty]
                public int PostId { get; private set; }

                [Required]
                [JsonProperty]
                public string RevisionGUID { get; private set; }

                [Required]
                [JsonProperty]
                public string Text { get; private set; }

                [Required]
                [JsonProperty]
                public string UserDisplayName { get; private set; }

                [Required]
                [JsonProperty]
                public int? UserId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>129ba1e25cb0442f66b8f0780c433923</Hash>
</Codenesium>*/