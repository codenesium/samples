using Codenesium.DataConversionExtensions;
using System;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractBOFollowing : AbstractBusinessObject
	{
		public AbstractBOFollowing()
			: base()
		{
		}

		public virtual void SetProperties(int userId,
		                                  DateTime? dateFollowed,
		                                  string muted)
		{
			this.DateFollowed = dateFollowed;
			this.Muted = muted;
			this.UserId = userId;
		}

		public DateTime? DateFollowed { get; private set; }

		public string Muted { get; private set; }

		public int UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>677fb11be9975770e64f5c523b4c58f7</Hash>
</Codenesium>*/