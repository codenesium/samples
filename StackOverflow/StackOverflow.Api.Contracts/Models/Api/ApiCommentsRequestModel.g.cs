using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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

                public virtual void SetProperties(
                        DateTime creationDate,
                        int postId,
                        int? score,
                        string text,
                        int? userId)
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

                private int? score;

                public int? Score
                {
                        get
                        {
                                return this.score;
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
        }
}

/*<Codenesium>
    <Hash>d84f9fe884021cdb13816410650846ea</Hash>
</Codenesium>*/