using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
        public abstract class AbstractBOPosts : AbstractBusinessObject
        {
                public AbstractBOPosts()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
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

                public Nullable<int> AcceptedAnswerId { get; private set; }

                public Nullable<int> AnswerCount { get; private set; }

                public string Body { get; private set; }

                public Nullable<DateTime> ClosedDate { get; private set; }

                public Nullable<int> CommentCount { get; private set; }

                public Nullable<DateTime> CommunityOwnedDate { get; private set; }

                public DateTime CreationDate { get; private set; }

                public Nullable<int> FavoriteCount { get; private set; }

                public int Id { get; private set; }

                public DateTime LastActivityDate { get; private set; }

                public Nullable<DateTime> LastEditDate { get; private set; }

                public string LastEditorDisplayName { get; private set; }

                public Nullable<int> LastEditorUserId { get; private set; }

                public Nullable<int> OwnerUserId { get; private set; }

                public Nullable<int> ParentId { get; private set; }

                public int PostTypeId { get; private set; }

                public int Score { get; private set; }

                public string Tags { get; private set; }

                public string Title { get; private set; }

                public int ViewCount { get; private set; }
        }
}

/*<Codenesium>
    <Hash>df7ef0b88008ca83fd86677ea1099173</Hash>
</Codenesium>*/