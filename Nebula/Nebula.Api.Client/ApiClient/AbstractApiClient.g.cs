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

                public virtual async Task<ApiChainResponseModel> ChainCreateAsync(ApiChainRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Chains", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiChainResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiChainResponseModel> ChainUpdateAsync(int id, ApiChainRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Chains/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiChainResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ChainDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Chains/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiChainResponseModel> ChainGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiChainResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiChainResponseModel>> ChainAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiChainResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiChainResponseModel>> ChainBulkInsertAsync(List<ApiChainRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Chains/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiChainResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiClaspResponseModel>> Clasps(int nextChainId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains/Clasps/{nextChainId}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiClaspResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLinkResponseModel>> Links(int chainId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Chains/Links/{chainId}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiChainStatusResponseModel> ChainStatusCreateAsync(ApiChainStatusRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ChainStatus", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiChainStatusResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiChainStatusResponseModel> ChainStatusUpdateAsync(int id, ApiChainStatusRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ChainStatus/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiChainStatusResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ChainStatusDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ChainStatus/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiChainStatusResponseModel> ChainStatusGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatus/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiChainStatusResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiChainStatusResponseModel>> ChainStatusAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatus?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiChainStatusResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiChainStatusResponseModel>> ChainStatusBulkInsertAsync(List<ApiChainStatusRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ChainStatus/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiChainStatusResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiChainResponseModel>> Chains(int chainStatusId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ChainStatus/Chains/{chainStatusId}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiChainResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiClaspResponseModel> ClaspCreateAsync(ApiClaspRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Clasps", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiClaspResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiClaspResponseModel> ClaspUpdateAsync(int id, ApiClaspRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Clasps/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiClaspResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ClaspDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Clasps/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiClaspResponseModel> ClaspGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clasps/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiClaspResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiClaspResponseModel>> ClaspAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Clasps?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiClaspResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiClaspResponseModel>> ClaspBulkInsertAsync(List<ApiClaspRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Clasps/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiClaspResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLinkResponseModel> LinkCreateAsync(ApiLinkRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Links", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLinkResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLinkResponseModel> LinkUpdateAsync(int id, ApiLinkRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Links/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLinkResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task LinkDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Links/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiLinkResponseModel> LinkGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLinkResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLinkResponseModel>> LinkAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLinkResponseModel>> LinkBulkInsertAsync(List<ApiLinkRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Links/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLinkResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLinkLogResponseModel>> LinkLogs(int linkId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Links/LinkLogs/{linkId}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLinkLogResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLinkLogResponseModel> LinkLogCreateAsync(ApiLinkLogRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkLogs", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLinkLogResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLinkLogResponseModel> LinkLogUpdateAsync(int id, ApiLinkLogRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LinkLogs/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLinkLogResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task LinkLogDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LinkLogs/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiLinkLogResponseModel> LinkLogGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkLogs/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLinkLogResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLinkLogResponseModel>> LinkLogAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkLogs?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLinkLogResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLinkLogResponseModel>> LinkLogBulkInsertAsync(List<ApiLinkLogRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkLogs/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLinkLogResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLinkStatusResponseModel> LinkStatusCreateAsync(ApiLinkStatusRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkStatus", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLinkStatusResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLinkStatusResponseModel> LinkStatusUpdateAsync(int id, ApiLinkStatusRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LinkStatus/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLinkStatusResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task LinkStatusDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LinkStatus/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiLinkStatusResponseModel> LinkStatusGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkStatus/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLinkStatusResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLinkStatusResponseModel>> LinkStatusAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkStatus?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLinkStatusResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLinkStatusResponseModel>> LinkStatusBulkInsertAsync(List<ApiLinkStatusRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkStatus/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLinkStatusResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiMachineResponseModel> MachineCreateAsync(ApiMachineRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Machines", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiMachineResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiMachineResponseModel> MachineUpdateAsync(int id, ApiMachineRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Machines/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiMachineResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task MachineDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Machines/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiMachineResponseModel> MachineGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiMachineResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiMachineResponseModel>> MachineAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiMachineResponseModel>> MachineBulkInsertAsync(List<ApiMachineRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Machines/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiMachineRefTeamResponseModel>> MachineRefTeams(int machineId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/MachineRefTeams/{machineId}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiMachineRefTeamResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiMachineRefTeamResponseModel> MachineRefTeamCreateAsync(ApiMachineRefTeamRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/MachineRefTeams", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiMachineRefTeamResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiMachineRefTeamResponseModel> MachineRefTeamUpdateAsync(int id, ApiMachineRefTeamRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/MachineRefTeams/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiMachineRefTeamResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task MachineRefTeamDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/MachineRefTeams/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiMachineRefTeamResponseModel> MachineRefTeamGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/MachineRefTeams/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiMachineRefTeamResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiMachineRefTeamResponseModel>> MachineRefTeamAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/MachineRefTeams?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiMachineRefTeamResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiMachineRefTeamResponseModel>> MachineRefTeamBulkInsertAsync(List<ApiMachineRefTeamRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/MachineRefTeams/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiMachineRefTeamResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiOrganizationResponseModel> OrganizationCreateAsync(ApiOrganizationRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Organizations", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiOrganizationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiOrganizationResponseModel> OrganizationUpdateAsync(int id, ApiOrganizationRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Organizations/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiOrganizationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task OrganizationDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Organizations/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiOrganizationResponseModel> OrganizationGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiOrganizationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiOrganizationResponseModel>> OrganizationAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiOrganizationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiOrganizationResponseModel>> OrganizationBulkInsertAsync(List<ApiOrganizationRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Organizations/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiOrganizationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTeamResponseModel>> Teams(int organizationId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Organizations/Teams/{organizationId}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTeamResponseModel> TeamCreateAsync(ApiTeamRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teams", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTeamResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTeamResponseModel> TeamUpdateAsync(int id, ApiTeamRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Teams/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTeamResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task TeamDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Teams/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiTeamResponseModel> TeamGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTeamResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTeamResponseModel>> TeamAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTeamResponseModel>> TeamBulkInsertAsync(List<ApiTeamRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teams/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiVersionInfoResponseModel> VersionInfoCreateAsync(ApiVersionInfoRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VersionInfoes", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiVersionInfoResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiVersionInfoResponseModel> VersionInfoUpdateAsync(long id, ApiVersionInfoRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/VersionInfoes/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiVersionInfoResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task VersionInfoDeleteAsync(long id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/VersionInfoes/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiVersionInfoResponseModel> VersionInfoGetAsync(long id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiVersionInfoResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiVersionInfoResponseModel>> VersionInfoAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiVersionInfoResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiVersionInfoResponseModel>> VersionInfoBulkInsertAsync(List<ApiVersionInfoRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VersionInfoes/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiVersionInfoResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiVersionInfoResponseModel> GetVersionInfoByVersion(long version)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes/byVersion/{version}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiVersionInfoResponseModel>(httpResponse.Content.ContentToString());
                }
        }
}

/*<Codenesium>
    <Hash>22b94747351d93f20443787873cf596e</Hash>
</Codenesium>*/