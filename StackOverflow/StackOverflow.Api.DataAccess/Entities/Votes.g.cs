using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("Votes", Schema="dbo")]
	public partial class Votes : AbstractEntity
	{
		public Votes()
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
		public virtual Posts PostIdNavigation { get; private set; }

		public void SetPostIdNavigation(Posts item)
		{
			this.PostIdNavigation = item;
		}

		[ForeignKey("UserId")]
		public virtual Users UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(Users item)
		{
			this.UserIdNavigation = item;
		}

		[ForeignKey("VoteTypeId")]
		public virtual VoteTypes VoteTypeIdNavigation { get; private set; }

		public void SetVoteTypeIdNavigation(VoteTypes item)
		{
			this.VoteTypeIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>39b4e4838eadb18043963e360bb99366</Hash>
</Codenesium>*/