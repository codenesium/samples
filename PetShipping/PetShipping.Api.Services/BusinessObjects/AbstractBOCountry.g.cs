using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOCountry : AbstractBusinessObject
	{
		public AbstractBOCountry()
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
    <Hash>eaccc6bc79a1c46a3a2f4f8f93fc68bc</Hash>
</Codenesium>*/