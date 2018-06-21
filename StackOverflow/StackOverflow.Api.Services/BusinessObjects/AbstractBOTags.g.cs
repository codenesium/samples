using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
        public abstract class AbstractBOTags : AbstractBusinessObject
        {
                public AbstractBOTags()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  int count,
                                                  int excerptPostId,
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
        }
}

/*<Codenesium>
    <Hash>204e8685ecf196566af5687208af87e9</Hash>
</Codenesium>*/