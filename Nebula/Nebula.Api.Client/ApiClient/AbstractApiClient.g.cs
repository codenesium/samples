using Codenesium.DataConversionExtensions;
using NebulaNS.Api.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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

		public AbstractApiClient(string apiUrl, string apiVersion)
		{
			if (string.IsNullOrWhiteSpace(apiUrl))
			{
				throw new ArgumentException("apiUrl is not set");
			}

			if (string.IsNullOrWhiteSpace(apiVersion))
			{
				throw new ArgumentException("apiVersion is not set");
			}

			if (!apiUrl.EndsWith("/"))
			{
				apiUrl += "/";
			}

			this.ApiUrl = apiUrl;
			this.ApiVersion = apiVersion;
			this.client = new HttpClient();
			this.client.BaseAddress = new Uri(apiUrl);
			this.client.DefaultRequestHeaders.Accept.Clear();
			this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			this.client.DefaultRequestHeaders.Add("api-version", this.ApiVersion);
		}

		public void SetBearerToken(string token)
		{
			this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		}

		public virtual async Task<CreateResponse<ApiChainResponseModel>> ChainCreateAsync(ApiChainRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Chains", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiChainResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiChainResponseModel>> ChainUpdateAsync(int id, ApiChainRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Chains/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiChainResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ChainDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Chains/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiChainResponseModel> ChainGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiChainResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiChainResponseModel>> ChainAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiChainResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiChainResponseModel>> ChainBulkInsertAsync(List<ApiChainRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Chains/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiChainResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiChainResponseModel> GetChainByExternalId(Guid externalId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains/byExternalId/{externalId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiChainResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiClaspResponseModel>> Clasps(int nextChainId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains/Clasps/{nextChainId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiClaspResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkResponseModel>> Links(int chainId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains/Links/{chainId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiChainStatuResponseModel>> ChainStatuCreateAsync(ApiChainStatuRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ChainStatus", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiChainStatuResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiChainStatuResponseModel>> ChainStatuUpdateAsync(int id, ApiChainStatuRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ChainStatus/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiChainStatuResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ChainStatuDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ChainStatus/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiChainStatuResponseModel> ChainStatuGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatus/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiChainStatuResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiChainStatuResponseModel>> ChainStatuAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatus?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiChainStatuResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiChainStatuResponseModel>> ChainStatuBulkInsertAsync(List<ApiChainStatuRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ChainStatus/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiChainStatuResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiChainStatuResponseModel> GetChainStatuByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatus/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiChainStatuResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiChainResponseModel>> Chains(int chainStatusId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatus/Chains/{chainStatusId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiChainResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiClaspResponseModel>> ClaspCreateAsync(ApiClaspRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Clasps", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiClaspResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiClaspResponseModel>> ClaspUpdateAsync(int id, ApiClaspRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Clasps/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiClaspResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ClaspDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Clasps/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiClaspResponseModel> ClaspGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clasps/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiClaspResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiClaspResponseModel>> ClaspAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clasps?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiClaspResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiClaspResponseModel>> ClaspBulkInsertAsync(List<ApiClaspRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Clasps/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiClaspResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiLinkResponseModel>> LinkCreateAsync(ApiLinkRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Links", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiLinkResponseModel>> LinkUpdateAsync(int id, ApiLinkRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Links/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> LinkDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Links/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkResponseModel> LinkGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLinkResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkResponseModel>> LinkAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkResponseModel>> LinkBulkInsertAsync(List<ApiLinkRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Links/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkResponseModel> GetLinkByExternalId(Guid externalId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links/byExternalId/{externalId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLinkResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkResponseModel>> GetLinkByChainId(int chainId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links/byChainId/{chainId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkLogResponseModel>> LinkLogs(int linkId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links/LinkLogs/{linkId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiLinkLogResponseModel>> LinkLogCreateAsync(ApiLinkLogRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkLogs", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiLinkLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiLinkLogResponseModel>> LinkLogUpdateAsync(int id, ApiLinkLogRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LinkLogs/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiLinkLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> LinkLogDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LinkLogs/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkLogResponseModel> LinkLogGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkLogs/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLinkLogResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkLogResponseModel>> LinkLogAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkLogs?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkLogResponseModel>> LinkLogBulkInsertAsync(List<ApiLinkLogRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkLogs/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiLinkStatuResponseModel>> LinkStatuCreateAsync(ApiLinkStatuRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkStatus", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiLinkStatuResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiLinkStatuResponseModel>> LinkStatuUpdateAsync(int id, ApiLinkStatuRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LinkStatus/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiLinkStatuResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> LinkStatuDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LinkStatus/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkStatuResponseModel> LinkStatuGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkStatus/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLinkStatuResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkStatuResponseModel>> LinkStatuAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkStatus?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkStatuResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkStatuResponseModel>> LinkStatuBulkInsertAsync(List<ApiLinkStatuRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkStatus/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkStatuResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkStatuResponseModel> GetLinkStatuByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkStatus/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLinkStatuResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiMachineResponseModel>> MachineCreateAsync(ApiMachineRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Machines", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiMachineResponseModel>> MachineUpdateAsync(int id, ApiMachineRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Machines/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> MachineDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Machines/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiMachineResponseModel> MachineGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiMachineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMachineResponseModel>> MachineAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMachineResponseModel>> MachineBulkInsertAsync(List<ApiMachineRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Machines/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiMachineResponseModel> GetMachineByMachineGuid(Guid machineGuid)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/byMachineGuid/{machineGuid}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiMachineResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMachineRefTeamResponseModel>> MachineRefTeams(int machineId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/MachineRefTeams/{machineId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMachineRefTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiMachineRefTeamResponseModel>> MachineRefTeamCreateAsync(ApiMachineRefTeamRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/MachineRefTeams", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiMachineRefTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiMachineRefTeamResponseModel>> MachineRefTeamUpdateAsync(int id, ApiMachineRefTeamRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/MachineRefTeams/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiMachineRefTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> MachineRefTeamDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/MachineRefTeams/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiMachineRefTeamResponseModel> MachineRefTeamGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/MachineRefTeams/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiMachineRefTeamResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMachineRefTeamResponseModel>> MachineRefTeamAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/MachineRefTeams?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMachineRefTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMachineRefTeamResponseModel>> MachineRefTeamBulkInsertAsync(List<ApiMachineRefTeamRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/MachineRefTeams/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMachineRefTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiOrganizationResponseModel>> OrganizationCreateAsync(ApiOrganizationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Organizations", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiOrganizationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiOrganizationResponseModel>> OrganizationUpdateAsync(int id, ApiOrganizationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Organizations/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiOrganizationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> OrganizationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Organizations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiOrganizationResponseModel> OrganizationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiOrganizationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiOrganizationResponseModel>> OrganizationAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiOrganizationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiOrganizationResponseModel>> OrganizationBulkInsertAsync(List<ApiOrganizationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Organizations/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiOrganizationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiOrganizationResponseModel> GetOrganizationByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiOrganizationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeamResponseModel>> Teams(int organizationId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations/Teams/{organizationId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSysdiagramResponseModel>> SysdiagramCreateAsync(ApiSysdiagramRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Sysdiagrams", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSysdiagramResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSysdiagramResponseModel>> SysdiagramUpdateAsync(int id, ApiSysdiagramRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Sysdiagrams/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSysdiagramResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SysdiagramDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Sysdiagrams/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSysdiagramResponseModel> SysdiagramGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Sysdiagrams/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSysdiagramResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSysdiagramResponseModel>> SysdiagramAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Sysdiagrams?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSysdiagramResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSysdiagramResponseModel>> SysdiagramBulkInsertAsync(List<ApiSysdiagramRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Sysdiagrams/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSysdiagramResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSysdiagramResponseModel> GetSysdiagramByPrincipalIdName(int principalId, string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Sysdiagrams/byPrincipalIdName/{principalId}/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSysdiagramResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTeamResponseModel>> TeamCreateAsync(ApiTeamRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teams", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTeamResponseModel>> TeamUpdateAsync(int id, ApiTeamRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Teams/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TeamDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Teams/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTeamResponseModel> TeamGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTeamResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeamResponseModel>> TeamAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeamResponseModel>> TeamBulkInsertAsync(List<ApiTeamRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teams/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTeamResponseModel> GetTeamByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTeamResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiVersionInfoResponseModel>> VersionInfoCreateAsync(ApiVersionInfoRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VersionInfoes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiVersionInfoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiVersionInfoResponseModel>> VersionInfoUpdateAsync(long id, ApiVersionInfoRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/VersionInfoes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiVersionInfoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> VersionInfoDeleteAsync(long id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/VersionInfoes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVersionInfoResponseModel> VersionInfoGetAsync(long id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiVersionInfoResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVersionInfoResponseModel>> VersionInfoAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVersionInfoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVersionInfoResponseModel>> VersionInfoBulkInsertAsync(List<ApiVersionInfoRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VersionInfoes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVersionInfoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVersionInfoResponseModel> GetVersionInfoByVersion(long version)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes/byVersion/{version}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiVersionInfoResponseModel>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>b66135181228d6336da6b1f869fb087b</Hash>
</Codenesium>*/