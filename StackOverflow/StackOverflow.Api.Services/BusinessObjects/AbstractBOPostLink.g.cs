using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractBOPostLink : AbstractBusinessObject
	{
		public AbstractBOPostLink()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  DateTime creationDate,
		                                  int linkTypeId,
		                                  int postId,
		                                  int relatedPostId)
		{
			this.CreationDate = creationDate;
			this.Id = id;
			this.LinkTypeId = linkTypeId;
			this.PostId = postId;
			this.RelatedPostId = relatedPostId;
		}

		public DateTime CreationDate { get; private set; }

		public int Id { get; private set; }

		public int LinkTypeId { get; private set; }

		public int PostId { get; private set; }

		public int RelatedPostId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b4b0cc1484885f097791cbd97115e51e</Hash>
</Codenesium>*/