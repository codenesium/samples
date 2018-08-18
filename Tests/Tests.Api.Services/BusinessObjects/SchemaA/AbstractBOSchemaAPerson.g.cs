using Codenesium.DataConversionExtensions;
using System;

namespace TestsNS.Api.Services
{
	public abstract class AbstractBOSchemaAPerson : AbstractBusinessObject
	{
		public AbstractBOSchemaAPerson()
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
    <Hash>f6ad5a1712206bb62773788d15d4dc6d</Hash>
</Codenesium>*/