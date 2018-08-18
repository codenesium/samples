using Codenesium.DataConversionExtensions;
using System;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractBOTransactionStatus : AbstractBusinessObject
	{
		public AbstractBOTransactionStatus()
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
    <Hash>210af2a4985d387f9a0b227dedfc81d4</Hash>
</Codenesium>*/