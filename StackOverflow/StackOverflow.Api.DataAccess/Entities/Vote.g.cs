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
	}
}

/*<Codenesium>
    <Hash>58d0c2c9cc20ce3a9c4569fadef78b53</Hash>
</Codenesium>*/