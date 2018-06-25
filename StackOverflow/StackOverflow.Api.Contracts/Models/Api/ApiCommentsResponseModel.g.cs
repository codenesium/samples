using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiCommentsResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        DateTime creationDate,
                        int id,
                        int postId,
                        int? score,
                        string text,
                        int? userId)
                {
                        this.CreationDate = creationDate;
                        this.Id = id;
                        this.PostId = postId;
                        this.Score = score;
                        this.Text = text;
                        this.UserId = userId;
                }

                public DateTime CreationDate { get; private set; }

                public int Id { get; private set; }

                public int PostId { get; private set; }

                public int? Score { get; private set; }

                public string Text { get; private set; }

                public int? UserId { get; private set; }

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
                public bool ShouldSerializeScoreValue { get; set; } = true;

                public bool ShouldSerializeScore()
                {
                        return this.ShouldSerializeScoreValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTextValue { get; set; } = true;

                public bool ShouldSerializeText()
                {
                        return this.ShouldSerializeTextValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeUserIdValue { get; set; } = true;

                public bool ShouldSerializeUserId()
                {
                        return this.ShouldSerializeUserIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCreationDateValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializePostIdValue = false;
                        this.ShouldSerializeScoreValue = false;
                        this.ShouldSerializeTextValue = false;
                        this.ShouldSerializeUserIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>9d3f73ad8140fa5f849e2c7e5ca80807</Hash>
</Codenesium>*/