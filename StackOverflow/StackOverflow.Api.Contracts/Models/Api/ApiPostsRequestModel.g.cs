using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiPostsRequestModel : AbstractApiRequestModel
        {
                public ApiPostsRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        Nullable<int> acceptedAnswerId,
                        Nullable<int> answerCount,
                        string body,
                        Nullable<DateTime> closedDate,
                        Nullable<int> commentCount,
                        Nullable<DateTime> communityOwnedDate,
                        DateTime creationDate,
                        Nullable<int> favoriteCount,
                        DateTime lastActivityDate,
                        Nullable<DateTime> lastEditDate,
                        string lastEditorDisplayName,
                        Nullable<int> lastEditorUserId,
                        Nullable<int> ownerUserId,
                        Nullable<int> parentId,
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

                private Nullable<int> acceptedAnswerId;

                public Nullable<int> AcceptedAnswerId
                {
                        get
                        {
                                return this.acceptedAnswerId.IsEmptyOrZeroOrNull() ? null : this.acceptedAnswerId;
                        }

                        set
                        {
                                this.acceptedAnswerId = value;
                        }
                }

                private Nullable<int> answerCount;

                public Nullable<int> AnswerCount
                {
                        get
                        {
                                return this.answerCount.IsEmptyOrZeroOrNull() ? null : this.answerCount;
                        }

                        set
                        {
                                this.answerCount = value;
                        }
                }

                private string body;

                [Required]
                public string Body
                {
                        get
                        {
                                return this.body;
                        }

                        set
                        {
                                this.body = value;
                        }
                }

                private Nullable<DateTime> closedDate;

                public Nullable<DateTime> ClosedDate
                {
                        get
                        {
                                return this.closedDate.IsEmptyOrZeroOrNull() ? null : this.closedDate;
                        }

                        set
                        {
                                this.closedDate = value;
                        }
                }

                private Nullable<int> commentCount;

                public Nullable<int> CommentCount
                {
                        get
                        {
                                return this.commentCount.IsEmptyOrZeroOrNull() ? null : this.commentCount;
                        }

                        set
                        {
                                this.commentCount = value;
                        }
                }

                private Nullable<DateTime> communityOwnedDate;

                public Nullable<DateTime> CommunityOwnedDate
                {
                        get
                        {
                                return this.communityOwnedDate.IsEmptyOrZeroOrNull() ? null : this.communityOwnedDate;
                        }

                        set
                        {
                                this.communityOwnedDate = value;
                        }
                }

                private DateTime creationDate;

                [Required]
                public DateTime CreationDate
                {
                        get
                        {
                                return this.creationDate;
                        }

                        set
                        {
                                this.creationDate = value;
                        }
                }

                private Nullable<int> favoriteCount;

                public Nullable<int> FavoriteCount
                {
                        get
                        {
                                return this.favoriteCount.IsEmptyOrZeroOrNull() ? null : this.favoriteCount;
                        }

                        set
                        {
                                this.favoriteCount = value;
                        }
                }

                private DateTime lastActivityDate;

                [Required]
                public DateTime LastActivityDate
                {
                        get
                        {
                                return this.lastActivityDate;
                        }

                        set
                        {
                                this.lastActivityDate = value;
                        }
                }

                private Nullable<DateTime> lastEditDate;

                public Nullable<DateTime> LastEditDate
                {
                        get
                        {
                                return this.lastEditDate.IsEmptyOrZeroOrNull() ? null : this.lastEditDate;
                        }

                        set
                        {
                                this.lastEditDate = value;
                        }
                }

                private string lastEditorDisplayName;

                public string LastEditorDisplayName
                {
                        get
                        {
                                return this.lastEditorDisplayName.IsEmptyOrZeroOrNull() ? null : this.lastEditorDisplayName;
                        }

                        set
                        {
                                this.lastEditorDisplayName = value;
                        }
                }

                private Nullable<int> lastEditorUserId;

                public Nullable<int> LastEditorUserId
                {
                        get
                        {
                                return this.lastEditorUserId.IsEmptyOrZeroOrNull() ? null : this.lastEditorUserId;
                        }

                        set
                        {
                                this.lastEditorUserId = value;
                        }
                }

                private Nullable<int> ownerUserId;

                public Nullable<int> OwnerUserId
                {
                        get
                        {
                                return this.ownerUserId.IsEmptyOrZeroOrNull() ? null : this.ownerUserId;
                        }

                        set
                        {
                                this.ownerUserId = value;
                        }
                }

                private Nullable<int> parentId;

                public Nullable<int> ParentId
                {
                        get
                        {
                                return this.parentId.IsEmptyOrZeroOrNull() ? null : this.parentId;
                        }

                        set
                        {
                                this.parentId = value;
                        }
                }

                private int postTypeId;

                [Required]
                public int PostTypeId
                {
                        get
                        {
                                return this.postTypeId;
                        }

                        set
                        {
                                this.postTypeId = value;
                        }
                }

                private int score;

                [Required]
                public int Score
                {
                        get
                        {
                                return this.score;
                        }

                        set
                        {
                                this.score = value;
                        }
                }

                private string tags;

                public string Tags
                {
                        get
                        {
                                return this.tags.IsEmptyOrZeroOrNull() ? null : this.tags;
                        }

                        set
                        {
                                this.tags = value;
                        }
                }

                private string title;

                public string Title
                {
                        get
                        {
                                return this.title.IsEmptyOrZeroOrNull() ? null : this.title;
                        }

                        set
                        {
                                this.title = value;
                        }
                }

                private int viewCount;

                [Required]
                public int ViewCount
                {
                        get
                        {
                                return this.viewCount;
                        }

                        set
                        {
                                this.viewCount = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>45fca81f7727255d605629af8310cc1b</Hash>
</Codenesium>*/