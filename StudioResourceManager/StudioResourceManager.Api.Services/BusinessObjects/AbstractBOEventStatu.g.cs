using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractBOEventStatu : AbstractBusinessObject
	{
		public AbstractBOEventStatu()
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
    <Hash>9e0e44f1dbed868fe13459590a50aa7e</Hash>
</Codenesium>*/