using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiTagsResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int count,
                        int excerptPostId,
                        string tagName,
                        int wikiPostId)
                {
                        this.Id = id;
                        this.Count = count;
                        this.ExcerptPostId = excerptPostId;
                        this.TagName = tagName;
                        this.WikiPostId = wikiPostId;
                }

                [Required]
                [JsonProperty]
                public int Count { get; private set; }

                [Required]
                [JsonProperty]
                public int ExcerptPostId { get; private set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string TagName { get; private set; }

                [Required]
                [JsonProperty]
                public int WikiPostId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c0d4a3be2462d1b5df4de0727d6c4c09</Hash>
</Codenesium>*/