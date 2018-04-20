using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Client
{
	public abstract partial class AbstractApiClient
	{
		private HttpClient client;

		protected string ApiUrl { get; set; }

		protected string ApiVersion { get; set; }

		public AbstractApiClient(string apiUri, string apiVersion)
		{
			if (string.IsNullOrWhiteSpace(apiUri))
			{
				throw new ArgumentException("apiUrl is not set");
			}
			if (apiUri[apiUri.Length - 1] != '/')
			{
				throw new ArgumentException("The apiUrl must end in a / for httpClient to work correctly");
			}
			if (string.IsNullOrWhiteSpace(apiVersion))
			{
				throw new ArgumentException("apiVersion is not set");
			}

			this.ApiUrl = apiUri;
			this.ApiVersion = apiVersion;
			this.client = new HttpClient();

			this.client.BaseAddress = new Uri(apiUri);

			this.client.DefaultRequestHeaders.Accept.Clear();
			this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			this.client.DefaultRequestHeaders.Add("api-version", this.ApiVersion);
		}

		public virtual async Task<int> ChainCreateAsync(ChainModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Chains", item);

			httpResponse.EnsureSuccessStatusCode();
			return httpResponse.GetHeaderValue("x-record-id").ToInt();
		}

		public virtual async Task ChainUpdateAsync(int id, ChainModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Chains/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ChainDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Chains/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOChain>> ChainSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).Chains;
		}

		public virtual async Task<POCOChain> ChainGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).Chains.FirstOrDefault();
		}

		public virtual async Task<List<POCOChain>> ChainGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).Chains;
		}

		public virtual async Task ChainBulkInsertAsync(List<ChainModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Chains/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ChainStatusCreateAsync(ChainStatusModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ChainStatus", item);

			httpResponse.EnsureSuccessStatusCode();
			return httpResponse.GetHeaderValue("x-record-id").ToInt();
		}

		public virtual async Task ChainStatusUpdateAsync(int id, ChainStatusModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ChainStatus/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ChainStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ChainStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOChainStatus>> ChainStatusSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatus?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).ChainStatus;
		}

		public virtual async Task<POCOChainStatus> ChainStatusGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).ChainStatus.FirstOrDefault();
		}

		public virtual async Task<List<POCOChainStatus>> ChainStatusGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatus?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).ChainStatus;
		}

		public virtual async Task ChainStatusBulkInsertAsync(List<ChainStatusModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ChainStatus/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ClaspCreateAsync(ClaspModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Clasps", item);

			httpResponse.EnsureSuccessStatusCode();
			return httpResponse.GetHeaderValue("x-record-id").ToInt();
		}

		public virtual async Task ClaspUpdateAsync(int id, ClaspModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Clasps/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ClaspDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Clasps/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOClasp>> ClaspSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clasps?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).Clasps;
		}

		public virtual async Task<POCOClasp> ClaspGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clasps/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).Clasps.FirstOrDefault();
		}

		public virtual async Task<List<POCOClasp>> ClaspGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clasps?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).Clasps;
		}

		public virtual async Task ClaspBulkInsertAsync(List<ClaspModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Clasps/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> LinkCreateAsync(LinkModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Links", item);

			httpResponse.EnsureSuccessStatusCode();
			return httpResponse.GetHeaderValue("x-record-id").ToInt();
		}

		public virtual async Task LinkUpdateAsync(int id, LinkModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Links/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task LinkDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Links/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOLink>> LinkSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).Links;
		}

		public virtual async Task<POCOLink> LinkGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).Links.FirstOrDefault();
		}

		public virtual async Task<List<POCOLink>> LinkGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).Links;
		}

		public virtual async Task LinkBulkInsertAsync(List<LinkModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Links/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> LinkLogCreateAsync(LinkLogModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkLogs", item);

			httpResponse.EnsureSuccessStatusCode();
			return httpResponse.GetHeaderValue("x-record-id").ToInt();
		}

		public virtual async Task LinkLogUpdateAsync(int id, LinkLogModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LinkLogs/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task LinkLogDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LinkLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOLinkLog>> LinkLogSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkLogs?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).LinkLogs;
		}

		public virtual async Task<POCOLinkLog> LinkLogGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).LinkLogs.FirstOrDefault();
		}

		public virtual async Task<List<POCOLinkLog>> LinkLogGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkLogs?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).LinkLogs;
		}

		public virtual async Task LinkLogBulkInsertAsync(List<LinkLogModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkLogs/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> LinkStatusCreateAsync(LinkStatusModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkStatus", item);

			httpResponse.EnsureSuccessStatusCode();
			return httpResponse.GetHeaderValue("x-record-id").ToInt();
		}

		public virtual async Task LinkStatusUpdateAsync(int id, LinkStatusModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LinkStatus/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task LinkStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LinkStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOLinkStatus>> LinkStatusSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkStatus?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).LinkStatus;
		}

		public virtual async Task<POCOLinkStatus> LinkStatusGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).LinkStatus.FirstOrDefault();
		}

		public virtual async Task<List<POCOLinkStatus>> LinkStatusGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkStatus?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).LinkStatus;
		}

		public virtual async Task LinkStatusBulkInsertAsync(List<LinkStatusModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkStatus/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> MachineCreateAsync(MachineModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Machines", item);

			httpResponse.EnsureSuccessStatusCode();
			return httpResponse.GetHeaderValue("x-record-id").ToInt();
		}

		public virtual async Task MachineUpdateAsync(int id, MachineModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Machines/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task MachineDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Machines/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOMachine>> MachineSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).Machines;
		}

		public virtual async Task<POCOMachine> MachineGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).Machines.FirstOrDefault();
		}

		public virtual async Task<List<POCOMachine>> MachineGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).Machines;
		}

		public virtual async Task MachineBulkInsertAsync(List<MachineModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Machines/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> MachineRefTeamCreateAsync(MachineRefTeamModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/MachineRefTeams", item);

			httpResponse.EnsureSuccessStatusCode();
			return httpResponse.GetHeaderValue("x-record-id").ToInt();
		}

		public virtual async Task MachineRefTeamUpdateAsync(int id, MachineRefTeamModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/MachineRefTeams/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task MachineRefTeamDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/MachineRefTeams/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOMachineRefTeam>> MachineRefTeamSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/MachineRefTeams?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).MachineRefTeams;
		}

		public virtual async Task<POCOMachineRefTeam> MachineRefTeamGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/MachineRefTeams/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).MachineRefTeams.FirstOrDefault();
		}

		public virtual async Task<List<POCOMachineRefTeam>> MachineRefTeamGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/MachineRefTeams?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).MachineRefTeams;
		}

		public virtual async Task MachineRefTeamBulkInsertAsync(List<MachineRefTeamModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/MachineRefTeams/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> OrganizationCreateAsync(OrganizationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Organizations", item);

			httpResponse.EnsureSuccessStatusCode();
			return httpResponse.GetHeaderValue("x-record-id").ToInt();
		}

		public virtual async Task OrganizationUpdateAsync(int id, OrganizationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Organizations/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task OrganizationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Organizations/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOOrganization>> OrganizationSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).Organizations;
		}

		public virtual async Task<POCOOrganization> OrganizationGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).Organizations.FirstOrDefault();
		}

		public virtual async Task<List<POCOOrganization>> OrganizationGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).Organizations;
		}

		public virtual async Task OrganizationBulkInsertAsync(List<OrganizationModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Organizations/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> TeamCreateAsync(TeamModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teams", item);

			httpResponse.EnsureSuccessStatusCode();
			return httpResponse.GetHeaderValue("x-record-id").ToInt();
		}

		public virtual async Task TeamUpdateAsync(int id, TeamModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Teams/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task TeamDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Teams/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOTeam>> TeamSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).Teams;
		}

		public virtual async Task<POCOTeam> TeamGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).Teams.FirstOrDefault();
		}

		public virtual async Task<List<POCOTeam>> TeamGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiResponse>(httpResponse.Content.ContentToString()).Teams;
		}

		public virtual async Task TeamBulkInsertAsync(List<TeamModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teams/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
		}
	}
}

/*<Codenesium>
    <Hash>cd4d5ab1e57f5f8313d66977b5951c90</Hash>
</Codenesium>*/