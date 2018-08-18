using Codenesium.DataConversionExtensions;
using System;

namespace FileServiceNS.Api.Services
{
	public abstract class AbstractBOVersionInfo : AbstractBusinessObject
	{
		public AbstractBOVersionInfo()
			: base()
		{
		}

		public virtual void SetProperties(long version,
		                                  DateTime? appliedOn,
		                                  string description)
		{
			this.AppliedOn = appliedOn;
			this.Description = description;
			this.Version = version;
		}

		public DateTime? AppliedOn { get; private set; }

		public string Description { get; private set; }

		public long Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f59c9f34d9cb995bcedc9d82a1908afb</Hash>
</Codenesium>*/