using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractBOComment : AbstractBusinessObject
	{
		public AbstractBOComment()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  DateTime creationDate,
		                                  int postId,
		                                  int? score,
		                                  string text,
		                                  int? userId)
		{
			this.CreationDate = creationDate;
			this.Id = id;
			this.PostId = postId;
			this.Score = score;
			this.Text = text;
			this.UserId = userId;
		}

		public DateTime CreationDate { get; private set; }

		public int Id { get; private set; }

		public int PostId { get; private set; }

		public int? Score { get; private set; }

		public string Text { get; private set; }

		public int? UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4dccfbd0e514fc432d5c3b3bf1ced46a</Hash>
</Codenesium>*/