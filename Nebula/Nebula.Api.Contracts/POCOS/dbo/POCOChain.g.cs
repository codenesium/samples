using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class POCOChain
	{
		public POCOChain()
		{}

		public POCOChain(int id,
		                 string name,
		                 int teamId,
		                 int chainStatusId,
		                 Guid externalId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.ExternalId = externalId;

			TeamId = new ReferenceEntity<int>(teamId,
			                                  "Team");
			ChainStatusId = new ReferenceEntity<int>(chainStatusId,
			                                         "ChainStatus");
		}

		public int Id {get; set;}
		public string Name {get; set;}
		public ReferenceEntity<int>TeamId {get; set;}
		public ReferenceEntity<int>ChainStatusId {get; set;}
		public Guid ExternalId {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeIdValue {get; set;} = true;

		public bool ShouldSerializeId()
		{
			return ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTeamIdValue {get; set;} = true;

		public bool ShouldSerializeTeamId()
		{
			return ShouldSerializeTeamIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeChainStatusIdValue {get; set;} = true;

		public bool ShouldSerializeChainStatusId()
		{
			return ShouldSerializeChainStatusIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeExternalIdValue {get; set;} = true;

		public bool ShouldSerializeExternalId()
		{
			return ShouldSerializeExternalIdValue;
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
    <Hash>5a14799d8617c10ed7590453bbc3a46b</Hash>
</Codenesium>*/