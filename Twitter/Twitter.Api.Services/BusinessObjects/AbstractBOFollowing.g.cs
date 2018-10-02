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

		public virtual void SetProperties(string userId,
		                                  DateTime? dateFollowed,
		                                  string muted)
		{
			this.DateFollowed = dateFollowed;
			this.Muted = muted;
			this.UserId = userId;
		}

		public DateTime? DateFollowed { get; private set; }

		public string Muted { get; private set; }

		public string UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3d227e272fac35c60b101444f8b7567d</Hash>
</Codenesium>*/