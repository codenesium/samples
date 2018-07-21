using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiPostHistoryRequestModel : AbstractApiRequestModel
        {
                public ApiPostHistoryRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string comment,
                        DateTime creationDate,
                        int postHistoryTypeId,
                        int postId,
                        string revisionGUID,
                        string text,
                        string userDisplayName,
                        int? userId)
                {
                        this.Comment = comment;
                        this.CreationDate = creationDate;
                        this.PostHistoryTypeId = postHistoryTypeId;
                        this.PostId = postId;
                        this.RevisionGUID = revisionGUID;
                        this.Text = text;
                        this.UserDisplayName = userDisplayName;
                        this.UserId = userId;
                }

                [JsonProperty]
                public string Comment { get; private set; }

                [JsonProperty]
                public DateTime CreationDate { get; private set; }

                [JsonProperty]
                public int PostHistoryTypeId { get; private set; }

                [JsonProperty]
                public int PostId { get; private set; }

                [JsonProperty]
                public string RevisionGUID { get; private set; }

                [JsonProperty]
                public string Text { get; private set; }

                [JsonProperty]
                public string UserDisplayName { get; private set; }

                [JsonProperty]
                public int? UserId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9b95e3974a151b81857e411ade6c41a0</Hash>
</Codenesium>*/