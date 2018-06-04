using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class BOClasp: AbstractBusinessObject
	{
		public BOClasp() : base()
		{}

		public void SetProperties(int id,
		                          int nextChainId,
		                          int previousChainId)
		{
			this.Id = id.ToInt();
			this.NextChainId = nextChainId.ToInt();
			this.PreviousChainId = previousChainId.ToInt();
		}

		public int Id { get; private set; }
		public int NextChainId { get; private set; }
		public int PreviousChainId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9cee0da3dac578ae93bd301331de3d43</Hash>
</Codenesium>*/