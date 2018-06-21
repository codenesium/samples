using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiCommentsRequestModel : AbstractApiRequestModel
        {
                public ApiCommentsRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        DateTime creationDate,
                        int postId,
                        Nullable<int> score,
                        string text,
                        Nullable<int> userId)
                {
                        this.CreationDate = creationDate;
                        this.PostId = postId;
                        this.Score = score;
                        this.Text = text;
                        this.UserId = userId;
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

                private Nullable<int> score;

                public Nullable<int> Score
                {
                        get
                        {
                                return this.score.IsEmptyOrZeroOrNull() ? null : this.score;
                        }

                        set
                        {
                                this.score = value;
                        }
                }

                private string text;

                [Required]
                public string Text
                {
                        get
                        {
                                return this.text;
                        }

                        set
                        {
                                this.text = value;
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
        }
}

/*<Codenesium>
    <Hash>7791b55e210361582fd22ee4b5882665</Hash>
</Codenesium>*/