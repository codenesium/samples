using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractBOSpaceFeature : AbstractBusinessObject
	{
		public AbstractBOSpaceFeature()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string name,
		                                  bool isDeleted)
		{
			this.Id = id;
			this.Name = name;
			this.IsDeleted = isDeleted;
		}

		public int Id { get; private set; }

		public string Name { get; private set; }

		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>757256c2df8402fdaa261444171746a7</Hash>
</Codenesium>*/