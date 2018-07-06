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

                public int Count { get; private set; }

                public int ExcerptPostId { get; private set; }

                public int Id { get; private set; }

                public string TagName { get; private set; }

                public int WikiPostId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0f2abb7aeda1e5cde6da9c0212498d2f</Hash>
</Codenesium>*/