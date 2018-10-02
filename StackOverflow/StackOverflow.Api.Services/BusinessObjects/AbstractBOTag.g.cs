using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractBOTag : AbstractBusinessObject
	{
		public AbstractBOTag()
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
    <Hash>429f08e857c017b15ca1984add3abe0d</Hash>
</Codenesium>*/