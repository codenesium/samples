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

                public int? BountyAmount { get; private set; }

                public DateTime CreationDate { get; private set; }

                public int Id { get; private set; }

                public int PostId { get; private set; }

                public int? UserId { get; private set; }

                public int VoteTypeId { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeBountyAmountValue { get; set; } = true;

                public bool ShouldSerializeBountyAmount()
                {
                        return this.ShouldSerializeBountyAmountValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCreationDateValue { get; set; } = true;

                public bool ShouldSerializeCreationDate()
                {
                        return this.ShouldSerializeCreationDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePostIdValue { get; set; } = true;

                public bool ShouldSerializePostId()
                {
                        return this.ShouldSerializePostIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeUserIdValue { get; set; } = true;

                public bool ShouldSerializeUserId()
                {
                        return this.ShouldSerializeUserIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVoteTypeIdValue { get; set; } = true;

                public bool ShouldSerializeVoteTypeId()
                {
                        return this.ShouldSerializeVoteTypeIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeBountyAmountValue = false;
                        this.ShouldSerializeCreationDateValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializePostIdValue = false;
                        this.ShouldSerializeUserIdValue = false;
                        this.ShouldSerializeVoteTypeIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>7c44fd0c7d668087fc9c8680ab3e67fb</Hash>
</Codenesium>*/