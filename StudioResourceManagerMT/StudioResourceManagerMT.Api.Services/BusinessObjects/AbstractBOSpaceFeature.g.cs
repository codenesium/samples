using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractBOSpaceFeature : AbstractBusinessObject
	{
		public AbstractBOSpaceFeature()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string name)
		{
			this.Id = id;
			this.Name = name;
		}

		public int Id { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a7fa7438dd10162a53f1b90db32cac1f</Hash>
</Codenesium>*/