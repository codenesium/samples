using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NebulaNS.Api.Contracts
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.Chains.ForEach(x => this.AddChain(x));
			from.ChainStatuses.ForEach(x => this.AddChainStatus(x));
			from.Links.ForEach(x => this.AddLink(x));
			from.LinkLogs.ForEach(x => this.AddLinkLog(x));
			from.LinkStatuses.ForEach(x => this.AddLinkStatus(x));
			from.Machines.ForEach(x => this.AddMachine(x));
			from.Organizations.ForEach(x => this.AddOrganization(x));
			from.Teams.ForEach(x => this.AddTeam(x));
			from.VersionInfoes.ForEach(x => this.AddVersionInfo(x));
		}

		public List<ApiChainResponseModel> Chains { get; private set; } = new List<ApiChainResponseModel>();

		public List<ApiChainStatusResponseModel> ChainStatuses { get; private set; } = new List<ApiChainStatusResponseModel>();

		public List<ApiLinkResponseModel> Links { get; private set; } = new List<ApiLinkResponseModel>();

		public List<ApiLinkLogResponseModel> LinkLogs { get; private set; } = new List<ApiLinkLogResponseModel>();

		public List<ApiLinkStatusResponseModel> LinkStatuses { get; private set; } = new List<ApiLinkStatusResponseModel>();

		public List<ApiMachineResponseModel> Machines { get; private set; } = new List<ApiMachineResponseModel>();

		public List<ApiOrganizationResponseModel> Organizations { get; private set; } = new List<ApiOrganizationResponseModel>();

		public List<ApiTeamResponseModel> Teams { get; private set; } = new List<ApiTeamResponseModel>();

		public List<ApiVersionInfoResponseModel> VersionInfoes { get; private set; } = new List<ApiVersionInfoResponseModel>();

		[JsonIgnore]
		public bool ShouldSerializeChainsValue { get; private set; } = true;

		public bool ShouldSerializeChains()
		{
			return this.ShouldSerializeChainsValue;
		}

		public void AddChain(ApiChainResponseModel item)
		{
			if (!this.Chains.Any(x => x.Id == item.Id))
			{
				this.Chains.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeChainStatusesValue { get; private set; } = true;

		public bool ShouldSerializeChainStatuses()
		{
			return this.ShouldSerializeChainStatusesValue;
		}

		public void AddChainStatus(ApiChainStatusResponseModel item)
		{
			if (!this.ChainStatuses.Any(x => x.Id == item.Id))
			{
				this.ChainStatuses.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeLinksValue { get; private set; } = true;

		public bool ShouldSerializeLinks()
		{
			return this.ShouldSerializeLinksValue;
		}

		public void AddLink(ApiLinkResponseModel item)
		{
			if (!this.Links.Any(x => x.Id == item.Id))
			{
				this.Links.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeLinkLogsValue { get; private set; } = true;

		public bool ShouldSerializeLinkLogs()
		{
			return this.ShouldSerializeLinkLogsValue;
		}

		public void AddLinkLog(ApiLinkLogResponseModel item)
		{
			if (!this.LinkLogs.Any(x => x.Id == item.Id))
			{
				this.LinkLogs.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeLinkStatusesValue { get; private set; } = true;

		public bool ShouldSerializeLinkStatuses()
		{
			return this.ShouldSerializeLinkStatusesValue;
		}

		public void AddLinkStatus(ApiLinkStatusResponseModel item)
		{
			if (!this.LinkStatuses.Any(x => x.Id == item.Id))
			{
				this.LinkStatuses.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeMachinesValue { get; private set; } = true;

		public bool ShouldSerializeMachines()
		{
			return this.ShouldSerializeMachinesValue;
		}

		public void AddMachine(ApiMachineResponseModel item)
		{
			if (!this.Machines.Any(x => x.Id == item.Id))
			{
				this.Machines.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeOrganizationsValue { get; private set; } = true;

		public bool ShouldSerializeOrganizations()
		{
			return this.ShouldSerializeOrganizationsValue;
		}

		public void AddOrganization(ApiOrganizationResponseModel item)
		{
			if (!this.Organizations.Any(x => x.Id == item.Id))
			{
				this.Organizations.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTeamsValue { get; private set; } = true;

		public bool ShouldSerializeTeams()
		{
			return this.ShouldSerializeTeamsValue;
		}

		public void AddTeam(ApiTeamResponseModel item)
		{
			if (!this.Teams.Any(x => x.Id == item.Id))
			{
				this.Teams.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeVersionInfoesValue { get; private set; } = true;

		public bool ShouldSerializeVersionInfoes()
		{
			return this.ShouldSerializeVersionInfoesValue;
		}

		public void AddVersionInfo(ApiVersionInfoResponseModel item)
		{
			if (!this.VersionInfoes.Any(x => x.Version == item.Version))
			{
				this.VersionInfoes.Add(item);
			}
		}

		public void DisableSerializationOfEmptyFields()
		{
			if (this.Chains.Count == 0)
			{
				this.ShouldSerializeChainsValue = false;
			}

			if (this.ChainStatuses.Count == 0)
			{
				this.ShouldSerializeChainStatusesValue = false;
			}

			if (this.Links.Count == 0)
			{
				this.ShouldSerializeLinksValue = false;
			}

			if (this.LinkLogs.Count == 0)
			{
				this.ShouldSerializeLinkLogsValue = false;
			}

			if (this.LinkStatuses.Count == 0)
			{
				this.ShouldSerializeLinkStatusesValue = false;
			}

			if (this.Machines.Count == 0)
			{
				this.ShouldSerializeMachinesValue = false;
			}

			if (this.Organizations.Count == 0)
			{
				this.ShouldSerializeOrganizationsValue = false;
			}

			if (this.Teams.Count == 0)
			{
				this.ShouldSerializeTeamsValue = false;
			}

			if (this.VersionInfoes.Count == 0)
			{
				this.ShouldSerializeVersionInfoesValue = false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>463b71fbf9f8058af70180f1e018d807</Hash>
</Codenesium>*/