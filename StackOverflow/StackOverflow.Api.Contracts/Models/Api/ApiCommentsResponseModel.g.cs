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
                        int id,
                        DateTime creationDate,
                        int postId,
                        int? score,
                        string text,
                        int? userId)
                {
                        this.Id = id;
                        this.CreationDate = creationDate;
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
        }
}

/*<Codenesium>
    <Hash>5eba9cf685e79b48cde4cff8680d498f</Hash>
</Codenesium>*/