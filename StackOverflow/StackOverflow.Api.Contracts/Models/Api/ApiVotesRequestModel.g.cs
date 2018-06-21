using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiVotesRequestModel : AbstractApiRequestModel
        {
                public ApiVotesRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        Nullable<int> bountyAmount,
                        DateTime creationDate,
                        int postId,
                        Nullable<int> userId,
                        int voteTypeId)
                {
                        this.BountyAmount = bountyAmount;
                        this.CreationDate = creationDate;
                        this.PostId = postId;
                        this.UserId = userId;
                        this.VoteTypeId = voteTypeId;
                }

                private Nullable<int> bountyAmount;

                public Nullable<int> BountyAmount
                {
                        get
                        {
                                return this.bountyAmount.IsEmptyOrZeroOrNull() ? null : this.bountyAmount;
                        }

                        set
                        {
                                this.bountyAmount = value;
                        }
                }

                private DateTime creationDate;

                [Required]
                public DateTime CreationDate
                {
                        get
                        {
                                return this.creationDate;
                        }

                        set
                        {
                                this.creationDate = value;
                        }
                }

                private int postId;

                [Required]
                public int PostId
                {
                        get
                        {
                                return this.postId;
                        }

                        set
                        {
                                this.postId = value;
                        }
                }

                private Nullable<int> userId;

                public Nullable<int> UserId
                {
                        get
                        {
                                return this.userId.IsEmptyOrZeroOrNull() ? null : this.userId;
                        }

                        set
                        {
                                this.userId = value;
                        }
                }

                private int voteTypeId;

                [Required]
                public int VoteTypeId
                {
                        get
                        {
                                return this.voteTypeId;
                        }

                        set
                        {
                                this.voteTypeId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>52f779d638e7c8777eb01ce5bb2459f3</Hash>
</Codenesium>*/