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
	public abstract class AbstractApiClient
	{
		private HttpClient client;

		protected string ApiUrl { get; set; }

		protected string ApiVersion { get; set; }

		public AbstractApiClient(HttpClient client)
		{
			this.client = client;
		}

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

		public virtual async Task<POCOChain> ChainCreateAsync(ApiChainModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Chains", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOChain>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOChain> ChainUpdateAsync(int id, ApiChainModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Chains/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOChain>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ChainDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Chains/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOChain> ChainGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOChain>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOChain>> ChainAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOChain>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOChain>> ChainBulkInsertAsync(List<ApiChainModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Chains/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOChain>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOChain> GetChainGetExternalId(Guid externalId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains/getExternalId/{externalId}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOChain>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOChainStatus> ChainStatusCreateAsync(ApiChainStatusModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ChainStatus", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOChainStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOChainStatus> ChainStatusUpdateAsync(int id, ApiChainStatusModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ChainStatus/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOChainStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ChainStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ChainStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOChainStatus> ChainStatusGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOChainStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOChainStatus>> ChainStatusAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatus?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOChainStatus>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOChainStatus>> ChainStatusBulkInsertAsync(List<ApiChainStatusModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ChainStatus/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOChainStatus>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOChainStatus> GetChainStatusGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatus/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOChainStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOClasp> ClaspCreateAsync(ApiClaspModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Clasps", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOClasp>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOClasp> ClaspUpdateAsync(int id, ApiClaspModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Clasps/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOClasp>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ClaspDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Clasps/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOClasp> ClaspGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clasps/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOClasp>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOClasp>> ClaspAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clasps?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOClasp>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOClasp>> ClaspBulkInsertAsync(List<ApiClaspModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Clasps/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOClasp>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLink> LinkCreateAsync(ApiLinkModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Links", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLink>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLink> LinkUpdateAsync(int id, ApiLinkModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Links/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLink>(httpResponse.Content.ContentToString());
		}

		public virtual async Task LinkDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Links/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOLink> LinkGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLink>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLink>> LinkAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLink>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLink>> LinkBulkInsertAsync(List<ApiLinkModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Links/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLink>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLink> GetLinkGetExternalId(Guid externalId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links/getExternalId/{externalId}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLink>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLink>> GetLinkGetChainId(int chainId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links/getChainId/{chainId}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLink>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLinkLog> LinkLogCreateAsync(ApiLinkLogModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkLogs", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLinkLog>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLinkLog> LinkLogUpdateAsync(int id, ApiLinkLogModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LinkLogs/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLinkLog>(httpResponse.Content.ContentToString());
		}

		public virtual async Task LinkLogDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LinkLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOLinkLog> LinkLogGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLinkLog>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLinkLog>> LinkLogAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkLogs?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLinkLog>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLinkLog>> LinkLogBulkInsertAsync(List<ApiLinkLogModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkLogs/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLinkLog>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLinkStatus> LinkStatusCreateAsync(ApiLinkStatusModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkStatus", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLinkStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLinkStatus> LinkStatusUpdateAsync(int id, ApiLinkStatusModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LinkStatus/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLinkStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task LinkStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LinkStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOLinkStatus> LinkStatusGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLinkStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLinkStatus>> LinkStatusAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkStatus?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLinkStatus>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLinkStatus>> LinkStatusBulkInsertAsync(List<ApiLinkStatusModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkStatus/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLinkStatus>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLinkStatus> GetLinkStatusGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkStatus/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLinkStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOMachine> MachineCreateAsync(ApiMachineModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Machines", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOMachine>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOMachine> MachineUpdateAsync(int id, ApiMachineModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Machines/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOMachine>(httpResponse.Content.ContentToString());
		}

		public virtual async Task MachineDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Machines/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOMachine> MachineGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOMachine>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOMachine>> MachineAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOMachine>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOMachine>> MachineBulkInsertAsync(List<ApiMachineModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Machines/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOMachine>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOMachine> GetMachineGetMachineGuid(Guid machineGuid)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/getMachineGuid/{machineGuid}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOMachine>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOMachineRefTeam> MachineRefTeamCreateAsync(ApiMachineRefTeamModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/MachineRefTeams", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOMachineRefTeam>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOMachineRefTeam> MachineRefTeamUpdateAsync(int id, ApiMachineRefTeamModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/MachineRefTeams/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOMachineRefTeam>(httpResponse.Content.ContentToString());
		}

		public virtual async Task MachineRefTeamDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/MachineRefTeams/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOMachineRefTeam> MachineRefTeamGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/MachineRefTeams/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOMachineRefTeam>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOMachineRefTeam>> MachineRefTeamAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/MachineRefTeams?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOMachineRefTeam>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOMachineRefTeam>> MachineRefTeamBulkInsertAsync(List<ApiMachineRefTeamModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/MachineRefTeams/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOMachineRefTeam>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOOrganization> OrganizationCreateAsync(ApiOrganizationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Organizations", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOOrganization>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOOrganization> OrganizationUpdateAsync(int id, ApiOrganizationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Organizations/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOOrganization>(httpResponse.Content.ContentToString());
		}

		public virtual async Task OrganizationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Organizations/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOOrganization> OrganizationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOOrganization>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOOrganization>> OrganizationAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOOrganization>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOOrganization>> OrganizationBulkInsertAsync(List<ApiOrganizationModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Organizations/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOOrganization>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOOrganization> GetOrganizationGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOOrganization>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTeam> TeamCreateAsync(ApiTeamModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teams", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeam>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTeam> TeamUpdateAsync(int id, ApiTeamModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Teams/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeam>(httpResponse.Content.ContentToString());
		}

		public virtual async Task TeamDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Teams/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOTeam> TeamGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeam>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTeam>> TeamAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTeam>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTeam>> TeamBulkInsertAsync(List<ApiTeamModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teams/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTeam>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTeam> GetTeamGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeam>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOVersionInfo> VersionInfoCreateAsync(ApiVersionInfoModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VersionInfoes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOVersionInfo>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOVersionInfo> VersionInfoUpdateAsync(long id, ApiVersionInfoModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/VersionInfoes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOVersionInfo>(httpResponse.Content.ContentToString());
		}

		public virtual async Task VersionInfoDeleteAsync(long id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/VersionInfoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOVersionInfo> VersionInfoGetAsync(long id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOVersionInfo>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOVersionInfo>> VersionInfoAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOVersionInfo>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOVersionInfo>> VersionInfoBulkInsertAsync(List<ApiVersionInfoModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VersionInfoes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOVersionInfo>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOVersionInfo> GetVersionInfoGetVersion(long version)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes/getVersion/{version}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOVersionInfo>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>0631648fb88eab0d187d6cefa094bf85</Hash>
</Codenesium>*/