using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NebulaNS.Api.Client
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
			from.Clasps.ForEach(x => this.AddClasp(x));
			from.Links.ForEach(x => this.AddLink(x));
			from.LinkLogs.ForEach(x => this.AddLinkLog(x));
			from.LinkStatuses.ForEach(x => this.AddLinkStatus(x));
			from.Machines.ForEach(x => this.AddMachine(x));
			from.Organizations.ForEach(x => this.AddOrganization(x));
			from.Teams.ForEach(x => this.AddTeam(x));
		}

		public List<ApiChainClientResponseModel> Chains { get; private set; } = new List<ApiChainClientResponseModel>();

		public List<ApiChainStatusClientResponseModel> ChainStatuses { get; private set; } = new List<ApiChainStatusClientResponseModel>();

		public List<ApiClaspClientResponseModel> Clasps { get; private set; } = new List<ApiClaspClientResponseModel>();

		public List<ApiLinkClientResponseModel> Links { get; private set; } = new List<ApiLinkClientResponseModel>();

		public List<ApiLinkLogClientResponseModel> LinkLogs { get; private set; } = new List<ApiLinkLogClientResponseModel>();

		public List<ApiLinkStatusClientResponseModel> LinkStatuses { get; private set; } = new List<ApiLinkStatusClientResponseModel>();

		public List<ApiMachineClientResponseModel> Machines { get; private set; } = new List<ApiMachineClientResponseModel>();

		public List<ApiOrganizationClientResponseModel> Organizations { get; private set; } = new List<ApiOrganizationClientResponseModel>();

		public List<ApiTeamClientResponseModel> Teams { get; private set; } = new List<ApiTeamClientResponseModel>();

		public void AddChain(ApiChainClientResponseModel item)
		{
			if (!this.Chains.Any(x => x.Id == item.Id))
			{
				this.Chains.Add(item);
			}
		}

		public void AddChainStatus(ApiChainStatusClientResponseModel item)
		{
			if (!this.ChainStatuses.Any(x => x.Id == item.Id))
			{
				this.ChainStatuses.Add(item);
			}
		}

		public void AddClasp(ApiClaspClientResponseModel item)
		{
			if (!this.Clasps.Any(x => x.Id == item.Id))
			{
				this.Clasps.Add(item);
			}
		}

		public void AddLink(ApiLinkClientResponseModel item)
		{
			if (!this.Links.Any(x => x.Id == item.Id))
			{
				this.Links.Add(item);
			}
		}

		public void AddLinkLog(ApiLinkLogClientResponseModel item)
		{
			if (!this.LinkLogs.Any(x => x.Id == item.Id))
			{
				this.LinkLogs.Add(item);
			}
		}

		public void AddLinkStatus(ApiLinkStatusClientResponseModel item)
		{
			if (!this.LinkStatuses.Any(x => x.Id == item.Id))
			{
				this.LinkStatuses.Add(item);
			}
		}

		public void AddMachine(ApiMachineClientResponseModel item)
		{
			if (!this.Machines.Any(x => x.Id == item.Id))
			{
				this.Machines.Add(item);
			}
		}

		public void AddOrganization(ApiOrganizationClientResponseModel item)
		{
			if (!this.Organizations.Any(x => x.Id == item.Id))
			{
				this.Organizations.Add(item);
			}
		}

		public void AddTeam(ApiTeamClientResponseModel item)
		{
			if (!this.Teams.Any(x => x.Id == item.Id))
			{
				this.Teams.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>8697a780f20c85b94114e7777957f88e</Hash>
</Codenesium>*/