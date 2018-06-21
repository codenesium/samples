using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowNS.Api.DataAccess
{
        [Table("Votes", Schema="dbo")]
        public partial class Votes : AbstractEntity
        {
                public Votes()
                {
                }

                public void SetProperties(
                        Nullable<int> bountyAmount,
                        DateTime creationDate,
                        int id,
                        int postId,
                        Nullable<int> userId,
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
                public Nullable<int> BountyAmount { get; private set; }

                [Column("CreationDate")]
                public DateTime CreationDate { get; private set; }

                [Key]
                [Column("Id")]
                public int Id { get; private set; }

                [Column("PostId")]
                public int PostId { get; private set; }

                [Column("UserId")]
                public Nullable<int> UserId { get; private set; }

                [Column("VoteTypeId")]
                public int VoteTypeId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>41757a48476a79eaa5c19ad36b141809</Hash>
</Codenesium>*/