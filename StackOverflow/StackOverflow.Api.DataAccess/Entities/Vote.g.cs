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
			int? bountyAmount,
			DateTime creationDate,
			int id,
			int postId,
			int? userId,
			int voteTypeId)
		{
			this.BountyAmount = bountyAmount;
			this.CreationDate = creationDate;
			this.Id = id;
			this.PostId = postId;
			this.UserId = userId;
			this.VoteTypeId = voteTypeId;
		}

		[Column("BountyAmount")]
		public int? BountyAmount { get; private set; }

		[Column("CreationDate")]
		public DateTime CreationDate { get; private set; }

		[Key]
		[Column("Id")]
		public int Id { get; private set; }

		[Column("PostId")]
		public int PostId { get; private set; }

		[Column("UserId")]
		public int? UserId { get; private set; }

		[Column("VoteTypeId")]
		public int VoteTypeId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4468959b0834284195e7728d4b6ea4f4</Hash>
</Codenesium>*/