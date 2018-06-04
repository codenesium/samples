using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class BOChain: AbstractBusinessObject
	{
		public BOChain() : base()
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

		public int ChainStatusId { get; private set; }
		public Guid ExternalId { get; private set; }
		public int Id { get; private set; }
		public string Name { get; private set; }
		public int TeamId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>dacf94a7762a77626166afdeb231e812</Hash>
</Codenesium>*/