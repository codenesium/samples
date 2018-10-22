using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractBOSpace : AbstractBusinessObject
	{
		public AbstractBOSpace()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string description,
		                                  string name)
		{
			this.Description = description;
			this.Id = id;
			this.Name = name;
		}

		public string Description { get; private set; }

		public int Id { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>460489991e7a2f5a1c9b4abfcb567fac</Hash>
</Codenesium>*/