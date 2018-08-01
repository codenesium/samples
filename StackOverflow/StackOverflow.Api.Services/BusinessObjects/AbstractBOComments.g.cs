using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractBOComments : AbstractBusinessObject
	{
		public AbstractBOComments()
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
    <Hash>3b1a5bfd933732d45e5f510455663b4e</Hash>
</Codenesium>*/