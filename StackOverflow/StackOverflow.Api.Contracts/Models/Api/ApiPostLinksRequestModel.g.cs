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

                [JsonProperty]
                public DateTime CreationDate { get; private set; }

                [JsonProperty]
                public int LinkTypeId { get; private set; }

                [JsonProperty]
                public int PostId { get; private set; }

                [JsonProperty]
                public int RelatedPostId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>33b209a33e1efcddd4eefc04914d5cbe</Hash>
</Codenesium>*/