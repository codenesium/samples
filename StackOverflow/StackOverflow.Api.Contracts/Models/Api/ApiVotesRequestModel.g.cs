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

                public virtual void SetProperties(
                        int? bountyAmount,
                        DateTime creationDate,
                        int postId,
                        int? userId,
                        int voteTypeId)
                {
                        this.BountyAmount = bountyAmount;
                        this.CreationDate = creationDate;
                        this.PostId = postId;
                        this.UserId = userId;
                        this.VoteTypeId = voteTypeId;
                }

                private int? bountyAmount;

                public int? BountyAmount
                {
                        get
                        {
                                return this.bountyAmount;
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

                private int? userId;

                public int? UserId
                {
                        get
                        {
                                return this.userId;
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
    <Hash>f0b3210c40b202ee70acd6e1b53fb9ce</Hash>
</Codenesium>*/