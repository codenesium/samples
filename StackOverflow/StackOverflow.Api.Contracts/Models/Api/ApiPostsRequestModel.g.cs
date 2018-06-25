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

                public virtual void SetProperties(
                        int? acceptedAnswerId,
                        int? answerCount,
                        string body,
                        DateTime? closedDate,
                        int? commentCount,
                        DateTime? communityOwnedDate,
                        DateTime creationDate,
                        int? favoriteCount,
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

                private int? acceptedAnswerId;

                public int? AcceptedAnswerId
                {
                        get
                        {
                                return this.acceptedAnswerId;
                        }

                        set
                        {
                                this.acceptedAnswerId = value;
                        }
                }

                private int? answerCount;

                public int? AnswerCount
                {
                        get
                        {
                                return this.answerCount;
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

                private DateTime? closedDate;

                public DateTime? ClosedDate
                {
                        get
                        {
                                return this.closedDate;
                        }

                        set
                        {
                                this.closedDate = value;
                        }
                }

                private int? commentCount;

                public int? CommentCount
                {
                        get
                        {
                                return this.commentCount;
                        }

                        set
                        {
                                this.commentCount = value;
                        }
                }

                private DateTime? communityOwnedDate;

                public DateTime? CommunityOwnedDate
                {
                        get
                        {
                                return this.communityOwnedDate;
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

                private int? favoriteCount;

                public int? FavoriteCount
                {
                        get
                        {
                                return this.favoriteCount;
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

                private DateTime? lastEditDate;

                public DateTime? LastEditDate
                {
                        get
                        {
                                return this.lastEditDate;
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
                                return this.lastEditorDisplayName;
                        }

                        set
                        {
                                this.lastEditorDisplayName = value;
                        }
                }

                private int? lastEditorUserId;

                public int? LastEditorUserId
                {
                        get
                        {
                                return this.lastEditorUserId;
                        }

                        set
                        {
                                this.lastEditorUserId = value;
                        }
                }

                private int? ownerUserId;

                public int? OwnerUserId
                {
                        get
                        {
                                return this.ownerUserId;
                        }

                        set
                        {
                                this.ownerUserId = value;
                        }
                }

                private int? parentId;

                public int? ParentId
                {
                        get
                        {
                                return this.parentId;
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
                                return this.tags;
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
                                return this.title;
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
    <Hash>1727df80426d84e274b849a61f40517c</Hash>
</Codenesium>*/