using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
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
    <Hash>bb93de21cc14c70cb4083e7fcb1944d4</Hash>
</Codenesium>*/