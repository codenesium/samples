using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class DTOClasp: AbstractDTO
	{
		public DTOClasp() : base()
		{}

		public void SetProperties(int id,
		                          int nextChainId,
		                          int previousChainId)
		{
			this.Id = id.ToInt();
			this.NextChainId = nextChainId.ToInt();
			this.PreviousChainId = previousChainId.ToInt();
		}

		public int Id { get; set; }
		public int NextChainId { get; set; }
		public int PreviousChainId { get; set; }
	}
}

/*<Codenesium>
    <Hash>3b44507b0e274ead896edcb6301ee24e</Hash>
</Codenesium>*/