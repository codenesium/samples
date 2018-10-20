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

		public virtual async Task<List<ApiAWBuildVersionResponseModel>> AWBuildVersionBulkInsertAsync(List<ApiAWBuildVersionRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AWBuildVersions/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAWBuildVersionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiAWBuildVersionResponseModel>> AWBuildVersionCreateAsync(ApiAWBuildVersionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AWBuildVersions", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiAWBuildVersionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiAWBuildVersionResponseModel>> AWBuildVersionUpdateAsync(int id, ApiAWBuildVersionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/AWBuildVersions/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiAWBuildVersionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> AWBuildVersionDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/AWBuildVersions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAWBuildVersionResponseModel> AWBuildVersionGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AWBuildVersions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiAWBuildVersionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAWBuildVersionResponseModel>> AWBuildVersionAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AWBuildVersions?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAWBuildVersionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDatabaseLogResponseModel>> DatabaseLogBulkInsertAsync(List<ApiDatabaseLogRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DatabaseLogs/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDatabaseLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiDatabaseLogResponseModel>> DatabaseLogCreateAsync(ApiDatabaseLogRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DatabaseLogs", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiDatabaseLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiDatabaseLogResponseModel>> DatabaseLogUpdateAsync(int id, ApiDatabaseLogRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/DatabaseLogs/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiDatabaseLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> DatabaseLogDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/DatabaseLogs/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDatabaseLogResponseModel> DatabaseLogGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DatabaseLogs/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiDatabaseLogResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDatabaseLogResponseModel>> DatabaseLogAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DatabaseLogs?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDatabaseLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiErrorLogResponseModel>> ErrorLogBulkInsertAsync(List<ApiErrorLogRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ErrorLogs/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiErrorLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiErrorLogResponseModel>> ErrorLogCreateAsync(ApiErrorLogRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ErrorLogs", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiErrorLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiErrorLogResponseModel>> ErrorLogUpdateAsync(int id, ApiErrorLogRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ErrorLogs/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiErrorLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ErrorLogDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ErrorLogs/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiErrorLogResponseModel> ErrorLogGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ErrorLogs/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiErrorLogResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiErrorLogResponseModel>> ErrorLogAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ErrorLogs?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiErrorLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDepartmentResponseModel>> DepartmentBulkInsertAsync(List<ApiDepartmentRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Departments/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDepartmentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiDepartmentResponseModel>> DepartmentCreateAsync(ApiDepartmentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Departments", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiDepartmentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiDepartmentResponseModel>> DepartmentUpdateAsync(short id, ApiDepartmentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Departments/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiDepartmentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> DepartmentDeleteAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Departments/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDepartmentResponseModel> DepartmentGetAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Departments/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiDepartmentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDepartmentResponseModel>> DepartmentAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Departments?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDepartmentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDepartmentResponseModel> ByDepartmentByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Departments/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiDepartmentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistoriesByDepartmentID(short departmentID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Departments/EmployeeDepartmentHistoriesByDepartmentID/{departmentID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEmployeeDepartmentHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeResponseModel>> EmployeeBulkInsertAsync(List<ApiEmployeeRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Employees/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEmployeeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiEmployeeResponseModel>> EmployeeCreateAsync(ApiEmployeeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Employees", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiEmployeeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiEmployeeResponseModel>> EmployeeUpdateAsync(int id, ApiEmployeeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Employees/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiEmployeeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> EmployeeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Employees/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmployeeResponseModel> EmployeeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiEmployeeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeResponseModel>> EmployeeAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEmployeeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmployeeResponseModel> ByEmployeeByLoginID(string loginID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/byLoginID/{loginID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiEmployeeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmployeeResponseModel> ByEmployeeByNationalIDNumber(string nationalIDNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/byNationalIDNumber/{nationalIDNumber}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiEmployeeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistoriesByBusinessEntityID(int businessEntityID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/EmployeeDepartmentHistoriesByBusinessEntityID/{businessEntityID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEmployeeDepartmentHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeePayHistoryResponseModel>> EmployeePayHistoriesByBusinessEntityID(int businessEntityID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/EmployeePayHistoriesByBusinessEntityID/{businessEntityID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEmployeePayHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiJobCandidateResponseModel>> JobCandidatesByBusinessEntityID(int businessEntityID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/JobCandidatesByBusinessEntityID/{businessEntityID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiJobCandidateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistoryBulkInsertAsync(List<ApiEmployeeDepartmentHistoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeeDepartmentHistories/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEmployeeDepartmentHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistoryCreateAsync(ApiEmployeeDepartmentHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeeDepartmentHistories", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistoryUpdateAsync(int id, ApiEmployeeDepartmentHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/EmployeeDepartmentHistories/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> EmployeeDepartmentHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/EmployeeDepartmentHistories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmployeeDepartmentHistoryResponseModel> EmployeeDepartmentHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiEmployeeDepartmentHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistoryAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEmployeeDepartmentHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> ByEmployeeDepartmentHistoryByDepartmentID(short departmentID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories/byDepartmentID/{departmentID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEmployeeDepartmentHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> ByEmployeeDepartmentHistoryByShiftID(int shiftID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories/byShiftID/{shiftID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEmployeeDepartmentHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeePayHistoryResponseModel>> EmployeePayHistoryBulkInsertAsync(List<ApiEmployeePayHistoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeePayHistories/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEmployeePayHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiEmployeePayHistoryResponseModel>> EmployeePayHistoryCreateAsync(ApiEmployeePayHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeePayHistories", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiEmployeePayHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiEmployeePayHistoryResponseModel>> EmployeePayHistoryUpdateAsync(int id, ApiEmployeePayHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/EmployeePayHistories/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiEmployeePayHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> EmployeePayHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/EmployeePayHistories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmployeePayHistoryResponseModel> EmployeePayHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeePayHistories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiEmployeePayHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeePayHistoryResponseModel>> EmployeePayHistoryAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeePayHistories?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEmployeePayHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiJobCandidateResponseModel>> JobCandidateBulkInsertAsync(List<ApiJobCandidateRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/JobCandidates/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiJobCandidateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiJobCandidateResponseModel>> JobCandidateCreateAsync(ApiJobCandidateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/JobCandidates", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiJobCandidateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiJobCandidateResponseModel>> JobCandidateUpdateAsync(int id, ApiJobCandidateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/JobCandidates/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiJobCandidateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> JobCandidateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/JobCandidates/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiJobCandidateResponseModel> JobCandidateGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/JobCandidates/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiJobCandidateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiJobCandidateResponseModel>> JobCandidateAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/JobCandidates?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiJobCandidateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiJobCandidateResponseModel>> ByJobCandidateByBusinessEntityID(int? businessEntityID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/JobCandidates/byBusinessEntityID/{businessEntityID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiJobCandidateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiShiftResponseModel>> ShiftBulkInsertAsync(List<ApiShiftRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Shifts/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiShiftResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiShiftResponseModel>> ShiftCreateAsync(ApiShiftRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Shifts", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiShiftResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiShiftResponseModel>> ShiftUpdateAsync(int id, ApiShiftRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Shifts/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiShiftResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ShiftDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Shifts/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiShiftResponseModel> ShiftGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiShiftResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiShiftResponseModel>> ShiftAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiShiftResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiShiftResponseModel> ByShiftByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiShiftResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiShiftResponseModel> ByShiftByStartTimeEndTime(TimeSpan startTime, TimeSpan endTime)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts/byStartTimeEndTime/{startTime}/{endTime}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiShiftResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistoriesByShiftID(int shiftID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts/EmployeeDepartmentHistoriesByShiftID/{shiftID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEmployeeDepartmentHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAddressResponseModel>> AddressBulkInsertAsync(List<ApiAddressRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Addresses/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiAddressResponseModel>> AddressCreateAsync(ApiAddressRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Addresses", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiAddressResponseModel>> AddressUpdateAsync(int id, ApiAddressRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Addresses/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> AddressDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Addresses/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAddressResponseModel> AddressGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiAddressResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAddressResponseModel>> AddressAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAddressResponseModel> ByAddressByAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1, string addressLine2, string city, int stateProvinceID, string postalCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses/byAddressLine1AddressLine2CityStateProvinceIDPostalCode/{addressLine1}/{addressLine2}/{city}/{stateProvinceID}/{postalCode}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiAddressResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAddressResponseModel>> ByAddressByStateProvinceID(int stateProvinceID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses/byStateProvinceID/{stateProvinceID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddressesByAddressID(int addressID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses/BusinessEntityAddressesByAddressID/{addressID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBusinessEntityAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAddressTypeResponseModel>> AddressTypeBulkInsertAsync(List<ApiAddressTypeRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AddressTypes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAddressTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiAddressTypeResponseModel>> AddressTypeCreateAsync(ApiAddressTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AddressTypes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiAddressTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiAddressTypeResponseModel>> AddressTypeUpdateAsync(int id, ApiAddressTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/AddressTypes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiAddressTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> AddressTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/AddressTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAddressTypeResponseModel> AddressTypeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AddressTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiAddressTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAddressTypeResponseModel>> AddressTypeAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AddressTypes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAddressTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAddressTypeResponseModel> ByAddressTypeByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AddressTypes/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiAddressTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddressesByAddressTypeID(int addressTypeID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AddressTypes/BusinessEntityAddressesByAddressTypeID/{addressTypeID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBusinessEntityAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityResponseModel>> BusinessEntityBulkInsertAsync(List<ApiBusinessEntityRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntities/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBusinessEntityResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiBusinessEntityResponseModel>> BusinessEntityCreateAsync(ApiBusinessEntityRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntities", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiBusinessEntityResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiBusinessEntityResponseModel>> BusinessEntityUpdateAsync(int id, ApiBusinessEntityRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/BusinessEntities/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiBusinessEntityResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> BusinessEntityDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/BusinessEntities/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBusinessEntityResponseModel> BusinessEntityGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntities/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiBusinessEntityResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityResponseModel>> BusinessEntityAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntities?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBusinessEntityResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddressesByBusinessEntityID(int businessEntityID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntities/BusinessEntityAddressesByBusinessEntityID/{businessEntityID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBusinessEntityAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContactsByBusinessEntityID(int businessEntityID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntities/BusinessEntityContactsByBusinessEntityID/{businessEntityID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBusinessEntityContactResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonResponseModel>> PeopleByBusinessEntityID(int businessEntityID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntities/PeopleByBusinessEntityID/{businessEntityID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddressBulkInsertAsync(List<ApiBusinessEntityAddressRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityAddresses/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBusinessEntityAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddressCreateAsync(ApiBusinessEntityAddressRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityAddresses", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiBusinessEntityAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddressUpdateAsync(int id, ApiBusinessEntityAddressRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/BusinessEntityAddresses/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiBusinessEntityAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> BusinessEntityAddressDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/BusinessEntityAddresses/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBusinessEntityAddressResponseModel> BusinessEntityAddressGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiBusinessEntityAddressResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddressAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBusinessEntityAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> ByBusinessEntityAddressByAddressID(int addressID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses/byAddressID/{addressID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBusinessEntityAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> ByBusinessEntityAddressByAddressTypeID(int addressTypeID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses/byAddressTypeID/{addressTypeID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBusinessEntityAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContactBulkInsertAsync(List<ApiBusinessEntityContactRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityContacts/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBusinessEntityContactResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiBusinessEntityContactResponseModel>> BusinessEntityContactCreateAsync(ApiBusinessEntityContactRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityContacts", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiBusinessEntityContactResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiBusinessEntityContactResponseModel>> BusinessEntityContactUpdateAsync(int id, ApiBusinessEntityContactRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/BusinessEntityContacts/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiBusinessEntityContactResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> BusinessEntityContactDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/BusinessEntityContacts/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBusinessEntityContactResponseModel> BusinessEntityContactGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiBusinessEntityContactResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContactAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBusinessEntityContactResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityContactResponseModel>> ByBusinessEntityContactByContactTypeID(int contactTypeID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts/byContactTypeID/{contactTypeID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBusinessEntityContactResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityContactResponseModel>> ByBusinessEntityContactByPersonID(int personID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts/byPersonID/{personID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBusinessEntityContactResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiContactTypeResponseModel>> ContactTypeBulkInsertAsync(List<ApiContactTypeRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ContactTypes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiContactTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiContactTypeResponseModel>> ContactTypeCreateAsync(ApiContactTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ContactTypes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiContactTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiContactTypeResponseModel>> ContactTypeUpdateAsync(int id, ApiContactTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ContactTypes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiContactTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ContactTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ContactTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiContactTypeResponseModel> ContactTypeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ContactTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiContactTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiContactTypeResponseModel>> ContactTypeAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ContactTypes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiContactTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiContactTypeResponseModel> ByContactTypeByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ContactTypes/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiContactTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContactsByContactTypeID(int contactTypeID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ContactTypes/BusinessEntityContactsByContactTypeID/{contactTypeID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBusinessEntityContactResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCountryRegionResponseModel>> CountryRegionBulkInsertAsync(List<ApiCountryRegionRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRegions/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCountryRegionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiCountryRegionResponseModel>> CountryRegionCreateAsync(ApiCountryRegionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRegions", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiCountryRegionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiCountryRegionResponseModel>> CountryRegionUpdateAsync(string id, ApiCountryRegionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CountryRegions/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiCountryRegionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> CountryRegionDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CountryRegions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCountryRegionResponseModel> CountryRegionGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCountryRegionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCountryRegionResponseModel>> CountryRegionAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegions?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCountryRegionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCountryRegionResponseModel> ByCountryRegionByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegions/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCountryRegionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStateProvinceResponseModel>> StateProvincesByCountryRegionCode(string countryRegionCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegions/StateProvincesByCountryRegionCode/{countryRegionCode}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStateProvinceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmailAddressResponseModel>> EmailAddressBulkInsertAsync(List<ApiEmailAddressRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmailAddresses/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEmailAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiEmailAddressResponseModel>> EmailAddressCreateAsync(ApiEmailAddressRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmailAddresses", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiEmailAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiEmailAddressResponseModel>> EmailAddressUpdateAsync(int id, ApiEmailAddressRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/EmailAddresses/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiEmailAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> EmailAddressDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/EmailAddresses/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmailAddressResponseModel> EmailAddressGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmailAddresses/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiEmailAddressResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmailAddressResponseModel>> EmailAddressAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmailAddresses?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEmailAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmailAddressResponseModel>> ByEmailAddressByEmailAddress(string emailAddress1)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmailAddresses/byEmailAddress/{emailAddress1}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEmailAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPasswordResponseModel>> PasswordBulkInsertAsync(List<ApiPasswordRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Passwords/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPasswordResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPasswordResponseModel>> PasswordCreateAsync(ApiPasswordRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Passwords", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPasswordResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPasswordResponseModel>> PasswordUpdateAsync(int id, ApiPasswordRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Passwords/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPasswordResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PasswordDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Passwords/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPasswordResponseModel> PasswordGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Passwords/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPasswordResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPasswordResponseModel>> PasswordAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Passwords?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPasswordResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonResponseModel>> PersonBulkInsertAsync(List<ApiPersonRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/People/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPersonResponseModel>> PersonCreateAsync(ApiPersonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/People", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPersonResponseModel>> PersonUpdateAsync(int id, ApiPersonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/People/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PersonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/People/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPersonResponseModel> PersonGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPersonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonResponseModel>> PersonAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonResponseModel>> ByPersonByLastNameFirstNameMiddleName(string lastName, string firstName, string middleName)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/byLastNameFirstNameMiddleName/{lastName}/{firstName}/{middleName}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonResponseModel>> ByPersonByAdditionalContactInfo(string additionalContactInfo)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/byAdditionalContactInfo/{additionalContactInfo}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonResponseModel>> ByPersonByDemographic(string demographic)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/byDemographics/{demographic}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContactsByPersonID(int personID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/BusinessEntityContactsByPersonID/{personID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBusinessEntityContactResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmailAddressResponseModel>> EmailAddressesByBusinessEntityID(int businessEntityID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/EmailAddressesByBusinessEntityID/{businessEntityID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEmailAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPasswordResponseModel>> PasswordsByBusinessEntityID(int businessEntityID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/PasswordsByBusinessEntityID/{businessEntityID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPasswordResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonPhoneResponseModel>> PersonPhonesByBusinessEntityID(int businessEntityID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/PersonPhonesByBusinessEntityID/{businessEntityID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPersonPhoneResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonPhoneResponseModel>> PersonPhoneBulkInsertAsync(List<ApiPersonPhoneRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonPhones/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPersonPhoneResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPersonPhoneResponseModel>> PersonPhoneCreateAsync(ApiPersonPhoneRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonPhones", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPersonPhoneResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPersonPhoneResponseModel>> PersonPhoneUpdateAsync(int id, ApiPersonPhoneRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PersonPhones/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPersonPhoneResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PersonPhoneDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PersonPhones/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPersonPhoneResponseModel> PersonPhoneGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonPhones/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPersonPhoneResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonPhoneResponseModel>> PersonPhoneAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonPhones?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPersonPhoneResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonPhoneResponseModel>> ByPersonPhoneByPhoneNumber(string phoneNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonPhones/byPhoneNumber/{phoneNumber}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPersonPhoneResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPhoneNumberTypeResponseModel>> PhoneNumberTypeBulkInsertAsync(List<ApiPhoneNumberTypeRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PhoneNumberTypes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPhoneNumberTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPhoneNumberTypeResponseModel>> PhoneNumberTypeCreateAsync(ApiPhoneNumberTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PhoneNumberTypes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPhoneNumberTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPhoneNumberTypeResponseModel>> PhoneNumberTypeUpdateAsync(int id, ApiPhoneNumberTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PhoneNumberTypes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPhoneNumberTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PhoneNumberTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PhoneNumberTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPhoneNumberTypeResponseModel> PhoneNumberTypeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PhoneNumberTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPhoneNumberTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPhoneNumberTypeResponseModel>> PhoneNumberTypeAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PhoneNumberTypes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPhoneNumberTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonPhoneResponseModel>> PersonPhonesByPhoneNumberTypeID(int phoneNumberTypeID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PhoneNumberTypes/PersonPhonesByPhoneNumberTypeID/{phoneNumberTypeID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPersonPhoneResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStateProvinceResponseModel>> StateProvinceBulkInsertAsync(List<ApiStateProvinceRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/StateProvinces/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStateProvinceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiStateProvinceResponseModel>> StateProvinceCreateAsync(ApiStateProvinceRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/StateProvinces", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiStateProvinceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiStateProvinceResponseModel>> StateProvinceUpdateAsync(int id, ApiStateProvinceRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/StateProvinces/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiStateProvinceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> StateProvinceDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/StateProvinces/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiStateProvinceResponseModel> StateProvinceGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiStateProvinceResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStateProvinceResponseModel>> StateProvinceAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStateProvinceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiStateProvinceResponseModel> ByStateProvinceByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiStateProvinceResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiStateProvinceResponseModel> ByStateProvinceByStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces/byStateProvinceCodeCountryRegionCode/{stateProvinceCode}/{countryRegionCode}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiStateProvinceResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAddressResponseModel>> AddressesByStateProvinceID(int stateProvinceID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces/AddressesByStateProvinceID/{stateProvinceID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVStateProvinceCountryRegionResponseModel> VStateProvinceCountryRegionGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VStateProvinceCountryRegions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiVStateProvinceCountryRegionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVStateProvinceCountryRegionResponseModel>> VStateProvinceCountryRegionAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VStateProvinceCountryRegions?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVStateProvinceCountryRegionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBillOfMaterialResponseModel>> BillOfMaterialBulkInsertAsync(List<ApiBillOfMaterialRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BillOfMaterials/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBillOfMaterialResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiBillOfMaterialResponseModel>> BillOfMaterialCreateAsync(ApiBillOfMaterialRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BillOfMaterials", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiBillOfMaterialResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiBillOfMaterialResponseModel>> BillOfMaterialUpdateAsync(int id, ApiBillOfMaterialRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/BillOfMaterials/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiBillOfMaterialResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> BillOfMaterialDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/BillOfMaterials/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBillOfMaterialResponseModel> BillOfMaterialGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BillOfMaterials/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiBillOfMaterialResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBillOfMaterialResponseModel>> BillOfMaterialAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BillOfMaterials?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBillOfMaterialResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBillOfMaterialResponseModel>> ByBillOfMaterialByUnitMeasureCode(string unitMeasureCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BillOfMaterials/byUnitMeasureCode/{unitMeasureCode}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBillOfMaterialResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCultureResponseModel>> CultureBulkInsertAsync(List<ApiCultureRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Cultures/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCultureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiCultureResponseModel>> CultureCreateAsync(ApiCultureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Cultures", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiCultureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiCultureResponseModel>> CultureUpdateAsync(string id, ApiCultureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Cultures/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiCultureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> CultureDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Cultures/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCultureResponseModel> CultureGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cultures/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCultureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCultureResponseModel>> CultureAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cultures?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCultureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCultureResponseModel> ByCultureByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cultures/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCultureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCulturesByCultureID(string cultureID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cultures/ProductModelProductDescriptionCulturesByCultureID/{cultureID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductModelProductDescriptionCultureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDocumentResponseModel>> DocumentBulkInsertAsync(List<ApiDocumentRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Documents/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDocumentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiDocumentResponseModel>> DocumentCreateAsync(ApiDocumentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Documents", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiDocumentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiDocumentResponseModel>> DocumentUpdateAsync(Guid id, ApiDocumentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Documents/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiDocumentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> DocumentDeleteAsync(Guid id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Documents/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDocumentResponseModel> DocumentGetAsync(Guid id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Documents/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiDocumentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDocumentResponseModel>> DocumentAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Documents?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDocumentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDocumentResponseModel>> ByDocumentByFileNameRevision(string fileName, string revision)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Documents/byFileNameRevision/{fileName}/{revision}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDocumentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiIllustrationResponseModel>> IllustrationBulkInsertAsync(List<ApiIllustrationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Illustrations/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiIllustrationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiIllustrationResponseModel>> IllustrationCreateAsync(ApiIllustrationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Illustrations", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiIllustrationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiIllustrationResponseModel>> IllustrationUpdateAsync(int id, ApiIllustrationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Illustrations/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiIllustrationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> IllustrationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Illustrations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiIllustrationResponseModel> IllustrationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Illustrations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiIllustrationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiIllustrationResponseModel>> IllustrationAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Illustrations?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiIllustrationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLocationResponseModel>> LocationBulkInsertAsync(List<ApiLocationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Locations/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLocationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiLocationResponseModel>> LocationCreateAsync(ApiLocationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Locations", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiLocationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiLocationResponseModel>> LocationUpdateAsync(short id, ApiLocationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Locations/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiLocationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> LocationDeleteAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Locations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLocationResponseModel> LocationGetAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLocationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLocationResponseModel>> LocationAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLocationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLocationResponseModel> ByLocationByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLocationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductInventoryResponseModel>> ProductInventoriesByLocationID(short locationID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations/ProductInventoriesByLocationID/{locationID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductInventoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutingsByLocationID(short locationID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations/WorkOrderRoutingsByLocationID/{locationID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiWorkOrderRoutingResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductResponseModel>> ProductBulkInsertAsync(List<ApiProductRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Products/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProductResponseModel>> ProductCreateAsync(ApiProductRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Products", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiProductResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProductResponseModel>> ProductUpdateAsync(int id, ApiProductRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Products/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiProductResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProductDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Products/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductResponseModel> ProductGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProductResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductResponseModel>> ProductAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductResponseModel> ByProductByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProductResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductResponseModel> ByProductByProductNumber(string productNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/byProductNumber/{productNumber}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProductResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBillOfMaterialResponseModel>> BillOfMaterialsByProductAssemblyID(int productAssemblyID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/BillOfMaterialsByProductAssemblyID/{productAssemblyID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBillOfMaterialResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBillOfMaterialResponseModel>> BillOfMaterialsByComponentID(int componentID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/BillOfMaterialsByComponentID/{componentID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBillOfMaterialResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductCostHistoryResponseModel>> ProductCostHistoriesByProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/ProductCostHistoriesByProductID/{productID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductCostHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductInventoryResponseModel>> ProductInventoriesByProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/ProductInventoriesByProductID/{productID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductInventoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductListPriceHistoryResponseModel>> ProductListPriceHistoriesByProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/ProductListPriceHistoriesByProductID/{productID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductListPriceHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductProductPhotoResponseModel>> ProductProductPhotoesByProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/ProductProductPhotoesByProductID/{productID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductReviewResponseModel>> ProductReviewsByProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/ProductReviewsByProductID/{productID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductReviewResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionHistoryResponseModel>> TransactionHistoriesByProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/TransactionHistoriesByProductID/{productID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTransactionHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkOrderResponseModel>> WorkOrdersByProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/WorkOrdersByProductID/{productID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiWorkOrderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductCategoryResponseModel>> ProductCategoryBulkInsertAsync(List<ApiProductCategoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCategories/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductCategoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProductCategoryResponseModel>> ProductCategoryCreateAsync(ApiProductCategoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCategories", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiProductCategoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProductCategoryResponseModel>> ProductCategoryUpdateAsync(int id, ApiProductCategoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductCategories/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiProductCategoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProductCategoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductCategories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductCategoryResponseModel> ProductCategoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCategories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProductCategoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductCategoryResponseModel>> ProductCategoryAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCategories?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductCategoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductCategoryResponseModel> ByProductCategoryByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCategories/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProductCategoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductSubcategoryResponseModel>> ProductSubcategoriesByProductCategoryID(int productCategoryID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCategories/ProductSubcategoriesByProductCategoryID/{productCategoryID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductSubcategoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductCostHistoryResponseModel>> ProductCostHistoryBulkInsertAsync(List<ApiProductCostHistoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCostHistories/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductCostHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProductCostHistoryResponseModel>> ProductCostHistoryCreateAsync(ApiProductCostHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCostHistories", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiProductCostHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProductCostHistoryResponseModel>> ProductCostHistoryUpdateAsync(int id, ApiProductCostHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductCostHistories/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiProductCostHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProductCostHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductCostHistories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductCostHistoryResponseModel> ProductCostHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCostHistories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProductCostHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductCostHistoryResponseModel>> ProductCostHistoryAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCostHistories?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductCostHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductDescriptionResponseModel>> ProductDescriptionBulkInsertAsync(List<ApiProductDescriptionRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductDescriptions/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductDescriptionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProductDescriptionResponseModel>> ProductDescriptionCreateAsync(ApiProductDescriptionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductDescriptions", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiProductDescriptionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProductDescriptionResponseModel>> ProductDescriptionUpdateAsync(int id, ApiProductDescriptionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductDescriptions/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiProductDescriptionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProductDescriptionDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductDescriptions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductDescriptionResponseModel> ProductDescriptionGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDescriptions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProductDescriptionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductDescriptionResponseModel>> ProductDescriptionAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDescriptions?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductDescriptionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCulturesByProductDescriptionID(int productDescriptionID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDescriptions/ProductModelProductDescriptionCulturesByProductDescriptionID/{productDescriptionID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductModelProductDescriptionCultureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductInventoryResponseModel>> ProductInventoryBulkInsertAsync(List<ApiProductInventoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductInventories/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductInventoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProductInventoryResponseModel>> ProductInventoryCreateAsync(ApiProductInventoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductInventories", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiProductInventoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProductInventoryResponseModel>> ProductInventoryUpdateAsync(int id, ApiProductInventoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductInventories/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiProductInventoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProductInventoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductInventories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductInventoryResponseModel> ProductInventoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductInventories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProductInventoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductInventoryResponseModel>> ProductInventoryAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductInventories?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductInventoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductListPriceHistoryResponseModel>> ProductListPriceHistoryBulkInsertAsync(List<ApiProductListPriceHistoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductListPriceHistories/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductListPriceHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProductListPriceHistoryResponseModel>> ProductListPriceHistoryCreateAsync(ApiProductListPriceHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductListPriceHistories", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiProductListPriceHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProductListPriceHistoryResponseModel>> ProductListPriceHistoryUpdateAsync(int id, ApiProductListPriceHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductListPriceHistories/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiProductListPriceHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProductListPriceHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductListPriceHistories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductListPriceHistoryResponseModel> ProductListPriceHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductListPriceHistories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProductListPriceHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductListPriceHistoryResponseModel>> ProductListPriceHistoryAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductListPriceHistories?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductListPriceHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductModelResponseModel>> ProductModelBulkInsertAsync(List<ApiProductModelRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModels/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductModelResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProductModelResponseModel>> ProductModelCreateAsync(ApiProductModelRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModels", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiProductModelResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProductModelResponseModel>> ProductModelUpdateAsync(int id, ApiProductModelRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductModels/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiProductModelResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProductModelDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductModels/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductModelResponseModel> ProductModelGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProductModelResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductModelResponseModel>> ProductModelAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductModelResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductModelResponseModel> ByProductModelByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProductModelResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductModelResponseModel>> ByProductModelByCatalogDescription(string catalogDescription)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/byCatalogDescription/{catalogDescription}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductModelResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductModelResponseModel>> ByProductModelByInstruction(string instruction)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/byInstructions/{instruction}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductModelResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductResponseModel>> ProductsByProductModelID(int productModelID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/ProductsByProductModelID/{productModelID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCulturesByProductModelID(int productModelID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/ProductModelProductDescriptionCulturesByProductModelID/{productModelID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductModelProductDescriptionCultureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultureBulkInsertAsync(List<ApiProductModelProductDescriptionCultureRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModelProductDescriptionCultures/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductModelProductDescriptionCultureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultureCreateAsync(ApiProductModelProductDescriptionCultureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModelProductDescriptionCultures", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultureUpdateAsync(int id, ApiProductModelProductDescriptionCultureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductModelProductDescriptionCultures/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiProductModelProductDescriptionCultureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProductModelProductDescriptionCultureDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductModelProductDescriptionCultures/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductModelProductDescriptionCultureResponseModel> ProductModelProductDescriptionCultureGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelProductDescriptionCultures/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProductModelProductDescriptionCultureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultureAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelProductDescriptionCultures?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductModelProductDescriptionCultureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductPhotoResponseModel>> ProductPhotoBulkInsertAsync(List<ApiProductPhotoRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductPhotoes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProductPhotoResponseModel>> ProductPhotoCreateAsync(ApiProductPhotoRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductPhotoes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProductPhotoResponseModel>> ProductPhotoUpdateAsync(int id, ApiProductPhotoRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductPhotoes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProductPhotoDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductPhotoes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductPhotoResponseModel> ProductPhotoGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductPhotoes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProductPhotoResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductPhotoResponseModel>> ProductPhotoAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductPhotoes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductProductPhotoResponseModel>> ProductProductPhotoesByProductPhotoID(int productPhotoID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductPhotoes/ProductProductPhotoesByProductPhotoID/{productPhotoID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductProductPhotoResponseModel>> ProductProductPhotoBulkInsertAsync(List<ApiProductProductPhotoRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductProductPhotoes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProductProductPhotoResponseModel>> ProductProductPhotoCreateAsync(ApiProductProductPhotoRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductProductPhotoes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiProductProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProductProductPhotoResponseModel>> ProductProductPhotoUpdateAsync(int id, ApiProductProductPhotoRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductProductPhotoes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiProductProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProductProductPhotoDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductProductPhotoes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductProductPhotoResponseModel> ProductProductPhotoGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductProductPhotoes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProductProductPhotoResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductProductPhotoResponseModel>> ProductProductPhotoAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductProductPhotoes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductReviewResponseModel>> ProductReviewBulkInsertAsync(List<ApiProductReviewRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductReviews/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductReviewResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProductReviewResponseModel>> ProductReviewCreateAsync(ApiProductReviewRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductReviews", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiProductReviewResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProductReviewResponseModel>> ProductReviewUpdateAsync(int id, ApiProductReviewRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductReviews/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiProductReviewResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProductReviewDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductReviews/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductReviewResponseModel> ProductReviewGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductReviews/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProductReviewResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductReviewResponseModel>> ProductReviewAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductReviews?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductReviewResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductReviewResponseModel>> ByProductReviewByProductIDReviewerName(int productID, string reviewerName)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductReviews/byProductIDReviewerName/{productID}/{reviewerName}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductReviewResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductSubcategoryResponseModel>> ProductSubcategoryBulkInsertAsync(List<ApiProductSubcategoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductSubcategories/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductSubcategoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProductSubcategoryResponseModel>> ProductSubcategoryCreateAsync(ApiProductSubcategoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductSubcategories", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiProductSubcategoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProductSubcategoryResponseModel>> ProductSubcategoryUpdateAsync(int id, ApiProductSubcategoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductSubcategories/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiProductSubcategoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProductSubcategoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductSubcategories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductSubcategoryResponseModel> ProductSubcategoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductSubcategories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProductSubcategoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductSubcategoryResponseModel>> ProductSubcategoryAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductSubcategories?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductSubcategoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductSubcategoryResponseModel> ByProductSubcategoryByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductSubcategories/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProductSubcategoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductResponseModel>> ProductsByProductSubcategoryID(int productSubcategoryID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductSubcategories/ProductsByProductSubcategoryID/{productSubcategoryID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiScrapReasonResponseModel>> ScrapReasonBulkInsertAsync(List<ApiScrapReasonRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ScrapReasons/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiScrapReasonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiScrapReasonResponseModel>> ScrapReasonCreateAsync(ApiScrapReasonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ScrapReasons", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiScrapReasonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiScrapReasonResponseModel>> ScrapReasonUpdateAsync(short id, ApiScrapReasonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ScrapReasons/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiScrapReasonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ScrapReasonDeleteAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ScrapReasons/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiScrapReasonResponseModel> ScrapReasonGetAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ScrapReasons/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiScrapReasonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiScrapReasonResponseModel>> ScrapReasonAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ScrapReasons?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiScrapReasonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiScrapReasonResponseModel> ByScrapReasonByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ScrapReasons/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiScrapReasonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkOrderResponseModel>> WorkOrdersByScrapReasonID(short scrapReasonID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ScrapReasons/WorkOrdersByScrapReasonID/{scrapReasonID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiWorkOrderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionHistoryResponseModel>> TransactionHistoryBulkInsertAsync(List<ApiTransactionHistoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistories/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTransactionHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTransactionHistoryResponseModel>> TransactionHistoryCreateAsync(ApiTransactionHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistories", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTransactionHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTransactionHistoryResponseModel>> TransactionHistoryUpdateAsync(int id, ApiTransactionHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TransactionHistories/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTransactionHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TransactionHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TransactionHistories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTransactionHistoryResponseModel> TransactionHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTransactionHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionHistoryResponseModel>> TransactionHistoryAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTransactionHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionHistoryResponseModel>> ByTransactionHistoryByProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories/byProductID/{productID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTransactionHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionHistoryResponseModel>> ByTransactionHistoryByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories/byReferenceOrderIDReferenceOrderLineID/{referenceOrderID}/{referenceOrderLineID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTransactionHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionHistoryArchiveResponseModel>> TransactionHistoryArchiveBulkInsertAsync(List<ApiTransactionHistoryArchiveRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistoryArchives/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTransactionHistoryArchiveResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTransactionHistoryArchiveResponseModel>> TransactionHistoryArchiveCreateAsync(ApiTransactionHistoryArchiveRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistoryArchives", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTransactionHistoryArchiveResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTransactionHistoryArchiveResponseModel>> TransactionHistoryArchiveUpdateAsync(int id, ApiTransactionHistoryArchiveRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TransactionHistoryArchives/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTransactionHistoryArchiveResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TransactionHistoryArchiveDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TransactionHistoryArchives/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTransactionHistoryArchiveResponseModel> TransactionHistoryArchiveGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTransactionHistoryArchiveResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionHistoryArchiveResponseModel>> TransactionHistoryArchiveAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTransactionHistoryArchiveResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionHistoryArchiveResponseModel>> ByTransactionHistoryArchiveByProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives/byProductID/{productID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTransactionHistoryArchiveResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionHistoryArchiveResponseModel>> ByTransactionHistoryArchiveByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives/byReferenceOrderIDReferenceOrderLineID/{referenceOrderID}/{referenceOrderLineID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTransactionHistoryArchiveResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUnitMeasureResponseModel>> UnitMeasureBulkInsertAsync(List<ApiUnitMeasureRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/UnitMeasures/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiUnitMeasureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiUnitMeasureResponseModel>> UnitMeasureCreateAsync(ApiUnitMeasureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/UnitMeasures", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiUnitMeasureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiUnitMeasureResponseModel>> UnitMeasureUpdateAsync(string id, ApiUnitMeasureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/UnitMeasures/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiUnitMeasureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> UnitMeasureDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/UnitMeasures/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiUnitMeasureResponseModel> UnitMeasureGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UnitMeasures/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiUnitMeasureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUnitMeasureResponseModel>> UnitMeasureAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UnitMeasures?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiUnitMeasureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiUnitMeasureResponseModel> ByUnitMeasureByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UnitMeasures/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiUnitMeasureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBillOfMaterialResponseModel>> BillOfMaterialsByUnitMeasureCode(string unitMeasureCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UnitMeasures/BillOfMaterialsByUnitMeasureCode/{unitMeasureCode}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBillOfMaterialResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductResponseModel>> ProductsBySizeUnitMeasureCode(string sizeUnitMeasureCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UnitMeasures/ProductsBySizeUnitMeasureCode/{sizeUnitMeasureCode}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductResponseModel>> ProductsByWeightUnitMeasureCode(string weightUnitMeasureCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UnitMeasures/ProductsByWeightUnitMeasureCode/{weightUnitMeasureCode}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVProductAndDescriptionResponseModel> VProductAndDescriptionGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VProductAndDescriptions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiVProductAndDescriptionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVProductAndDescriptionResponseModel>> VProductAndDescriptionAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VProductAndDescriptions?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVProductAndDescriptionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkOrderResponseModel>> WorkOrderBulkInsertAsync(List<ApiWorkOrderRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrders/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiWorkOrderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiWorkOrderResponseModel>> WorkOrderCreateAsync(ApiWorkOrderRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrders", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiWorkOrderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiWorkOrderResponseModel>> WorkOrderUpdateAsync(int id, ApiWorkOrderRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/WorkOrders/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiWorkOrderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> WorkOrderDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/WorkOrders/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiWorkOrderResponseModel> WorkOrderGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiWorkOrderResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkOrderResponseModel>> WorkOrderAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiWorkOrderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkOrderResponseModel>> ByWorkOrderByProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders/byProductID/{productID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiWorkOrderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkOrderResponseModel>> ByWorkOrderByScrapReasonID(short? scrapReasonID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders/byScrapReasonID/{scrapReasonID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiWorkOrderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutingsByWorkOrderID(int workOrderID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders/WorkOrderRoutingsByWorkOrderID/{workOrderID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiWorkOrderRoutingResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutingBulkInsertAsync(List<ApiWorkOrderRoutingRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrderRoutings/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiWorkOrderRoutingResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutingCreateAsync(ApiWorkOrderRoutingRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrderRoutings", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiWorkOrderRoutingResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutingUpdateAsync(int id, ApiWorkOrderRoutingRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/WorkOrderRoutings/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiWorkOrderRoutingResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> WorkOrderRoutingDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/WorkOrderRoutings/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiWorkOrderRoutingResponseModel> WorkOrderRoutingGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrderRoutings/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiWorkOrderRoutingResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutingAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrderRoutings?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiWorkOrderRoutingResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkOrderRoutingResponseModel>> ByWorkOrderRoutingByProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrderRoutings/byProductID/{productID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiWorkOrderRoutingResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductVendorResponseModel>> ProductVendorBulkInsertAsync(List<ApiProductVendorRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductVendors/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductVendorResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiProductVendorResponseModel>> ProductVendorCreateAsync(ApiProductVendorRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductVendors", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiProductVendorResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiProductVendorResponseModel>> ProductVendorUpdateAsync(int id, ApiProductVendorRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductVendors/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiProductVendorResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ProductVendorDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductVendors/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductVendorResponseModel> ProductVendorGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiProductVendorResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductVendorResponseModel>> ProductVendorAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductVendorResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductVendorResponseModel>> ByProductVendorByBusinessEntityID(int businessEntityID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors/byBusinessEntityID/{businessEntityID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductVendorResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductVendorResponseModel>> ByProductVendorByUnitMeasureCode(string unitMeasureCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors/byUnitMeasureCode/{unitMeasureCode}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductVendorResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPurchaseOrderDetailResponseModel>> PurchaseOrderDetailBulkInsertAsync(List<ApiPurchaseOrderDetailRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderDetails/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPurchaseOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPurchaseOrderDetailResponseModel>> PurchaseOrderDetailCreateAsync(ApiPurchaseOrderDetailRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderDetails", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPurchaseOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPurchaseOrderDetailResponseModel>> PurchaseOrderDetailUpdateAsync(int id, ApiPurchaseOrderDetailRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PurchaseOrderDetails/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPurchaseOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PurchaseOrderDetailDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PurchaseOrderDetails/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPurchaseOrderDetailResponseModel> PurchaseOrderDetailGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderDetails/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPurchaseOrderDetailResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPurchaseOrderDetailResponseModel>> PurchaseOrderDetailAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderDetails?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPurchaseOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPurchaseOrderDetailResponseModel>> ByPurchaseOrderDetailByProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderDetails/byProductID/{productID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPurchaseOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeaderBulkInsertAsync(List<ApiPurchaseOrderHeaderRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderHeaders/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPurchaseOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeaderCreateAsync(ApiPurchaseOrderHeaderRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderHeaders", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPurchaseOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeaderUpdateAsync(int id, ApiPurchaseOrderHeaderRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PurchaseOrderHeaders/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPurchaseOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PurchaseOrderHeaderDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PurchaseOrderHeaders/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPurchaseOrderHeaderResponseModel> PurchaseOrderHeaderGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPurchaseOrderHeaderResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeaderAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPurchaseOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> ByPurchaseOrderHeaderByEmployeeID(int employeeID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders/byEmployeeID/{employeeID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPurchaseOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> ByPurchaseOrderHeaderByVendorID(int vendorID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders/byVendorID/{vendorID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPurchaseOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPurchaseOrderDetailResponseModel>> PurchaseOrderDetailsByPurchaseOrderID(int purchaseOrderID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders/PurchaseOrderDetailsByPurchaseOrderID/{purchaseOrderID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPurchaseOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiShipMethodResponseModel>> ShipMethodBulkInsertAsync(List<ApiShipMethodRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShipMethods/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiShipMethodResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiShipMethodResponseModel>> ShipMethodCreateAsync(ApiShipMethodRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShipMethods", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiShipMethodResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiShipMethodResponseModel>> ShipMethodUpdateAsync(int id, ApiShipMethodRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ShipMethods/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiShipMethodResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ShipMethodDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ShipMethods/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiShipMethodResponseModel> ShipMethodGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShipMethods/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiShipMethodResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiShipMethodResponseModel>> ShipMethodAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShipMethods?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiShipMethodResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiShipMethodResponseModel> ByShipMethodByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShipMethods/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiShipMethodResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeadersByShipMethodID(int shipMethodID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShipMethods/PurchaseOrderHeadersByShipMethodID/{shipMethodID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPurchaseOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVendorResponseModel>> VendorBulkInsertAsync(List<ApiVendorRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Vendors/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVendorResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiVendorResponseModel>> VendorCreateAsync(ApiVendorRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Vendors", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiVendorResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiVendorResponseModel>> VendorUpdateAsync(int id, ApiVendorRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Vendors/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiVendorResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> VendorDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Vendors/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVendorResponseModel> VendorGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Vendors/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiVendorResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVendorResponseModel>> VendorAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Vendors?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVendorResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVendorResponseModel> ByVendorByAccountNumber(string accountNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Vendors/byAccountNumber/{accountNumber}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiVendorResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductVendorResponseModel>> ProductVendorsByBusinessEntityID(int businessEntityID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Vendors/ProductVendorsByBusinessEntityID/{businessEntityID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiProductVendorResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeadersByVendorID(int vendorID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Vendors/PurchaseOrderHeadersByVendorID/{vendorID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPurchaseOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCreditCardResponseModel>> CreditCardBulkInsertAsync(List<ApiCreditCardRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CreditCards/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCreditCardResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiCreditCardResponseModel>> CreditCardCreateAsync(ApiCreditCardRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CreditCards", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiCreditCardResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiCreditCardResponseModel>> CreditCardUpdateAsync(int id, ApiCreditCardRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CreditCards/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiCreditCardResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> CreditCardDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CreditCards/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCreditCardResponseModel> CreditCardGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CreditCards/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCreditCardResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCreditCardResponseModel>> CreditCardAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CreditCards?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCreditCardResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCreditCardResponseModel> ByCreditCardByCardNumber(string cardNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CreditCards/byCardNumber/{cardNumber}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCreditCardResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeadersByCreditCardID(int creditCardID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CreditCards/SalesOrderHeadersByCreditCardID/{creditCardID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCurrencyResponseModel>> CurrencyBulkInsertAsync(List<ApiCurrencyRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Currencies/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCurrencyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiCurrencyResponseModel>> CurrencyCreateAsync(ApiCurrencyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Currencies", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiCurrencyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiCurrencyResponseModel>> CurrencyUpdateAsync(string id, ApiCurrencyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Currencies/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiCurrencyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> CurrencyDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Currencies/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCurrencyResponseModel> CurrencyGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCurrencyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCurrencyResponseModel>> CurrencyAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCurrencyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCurrencyResponseModel> ByCurrencyByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCurrencyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCurrencyRateResponseModel>> CurrencyRatesByFromCurrencyCode(string fromCurrencyCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies/CurrencyRatesByFromCurrencyCode/{fromCurrencyCode}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCurrencyRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCurrencyRateResponseModel>> CurrencyRatesByToCurrencyCode(string toCurrencyCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies/CurrencyRatesByToCurrencyCode/{toCurrencyCode}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCurrencyRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCurrencyRateResponseModel>> CurrencyRateBulkInsertAsync(List<ApiCurrencyRateRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CurrencyRates/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCurrencyRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiCurrencyRateResponseModel>> CurrencyRateCreateAsync(ApiCurrencyRateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CurrencyRates", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiCurrencyRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiCurrencyRateResponseModel>> CurrencyRateUpdateAsync(int id, ApiCurrencyRateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CurrencyRates/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiCurrencyRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> CurrencyRateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CurrencyRates/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCurrencyRateResponseModel> CurrencyRateGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CurrencyRates/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCurrencyRateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCurrencyRateResponseModel>> CurrencyRateAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CurrencyRates?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCurrencyRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCurrencyRateResponseModel> ByCurrencyRateByCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CurrencyRates/byCurrencyRateDateFromCurrencyCodeToCurrencyCode/{currencyRateDate}/{fromCurrencyCode}/{toCurrencyCode}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCurrencyRateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeadersByCurrencyRateID(int currencyRateID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CurrencyRates/SalesOrderHeadersByCurrencyRateID/{currencyRateID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCustomerResponseModel>> CustomerBulkInsertAsync(List<ApiCustomerRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Customers/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiCustomerResponseModel>> CustomerCreateAsync(ApiCustomerRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Customers", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiCustomerResponseModel>> CustomerUpdateAsync(int id, ApiCustomerRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Customers/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> CustomerDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Customers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCustomerResponseModel> CustomerGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCustomerResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCustomerResponseModel>> CustomerAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCustomerResponseModel> ByCustomerByAccountNumber(string accountNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers/byAccountNumber/{accountNumber}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCustomerResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCustomerResponseModel>> ByCustomerByTerritoryID(int? territoryID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers/byTerritoryID/{territoryID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeadersByCustomerID(int customerID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers/SalesOrderHeadersByCustomerID/{customerID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderDetailResponseModel>> SalesOrderDetailBulkInsertAsync(List<ApiSalesOrderDetailRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderDetails/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSalesOrderDetailResponseModel>> SalesOrderDetailCreateAsync(ApiSalesOrderDetailRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderDetails", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSalesOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSalesOrderDetailResponseModel>> SalesOrderDetailUpdateAsync(int id, ApiSalesOrderDetailRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesOrderDetails/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSalesOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SalesOrderDetailDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesOrderDetails/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesOrderDetailResponseModel> SalesOrderDetailGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderDetails/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSalesOrderDetailResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderDetailResponseModel>> SalesOrderDetailAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderDetails?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderDetailResponseModel>> BySalesOrderDetailByProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderDetails/byProductID/{productID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaderBulkInsertAsync(List<ApiSalesOrderHeaderRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderHeaders/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaderCreateAsync(ApiSalesOrderHeaderRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderHeaders", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaderUpdateAsync(int id, ApiSalesOrderHeaderRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesOrderHeaders/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SalesOrderHeaderDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesOrderHeaders/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesOrderHeaderResponseModel> SalesOrderHeaderGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSalesOrderHeaderResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaderAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesOrderHeaderResponseModel> BySalesOrderHeaderBySalesOrderNumber(string salesOrderNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/bySalesOrderNumber/{salesOrderNumber}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSalesOrderHeaderResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> BySalesOrderHeaderByCustomerID(int customerID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/byCustomerID/{customerID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> BySalesOrderHeaderBySalesPersonID(int? salesPersonID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/bySalesPersonID/{salesPersonID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderDetailResponseModel>> SalesOrderDetailsBySalesOrderID(int salesOrderID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/SalesOrderDetailsBySalesOrderID/{salesOrderID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesPersonResponseModel>> SalesPersonBulkInsertAsync(List<ApiSalesPersonRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersons/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSalesPersonResponseModel>> SalesPersonCreateAsync(ApiSalesPersonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersons", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSalesPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSalesPersonResponseModel>> SalesPersonUpdateAsync(int id, ApiSalesPersonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesPersons/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSalesPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SalesPersonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesPersons/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesPersonResponseModel> SalesPersonGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersons/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSalesPersonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesPersonResponseModel>> SalesPersonAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersons?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeadersBySalesPersonID(int salesPersonID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersons/SalesOrderHeadersBySalesPersonID/{salesPersonID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesPersonQuotaHistoryResponseModel>> SalesPersonQuotaHistoriesByBusinessEntityID(int businessEntityID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersons/SalesPersonQuotaHistoriesByBusinessEntityID/{businessEntityID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesPersonQuotaHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistoriesByBusinessEntityID(int businessEntityID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersons/SalesTerritoryHistoriesByBusinessEntityID/{businessEntityID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesTerritoryHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStoreResponseModel>> StoresBySalesPersonID(int salesPersonID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersons/StoresBySalesPersonID/{salesPersonID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStoreResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesPersonQuotaHistoryResponseModel>> SalesPersonQuotaHistoryBulkInsertAsync(List<ApiSalesPersonQuotaHistoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersonQuotaHistories/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesPersonQuotaHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>> SalesPersonQuotaHistoryCreateAsync(ApiSalesPersonQuotaHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersonQuotaHistories", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>> SalesPersonQuotaHistoryUpdateAsync(int id, ApiSalesPersonQuotaHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesPersonQuotaHistories/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SalesPersonQuotaHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesPersonQuotaHistories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesPersonQuotaHistoryResponseModel> SalesPersonQuotaHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersonQuotaHistories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSalesPersonQuotaHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesPersonQuotaHistoryResponseModel>> SalesPersonQuotaHistoryAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersonQuotaHistories?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesPersonQuotaHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesReasonResponseModel>> SalesReasonBulkInsertAsync(List<ApiSalesReasonRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesReasons/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesReasonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSalesReasonResponseModel>> SalesReasonCreateAsync(ApiSalesReasonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesReasons", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSalesReasonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSalesReasonResponseModel>> SalesReasonUpdateAsync(int id, ApiSalesReasonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesReasons/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSalesReasonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SalesReasonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesReasons/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesReasonResponseModel> SalesReasonGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesReasons/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSalesReasonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesReasonResponseModel>> SalesReasonAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesReasons?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesReasonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesTaxRateResponseModel>> SalesTaxRateBulkInsertAsync(List<ApiSalesTaxRateRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTaxRates/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesTaxRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSalesTaxRateResponseModel>> SalesTaxRateCreateAsync(ApiSalesTaxRateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTaxRates", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSalesTaxRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSalesTaxRateResponseModel>> SalesTaxRateUpdateAsync(int id, ApiSalesTaxRateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesTaxRates/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSalesTaxRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SalesTaxRateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesTaxRates/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesTaxRateResponseModel> SalesTaxRateGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTaxRates/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSalesTaxRateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesTaxRateResponseModel>> SalesTaxRateAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTaxRates?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesTaxRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesTaxRateResponseModel> BySalesTaxRateByStateProvinceIDTaxType(int stateProvinceID, int taxType)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTaxRates/byStateProvinceIDTaxType/{stateProvinceID}/{taxType}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSalesTaxRateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesTerritoryResponseModel>> SalesTerritoryBulkInsertAsync(List<ApiSalesTerritoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritories/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesTerritoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSalesTerritoryResponseModel>> SalesTerritoryCreateAsync(ApiSalesTerritoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritories", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSalesTerritoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSalesTerritoryResponseModel>> SalesTerritoryUpdateAsync(int id, ApiSalesTerritoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesTerritories/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSalesTerritoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SalesTerritoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesTerritories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesTerritoryResponseModel> SalesTerritoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSalesTerritoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesTerritoryResponseModel>> SalesTerritoryAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesTerritoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesTerritoryResponseModel> BySalesTerritoryByName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories/byName/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSalesTerritoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCustomerResponseModel>> CustomersByTerritoryID(int territoryID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories/CustomersByTerritoryID/{territoryID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeadersByTerritoryID(int territoryID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories/SalesOrderHeadersByTerritoryID/{territoryID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesPersonResponseModel>> SalesPersonsByTerritoryID(int territoryID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories/SalesPersonsByTerritoryID/{territoryID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistoriesByTerritoryID(int territoryID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories/SalesTerritoryHistoriesByTerritoryID/{territoryID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesTerritoryHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistoryBulkInsertAsync(List<ApiSalesTerritoryHistoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritoryHistories/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesTerritoryHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistoryCreateAsync(ApiSalesTerritoryHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritoryHistories", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSalesTerritoryHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistoryUpdateAsync(int id, ApiSalesTerritoryHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesTerritoryHistories/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSalesTerritoryHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SalesTerritoryHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesTerritoryHistories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesTerritoryHistoryResponseModel> SalesTerritoryHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritoryHistories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSalesTerritoryHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistoryAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritoryHistories?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSalesTerritoryHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiShoppingCartItemResponseModel>> ShoppingCartItemBulkInsertAsync(List<ApiShoppingCartItemRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShoppingCartItems/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiShoppingCartItemResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiShoppingCartItemResponseModel>> ShoppingCartItemCreateAsync(ApiShoppingCartItemRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShoppingCartItems", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiShoppingCartItemResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiShoppingCartItemResponseModel>> ShoppingCartItemUpdateAsync(int id, ApiShoppingCartItemRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ShoppingCartItems/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiShoppingCartItemResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ShoppingCartItemDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ShoppingCartItems/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiShoppingCartItemResponseModel> ShoppingCartItemGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShoppingCartItems/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiShoppingCartItemResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiShoppingCartItemResponseModel>> ShoppingCartItemAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShoppingCartItems?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiShoppingCartItemResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiShoppingCartItemResponseModel>> ByShoppingCartItemByShoppingCartIDProductID(string shoppingCartID, int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShoppingCartItems/byShoppingCartIDProductID/{shoppingCartID}/{productID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiShoppingCartItemResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpecialOfferResponseModel>> SpecialOfferBulkInsertAsync(List<ApiSpecialOfferRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOffers/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpecialOfferResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSpecialOfferResponseModel>> SpecialOfferCreateAsync(ApiSpecialOfferRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOffers", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSpecialOfferResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSpecialOfferResponseModel>> SpecialOfferUpdateAsync(int id, ApiSpecialOfferRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SpecialOffers/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSpecialOfferResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SpecialOfferDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SpecialOffers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSpecialOfferResponseModel> SpecialOfferGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOffers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSpecialOfferResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpecialOfferResponseModel>> SpecialOfferAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOffers?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpecialOfferResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpecialOfferProductResponseModel>> SpecialOfferProductBulkInsertAsync(List<ApiSpecialOfferProductRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOfferProducts/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpecialOfferProductResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSpecialOfferProductResponseModel>> SpecialOfferProductCreateAsync(ApiSpecialOfferProductRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOfferProducts", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSpecialOfferProductResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSpecialOfferProductResponseModel>> SpecialOfferProductUpdateAsync(int id, ApiSpecialOfferProductRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SpecialOfferProducts/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSpecialOfferProductResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SpecialOfferProductDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SpecialOfferProducts/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSpecialOfferProductResponseModel> SpecialOfferProductGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOfferProducts/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSpecialOfferProductResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpecialOfferProductResponseModel>> SpecialOfferProductAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOfferProducts?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpecialOfferProductResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStoreResponseModel>> StoreBulkInsertAsync(List<ApiStoreRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Stores/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStoreResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiStoreResponseModel>> StoreCreateAsync(ApiStoreRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Stores", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiStoreResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiStoreResponseModel>> StoreUpdateAsync(int id, ApiStoreRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Stores/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiStoreResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> StoreDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Stores/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiStoreResponseModel> StoreGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiStoreResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStoreResponseModel>> StoreAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStoreResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStoreResponseModel>> ByStoreBySalesPersonID(int? salesPersonID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores/bySalesPersonID/{salesPersonID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStoreResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStoreResponseModel>> ByStoreByDemographic(string demographic)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores/byDemographics/{demographic}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStoreResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCustomerResponseModel>> CustomersByStoreID(int storeID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores/CustomersByStoreID/{storeID}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>3c15bc51c57c54b4fcddb539346a3670</Hash>
</Codenesium>*/