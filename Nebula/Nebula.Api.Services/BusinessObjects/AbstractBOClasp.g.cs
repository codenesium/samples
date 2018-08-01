using Codenesium.DataConversionExtensions;
using System;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractBOClasp : AbstractBusinessObject
	{
		public AbstractBOClasp()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int nextChainId,
		                                  int previousChainId)
		{
			this.Id = id;
			this.NextChainId = nextChainId;
			this.PreviousChainId = previousChainId;
		}

		public int Id { get; private set; }

		public int NextChainId { get; private set; }

		public int PreviousChainId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e2b5c8fca772ea559e19c0baafdc4c71</Hash>
</Codenesium>*/