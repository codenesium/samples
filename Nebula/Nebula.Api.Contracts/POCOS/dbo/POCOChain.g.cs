using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class POCOChain
	{
		public POCOChain()
		{}

		public POCOChain(
			int id,
			string name,
			int teamId,
			int chainStatusId,
			Guid externalId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.ExternalId = externalId;

			this.TeamId = new ReferenceEntity<int>(teamId,
			                                       "Team");
			this.ChainStatusId = new ReferenceEntity<int>(chainStatusId,
			                                              "ChainStatus");
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public ReferenceEntity<int> TeamId { get; set; }
		public ReferenceEntity<int> ChainStatusId { get; set; }
		public Guid ExternalId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTeamIdValue { get; set; } = true;

		public bool ShouldSerializeTeamId()
		{
			return this.ShouldSerializeTeamIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeChainStatusIdValue { get; set; } = true;

		public bool ShouldSerializeChainStatusId()
		{
			return this.ShouldSerializeChainStatusIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeExternalIdValue { get; set; } = true;

		public bool ShouldSerializeExternalId()
		{
			return this.ShouldSerializeExternalIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeTeamIdValue = false;
			this.ShouldSerializeChainStatusIdValue = false;
			this.ShouldSerializeExternalIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>4ad4ddbad487ab01ef2a17b4d3e4567c</Hash>
</Codenesium>*/