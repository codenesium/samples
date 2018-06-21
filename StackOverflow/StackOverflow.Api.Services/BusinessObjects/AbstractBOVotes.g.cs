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
                                                  Nullable<int> bountyAmount,
                                                  DateTime creationDate,
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

                public Nullable<int> BountyAmount { get; private set; }

                public DateTime CreationDate { get; private set; }

                public int Id { get; private set; }

                public int PostId { get; private set; }

                public Nullable<int> UserId { get; private set; }

                public int VoteTypeId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>dba7f883acc96aa40f53d18b61ea1ec4</Hash>
</Codenesium>*/