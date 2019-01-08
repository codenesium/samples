using Codenesium.DataConversionExtensions;
using System;

namespace TestsNS.Api.Services
{
	public abstract class AbstractBOPerson : AbstractBusinessObject
	{
		public AbstractBOPerson()
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
    <Hash>201a1ad80e737c77fa3e4d94d8379450</Hash>
</Codenesium>*/