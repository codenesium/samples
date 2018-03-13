using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class POCOChain
	{
		public POCOChain()
		{}

		public POCOChain(int chainStatusId,
		                 Guid externalId,
		                 int id,
		                 string name,
		                 int teamId)
		{
			this.ExternalId = externalId;
			this.Id = id.ToInt();
			this.Name = name;

			ChainStatusId = new ReferenceEntity<int>(chainStatusId,
			                                         "ChainStatus");
			TeamId = new ReferenceEntity<int>(teamId,
			                                  "Team");
		}

		public ReferenceEntity<int>ChainStatusId {get; set;}
		public Guid ExternalId {get; set;}
		public int Id {get; set;}
		public string Name {get; set;}
		public ReferenceEntity<int>TeamId {get; set;}

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
    <Hash>4887add7b43a445ca60984e0b5ae4c4c</Hash>
</Codenesium>*/