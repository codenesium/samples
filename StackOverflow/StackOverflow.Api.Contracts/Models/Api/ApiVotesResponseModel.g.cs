using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiVotesResponseModel : AbstractApiResponseModel
        {
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

                public int? BountyAmount { get; private set; }

                public DateTime CreationDate { get; private set; }

                public int Id { get; private set; }

                public int PostId { get; private set; }

                public int? UserId { get; private set; }

                public int VoteTypeId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>f10b8e503deeed6f451b32249acb7807</Hash>
</Codenesium>*/