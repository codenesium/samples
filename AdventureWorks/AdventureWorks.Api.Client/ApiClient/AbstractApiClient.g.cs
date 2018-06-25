using AdventureWorksNS.Api.Contracts;
using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
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

                public virtual async Task<ApiAWBuildVersionResponseModel> AWBuildVersionCreateAsync(ApiAWBuildVersionRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AWBuildVersions", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAWBuildVersionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiAWBuildVersionResponseModel> AWBuildVersionUpdateAsync(int id, ApiAWBuildVersionRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/AWBuildVersions/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAWBuildVersionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task AWBuildVersionDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/AWBuildVersions/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiAWBuildVersionResponseModel> AWBuildVersionGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AWBuildVersions/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAWBuildVersionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiAWBuildVersionResponseModel>> AWBuildVersionAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AWBuildVersions?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiAWBuildVersionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiAWBuildVersionResponseModel>> AWBuildVersionBulkInsertAsync(List<ApiAWBuildVersionRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AWBuildVersions/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiAWBuildVersionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDatabaseLogResponseModel> DatabaseLogCreateAsync(ApiDatabaseLogRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DatabaseLogs", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDatabaseLogResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDatabaseLogResponseModel> DatabaseLogUpdateAsync(int id, ApiDatabaseLogRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/DatabaseLogs/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDatabaseLogResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task DatabaseLogDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/DatabaseLogs/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiDatabaseLogResponseModel> DatabaseLogGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DatabaseLogs/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDatabaseLogResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDatabaseLogResponseModel>> DatabaseLogAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DatabaseLogs?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDatabaseLogResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDatabaseLogResponseModel>> DatabaseLogBulkInsertAsync(List<ApiDatabaseLogRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DatabaseLogs/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDatabaseLogResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiErrorLogResponseModel> ErrorLogCreateAsync(ApiErrorLogRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ErrorLogs", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiErrorLogResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiErrorLogResponseModel> ErrorLogUpdateAsync(int id, ApiErrorLogRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ErrorLogs/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiErrorLogResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ErrorLogDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ErrorLogs/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiErrorLogResponseModel> ErrorLogGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ErrorLogs/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiErrorLogResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiErrorLogResponseModel>> ErrorLogAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ErrorLogs?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiErrorLogResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiErrorLogResponseModel>> ErrorLogBulkInsertAsync(List<ApiErrorLogRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ErrorLogs/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiErrorLogResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDepartmentResponseModel> DepartmentCreateAsync(ApiDepartmentRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Departments", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDepartmentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDepartmentResponseModel> DepartmentUpdateAsync(short id, ApiDepartmentRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Departments/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDepartmentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task DepartmentDeleteAsync(short id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Departments/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiDepartmentResponseModel> DepartmentGetAsync(short id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Departments/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDepartmentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDepartmentResponseModel>> DepartmentAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Departments?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDepartmentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDepartmentResponseModel>> DepartmentBulkInsertAsync(List<ApiDepartmentRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Departments/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDepartmentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDepartmentResponseModel> GetDepartmentByName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Departments/byName/{name}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDepartmentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistories(short departmentID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Departments/EmployeeDepartmentHistories/{departmentID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEmployeeDepartmentHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiEmployeeResponseModel> EmployeeCreateAsync(ApiEmployeeRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Employees", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEmployeeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiEmployeeResponseModel> EmployeeUpdateAsync(int id, ApiEmployeeRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Employees/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEmployeeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task EmployeeDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Employees/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiEmployeeResponseModel> EmployeeGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEmployeeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEmployeeResponseModel>> EmployeeAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEmployeeResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEmployeeResponseModel>> EmployeeBulkInsertAsync(List<ApiEmployeeRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Employees/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEmployeeResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiEmployeeResponseModel> GetEmployeeByLoginID(string loginID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/byLoginID/{loginID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEmployeeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiEmployeeResponseModel> GetEmployeeByNationalIDNumber(string nationalIDNumber)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/byNationalIDNumber/{nationalIDNumber}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEmployeeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEmployeePayHistoryResponseModel>> EmployeePayHistories(int businessEntityID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/EmployeePayHistories/{businessEntityID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEmployeePayHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiJobCandidateResponseModel>> JobCandidates(int businessEntityID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/JobCandidates/{businessEntityID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiJobCandidateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiEmployeeDepartmentHistoryResponseModel> EmployeeDepartmentHistoryCreateAsync(ApiEmployeeDepartmentHistoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeeDepartmentHistories", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEmployeeDepartmentHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiEmployeeDepartmentHistoryResponseModel> EmployeeDepartmentHistoryUpdateAsync(int id, ApiEmployeeDepartmentHistoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/EmployeeDepartmentHistories/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEmployeeDepartmentHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task EmployeeDepartmentHistoryDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/EmployeeDepartmentHistories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiEmployeeDepartmentHistoryResponseModel> EmployeeDepartmentHistoryGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEmployeeDepartmentHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistoryAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEmployeeDepartmentHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistoryBulkInsertAsync(List<ApiEmployeeDepartmentHistoryRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeeDepartmentHistories/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEmployeeDepartmentHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> GetEmployeeDepartmentHistoryByDepartmentID(short departmentID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories/byDepartmentID/{departmentID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEmployeeDepartmentHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> GetEmployeeDepartmentHistoryByShiftID(int shiftID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories/byShiftID/{shiftID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEmployeeDepartmentHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiEmployeePayHistoryResponseModel> EmployeePayHistoryCreateAsync(ApiEmployeePayHistoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeePayHistories", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEmployeePayHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiEmployeePayHistoryResponseModel> EmployeePayHistoryUpdateAsync(int id, ApiEmployeePayHistoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/EmployeePayHistories/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEmployeePayHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task EmployeePayHistoryDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/EmployeePayHistories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiEmployeePayHistoryResponseModel> EmployeePayHistoryGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeePayHistories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEmployeePayHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEmployeePayHistoryResponseModel>> EmployeePayHistoryAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeePayHistories?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEmployeePayHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEmployeePayHistoryResponseModel>> EmployeePayHistoryBulkInsertAsync(List<ApiEmployeePayHistoryRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeePayHistories/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEmployeePayHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiJobCandidateResponseModel> JobCandidateCreateAsync(ApiJobCandidateRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/JobCandidates", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiJobCandidateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiJobCandidateResponseModel> JobCandidateUpdateAsync(int id, ApiJobCandidateRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/JobCandidates/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiJobCandidateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task JobCandidateDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/JobCandidates/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiJobCandidateResponseModel> JobCandidateGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/JobCandidates/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiJobCandidateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiJobCandidateResponseModel>> JobCandidateAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/JobCandidates?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiJobCandidateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiJobCandidateResponseModel>> JobCandidateBulkInsertAsync(List<ApiJobCandidateRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/JobCandidates/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiJobCandidateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiJobCandidateResponseModel>> GetJobCandidateByBusinessEntityID(int? businessEntityID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/JobCandidates/byBusinessEntityID/{businessEntityID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiJobCandidateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiShiftResponseModel> ShiftCreateAsync(ApiShiftRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Shifts", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiShiftResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiShiftResponseModel> ShiftUpdateAsync(int id, ApiShiftRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Shifts/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiShiftResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ShiftDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Shifts/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiShiftResponseModel> ShiftGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiShiftResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiShiftResponseModel>> ShiftAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiShiftResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiShiftResponseModel>> ShiftBulkInsertAsync(List<ApiShiftRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Shifts/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiShiftResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiShiftResponseModel> GetShiftByName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts/byName/{name}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiShiftResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiShiftResponseModel> GetShiftByStartTimeEndTime(TimeSpan startTime, TimeSpan endTime)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts/byStartTimeEndTime/{startTime}/{endTime}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiShiftResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiAddressResponseModel> AddressCreateAsync(ApiAddressRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Addresses", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAddressResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiAddressResponseModel> AddressUpdateAsync(int id, ApiAddressRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Addresses/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAddressResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task AddressDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Addresses/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiAddressResponseModel> AddressGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAddressResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiAddressResponseModel>> AddressAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiAddressResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiAddressResponseModel>> AddressBulkInsertAsync(List<ApiAddressRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Addresses/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiAddressResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiAddressResponseModel> GetAddressByAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1, string addressLine2, string city, int stateProvinceID, string postalCode)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses/byAddressLine1AddressLine2CityStateProvinceIDPostalCode/{addressLine1}/{addressLine2}/{city}/{stateProvinceID}/{postalCode}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAddressResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiAddressResponseModel>> GetAddressByStateProvinceID(int stateProvinceID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses/byStateProvinceID/{stateProvinceID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiAddressResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddresses(int addressID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses/BusinessEntityAddresses/{addressID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBusinessEntityAddressResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiAddressTypeResponseModel> AddressTypeCreateAsync(ApiAddressTypeRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AddressTypes", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAddressTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiAddressTypeResponseModel> AddressTypeUpdateAsync(int id, ApiAddressTypeRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/AddressTypes/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAddressTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task AddressTypeDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/AddressTypes/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiAddressTypeResponseModel> AddressTypeGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AddressTypes/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAddressTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiAddressTypeResponseModel>> AddressTypeAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AddressTypes?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiAddressTypeResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiAddressTypeResponseModel>> AddressTypeBulkInsertAsync(List<ApiAddressTypeRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AddressTypes/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiAddressTypeResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiAddressTypeResponseModel> GetAddressTypeByName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AddressTypes/byName/{name}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAddressTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiBusinessEntityResponseModel> BusinessEntityCreateAsync(ApiBusinessEntityRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntities", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBusinessEntityResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiBusinessEntityResponseModel> BusinessEntityUpdateAsync(int id, ApiBusinessEntityRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/BusinessEntities/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBusinessEntityResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task BusinessEntityDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/BusinessEntities/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiBusinessEntityResponseModel> BusinessEntityGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntities/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBusinessEntityResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBusinessEntityResponseModel>> BusinessEntityAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntities?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBusinessEntityResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBusinessEntityResponseModel>> BusinessEntityBulkInsertAsync(List<ApiBusinessEntityRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntities/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBusinessEntityResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContacts(int businessEntityID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntities/BusinessEntityContacts/{businessEntityID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBusinessEntityContactResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPersonResponseModel>> People(int businessEntityID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntities/People/{businessEntityID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiBusinessEntityAddressResponseModel> BusinessEntityAddressCreateAsync(ApiBusinessEntityAddressRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityAddresses", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBusinessEntityAddressResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiBusinessEntityAddressResponseModel> BusinessEntityAddressUpdateAsync(int id, ApiBusinessEntityAddressRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/BusinessEntityAddresses/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBusinessEntityAddressResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task BusinessEntityAddressDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/BusinessEntityAddresses/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiBusinessEntityAddressResponseModel> BusinessEntityAddressGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBusinessEntityAddressResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddressAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBusinessEntityAddressResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddressBulkInsertAsync(List<ApiBusinessEntityAddressRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityAddresses/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBusinessEntityAddressResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> GetBusinessEntityAddressByAddressID(int addressID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses/byAddressID/{addressID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBusinessEntityAddressResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> GetBusinessEntityAddressByAddressTypeID(int addressTypeID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses/byAddressTypeID/{addressTypeID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBusinessEntityAddressResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiBusinessEntityContactResponseModel> BusinessEntityContactCreateAsync(ApiBusinessEntityContactRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityContacts", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBusinessEntityContactResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiBusinessEntityContactResponseModel> BusinessEntityContactUpdateAsync(int id, ApiBusinessEntityContactRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/BusinessEntityContacts/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBusinessEntityContactResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task BusinessEntityContactDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/BusinessEntityContacts/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiBusinessEntityContactResponseModel> BusinessEntityContactGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBusinessEntityContactResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContactAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBusinessEntityContactResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContactBulkInsertAsync(List<ApiBusinessEntityContactRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityContacts/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBusinessEntityContactResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBusinessEntityContactResponseModel>> GetBusinessEntityContactByContactTypeID(int contactTypeID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts/byContactTypeID/{contactTypeID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBusinessEntityContactResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBusinessEntityContactResponseModel>> GetBusinessEntityContactByPersonID(int personID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts/byPersonID/{personID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBusinessEntityContactResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiContactTypeResponseModel> ContactTypeCreateAsync(ApiContactTypeRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ContactTypes", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiContactTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiContactTypeResponseModel> ContactTypeUpdateAsync(int id, ApiContactTypeRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ContactTypes/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiContactTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ContactTypeDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ContactTypes/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiContactTypeResponseModel> ContactTypeGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ContactTypes/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiContactTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiContactTypeResponseModel>> ContactTypeAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ContactTypes?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiContactTypeResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiContactTypeResponseModel>> ContactTypeBulkInsertAsync(List<ApiContactTypeRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ContactTypes/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiContactTypeResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiContactTypeResponseModel> GetContactTypeByName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ContactTypes/byName/{name}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiContactTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCountryRegionResponseModel> CountryRegionCreateAsync(ApiCountryRegionRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRegions", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCountryRegionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCountryRegionResponseModel> CountryRegionUpdateAsync(string id, ApiCountryRegionRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CountryRegions/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCountryRegionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task CountryRegionDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CountryRegions/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiCountryRegionResponseModel> CountryRegionGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegions/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCountryRegionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCountryRegionResponseModel>> CountryRegionAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegions?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCountryRegionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCountryRegionResponseModel>> CountryRegionBulkInsertAsync(List<ApiCountryRegionRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRegions/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCountryRegionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCountryRegionResponseModel> GetCountryRegionByName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegions/byName/{name}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCountryRegionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStateProvinceResponseModel>> StateProvinces(string countryRegionCode)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegions/StateProvinces/{countryRegionCode}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStateProvinceResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiEmailAddressResponseModel> EmailAddressCreateAsync(ApiEmailAddressRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmailAddresses", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEmailAddressResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiEmailAddressResponseModel> EmailAddressUpdateAsync(int id, ApiEmailAddressRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/EmailAddresses/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEmailAddressResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task EmailAddressDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/EmailAddresses/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiEmailAddressResponseModel> EmailAddressGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmailAddresses/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiEmailAddressResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEmailAddressResponseModel>> EmailAddressAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmailAddresses?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEmailAddressResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEmailAddressResponseModel>> EmailAddressBulkInsertAsync(List<ApiEmailAddressRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmailAddresses/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEmailAddressResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEmailAddressResponseModel>> GetEmailAddressByEmailAddress(string emailAddress1)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmailAddresses/byEmailAddress/{emailAddress1}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEmailAddressResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPasswordResponseModel> PasswordCreateAsync(ApiPasswordRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Passwords", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPasswordResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPasswordResponseModel> PasswordUpdateAsync(int id, ApiPasswordRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Passwords/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPasswordResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task PasswordDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Passwords/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiPasswordResponseModel> PasswordGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Passwords/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPasswordResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPasswordResponseModel>> PasswordAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Passwords?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPasswordResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPasswordResponseModel>> PasswordBulkInsertAsync(List<ApiPasswordRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Passwords/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPasswordResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPersonResponseModel> PersonCreateAsync(ApiPersonRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/People", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPersonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPersonResponseModel> PersonUpdateAsync(int id, ApiPersonRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/People/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPersonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task PersonDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/People/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiPersonResponseModel> PersonGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPersonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPersonResponseModel>> PersonAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPersonResponseModel>> PersonBulkInsertAsync(List<ApiPersonRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/People/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPersonResponseModel>> GetPersonByLastNameFirstNameMiddleName(string lastName, string firstName, string middleName)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/byLastNameFirstNameMiddleName/{lastName}/{firstName}/{middleName}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPersonResponseModel>> GetPersonByAdditionalContactInfo(string additionalContactInfo)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/byAdditionalContactInfo/{additionalContactInfo}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPersonResponseModel>> GetPersonByDemographics(string demographics)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/byDemographics/{demographics}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiEmailAddressResponseModel>> EmailAddresses(int businessEntityID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/EmailAddresses/{businessEntityID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiEmailAddressResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPasswordResponseModel>> Passwords(int businessEntityID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/Passwords/{businessEntityID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPasswordResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPersonPhoneResponseModel>> PersonPhones(int businessEntityID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/PersonPhones/{businessEntityID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPersonPhoneResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPersonPhoneResponseModel> PersonPhoneCreateAsync(ApiPersonPhoneRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonPhones", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPersonPhoneResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPersonPhoneResponseModel> PersonPhoneUpdateAsync(int id, ApiPersonPhoneRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PersonPhones/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPersonPhoneResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task PersonPhoneDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PersonPhones/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiPersonPhoneResponseModel> PersonPhoneGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonPhones/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPersonPhoneResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPersonPhoneResponseModel>> PersonPhoneAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonPhones?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPersonPhoneResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPersonPhoneResponseModel>> PersonPhoneBulkInsertAsync(List<ApiPersonPhoneRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonPhones/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPersonPhoneResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPersonPhoneResponseModel>> GetPersonPhoneByPhoneNumber(string phoneNumber)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonPhones/byPhoneNumber/{phoneNumber}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPersonPhoneResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPhoneNumberTypeResponseModel> PhoneNumberTypeCreateAsync(ApiPhoneNumberTypeRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PhoneNumberTypes", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPhoneNumberTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPhoneNumberTypeResponseModel> PhoneNumberTypeUpdateAsync(int id, ApiPhoneNumberTypeRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PhoneNumberTypes/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPhoneNumberTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task PhoneNumberTypeDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PhoneNumberTypes/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiPhoneNumberTypeResponseModel> PhoneNumberTypeGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PhoneNumberTypes/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPhoneNumberTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPhoneNumberTypeResponseModel>> PhoneNumberTypeAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PhoneNumberTypes?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPhoneNumberTypeResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPhoneNumberTypeResponseModel>> PhoneNumberTypeBulkInsertAsync(List<ApiPhoneNumberTypeRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PhoneNumberTypes/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPhoneNumberTypeResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiStateProvinceResponseModel> StateProvinceCreateAsync(ApiStateProvinceRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/StateProvinces", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStateProvinceResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiStateProvinceResponseModel> StateProvinceUpdateAsync(int id, ApiStateProvinceRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/StateProvinces/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStateProvinceResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task StateProvinceDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/StateProvinces/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiStateProvinceResponseModel> StateProvinceGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStateProvinceResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStateProvinceResponseModel>> StateProvinceAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStateProvinceResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStateProvinceResponseModel>> StateProvinceBulkInsertAsync(List<ApiStateProvinceRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/StateProvinces/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStateProvinceResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiStateProvinceResponseModel> GetStateProvinceByName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces/byName/{name}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStateProvinceResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiStateProvinceResponseModel> GetStateProvinceByStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces/byStateProvinceCodeCountryRegionCode/{stateProvinceCode}/{countryRegionCode}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStateProvinceResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiAddressResponseModel>> Addresses(int stateProvinceID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces/Addresses/{stateProvinceID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiAddressResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiBillOfMaterialsResponseModel> BillOfMaterialsCreateAsync(ApiBillOfMaterialsRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BillOfMaterials", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBillOfMaterialsResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiBillOfMaterialsResponseModel> BillOfMaterialsUpdateAsync(int id, ApiBillOfMaterialsRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/BillOfMaterials/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBillOfMaterialsResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task BillOfMaterialsDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/BillOfMaterials/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiBillOfMaterialsResponseModel> BillOfMaterialsGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BillOfMaterials/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBillOfMaterialsResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBillOfMaterialsResponseModel>> BillOfMaterialsAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BillOfMaterials?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBillOfMaterialsResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBillOfMaterialsResponseModel>> BillOfMaterialsBulkInsertAsync(List<ApiBillOfMaterialsRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BillOfMaterials/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBillOfMaterialsResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiBillOfMaterialsResponseModel> GetBillOfMaterialsByProductAssemblyIDComponentIDStartDate(int? productAssemblyID, int componentID, DateTime startDate)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BillOfMaterials/byProductAssemblyIDComponentIDStartDate/{productAssemblyID}/{componentID}/{startDate}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBillOfMaterialsResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBillOfMaterialsResponseModel>> GetBillOfMaterialsByUnitMeasureCode(string unitMeasureCode)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BillOfMaterials/byUnitMeasureCode/{unitMeasureCode}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBillOfMaterialsResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCultureResponseModel> CultureCreateAsync(ApiCultureRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Cultures", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCultureResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCultureResponseModel> CultureUpdateAsync(string id, ApiCultureRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Cultures/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCultureResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task CultureDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Cultures/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiCultureResponseModel> CultureGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cultures/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCultureResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCultureResponseModel>> CultureAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cultures?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCultureResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCultureResponseModel>> CultureBulkInsertAsync(List<ApiCultureRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Cultures/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCultureResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCultureResponseModel> GetCultureByName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cultures/byName/{name}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCultureResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultures(string cultureID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cultures/ProductModelProductDescriptionCultures/{cultureID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductModelProductDescriptionCultureResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDocumentResponseModel> DocumentCreateAsync(ApiDocumentRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Documents", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDocumentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDocumentResponseModel> DocumentUpdateAsync(Guid id, ApiDocumentRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Documents/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDocumentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task DocumentDeleteAsync(Guid id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Documents/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiDocumentResponseModel> DocumentGetAsync(Guid id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Documents/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDocumentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDocumentResponseModel>> DocumentAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Documents?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDocumentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDocumentResponseModel>> DocumentBulkInsertAsync(List<ApiDocumentRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Documents/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDocumentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDocumentResponseModel>> GetDocumentByFileNameRevision(string fileName, string revision)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Documents/byFileNameRevision/{fileName}/{revision}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDocumentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiIllustrationResponseModel> IllustrationCreateAsync(ApiIllustrationRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Illustrations", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiIllustrationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiIllustrationResponseModel> IllustrationUpdateAsync(int id, ApiIllustrationRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Illustrations/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiIllustrationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task IllustrationDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Illustrations/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiIllustrationResponseModel> IllustrationGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Illustrations/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiIllustrationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiIllustrationResponseModel>> IllustrationAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Illustrations?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiIllustrationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiIllustrationResponseModel>> IllustrationBulkInsertAsync(List<ApiIllustrationRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Illustrations/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiIllustrationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductModelIllustrationResponseModel>> ProductModelIllustrations(int illustrationID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Illustrations/ProductModelIllustrations/{illustrationID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductModelIllustrationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLocationResponseModel> LocationCreateAsync(ApiLocationRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Locations", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLocationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLocationResponseModel> LocationUpdateAsync(short id, ApiLocationRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Locations/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLocationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task LocationDeleteAsync(short id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Locations/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiLocationResponseModel> LocationGetAsync(short id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLocationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLocationResponseModel>> LocationAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLocationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLocationResponseModel>> LocationBulkInsertAsync(List<ApiLocationRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Locations/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLocationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLocationResponseModel> GetLocationByName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations/byName/{name}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLocationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductInventoryResponseModel>> ProductInventories(short locationID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations/ProductInventories/{locationID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductInventoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutings(short locationID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations/WorkOrderRoutings/{locationID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiWorkOrderRoutingResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductResponseModel> ProductCreateAsync(ApiProductRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Products", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductResponseModel> ProductUpdateAsync(int id, ApiProductRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Products/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProductDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Products/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProductResponseModel> ProductGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductResponseModel>> ProductAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductResponseModel>> ProductBulkInsertAsync(List<ApiProductRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Products/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductResponseModel> GetProductByName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/byName/{name}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductResponseModel> GetProductByProductNumber(string productNumber)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/byProductNumber/{productNumber}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBillOfMaterialsResponseModel>> BillOfMaterials(int componentID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/BillOfMaterials/{componentID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBillOfMaterialsResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductCostHistoryResponseModel>> ProductCostHistories(int productID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/ProductCostHistories/{productID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductCostHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductListPriceHistoryResponseModel>> ProductListPriceHistories(int productID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/ProductListPriceHistories/{productID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductListPriceHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductProductPhotoResponseModel>> ProductProductPhotoes(int productID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/ProductProductPhotoes/{productID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductReviewResponseModel>> ProductReviews(int productID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/ProductReviews/{productID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductReviewResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTransactionHistoryResponseModel>> TransactionHistories(int productID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/TransactionHistories/{productID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTransactionHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiWorkOrderResponseModel>> WorkOrders(int productID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/WorkOrders/{productID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiWorkOrderResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductCategoryResponseModel> ProductCategoryCreateAsync(ApiProductCategoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCategories", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductCategoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductCategoryResponseModel> ProductCategoryUpdateAsync(int id, ApiProductCategoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductCategories/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductCategoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProductCategoryDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductCategories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProductCategoryResponseModel> ProductCategoryGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCategories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductCategoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductCategoryResponseModel>> ProductCategoryAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCategories?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductCategoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductCategoryResponseModel>> ProductCategoryBulkInsertAsync(List<ApiProductCategoryRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCategories/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductCategoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductCategoryResponseModel> GetProductCategoryByName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCategories/byName/{name}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductCategoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductSubcategoryResponseModel>> ProductSubcategories(int productCategoryID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCategories/ProductSubcategories/{productCategoryID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductSubcategoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductCostHistoryResponseModel> ProductCostHistoryCreateAsync(ApiProductCostHistoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCostHistories", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductCostHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductCostHistoryResponseModel> ProductCostHistoryUpdateAsync(int id, ApiProductCostHistoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductCostHistories/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductCostHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProductCostHistoryDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductCostHistories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProductCostHistoryResponseModel> ProductCostHistoryGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCostHistories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductCostHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductCostHistoryResponseModel>> ProductCostHistoryAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCostHistories?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductCostHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductCostHistoryResponseModel>> ProductCostHistoryBulkInsertAsync(List<ApiProductCostHistoryRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCostHistories/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductCostHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductDescriptionResponseModel> ProductDescriptionCreateAsync(ApiProductDescriptionRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductDescriptions", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductDescriptionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductDescriptionResponseModel> ProductDescriptionUpdateAsync(int id, ApiProductDescriptionRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductDescriptions/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductDescriptionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProductDescriptionDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductDescriptions/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProductDescriptionResponseModel> ProductDescriptionGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDescriptions/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductDescriptionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductDescriptionResponseModel>> ProductDescriptionAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDescriptions?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductDescriptionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductDescriptionResponseModel>> ProductDescriptionBulkInsertAsync(List<ApiProductDescriptionRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductDescriptions/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductDescriptionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductInventoryResponseModel> ProductInventoryCreateAsync(ApiProductInventoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductInventories", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductInventoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductInventoryResponseModel> ProductInventoryUpdateAsync(int id, ApiProductInventoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductInventories/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductInventoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProductInventoryDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductInventories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProductInventoryResponseModel> ProductInventoryGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductInventories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductInventoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductInventoryResponseModel>> ProductInventoryAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductInventories?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductInventoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductInventoryResponseModel>> ProductInventoryBulkInsertAsync(List<ApiProductInventoryRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductInventories/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductInventoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductListPriceHistoryResponseModel> ProductListPriceHistoryCreateAsync(ApiProductListPriceHistoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductListPriceHistories", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductListPriceHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductListPriceHistoryResponseModel> ProductListPriceHistoryUpdateAsync(int id, ApiProductListPriceHistoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductListPriceHistories/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductListPriceHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProductListPriceHistoryDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductListPriceHistories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProductListPriceHistoryResponseModel> ProductListPriceHistoryGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductListPriceHistories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductListPriceHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductListPriceHistoryResponseModel>> ProductListPriceHistoryAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductListPriceHistories?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductListPriceHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductListPriceHistoryResponseModel>> ProductListPriceHistoryBulkInsertAsync(List<ApiProductListPriceHistoryRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductListPriceHistories/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductListPriceHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductModelResponseModel> ProductModelCreateAsync(ApiProductModelRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModels", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductModelResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductModelResponseModel> ProductModelUpdateAsync(int id, ApiProductModelRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductModels/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductModelResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProductModelDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductModels/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProductModelResponseModel> ProductModelGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductModelResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductModelResponseModel>> ProductModelAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductModelResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductModelResponseModel>> ProductModelBulkInsertAsync(List<ApiProductModelRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModels/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductModelResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductModelResponseModel> GetProductModelByName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/byName/{name}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductModelResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductModelResponseModel>> GetProductModelByCatalogDescription(string catalogDescription)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/byCatalogDescription/{catalogDescription}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductModelResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductModelResponseModel>> GetProductModelByInstructions(string instructions)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/byInstructions/{instructions}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductModelResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductResponseModel>> Products(int productModelID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/Products/{productModelID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductModelIllustrationResponseModel> ProductModelIllustrationCreateAsync(ApiProductModelIllustrationRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModelIllustrations", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductModelIllustrationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductModelIllustrationResponseModel> ProductModelIllustrationUpdateAsync(int id, ApiProductModelIllustrationRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductModelIllustrations/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductModelIllustrationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProductModelIllustrationDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductModelIllustrations/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProductModelIllustrationResponseModel> ProductModelIllustrationGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelIllustrations/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductModelIllustrationResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductModelIllustrationResponseModel>> ProductModelIllustrationAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelIllustrations?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductModelIllustrationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductModelIllustrationResponseModel>> ProductModelIllustrationBulkInsertAsync(List<ApiProductModelIllustrationRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModelIllustrations/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductModelIllustrationResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductModelProductDescriptionCultureResponseModel> ProductModelProductDescriptionCultureCreateAsync(ApiProductModelProductDescriptionCultureRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModelProductDescriptionCultures", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductModelProductDescriptionCultureResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductModelProductDescriptionCultureResponseModel> ProductModelProductDescriptionCultureUpdateAsync(int id, ApiProductModelProductDescriptionCultureRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductModelProductDescriptionCultures/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductModelProductDescriptionCultureResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProductModelProductDescriptionCultureDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductModelProductDescriptionCultures/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProductModelProductDescriptionCultureResponseModel> ProductModelProductDescriptionCultureGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelProductDescriptionCultures/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductModelProductDescriptionCultureResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultureAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelProductDescriptionCultures?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductModelProductDescriptionCultureResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultureBulkInsertAsync(List<ApiProductModelProductDescriptionCultureRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModelProductDescriptionCultures/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductModelProductDescriptionCultureResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductPhotoResponseModel> ProductPhotoCreateAsync(ApiProductPhotoRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductPhotoes", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductPhotoResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductPhotoResponseModel> ProductPhotoUpdateAsync(int id, ApiProductPhotoRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductPhotoes/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductPhotoResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProductPhotoDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductPhotoes/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProductPhotoResponseModel> ProductPhotoGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductPhotoes/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductPhotoResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductPhotoResponseModel>> ProductPhotoAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductPhotoes?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductPhotoResponseModel>> ProductPhotoBulkInsertAsync(List<ApiProductPhotoRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductPhotoes/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductProductPhotoResponseModel> ProductProductPhotoCreateAsync(ApiProductProductPhotoRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductProductPhotoes", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductProductPhotoResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductProductPhotoResponseModel> ProductProductPhotoUpdateAsync(int id, ApiProductProductPhotoRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductProductPhotoes/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductProductPhotoResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProductProductPhotoDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductProductPhotoes/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProductProductPhotoResponseModel> ProductProductPhotoGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductProductPhotoes/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductProductPhotoResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductProductPhotoResponseModel>> ProductProductPhotoAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductProductPhotoes?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductProductPhotoResponseModel>> ProductProductPhotoBulkInsertAsync(List<ApiProductProductPhotoRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductProductPhotoes/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductReviewResponseModel> ProductReviewCreateAsync(ApiProductReviewRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductReviews", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductReviewResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductReviewResponseModel> ProductReviewUpdateAsync(int id, ApiProductReviewRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductReviews/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductReviewResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProductReviewDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductReviews/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProductReviewResponseModel> ProductReviewGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductReviews/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductReviewResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductReviewResponseModel>> ProductReviewAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductReviews?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductReviewResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductReviewResponseModel>> ProductReviewBulkInsertAsync(List<ApiProductReviewRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductReviews/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductReviewResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductReviewResponseModel>> GetProductReviewByCommentsProductIDReviewerName(string comments, int productID, string reviewerName)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductReviews/byCommentsProductIDReviewerName/{comments}/{productID}/{reviewerName}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductReviewResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductSubcategoryResponseModel> ProductSubcategoryCreateAsync(ApiProductSubcategoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductSubcategories", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductSubcategoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductSubcategoryResponseModel> ProductSubcategoryUpdateAsync(int id, ApiProductSubcategoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductSubcategories/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductSubcategoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProductSubcategoryDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductSubcategories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProductSubcategoryResponseModel> ProductSubcategoryGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductSubcategories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductSubcategoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductSubcategoryResponseModel>> ProductSubcategoryAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductSubcategories?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductSubcategoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductSubcategoryResponseModel>> ProductSubcategoryBulkInsertAsync(List<ApiProductSubcategoryRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductSubcategories/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductSubcategoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductSubcategoryResponseModel> GetProductSubcategoryByName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductSubcategories/byName/{name}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductSubcategoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiScrapReasonResponseModel> ScrapReasonCreateAsync(ApiScrapReasonRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ScrapReasons", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiScrapReasonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiScrapReasonResponseModel> ScrapReasonUpdateAsync(short id, ApiScrapReasonRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ScrapReasons/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiScrapReasonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ScrapReasonDeleteAsync(short id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ScrapReasons/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiScrapReasonResponseModel> ScrapReasonGetAsync(short id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ScrapReasons/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiScrapReasonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiScrapReasonResponseModel>> ScrapReasonAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ScrapReasons?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiScrapReasonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiScrapReasonResponseModel>> ScrapReasonBulkInsertAsync(List<ApiScrapReasonRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ScrapReasons/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiScrapReasonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiScrapReasonResponseModel> GetScrapReasonByName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ScrapReasons/byName/{name}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiScrapReasonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTransactionHistoryResponseModel> TransactionHistoryCreateAsync(ApiTransactionHistoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistories", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTransactionHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTransactionHistoryResponseModel> TransactionHistoryUpdateAsync(int id, ApiTransactionHistoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TransactionHistories/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTransactionHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task TransactionHistoryDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TransactionHistories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiTransactionHistoryResponseModel> TransactionHistoryGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTransactionHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTransactionHistoryResponseModel>> TransactionHistoryAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTransactionHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTransactionHistoryResponseModel>> TransactionHistoryBulkInsertAsync(List<ApiTransactionHistoryRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistories/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTransactionHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTransactionHistoryResponseModel>> GetTransactionHistoryByProductID(int productID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories/byProductID/{productID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTransactionHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTransactionHistoryResponseModel>> GetTransactionHistoryByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories/byReferenceOrderIDReferenceOrderLineID/{referenceOrderID}/{referenceOrderLineID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTransactionHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTransactionHistoryArchiveResponseModel> TransactionHistoryArchiveCreateAsync(ApiTransactionHistoryArchiveRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistoryArchives", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTransactionHistoryArchiveResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTransactionHistoryArchiveResponseModel> TransactionHistoryArchiveUpdateAsync(int id, ApiTransactionHistoryArchiveRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TransactionHistoryArchives/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTransactionHistoryArchiveResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task TransactionHistoryArchiveDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TransactionHistoryArchives/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiTransactionHistoryArchiveResponseModel> TransactionHistoryArchiveGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTransactionHistoryArchiveResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTransactionHistoryArchiveResponseModel>> TransactionHistoryArchiveAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTransactionHistoryArchiveResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTransactionHistoryArchiveResponseModel>> TransactionHistoryArchiveBulkInsertAsync(List<ApiTransactionHistoryArchiveRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistoryArchives/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTransactionHistoryArchiveResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTransactionHistoryArchiveResponseModel>> GetTransactionHistoryArchiveByProductID(int productID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives/byProductID/{productID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTransactionHistoryArchiveResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTransactionHistoryArchiveResponseModel>> GetTransactionHistoryArchiveByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives/byReferenceOrderIDReferenceOrderLineID/{referenceOrderID}/{referenceOrderLineID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTransactionHistoryArchiveResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiUnitMeasureResponseModel> UnitMeasureCreateAsync(ApiUnitMeasureRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/UnitMeasures", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiUnitMeasureResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiUnitMeasureResponseModel> UnitMeasureUpdateAsync(string id, ApiUnitMeasureRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/UnitMeasures/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiUnitMeasureResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task UnitMeasureDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/UnitMeasures/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiUnitMeasureResponseModel> UnitMeasureGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UnitMeasures/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiUnitMeasureResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiUnitMeasureResponseModel>> UnitMeasureAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UnitMeasures?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiUnitMeasureResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiUnitMeasureResponseModel>> UnitMeasureBulkInsertAsync(List<ApiUnitMeasureRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/UnitMeasures/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiUnitMeasureResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiUnitMeasureResponseModel> GetUnitMeasureByName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UnitMeasures/byName/{name}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiUnitMeasureResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiWorkOrderResponseModel> WorkOrderCreateAsync(ApiWorkOrderRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrders", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiWorkOrderResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiWorkOrderResponseModel> WorkOrderUpdateAsync(int id, ApiWorkOrderRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/WorkOrders/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiWorkOrderResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task WorkOrderDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/WorkOrders/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiWorkOrderResponseModel> WorkOrderGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiWorkOrderResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiWorkOrderResponseModel>> WorkOrderAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiWorkOrderResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiWorkOrderResponseModel>> WorkOrderBulkInsertAsync(List<ApiWorkOrderRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrders/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiWorkOrderResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiWorkOrderResponseModel>> GetWorkOrderByProductID(int productID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders/byProductID/{productID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiWorkOrderResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiWorkOrderResponseModel>> GetWorkOrderByScrapReasonID(short? scrapReasonID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders/byScrapReasonID/{scrapReasonID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiWorkOrderResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiWorkOrderRoutingResponseModel> WorkOrderRoutingCreateAsync(ApiWorkOrderRoutingRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrderRoutings", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiWorkOrderRoutingResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiWorkOrderRoutingResponseModel> WorkOrderRoutingUpdateAsync(int id, ApiWorkOrderRoutingRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/WorkOrderRoutings/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiWorkOrderRoutingResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task WorkOrderRoutingDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/WorkOrderRoutings/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiWorkOrderRoutingResponseModel> WorkOrderRoutingGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrderRoutings/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiWorkOrderRoutingResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutingAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrderRoutings?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiWorkOrderRoutingResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutingBulkInsertAsync(List<ApiWorkOrderRoutingRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrderRoutings/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiWorkOrderRoutingResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiWorkOrderRoutingResponseModel>> GetWorkOrderRoutingByProductID(int productID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrderRoutings/byProductID/{productID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiWorkOrderRoutingResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductVendorResponseModel> ProductVendorCreateAsync(ApiProductVendorRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductVendors", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductVendorResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiProductVendorResponseModel> ProductVendorUpdateAsync(int id, ApiProductVendorRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductVendors/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductVendorResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ProductVendorDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductVendors/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiProductVendorResponseModel> ProductVendorGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiProductVendorResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductVendorResponseModel>> ProductVendorAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductVendorResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductVendorResponseModel>> ProductVendorBulkInsertAsync(List<ApiProductVendorRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductVendors/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductVendorResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductVendorResponseModel>> GetProductVendorByBusinessEntityID(int businessEntityID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors/byBusinessEntityID/{businessEntityID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductVendorResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductVendorResponseModel>> GetProductVendorByUnitMeasureCode(string unitMeasureCode)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors/byUnitMeasureCode/{unitMeasureCode}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductVendorResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPurchaseOrderDetailResponseModel> PurchaseOrderDetailCreateAsync(ApiPurchaseOrderDetailRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderDetails", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPurchaseOrderDetailResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPurchaseOrderDetailResponseModel> PurchaseOrderDetailUpdateAsync(int id, ApiPurchaseOrderDetailRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PurchaseOrderDetails/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPurchaseOrderDetailResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task PurchaseOrderDetailDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PurchaseOrderDetails/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiPurchaseOrderDetailResponseModel> PurchaseOrderDetailGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderDetails/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPurchaseOrderDetailResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPurchaseOrderDetailResponseModel>> PurchaseOrderDetailAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderDetails?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPurchaseOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPurchaseOrderDetailResponseModel>> PurchaseOrderDetailBulkInsertAsync(List<ApiPurchaseOrderDetailRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderDetails/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPurchaseOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPurchaseOrderDetailResponseModel>> GetPurchaseOrderDetailByProductID(int productID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderDetails/byProductID/{productID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPurchaseOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPurchaseOrderHeaderResponseModel> PurchaseOrderHeaderCreateAsync(ApiPurchaseOrderHeaderRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderHeaders", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPurchaseOrderHeaderResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPurchaseOrderHeaderResponseModel> PurchaseOrderHeaderUpdateAsync(int id, ApiPurchaseOrderHeaderRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PurchaseOrderHeaders/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPurchaseOrderHeaderResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task PurchaseOrderHeaderDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PurchaseOrderHeaders/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiPurchaseOrderHeaderResponseModel> PurchaseOrderHeaderGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPurchaseOrderHeaderResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeaderAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPurchaseOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeaderBulkInsertAsync(List<ApiPurchaseOrderHeaderRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderHeaders/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPurchaseOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> GetPurchaseOrderHeaderByEmployeeID(int employeeID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders/byEmployeeID/{employeeID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPurchaseOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> GetPurchaseOrderHeaderByVendorID(int vendorID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders/byVendorID/{vendorID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPurchaseOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPurchaseOrderDetailResponseModel>> PurchaseOrderDetails(int purchaseOrderID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders/PurchaseOrderDetails/{purchaseOrderID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPurchaseOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiShipMethodResponseModel> ShipMethodCreateAsync(ApiShipMethodRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShipMethods", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiShipMethodResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiShipMethodResponseModel> ShipMethodUpdateAsync(int id, ApiShipMethodRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ShipMethods/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiShipMethodResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ShipMethodDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ShipMethods/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiShipMethodResponseModel> ShipMethodGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShipMethods/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiShipMethodResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiShipMethodResponseModel>> ShipMethodAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShipMethods?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiShipMethodResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiShipMethodResponseModel>> ShipMethodBulkInsertAsync(List<ApiShipMethodRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShipMethods/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiShipMethodResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiShipMethodResponseModel> GetShipMethodByName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShipMethods/byName/{name}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiShipMethodResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeaders(int shipMethodID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShipMethods/PurchaseOrderHeaders/{shipMethodID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPurchaseOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiVendorResponseModel> VendorCreateAsync(ApiVendorRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Vendors", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiVendorResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiVendorResponseModel> VendorUpdateAsync(int id, ApiVendorRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Vendors/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiVendorResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task VendorDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Vendors/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiVendorResponseModel> VendorGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Vendors/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiVendorResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiVendorResponseModel>> VendorAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Vendors?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiVendorResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiVendorResponseModel>> VendorBulkInsertAsync(List<ApiVendorRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Vendors/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiVendorResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiVendorResponseModel> GetVendorByAccountNumber(string accountNumber)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Vendors/byAccountNumber/{accountNumber}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiVendorResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiProductVendorResponseModel>> ProductVendors(int businessEntityID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Vendors/ProductVendors/{businessEntityID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiProductVendorResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCountryRegionCurrencyResponseModel> CountryRegionCurrencyCreateAsync(ApiCountryRegionCurrencyRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRegionCurrencies", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCountryRegionCurrencyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCountryRegionCurrencyResponseModel> CountryRegionCurrencyUpdateAsync(string id, ApiCountryRegionCurrencyRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CountryRegionCurrencies/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCountryRegionCurrencyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task CountryRegionCurrencyDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CountryRegionCurrencies/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiCountryRegionCurrencyResponseModel> CountryRegionCurrencyGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegionCurrencies/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCountryRegionCurrencyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCountryRegionCurrencyResponseModel>> CountryRegionCurrencyAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegionCurrencies?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCountryRegionCurrencyResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCountryRegionCurrencyResponseModel>> CountryRegionCurrencyBulkInsertAsync(List<ApiCountryRegionCurrencyRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRegionCurrencies/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCountryRegionCurrencyResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCountryRegionCurrencyResponseModel>> GetCountryRegionCurrencyByCurrencyCode(string currencyCode)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegionCurrencies/byCurrencyCode/{currencyCode}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCountryRegionCurrencyResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCreditCardResponseModel> CreditCardCreateAsync(ApiCreditCardRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CreditCards", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCreditCardResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCreditCardResponseModel> CreditCardUpdateAsync(int id, ApiCreditCardRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CreditCards/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCreditCardResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task CreditCardDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CreditCards/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiCreditCardResponseModel> CreditCardGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CreditCards/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCreditCardResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCreditCardResponseModel>> CreditCardAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CreditCards?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCreditCardResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCreditCardResponseModel>> CreditCardBulkInsertAsync(List<ApiCreditCardRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CreditCards/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCreditCardResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCreditCardResponseModel> GetCreditCardByCardNumber(string cardNumber)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CreditCards/byCardNumber/{cardNumber}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCreditCardResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPersonCreditCardResponseModel>> PersonCreditCards(int creditCardID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CreditCards/PersonCreditCards/{creditCardID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPersonCreditCardResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int creditCardID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CreditCards/SalesOrderHeaders/{creditCardID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCurrencyResponseModel> CurrencyCreateAsync(ApiCurrencyRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Currencies", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCurrencyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCurrencyResponseModel> CurrencyUpdateAsync(string id, ApiCurrencyRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Currencies/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCurrencyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task CurrencyDeleteAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Currencies/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiCurrencyResponseModel> CurrencyGetAsync(string id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCurrencyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCurrencyResponseModel>> CurrencyAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCurrencyResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCurrencyResponseModel>> CurrencyBulkInsertAsync(List<ApiCurrencyRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Currencies/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCurrencyResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCurrencyResponseModel> GetCurrencyByName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies/byName/{name}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCurrencyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCountryRegionCurrencyResponseModel>> CountryRegionCurrencies(string currencyCode)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies/CountryRegionCurrencies/{currencyCode}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCountryRegionCurrencyResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCurrencyRateResponseModel>> CurrencyRates(string fromCurrencyCode)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies/CurrencyRates/{fromCurrencyCode}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCurrencyRateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCurrencyRateResponseModel> CurrencyRateCreateAsync(ApiCurrencyRateRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CurrencyRates", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCurrencyRateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCurrencyRateResponseModel> CurrencyRateUpdateAsync(int id, ApiCurrencyRateRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CurrencyRates/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCurrencyRateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task CurrencyRateDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CurrencyRates/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiCurrencyRateResponseModel> CurrencyRateGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CurrencyRates/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCurrencyRateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCurrencyRateResponseModel>> CurrencyRateAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CurrencyRates?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCurrencyRateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCurrencyRateResponseModel>> CurrencyRateBulkInsertAsync(List<ApiCurrencyRateRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CurrencyRates/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCurrencyRateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCurrencyRateResponseModel> GetCurrencyRateByCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CurrencyRates/byCurrencyRateDateFromCurrencyCodeToCurrencyCode/{currencyRateDate}/{fromCurrencyCode}/{toCurrencyCode}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCurrencyRateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCustomerResponseModel> CustomerCreateAsync(ApiCustomerRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Customers", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCustomerResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCustomerResponseModel> CustomerUpdateAsync(int id, ApiCustomerRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Customers/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCustomerResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task CustomerDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Customers/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiCustomerResponseModel> CustomerGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCustomerResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCustomerResponseModel>> CustomerAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCustomerResponseModel>> CustomerBulkInsertAsync(List<ApiCustomerRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Customers/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiCustomerResponseModel> GetCustomerByAccountNumber(string accountNumber)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers/byAccountNumber/{accountNumber}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiCustomerResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCustomerResponseModel>> GetCustomerByTerritoryID(int? territoryID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers/byTerritoryID/{territoryID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPersonCreditCardResponseModel> PersonCreditCardCreateAsync(ApiPersonCreditCardRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonCreditCards", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPersonCreditCardResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiPersonCreditCardResponseModel> PersonCreditCardUpdateAsync(int id, ApiPersonCreditCardRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PersonCreditCards/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPersonCreditCardResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task PersonCreditCardDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PersonCreditCards/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiPersonCreditCardResponseModel> PersonCreditCardGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonCreditCards/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiPersonCreditCardResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPersonCreditCardResponseModel>> PersonCreditCardAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonCreditCards?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPersonCreditCardResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiPersonCreditCardResponseModel>> PersonCreditCardBulkInsertAsync(List<ApiPersonCreditCardRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonCreditCards/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiPersonCreditCardResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesOrderDetailResponseModel> SalesOrderDetailCreateAsync(ApiSalesOrderDetailRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderDetails", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesOrderDetailResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesOrderDetailResponseModel> SalesOrderDetailUpdateAsync(int id, ApiSalesOrderDetailRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesOrderDetails/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesOrderDetailResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SalesOrderDetailDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesOrderDetails/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSalesOrderDetailResponseModel> SalesOrderDetailGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderDetails/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesOrderDetailResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesOrderDetailResponseModel>> SalesOrderDetailAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderDetails?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesOrderDetailResponseModel>> SalesOrderDetailBulkInsertAsync(List<ApiSalesOrderDetailRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderDetails/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesOrderDetailResponseModel>> GetSalesOrderDetailByProductID(int productID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderDetails/byProductID/{productID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesOrderHeaderResponseModel> SalesOrderHeaderCreateAsync(ApiSalesOrderHeaderRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderHeaders", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesOrderHeaderResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesOrderHeaderResponseModel> SalesOrderHeaderUpdateAsync(int id, ApiSalesOrderHeaderRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesOrderHeaders/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesOrderHeaderResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SalesOrderHeaderDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesOrderHeaders/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSalesOrderHeaderResponseModel> SalesOrderHeaderGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesOrderHeaderResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaderAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaderBulkInsertAsync(List<ApiSalesOrderHeaderRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderHeaders/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesOrderHeaderResponseModel> GetSalesOrderHeaderBySalesOrderNumber(string salesOrderNumber)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/bySalesOrderNumber/{salesOrderNumber}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesOrderHeaderResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> GetSalesOrderHeaderByCustomerID(int customerID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/byCustomerID/{customerID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> GetSalesOrderHeaderBySalesPersonID(int? salesPersonID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/bySalesPersonID/{salesPersonID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesOrderDetailResponseModel>> SalesOrderDetails(int salesOrderID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/SalesOrderDetails/{salesOrderID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> SalesOrderHeaderSalesReasons(int salesOrderID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/SalesOrderHeaderSalesReasons/{salesOrderID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderSalesReasonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesOrderHeaderSalesReasonResponseModel> SalesOrderHeaderSalesReasonCreateAsync(ApiSalesOrderHeaderSalesReasonRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderHeaderSalesReasons", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesOrderHeaderSalesReasonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesOrderHeaderSalesReasonResponseModel> SalesOrderHeaderSalesReasonUpdateAsync(int id, ApiSalesOrderHeaderSalesReasonRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesOrderHeaderSalesReasons/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesOrderHeaderSalesReasonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SalesOrderHeaderSalesReasonDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesOrderHeaderSalesReasons/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSalesOrderHeaderSalesReasonResponseModel> SalesOrderHeaderSalesReasonGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaderSalesReasons/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesOrderHeaderSalesReasonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> SalesOrderHeaderSalesReasonAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaderSalesReasons?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderSalesReasonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> SalesOrderHeaderSalesReasonBulkInsertAsync(List<ApiSalesOrderHeaderSalesReasonRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderHeaderSalesReasons/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderSalesReasonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesPersonResponseModel> SalesPersonCreateAsync(ApiSalesPersonRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersons", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesPersonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesPersonResponseModel> SalesPersonUpdateAsync(int id, ApiSalesPersonRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesPersons/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesPersonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SalesPersonDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesPersons/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSalesPersonResponseModel> SalesPersonGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersons/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesPersonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesPersonResponseModel>> SalesPersonAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersons?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesPersonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesPersonResponseModel>> SalesPersonBulkInsertAsync(List<ApiSalesPersonRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersons/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesPersonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesPersonQuotaHistoryResponseModel>> SalesPersonQuotaHistories(int businessEntityID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersons/SalesPersonQuotaHistories/{businessEntityID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesPersonQuotaHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistories(int businessEntityID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersons/SalesTerritoryHistories/{businessEntityID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesTerritoryHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStoreResponseModel>> Stores(int salesPersonID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersons/Stores/{salesPersonID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStoreResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesPersonQuotaHistoryResponseModel> SalesPersonQuotaHistoryCreateAsync(ApiSalesPersonQuotaHistoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersonQuotaHistories", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesPersonQuotaHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesPersonQuotaHistoryResponseModel> SalesPersonQuotaHistoryUpdateAsync(int id, ApiSalesPersonQuotaHistoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesPersonQuotaHistories/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesPersonQuotaHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SalesPersonQuotaHistoryDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesPersonQuotaHistories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSalesPersonQuotaHistoryResponseModel> SalesPersonQuotaHistoryGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersonQuotaHistories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesPersonQuotaHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesPersonQuotaHistoryResponseModel>> SalesPersonQuotaHistoryAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersonQuotaHistories?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesPersonQuotaHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesPersonQuotaHistoryResponseModel>> SalesPersonQuotaHistoryBulkInsertAsync(List<ApiSalesPersonQuotaHistoryRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersonQuotaHistories/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesPersonQuotaHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesReasonResponseModel> SalesReasonCreateAsync(ApiSalesReasonRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesReasons", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesReasonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesReasonResponseModel> SalesReasonUpdateAsync(int id, ApiSalesReasonRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesReasons/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesReasonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SalesReasonDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesReasons/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSalesReasonResponseModel> SalesReasonGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesReasons/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesReasonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesReasonResponseModel>> SalesReasonAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesReasons?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesReasonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesReasonResponseModel>> SalesReasonBulkInsertAsync(List<ApiSalesReasonRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesReasons/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesReasonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesTaxRateResponseModel> SalesTaxRateCreateAsync(ApiSalesTaxRateRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTaxRates", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesTaxRateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesTaxRateResponseModel> SalesTaxRateUpdateAsync(int id, ApiSalesTaxRateRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesTaxRates/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesTaxRateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SalesTaxRateDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesTaxRates/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSalesTaxRateResponseModel> SalesTaxRateGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTaxRates/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesTaxRateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesTaxRateResponseModel>> SalesTaxRateAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTaxRates?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesTaxRateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesTaxRateResponseModel>> SalesTaxRateBulkInsertAsync(List<ApiSalesTaxRateRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTaxRates/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesTaxRateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesTaxRateResponseModel> GetSalesTaxRateByStateProvinceIDTaxType(int stateProvinceID, int taxType)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTaxRates/byStateProvinceIDTaxType/{stateProvinceID}/{taxType}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesTaxRateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesTerritoryResponseModel> SalesTerritoryCreateAsync(ApiSalesTerritoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritories", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesTerritoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesTerritoryResponseModel> SalesTerritoryUpdateAsync(int id, ApiSalesTerritoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesTerritories/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesTerritoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SalesTerritoryDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesTerritories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSalesTerritoryResponseModel> SalesTerritoryGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesTerritoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesTerritoryResponseModel>> SalesTerritoryAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesTerritoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesTerritoryResponseModel>> SalesTerritoryBulkInsertAsync(List<ApiSalesTerritoryRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritories/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesTerritoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesTerritoryResponseModel> GetSalesTerritoryByName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories/byName/{name}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesTerritoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiCustomerResponseModel>> Customers(int territoryID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories/Customers/{territoryID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesPersonResponseModel>> SalesPersons(int territoryID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories/SalesPersons/{territoryID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesPersonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesTerritoryHistoryResponseModel> SalesTerritoryHistoryCreateAsync(ApiSalesTerritoryHistoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritoryHistories", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesTerritoryHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSalesTerritoryHistoryResponseModel> SalesTerritoryHistoryUpdateAsync(int id, ApiSalesTerritoryHistoryRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesTerritoryHistories/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesTerritoryHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SalesTerritoryHistoryDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesTerritoryHistories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSalesTerritoryHistoryResponseModel> SalesTerritoryHistoryGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritoryHistories/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSalesTerritoryHistoryResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistoryAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritoryHistories?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesTerritoryHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistoryBulkInsertAsync(List<ApiSalesTerritoryHistoryRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritoryHistories/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSalesTerritoryHistoryResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiShoppingCartItemResponseModel> ShoppingCartItemCreateAsync(ApiShoppingCartItemRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShoppingCartItems", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiShoppingCartItemResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiShoppingCartItemResponseModel> ShoppingCartItemUpdateAsync(int id, ApiShoppingCartItemRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ShoppingCartItems/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiShoppingCartItemResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task ShoppingCartItemDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ShoppingCartItems/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiShoppingCartItemResponseModel> ShoppingCartItemGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShoppingCartItems/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiShoppingCartItemResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiShoppingCartItemResponseModel>> ShoppingCartItemAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShoppingCartItems?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiShoppingCartItemResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiShoppingCartItemResponseModel>> ShoppingCartItemBulkInsertAsync(List<ApiShoppingCartItemRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShoppingCartItems/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiShoppingCartItemResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiShoppingCartItemResponseModel>> GetShoppingCartItemByShoppingCartIDProductID(string shoppingCartID, int productID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShoppingCartItems/byShoppingCartIDProductID/{shoppingCartID}/{productID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiShoppingCartItemResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSpecialOfferResponseModel> SpecialOfferCreateAsync(ApiSpecialOfferRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOffers", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSpecialOfferResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSpecialOfferResponseModel> SpecialOfferUpdateAsync(int id, ApiSpecialOfferRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SpecialOffers/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSpecialOfferResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SpecialOfferDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SpecialOffers/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSpecialOfferResponseModel> SpecialOfferGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOffers/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSpecialOfferResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSpecialOfferResponseModel>> SpecialOfferAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOffers?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSpecialOfferResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSpecialOfferResponseModel>> SpecialOfferBulkInsertAsync(List<ApiSpecialOfferRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOffers/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSpecialOfferResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSpecialOfferProductResponseModel>> SpecialOfferProducts(int specialOfferID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOffers/SpecialOfferProducts/{specialOfferID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSpecialOfferProductResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSpecialOfferProductResponseModel> SpecialOfferProductCreateAsync(ApiSpecialOfferProductRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOfferProducts", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSpecialOfferProductResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSpecialOfferProductResponseModel> SpecialOfferProductUpdateAsync(int id, ApiSpecialOfferProductRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SpecialOfferProducts/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSpecialOfferProductResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SpecialOfferProductDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SpecialOfferProducts/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSpecialOfferProductResponseModel> SpecialOfferProductGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOfferProducts/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSpecialOfferProductResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSpecialOfferProductResponseModel>> SpecialOfferProductAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOfferProducts?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSpecialOfferProductResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSpecialOfferProductResponseModel>> SpecialOfferProductBulkInsertAsync(List<ApiSpecialOfferProductRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOfferProducts/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSpecialOfferProductResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSpecialOfferProductResponseModel>> GetSpecialOfferProductByProductID(int productID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOfferProducts/byProductID/{productID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSpecialOfferProductResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiStoreResponseModel> StoreCreateAsync(ApiStoreRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Stores", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStoreResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiStoreResponseModel> StoreUpdateAsync(int id, ApiStoreRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Stores/{id}", item).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStoreResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task StoreDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Stores/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiStoreResponseModel> StoreGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores/{id}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStoreResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStoreResponseModel>> StoreAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores?limit={limit}&offset={offset}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStoreResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStoreResponseModel>> StoreBulkInsertAsync(List<ApiStoreRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Stores/BulkInsert", items).ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStoreResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStoreResponseModel>> GetStoreBySalesPersonID(int? salesPersonID)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores/bySalesPersonID/{salesPersonID}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStoreResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStoreResponseModel>> GetStoreByDemographics(string demographics)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores/byDemographics/{demographics}").ConfigureAwait(false);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStoreResponseModel>>(httpResponse.Content.ContentToString());
                }
        }
}

/*<Codenesium>
    <Hash>19ba33d3710e19707b8d183bcedcc816</Hash>
</Codenesium>*/