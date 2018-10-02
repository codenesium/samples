using Codenesium.DataConversionExtensions;
using System;

namespace TestsNS.Api.Services
{
	public abstract class AbstractBOColumnSameAsFKTable : AbstractBusinessObject
	{
		public AbstractBOColumnSameAsFKTable()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int person,
		                                  int personId)
		{
			this.Id = id;
			this.Person = person;
			this.PersonId = personId;
		}

		public int Id { get; private set; }

		public int Person { get; private set; }

		public int PersonId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f77cc463f196edbb5d91150d860df128</Hash>
</Codenesium>*/