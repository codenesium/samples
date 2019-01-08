using Codenesium.DataConversionExtensions;
using System;

namespace TestsNS.Api.Services
{
	public abstract class AbstractBOVPerson : AbstractBusinessObject
	{
		public AbstractBOVPerson()
			: base()
		{
		}

		public virtual void SetProperties(int personId,
		                                  string personName)
		{
			this.PersonId = personId;
			this.PersonName = personName;
		}

		public int PersonId { get; private set; }

		public string PersonName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>53e23f4eca1640efd6f816334d2b2961</Hash>
</Codenesium>*/