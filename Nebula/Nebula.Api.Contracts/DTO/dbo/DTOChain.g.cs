using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class DTOChain: AbstractDTO
	{
		public DTOChain() : base()
		{}

		public void SetProperties(int id,
		                          int chainStatusId,
		                          Guid externalId,
		                          string name,
		                          int teamId)
		{
			this.ChainStatusId = chainStatusId.ToInt();
			this.ExternalId = externalId.ToGuid();
			this.Id = id.ToInt();
			this.Name = name;
			this.TeamId = teamId.ToInt();
		}

		public int ChainStatusId { get; set; }
		public Guid ExternalId { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public int TeamId { get; set; }
	}
}

/*<Codenesium>
    <Hash>491252645d67fa3e9d9f48a657f9693c</Hash>
</Codenesium>*/