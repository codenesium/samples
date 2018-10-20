using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractBOEventStatus : AbstractBusinessObject
	{
		public AbstractBOEventStatus()
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
    <Hash>cf3818c7c2312d376e41803cfccae62a</Hash>
</Codenesium>*/