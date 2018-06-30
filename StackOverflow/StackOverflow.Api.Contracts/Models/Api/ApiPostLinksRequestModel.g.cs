using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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

                public virtual void SetProperties(
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
    <Hash>c4361cc921e6d0e7543ac051b3883432</Hash>
</Codenesium>*/