using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiPostsResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int? acceptedAnswerId,
                        int? answerCount,
                        string body,
                        DateTime? closedDate,
                        int? commentCount,
                        DateTime? communityOwnedDate,
                        DateTime creationDate,
                        int? favoriteCount,
                        int id,
                        DateTime lastActivityDate,
                        DateTime? lastEditDate,
                        string lastEditorDisplayName,
                        int? lastEditorUserId,
                        int? ownerUserId,
                        int? parentId,
                        int postTypeId,
                        int score,
                        string tags,
                        string title,
                        int viewCount)
                {
                        this.AcceptedAnswerId = acceptedAnswerId;
                        this.AnswerCount = answerCount;
                        this.Body = body;
                        this.ClosedDate = closedDate;
                        this.CommentCount = commentCount;
                        this.CommunityOwnedDate = communityOwnedDate;
                        this.CreationDate = creationDate;
                        this.FavoriteCount = favoriteCount;
                        this.Id = id;
                        this.LastActivityDate = lastActivityDate;
                        this.LastEditDate = lastEditDate;
                        this.LastEditorDisplayName = lastEditorDisplayName;
                        this.LastEditorUserId = lastEditorUserId;
                        this.OwnerUserId = ownerUserId;
                        this.ParentId = parentId;
                        this.PostTypeId = postTypeId;
                        this.Score = score;
                        this.Tags = tags;
                        this.Title = title;
                        this.ViewCount = viewCount;
                }

                public int? AcceptedAnswerId { get; private set; }

                public int? AnswerCount { get; private set; }

                public string Body { get; private set; }

                public DateTime? ClosedDate { get; private set; }

                public int? CommentCount { get; private set; }

                public DateTime? CommunityOwnedDate { get; private set; }

                public DateTime CreationDate { get; private set; }

                public int? FavoriteCount { get; private set; }

                public int Id { get; private set; }

                public DateTime LastActivityDate { get; private set; }

                public DateTime? LastEditDate { get; private set; }

                public string LastEditorDisplayName { get; private set; }

                public int? LastEditorUserId { get; private set; }

                public int? OwnerUserId { get; private set; }

                public int? ParentId { get; private set; }

                public int PostTypeId { get; private set; }

                public int Score { get; private set; }

                public string Tags { get; private set; }

                public string Title { get; private set; }

                public int ViewCount { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAcceptedAnswerIdValue { get; set; } = true;

                public bool ShouldSerializeAcceptedAnswerId()
                {
                        return this.ShouldSerializeAcceptedAnswerIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeAnswerCountValue { get; set; } = true;

                public bool ShouldSerializeAnswerCount()
                {
                        return this.ShouldSerializeAnswerCountValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeBodyValue { get; set; } = true;

                public bool ShouldSerializeBody()
                {
                        return this.ShouldSerializeBodyValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeClosedDateValue { get; set; } = true;

                public bool ShouldSerializeClosedDate()
                {
                        return this.ShouldSerializeClosedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCommentCountValue { get; set; } = true;

                public bool ShouldSerializeCommentCount()
                {
                        return this.ShouldSerializeCommentCountValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCommunityOwnedDateValue { get; set; } = true;

                public bool ShouldSerializeCommunityOwnedDate()
                {
                        return this.ShouldSerializeCommunityOwnedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCreationDateValue { get; set; } = true;

                public bool ShouldSerializeCreationDate()
                {
                        return this.ShouldSerializeCreationDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeFavoriteCountValue { get; set; } = true;

                public bool ShouldSerializeFavoriteCount()
                {
                        return this.ShouldSerializeFavoriteCountValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLastActivityDateValue { get; set; } = true;

                public bool ShouldSerializeLastActivityDate()
                {
                        return this.ShouldSerializeLastActivityDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLastEditDateValue { get; set; } = true;

                public bool ShouldSerializeLastEditDate()
                {
                        return this.ShouldSerializeLastEditDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLastEditorDisplayNameValue { get; set; } = true;

                public bool ShouldSerializeLastEditorDisplayName()
                {
                        return this.ShouldSerializeLastEditorDisplayNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLastEditorUserIdValue { get; set; } = true;

                public bool ShouldSerializeLastEditorUserId()
                {
                        return this.ShouldSerializeLastEditorUserIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeOwnerUserIdValue { get; set; } = true;

                public bool ShouldSerializeOwnerUserId()
                {
                        return this.ShouldSerializeOwnerUserIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeParentIdValue { get; set; } = true;

                public bool ShouldSerializeParentId()
                {
                        return this.ShouldSerializeParentIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePostTypeIdValue { get; set; } = true;

                public bool ShouldSerializePostTypeId()
                {
                        return this.ShouldSerializePostTypeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeScoreValue { get; set; } = true;

                public bool ShouldSerializeScore()
                {
                        return this.ShouldSerializeScoreValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTagsValue { get; set; } = true;

                public bool ShouldSerializeTags()
                {
                        return this.ShouldSerializeTagsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTitleValue { get; set; } = true;

                public bool ShouldSerializeTitle()
                {
                        return this.ShouldSerializeTitleValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeViewCountValue { get; set; } = true;

                public bool ShouldSerializeViewCount()
                {
                        return this.ShouldSerializeViewCountValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAcceptedAnswerIdValue = false;
                        this.ShouldSerializeAnswerCountValue = false;
                        this.ShouldSerializeBodyValue = false;
                        this.ShouldSerializeClosedDateValue = false;
                        this.ShouldSerializeCommentCountValue = false;
                        this.ShouldSerializeCommunityOwnedDateValue = false;
                        this.ShouldSerializeCreationDateValue = false;
                        this.ShouldSerializeFavoriteCountValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeLastActivityDateValue = false;
                        this.ShouldSerializeLastEditDateValue = false;
                        this.ShouldSerializeLastEditorDisplayNameValue = false;
                        this.ShouldSerializeLastEditorUserIdValue = false;
                        this.ShouldSerializeOwnerUserIdValue = false;
                        this.ShouldSerializeParentIdValue = false;
                        this.ShouldSerializePostTypeIdValue = false;
                        this.ShouldSerializeScoreValue = false;
                        this.ShouldSerializeTagsValue = false;
                        this.ShouldSerializeTitleValue = false;
                        this.ShouldSerializeViewCountValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>b60c80da012efab5e1ff182039882559</Hash>
</Codenesium>*/