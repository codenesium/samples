using Codenesium.DataConversionExtensions;
using System;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractBOOrganization : AbstractBusinessObject
	{
		public AbstractBOOrganization()
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
    <Hash>edf3133e6d0b88c61eeef8e179d275dd</Hash>
</Codenesium>*/