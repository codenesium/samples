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

		public virtual async Task<POCOAWBuildVersion> AWBuildVersionCreateAsync(ApiAWBuildVersionModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AWBuildVersions", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAWBuildVersion>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAWBuildVersion> AWBuildVersionUpdateAsync(int id, ApiAWBuildVersionModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/AWBuildVersions/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAWBuildVersion>(httpResponse.Content.ContentToString());
		}

		public virtual async Task AWBuildVersionDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/AWBuildVersions/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOAWBuildVersion> AWBuildVersionGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AWBuildVersions/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAWBuildVersion>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOAWBuildVersion>> AWBuildVersionAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AWBuildVersions?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAWBuildVersion>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOAWBuildVersion>> AWBuildVersionBulkInsertAsync(List<ApiAWBuildVersionModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AWBuildVersions/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAWBuildVersion>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODatabaseLog> DatabaseLogCreateAsync(ApiDatabaseLogModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DatabaseLogs", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODatabaseLog>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODatabaseLog> DatabaseLogUpdateAsync(int id, ApiDatabaseLogModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/DatabaseLogs/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODatabaseLog>(httpResponse.Content.ContentToString());
		}

		public virtual async Task DatabaseLogDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/DatabaseLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCODatabaseLog> DatabaseLogGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DatabaseLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODatabaseLog>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCODatabaseLog>> DatabaseLogAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DatabaseLogs?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCODatabaseLog>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCODatabaseLog>> DatabaseLogBulkInsertAsync(List<ApiDatabaseLogModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DatabaseLogs/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCODatabaseLog>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOErrorLog> ErrorLogCreateAsync(ApiErrorLogModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ErrorLogs", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOErrorLog>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOErrorLog> ErrorLogUpdateAsync(int id, ApiErrorLogModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ErrorLogs/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOErrorLog>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ErrorLogDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ErrorLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOErrorLog> ErrorLogGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ErrorLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOErrorLog>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOErrorLog>> ErrorLogAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ErrorLogs?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOErrorLog>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOErrorLog>> ErrorLogBulkInsertAsync(List<ApiErrorLogModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ErrorLogs/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOErrorLog>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODepartment> DepartmentCreateAsync(ApiDepartmentModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Departments", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODepartment>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODepartment> DepartmentUpdateAsync(short id, ApiDepartmentModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Departments/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODepartment>(httpResponse.Content.ContentToString());
		}

		public virtual async Task DepartmentDeleteAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Departments/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCODepartment> DepartmentGetAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Departments/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODepartment>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCODepartment>> DepartmentAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Departments?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCODepartment>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCODepartment>> DepartmentBulkInsertAsync(List<ApiDepartmentModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Departments/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCODepartment>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODepartment> GetDepartmentGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Departments/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODepartment>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployee> EmployeeCreateAsync(ApiEmployeeModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Employees", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployee>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployee> EmployeeUpdateAsync(int id, ApiEmployeeModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Employees/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployee>(httpResponse.Content.ContentToString());
		}

		public virtual async Task EmployeeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Employees/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOEmployee> EmployeeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployee>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmployee>> EmployeeAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmployee>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmployee>> EmployeeBulkInsertAsync(List<ApiEmployeeModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Employees/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmployee>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployee> GetEmployeeGetLoginID(string loginID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/getLoginID/{loginID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployee>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployee> GetEmployeeGetNationalIDNumber(string nationalIDNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/getNationalIDNumber/{nationalIDNumber}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployee>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmployee>> GetEmployeeGetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel,Nullable<Guid> organizationNode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/getOrganizationLevelOrganizationNode/{organizationLevel}/{organizationNode}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmployee>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmployee>> GetEmployeeGetOrganizationNode(Nullable<Guid> organizationNode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/getOrganizationNode/{organizationNode}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmployee>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployeeDepartmentHistory> EmployeeDepartmentHistoryCreateAsync(ApiEmployeeDepartmentHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeeDepartmentHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployeeDepartmentHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployeeDepartmentHistory> EmployeeDepartmentHistoryUpdateAsync(int id, ApiEmployeeDepartmentHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/EmployeeDepartmentHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployeeDepartmentHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task EmployeeDepartmentHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/EmployeeDepartmentHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOEmployeeDepartmentHistory> EmployeeDepartmentHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployeeDepartmentHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmployeeDepartmentHistory>> EmployeeDepartmentHistoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmployeeDepartmentHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmployeeDepartmentHistory>> EmployeeDepartmentHistoryBulkInsertAsync(List<ApiEmployeeDepartmentHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeeDepartmentHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmployeeDepartmentHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmployeeDepartmentHistory>> GetEmployeeDepartmentHistoryGetDepartmentID(short departmentID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories/getDepartmentID/{departmentID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmployeeDepartmentHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmployeeDepartmentHistory>> GetEmployeeDepartmentHistoryGetShiftID(int shiftID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories/getShiftID/{shiftID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmployeeDepartmentHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployeePayHistory> EmployeePayHistoryCreateAsync(ApiEmployeePayHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeePayHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployeePayHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployeePayHistory> EmployeePayHistoryUpdateAsync(int id, ApiEmployeePayHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/EmployeePayHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployeePayHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task EmployeePayHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/EmployeePayHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOEmployeePayHistory> EmployeePayHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeePayHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployeePayHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmployeePayHistory>> EmployeePayHistoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeePayHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmployeePayHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmployeePayHistory>> EmployeePayHistoryBulkInsertAsync(List<ApiEmployeePayHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeePayHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmployeePayHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOJobCandidate> JobCandidateCreateAsync(ApiJobCandidateModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/JobCandidates", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOJobCandidate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOJobCandidate> JobCandidateUpdateAsync(int id, ApiJobCandidateModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/JobCandidates/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOJobCandidate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task JobCandidateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/JobCandidates/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOJobCandidate> JobCandidateGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/JobCandidates/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOJobCandidate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOJobCandidate>> JobCandidateAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/JobCandidates?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOJobCandidate>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOJobCandidate>> JobCandidateBulkInsertAsync(List<ApiJobCandidateModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/JobCandidates/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOJobCandidate>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOJobCandidate>> GetJobCandidateGetBusinessEntityID(Nullable<int> businessEntityID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/JobCandidates/getBusinessEntityID/{businessEntityID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOJobCandidate>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOShift> ShiftCreateAsync(ApiShiftModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Shifts", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOShift>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOShift> ShiftUpdateAsync(int id, ApiShiftModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Shifts/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOShift>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ShiftDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Shifts/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOShift> ShiftGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOShift>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOShift>> ShiftAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOShift>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOShift>> ShiftBulkInsertAsync(List<ApiShiftModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Shifts/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOShift>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOShift> GetShiftGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOShift>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOShift> GetShiftGetStartTimeEndTime(TimeSpan startTime,TimeSpan endTime)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts/getStartTimeEndTime/{startTime}/{endTime}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOShift>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAddress> AddressCreateAsync(ApiAddressModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Addresses", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAddress>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAddress> AddressUpdateAsync(int id, ApiAddressModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Addresses/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAddress>(httpResponse.Content.ContentToString());
		}

		public virtual async Task AddressDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Addresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOAddress> AddressGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAddress>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOAddress>> AddressAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAddress>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOAddress>> AddressBulkInsertAsync(List<ApiAddressModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Addresses/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAddress>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAddress> GetAddressGetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1,string addressLine2,string city,int stateProvinceID,string postalCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses/getAddressLine1AddressLine2CityStateProvinceIDPostalCode/{addressLine1}/{addressLine2}/{city}/{stateProvinceID}/{postalCode}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAddress>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOAddress>> GetAddressGetStateProvinceID(int stateProvinceID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses/getStateProvinceID/{stateProvinceID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAddress>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAddressType> AddressTypeCreateAsync(ApiAddressTypeModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AddressTypes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAddressType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAddressType> AddressTypeUpdateAsync(int id, ApiAddressTypeModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/AddressTypes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAddressType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task AddressTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/AddressTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOAddressType> AddressTypeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AddressTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAddressType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOAddressType>> AddressTypeAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AddressTypes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAddressType>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOAddressType>> AddressTypeBulkInsertAsync(List<ApiAddressTypeModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AddressTypes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAddressType>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAddressType> GetAddressTypeGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AddressTypes/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAddressType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBusinessEntity> BusinessEntityCreateAsync(ApiBusinessEntityModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntities", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBusinessEntity>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBusinessEntity> BusinessEntityUpdateAsync(int id, ApiBusinessEntityModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/BusinessEntities/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBusinessEntity>(httpResponse.Content.ContentToString());
		}

		public virtual async Task BusinessEntityDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/BusinessEntities/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOBusinessEntity> BusinessEntityGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntities/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBusinessEntity>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBusinessEntity>> BusinessEntityAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntities?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBusinessEntity>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBusinessEntity>> BusinessEntityBulkInsertAsync(List<ApiBusinessEntityModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntities/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBusinessEntity>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBusinessEntityAddress> BusinessEntityAddressCreateAsync(ApiBusinessEntityAddressModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityAddresses", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBusinessEntityAddress>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBusinessEntityAddress> BusinessEntityAddressUpdateAsync(int id, ApiBusinessEntityAddressModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/BusinessEntityAddresses/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBusinessEntityAddress>(httpResponse.Content.ContentToString());
		}

		public virtual async Task BusinessEntityAddressDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/BusinessEntityAddresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOBusinessEntityAddress> BusinessEntityAddressGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBusinessEntityAddress>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBusinessEntityAddress>> BusinessEntityAddressAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBusinessEntityAddress>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBusinessEntityAddress>> BusinessEntityAddressBulkInsertAsync(List<ApiBusinessEntityAddressModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityAddresses/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBusinessEntityAddress>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBusinessEntityAddress>> GetBusinessEntityAddressGetAddressID(int addressID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses/getAddressID/{addressID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBusinessEntityAddress>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBusinessEntityAddress>> GetBusinessEntityAddressGetAddressTypeID(int addressTypeID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses/getAddressTypeID/{addressTypeID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBusinessEntityAddress>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBusinessEntityContact> BusinessEntityContactCreateAsync(ApiBusinessEntityContactModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityContacts", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBusinessEntityContact>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBusinessEntityContact> BusinessEntityContactUpdateAsync(int id, ApiBusinessEntityContactModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/BusinessEntityContacts/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBusinessEntityContact>(httpResponse.Content.ContentToString());
		}

		public virtual async Task BusinessEntityContactDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/BusinessEntityContacts/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOBusinessEntityContact> BusinessEntityContactGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBusinessEntityContact>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBusinessEntityContact>> BusinessEntityContactAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBusinessEntityContact>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBusinessEntityContact>> BusinessEntityContactBulkInsertAsync(List<ApiBusinessEntityContactModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityContacts/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBusinessEntityContact>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBusinessEntityContact>> GetBusinessEntityContactGetContactTypeID(int contactTypeID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts/getContactTypeID/{contactTypeID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBusinessEntityContact>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBusinessEntityContact>> GetBusinessEntityContactGetPersonID(int personID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts/getPersonID/{personID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBusinessEntityContact>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOContactType> ContactTypeCreateAsync(ApiContactTypeModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ContactTypes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOContactType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOContactType> ContactTypeUpdateAsync(int id, ApiContactTypeModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ContactTypes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOContactType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ContactTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ContactTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOContactType> ContactTypeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ContactTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOContactType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOContactType>> ContactTypeAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ContactTypes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOContactType>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOContactType>> ContactTypeBulkInsertAsync(List<ApiContactTypeModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ContactTypes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOContactType>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOContactType> GetContactTypeGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ContactTypes/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOContactType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCountryRegion> CountryRegionCreateAsync(ApiCountryRegionModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRegions", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCountryRegion>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCountryRegion> CountryRegionUpdateAsync(string id, ApiCountryRegionModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CountryRegions/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCountryRegion>(httpResponse.Content.ContentToString());
		}

		public virtual async Task CountryRegionDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CountryRegions/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOCountryRegion> CountryRegionGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegions/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCountryRegion>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCountryRegion>> CountryRegionAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegions?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCountryRegion>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCountryRegion>> CountryRegionBulkInsertAsync(List<ApiCountryRegionModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRegions/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCountryRegion>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCountryRegion> GetCountryRegionGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegions/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCountryRegion>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmailAddress> EmailAddressCreateAsync(ApiEmailAddressModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmailAddresses", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmailAddress>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmailAddress> EmailAddressUpdateAsync(int id, ApiEmailAddressModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/EmailAddresses/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmailAddress>(httpResponse.Content.ContentToString());
		}

		public virtual async Task EmailAddressDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/EmailAddresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOEmailAddress> EmailAddressGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmailAddresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmailAddress>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmailAddress>> EmailAddressAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmailAddresses?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmailAddress>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmailAddress>> EmailAddressBulkInsertAsync(List<ApiEmailAddressModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmailAddresses/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmailAddress>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmailAddress>> GetEmailAddressGetEmailAddress(string emailAddress1)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmailAddresses/getEmailAddress/{emailAddress1}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmailAddress>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPassword> PasswordCreateAsync(ApiPasswordModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Passwords", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPassword>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPassword> PasswordUpdateAsync(int id, ApiPasswordModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Passwords/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPassword>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PasswordDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Passwords/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOPassword> PasswordGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Passwords/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPassword>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPassword>> PasswordAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Passwords?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPassword>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPassword>> PasswordBulkInsertAsync(List<ApiPasswordModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Passwords/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPassword>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPerson> PersonCreateAsync(ApiPersonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/People", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPerson>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPerson> PersonUpdateAsync(int id, ApiPersonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/People/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPerson>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PersonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/People/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOPerson> PersonGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPerson>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPerson>> PersonAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPerson>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPerson>> PersonBulkInsertAsync(List<ApiPersonModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/People/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPerson>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPerson>> GetPersonGetLastNameFirstNameMiddleName(string lastName,string firstName,string middleName)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/getLastNameFirstNameMiddleName/{lastName}/{firstName}/{middleName}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPerson>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPerson>> GetPersonGetAdditionalContactInfo(string additionalContactInfo)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/getAdditionalContactInfo/{additionalContactInfo}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPerson>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPerson>> GetPersonGetDemographics(string demographics)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/getDemographics/{demographics}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPerson>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPersonPhone> PersonPhoneCreateAsync(ApiPersonPhoneModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonPhones", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPersonPhone>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPersonPhone> PersonPhoneUpdateAsync(int id, ApiPersonPhoneModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PersonPhones/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPersonPhone>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PersonPhoneDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PersonPhones/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOPersonPhone> PersonPhoneGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonPhones/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPersonPhone>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPersonPhone>> PersonPhoneAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonPhones?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPersonPhone>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPersonPhone>> PersonPhoneBulkInsertAsync(List<ApiPersonPhoneModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonPhones/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPersonPhone>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPersonPhone>> GetPersonPhoneGetPhoneNumber(string phoneNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonPhones/getPhoneNumber/{phoneNumber}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPersonPhone>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPhoneNumberType> PhoneNumberTypeCreateAsync(ApiPhoneNumberTypeModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PhoneNumberTypes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPhoneNumberType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPhoneNumberType> PhoneNumberTypeUpdateAsync(int id, ApiPhoneNumberTypeModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PhoneNumberTypes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPhoneNumberType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PhoneNumberTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PhoneNumberTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOPhoneNumberType> PhoneNumberTypeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PhoneNumberTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPhoneNumberType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPhoneNumberType>> PhoneNumberTypeAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PhoneNumberTypes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPhoneNumberType>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPhoneNumberType>> PhoneNumberTypeBulkInsertAsync(List<ApiPhoneNumberTypeModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PhoneNumberTypes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPhoneNumberType>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStateProvince> StateProvinceCreateAsync(ApiStateProvinceModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/StateProvinces", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStateProvince>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStateProvince> StateProvinceUpdateAsync(int id, ApiStateProvinceModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/StateProvinces/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStateProvince>(httpResponse.Content.ContentToString());
		}

		public virtual async Task StateProvinceDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/StateProvinces/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOStateProvince> StateProvinceGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStateProvince>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOStateProvince>> StateProvinceAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStateProvince>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOStateProvince>> StateProvinceBulkInsertAsync(List<ApiStateProvinceModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/StateProvinces/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStateProvince>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStateProvince> GetStateProvinceGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStateProvince>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStateProvince> GetStateProvinceGetStateProvinceCodeCountryRegionCode(string stateProvinceCode,string countryRegionCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces/getStateProvinceCodeCountryRegionCode/{stateProvinceCode}/{countryRegionCode}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStateProvince>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBillOfMaterials> BillOfMaterialsCreateAsync(ApiBillOfMaterialsModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BillOfMaterials", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBillOfMaterials>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBillOfMaterials> BillOfMaterialsUpdateAsync(int id, ApiBillOfMaterialsModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/BillOfMaterials/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBillOfMaterials>(httpResponse.Content.ContentToString());
		}

		public virtual async Task BillOfMaterialsDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/BillOfMaterials/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOBillOfMaterials> BillOfMaterialsGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BillOfMaterials/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBillOfMaterials>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBillOfMaterials>> BillOfMaterialsAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BillOfMaterials?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBillOfMaterials>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBillOfMaterials>> BillOfMaterialsBulkInsertAsync(List<ApiBillOfMaterialsModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BillOfMaterials/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBillOfMaterials>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBillOfMaterials> GetBillOfMaterialsGetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID,int componentID,DateTime startDate)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BillOfMaterials/getProductAssemblyIDComponentIDStartDate/{productAssemblyID}/{componentID}/{startDate}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBillOfMaterials>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBillOfMaterials>> GetBillOfMaterialsGetUnitMeasureCode(string unitMeasureCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BillOfMaterials/getUnitMeasureCode/{unitMeasureCode}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBillOfMaterials>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCulture> CultureCreateAsync(ApiCultureModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Cultures", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCulture>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCulture> CultureUpdateAsync(string id, ApiCultureModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Cultures/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCulture>(httpResponse.Content.ContentToString());
		}

		public virtual async Task CultureDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Cultures/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOCulture> CultureGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cultures/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCulture>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCulture>> CultureAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cultures?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCulture>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCulture>> CultureBulkInsertAsync(List<ApiCultureModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Cultures/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCulture>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCulture> GetCultureGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cultures/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCulture>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODocument> DocumentCreateAsync(ApiDocumentModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Documents", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODocument>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODocument> DocumentUpdateAsync(Guid id, ApiDocumentModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Documents/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODocument>(httpResponse.Content.ContentToString());
		}

		public virtual async Task DocumentDeleteAsync(Guid id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Documents/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCODocument> DocumentGetAsync(Guid id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Documents/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODocument>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCODocument>> DocumentAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Documents?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCODocument>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCODocument>> DocumentBulkInsertAsync(List<ApiDocumentModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Documents/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCODocument>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODocument> GetDocumentGetDocumentLevelDocumentNode(Nullable<short> documentLevel,Guid documentNode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Documents/getDocumentLevelDocumentNode/{documentLevel}/{documentNode}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODocument>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCODocument>> GetDocumentGetFileNameRevision(string fileName,string revision)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Documents/getFileNameRevision/{fileName}/{revision}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCODocument>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOIllustration> IllustrationCreateAsync(ApiIllustrationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Illustrations", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOIllustration>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOIllustration> IllustrationUpdateAsync(int id, ApiIllustrationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Illustrations/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOIllustration>(httpResponse.Content.ContentToString());
		}

		public virtual async Task IllustrationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Illustrations/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOIllustration> IllustrationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Illustrations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOIllustration>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOIllustration>> IllustrationAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Illustrations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOIllustration>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOIllustration>> IllustrationBulkInsertAsync(List<ApiIllustrationModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Illustrations/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOIllustration>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLocation> LocationCreateAsync(ApiLocationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Locations", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLocation>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLocation> LocationUpdateAsync(short id, ApiLocationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Locations/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLocation>(httpResponse.Content.ContentToString());
		}

		public virtual async Task LocationDeleteAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Locations/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOLocation> LocationGetAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLocation>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLocation>> LocationAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLocation>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLocation>> LocationBulkInsertAsync(List<ApiLocationModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Locations/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLocation>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLocation> GetLocationGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLocation>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProduct> ProductCreateAsync(ApiProductModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Products", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProduct>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProduct> ProductUpdateAsync(int id, ApiProductModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Products/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProduct>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Products/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOProduct> ProductGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProduct>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProduct>> ProductAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProduct>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProduct>> ProductBulkInsertAsync(List<ApiProductModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Products/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProduct>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProduct> GetProductGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProduct>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProduct> GetProductGetProductNumber(string productNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/getProductNumber/{productNumber}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProduct>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductCategory> ProductCategoryCreateAsync(ApiProductCategoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCategories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductCategory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductCategory> ProductCategoryUpdateAsync(int id, ApiProductCategoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductCategories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductCategory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductCategoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductCategories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOProductCategory> ProductCategoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCategories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductCategory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductCategory>> ProductCategoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCategories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductCategory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductCategory>> ProductCategoryBulkInsertAsync(List<ApiProductCategoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCategories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductCategory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductCategory> GetProductCategoryGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCategories/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductCategory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductCostHistory> ProductCostHistoryCreateAsync(ApiProductCostHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCostHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductCostHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductCostHistory> ProductCostHistoryUpdateAsync(int id, ApiProductCostHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductCostHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductCostHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductCostHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductCostHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOProductCostHistory> ProductCostHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCostHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductCostHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductCostHistory>> ProductCostHistoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCostHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductCostHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductCostHistory>> ProductCostHistoryBulkInsertAsync(List<ApiProductCostHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCostHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductCostHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductDescription> ProductDescriptionCreateAsync(ApiProductDescriptionModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductDescriptions", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductDescription>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductDescription> ProductDescriptionUpdateAsync(int id, ApiProductDescriptionModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductDescriptions/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductDescription>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductDescriptionDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductDescriptions/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOProductDescription> ProductDescriptionGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDescriptions/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductDescription>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductDescription>> ProductDescriptionAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDescriptions?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductDescription>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductDescription>> ProductDescriptionBulkInsertAsync(List<ApiProductDescriptionModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductDescriptions/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductDescription>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductDocument> ProductDocumentCreateAsync(ApiProductDocumentModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductDocuments", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductDocument>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductDocument> ProductDocumentUpdateAsync(int id, ApiProductDocumentModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductDocuments/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductDocument>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductDocumentDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductDocuments/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOProductDocument> ProductDocumentGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDocuments/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductDocument>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductDocument>> ProductDocumentAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDocuments?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductDocument>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductDocument>> ProductDocumentBulkInsertAsync(List<ApiProductDocumentModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductDocuments/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductDocument>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductInventory> ProductInventoryCreateAsync(ApiProductInventoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductInventories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductInventory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductInventory> ProductInventoryUpdateAsync(int id, ApiProductInventoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductInventories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductInventory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductInventoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductInventories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOProductInventory> ProductInventoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductInventories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductInventory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductInventory>> ProductInventoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductInventories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductInventory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductInventory>> ProductInventoryBulkInsertAsync(List<ApiProductInventoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductInventories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductInventory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductListPriceHistory> ProductListPriceHistoryCreateAsync(ApiProductListPriceHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductListPriceHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductListPriceHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductListPriceHistory> ProductListPriceHistoryUpdateAsync(int id, ApiProductListPriceHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductListPriceHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductListPriceHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductListPriceHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductListPriceHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOProductListPriceHistory> ProductListPriceHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductListPriceHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductListPriceHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductListPriceHistory>> ProductListPriceHistoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductListPriceHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductListPriceHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductListPriceHistory>> ProductListPriceHistoryBulkInsertAsync(List<ApiProductListPriceHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductListPriceHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductListPriceHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductModel> ProductModelCreateAsync(ApiProductModelModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModels", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductModel> ProductModelUpdateAsync(int id, ApiProductModelModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductModels/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductModelDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductModels/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOProductModel> ProductModelGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductModel>> ProductModelAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductModel>> ProductModelBulkInsertAsync(List<ApiProductModelModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModels/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductModel> GetProductModelGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductModel>> GetProductModelGetCatalogDescription(string catalogDescription)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/getCatalogDescription/{catalogDescription}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductModel>> GetProductModelGetInstructions(string instructions)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/getInstructions/{instructions}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductModelIllustration> ProductModelIllustrationCreateAsync(ApiProductModelIllustrationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModelIllustrations", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductModelIllustration>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductModelIllustration> ProductModelIllustrationUpdateAsync(int id, ApiProductModelIllustrationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductModelIllustrations/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductModelIllustration>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductModelIllustrationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductModelIllustrations/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOProductModelIllustration> ProductModelIllustrationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelIllustrations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductModelIllustration>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductModelIllustration>> ProductModelIllustrationAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelIllustrations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductModelIllustration>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductModelIllustration>> ProductModelIllustrationBulkInsertAsync(List<ApiProductModelIllustrationModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModelIllustrations/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductModelIllustration>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductModelProductDescriptionCulture> ProductModelProductDescriptionCultureCreateAsync(ApiProductModelProductDescriptionCultureModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModelProductDescriptionCultures", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductModelProductDescriptionCulture>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductModelProductDescriptionCulture> ProductModelProductDescriptionCultureUpdateAsync(int id, ApiProductModelProductDescriptionCultureModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductModelProductDescriptionCultures/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductModelProductDescriptionCulture>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductModelProductDescriptionCultureDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductModelProductDescriptionCultures/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOProductModelProductDescriptionCulture> ProductModelProductDescriptionCultureGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelProductDescriptionCultures/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductModelProductDescriptionCulture>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductModelProductDescriptionCulture>> ProductModelProductDescriptionCultureAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelProductDescriptionCultures?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductModelProductDescriptionCulture>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductModelProductDescriptionCulture>> ProductModelProductDescriptionCultureBulkInsertAsync(List<ApiProductModelProductDescriptionCultureModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModelProductDescriptionCultures/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductModelProductDescriptionCulture>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductPhoto> ProductPhotoCreateAsync(ApiProductPhotoModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductPhotoes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductPhoto>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductPhoto> ProductPhotoUpdateAsync(int id, ApiProductPhotoModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductPhotoes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductPhoto>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductPhotoDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductPhotoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOProductPhoto> ProductPhotoGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductPhotoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductPhoto>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductPhoto>> ProductPhotoAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductPhotoes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductPhoto>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductPhoto>> ProductPhotoBulkInsertAsync(List<ApiProductPhotoModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductPhotoes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductPhoto>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductProductPhoto> ProductProductPhotoCreateAsync(ApiProductProductPhotoModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductProductPhotoes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductProductPhoto>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductProductPhoto> ProductProductPhotoUpdateAsync(int id, ApiProductProductPhotoModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductProductPhotoes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductProductPhoto>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductProductPhotoDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductProductPhotoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOProductProductPhoto> ProductProductPhotoGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductProductPhotoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductProductPhoto>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductProductPhoto>> ProductProductPhotoAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductProductPhotoes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductProductPhoto>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductProductPhoto>> ProductProductPhotoBulkInsertAsync(List<ApiProductProductPhotoModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductProductPhotoes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductProductPhoto>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductReview> ProductReviewCreateAsync(ApiProductReviewModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductReviews", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductReview>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductReview> ProductReviewUpdateAsync(int id, ApiProductReviewModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductReviews/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductReview>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductReviewDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductReviews/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOProductReview> ProductReviewGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductReviews/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductReview>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductReview>> ProductReviewAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductReviews?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductReview>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductReview>> ProductReviewBulkInsertAsync(List<ApiProductReviewModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductReviews/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductReview>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductReview>> GetProductReviewGetCommentsProductIDReviewerName(string comments,int productID,string reviewerName)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductReviews/getCommentsProductIDReviewerName/{comments}/{productID}/{reviewerName}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductReview>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductSubcategory> ProductSubcategoryCreateAsync(ApiProductSubcategoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductSubcategories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductSubcategory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductSubcategory> ProductSubcategoryUpdateAsync(int id, ApiProductSubcategoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductSubcategories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductSubcategory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductSubcategoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductSubcategories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOProductSubcategory> ProductSubcategoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductSubcategories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductSubcategory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductSubcategory>> ProductSubcategoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductSubcategories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductSubcategory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductSubcategory>> ProductSubcategoryBulkInsertAsync(List<ApiProductSubcategoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductSubcategories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductSubcategory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductSubcategory> GetProductSubcategoryGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductSubcategories/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductSubcategory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOScrapReason> ScrapReasonCreateAsync(ApiScrapReasonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ScrapReasons", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOScrapReason>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOScrapReason> ScrapReasonUpdateAsync(short id, ApiScrapReasonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ScrapReasons/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOScrapReason>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ScrapReasonDeleteAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ScrapReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOScrapReason> ScrapReasonGetAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ScrapReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOScrapReason>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOScrapReason>> ScrapReasonAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ScrapReasons?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOScrapReason>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOScrapReason>> ScrapReasonBulkInsertAsync(List<ApiScrapReasonModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ScrapReasons/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOScrapReason>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOScrapReason> GetScrapReasonGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ScrapReasons/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOScrapReason>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTransactionHistory> TransactionHistoryCreateAsync(ApiTransactionHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTransactionHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTransactionHistory> TransactionHistoryUpdateAsync(int id, ApiTransactionHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TransactionHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTransactionHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task TransactionHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TransactionHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOTransactionHistory> TransactionHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTransactionHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTransactionHistory>> TransactionHistoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTransactionHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTransactionHistory>> TransactionHistoryBulkInsertAsync(List<ApiTransactionHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTransactionHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTransactionHistory>> GetTransactionHistoryGetProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories/getProductID/{productID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTransactionHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTransactionHistory>> GetTransactionHistoryGetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories/getReferenceOrderIDReferenceOrderLineID/{referenceOrderID}/{referenceOrderLineID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTransactionHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTransactionHistoryArchive> TransactionHistoryArchiveCreateAsync(ApiTransactionHistoryArchiveModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistoryArchives", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTransactionHistoryArchive>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTransactionHistoryArchive> TransactionHistoryArchiveUpdateAsync(int id, ApiTransactionHistoryArchiveModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TransactionHistoryArchives/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTransactionHistoryArchive>(httpResponse.Content.ContentToString());
		}

		public virtual async Task TransactionHistoryArchiveDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TransactionHistoryArchives/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOTransactionHistoryArchive> TransactionHistoryArchiveGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTransactionHistoryArchive>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTransactionHistoryArchive>> TransactionHistoryArchiveAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTransactionHistoryArchive>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTransactionHistoryArchive>> TransactionHistoryArchiveBulkInsertAsync(List<ApiTransactionHistoryArchiveModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistoryArchives/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTransactionHistoryArchive>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTransactionHistoryArchive>> GetTransactionHistoryArchiveGetProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives/getProductID/{productID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTransactionHistoryArchive>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTransactionHistoryArchive>> GetTransactionHistoryArchiveGetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives/getReferenceOrderIDReferenceOrderLineID/{referenceOrderID}/{referenceOrderLineID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTransactionHistoryArchive>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOUnitMeasure> UnitMeasureCreateAsync(ApiUnitMeasureModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/UnitMeasures", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOUnitMeasure>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOUnitMeasure> UnitMeasureUpdateAsync(string id, ApiUnitMeasureModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/UnitMeasures/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOUnitMeasure>(httpResponse.Content.ContentToString());
		}

		public virtual async Task UnitMeasureDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/UnitMeasures/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOUnitMeasure> UnitMeasureGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UnitMeasures/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOUnitMeasure>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOUnitMeasure>> UnitMeasureAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UnitMeasures?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOUnitMeasure>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOUnitMeasure>> UnitMeasureBulkInsertAsync(List<ApiUnitMeasureModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/UnitMeasures/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOUnitMeasure>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOUnitMeasure> GetUnitMeasureGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UnitMeasures/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOUnitMeasure>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOWorkOrder> WorkOrderCreateAsync(ApiWorkOrderModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrders", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOWorkOrder>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOWorkOrder> WorkOrderUpdateAsync(int id, ApiWorkOrderModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/WorkOrders/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOWorkOrder>(httpResponse.Content.ContentToString());
		}

		public virtual async Task WorkOrderDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/WorkOrders/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOWorkOrder> WorkOrderGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOWorkOrder>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOWorkOrder>> WorkOrderAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOWorkOrder>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOWorkOrder>> WorkOrderBulkInsertAsync(List<ApiWorkOrderModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrders/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOWorkOrder>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOWorkOrder>> GetWorkOrderGetProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders/getProductID/{productID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOWorkOrder>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOWorkOrder>> GetWorkOrderGetScrapReasonID(Nullable<short> scrapReasonID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders/getScrapReasonID/{scrapReasonID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOWorkOrder>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOWorkOrderRouting> WorkOrderRoutingCreateAsync(ApiWorkOrderRoutingModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrderRoutings", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOWorkOrderRouting>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOWorkOrderRouting> WorkOrderRoutingUpdateAsync(int id, ApiWorkOrderRoutingModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/WorkOrderRoutings/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOWorkOrderRouting>(httpResponse.Content.ContentToString());
		}

		public virtual async Task WorkOrderRoutingDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/WorkOrderRoutings/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOWorkOrderRouting> WorkOrderRoutingGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrderRoutings/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOWorkOrderRouting>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOWorkOrderRouting>> WorkOrderRoutingAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrderRoutings?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOWorkOrderRouting>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOWorkOrderRouting>> WorkOrderRoutingBulkInsertAsync(List<ApiWorkOrderRoutingModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrderRoutings/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOWorkOrderRouting>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOWorkOrderRouting>> GetWorkOrderRoutingGetProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrderRoutings/getProductID/{productID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOWorkOrderRouting>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductVendor> ProductVendorCreateAsync(ApiProductVendorModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductVendors", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductVendor>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductVendor> ProductVendorUpdateAsync(int id, ApiProductVendorModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ProductVendors/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductVendor>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductVendorDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ProductVendors/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOProductVendor> ProductVendorGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductVendor>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductVendor>> ProductVendorAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductVendor>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductVendor>> ProductVendorBulkInsertAsync(List<ApiProductVendorModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductVendors/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductVendor>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductVendor>> GetProductVendorGetBusinessEntityID(int businessEntityID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors/getBusinessEntityID/{businessEntityID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductVendor>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductVendor>> GetProductVendorGetUnitMeasureCode(string unitMeasureCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors/getUnitMeasureCode/{unitMeasureCode}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductVendor>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPurchaseOrderDetail> PurchaseOrderDetailCreateAsync(ApiPurchaseOrderDetailModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderDetails", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPurchaseOrderDetail>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPurchaseOrderDetail> PurchaseOrderDetailUpdateAsync(int id, ApiPurchaseOrderDetailModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PurchaseOrderDetails/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPurchaseOrderDetail>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PurchaseOrderDetailDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PurchaseOrderDetails/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOPurchaseOrderDetail> PurchaseOrderDetailGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderDetails/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPurchaseOrderDetail>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPurchaseOrderDetail>> PurchaseOrderDetailAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderDetails?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPurchaseOrderDetail>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPurchaseOrderDetail>> PurchaseOrderDetailBulkInsertAsync(List<ApiPurchaseOrderDetailModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderDetails/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPurchaseOrderDetail>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPurchaseOrderDetail>> GetPurchaseOrderDetailGetProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderDetails/getProductID/{productID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPurchaseOrderDetail>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPurchaseOrderHeader> PurchaseOrderHeaderCreateAsync(ApiPurchaseOrderHeaderModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderHeaders", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPurchaseOrderHeader>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPurchaseOrderHeader> PurchaseOrderHeaderUpdateAsync(int id, ApiPurchaseOrderHeaderModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PurchaseOrderHeaders/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPurchaseOrderHeader>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PurchaseOrderHeaderDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PurchaseOrderHeaders/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOPurchaseOrderHeader> PurchaseOrderHeaderGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPurchaseOrderHeader>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPurchaseOrderHeader>> PurchaseOrderHeaderAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPurchaseOrderHeader>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPurchaseOrderHeader>> PurchaseOrderHeaderBulkInsertAsync(List<ApiPurchaseOrderHeaderModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderHeaders/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPurchaseOrderHeader>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPurchaseOrderHeader>> GetPurchaseOrderHeaderGetEmployeeID(int employeeID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders/getEmployeeID/{employeeID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPurchaseOrderHeader>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPurchaseOrderHeader>> GetPurchaseOrderHeaderGetVendorID(int vendorID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders/getVendorID/{vendorID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPurchaseOrderHeader>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOShipMethod> ShipMethodCreateAsync(ApiShipMethodModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShipMethods", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOShipMethod>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOShipMethod> ShipMethodUpdateAsync(int id, ApiShipMethodModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ShipMethods/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOShipMethod>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ShipMethodDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ShipMethods/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOShipMethod> ShipMethodGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShipMethods/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOShipMethod>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOShipMethod>> ShipMethodAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShipMethods?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOShipMethod>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOShipMethod>> ShipMethodBulkInsertAsync(List<ApiShipMethodModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShipMethods/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOShipMethod>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOShipMethod> GetShipMethodGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShipMethods/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOShipMethod>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOVendor> VendorCreateAsync(ApiVendorModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Vendors", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOVendor>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOVendor> VendorUpdateAsync(int id, ApiVendorModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Vendors/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOVendor>(httpResponse.Content.ContentToString());
		}

		public virtual async Task VendorDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Vendors/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOVendor> VendorGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Vendors/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOVendor>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOVendor>> VendorAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Vendors?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOVendor>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOVendor>> VendorBulkInsertAsync(List<ApiVendorModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Vendors/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOVendor>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOVendor> GetVendorGetAccountNumber(string accountNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Vendors/getAccountNumber/{accountNumber}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOVendor>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCountryRegionCurrency> CountryRegionCurrencyCreateAsync(ApiCountryRegionCurrencyModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRegionCurrencies", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCountryRegionCurrency>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCountryRegionCurrency> CountryRegionCurrencyUpdateAsync(string id, ApiCountryRegionCurrencyModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CountryRegionCurrencies/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCountryRegionCurrency>(httpResponse.Content.ContentToString());
		}

		public virtual async Task CountryRegionCurrencyDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CountryRegionCurrencies/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOCountryRegionCurrency> CountryRegionCurrencyGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegionCurrencies/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCountryRegionCurrency>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCountryRegionCurrency>> CountryRegionCurrencyAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegionCurrencies?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCountryRegionCurrency>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCountryRegionCurrency>> CountryRegionCurrencyBulkInsertAsync(List<ApiCountryRegionCurrencyModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRegionCurrencies/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCountryRegionCurrency>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCountryRegionCurrency>> GetCountryRegionCurrencyGetCurrencyCode(string currencyCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegionCurrencies/getCurrencyCode/{currencyCode}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCountryRegionCurrency>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCreditCard> CreditCardCreateAsync(ApiCreditCardModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CreditCards", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCreditCard>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCreditCard> CreditCardUpdateAsync(int id, ApiCreditCardModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CreditCards/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCreditCard>(httpResponse.Content.ContentToString());
		}

		public virtual async Task CreditCardDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CreditCards/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOCreditCard> CreditCardGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CreditCards/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCreditCard>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCreditCard>> CreditCardAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CreditCards?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCreditCard>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCreditCard>> CreditCardBulkInsertAsync(List<ApiCreditCardModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CreditCards/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCreditCard>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCreditCard> GetCreditCardGetCardNumber(string cardNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CreditCards/getCardNumber/{cardNumber}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCreditCard>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCurrency> CurrencyCreateAsync(ApiCurrencyModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Currencies", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCurrency>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCurrency> CurrencyUpdateAsync(string id, ApiCurrencyModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Currencies/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCurrency>(httpResponse.Content.ContentToString());
		}

		public virtual async Task CurrencyDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Currencies/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOCurrency> CurrencyGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCurrency>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCurrency>> CurrencyAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCurrency>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCurrency>> CurrencyBulkInsertAsync(List<ApiCurrencyModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Currencies/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCurrency>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCurrency> GetCurrencyGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCurrency>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCurrencyRate> CurrencyRateCreateAsync(ApiCurrencyRateModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CurrencyRates", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCurrencyRate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCurrencyRate> CurrencyRateUpdateAsync(int id, ApiCurrencyRateModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/CurrencyRates/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCurrencyRate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task CurrencyRateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/CurrencyRates/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOCurrencyRate> CurrencyRateGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CurrencyRates/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCurrencyRate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCurrencyRate>> CurrencyRateAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CurrencyRates?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCurrencyRate>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCurrencyRate>> CurrencyRateBulkInsertAsync(List<ApiCurrencyRateModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CurrencyRates/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCurrencyRate>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCurrencyRate> GetCurrencyRateGetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate,string fromCurrencyCode,string toCurrencyCode)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CurrencyRates/getCurrencyRateDateFromCurrencyCodeToCurrencyCode/{currencyRateDate}/{fromCurrencyCode}/{toCurrencyCode}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCurrencyRate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCustomer> CustomerCreateAsync(ApiCustomerModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Customers", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCustomer>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCustomer> CustomerUpdateAsync(int id, ApiCustomerModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Customers/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCustomer>(httpResponse.Content.ContentToString());
		}

		public virtual async Task CustomerDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Customers/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOCustomer> CustomerGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCustomer>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCustomer>> CustomerAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCustomer>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCustomer>> CustomerBulkInsertAsync(List<ApiCustomerModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Customers/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCustomer>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCustomer> GetCustomerGetAccountNumber(string accountNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers/getAccountNumber/{accountNumber}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCustomer>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCustomer>> GetCustomerGetTerritoryID(Nullable<int> territoryID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers/getTerritoryID/{territoryID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCustomer>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPersonCreditCard> PersonCreditCardCreateAsync(ApiPersonCreditCardModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonCreditCards", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPersonCreditCard>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPersonCreditCard> PersonCreditCardUpdateAsync(int id, ApiPersonCreditCardModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PersonCreditCards/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPersonCreditCard>(httpResponse.Content.ContentToString());
		}

		public virtual async Task PersonCreditCardDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PersonCreditCards/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOPersonCreditCard> PersonCreditCardGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonCreditCards/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPersonCreditCard>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPersonCreditCard>> PersonCreditCardAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonCreditCards?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPersonCreditCard>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPersonCreditCard>> PersonCreditCardBulkInsertAsync(List<ApiPersonCreditCardModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonCreditCards/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPersonCreditCard>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesOrderDetail> SalesOrderDetailCreateAsync(ApiSalesOrderDetailModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderDetails", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesOrderDetail>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesOrderDetail> SalesOrderDetailUpdateAsync(int id, ApiSalesOrderDetailModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesOrderDetails/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesOrderDetail>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesOrderDetailDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesOrderDetails/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOSalesOrderDetail> SalesOrderDetailGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderDetails/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesOrderDetail>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesOrderDetail>> SalesOrderDetailAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderDetails?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesOrderDetail>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesOrderDetail>> SalesOrderDetailBulkInsertAsync(List<ApiSalesOrderDetailModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderDetails/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesOrderDetail>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesOrderDetail>> GetSalesOrderDetailGetProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderDetails/getProductID/{productID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesOrderDetail>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesOrderHeader> SalesOrderHeaderCreateAsync(ApiSalesOrderHeaderModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderHeaders", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesOrderHeader>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesOrderHeader> SalesOrderHeaderUpdateAsync(int id, ApiSalesOrderHeaderModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesOrderHeaders/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesOrderHeader>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesOrderHeaderDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesOrderHeaders/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOSalesOrderHeader> SalesOrderHeaderGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesOrderHeader>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesOrderHeader>> SalesOrderHeaderAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesOrderHeader>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesOrderHeader>> SalesOrderHeaderBulkInsertAsync(List<ApiSalesOrderHeaderModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderHeaders/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesOrderHeader>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesOrderHeader> GetSalesOrderHeaderGetSalesOrderNumber(string salesOrderNumber)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/getSalesOrderNumber/{salesOrderNumber}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesOrderHeader>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesOrderHeader>> GetSalesOrderHeaderGetCustomerID(int customerID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/getCustomerID/{customerID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesOrderHeader>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesOrderHeader>> GetSalesOrderHeaderGetSalesPersonID(Nullable<int> salesPersonID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/getSalesPersonID/{salesPersonID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesOrderHeader>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasonCreateAsync(ApiSalesOrderHeaderSalesReasonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderHeaderSalesReasons", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesOrderHeaderSalesReason>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasonUpdateAsync(int id, ApiSalesOrderHeaderSalesReasonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesOrderHeaderSalesReasons/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesOrderHeaderSalesReason>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesOrderHeaderSalesReasonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesOrderHeaderSalesReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOSalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasonGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaderSalesReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesOrderHeaderSalesReason>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesOrderHeaderSalesReason>> SalesOrderHeaderSalesReasonAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaderSalesReasons?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesOrderHeaderSalesReason>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesOrderHeaderSalesReason>> SalesOrderHeaderSalesReasonBulkInsertAsync(List<ApiSalesOrderHeaderSalesReasonModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderHeaderSalesReasons/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesOrderHeaderSalesReason>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesPerson> SalesPersonCreateAsync(ApiSalesPersonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersons", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesPerson>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesPerson> SalesPersonUpdateAsync(int id, ApiSalesPersonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesPersons/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesPerson>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesPersonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesPersons/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOSalesPerson> SalesPersonGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersons/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesPerson>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesPerson>> SalesPersonAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersons?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesPerson>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesPerson>> SalesPersonBulkInsertAsync(List<ApiSalesPersonModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersons/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesPerson>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesPersonQuotaHistory> SalesPersonQuotaHistoryCreateAsync(ApiSalesPersonQuotaHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersonQuotaHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesPersonQuotaHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesPersonQuotaHistory> SalesPersonQuotaHistoryUpdateAsync(int id, ApiSalesPersonQuotaHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesPersonQuotaHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesPersonQuotaHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesPersonQuotaHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesPersonQuotaHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOSalesPersonQuotaHistory> SalesPersonQuotaHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersonQuotaHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesPersonQuotaHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesPersonQuotaHistory>> SalesPersonQuotaHistoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersonQuotaHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesPersonQuotaHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesPersonQuotaHistory>> SalesPersonQuotaHistoryBulkInsertAsync(List<ApiSalesPersonQuotaHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersonQuotaHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesPersonQuotaHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesReason> SalesReasonCreateAsync(ApiSalesReasonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesReasons", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesReason>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesReason> SalesReasonUpdateAsync(int id, ApiSalesReasonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesReasons/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesReason>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesReasonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOSalesReason> SalesReasonGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesReason>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesReason>> SalesReasonAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesReasons?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesReason>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesReason>> SalesReasonBulkInsertAsync(List<ApiSalesReasonModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesReasons/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesReason>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesTaxRate> SalesTaxRateCreateAsync(ApiSalesTaxRateModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTaxRates", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesTaxRate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesTaxRate> SalesTaxRateUpdateAsync(int id, ApiSalesTaxRateModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesTaxRates/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesTaxRate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesTaxRateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesTaxRates/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOSalesTaxRate> SalesTaxRateGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTaxRates/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesTaxRate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesTaxRate>> SalesTaxRateAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTaxRates?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesTaxRate>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesTaxRate>> SalesTaxRateBulkInsertAsync(List<ApiSalesTaxRateModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTaxRates/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesTaxRate>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesTaxRate> GetSalesTaxRateGetStateProvinceIDTaxType(int stateProvinceID,int taxType)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTaxRates/getStateProvinceIDTaxType/{stateProvinceID}/{taxType}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesTaxRate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesTerritory> SalesTerritoryCreateAsync(ApiSalesTerritoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesTerritory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesTerritory> SalesTerritoryUpdateAsync(int id, ApiSalesTerritoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesTerritories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesTerritory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesTerritoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesTerritories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOSalesTerritory> SalesTerritoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesTerritory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesTerritory>> SalesTerritoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesTerritory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesTerritory>> SalesTerritoryBulkInsertAsync(List<ApiSalesTerritoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesTerritory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesTerritory> GetSalesTerritoryGetName(string name)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories/getName/{name}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesTerritory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesTerritoryHistory> SalesTerritoryHistoryCreateAsync(ApiSalesTerritoryHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritoryHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesTerritoryHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesTerritoryHistory> SalesTerritoryHistoryUpdateAsync(int id, ApiSalesTerritoryHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SalesTerritoryHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesTerritoryHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesTerritoryHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SalesTerritoryHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOSalesTerritoryHistory> SalesTerritoryHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritoryHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesTerritoryHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesTerritoryHistory>> SalesTerritoryHistoryAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritoryHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesTerritoryHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesTerritoryHistory>> SalesTerritoryHistoryBulkInsertAsync(List<ApiSalesTerritoryHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritoryHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesTerritoryHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOShoppingCartItem> ShoppingCartItemCreateAsync(ApiShoppingCartItemModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShoppingCartItems", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOShoppingCartItem>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOShoppingCartItem> ShoppingCartItemUpdateAsync(int id, ApiShoppingCartItemModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/ShoppingCartItems/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOShoppingCartItem>(httpResponse.Content.ContentToString());
		}

		public virtual async Task ShoppingCartItemDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/ShoppingCartItems/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOShoppingCartItem> ShoppingCartItemGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShoppingCartItems/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOShoppingCartItem>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOShoppingCartItem>> ShoppingCartItemAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShoppingCartItems?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOShoppingCartItem>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOShoppingCartItem>> ShoppingCartItemBulkInsertAsync(List<ApiShoppingCartItemModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShoppingCartItems/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOShoppingCartItem>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOShoppingCartItem>> GetShoppingCartItemGetShoppingCartIDProductID(string shoppingCartID,int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShoppingCartItems/getShoppingCartIDProductID/{shoppingCartID}/{productID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOShoppingCartItem>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpecialOffer> SpecialOfferCreateAsync(ApiSpecialOfferModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOffers", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpecialOffer>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpecialOffer> SpecialOfferUpdateAsync(int id, ApiSpecialOfferModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SpecialOffers/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpecialOffer>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SpecialOfferDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SpecialOffers/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOSpecialOffer> SpecialOfferGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOffers/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpecialOffer>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpecialOffer>> SpecialOfferAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOffers?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpecialOffer>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpecialOffer>> SpecialOfferBulkInsertAsync(List<ApiSpecialOfferModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOffers/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpecialOffer>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpecialOfferProduct> SpecialOfferProductCreateAsync(ApiSpecialOfferProductModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOfferProducts", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpecialOfferProduct>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpecialOfferProduct> SpecialOfferProductUpdateAsync(int id, ApiSpecialOfferProductModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SpecialOfferProducts/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpecialOfferProduct>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SpecialOfferProductDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SpecialOfferProducts/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOSpecialOfferProduct> SpecialOfferProductGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOfferProducts/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpecialOfferProduct>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpecialOfferProduct>> SpecialOfferProductAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOfferProducts?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpecialOfferProduct>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpecialOfferProduct>> SpecialOfferProductBulkInsertAsync(List<ApiSpecialOfferProductModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOfferProducts/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpecialOfferProduct>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpecialOfferProduct>> GetSpecialOfferProductGetProductID(int productID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOfferProducts/getProductID/{productID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpecialOfferProduct>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStore> StoreCreateAsync(ApiStoreModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Stores", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStore>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStore> StoreUpdateAsync(int id, ApiStoreModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Stores/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStore>(httpResponse.Content.ContentToString());
		}

		public virtual async Task StoreDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Stores/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOStore> StoreGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStore>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOStore>> StoreAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStore>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOStore>> StoreBulkInsertAsync(List<ApiStoreModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Stores/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStore>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOStore>> GetStoreGetSalesPersonID(Nullable<int> salesPersonID)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores/getSalesPersonID/{salesPersonID}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStore>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOStore>> GetStoreGetDemographics(string demographics)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores/getDemographics/{demographics}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStore>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>bea2dbe9fb41612bc7a100d2404b319b</Hash>
</Codenesium>*/