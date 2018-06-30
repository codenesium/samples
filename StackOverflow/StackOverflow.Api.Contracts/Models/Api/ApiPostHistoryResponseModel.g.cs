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

                public string Comment { get; private set; }

                public DateTime CreationDate { get; private set; }

                public int Id { get; private set; }

                public int PostHistoryTypeId { get; private set; }

                public int PostId { get; private set; }

                public string RevisionGUID { get; private set; }

                public string Text { get; private set; }

                public string UserDisplayName { get; private set; }

                public int? UserId { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeCommentValue { get; set; } = true;

                public bool ShouldSerializeComment()
                {
                        return this.ShouldSerializeCommentValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCreationDateValue { get; set; } = true;

                public bool ShouldSerializeCreationDate()
                {
                        return this.ShouldSerializeCreationDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePostHistoryTypeIdValue { get; set; } = true;

                public bool ShouldSerializePostHistoryTypeId()
                {
                        return this.ShouldSerializePostHistoryTypeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePostIdValue { get; set; } = true;

                public bool ShouldSerializePostId()
                {
                        return this.ShouldSerializePostIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRevisionGUIDValue { get; set; } = true;

                public bool ShouldSerializeRevisionGUID()
                {
                        return this.ShouldSerializeRevisionGUIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTextValue { get; set; } = true;

                public bool ShouldSerializeText()
                {
                        return this.ShouldSerializeTextValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeUserDisplayNameValue { get; set; } = true;

                public bool ShouldSerializeUserDisplayName()
                {
                        return this.ShouldSerializeUserDisplayNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeUserIdValue { get; set; } = true;

                public bool ShouldSerializeUserId()
                {
                        return this.ShouldSerializeUserIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCommentValue = false;
                        this.ShouldSerializeCreationDateValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializePostHistoryTypeIdValue = false;
                        this.ShouldSerializePostIdValue = false;
                        this.ShouldSerializeRevisionGUIDValue = false;
                        this.ShouldSerializeTextValue = false;
                        this.ShouldSerializeUserDisplayNameValue = false;
                        this.ShouldSerializeUserIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>e11f1c087b7bc53441be23ce0a3050d1</Hash>
</Codenesium>*/