using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiPostLinksRequestModel : AbstractApiRequestModel
        {
                public ApiPostLinksRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        DateTime creationDate,
                        int linkTypeId,
                        int postId,
                        int relatedPostId)
                {
                        this.CreationDate = creationDate;
                        this.LinkTypeId = linkTypeId;
                        this.PostId = postId;
                        this.RelatedPostId = relatedPostId;
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

                private int linkTypeId;

                [Required]
                public int LinkTypeId
                {
                        get
                        {
                                return this.linkTypeId;
                        }

                        set
                        {
                                this.linkTypeId = value;
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

                private int relatedPostId;

                [Required]
                public int RelatedPostId
                {
                        get
                        {
                                return this.relatedPostId;
                        }

                        set
                        {
                                this.relatedPostId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>e382ede5eb6e8bece23c47d32651b36f</Hash>
</Codenesium>*/