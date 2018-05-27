using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
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

		public virtual async Task<ApiAWBuildVersionResponseModel> AWBuildVersionCreateAsync(ApiAWBuildVersionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AWBuildVersions", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiAWBuildVersionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAWBuildVersionResponseModel> AWBuildVersionUpdateAsync(int id, ApiAWBuildVersionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/AWBuildVersions/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiAWBuildVersionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task AWBuildVersionDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/AWBuildVersions/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiAWBuildVersionResponseModel> AWBuildVersionGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AWBuildVersions/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiAWBuildVersionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAWBuildVersionResponseModel>> AWBuildVersionAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AWBuildVersions?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiAWBuildVersionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAWBuildVersionResponseModel>> AWBuildVersionBulkInsertAsync(List<ApiAWBuildVersionRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AWBuildVersions/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiAWBuildVersionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDatabaseLogResponseModel> DatabaseLogCreateAsync(ApiDatabaseLogRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DatabaseLogs", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiDatabaseLogResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDatabaseLogResponseModel> DatabaseLogUpdateAsync(int id, ApiDatabaseLogRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/DatabaseLogs/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiDatabaseLogResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task DatabaseLogDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/DatabaseLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiDatabaseLogResponseModel> DatabaseLogGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DatabaseLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiDatabaseLogResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDatabaseLogResponseModel>> DatabaseLogAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DatabaseLogs?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiDatabaseLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDatabaseLogResponseModel>> DatabaseLogBulkInsertAsync(List<ApiDatabaseLogRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DatabaseLogs/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiDatabaseLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiErrorLogResponseModel> ErrorLogCreateAsync(ApiErrorLogRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ErrorLogs", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiErrorLogResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiErrorLogResponseModel> ErrorLogUpdateAsync(int id, ApiErrorLogRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ErrorLogs/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiErrorLogResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ErrorLogDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ErrorLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiErrorLogResponseModel> ErrorLogGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ErrorLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiErrorLogResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiErrorLogResponseModel>> ErrorLogAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ErrorLogs?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiErrorLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiErrorLogResponseModel>> ErrorLogBulkInsertAsync(List<ApiErrorLogRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ErrorLogs/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiErrorLogResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDepartmentResponseModel> DepartmentCreateAsync(ApiDepartmentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Departments", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiDepartmentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDepartmentResponseModel> DepartmentUpdateAsync(short id, ApiDepartmentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Departments/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiDepartmentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task DepartmentDeleteAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Departments/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiDepartmentResponseModel> DepartmentGetAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Departments/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiDepartmentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDepartmentResponseModel>> DepartmentAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Departments?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiDepartmentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDepartmentResponseModel>> DepartmentBulkInsertAsync(List<ApiDepartmentRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Departments/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiDepartmentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDepartmentResponseModel> GetDepartmentGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Departments/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiDepartmentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmployeeResponseModel> EmployeeCreateAsync(ApiEmployeeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Employees", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiEmployeeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmployeeResponseModel> EmployeeUpdateAsync(int id, ApiEmployeeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Employees/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiEmployeeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task EmployeeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Employees/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiEmployeeResponseModel> EmployeeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiEmployeeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeResponseModel>> EmployeeAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiEmployeeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeResponseModel>> EmployeeBulkInsertAsync(List<ApiEmployeeRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Employees/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiEmployeeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmployeeResponseModel> GetEmployeeGetLoginID(string loginID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/getLoginID/{loginID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiEmployeeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmployeeResponseModel> GetEmployeeGetNationalIDNumber(string nationalIDNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/getNationalIDNumber/{nationalIDNumber}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiEmployeeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeResponseModel>> GetEmployeeGetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel,Nullable<Guid> organizationNode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/getOrganizationLevelOrganizationNode/{organizationLevel}/{organizationNode}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiEmployeeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeResponseModel>> GetEmployeeGetOrganizationNode(Nullable<Guid> organizationNode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/getOrganizationNode/{organizationNode}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiEmployeeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmployeeDepartmentHistoryResponseModel> EmployeeDepartmentHistoryCreateAsync(ApiEmployeeDepartmentHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeeDepartmentHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiEmployeeDepartmentHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmployeeDepartmentHistoryResponseModel> EmployeeDepartmentHistoryUpdateAsync(int id, ApiEmployeeDepartmentHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/EmployeeDepartmentHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiEmployeeDepartmentHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task EmployeeDepartmentHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/EmployeeDepartmentHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiEmployeeDepartmentHistoryResponseModel> EmployeeDepartmentHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiEmployeeDepartmentHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiEmployeeDepartmentHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistoryBulkInsertAsync(List<ApiEmployeeDepartmentHistoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeeDepartmentHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiEmployeeDepartmentHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> GetEmployeeDepartmentHistoryGetDepartmentID(short departmentID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories/getDepartmentID/{departmentID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiEmployeeDepartmentHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> GetEmployeeDepartmentHistoryGetShiftID(int shiftID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories/getShiftID/{shiftID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiEmployeeDepartmentHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmployeePayHistoryResponseModel> EmployeePayHistoryCreateAsync(ApiEmployeePayHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeePayHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiEmployeePayHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmployeePayHistoryResponseModel> EmployeePayHistoryUpdateAsync(int id, ApiEmployeePayHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/EmployeePayHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiEmployeePayHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task EmployeePayHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/EmployeePayHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiEmployeePayHistoryResponseModel> EmployeePayHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeePayHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiEmployeePayHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeePayHistoryResponseModel>> EmployeePayHistoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeePayHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiEmployeePayHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmployeePayHistoryResponseModel>> EmployeePayHistoryBulkInsertAsync(List<ApiEmployeePayHistoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeePayHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiEmployeePayHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiJobCandidateResponseModel> JobCandidateCreateAsync(ApiJobCandidateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/JobCandidates", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiJobCandidateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiJobCandidateResponseModel> JobCandidateUpdateAsync(int id, ApiJobCandidateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/JobCandidates/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiJobCandidateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task JobCandidateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/JobCandidates/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiJobCandidateResponseModel> JobCandidateGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/JobCandidates/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiJobCandidateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiJobCandidateResponseModel>> JobCandidateAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/JobCandidates?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiJobCandidateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiJobCandidateResponseModel>> JobCandidateBulkInsertAsync(List<ApiJobCandidateRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/JobCandidates/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiJobCandidateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiJobCandidateResponseModel>> GetJobCandidateGetBusinessEntityID(Nullable<int> businessEntityID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/JobCandidates/getBusinessEntityID/{businessEntityID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiJobCandidateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiShiftResponseModel> ShiftCreateAsync(ApiShiftRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Shifts", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiShiftResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiShiftResponseModel> ShiftUpdateAsync(int id, ApiShiftRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Shifts/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiShiftResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ShiftDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Shifts/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiShiftResponseModel> ShiftGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiShiftResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiShiftResponseModel>> ShiftAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiShiftResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiShiftResponseModel>> ShiftBulkInsertAsync(List<ApiShiftRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Shifts/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiShiftResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiShiftResponseModel> GetShiftGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiShiftResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiShiftResponseModel> GetShiftGetStartTimeEndTime(TimeSpan startTime,TimeSpan endTime)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts/getStartTimeEndTime/{startTime}/{endTime}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiShiftResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAddressResponseModel> AddressCreateAsync(ApiAddressRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Addresses", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiAddressResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAddressResponseModel> AddressUpdateAsync(int id, ApiAddressRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Addresses/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiAddressResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task AddressDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Addresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiAddressResponseModel> AddressGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiAddressResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAddressResponseModel>> AddressAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAddressResponseModel>> AddressBulkInsertAsync(List<ApiAddressRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Addresses/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAddressResponseModel> GetAddressGetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1,string addressLine2,string city,int stateProvinceID,string postalCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses/getAddressLine1AddressLine2CityStateProvinceIDPostalCode/{addressLine1}/{addressLine2}/{city}/{stateProvinceID}/{postalCode}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiAddressResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAddressResponseModel>> GetAddressGetStateProvinceID(int stateProvinceID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses/getStateProvinceID/{stateProvinceID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAddressTypeResponseModel> AddressTypeCreateAsync(ApiAddressTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AddressTypes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiAddressTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAddressTypeResponseModel> AddressTypeUpdateAsync(int id, ApiAddressTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/AddressTypes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiAddressTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task AddressTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/AddressTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiAddressTypeResponseModel> AddressTypeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AddressTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiAddressTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAddressTypeResponseModel>> AddressTypeAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AddressTypes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiAddressTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAddressTypeResponseModel>> AddressTypeBulkInsertAsync(List<ApiAddressTypeRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AddressTypes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiAddressTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAddressTypeResponseModel> GetAddressTypeGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AddressTypes/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiAddressTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBusinessEntityResponseModel> BusinessEntityCreateAsync(ApiBusinessEntityRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntities", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiBusinessEntityResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBusinessEntityResponseModel> BusinessEntityUpdateAsync(int id, ApiBusinessEntityRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/BusinessEntities/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiBusinessEntityResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task BusinessEntityDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/BusinessEntities/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiBusinessEntityResponseModel> BusinessEntityGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntities/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiBusinessEntityResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityResponseModel>> BusinessEntityAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntities?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiBusinessEntityResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityResponseModel>> BusinessEntityBulkInsertAsync(List<ApiBusinessEntityRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntities/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiBusinessEntityResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBusinessEntityAddressResponseModel> BusinessEntityAddressCreateAsync(ApiBusinessEntityAddressRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityAddresses", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiBusinessEntityAddressResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBusinessEntityAddressResponseModel> BusinessEntityAddressUpdateAsync(int id, ApiBusinessEntityAddressRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/BusinessEntityAddresses/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiBusinessEntityAddressResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task BusinessEntityAddressDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/BusinessEntityAddresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiBusinessEntityAddressResponseModel> BusinessEntityAddressGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiBusinessEntityAddressResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddressAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiBusinessEntityAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddressBulkInsertAsync(List<ApiBusinessEntityAddressRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityAddresses/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiBusinessEntityAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> GetBusinessEntityAddressGetAddressID(int addressID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses/getAddressID/{addressID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiBusinessEntityAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> GetBusinessEntityAddressGetAddressTypeID(int addressTypeID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses/getAddressTypeID/{addressTypeID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiBusinessEntityAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBusinessEntityContactResponseModel> BusinessEntityContactCreateAsync(ApiBusinessEntityContactRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityContacts", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiBusinessEntityContactResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBusinessEntityContactResponseModel> BusinessEntityContactUpdateAsync(int id, ApiBusinessEntityContactRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/BusinessEntityContacts/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiBusinessEntityContactResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task BusinessEntityContactDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/BusinessEntityContacts/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiBusinessEntityContactResponseModel> BusinessEntityContactGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiBusinessEntityContactResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContactAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiBusinessEntityContactResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContactBulkInsertAsync(List<ApiBusinessEntityContactRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityContacts/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiBusinessEntityContactResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityContactResponseModel>> GetBusinessEntityContactGetContactTypeID(int contactTypeID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts/getContactTypeID/{contactTypeID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiBusinessEntityContactResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBusinessEntityContactResponseModel>> GetBusinessEntityContactGetPersonID(int personID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts/getPersonID/{personID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiBusinessEntityContactResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiContactTypeResponseModel> ContactTypeCreateAsync(ApiContactTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ContactTypes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiContactTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiContactTypeResponseModel> ContactTypeUpdateAsync(int id, ApiContactTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ContactTypes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiContactTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ContactTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ContactTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiContactTypeResponseModel> ContactTypeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ContactTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiContactTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiContactTypeResponseModel>> ContactTypeAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ContactTypes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiContactTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiContactTypeResponseModel>> ContactTypeBulkInsertAsync(List<ApiContactTypeRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ContactTypes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiContactTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiContactTypeResponseModel> GetContactTypeGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ContactTypes/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiContactTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCountryRegionResponseModel> CountryRegionCreateAsync(ApiCountryRegionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRegions", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCountryRegionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCountryRegionResponseModel> CountryRegionUpdateAsync(string id, ApiCountryRegionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CountryRegions/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCountryRegionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task CountryRegionDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CountryRegions/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiCountryRegionResponseModel> CountryRegionGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegions/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCountryRegionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCountryRegionResponseModel>> CountryRegionAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegions?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCountryRegionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCountryRegionResponseModel>> CountryRegionBulkInsertAsync(List<ApiCountryRegionRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRegions/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCountryRegionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCountryRegionResponseModel> GetCountryRegionGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegions/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCountryRegionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmailAddressResponseModel> EmailAddressCreateAsync(ApiEmailAddressRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmailAddresses", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiEmailAddressResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEmailAddressResponseModel> EmailAddressUpdateAsync(int id, ApiEmailAddressRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/EmailAddresses/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiEmailAddressResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task EmailAddressDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/EmailAddresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiEmailAddressResponseModel> EmailAddressGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmailAddresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiEmailAddressResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmailAddressResponseModel>> EmailAddressAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmailAddresses?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiEmailAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmailAddressResponseModel>> EmailAddressBulkInsertAsync(List<ApiEmailAddressRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmailAddresses/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiEmailAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEmailAddressResponseModel>> GetEmailAddressGetEmailAddress(string emailAddress1)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmailAddresses/getEmailAddress/{emailAddress1}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiEmailAddressResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPasswordResponseModel> PasswordCreateAsync(ApiPasswordRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Passwords", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPasswordResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPasswordResponseModel> PasswordUpdateAsync(int id, ApiPasswordRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Passwords/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPasswordResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PasswordDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Passwords/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiPasswordResponseModel> PasswordGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Passwords/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPasswordResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPasswordResponseModel>> PasswordAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Passwords?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPasswordResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPasswordResponseModel>> PasswordBulkInsertAsync(List<ApiPasswordRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Passwords/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPasswordResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPersonResponseModel> PersonCreateAsync(ApiPersonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/People", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPersonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPersonResponseModel> PersonUpdateAsync(int id, ApiPersonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/People/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPersonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PersonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/People/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiPersonResponseModel> PersonGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPersonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonResponseModel>> PersonAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonResponseModel>> PersonBulkInsertAsync(List<ApiPersonRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/People/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonResponseModel>> GetPersonGetLastNameFirstNameMiddleName(string lastName,string firstName,string middleName)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/getLastNameFirstNameMiddleName/{lastName}/{firstName}/{middleName}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonResponseModel>> GetPersonGetAdditionalContactInfo(string additionalContactInfo)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/getAdditionalContactInfo/{additionalContactInfo}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonResponseModel>> GetPersonGetDemographics(string demographics)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/getDemographics/{demographics}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPersonPhoneResponseModel> PersonPhoneCreateAsync(ApiPersonPhoneRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonPhones", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPersonPhoneResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPersonPhoneResponseModel> PersonPhoneUpdateAsync(int id, ApiPersonPhoneRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PersonPhones/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPersonPhoneResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PersonPhoneDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PersonPhones/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiPersonPhoneResponseModel> PersonPhoneGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonPhones/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPersonPhoneResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonPhoneResponseModel>> PersonPhoneAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonPhones?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPersonPhoneResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonPhoneResponseModel>> PersonPhoneBulkInsertAsync(List<ApiPersonPhoneRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonPhones/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPersonPhoneResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonPhoneResponseModel>> GetPersonPhoneGetPhoneNumber(string phoneNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonPhones/getPhoneNumber/{phoneNumber}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPersonPhoneResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPhoneNumberTypeResponseModel> PhoneNumberTypeCreateAsync(ApiPhoneNumberTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PhoneNumberTypes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPhoneNumberTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPhoneNumberTypeResponseModel> PhoneNumberTypeUpdateAsync(int id, ApiPhoneNumberTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PhoneNumberTypes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPhoneNumberTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PhoneNumberTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PhoneNumberTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiPhoneNumberTypeResponseModel> PhoneNumberTypeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PhoneNumberTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPhoneNumberTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPhoneNumberTypeResponseModel>> PhoneNumberTypeAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PhoneNumberTypes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPhoneNumberTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPhoneNumberTypeResponseModel>> PhoneNumberTypeBulkInsertAsync(List<ApiPhoneNumberTypeRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PhoneNumberTypes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPhoneNumberTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiStateProvinceResponseModel> StateProvinceCreateAsync(ApiStateProvinceRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/StateProvinces", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiStateProvinceResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiStateProvinceResponseModel> StateProvinceUpdateAsync(int id, ApiStateProvinceRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/StateProvinces/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiStateProvinceResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task StateProvinceDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/StateProvinces/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiStateProvinceResponseModel> StateProvinceGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiStateProvinceResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStateProvinceResponseModel>> StateProvinceAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiStateProvinceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStateProvinceResponseModel>> StateProvinceBulkInsertAsync(List<ApiStateProvinceRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/StateProvinces/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiStateProvinceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiStateProvinceResponseModel> GetStateProvinceGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiStateProvinceResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiStateProvinceResponseModel> GetStateProvinceGetStateProvinceCodeCountryRegionCode(string stateProvinceCode,string countryRegionCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces/getStateProvinceCodeCountryRegionCode/{stateProvinceCode}/{countryRegionCode}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiStateProvinceResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBillOfMaterialsResponseModel> BillOfMaterialsCreateAsync(ApiBillOfMaterialsRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BillOfMaterials", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiBillOfMaterialsResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBillOfMaterialsResponseModel> BillOfMaterialsUpdateAsync(int id, ApiBillOfMaterialsRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/BillOfMaterials/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiBillOfMaterialsResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task BillOfMaterialsDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/BillOfMaterials/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiBillOfMaterialsResponseModel> BillOfMaterialsGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BillOfMaterials/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiBillOfMaterialsResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBillOfMaterialsResponseModel>> BillOfMaterialsAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BillOfMaterials?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiBillOfMaterialsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBillOfMaterialsResponseModel>> BillOfMaterialsBulkInsertAsync(List<ApiBillOfMaterialsRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BillOfMaterials/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiBillOfMaterialsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBillOfMaterialsResponseModel> GetBillOfMaterialsGetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID,int componentID,DateTime startDate)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BillOfMaterials/getProductAssemblyIDComponentIDStartDate/{productAssemblyID}/{componentID}/{startDate}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiBillOfMaterialsResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBillOfMaterialsResponseModel>> GetBillOfMaterialsGetUnitMeasureCode(string unitMeasureCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BillOfMaterials/getUnitMeasureCode/{unitMeasureCode}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiBillOfMaterialsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCultureResponseModel> CultureCreateAsync(ApiCultureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Cultures", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCultureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCultureResponseModel> CultureUpdateAsync(string id, ApiCultureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Cultures/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCultureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task CultureDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Cultures/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiCultureResponseModel> CultureGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cultures/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCultureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCultureResponseModel>> CultureAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cultures?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCultureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCultureResponseModel>> CultureBulkInsertAsync(List<ApiCultureRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Cultures/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCultureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCultureResponseModel> GetCultureGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cultures/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCultureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDocumentResponseModel> DocumentCreateAsync(ApiDocumentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Documents", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiDocumentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDocumentResponseModel> DocumentUpdateAsync(Guid id, ApiDocumentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Documents/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiDocumentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task DocumentDeleteAsync(Guid id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Documents/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiDocumentResponseModel> DocumentGetAsync(Guid id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Documents/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiDocumentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDocumentResponseModel>> DocumentAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Documents?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiDocumentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDocumentResponseModel>> DocumentBulkInsertAsync(List<ApiDocumentRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Documents/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiDocumentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDocumentResponseModel> GetDocumentGetDocumentLevelDocumentNode(Nullable<short> documentLevel,Guid documentNode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Documents/getDocumentLevelDocumentNode/{documentLevel}/{documentNode}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiDocumentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDocumentResponseModel>> GetDocumentGetFileNameRevision(string fileName,string revision)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Documents/getFileNameRevision/{fileName}/{revision}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiDocumentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiIllustrationResponseModel> IllustrationCreateAsync(ApiIllustrationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Illustrations", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiIllustrationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiIllustrationResponseModel> IllustrationUpdateAsync(int id, ApiIllustrationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Illustrations/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiIllustrationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task IllustrationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Illustrations/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiIllustrationResponseModel> IllustrationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Illustrations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiIllustrationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiIllustrationResponseModel>> IllustrationAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Illustrations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiIllustrationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiIllustrationResponseModel>> IllustrationBulkInsertAsync(List<ApiIllustrationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Illustrations/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiIllustrationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLocationResponseModel> LocationCreateAsync(ApiLocationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Locations", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiLocationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLocationResponseModel> LocationUpdateAsync(short id, ApiLocationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Locations/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiLocationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task LocationDeleteAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Locations/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiLocationResponseModel> LocationGetAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiLocationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLocationResponseModel>> LocationAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiLocationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLocationResponseModel>> LocationBulkInsertAsync(List<ApiLocationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Locations/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiLocationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLocationResponseModel> GetLocationGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiLocationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductResponseModel> ProductCreateAsync(ApiProductRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Products", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductResponseModel> ProductUpdateAsync(int id, ApiProductRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Products/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Products/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiProductResponseModel> ProductGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductResponseModel>> ProductAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductResponseModel>> ProductBulkInsertAsync(List<ApiProductRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Products/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductResponseModel> GetProductGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductResponseModel> GetProductGetProductNumber(string productNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/getProductNumber/{productNumber}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductCategoryResponseModel> ProductCategoryCreateAsync(ApiProductCategoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCategories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductCategoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductCategoryResponseModel> ProductCategoryUpdateAsync(int id, ApiProductCategoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductCategories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductCategoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductCategoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductCategories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiProductCategoryResponseModel> ProductCategoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCategories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductCategoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductCategoryResponseModel>> ProductCategoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCategories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductCategoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductCategoryResponseModel>> ProductCategoryBulkInsertAsync(List<ApiProductCategoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCategories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductCategoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductCategoryResponseModel> GetProductCategoryGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCategories/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductCategoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductCostHistoryResponseModel> ProductCostHistoryCreateAsync(ApiProductCostHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCostHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductCostHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductCostHistoryResponseModel> ProductCostHistoryUpdateAsync(int id, ApiProductCostHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductCostHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductCostHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductCostHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductCostHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiProductCostHistoryResponseModel> ProductCostHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCostHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductCostHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductCostHistoryResponseModel>> ProductCostHistoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCostHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductCostHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductCostHistoryResponseModel>> ProductCostHistoryBulkInsertAsync(List<ApiProductCostHistoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCostHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductCostHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductDescriptionResponseModel> ProductDescriptionCreateAsync(ApiProductDescriptionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductDescriptions", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductDescriptionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductDescriptionResponseModel> ProductDescriptionUpdateAsync(int id, ApiProductDescriptionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductDescriptions/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductDescriptionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductDescriptionDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductDescriptions/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiProductDescriptionResponseModel> ProductDescriptionGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDescriptions/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductDescriptionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductDescriptionResponseModel>> ProductDescriptionAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDescriptions?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductDescriptionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductDescriptionResponseModel>> ProductDescriptionBulkInsertAsync(List<ApiProductDescriptionRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductDescriptions/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductDescriptionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductDocumentResponseModel> ProductDocumentCreateAsync(ApiProductDocumentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductDocuments", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductDocumentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductDocumentResponseModel> ProductDocumentUpdateAsync(int id, ApiProductDocumentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductDocuments/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductDocumentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductDocumentDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductDocuments/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiProductDocumentResponseModel> ProductDocumentGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDocuments/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductDocumentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductDocumentResponseModel>> ProductDocumentAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDocuments?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductDocumentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductDocumentResponseModel>> ProductDocumentBulkInsertAsync(List<ApiProductDocumentRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductDocuments/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductDocumentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductInventoryResponseModel> ProductInventoryCreateAsync(ApiProductInventoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductInventories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductInventoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductInventoryResponseModel> ProductInventoryUpdateAsync(int id, ApiProductInventoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductInventories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductInventoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductInventoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductInventories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiProductInventoryResponseModel> ProductInventoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductInventories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductInventoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductInventoryResponseModel>> ProductInventoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductInventories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductInventoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductInventoryResponseModel>> ProductInventoryBulkInsertAsync(List<ApiProductInventoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductInventories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductInventoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductListPriceHistoryResponseModel> ProductListPriceHistoryCreateAsync(ApiProductListPriceHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductListPriceHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductListPriceHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductListPriceHistoryResponseModel> ProductListPriceHistoryUpdateAsync(int id, ApiProductListPriceHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductListPriceHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductListPriceHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductListPriceHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductListPriceHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiProductListPriceHistoryResponseModel> ProductListPriceHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductListPriceHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductListPriceHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductListPriceHistoryResponseModel>> ProductListPriceHistoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductListPriceHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductListPriceHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductListPriceHistoryResponseModel>> ProductListPriceHistoryBulkInsertAsync(List<ApiProductListPriceHistoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductListPriceHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductListPriceHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductModelResponseModel> ProductModelCreateAsync(ApiProductModelRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModels", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductModelResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductModelResponseModel> ProductModelUpdateAsync(int id, ApiProductModelRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductModels/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductModelResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductModelDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductModels/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiProductModelResponseModel> ProductModelGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductModelResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductModelResponseModel>> ProductModelAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductModelResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductModelResponseModel>> ProductModelBulkInsertAsync(List<ApiProductModelRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModels/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductModelResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductModelResponseModel> GetProductModelGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductModelResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductModelResponseModel>> GetProductModelGetCatalogDescription(string catalogDescription)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/getCatalogDescription/{catalogDescription}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductModelResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductModelResponseModel>> GetProductModelGetInstructions(string instructions)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/getInstructions/{instructions}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductModelResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductModelIllustrationResponseModel> ProductModelIllustrationCreateAsync(ApiProductModelIllustrationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModelIllustrations", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductModelIllustrationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductModelIllustrationResponseModel> ProductModelIllustrationUpdateAsync(int id, ApiProductModelIllustrationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductModelIllustrations/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductModelIllustrationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductModelIllustrationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductModelIllustrations/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiProductModelIllustrationResponseModel> ProductModelIllustrationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelIllustrations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductModelIllustrationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductModelIllustrationResponseModel>> ProductModelIllustrationAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelIllustrations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductModelIllustrationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductModelIllustrationResponseModel>> ProductModelIllustrationBulkInsertAsync(List<ApiProductModelIllustrationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModelIllustrations/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductModelIllustrationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductModelProductDescriptionCultureResponseModel> ProductModelProductDescriptionCultureCreateAsync(ApiProductModelProductDescriptionCultureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModelProductDescriptionCultures", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductModelProductDescriptionCultureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductModelProductDescriptionCultureResponseModel> ProductModelProductDescriptionCultureUpdateAsync(int id, ApiProductModelProductDescriptionCultureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductModelProductDescriptionCultures/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductModelProductDescriptionCultureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductModelProductDescriptionCultureDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductModelProductDescriptionCultures/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiProductModelProductDescriptionCultureResponseModel> ProductModelProductDescriptionCultureGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelProductDescriptionCultures/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductModelProductDescriptionCultureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultureAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelProductDescriptionCultures?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductModelProductDescriptionCultureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultureBulkInsertAsync(List<ApiProductModelProductDescriptionCultureRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModelProductDescriptionCultures/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductModelProductDescriptionCultureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductPhotoResponseModel> ProductPhotoCreateAsync(ApiProductPhotoRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductPhotoes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductPhotoResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductPhotoResponseModel> ProductPhotoUpdateAsync(int id, ApiProductPhotoRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductPhotoes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductPhotoResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductPhotoDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductPhotoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiProductPhotoResponseModel> ProductPhotoGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductPhotoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductPhotoResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductPhotoResponseModel>> ProductPhotoAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductPhotoes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductPhotoResponseModel>> ProductPhotoBulkInsertAsync(List<ApiProductPhotoRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductPhotoes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductProductPhotoResponseModel> ProductProductPhotoCreateAsync(ApiProductProductPhotoRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductProductPhotoes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductProductPhotoResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductProductPhotoResponseModel> ProductProductPhotoUpdateAsync(int id, ApiProductProductPhotoRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductProductPhotoes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductProductPhotoResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductProductPhotoDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductProductPhotoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiProductProductPhotoResponseModel> ProductProductPhotoGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductProductPhotoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductProductPhotoResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductProductPhotoResponseModel>> ProductProductPhotoAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductProductPhotoes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductProductPhotoResponseModel>> ProductProductPhotoBulkInsertAsync(List<ApiProductProductPhotoRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductProductPhotoes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductProductPhotoResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductReviewResponseModel> ProductReviewCreateAsync(ApiProductReviewRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductReviews", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductReviewResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductReviewResponseModel> ProductReviewUpdateAsync(int id, ApiProductReviewRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductReviews/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductReviewResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductReviewDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductReviews/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiProductReviewResponseModel> ProductReviewGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductReviews/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductReviewResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductReviewResponseModel>> ProductReviewAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductReviews?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductReviewResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductReviewResponseModel>> ProductReviewBulkInsertAsync(List<ApiProductReviewRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductReviews/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductReviewResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductReviewResponseModel>> GetProductReviewGetCommentsProductIDReviewerName(string comments,int productID,string reviewerName)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductReviews/getCommentsProductIDReviewerName/{comments}/{productID}/{reviewerName}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductReviewResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductSubcategoryResponseModel> ProductSubcategoryCreateAsync(ApiProductSubcategoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductSubcategories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductSubcategoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductSubcategoryResponseModel> ProductSubcategoryUpdateAsync(int id, ApiProductSubcategoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductSubcategories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductSubcategoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductSubcategoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductSubcategories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiProductSubcategoryResponseModel> ProductSubcategoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductSubcategories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductSubcategoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductSubcategoryResponseModel>> ProductSubcategoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductSubcategories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductSubcategoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductSubcategoryResponseModel>> ProductSubcategoryBulkInsertAsync(List<ApiProductSubcategoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductSubcategories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductSubcategoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductSubcategoryResponseModel> GetProductSubcategoryGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductSubcategories/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductSubcategoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiScrapReasonResponseModel> ScrapReasonCreateAsync(ApiScrapReasonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ScrapReasons", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiScrapReasonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiScrapReasonResponseModel> ScrapReasonUpdateAsync(short id, ApiScrapReasonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ScrapReasons/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiScrapReasonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ScrapReasonDeleteAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ScrapReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiScrapReasonResponseModel> ScrapReasonGetAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ScrapReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiScrapReasonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiScrapReasonResponseModel>> ScrapReasonAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ScrapReasons?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiScrapReasonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiScrapReasonResponseModel>> ScrapReasonBulkInsertAsync(List<ApiScrapReasonRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ScrapReasons/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiScrapReasonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiScrapReasonResponseModel> GetScrapReasonGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ScrapReasons/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiScrapReasonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTransactionHistoryResponseModel> TransactionHistoryCreateAsync(ApiTransactionHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiTransactionHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTransactionHistoryResponseModel> TransactionHistoryUpdateAsync(int id, ApiTransactionHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TransactionHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiTransactionHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task TransactionHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TransactionHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiTransactionHistoryResponseModel> TransactionHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiTransactionHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionHistoryResponseModel>> TransactionHistoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiTransactionHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionHistoryResponseModel>> TransactionHistoryBulkInsertAsync(List<ApiTransactionHistoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiTransactionHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionHistoryResponseModel>> GetTransactionHistoryGetProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories/getProductID/{productID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiTransactionHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionHistoryResponseModel>> GetTransactionHistoryGetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories/getReferenceOrderIDReferenceOrderLineID/{referenceOrderID}/{referenceOrderLineID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiTransactionHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTransactionHistoryArchiveResponseModel> TransactionHistoryArchiveCreateAsync(ApiTransactionHistoryArchiveRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistoryArchives", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiTransactionHistoryArchiveResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTransactionHistoryArchiveResponseModel> TransactionHistoryArchiveUpdateAsync(int id, ApiTransactionHistoryArchiveRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TransactionHistoryArchives/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiTransactionHistoryArchiveResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task TransactionHistoryArchiveDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TransactionHistoryArchives/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiTransactionHistoryArchiveResponseModel> TransactionHistoryArchiveGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiTransactionHistoryArchiveResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionHistoryArchiveResponseModel>> TransactionHistoryArchiveAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiTransactionHistoryArchiveResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionHistoryArchiveResponseModel>> TransactionHistoryArchiveBulkInsertAsync(List<ApiTransactionHistoryArchiveRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistoryArchives/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiTransactionHistoryArchiveResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionHistoryArchiveResponseModel>> GetTransactionHistoryArchiveGetProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives/getProductID/{productID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiTransactionHistoryArchiveResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTransactionHistoryArchiveResponseModel>> GetTransactionHistoryArchiveGetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives/getReferenceOrderIDReferenceOrderLineID/{referenceOrderID}/{referenceOrderLineID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiTransactionHistoryArchiveResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiUnitMeasureResponseModel> UnitMeasureCreateAsync(ApiUnitMeasureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/UnitMeasures", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiUnitMeasureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiUnitMeasureResponseModel> UnitMeasureUpdateAsync(string id, ApiUnitMeasureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/UnitMeasures/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiUnitMeasureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task UnitMeasureDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/UnitMeasures/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiUnitMeasureResponseModel> UnitMeasureGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UnitMeasures/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiUnitMeasureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUnitMeasureResponseModel>> UnitMeasureAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UnitMeasures?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiUnitMeasureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUnitMeasureResponseModel>> UnitMeasureBulkInsertAsync(List<ApiUnitMeasureRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/UnitMeasures/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiUnitMeasureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiUnitMeasureResponseModel> GetUnitMeasureGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UnitMeasures/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiUnitMeasureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiWorkOrderResponseModel> WorkOrderCreateAsync(ApiWorkOrderRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrders", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiWorkOrderResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiWorkOrderResponseModel> WorkOrderUpdateAsync(int id, ApiWorkOrderRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/WorkOrders/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiWorkOrderResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task WorkOrderDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/WorkOrders/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiWorkOrderResponseModel> WorkOrderGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiWorkOrderResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkOrderResponseModel>> WorkOrderAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiWorkOrderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkOrderResponseModel>> WorkOrderBulkInsertAsync(List<ApiWorkOrderRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrders/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiWorkOrderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkOrderResponseModel>> GetWorkOrderGetProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders/getProductID/{productID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiWorkOrderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkOrderResponseModel>> GetWorkOrderGetScrapReasonID(Nullable<short> scrapReasonID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders/getScrapReasonID/{scrapReasonID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiWorkOrderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiWorkOrderRoutingResponseModel> WorkOrderRoutingCreateAsync(ApiWorkOrderRoutingRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrderRoutings", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiWorkOrderRoutingResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiWorkOrderRoutingResponseModel> WorkOrderRoutingUpdateAsync(int id, ApiWorkOrderRoutingRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/WorkOrderRoutings/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiWorkOrderRoutingResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task WorkOrderRoutingDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/WorkOrderRoutings/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiWorkOrderRoutingResponseModel> WorkOrderRoutingGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrderRoutings/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiWorkOrderRoutingResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutingAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrderRoutings?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiWorkOrderRoutingResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutingBulkInsertAsync(List<ApiWorkOrderRoutingRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrderRoutings/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiWorkOrderRoutingResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiWorkOrderRoutingResponseModel>> GetWorkOrderRoutingGetProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrderRoutings/getProductID/{productID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiWorkOrderRoutingResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductVendorResponseModel> ProductVendorCreateAsync(ApiProductVendorRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductVendors", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductVendorResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiProductVendorResponseModel> ProductVendorUpdateAsync(int id, ApiProductVendorRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductVendors/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductVendorResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductVendorDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductVendors/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiProductVendorResponseModel> ProductVendorGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiProductVendorResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductVendorResponseModel>> ProductVendorAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductVendorResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductVendorResponseModel>> ProductVendorBulkInsertAsync(List<ApiProductVendorRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductVendors/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductVendorResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductVendorResponseModel>> GetProductVendorGetBusinessEntityID(int businessEntityID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors/getBusinessEntityID/{businessEntityID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductVendorResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiProductVendorResponseModel>> GetProductVendorGetUnitMeasureCode(string unitMeasureCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors/getUnitMeasureCode/{unitMeasureCode}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiProductVendorResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPurchaseOrderDetailResponseModel> PurchaseOrderDetailCreateAsync(ApiPurchaseOrderDetailRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderDetails", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPurchaseOrderDetailResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPurchaseOrderDetailResponseModel> PurchaseOrderDetailUpdateAsync(int id, ApiPurchaseOrderDetailRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PurchaseOrderDetails/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPurchaseOrderDetailResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PurchaseOrderDetailDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PurchaseOrderDetails/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiPurchaseOrderDetailResponseModel> PurchaseOrderDetailGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderDetails/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPurchaseOrderDetailResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPurchaseOrderDetailResponseModel>> PurchaseOrderDetailAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderDetails?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPurchaseOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPurchaseOrderDetailResponseModel>> PurchaseOrderDetailBulkInsertAsync(List<ApiPurchaseOrderDetailRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderDetails/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPurchaseOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPurchaseOrderDetailResponseModel>> GetPurchaseOrderDetailGetProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderDetails/getProductID/{productID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPurchaseOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPurchaseOrderHeaderResponseModel> PurchaseOrderHeaderCreateAsync(ApiPurchaseOrderHeaderRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderHeaders", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPurchaseOrderHeaderResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPurchaseOrderHeaderResponseModel> PurchaseOrderHeaderUpdateAsync(int id, ApiPurchaseOrderHeaderRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PurchaseOrderHeaders/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPurchaseOrderHeaderResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PurchaseOrderHeaderDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PurchaseOrderHeaders/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiPurchaseOrderHeaderResponseModel> PurchaseOrderHeaderGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPurchaseOrderHeaderResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeaderAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPurchaseOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeaderBulkInsertAsync(List<ApiPurchaseOrderHeaderRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderHeaders/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPurchaseOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> GetPurchaseOrderHeaderGetEmployeeID(int employeeID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders/getEmployeeID/{employeeID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPurchaseOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> GetPurchaseOrderHeaderGetVendorID(int vendorID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders/getVendorID/{vendorID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPurchaseOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiShipMethodResponseModel> ShipMethodCreateAsync(ApiShipMethodRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShipMethods", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiShipMethodResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiShipMethodResponseModel> ShipMethodUpdateAsync(int id, ApiShipMethodRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ShipMethods/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiShipMethodResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ShipMethodDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ShipMethods/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiShipMethodResponseModel> ShipMethodGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShipMethods/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiShipMethodResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiShipMethodResponseModel>> ShipMethodAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShipMethods?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiShipMethodResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiShipMethodResponseModel>> ShipMethodBulkInsertAsync(List<ApiShipMethodRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShipMethods/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiShipMethodResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiShipMethodResponseModel> GetShipMethodGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShipMethods/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiShipMethodResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVendorResponseModel> VendorCreateAsync(ApiVendorRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Vendors", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiVendorResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVendorResponseModel> VendorUpdateAsync(int id, ApiVendorRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Vendors/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiVendorResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task VendorDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Vendors/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiVendorResponseModel> VendorGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Vendors/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiVendorResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVendorResponseModel>> VendorAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Vendors?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiVendorResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVendorResponseModel>> VendorBulkInsertAsync(List<ApiVendorRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Vendors/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiVendorResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVendorResponseModel> GetVendorGetAccountNumber(string accountNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Vendors/getAccountNumber/{accountNumber}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiVendorResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCountryRegionCurrencyResponseModel> CountryRegionCurrencyCreateAsync(ApiCountryRegionCurrencyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRegionCurrencies", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCountryRegionCurrencyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCountryRegionCurrencyResponseModel> CountryRegionCurrencyUpdateAsync(string id, ApiCountryRegionCurrencyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CountryRegionCurrencies/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCountryRegionCurrencyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task CountryRegionCurrencyDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CountryRegionCurrencies/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiCountryRegionCurrencyResponseModel> CountryRegionCurrencyGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegionCurrencies/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCountryRegionCurrencyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCountryRegionCurrencyResponseModel>> CountryRegionCurrencyAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegionCurrencies?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCountryRegionCurrencyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCountryRegionCurrencyResponseModel>> CountryRegionCurrencyBulkInsertAsync(List<ApiCountryRegionCurrencyRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRegionCurrencies/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCountryRegionCurrencyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCountryRegionCurrencyResponseModel>> GetCountryRegionCurrencyGetCurrencyCode(string currencyCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegionCurrencies/getCurrencyCode/{currencyCode}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCountryRegionCurrencyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCreditCardResponseModel> CreditCardCreateAsync(ApiCreditCardRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CreditCards", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCreditCardResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCreditCardResponseModel> CreditCardUpdateAsync(int id, ApiCreditCardRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CreditCards/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCreditCardResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task CreditCardDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CreditCards/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiCreditCardResponseModel> CreditCardGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CreditCards/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCreditCardResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCreditCardResponseModel>> CreditCardAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CreditCards?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCreditCardResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCreditCardResponseModel>> CreditCardBulkInsertAsync(List<ApiCreditCardRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CreditCards/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCreditCardResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCreditCardResponseModel> GetCreditCardGetCardNumber(string cardNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CreditCards/getCardNumber/{cardNumber}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCreditCardResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCurrencyResponseModel> CurrencyCreateAsync(ApiCurrencyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Currencies", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCurrencyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCurrencyResponseModel> CurrencyUpdateAsync(string id, ApiCurrencyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Currencies/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCurrencyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task CurrencyDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Currencies/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiCurrencyResponseModel> CurrencyGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCurrencyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCurrencyResponseModel>> CurrencyAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCurrencyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCurrencyResponseModel>> CurrencyBulkInsertAsync(List<ApiCurrencyRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Currencies/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCurrencyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCurrencyResponseModel> GetCurrencyGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCurrencyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCurrencyRateResponseModel> CurrencyRateCreateAsync(ApiCurrencyRateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CurrencyRates", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCurrencyRateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCurrencyRateResponseModel> CurrencyRateUpdateAsync(int id, ApiCurrencyRateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CurrencyRates/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCurrencyRateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task CurrencyRateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CurrencyRates/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiCurrencyRateResponseModel> CurrencyRateGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CurrencyRates/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCurrencyRateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCurrencyRateResponseModel>> CurrencyRateAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CurrencyRates?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCurrencyRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCurrencyRateResponseModel>> CurrencyRateBulkInsertAsync(List<ApiCurrencyRateRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CurrencyRates/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCurrencyRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCurrencyRateResponseModel> GetCurrencyRateGetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate,string fromCurrencyCode,string toCurrencyCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CurrencyRates/getCurrencyRateDateFromCurrencyCodeToCurrencyCode/{currencyRateDate}/{fromCurrencyCode}/{toCurrencyCode}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCurrencyRateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCustomerResponseModel> CustomerCreateAsync(ApiCustomerRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Customers", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCustomerResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCustomerResponseModel> CustomerUpdateAsync(int id, ApiCustomerRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Customers/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCustomerResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task CustomerDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Customers/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiCustomerResponseModel> CustomerGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCustomerResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCustomerResponseModel>> CustomerAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCustomerResponseModel>> CustomerBulkInsertAsync(List<ApiCustomerRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Customers/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCustomerResponseModel> GetCustomerGetAccountNumber(string accountNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers/getAccountNumber/{accountNumber}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiCustomerResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCustomerResponseModel>> GetCustomerGetTerritoryID(Nullable<int> territoryID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers/getTerritoryID/{territoryID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiCustomerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPersonCreditCardResponseModel> PersonCreditCardCreateAsync(ApiPersonCreditCardRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonCreditCards", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPersonCreditCardResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPersonCreditCardResponseModel> PersonCreditCardUpdateAsync(int id, ApiPersonCreditCardRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PersonCreditCards/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPersonCreditCardResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PersonCreditCardDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PersonCreditCards/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiPersonCreditCardResponseModel> PersonCreditCardGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonCreditCards/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiPersonCreditCardResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonCreditCardResponseModel>> PersonCreditCardAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonCreditCards?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPersonCreditCardResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonCreditCardResponseModel>> PersonCreditCardBulkInsertAsync(List<ApiPersonCreditCardRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonCreditCards/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiPersonCreditCardResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesOrderDetailResponseModel> SalesOrderDetailCreateAsync(ApiSalesOrderDetailRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderDetails", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesOrderDetailResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesOrderDetailResponseModel> SalesOrderDetailUpdateAsync(int id, ApiSalesOrderDetailRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesOrderDetails/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesOrderDetailResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesOrderDetailDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesOrderDetails/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiSalesOrderDetailResponseModel> SalesOrderDetailGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderDetails/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesOrderDetailResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderDetailResponseModel>> SalesOrderDetailAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderDetails?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderDetailResponseModel>> SalesOrderDetailBulkInsertAsync(List<ApiSalesOrderDetailRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderDetails/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderDetailResponseModel>> GetSalesOrderDetailGetProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderDetails/getProductID/{productID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesOrderDetailResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesOrderHeaderResponseModel> SalesOrderHeaderCreateAsync(ApiSalesOrderHeaderRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderHeaders", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesOrderHeaderResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesOrderHeaderResponseModel> SalesOrderHeaderUpdateAsync(int id, ApiSalesOrderHeaderRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesOrderHeaders/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesOrderHeaderResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesOrderHeaderDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesOrderHeaders/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiSalesOrderHeaderResponseModel> SalesOrderHeaderGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesOrderHeaderResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaderAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaderBulkInsertAsync(List<ApiSalesOrderHeaderRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderHeaders/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesOrderHeaderResponseModel> GetSalesOrderHeaderGetSalesOrderNumber(string salesOrderNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/getSalesOrderNumber/{salesOrderNumber}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesOrderHeaderResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> GetSalesOrderHeaderGetCustomerID(int customerID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/getCustomerID/{customerID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> GetSalesOrderHeaderGetSalesPersonID(Nullable<int> salesPersonID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/getSalesPersonID/{salesPersonID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesOrderHeaderSalesReasonResponseModel> SalesOrderHeaderSalesReasonCreateAsync(ApiSalesOrderHeaderSalesReasonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderHeaderSalesReasons", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesOrderHeaderSalesReasonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesOrderHeaderSalesReasonResponseModel> SalesOrderHeaderSalesReasonUpdateAsync(int id, ApiSalesOrderHeaderSalesReasonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesOrderHeaderSalesReasons/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesOrderHeaderSalesReasonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesOrderHeaderSalesReasonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesOrderHeaderSalesReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiSalesOrderHeaderSalesReasonResponseModel> SalesOrderHeaderSalesReasonGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaderSalesReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesOrderHeaderSalesReasonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> SalesOrderHeaderSalesReasonAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaderSalesReasons?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderSalesReasonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> SalesOrderHeaderSalesReasonBulkInsertAsync(List<ApiSalesOrderHeaderSalesReasonRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderHeaderSalesReasons/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesOrderHeaderSalesReasonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesPersonResponseModel> SalesPersonCreateAsync(ApiSalesPersonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersons", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesPersonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesPersonResponseModel> SalesPersonUpdateAsync(int id, ApiSalesPersonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesPersons/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesPersonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesPersonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesPersons/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiSalesPersonResponseModel> SalesPersonGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersons/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesPersonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesPersonResponseModel>> SalesPersonAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersons?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesPersonResponseModel>> SalesPersonBulkInsertAsync(List<ApiSalesPersonRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersons/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesPersonQuotaHistoryResponseModel> SalesPersonQuotaHistoryCreateAsync(ApiSalesPersonQuotaHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersonQuotaHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesPersonQuotaHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesPersonQuotaHistoryResponseModel> SalesPersonQuotaHistoryUpdateAsync(int id, ApiSalesPersonQuotaHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesPersonQuotaHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesPersonQuotaHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesPersonQuotaHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesPersonQuotaHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiSalesPersonQuotaHistoryResponseModel> SalesPersonQuotaHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersonQuotaHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesPersonQuotaHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesPersonQuotaHistoryResponseModel>> SalesPersonQuotaHistoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersonQuotaHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesPersonQuotaHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesPersonQuotaHistoryResponseModel>> SalesPersonQuotaHistoryBulkInsertAsync(List<ApiSalesPersonQuotaHistoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersonQuotaHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesPersonQuotaHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesReasonResponseModel> SalesReasonCreateAsync(ApiSalesReasonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesReasons", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesReasonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesReasonResponseModel> SalesReasonUpdateAsync(int id, ApiSalesReasonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesReasons/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesReasonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesReasonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiSalesReasonResponseModel> SalesReasonGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesReasonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesReasonResponseModel>> SalesReasonAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesReasons?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesReasonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesReasonResponseModel>> SalesReasonBulkInsertAsync(List<ApiSalesReasonRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesReasons/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesReasonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesTaxRateResponseModel> SalesTaxRateCreateAsync(ApiSalesTaxRateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTaxRates", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesTaxRateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesTaxRateResponseModel> SalesTaxRateUpdateAsync(int id, ApiSalesTaxRateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesTaxRates/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesTaxRateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesTaxRateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesTaxRates/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiSalesTaxRateResponseModel> SalesTaxRateGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTaxRates/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesTaxRateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesTaxRateResponseModel>> SalesTaxRateAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTaxRates?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesTaxRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesTaxRateResponseModel>> SalesTaxRateBulkInsertAsync(List<ApiSalesTaxRateRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTaxRates/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesTaxRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesTaxRateResponseModel> GetSalesTaxRateGetStateProvinceIDTaxType(int stateProvinceID,int taxType)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTaxRates/getStateProvinceIDTaxType/{stateProvinceID}/{taxType}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesTaxRateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesTerritoryResponseModel> SalesTerritoryCreateAsync(ApiSalesTerritoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesTerritoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesTerritoryResponseModel> SalesTerritoryUpdateAsync(int id, ApiSalesTerritoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesTerritories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesTerritoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesTerritoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesTerritories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiSalesTerritoryResponseModel> SalesTerritoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesTerritoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesTerritoryResponseModel>> SalesTerritoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesTerritoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesTerritoryResponseModel>> SalesTerritoryBulkInsertAsync(List<ApiSalesTerritoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesTerritoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesTerritoryResponseModel> GetSalesTerritoryGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesTerritoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesTerritoryHistoryResponseModel> SalesTerritoryHistoryCreateAsync(ApiSalesTerritoryHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritoryHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesTerritoryHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSalesTerritoryHistoryResponseModel> SalesTerritoryHistoryUpdateAsync(int id, ApiSalesTerritoryHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesTerritoryHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesTerritoryHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesTerritoryHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesTerritoryHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiSalesTerritoryHistoryResponseModel> SalesTerritoryHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritoryHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSalesTerritoryHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritoryHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesTerritoryHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistoryBulkInsertAsync(List<ApiSalesTerritoryHistoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritoryHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSalesTerritoryHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiShoppingCartItemResponseModel> ShoppingCartItemCreateAsync(ApiShoppingCartItemRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShoppingCartItems", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiShoppingCartItemResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiShoppingCartItemResponseModel> ShoppingCartItemUpdateAsync(int id, ApiShoppingCartItemRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ShoppingCartItems/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiShoppingCartItemResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ShoppingCartItemDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ShoppingCartItems/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiShoppingCartItemResponseModel> ShoppingCartItemGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShoppingCartItems/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiShoppingCartItemResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiShoppingCartItemResponseModel>> ShoppingCartItemAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShoppingCartItems?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiShoppingCartItemResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiShoppingCartItemResponseModel>> ShoppingCartItemBulkInsertAsync(List<ApiShoppingCartItemRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShoppingCartItems/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiShoppingCartItemResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiShoppingCartItemResponseModel>> GetShoppingCartItemGetShoppingCartIDProductID(string shoppingCartID,int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShoppingCartItems/getShoppingCartIDProductID/{shoppingCartID}/{productID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiShoppingCartItemResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSpecialOfferResponseModel> SpecialOfferCreateAsync(ApiSpecialOfferRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOffers", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSpecialOfferResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSpecialOfferResponseModel> SpecialOfferUpdateAsync(int id, ApiSpecialOfferRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SpecialOffers/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSpecialOfferResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SpecialOfferDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SpecialOffers/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiSpecialOfferResponseModel> SpecialOfferGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOffers/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSpecialOfferResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpecialOfferResponseModel>> SpecialOfferAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOffers?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSpecialOfferResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpecialOfferResponseModel>> SpecialOfferBulkInsertAsync(List<ApiSpecialOfferRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOffers/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSpecialOfferResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSpecialOfferProductResponseModel> SpecialOfferProductCreateAsync(ApiSpecialOfferProductRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOfferProducts", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSpecialOfferProductResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSpecialOfferProductResponseModel> SpecialOfferProductUpdateAsync(int id, ApiSpecialOfferProductRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SpecialOfferProducts/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSpecialOfferProductResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SpecialOfferProductDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SpecialOfferProducts/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiSpecialOfferProductResponseModel> SpecialOfferProductGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOfferProducts/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiSpecialOfferProductResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpecialOfferProductResponseModel>> SpecialOfferProductAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOfferProducts?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSpecialOfferProductResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpecialOfferProductResponseModel>> SpecialOfferProductBulkInsertAsync(List<ApiSpecialOfferProductRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOfferProducts/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSpecialOfferProductResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpecialOfferProductResponseModel>> GetSpecialOfferProductGetProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOfferProducts/getProductID/{productID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiSpecialOfferProductResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiStoreResponseModel> StoreCreateAsync(ApiStoreRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Stores", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiStoreResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiStoreResponseModel> StoreUpdateAsync(int id, ApiStoreRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Stores/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiStoreResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task StoreDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Stores/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<ApiStoreResponseModel> StoreGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<ApiStoreResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStoreResponseModel>> StoreAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiStoreResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStoreResponseModel>> StoreBulkInsertAsync(List<ApiStoreRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Stores/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiStoreResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStoreResponseModel>> GetStoreGetSalesPersonID(Nullable<int> salesPersonID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores/getSalesPersonID/{salesPersonID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiStoreResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStoreResponseModel>> GetStoreGetDemographics(string demographics)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores/getDemographics/{demographics}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<ApiStoreResponseModel>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>15238579f94713e018b6fbcb5bea67e4</Hash>
</Codenesium>*/