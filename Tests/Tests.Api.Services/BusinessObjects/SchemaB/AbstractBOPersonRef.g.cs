using Codenesium.DataConversionExtensions;
using System;

namespace TestsNS.Api.Services
{
	public abstract class AbstractBOPersonRef : AbstractBusinessObject
	{
		public AbstractBOPersonRef()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int personAId,
		                                  int personBId)
		{
			this.Id = id;
			this.PersonAId = personAId;
			this.PersonBId = personBId;
		}

		public int Id { get; private set; }

		public int PersonAId { get; private set; }

		public int PersonBId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4ed984f8b62eb10bffee4eb38af1ab16</Hash>
</Codenesium>*/