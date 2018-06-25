using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiTagsRequestModel : AbstractApiRequestModel
        {
                public ApiTagsRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int count,
                        int excerptPostId,
                        string tagName,
                        int wikiPostId)
                {
                        this.Count = count;
                        this.ExcerptPostId = excerptPostId;
                        this.TagName = tagName;
                        this.WikiPostId = wikiPostId;
                }

                private int count;

                [Required]
                public int Count
                {
                        get
                        {
                                return this.count;
                        }

                        set
                        {
                                this.count = value;
                        }
                }

                private int excerptPostId;

                [Required]
                public int ExcerptPostId
                {
                        get
                        {
                                return this.excerptPostId;
                        }

                        set
                        {
                                this.excerptPostId = value;
                        }
                }

                private string tagName;

                [Required]
                public string TagName
                {
                        get
                        {
                                return this.tagName;
                        }

                        set
                        {
                                this.tagName = value;
                        }
                }

                private int wikiPostId;

                [Required]
                public int WikiPostId
                {
                        get
                        {
                                return this.wikiPostId;
                        }

                        set
                        {
                                this.wikiPostId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>4b0dd959398ab1f2686e6ea5adf9765b</Hash>
</Codenesium>*/