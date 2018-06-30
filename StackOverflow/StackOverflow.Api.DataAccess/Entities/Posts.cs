using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowNS.Api.DataAccess
{
        [Table("Posts", Schema="dbo")]
        public partial class Posts : AbstractEntity
        {
                public Posts()
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

                [Column("AcceptedAnswerId")]
                public int? AcceptedAnswerId { get; private set; }

                [Column("AnswerCount")]
                public int? AnswerCount { get; private set; }

                [Column("Body")]
                public string Body { get; private set; }

                [Column("ClosedDate")]
                public DateTime? ClosedDate { get; private set; }

                [Column("CommentCount")]
                public int? CommentCount { get; private set; }

                [Column("CommunityOwnedDate")]
                public DateTime? CommunityOwnedDate { get; private set; }

                [Column("CreationDate")]
                public DateTime CreationDate { get; private set; }

                [Column("FavoriteCount")]
                public int? FavoriteCount { get; private set; }

                [Key]
                [Column("Id")]
                public int Id { get; private set; }

                [Column("LastActivityDate")]
                public DateTime LastActivityDate { get; private set; }

                [Column("LastEditDate")]
                public DateTime? LastEditDate { get; private set; }

                [Column("LastEditorDisplayName")]
                public string LastEditorDisplayName { get; private set; }

                [Column("LastEditorUserId")]
                public int? LastEditorUserId { get; private set; }

                [Column("OwnerUserId")]
                public int? OwnerUserId { get; private set; }

                [Column("ParentId")]
                public int? ParentId { get; private set; }

                [Column("PostTypeId")]
                public int PostTypeId { get; private set; }

                [Column("Score")]
                public int Score { get; private set; }

                [Column("Tags")]
                public string Tags { get; private set; }

                [Column("Title")]
                public string Title { get; private set; }

                [Column("ViewCount")]
                public int ViewCount { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0ff4e0a8371183830089e9c68333e7aa</Hash>
</Codenesium>*/