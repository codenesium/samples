using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public abstract class AbstractApiTagsResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int count,
                        int excerptPostId,
                        int id,
                        string tagName,
                        int wikiPostId)
                {
                        this.Count = count;
                        this.ExcerptPostId = excerptPostId;
                        this.Id = id;
                        this.TagName = tagName;
                        this.WikiPostId = wikiPostId;
                }

                public int Count { get; private set; }

                public int ExcerptPostId { get; private set; }

                public int Id { get; private set; }

                public string TagName { get; private set; }

                public int WikiPostId { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeCountValue { get; set; } = true;

                public bool ShouldSerializeCount()
                {
                        return this.ShouldSerializeCountValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeExcerptPostIdValue { get; set; } = true;

                public bool ShouldSerializeExcerptPostId()
                {
                        return this.ShouldSerializeExcerptPostIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTagNameValue { get; set; } = true;

                public bool ShouldSerializeTagName()
                {
                        return this.ShouldSerializeTagNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeWikiPostIdValue { get; set; } = true;

                public bool ShouldSerializeWikiPostId()
                {
                        return this.ShouldSerializeWikiPostIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCountValue = false;
                        this.ShouldSerializeExcerptPostIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeTagNameValue = false;
                        this.ShouldSerializeWikiPostIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>ba299c3469ad736e383eb9f9fca8b902</Hash>
</Codenesium>*/