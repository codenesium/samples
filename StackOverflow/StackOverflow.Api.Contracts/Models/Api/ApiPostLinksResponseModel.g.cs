using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiPostLinksResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        DateTime creationDate,
                        int linkTypeId,
                        int postId,
                        int relatedPostId)
                {
                        this.Id = id;
                        this.CreationDate = creationDate;
                        this.LinkTypeId = linkTypeId;
                        this.PostId = postId;
                        this.RelatedPostId = relatedPostId;
                }

                [Required]
                [JsonProperty]
                public DateTime CreationDate { get; private set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public int LinkTypeId { get; private set; }

                [Required]
                [JsonProperty]
                public int PostId { get; private set; }

                [Required]
                [JsonProperty]
                public int RelatedPostId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>74750d257b5b9c262453828904b1cf6e</Hash>
</Codenesium>*/