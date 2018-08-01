using Codenesium.DataConversionExtensions;
using System;

namespace TestsNS.Api.Services
{
	public abstract class AbstractBOSchemaBPerson : AbstractBusinessObject
	{
		public AbstractBOSchemaBPerson()
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
    <Hash>78596fb5a11020b26929e45e344316dd</Hash>
</Codenesium>*/