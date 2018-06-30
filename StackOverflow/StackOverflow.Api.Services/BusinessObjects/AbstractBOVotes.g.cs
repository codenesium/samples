using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
        public abstract class AbstractBOVotes : AbstractBusinessObject
        {
                public AbstractBOVotes()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  int? bountyAmount,
                                                  DateTime creationDate,
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

                public int? BountyAmount { get; private set; }

                public DateTime CreationDate { get; private set; }

                public int Id { get; private set; }

                public int PostId { get; private set; }

                public int? UserId { get; private set; }

                public int VoteTypeId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>76aa4d2f13c0dc4e90b0fb0baa2ef3df</Hash>
</Codenesium>*/