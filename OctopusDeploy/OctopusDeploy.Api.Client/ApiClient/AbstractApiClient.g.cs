using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Client
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

                public virtual async Task<ApiAccountResponseModel> AccountCreateAsync(ApiAccountRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Accounts", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAccountResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiAccountResponseModel> AccountUpdateAsync(string id, ApiAccountRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Accounts/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAccountResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task AccountDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Accounts/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiAccountResponseModel> AccountGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Accounts/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAccountResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiAccountResponseModel>> AccountAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Accounts?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiAccountResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiAccountResponseModel>> AccountBulkInsertAsync(List<ApiAccountRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Accounts/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiAccountResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiAccountResponseModel> GetAccountGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Accounts/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAccountResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiActionTemplateResponseModel> ActionTemplateCreateAsync(ApiActionTemplateRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ActionTemplates", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiActionTemplateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiActionTemplateResponseModel> ActionTemplateUpdateAsync(string id, ApiActionTemplateRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ActionTemplates/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiActionTemplateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ActionTemplateDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ActionTemplates/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiActionTemplateResponseModel> ActionTemplateGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ActionTemplates/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiActionTemplateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiActionTemplateResponseModel>> ActionTemplateAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ActionTemplates?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiActionTemplateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiActionTemplateResponseModel>> ActionTemplateBulkInsertAsync(List<ApiActionTemplateRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ActionTemplates/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiActionTemplateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiActionTemplateResponseModel> GetActionTemplateGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ActionTemplates/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiActionTemplateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiActionTemplateVersionResponseModel> ActionTemplateVersionCreateAsync(ApiActionTemplateVersionRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ActionTemplateVersions", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiActionTemplateVersionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiActionTemplateVersionResponseModel> ActionTemplateVersionUpdateAsync(string id, ApiActionTemplateVersionRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ActionTemplateVersions/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiActionTemplateVersionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ActionTemplateVersionDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ActionTemplateVersions/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiActionTemplateVersionResponseModel> ActionTemplateVersionGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ActionTemplateVersions/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiActionTemplateVersionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiActionTemplateVersionResponseModel>> ActionTemplateVersionAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ActionTemplateVersions?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiActionTemplateVersionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiActionTemplateVersionResponseModel>> ActionTemplateVersionBulkInsertAsync(List<ApiActionTemplateVersionRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ActionTemplateVersions/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiActionTemplateVersionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiActionTemplateVersionResponseModel> GetActionTemplateVersionGetNameVersion(string name, int version)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ActionTemplateVersions/getNameVersion/{name}/{version}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiActionTemplateVersionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiActionTemplateVersionResponseModel>> GetActionTemplateVersionGetLatestActionTemplateId(string latestActionTemplateId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ActionTemplateVersions/getLatestActionTemplateId/{latestActionTemplateId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiActionTemplateVersionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiApiKeyResponseModel> ApiKeyCreateAsync(ApiApiKeyRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ApiKeys", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiApiKeyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiApiKeyResponseModel> ApiKeyUpdateAsync(string id, ApiApiKeyRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ApiKeys/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiApiKeyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ApiKeyDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ApiKeys/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiApiKeyResponseModel> ApiKeyGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ApiKeys/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiApiKeyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiApiKeyResponseModel>> ApiKeyAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ApiKeys?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiApiKeyResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiApiKeyResponseModel>> ApiKeyBulkInsertAsync(List<ApiApiKeyRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ApiKeys/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiApiKeyResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiApiKeyResponseModel> GetApiKeyGetApiKeyHashed(string apiKeyHashed)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ApiKeys/getApiKeyHashed/{apiKeyHashed}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiApiKeyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiArtifactResponseModel> ArtifactCreateAsync(ApiArtifactRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Artifacts", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiArtifactResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiArtifactResponseModel> ArtifactUpdateAsync(string id, ApiArtifactRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Artifacts/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiArtifactResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ArtifactDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Artifacts/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiArtifactResponseModel> ArtifactGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Artifacts/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiArtifactResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiArtifactResponseModel>> ArtifactAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Artifacts?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiArtifactResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiArtifactResponseModel>> ArtifactBulkInsertAsync(List<ApiArtifactRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Artifacts/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiArtifactResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiArtifactResponseModel>> GetArtifactGetTenantId(string tenantId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Artifacts/getTenantId/{tenantId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiArtifactResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCertificateResponseModel> CertificateCreateAsync(ApiCertificateRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Certificates", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCertificateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCertificateResponseModel> CertificateUpdateAsync(string id, ApiCertificateRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Certificates/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCertificateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task CertificateDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Certificates/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiCertificateResponseModel> CertificateGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Certificates/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCertificateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCertificateResponseModel>> CertificateAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Certificates?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCertificateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCertificateResponseModel>> CertificateBulkInsertAsync(List<ApiCertificateRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Certificates/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCertificateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCertificateResponseModel>> GetCertificateGetCreated(DateTimeOffset created)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Certificates/getCreated/{created}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCertificateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCertificateResponseModel>> GetCertificateGetDataVersion(byte[] dataVersion)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Certificates/getDataVersion/{dataVersion}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCertificateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCertificateResponseModel>> GetCertificateGetNotAfter(DateTimeOffset notAfter)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Certificates/getNotAfter/{notAfter}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCertificateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCertificateResponseModel>> GetCertificateGetThumbprint(string thumbprint)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Certificates/getThumbprint/{thumbprint}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCertificateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiChannelResponseModel> ChannelCreateAsync(ApiChannelRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Channels", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiChannelResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiChannelResponseModel> ChannelUpdateAsync(string id, ApiChannelRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Channels/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiChannelResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ChannelDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Channels/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiChannelResponseModel> ChannelGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Channels/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiChannelResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiChannelResponseModel>> ChannelAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Channels?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiChannelResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiChannelResponseModel>> ChannelBulkInsertAsync(List<ApiChannelRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Channels/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiChannelResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiChannelResponseModel> GetChannelGetNameProjectId(string name, string projectId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Channels/getNameProjectId/{name}/{projectId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiChannelResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiChannelResponseModel>> GetChannelGetDataVersion(byte[] dataVersion)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Channels/getDataVersion/{dataVersion}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiChannelResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiChannelResponseModel>> GetChannelGetProjectId(string projectId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Channels/getProjectId/{projectId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiChannelResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCommunityActionTemplateResponseModel> CommunityActionTemplateCreateAsync(ApiCommunityActionTemplateRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CommunityActionTemplates", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCommunityActionTemplateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCommunityActionTemplateResponseModel> CommunityActionTemplateUpdateAsync(string id, ApiCommunityActionTemplateRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CommunityActionTemplates/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCommunityActionTemplateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task CommunityActionTemplateDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CommunityActionTemplates/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiCommunityActionTemplateResponseModel> CommunityActionTemplateGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CommunityActionTemplates/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCommunityActionTemplateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCommunityActionTemplateResponseModel>> CommunityActionTemplateAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CommunityActionTemplates?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCommunityActionTemplateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCommunityActionTemplateResponseModel>> CommunityActionTemplateBulkInsertAsync(List<ApiCommunityActionTemplateRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CommunityActionTemplates/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCommunityActionTemplateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCommunityActionTemplateResponseModel> GetCommunityActionTemplateGetExternalId(Guid externalId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CommunityActionTemplates/getExternalId/{externalId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCommunityActionTemplateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCommunityActionTemplateResponseModel> GetCommunityActionTemplateGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CommunityActionTemplates/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCommunityActionTemplateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiConfigurationResponseModel> ConfigurationCreateAsync(ApiConfigurationRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Configurations", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiConfigurationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiConfigurationResponseModel> ConfigurationUpdateAsync(string id, ApiConfigurationRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Configurations/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiConfigurationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ConfigurationDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Configurations/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiConfigurationResponseModel> ConfigurationGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Configurations/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiConfigurationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiConfigurationResponseModel>> ConfigurationAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Configurations?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiConfigurationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiConfigurationResponseModel>> ConfigurationBulkInsertAsync(List<ApiConfigurationRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Configurations/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiConfigurationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDashboardConfigurationResponseModel> DashboardConfigurationCreateAsync(ApiDashboardConfigurationRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DashboardConfigurations", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDashboardConfigurationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDashboardConfigurationResponseModel> DashboardConfigurationUpdateAsync(string id, ApiDashboardConfigurationRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/DashboardConfigurations/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDashboardConfigurationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task DashboardConfigurationDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/DashboardConfigurations/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiDashboardConfigurationResponseModel> DashboardConfigurationGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DashboardConfigurations/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDashboardConfigurationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDashboardConfigurationResponseModel>> DashboardConfigurationAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DashboardConfigurations?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDashboardConfigurationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDashboardConfigurationResponseModel>> DashboardConfigurationBulkInsertAsync(List<ApiDashboardConfigurationRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DashboardConfigurations/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDashboardConfigurationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDeploymentResponseModel> DeploymentCreateAsync(ApiDeploymentRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Deployments", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeploymentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDeploymentResponseModel> DeploymentUpdateAsync(string id, ApiDeploymentRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Deployments/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeploymentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task DeploymentDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Deployments/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiDeploymentResponseModel> DeploymentGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Deployments/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeploymentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeploymentResponseModel>> DeploymentAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Deployments?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeploymentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeploymentResponseModel>> DeploymentBulkInsertAsync(List<ApiDeploymentRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Deployments/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeploymentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeploymentResponseModel>> GetDeploymentGetChannelId(string channelId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Deployments/getChannelId/{channelId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeploymentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeploymentResponseModel>> GetDeploymentGetIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(string id, string projectId, string projectGroupId, string name, DateTimeOffset created, string releaseId, string taskId, string environmentId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Deployments/getIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId/{id}/{projectId}/{projectGroupId}/{name}/{created}/{releaseId}/{taskId}/{environmentId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeploymentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeploymentResponseModel>> GetDeploymentGetTenantId(string tenantId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Deployments/getTenantId/{tenantId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeploymentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeploymentRelatedMachineResponseModel>> DeploymentRelatedMachines(string deploymentId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Deployments/DeploymentRelatedMachines/{deploymentId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeploymentRelatedMachineResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDeploymentEnvironmentResponseModel> DeploymentEnvironmentCreateAsync(ApiDeploymentEnvironmentRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeploymentEnvironments", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeploymentEnvironmentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDeploymentEnvironmentResponseModel> DeploymentEnvironmentUpdateAsync(string id, ApiDeploymentEnvironmentRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/DeploymentEnvironments/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeploymentEnvironmentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task DeploymentEnvironmentDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/DeploymentEnvironments/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiDeploymentEnvironmentResponseModel> DeploymentEnvironmentGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentEnvironments/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeploymentEnvironmentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeploymentEnvironmentResponseModel>> DeploymentEnvironmentAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentEnvironments?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeploymentEnvironmentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeploymentEnvironmentResponseModel>> DeploymentEnvironmentBulkInsertAsync(List<ApiDeploymentEnvironmentRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeploymentEnvironments/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeploymentEnvironmentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDeploymentEnvironmentResponseModel> GetDeploymentEnvironmentGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentEnvironments/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeploymentEnvironmentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeploymentEnvironmentResponseModel>> GetDeploymentEnvironmentGetDataVersion(byte[] dataVersion)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentEnvironments/getDataVersion/{dataVersion}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeploymentEnvironmentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDeploymentHistoryResponseModel> DeploymentHistoryCreateAsync(ApiDeploymentHistoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeploymentHistories", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeploymentHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDeploymentHistoryResponseModel> DeploymentHistoryUpdateAsync(string id, ApiDeploymentHistoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/DeploymentHistories/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeploymentHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task DeploymentHistoryDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/DeploymentHistories/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiDeploymentHistoryResponseModel> DeploymentHistoryGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentHistories/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeploymentHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeploymentHistoryResponseModel>> DeploymentHistoryAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentHistories?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeploymentHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeploymentHistoryResponseModel>> DeploymentHistoryBulkInsertAsync(List<ApiDeploymentHistoryRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeploymentHistories/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeploymentHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeploymentHistoryResponseModel>> GetDeploymentHistoryGetCreated(DateTimeOffset created)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentHistories/getCreated/{created}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeploymentHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDeploymentProcessResponseModel> DeploymentProcessCreateAsync(ApiDeploymentProcessRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeploymentProcesses", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeploymentProcessResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDeploymentProcessResponseModel> DeploymentProcessUpdateAsync(string id, ApiDeploymentProcessRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/DeploymentProcesses/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeploymentProcessResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task DeploymentProcessDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/DeploymentProcesses/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiDeploymentProcessResponseModel> DeploymentProcessGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentProcesses/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeploymentProcessResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeploymentProcessResponseModel>> DeploymentProcessAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentProcesses?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeploymentProcessResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeploymentProcessResponseModel>> DeploymentProcessBulkInsertAsync(List<ApiDeploymentProcessRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeploymentProcesses/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeploymentProcessResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDeploymentRelatedMachineResponseModel> DeploymentRelatedMachineCreateAsync(ApiDeploymentRelatedMachineRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeploymentRelatedMachines", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeploymentRelatedMachineResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDeploymentRelatedMachineResponseModel> DeploymentRelatedMachineUpdateAsync(int id, ApiDeploymentRelatedMachineRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/DeploymentRelatedMachines/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeploymentRelatedMachineResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task DeploymentRelatedMachineDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/DeploymentRelatedMachines/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiDeploymentRelatedMachineResponseModel> DeploymentRelatedMachineGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentRelatedMachines/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeploymentRelatedMachineResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeploymentRelatedMachineResponseModel>> DeploymentRelatedMachineAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentRelatedMachines?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeploymentRelatedMachineResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeploymentRelatedMachineResponseModel>> DeploymentRelatedMachineBulkInsertAsync(List<ApiDeploymentRelatedMachineRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeploymentRelatedMachines/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeploymentRelatedMachineResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeploymentRelatedMachineResponseModel>> GetDeploymentRelatedMachineGetDeploymentId(string deploymentId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentRelatedMachines/getDeploymentId/{deploymentId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeploymentRelatedMachineResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeploymentRelatedMachineResponseModel>> GetDeploymentRelatedMachineGetMachineId(string machineId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeploymentRelatedMachines/getMachineId/{machineId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeploymentRelatedMachineResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiEventResponseModel> EventCreateAsync(ApiEventRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Events", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEventResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiEventResponseModel> EventUpdateAsync(string id, ApiEventRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Events/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEventResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task EventDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Events/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiEventResponseModel> EventGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEventResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEventResponseModel>> EventAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEventResponseModel>> EventBulkInsertAsync(List<ApiEventRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Events/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEventResponseModel>> GetEventGetAutoId(long autoId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events/getAutoId/{autoId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEventResponseModel>> GetEventGetIdRelatedDocumentIdsOccurredCategoryAutoId(string id, string relatedDocumentIds, DateTimeOffset occurred, string category, long autoId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events/getIdRelatedDocumentIdsOccurredCategoryAutoId/{id}/{relatedDocumentIds}/{occurred}/{category}/{autoId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEventResponseModel>> GetEventGetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(string id, string relatedDocumentIds, string projectId, string environmentId, string category, string userId, DateTimeOffset occurred, string tenantId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events/getIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId/{id}/{relatedDocumentIds}/{projectId}/{environmentId}/{category}/{userId}/{occurred}/{tenantId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEventResponseModel>> GetEventGetIdOccurred(string id, DateTimeOffset occurred)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events/getIdOccurred/{id}/{occurred}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEventRelatedDocumentResponseModel>> EventRelatedDocuments(string eventId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events/EventRelatedDocuments/{eventId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEventRelatedDocumentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiEventRelatedDocumentResponseModel> EventRelatedDocumentCreateAsync(ApiEventRelatedDocumentRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EventRelatedDocuments", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEventRelatedDocumentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiEventRelatedDocumentResponseModel> EventRelatedDocumentUpdateAsync(int id, ApiEventRelatedDocumentRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/EventRelatedDocuments/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEventRelatedDocumentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task EventRelatedDocumentDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/EventRelatedDocuments/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiEventRelatedDocumentResponseModel> EventRelatedDocumentGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EventRelatedDocuments/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEventRelatedDocumentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEventRelatedDocumentResponseModel>> EventRelatedDocumentAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EventRelatedDocuments?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEventRelatedDocumentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEventRelatedDocumentResponseModel>> EventRelatedDocumentBulkInsertAsync(List<ApiEventRelatedDocumentRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EventRelatedDocuments/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEventRelatedDocumentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEventRelatedDocumentResponseModel>> GetEventRelatedDocumentGetEventId(string eventId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EventRelatedDocuments/getEventId/{eventId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEventRelatedDocumentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEventRelatedDocumentResponseModel>> GetEventRelatedDocumentGetEventIdRelatedDocumentId(string eventId, string relatedDocumentId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EventRelatedDocuments/getEventIdRelatedDocumentId/{eventId}/{relatedDocumentId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEventRelatedDocumentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiExtensionConfigurationResponseModel> ExtensionConfigurationCreateAsync(ApiExtensionConfigurationRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ExtensionConfigurations", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiExtensionConfigurationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiExtensionConfigurationResponseModel> ExtensionConfigurationUpdateAsync(string id, ApiExtensionConfigurationRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ExtensionConfigurations/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiExtensionConfigurationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ExtensionConfigurationDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ExtensionConfigurations/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiExtensionConfigurationResponseModel> ExtensionConfigurationGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ExtensionConfigurations/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiExtensionConfigurationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiExtensionConfigurationResponseModel>> ExtensionConfigurationAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ExtensionConfigurations?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiExtensionConfigurationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiExtensionConfigurationResponseModel>> ExtensionConfigurationBulkInsertAsync(List<ApiExtensionConfigurationRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ExtensionConfigurations/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiExtensionConfigurationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiFeedResponseModel> FeedCreateAsync(ApiFeedRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Feeds", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiFeedResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiFeedResponseModel> FeedUpdateAsync(string id, ApiFeedRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Feeds/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiFeedResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task FeedDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Feeds/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiFeedResponseModel> FeedGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Feeds/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiFeedResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiFeedResponseModel>> FeedAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Feeds?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiFeedResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiFeedResponseModel>> FeedBulkInsertAsync(List<ApiFeedRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Feeds/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiFeedResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiFeedResponseModel> GetFeedGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Feeds/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiFeedResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiInterruptionResponseModel> InterruptionCreateAsync(ApiInterruptionRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Interruptions", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiInterruptionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiInterruptionResponseModel> InterruptionUpdateAsync(string id, ApiInterruptionRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Interruptions/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiInterruptionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task InterruptionDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Interruptions/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiInterruptionResponseModel> InterruptionGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Interruptions/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiInterruptionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiInterruptionResponseModel>> InterruptionAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Interruptions?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiInterruptionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiInterruptionResponseModel>> InterruptionBulkInsertAsync(List<ApiInterruptionRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Interruptions/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiInterruptionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiInterruptionResponseModel>> GetInterruptionGetTenantId(string tenantId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Interruptions/getTenantId/{tenantId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiInterruptionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiInvitationResponseModel> InvitationCreateAsync(ApiInvitationRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Invitations", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiInvitationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiInvitationResponseModel> InvitationUpdateAsync(string id, ApiInvitationRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Invitations/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiInvitationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task InvitationDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Invitations/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiInvitationResponseModel> InvitationGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Invitations/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiInvitationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiInvitationResponseModel>> InvitationAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Invitations?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiInvitationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiInvitationResponseModel>> InvitationBulkInsertAsync(List<ApiInvitationRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Invitations/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiInvitationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiKeyAllocationResponseModel> KeyAllocationCreateAsync(ApiKeyAllocationRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/KeyAllocations", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiKeyAllocationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiKeyAllocationResponseModel> KeyAllocationUpdateAsync(string id, ApiKeyAllocationRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/KeyAllocations/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiKeyAllocationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task KeyAllocationDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/KeyAllocations/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiKeyAllocationResponseModel> KeyAllocationGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/KeyAllocations/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiKeyAllocationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiKeyAllocationResponseModel>> KeyAllocationAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/KeyAllocations?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiKeyAllocationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiKeyAllocationResponseModel>> KeyAllocationBulkInsertAsync(List<ApiKeyAllocationRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/KeyAllocations/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiKeyAllocationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLibraryVariableSetResponseModel> LibraryVariableSetCreateAsync(ApiLibraryVariableSetRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LibraryVariableSets", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLibraryVariableSetResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLibraryVariableSetResponseModel> LibraryVariableSetUpdateAsync(string id, ApiLibraryVariableSetRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LibraryVariableSets/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLibraryVariableSetResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task LibraryVariableSetDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LibraryVariableSets/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiLibraryVariableSetResponseModel> LibraryVariableSetGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LibraryVariableSets/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLibraryVariableSetResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLibraryVariableSetResponseModel>> LibraryVariableSetAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LibraryVariableSets?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLibraryVariableSetResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLibraryVariableSetResponseModel>> LibraryVariableSetBulkInsertAsync(List<ApiLibraryVariableSetRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LibraryVariableSets/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLibraryVariableSetResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLibraryVariableSetResponseModel> GetLibraryVariableSetGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LibraryVariableSets/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLibraryVariableSetResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLifecycleResponseModel> LifecycleCreateAsync(ApiLifecycleRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Lifecycles", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLifecycleResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLifecycleResponseModel> LifecycleUpdateAsync(string id, ApiLifecycleRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Lifecycles/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLifecycleResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task LifecycleDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Lifecycles/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiLifecycleResponseModel> LifecycleGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lifecycles/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLifecycleResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLifecycleResponseModel>> LifecycleAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lifecycles?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLifecycleResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLifecycleResponseModel>> LifecycleBulkInsertAsync(List<ApiLifecycleRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Lifecycles/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLifecycleResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLifecycleResponseModel> GetLifecycleGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lifecycles/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLifecycleResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLifecycleResponseModel>> GetLifecycleGetDataVersion(byte[] dataVersion)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lifecycles/getDataVersion/{dataVersion}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLifecycleResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiMachineResponseModel> MachineCreateAsync(ApiMachineRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Machines", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiMachineResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiMachineResponseModel> MachineUpdateAsync(string id, ApiMachineRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Machines/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiMachineResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task MachineDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Machines/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiMachineResponseModel> MachineGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiMachineResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiMachineResponseModel>> MachineAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiMachineResponseModel>> MachineBulkInsertAsync(List<ApiMachineRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Machines/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiMachineResponseModel> GetMachineGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiMachineResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiMachineResponseModel>> GetMachineGetMachinePolicyId(string machinePolicyId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Machines/getMachinePolicyId/{machinePolicyId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiMachineResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiMachinePolicyResponseModel> MachinePolicyCreateAsync(ApiMachinePolicyRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/MachinePolicies", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiMachinePolicyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiMachinePolicyResponseModel> MachinePolicyUpdateAsync(string id, ApiMachinePolicyRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/MachinePolicies/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiMachinePolicyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task MachinePolicyDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/MachinePolicies/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiMachinePolicyResponseModel> MachinePolicyGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/MachinePolicies/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiMachinePolicyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiMachinePolicyResponseModel>> MachinePolicyAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/MachinePolicies?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiMachinePolicyResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiMachinePolicyResponseModel>> MachinePolicyBulkInsertAsync(List<ApiMachinePolicyRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/MachinePolicies/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiMachinePolicyResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiMachinePolicyResponseModel> GetMachinePolicyGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/MachinePolicies/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiMachinePolicyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiMutexResponseModel> MutexCreateAsync(ApiMutexRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Mutexes", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiMutexResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiMutexResponseModel> MutexUpdateAsync(string id, ApiMutexRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Mutexes/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiMutexResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task MutexDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Mutexes/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiMutexResponseModel> MutexGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Mutexes/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiMutexResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiMutexResponseModel>> MutexAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Mutexes?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiMutexResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiMutexResponseModel>> MutexBulkInsertAsync(List<ApiMutexRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Mutexes/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiMutexResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiNuGetPackageResponseModel> NuGetPackageCreateAsync(ApiNuGetPackageRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/NuGetPackages", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiNuGetPackageResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiNuGetPackageResponseModel> NuGetPackageUpdateAsync(string id, ApiNuGetPackageRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/NuGetPackages/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiNuGetPackageResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task NuGetPackageDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/NuGetPackages/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiNuGetPackageResponseModel> NuGetPackageGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/NuGetPackages/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiNuGetPackageResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiNuGetPackageResponseModel>> NuGetPackageAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/NuGetPackages?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiNuGetPackageResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiNuGetPackageResponseModel>> NuGetPackageBulkInsertAsync(List<ApiNuGetPackageRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/NuGetPackages/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiNuGetPackageResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiOctopusServerNodeResponseModel> OctopusServerNodeCreateAsync(ApiOctopusServerNodeRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/OctopusServerNodes", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiOctopusServerNodeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiOctopusServerNodeResponseModel> OctopusServerNodeUpdateAsync(string id, ApiOctopusServerNodeRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/OctopusServerNodes/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiOctopusServerNodeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task OctopusServerNodeDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/OctopusServerNodes/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiOctopusServerNodeResponseModel> OctopusServerNodeGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/OctopusServerNodes/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiOctopusServerNodeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiOctopusServerNodeResponseModel>> OctopusServerNodeAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/OctopusServerNodes?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiOctopusServerNodeResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiOctopusServerNodeResponseModel>> OctopusServerNodeBulkInsertAsync(List<ApiOctopusServerNodeRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/OctopusServerNodes/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiOctopusServerNodeResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProjectResponseModel> ProjectCreateAsync(ApiProjectRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Projects", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProjectResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProjectResponseModel> ProjectUpdateAsync(string id, ApiProjectRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Projects/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProjectResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProjectDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Projects/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProjectResponseModel> ProjectGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Projects/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProjectResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProjectResponseModel>> ProjectAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Projects?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProjectResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProjectResponseModel>> ProjectBulkInsertAsync(List<ApiProjectRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Projects/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProjectResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProjectResponseModel> GetProjectGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Projects/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProjectResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProjectResponseModel> GetProjectGetSlug(string slug)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Projects/getSlug/{slug}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProjectResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProjectResponseModel>> GetProjectGetDataVersion(byte[] dataVersion)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Projects/getDataVersion/{dataVersion}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProjectResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProjectResponseModel>> GetProjectGetDiscreteChannelReleaseId(bool discreteChannelRelease, string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Projects/getDiscreteChannelReleaseId/{discreteChannelRelease}/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProjectResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProjectGroupResponseModel> ProjectGroupCreateAsync(ApiProjectGroupRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProjectGroups", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProjectGroupResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProjectGroupResponseModel> ProjectGroupUpdateAsync(string id, ApiProjectGroupRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProjectGroups/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProjectGroupResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProjectGroupDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProjectGroups/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProjectGroupResponseModel> ProjectGroupGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProjectGroups/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProjectGroupResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProjectGroupResponseModel>> ProjectGroupAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProjectGroups?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProjectGroupResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProjectGroupResponseModel>> ProjectGroupBulkInsertAsync(List<ApiProjectGroupRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProjectGroups/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProjectGroupResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProjectGroupResponseModel> GetProjectGroupGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProjectGroups/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProjectGroupResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProjectGroupResponseModel>> GetProjectGroupGetDataVersion(byte[] dataVersion)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProjectGroups/getDataVersion/{dataVersion}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProjectGroupResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProjectTriggerResponseModel> ProjectTriggerCreateAsync(ApiProjectTriggerRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProjectTriggers", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProjectTriggerResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProjectTriggerResponseModel> ProjectTriggerUpdateAsync(string id, ApiProjectTriggerRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProjectTriggers/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProjectTriggerResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProjectTriggerDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProjectTriggers/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProjectTriggerResponseModel> ProjectTriggerGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProjectTriggers/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProjectTriggerResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProjectTriggerResponseModel>> ProjectTriggerAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProjectTriggers?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProjectTriggerResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProjectTriggerResponseModel>> ProjectTriggerBulkInsertAsync(List<ApiProjectTriggerRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProjectTriggers/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProjectTriggerResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProjectTriggerResponseModel> GetProjectTriggerGetProjectIdName(string projectId, string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProjectTriggers/getProjectIdName/{projectId}/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProjectTriggerResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProjectTriggerResponseModel>> GetProjectTriggerGetProjectId(string projectId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProjectTriggers/getProjectId/{projectId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProjectTriggerResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProxyResponseModel> ProxyCreateAsync(ApiProxyRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Proxies", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProxyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProxyResponseModel> ProxyUpdateAsync(string id, ApiProxyRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Proxies/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProxyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProxyDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Proxies/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProxyResponseModel> ProxyGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Proxies/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProxyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProxyResponseModel>> ProxyAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Proxies?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProxyResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProxyResponseModel>> ProxyBulkInsertAsync(List<ApiProxyRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Proxies/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProxyResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProxyResponseModel> GetProxyGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Proxies/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProxyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiReleaseResponseModel> ReleaseCreateAsync(ApiReleaseRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Releases", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiReleaseResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiReleaseResponseModel> ReleaseUpdateAsync(string id, ApiReleaseRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Releases/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiReleaseResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ReleaseDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Releases/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiReleaseResponseModel> ReleaseGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Releases/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiReleaseResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiReleaseResponseModel>> ReleaseAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Releases?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiReleaseResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiReleaseResponseModel>> ReleaseBulkInsertAsync(List<ApiReleaseRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Releases/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiReleaseResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiReleaseResponseModel> GetReleaseGetVersionProjectId(string version, string projectId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Releases/getVersionProjectId/{version}/{projectId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiReleaseResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiReleaseResponseModel>> GetReleaseGetIdAssembled(string id, DateTimeOffset assembled)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Releases/getIdAssembled/{id}/{assembled}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiReleaseResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiReleaseResponseModel>> GetReleaseGetProjectDeploymentProcessSnapshotId(string projectDeploymentProcessSnapshotId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Releases/getProjectDeploymentProcessSnapshotId/{projectDeploymentProcessSnapshotId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiReleaseResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiReleaseResponseModel>> GetReleaseGetIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(string id, string version, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string channelId, DateTimeOffset assembled)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Releases/getIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled/{id}/{version}/{projectVariableSetSnapshotId}/{projectDeploymentProcessSnapshotId}/{jSON}/{projectId}/{channelId}/{assembled}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiReleaseResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiReleaseResponseModel>> GetReleaseGetIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(string id, string channelId, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string version, DateTimeOffset assembled)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Releases/getIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled/{id}/{channelId}/{projectVariableSetSnapshotId}/{projectDeploymentProcessSnapshotId}/{jSON}/{projectId}/{version}/{assembled}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiReleaseResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSchemaVersionsResponseModel> SchemaVersionsCreateAsync(ApiSchemaVersionsRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SchemaVersions", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSchemaVersionsResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSchemaVersionsResponseModel> SchemaVersionsUpdateAsync(int id, ApiSchemaVersionsRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SchemaVersions/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSchemaVersionsResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SchemaVersionsDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SchemaVersions/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSchemaVersionsResponseModel> SchemaVersionsGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SchemaVersions/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSchemaVersionsResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSchemaVersionsResponseModel>> SchemaVersionsAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SchemaVersions?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSchemaVersionsResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSchemaVersionsResponseModel>> SchemaVersionsBulkInsertAsync(List<ApiSchemaVersionsRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SchemaVersions/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSchemaVersionsResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiServerTaskResponseModel> ServerTaskCreateAsync(ApiServerTaskRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ServerTasks", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiServerTaskResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiServerTaskResponseModel> ServerTaskUpdateAsync(string id, ApiServerTaskRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ServerTasks/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiServerTaskResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ServerTaskDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ServerTasks/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiServerTaskResponseModel> ServerTaskGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ServerTasks/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiServerTaskResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiServerTaskResponseModel>> ServerTaskAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ServerTasks?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiServerTaskResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiServerTaskResponseModel>> ServerTaskBulkInsertAsync(List<ApiServerTaskRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ServerTasks/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiServerTaskResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiServerTaskResponseModel>> GetServerTaskGetDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(string description, DateTimeOffset queueTime, Nullable<DateTimeOffset> startTime, Nullable<DateTimeOffset> completedTime, string errorMessage, string concurrencyTag, bool hasPendingInterruptions, bool hasWarningsOrErrors, int durationSeconds, string jSON, string state, string name, string projectId, string environmentId, string tenantId, string serverNodeId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ServerTasks/getDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId/{description}/{queueTime}/{startTime}/{completedTime}/{errorMessage}/{concurrencyTag}/{hasPendingInterruptions}/{hasWarningsOrErrors}/{durationSeconds}/{jSON}/{state}/{name}/{projectId}/{environmentId}/{tenantId}/{serverNodeId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiServerTaskResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiServerTaskResponseModel>> GetServerTaskGetStateConcurrencyTag(string state, string concurrencyTag)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ServerTasks/getStateConcurrencyTag/{state}/{concurrencyTag}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiServerTaskResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiServerTaskResponseModel>> GetServerTaskGetNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(string name, string description, Nullable<DateTimeOffset> startTime, Nullable<DateTimeOffset> completedTime, string errorMessage, bool hasWarningsOrErrors, string projectId, string environmentId, string tenantId, int durationSeconds, string jSON, DateTimeOffset queueTime, string state, string concurrencyTag, bool hasPendingInterruptions, string serverNodeId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ServerTasks/getNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId/{name}/{description}/{startTime}/{completedTime}/{errorMessage}/{hasWarningsOrErrors}/{projectId}/{environmentId}/{tenantId}/{durationSeconds}/{jSON}/{queueTime}/{state}/{concurrencyTag}/{hasPendingInterruptions}/{serverNodeId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiServerTaskResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSubscriptionResponseModel> SubscriptionCreateAsync(ApiSubscriptionRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Subscriptions", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSubscriptionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSubscriptionResponseModel> SubscriptionUpdateAsync(string id, ApiSubscriptionRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Subscriptions/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSubscriptionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SubscriptionDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Subscriptions/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSubscriptionResponseModel> SubscriptionGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Subscriptions/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSubscriptionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSubscriptionResponseModel>> SubscriptionAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Subscriptions?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSubscriptionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSubscriptionResponseModel>> SubscriptionBulkInsertAsync(List<ApiSubscriptionRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Subscriptions/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSubscriptionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSubscriptionResponseModel> GetSubscriptionGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Subscriptions/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSubscriptionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTagSetResponseModel> TagSetCreateAsync(ApiTagSetRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TagSets", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTagSetResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTagSetResponseModel> TagSetUpdateAsync(string id, ApiTagSetRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TagSets/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTagSetResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task TagSetDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TagSets/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiTagSetResponseModel> TagSetGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TagSets/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTagSetResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTagSetResponseModel>> TagSetAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TagSets?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTagSetResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTagSetResponseModel>> TagSetBulkInsertAsync(List<ApiTagSetRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TagSets/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTagSetResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTagSetResponseModel> GetTagSetGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TagSets/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTagSetResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTagSetResponseModel>> GetTagSetGetDataVersion(byte[] dataVersion)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TagSets/getDataVersion/{dataVersion}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTagSetResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTeamResponseModel> TeamCreateAsync(ApiTeamRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teams", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTeamResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTeamResponseModel> TeamUpdateAsync(string id, ApiTeamRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Teams/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTeamResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task TeamDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Teams/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiTeamResponseModel> TeamGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTeamResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTeamResponseModel>> TeamAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTeamResponseModel>> TeamBulkInsertAsync(List<ApiTeamRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teams/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTeamResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTeamResponseModel> GetTeamGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teams/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTeamResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTenantResponseModel> TenantCreateAsync(ApiTenantRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Tenants", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTenantResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTenantResponseModel> TenantUpdateAsync(string id, ApiTenantRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Tenants/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTenantResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task TenantDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Tenants/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiTenantResponseModel> TenantGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tenants/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTenantResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTenantResponseModel>> TenantAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tenants?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTenantResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTenantResponseModel>> TenantBulkInsertAsync(List<ApiTenantRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Tenants/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTenantResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTenantResponseModel> GetTenantGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tenants/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTenantResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTenantResponseModel>> GetTenantGetDataVersion(byte[] dataVersion)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tenants/getDataVersion/{dataVersion}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTenantResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTenantVariableResponseModel> TenantVariableCreateAsync(ApiTenantVariableRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TenantVariables", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTenantVariableResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTenantVariableResponseModel> TenantVariableUpdateAsync(string id, ApiTenantVariableRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TenantVariables/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTenantVariableResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task TenantVariableDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TenantVariables/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiTenantVariableResponseModel> TenantVariableGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TenantVariables/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTenantVariableResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTenantVariableResponseModel>> TenantVariableAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TenantVariables?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTenantVariableResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTenantVariableResponseModel>> TenantVariableBulkInsertAsync(List<ApiTenantVariableRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TenantVariables/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTenantVariableResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTenantVariableResponseModel> GetTenantVariableGetTenantIdOwnerIdEnvironmentIdVariableTemplateId(string tenantId, string ownerId, string environmentId, string variableTemplateId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TenantVariables/getTenantIdOwnerIdEnvironmentIdVariableTemplateId/{tenantId}/{ownerId}/{environmentId}/{variableTemplateId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTenantVariableResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTenantVariableResponseModel>> GetTenantVariableGetTenantId(string tenantId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TenantVariables/getTenantId/{tenantId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTenantVariableResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiUserResponseModel> UserCreateAsync(ApiUserRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Users", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiUserResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiUserResponseModel> UserUpdateAsync(string id, ApiUserRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Users/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiUserResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task UserDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Users/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiUserResponseModel> UserGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiUserResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiUserResponseModel>> UserAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiUserResponseModel>> UserBulkInsertAsync(List<ApiUserRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Users/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiUserResponseModel> GetUserGetUsername(string username)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/getUsername/{username}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiUserResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiUserResponseModel>> GetUserGetDisplayName(string displayName)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/getDisplayName/{displayName}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiUserResponseModel>> GetUserGetEmailAddress(string emailAddress)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/getEmailAddress/{emailAddress}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiUserResponseModel>> GetUserGetExternalId(string externalId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/getExternalId/{externalId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiUserRoleResponseModel> UserRoleCreateAsync(ApiUserRoleRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/UserRoles", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiUserRoleResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiUserRoleResponseModel> UserRoleUpdateAsync(string id, ApiUserRoleRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/UserRoles/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiUserRoleResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task UserRoleDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/UserRoles/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiUserRoleResponseModel> UserRoleGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UserRoles/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiUserRoleResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiUserRoleResponseModel>> UserRoleAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UserRoles?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiUserRoleResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiUserRoleResponseModel>> UserRoleBulkInsertAsync(List<ApiUserRoleRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/UserRoles/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiUserRoleResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiUserRoleResponseModel> GetUserRoleGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UserRoles/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiUserRoleResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiVariableSetResponseModel> VariableSetCreateAsync(ApiVariableSetRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VariableSets", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiVariableSetResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiVariableSetResponseModel> VariableSetUpdateAsync(string id, ApiVariableSetRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/VariableSets/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiVariableSetResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task VariableSetDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/VariableSets/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiVariableSetResponseModel> VariableSetGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VariableSets/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiVariableSetResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiVariableSetResponseModel>> VariableSetAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VariableSets?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiVariableSetResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiVariableSetResponseModel>> VariableSetBulkInsertAsync(List<ApiVariableSetRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VariableSets/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiVariableSetResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiWorkerResponseModel> WorkerCreateAsync(ApiWorkerRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Workers", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiWorkerResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiWorkerResponseModel> WorkerUpdateAsync(string id, ApiWorkerRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Workers/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiWorkerResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task WorkerDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Workers/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiWorkerResponseModel> WorkerGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Workers/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiWorkerResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiWorkerResponseModel>> WorkerAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Workers?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiWorkerResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiWorkerResponseModel>> WorkerBulkInsertAsync(List<ApiWorkerRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Workers/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiWorkerResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiWorkerResponseModel> GetWorkerGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Workers/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiWorkerResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiWorkerResponseModel>> GetWorkerGetMachinePolicyId(string machinePolicyId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Workers/getMachinePolicyId/{machinePolicyId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiWorkerResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiWorkerPoolResponseModel> WorkerPoolCreateAsync(ApiWorkerPoolRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkerPools", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiWorkerPoolResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiWorkerPoolResponseModel> WorkerPoolUpdateAsync(string id, ApiWorkerPoolRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/WorkerPools/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiWorkerPoolResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task WorkerPoolDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/WorkerPools/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiWorkerPoolResponseModel> WorkerPoolGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkerPools/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiWorkerPoolResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiWorkerPoolResponseModel>> WorkerPoolAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkerPools?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiWorkerPoolResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiWorkerPoolResponseModel>> WorkerPoolBulkInsertAsync(List<ApiWorkerPoolRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkerPools/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiWorkerPoolResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiWorkerPoolResponseModel> GetWorkerPoolGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkerPools/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiWorkerPoolResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiWorkerTaskLeaseResponseModel> WorkerTaskLeaseCreateAsync(ApiWorkerTaskLeaseRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkerTaskLeases", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiWorkerTaskLeaseResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiWorkerTaskLeaseResponseModel> WorkerTaskLeaseUpdateAsync(string id, ApiWorkerTaskLeaseRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/WorkerTaskLeases/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiWorkerTaskLeaseResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task WorkerTaskLeaseDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/WorkerTaskLeases/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiWorkerTaskLeaseResponseModel> WorkerTaskLeaseGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkerTaskLeases/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiWorkerTaskLeaseResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiWorkerTaskLeaseResponseModel>> WorkerTaskLeaseAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkerTaskLeases?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiWorkerTaskLeaseResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiWorkerTaskLeaseResponseModel>> WorkerTaskLeaseBulkInsertAsync(List<ApiWorkerTaskLeaseRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkerTaskLeases/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiWorkerTaskLeaseResponseModel>>(httpResponse.Content.ContentToString());
                }
        }
}

/*<Codenesium>
    <Hash>4e503e42dfdd0d3bf51e8ee773c8ba2b</Hash>
</Codenesium>*/