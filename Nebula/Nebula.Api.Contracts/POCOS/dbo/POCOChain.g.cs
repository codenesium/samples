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
			int chainStatusId,
			Guid externalId,
			int id,
			string name,
			int teamId)
		{
			this.ExternalId = externalId.ToGuid();
			this.Id = id.ToInt();
			this.Name = name.ToString();

			this.ChainStatusId = new ReferenceEntity<int>(chainStatusId,
			                                              nameof(ApiResponse.ChainStatus));
			this.TeamId = new ReferenceEntity<int>(teamId,
			                                       nameof(ApiResponse.Teams));
		}

		public ReferenceEntity<int> ChainStatusId { get; set; }
		public Guid ExternalId { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public ReferenceEntity<int> TeamId { get; set; }

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

		public void DisableAllFields()
		{
			this.ShouldSerializeChainStatusIdValue = false;
			this.ShouldSerializeExternalIdValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeTeamIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>8114fca92e720dc2e83833201a7c3f1a</Hash>
</Codenesium>*/