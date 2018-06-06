using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
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
    <Hash>84b5276d468d590549655b657a0c17fe</Hash>
</Codenesium>*/