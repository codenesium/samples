using Codenesium.DataConversionExtensions;
using System;

namespace NebulaNS.Api.Services
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
    <Hash>1954b1b1e35e4e1b1c8cde6b76958b1e</Hash>
</Codenesium>*/