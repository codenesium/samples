using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("Posts", Schema="dbo")]
	public partial class Posts : AbstractEntity
	{
		public Posts()
		{
		}

		public virtual void SetProperties(
			int id,
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
			string tag,
			string title,
			int viewCount)
		{
			this.Id = id;
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
			this.Tag = tag;
			this.Title = title;
			this.ViewCount = viewCount;
		}

		[Column("AcceptedAnswerId")]
		public virtual int? AcceptedAnswerId { get; private set; }

		[Column("AnswerCount")]
		public virtual int? AnswerCount { get; private set; }

		[Column("Body")]
		public virtual string Body { get; private set; }

		[Column("ClosedDate")]
		public virtual DateTime? ClosedDate { get; private set; }

		[Column("CommentCount")]
		public virtual int? CommentCount { get; private set; }

		[Column("CommunityOwnedDate")]
		public virtual DateTime? CommunityOwnedDate { get; private set; }

		[Column("CreationDate")]
		public virtual DateTime CreationDate { get; private set; }

		[Column("FavoriteCount")]
		public virtual int? FavoriteCount { get; private set; }

		[Key]
		[Column("Id")]
		public virtual int Id { get; private set; }

		[Column("LastActivityDate")]
		public virtual DateTime LastActivityDate { get; private set; }

		[Column("LastEditDate")]
		public virtual DateTime? LastEditDate { get; private set; }

		[MaxLength(40)]
		[Column("LastEditorDisplayName")]
		public virtual string LastEditorDisplayName { get; private set; }

		[Column("LastEditorUserId")]
		public virtual int? LastEditorUserId { get; private set; }

		[Column("OwnerUserId")]
		public virtual int? OwnerUserId { get; private set; }

		[Column("ParentId")]
		public virtual int? ParentId { get; private set; }

		[Column("PostTypeId")]
		public virtual int PostTypeId { get; private set; }

		[Column("Score")]
		public virtual int Score { get; private set; }

		[MaxLength(150)]
		[Column("Tags")]
		public virtual string Tag { get; private set; }

		[MaxLength(250)]
		[Column("Title")]
		public virtual string Title { get; private set; }

		[Column("ViewCount")]
		public virtual int ViewCount { get; private set; }

		[ForeignKey("LastEditorUserId")]
		public virtual Users LastEditorUserIdNavigation { get; private set; }

		public void SetLastEditorUserIdNavigation(Users item)
		{
			this.LastEditorUserIdNavigation = item;
		}

		[ForeignKey("OwnerUserId")]
		public virtual Users OwnerUserIdNavigation { get; private set; }

		public void SetOwnerUserIdNavigation(Users item)
		{
			this.OwnerUserIdNavigation = item;
		}

		[ForeignKey("ParentId")]
		public virtual Posts ParentIdNavigation { get; private set; }

		public void SetParentIdNavigation(Posts item)
		{
			this.ParentIdNavigation = item;
		}

		[ForeignKey("PostTypeId")]
		public virtual PostTypes PostTypeIdNavigation { get; private set; }

		public void SetPostTypeIdNavigation(PostTypes item)
		{
			this.PostTypeIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>e24d2f797a29fe09a5888abdd6954870</Hash>
</Codenesium>*/