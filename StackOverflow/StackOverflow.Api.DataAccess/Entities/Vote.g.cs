using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("Votes", Schema="dbo")]
	public partial class Vote : AbstractEntity
	{
		public Vote()
		{
		}

		public virtual void SetProperties(
			int id,
			int? bountyAmount,
			DateTime creationDate,
			int postId,
			int? userId,
			int voteTypeId)
		{
			this.Id = id;
			this.BountyAmount = bountyAmount;
			this.CreationDate = creationDate;
			this.PostId = postId;
			this.UserId = userId;
			this.VoteTypeId = voteTypeId;
		}

		[Column("BountyAmount")]
		public virtual int? BountyAmount { get; private set; }

		[Column("CreationDate")]
		public virtual DateTime CreationDate { get; private set; }

		[Key]
		[Column("Id")]
		public virtual int Id { get; private set; }

		[Column("PostId")]
		public virtual int PostId { get; private set; }

		[Column("UserId")]
		public virtual int? UserId { get; private set; }

		[Column("VoteTypeId")]
		public virtual int VoteTypeId { get; private set; }

		[ForeignKey("PostId")]
		public virtual Post PostIdNavigation { get; private set; }

		public void SetPostIdNavigation(Post item)
		{
			this.PostIdNavigation = item;
		}

		[ForeignKey("UserId")]
		public virtual User UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(User item)
		{
			this.UserIdNavigation = item;
		}

		[ForeignKey("VoteTypeId")]
		public virtual VoteType VoteTypeIdNavigation { get; private set; }

		public void SetVoteTypeIdNavigation(VoteType item)
		{
			this.VoteTypeIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>84e86076a18e7ffedf53595758c7443f</Hash>
</Codenesium>*/