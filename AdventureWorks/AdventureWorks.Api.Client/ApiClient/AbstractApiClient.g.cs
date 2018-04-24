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

		public virtual async Task<POCOAWBuildVersion> AWBuildVersionCreateAsync(AWBuildVersionModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AWBuildVersions", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAWBuildVersion>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAWBuildVersion> AWBuildVersionUpdateAsync(int id, AWBuildVersionModel item)
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

		public virtual async Task<List<POCOAWBuildVersion>> AWBuildVersionSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AWBuildVersions?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAWBuildVersion>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAWBuildVersion> AWBuildVersionGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AWBuildVersions/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAWBuildVersion>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOAWBuildVersion>> AWBuildVersionGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AWBuildVersions?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAWBuildVersion>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> AWBuildVersionBulkInsertAsync(List<AWBuildVersionModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AWBuildVersions/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODatabaseLog> DatabaseLogCreateAsync(DatabaseLogModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DatabaseLogs", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODatabaseLog>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODatabaseLog> DatabaseLogUpdateAsync(int id, DatabaseLogModel item)
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

		public virtual async Task<List<POCODatabaseLog>> DatabaseLogSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DatabaseLogs?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCODatabaseLog>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODatabaseLog> DatabaseLogGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DatabaseLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODatabaseLog>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCODatabaseLog>> DatabaseLogGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DatabaseLogs?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCODatabaseLog>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> DatabaseLogBulkInsertAsync(List<DatabaseLogModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DatabaseLogs/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOErrorLog> ErrorLogCreateAsync(ErrorLogModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ErrorLogs", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOErrorLog>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOErrorLog> ErrorLogUpdateAsync(int id, ErrorLogModel item)
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

		public virtual async Task<List<POCOErrorLog>> ErrorLogSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ErrorLogs?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOErrorLog>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOErrorLog> ErrorLogGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ErrorLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOErrorLog>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOErrorLog>> ErrorLogGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ErrorLogs?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOErrorLog>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ErrorLogBulkInsertAsync(List<ErrorLogModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ErrorLogs/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODepartment> DepartmentCreateAsync(DepartmentModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Departments", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODepartment>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODepartment> DepartmentUpdateAsync(short id, DepartmentModel item)
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

		public virtual async Task<List<POCODepartment>> DepartmentSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Departments?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCODepartment>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODepartment> DepartmentGetByIdAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Departments/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODepartment>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCODepartment>> DepartmentGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Departments?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCODepartment>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<short>> DepartmentBulkInsertAsync(List<DepartmentModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Departments/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<short>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployee> EmployeeCreateAsync(EmployeeModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Employees", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployee>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployee> EmployeeUpdateAsync(int id, EmployeeModel item)
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

		public virtual async Task<List<POCOEmployee>> EmployeeSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmployee>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployee> EmployeeGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployee>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmployee>> EmployeeGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Employees?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmployee>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> EmployeeBulkInsertAsync(List<EmployeeModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Employees/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployeeDepartmentHistory> EmployeeDepartmentHistoryCreateAsync(EmployeeDepartmentHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeeDepartmentHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployeeDepartmentHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployeeDepartmentHistory> EmployeeDepartmentHistoryUpdateAsync(int id, EmployeeDepartmentHistoryModel item)
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

		public virtual async Task<List<POCOEmployeeDepartmentHistory>> EmployeeDepartmentHistorySearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmployeeDepartmentHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployeeDepartmentHistory> EmployeeDepartmentHistoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployeeDepartmentHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmployeeDepartmentHistory>> EmployeeDepartmentHistoryGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeeDepartmentHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmployeeDepartmentHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> EmployeeDepartmentHistoryBulkInsertAsync(List<EmployeeDepartmentHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeeDepartmentHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployeePayHistory> EmployeePayHistoryCreateAsync(EmployeePayHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeePayHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployeePayHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployeePayHistory> EmployeePayHistoryUpdateAsync(int id, EmployeePayHistoryModel item)
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

		public virtual async Task<List<POCOEmployeePayHistory>> EmployeePayHistorySearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeePayHistories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmployeePayHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmployeePayHistory> EmployeePayHistoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeePayHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmployeePayHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmployeePayHistory>> EmployeePayHistoryGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmployeePayHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmployeePayHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> EmployeePayHistoryBulkInsertAsync(List<EmployeePayHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmployeePayHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOJobCandidate> JobCandidateCreateAsync(JobCandidateModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/JobCandidates", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOJobCandidate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOJobCandidate> JobCandidateUpdateAsync(int id, JobCandidateModel item)
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

		public virtual async Task<List<POCOJobCandidate>> JobCandidateSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/JobCandidates?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOJobCandidate>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOJobCandidate> JobCandidateGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/JobCandidates/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOJobCandidate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOJobCandidate>> JobCandidateGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/JobCandidates?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOJobCandidate>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> JobCandidateBulkInsertAsync(List<JobCandidateModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/JobCandidates/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOShift> ShiftCreateAsync(ShiftModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Shifts", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOShift>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOShift> ShiftUpdateAsync(int id, ShiftModel item)
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

		public virtual async Task<List<POCOShift>> ShiftSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOShift>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOShift> ShiftGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOShift>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOShift>> ShiftGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Shifts?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOShift>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ShiftBulkInsertAsync(List<ShiftModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Shifts/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAddress> AddressCreateAsync(AddressModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Addresses", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAddress>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAddress> AddressUpdateAsync(int id, AddressModel item)
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

		public virtual async Task<List<POCOAddress>> AddressSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAddress>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAddress> AddressGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAddress>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOAddress>> AddressGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Addresses?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAddress>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> AddressBulkInsertAsync(List<AddressModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Addresses/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAddressType> AddressTypeCreateAsync(AddressTypeModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AddressTypes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAddressType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAddressType> AddressTypeUpdateAsync(int id, AddressTypeModel item)
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

		public virtual async Task<List<POCOAddressType>> AddressTypeSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AddressTypes?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAddressType>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAddressType> AddressTypeGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AddressTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAddressType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOAddressType>> AddressTypeGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/AddressTypes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAddressType>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> AddressTypeBulkInsertAsync(List<AddressTypeModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/AddressTypes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBusinessEntity> BusinessEntityCreateAsync(BusinessEntityModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntities", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBusinessEntity>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBusinessEntity> BusinessEntityUpdateAsync(int id, BusinessEntityModel item)
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

		public virtual async Task<List<POCOBusinessEntity>> BusinessEntitySearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntities?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBusinessEntity>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBusinessEntity> BusinessEntityGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntities/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBusinessEntity>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBusinessEntity>> BusinessEntityGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntities?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBusinessEntity>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> BusinessEntityBulkInsertAsync(List<BusinessEntityModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntities/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBusinessEntityAddress> BusinessEntityAddressCreateAsync(BusinessEntityAddressModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityAddresses", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBusinessEntityAddress>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBusinessEntityAddress> BusinessEntityAddressUpdateAsync(int id, BusinessEntityAddressModel item)
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

		public virtual async Task<List<POCOBusinessEntityAddress>> BusinessEntityAddressSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBusinessEntityAddress>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBusinessEntityAddress> BusinessEntityAddressGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBusinessEntityAddress>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBusinessEntityAddress>> BusinessEntityAddressGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityAddresses?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBusinessEntityAddress>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> BusinessEntityAddressBulkInsertAsync(List<BusinessEntityAddressModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityAddresses/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBusinessEntityContact> BusinessEntityContactCreateAsync(BusinessEntityContactModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityContacts", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBusinessEntityContact>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBusinessEntityContact> BusinessEntityContactUpdateAsync(int id, BusinessEntityContactModel item)
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

		public virtual async Task<List<POCOBusinessEntityContact>> BusinessEntityContactSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBusinessEntityContact>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBusinessEntityContact> BusinessEntityContactGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBusinessEntityContact>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBusinessEntityContact>> BusinessEntityContactGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BusinessEntityContacts?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBusinessEntityContact>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> BusinessEntityContactBulkInsertAsync(List<BusinessEntityContactModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BusinessEntityContacts/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOContactType> ContactTypeCreateAsync(ContactTypeModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ContactTypes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOContactType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOContactType> ContactTypeUpdateAsync(int id, ContactTypeModel item)
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

		public virtual async Task<List<POCOContactType>> ContactTypeSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ContactTypes?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOContactType>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOContactType> ContactTypeGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ContactTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOContactType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOContactType>> ContactTypeGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ContactTypes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOContactType>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ContactTypeBulkInsertAsync(List<ContactTypeModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ContactTypes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCountryRegion> CountryRegionCreateAsync(CountryRegionModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRegions", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCountryRegion>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCountryRegion> CountryRegionUpdateAsync(string id, CountryRegionModel item)
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

		public virtual async Task<List<POCOCountryRegion>> CountryRegionSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegions?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCountryRegion>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCountryRegion> CountryRegionGetByIdAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegions/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCountryRegion>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCountryRegion>> CountryRegionGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegions?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCountryRegion>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<string>> CountryRegionBulkInsertAsync(List<CountryRegionModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRegions/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<string>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmailAddress> EmailAddressCreateAsync(EmailAddressModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmailAddresses", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmailAddress>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmailAddress> EmailAddressUpdateAsync(int id, EmailAddressModel item)
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

		public virtual async Task<List<POCOEmailAddress>> EmailAddressSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmailAddresses?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmailAddress>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOEmailAddress> EmailAddressGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmailAddresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOEmailAddress>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOEmailAddress>> EmailAddressGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EmailAddresses?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOEmailAddress>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> EmailAddressBulkInsertAsync(List<EmailAddressModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EmailAddresses/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPassword> PasswordCreateAsync(PasswordModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Passwords", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPassword>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPassword> PasswordUpdateAsync(int id, PasswordModel item)
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

		public virtual async Task<List<POCOPassword>> PasswordSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Passwords?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPassword>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPassword> PasswordGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Passwords/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPassword>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPassword>> PasswordGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Passwords?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPassword>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> PasswordBulkInsertAsync(List<PasswordModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Passwords/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPerson> PersonCreateAsync(PersonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/People", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPerson>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPerson> PersonUpdateAsync(int id, PersonModel item)
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

		public virtual async Task<List<POCOPerson>> PersonSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPerson>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPerson> PersonGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPerson>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPerson>> PersonGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/People?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPerson>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> PersonBulkInsertAsync(List<PersonModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/People/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPersonPhone> PersonPhoneCreateAsync(PersonPhoneModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonPhones", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPersonPhone>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPersonPhone> PersonPhoneUpdateAsync(int id, PersonPhoneModel item)
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

		public virtual async Task<List<POCOPersonPhone>> PersonPhoneSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonPhones?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPersonPhone>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPersonPhone> PersonPhoneGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonPhones/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPersonPhone>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPersonPhone>> PersonPhoneGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonPhones?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPersonPhone>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> PersonPhoneBulkInsertAsync(List<PersonPhoneModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonPhones/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPhoneNumberType> PhoneNumberTypeCreateAsync(PhoneNumberTypeModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PhoneNumberTypes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPhoneNumberType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPhoneNumberType> PhoneNumberTypeUpdateAsync(int id, PhoneNumberTypeModel item)
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

		public virtual async Task<List<POCOPhoneNumberType>> PhoneNumberTypeSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PhoneNumberTypes?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPhoneNumberType>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPhoneNumberType> PhoneNumberTypeGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PhoneNumberTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPhoneNumberType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPhoneNumberType>> PhoneNumberTypeGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PhoneNumberTypes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPhoneNumberType>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> PhoneNumberTypeBulkInsertAsync(List<PhoneNumberTypeModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PhoneNumberTypes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStateProvince> StateProvinceCreateAsync(StateProvinceModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/StateProvinces", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStateProvince>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStateProvince> StateProvinceUpdateAsync(int id, StateProvinceModel item)
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

		public virtual async Task<List<POCOStateProvince>> StateProvinceSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStateProvince>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStateProvince> StateProvinceGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStateProvince>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOStateProvince>> StateProvinceGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StateProvinces?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStateProvince>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> StateProvinceBulkInsertAsync(List<StateProvinceModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/StateProvinces/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBillOfMaterials> BillOfMaterialsCreateAsync(BillOfMaterialsModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BillOfMaterials", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBillOfMaterials>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBillOfMaterials> BillOfMaterialsUpdateAsync(int id, BillOfMaterialsModel item)
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

		public virtual async Task<List<POCOBillOfMaterials>> BillOfMaterialsSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BillOfMaterials?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBillOfMaterials>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBillOfMaterials> BillOfMaterialsGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BillOfMaterials/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBillOfMaterials>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBillOfMaterials>> BillOfMaterialsGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/BillOfMaterials?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBillOfMaterials>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> BillOfMaterialsBulkInsertAsync(List<BillOfMaterialsModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/BillOfMaterials/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCulture> CultureCreateAsync(CultureModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Cultures", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCulture>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCulture> CultureUpdateAsync(string id, CultureModel item)
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

		public virtual async Task<List<POCOCulture>> CultureSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cultures?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCulture>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCulture> CultureGetByIdAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cultures/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCulture>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCulture>> CultureGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Cultures?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCulture>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<string>> CultureBulkInsertAsync(List<CultureModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Cultures/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<string>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODocument> DocumentCreateAsync(DocumentModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Documents", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODocument>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODocument> DocumentUpdateAsync(Guid id, DocumentModel item)
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

		public virtual async Task<List<POCODocument>> DocumentSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Documents?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCODocument>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCODocument> DocumentGetByIdAsync(Guid id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Documents/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCODocument>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCODocument>> DocumentGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Documents?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCODocument>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<Guid>> DocumentBulkInsertAsync(List<DocumentModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Documents/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<Guid>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOIllustration> IllustrationCreateAsync(IllustrationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Illustrations", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOIllustration>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOIllustration> IllustrationUpdateAsync(int id, IllustrationModel item)
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

		public virtual async Task<List<POCOIllustration>> IllustrationSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Illustrations?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOIllustration>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOIllustration> IllustrationGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Illustrations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOIllustration>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOIllustration>> IllustrationGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Illustrations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOIllustration>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> IllustrationBulkInsertAsync(List<IllustrationModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Illustrations/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLocation> LocationCreateAsync(LocationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Locations", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLocation>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLocation> LocationUpdateAsync(short id, LocationModel item)
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

		public virtual async Task<List<POCOLocation>> LocationSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLocation>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLocation> LocationGetByIdAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLocation>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLocation>> LocationGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLocation>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<short>> LocationBulkInsertAsync(List<LocationModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Locations/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<short>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProduct> ProductCreateAsync(ProductModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Products", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProduct>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProduct> ProductUpdateAsync(int id, ProductModel item)
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

		public virtual async Task<List<POCOProduct>> ProductSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProduct>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProduct> ProductGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProduct>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProduct>> ProductGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Products?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProduct>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ProductBulkInsertAsync(List<ProductModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Products/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductCategory> ProductCategoryCreateAsync(ProductCategoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCategories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductCategory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductCategory> ProductCategoryUpdateAsync(int id, ProductCategoryModel item)
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

		public virtual async Task<List<POCOProductCategory>> ProductCategorySearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCategories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductCategory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductCategory> ProductCategoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCategories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductCategory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductCategory>> ProductCategoryGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCategories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductCategory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ProductCategoryBulkInsertAsync(List<ProductCategoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCategories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductCostHistory> ProductCostHistoryCreateAsync(ProductCostHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCostHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductCostHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductCostHistory> ProductCostHistoryUpdateAsync(int id, ProductCostHistoryModel item)
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

		public virtual async Task<List<POCOProductCostHistory>> ProductCostHistorySearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCostHistories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductCostHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductCostHistory> ProductCostHistoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCostHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductCostHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductCostHistory>> ProductCostHistoryGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductCostHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductCostHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ProductCostHistoryBulkInsertAsync(List<ProductCostHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductCostHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductDescription> ProductDescriptionCreateAsync(ProductDescriptionModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductDescriptions", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductDescription>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductDescription> ProductDescriptionUpdateAsync(int id, ProductDescriptionModel item)
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

		public virtual async Task<List<POCOProductDescription>> ProductDescriptionSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDescriptions?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductDescription>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductDescription> ProductDescriptionGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDescriptions/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductDescription>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductDescription>> ProductDescriptionGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDescriptions?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductDescription>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ProductDescriptionBulkInsertAsync(List<ProductDescriptionModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductDescriptions/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductDocument> ProductDocumentCreateAsync(ProductDocumentModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductDocuments", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductDocument>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductDocument> ProductDocumentUpdateAsync(int id, ProductDocumentModel item)
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

		public virtual async Task<List<POCOProductDocument>> ProductDocumentSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDocuments?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductDocument>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductDocument> ProductDocumentGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDocuments/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductDocument>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductDocument>> ProductDocumentGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductDocuments?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductDocument>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ProductDocumentBulkInsertAsync(List<ProductDocumentModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductDocuments/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductInventory> ProductInventoryCreateAsync(ProductInventoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductInventories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductInventory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductInventory> ProductInventoryUpdateAsync(int id, ProductInventoryModel item)
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

		public virtual async Task<List<POCOProductInventory>> ProductInventorySearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductInventories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductInventory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductInventory> ProductInventoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductInventories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductInventory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductInventory>> ProductInventoryGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductInventories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductInventory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ProductInventoryBulkInsertAsync(List<ProductInventoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductInventories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductListPriceHistory> ProductListPriceHistoryCreateAsync(ProductListPriceHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductListPriceHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductListPriceHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductListPriceHistory> ProductListPriceHistoryUpdateAsync(int id, ProductListPriceHistoryModel item)
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

		public virtual async Task<List<POCOProductListPriceHistory>> ProductListPriceHistorySearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductListPriceHistories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductListPriceHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductListPriceHistory> ProductListPriceHistoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductListPriceHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductListPriceHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductListPriceHistory>> ProductListPriceHistoryGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductListPriceHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductListPriceHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ProductListPriceHistoryBulkInsertAsync(List<ProductListPriceHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductListPriceHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductModel> ProductModelCreateAsync(ProductModelModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModels", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductModel> ProductModelUpdateAsync(int id, ProductModelModel item)
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

		public virtual async Task<List<POCOProductModel>> ProductModelSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductModel> ProductModelGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductModel>> ProductModelGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModels?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ProductModelBulkInsertAsync(List<ProductModelModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModels/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductModelIllustration> ProductModelIllustrationCreateAsync(ProductModelIllustrationModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModelIllustrations", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductModelIllustration>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductModelIllustration> ProductModelIllustrationUpdateAsync(int id, ProductModelIllustrationModel item)
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

		public virtual async Task<List<POCOProductModelIllustration>> ProductModelIllustrationSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelIllustrations?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductModelIllustration>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductModelIllustration> ProductModelIllustrationGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelIllustrations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductModelIllustration>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductModelIllustration>> ProductModelIllustrationGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelIllustrations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductModelIllustration>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ProductModelIllustrationBulkInsertAsync(List<ProductModelIllustrationModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModelIllustrations/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductModelProductDescriptionCulture> ProductModelProductDescriptionCultureCreateAsync(ProductModelProductDescriptionCultureModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModelProductDescriptionCultures", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductModelProductDescriptionCulture>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductModelProductDescriptionCulture> ProductModelProductDescriptionCultureUpdateAsync(int id, ProductModelProductDescriptionCultureModel item)
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

		public virtual async Task<List<POCOProductModelProductDescriptionCulture>> ProductModelProductDescriptionCultureSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelProductDescriptionCultures?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductModelProductDescriptionCulture>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductModelProductDescriptionCulture> ProductModelProductDescriptionCultureGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelProductDescriptionCultures/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductModelProductDescriptionCulture>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductModelProductDescriptionCulture>> ProductModelProductDescriptionCultureGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductModelProductDescriptionCultures?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductModelProductDescriptionCulture>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ProductModelProductDescriptionCultureBulkInsertAsync(List<ProductModelProductDescriptionCultureModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductModelProductDescriptionCultures/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductPhoto> ProductPhotoCreateAsync(ProductPhotoModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductPhotoes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductPhoto>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductPhoto> ProductPhotoUpdateAsync(int id, ProductPhotoModel item)
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

		public virtual async Task<List<POCOProductPhoto>> ProductPhotoSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductPhotoes?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductPhoto>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductPhoto> ProductPhotoGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductPhotoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductPhoto>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductPhoto>> ProductPhotoGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductPhotoes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductPhoto>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ProductPhotoBulkInsertAsync(List<ProductPhotoModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductPhotoes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductProductPhoto> ProductProductPhotoCreateAsync(ProductProductPhotoModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductProductPhotoes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductProductPhoto>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductProductPhoto> ProductProductPhotoUpdateAsync(int id, ProductProductPhotoModel item)
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

		public virtual async Task<List<POCOProductProductPhoto>> ProductProductPhotoSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductProductPhotoes?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductProductPhoto>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductProductPhoto> ProductProductPhotoGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductProductPhotoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductProductPhoto>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductProductPhoto>> ProductProductPhotoGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductProductPhotoes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductProductPhoto>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ProductProductPhotoBulkInsertAsync(List<ProductProductPhotoModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductProductPhotoes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductReview> ProductReviewCreateAsync(ProductReviewModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductReviews", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductReview>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductReview> ProductReviewUpdateAsync(int id, ProductReviewModel item)
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

		public virtual async Task<List<POCOProductReview>> ProductReviewSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductReviews?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductReview>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductReview> ProductReviewGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductReviews/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductReview>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductReview>> ProductReviewGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductReviews?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductReview>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ProductReviewBulkInsertAsync(List<ProductReviewModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductReviews/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductSubcategory> ProductSubcategoryCreateAsync(ProductSubcategoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductSubcategories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductSubcategory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductSubcategory> ProductSubcategoryUpdateAsync(int id, ProductSubcategoryModel item)
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

		public virtual async Task<List<POCOProductSubcategory>> ProductSubcategorySearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductSubcategories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductSubcategory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductSubcategory> ProductSubcategoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductSubcategories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductSubcategory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductSubcategory>> ProductSubcategoryGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductSubcategories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductSubcategory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ProductSubcategoryBulkInsertAsync(List<ProductSubcategoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductSubcategories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOScrapReason> ScrapReasonCreateAsync(ScrapReasonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ScrapReasons", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOScrapReason>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOScrapReason> ScrapReasonUpdateAsync(short id, ScrapReasonModel item)
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

		public virtual async Task<List<POCOScrapReason>> ScrapReasonSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ScrapReasons?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOScrapReason>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOScrapReason> ScrapReasonGetByIdAsync(short id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ScrapReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOScrapReason>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOScrapReason>> ScrapReasonGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ScrapReasons?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOScrapReason>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<short>> ScrapReasonBulkInsertAsync(List<ScrapReasonModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ScrapReasons/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<short>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTransactionHistory> TransactionHistoryCreateAsync(TransactionHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTransactionHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTransactionHistory> TransactionHistoryUpdateAsync(int id, TransactionHistoryModel item)
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

		public virtual async Task<List<POCOTransactionHistory>> TransactionHistorySearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTransactionHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTransactionHistory> TransactionHistoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTransactionHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTransactionHistory>> TransactionHistoryGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTransactionHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> TransactionHistoryBulkInsertAsync(List<TransactionHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTransactionHistoryArchive> TransactionHistoryArchiveCreateAsync(TransactionHistoryArchiveModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistoryArchives", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTransactionHistoryArchive>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTransactionHistoryArchive> TransactionHistoryArchiveUpdateAsync(int id, TransactionHistoryArchiveModel item)
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

		public virtual async Task<List<POCOTransactionHistoryArchive>> TransactionHistoryArchiveSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTransactionHistoryArchive>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTransactionHistoryArchive> TransactionHistoryArchiveGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTransactionHistoryArchive>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTransactionHistoryArchive>> TransactionHistoryArchiveGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TransactionHistoryArchives?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTransactionHistoryArchive>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> TransactionHistoryArchiveBulkInsertAsync(List<TransactionHistoryArchiveModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TransactionHistoryArchives/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOUnitMeasure> UnitMeasureCreateAsync(UnitMeasureModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/UnitMeasures", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOUnitMeasure>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOUnitMeasure> UnitMeasureUpdateAsync(string id, UnitMeasureModel item)
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

		public virtual async Task<List<POCOUnitMeasure>> UnitMeasureSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UnitMeasures?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOUnitMeasure>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOUnitMeasure> UnitMeasureGetByIdAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UnitMeasures/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOUnitMeasure>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOUnitMeasure>> UnitMeasureGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/UnitMeasures?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOUnitMeasure>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<string>> UnitMeasureBulkInsertAsync(List<UnitMeasureModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/UnitMeasures/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<string>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOWorkOrder> WorkOrderCreateAsync(WorkOrderModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrders", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOWorkOrder>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOWorkOrder> WorkOrderUpdateAsync(int id, WorkOrderModel item)
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

		public virtual async Task<List<POCOWorkOrder>> WorkOrderSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOWorkOrder>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOWorkOrder> WorkOrderGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOWorkOrder>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOWorkOrder>> WorkOrderGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrders?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOWorkOrder>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> WorkOrderBulkInsertAsync(List<WorkOrderModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrders/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOWorkOrderRouting> WorkOrderRoutingCreateAsync(WorkOrderRoutingModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrderRoutings", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOWorkOrderRouting>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOWorkOrderRouting> WorkOrderRoutingUpdateAsync(int id, WorkOrderRoutingModel item)
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

		public virtual async Task<List<POCOWorkOrderRouting>> WorkOrderRoutingSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrderRoutings?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOWorkOrderRouting>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOWorkOrderRouting> WorkOrderRoutingGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrderRoutings/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOWorkOrderRouting>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOWorkOrderRouting>> WorkOrderRoutingGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/WorkOrderRoutings?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOWorkOrderRouting>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> WorkOrderRoutingBulkInsertAsync(List<WorkOrderRoutingModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/WorkOrderRoutings/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductVendor> ProductVendorCreateAsync(ProductVendorModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductVendors", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductVendor>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductVendor> ProductVendorUpdateAsync(int id, ProductVendorModel item)
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

		public virtual async Task<List<POCOProductVendor>> ProductVendorSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductVendor>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOProductVendor> ProductVendorGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOProductVendor>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOProductVendor>> ProductVendorGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ProductVendors?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOProductVendor>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ProductVendorBulkInsertAsync(List<ProductVendorModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ProductVendors/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPurchaseOrderDetail> PurchaseOrderDetailCreateAsync(PurchaseOrderDetailModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderDetails", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPurchaseOrderDetail>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPurchaseOrderDetail> PurchaseOrderDetailUpdateAsync(int id, PurchaseOrderDetailModel item)
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

		public virtual async Task<List<POCOPurchaseOrderDetail>> PurchaseOrderDetailSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderDetails?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPurchaseOrderDetail>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPurchaseOrderDetail> PurchaseOrderDetailGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderDetails/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPurchaseOrderDetail>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPurchaseOrderDetail>> PurchaseOrderDetailGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderDetails?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPurchaseOrderDetail>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> PurchaseOrderDetailBulkInsertAsync(List<PurchaseOrderDetailModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderDetails/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPurchaseOrderHeader> PurchaseOrderHeaderCreateAsync(PurchaseOrderHeaderModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderHeaders", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPurchaseOrderHeader>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPurchaseOrderHeader> PurchaseOrderHeaderUpdateAsync(int id, PurchaseOrderHeaderModel item)
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

		public virtual async Task<List<POCOPurchaseOrderHeader>> PurchaseOrderHeaderSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPurchaseOrderHeader>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPurchaseOrderHeader> PurchaseOrderHeaderGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPurchaseOrderHeader>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPurchaseOrderHeader>> PurchaseOrderHeaderGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PurchaseOrderHeaders?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPurchaseOrderHeader>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> PurchaseOrderHeaderBulkInsertAsync(List<PurchaseOrderHeaderModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PurchaseOrderHeaders/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOShipMethod> ShipMethodCreateAsync(ShipMethodModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShipMethods", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOShipMethod>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOShipMethod> ShipMethodUpdateAsync(int id, ShipMethodModel item)
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

		public virtual async Task<List<POCOShipMethod>> ShipMethodSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShipMethods?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOShipMethod>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOShipMethod> ShipMethodGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShipMethods/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOShipMethod>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOShipMethod>> ShipMethodGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShipMethods?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOShipMethod>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ShipMethodBulkInsertAsync(List<ShipMethodModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShipMethods/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOVendor> VendorCreateAsync(VendorModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Vendors", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOVendor>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOVendor> VendorUpdateAsync(int id, VendorModel item)
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

		public virtual async Task<List<POCOVendor>> VendorSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Vendors?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOVendor>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOVendor> VendorGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Vendors/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOVendor>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOVendor>> VendorGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Vendors?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOVendor>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> VendorBulkInsertAsync(List<VendorModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Vendors/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCountryRegionCurrency> CountryRegionCurrencyCreateAsync(CountryRegionCurrencyModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRegionCurrencies", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCountryRegionCurrency>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCountryRegionCurrency> CountryRegionCurrencyUpdateAsync(string id, CountryRegionCurrencyModel item)
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

		public virtual async Task<List<POCOCountryRegionCurrency>> CountryRegionCurrencySearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegionCurrencies?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCountryRegionCurrency>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCountryRegionCurrency> CountryRegionCurrencyGetByIdAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegionCurrencies/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCountryRegionCurrency>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCountryRegionCurrency>> CountryRegionCurrencyGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CountryRegionCurrencies?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCountryRegionCurrency>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<string>> CountryRegionCurrencyBulkInsertAsync(List<CountryRegionCurrencyModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CountryRegionCurrencies/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<string>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCreditCard> CreditCardCreateAsync(CreditCardModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CreditCards", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCreditCard>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCreditCard> CreditCardUpdateAsync(int id, CreditCardModel item)
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

		public virtual async Task<List<POCOCreditCard>> CreditCardSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CreditCards?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCreditCard>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCreditCard> CreditCardGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CreditCards/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCreditCard>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCreditCard>> CreditCardGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CreditCards?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCreditCard>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> CreditCardBulkInsertAsync(List<CreditCardModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CreditCards/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCurrency> CurrencyCreateAsync(CurrencyModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Currencies", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCurrency>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCurrency> CurrencyUpdateAsync(string id, CurrencyModel item)
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

		public virtual async Task<List<POCOCurrency>> CurrencySearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCurrency>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCurrency> CurrencyGetByIdAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCurrency>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCurrency>> CurrencyGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Currencies?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCurrency>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<string>> CurrencyBulkInsertAsync(List<CurrencyModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Currencies/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<string>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCurrencyRate> CurrencyRateCreateAsync(CurrencyRateModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CurrencyRates", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCurrencyRate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCurrencyRate> CurrencyRateUpdateAsync(int id, CurrencyRateModel item)
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

		public virtual async Task<List<POCOCurrencyRate>> CurrencyRateSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CurrencyRates?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCurrencyRate>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCurrencyRate> CurrencyRateGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CurrencyRates/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCurrencyRate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCurrencyRate>> CurrencyRateGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/CurrencyRates?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCurrencyRate>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> CurrencyRateBulkInsertAsync(List<CurrencyRateModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/CurrencyRates/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCustomer> CustomerCreateAsync(CustomerModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Customers", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCustomer>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCustomer> CustomerUpdateAsync(int id, CustomerModel item)
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

		public virtual async Task<List<POCOCustomer>> CustomerSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCustomer>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOCustomer> CustomerGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOCustomer>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOCustomer>> CustomerGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Customers?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOCustomer>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> CustomerBulkInsertAsync(List<CustomerModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Customers/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPersonCreditCard> PersonCreditCardCreateAsync(PersonCreditCardModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonCreditCards", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPersonCreditCard>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPersonCreditCard> PersonCreditCardUpdateAsync(int id, PersonCreditCardModel item)
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

		public virtual async Task<List<POCOPersonCreditCard>> PersonCreditCardSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonCreditCards?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPersonCreditCard>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOPersonCreditCard> PersonCreditCardGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonCreditCards/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOPersonCreditCard>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOPersonCreditCard>> PersonCreditCardGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonCreditCards?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOPersonCreditCard>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> PersonCreditCardBulkInsertAsync(List<PersonCreditCardModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonCreditCards/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesOrderDetail> SalesOrderDetailCreateAsync(SalesOrderDetailModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderDetails", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesOrderDetail>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesOrderDetail> SalesOrderDetailUpdateAsync(int id, SalesOrderDetailModel item)
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

		public virtual async Task<List<POCOSalesOrderDetail>> SalesOrderDetailSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderDetails?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesOrderDetail>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesOrderDetail> SalesOrderDetailGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderDetails/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesOrderDetail>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesOrderDetail>> SalesOrderDetailGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderDetails?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesOrderDetail>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> SalesOrderDetailBulkInsertAsync(List<SalesOrderDetailModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderDetails/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesOrderHeader> SalesOrderHeaderCreateAsync(SalesOrderHeaderModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderHeaders", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesOrderHeader>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesOrderHeader> SalesOrderHeaderUpdateAsync(int id, SalesOrderHeaderModel item)
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

		public virtual async Task<List<POCOSalesOrderHeader>> SalesOrderHeaderSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesOrderHeader>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesOrderHeader> SalesOrderHeaderGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesOrderHeader>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesOrderHeader>> SalesOrderHeaderGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaders?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesOrderHeader>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> SalesOrderHeaderBulkInsertAsync(List<SalesOrderHeaderModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderHeaders/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasonCreateAsync(SalesOrderHeaderSalesReasonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderHeaderSalesReasons", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesOrderHeaderSalesReason>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasonUpdateAsync(int id, SalesOrderHeaderSalesReasonModel item)
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

		public virtual async Task<List<POCOSalesOrderHeaderSalesReason>> SalesOrderHeaderSalesReasonSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaderSalesReasons?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesOrderHeaderSalesReason>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasonGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaderSalesReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesOrderHeaderSalesReason>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesOrderHeaderSalesReason>> SalesOrderHeaderSalesReasonGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesOrderHeaderSalesReasons?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesOrderHeaderSalesReason>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> SalesOrderHeaderSalesReasonBulkInsertAsync(List<SalesOrderHeaderSalesReasonModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesOrderHeaderSalesReasons/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesPerson> SalesPersonCreateAsync(SalesPersonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersons", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesPerson>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesPerson> SalesPersonUpdateAsync(int id, SalesPersonModel item)
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

		public virtual async Task<List<POCOSalesPerson>> SalesPersonSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersons?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesPerson>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesPerson> SalesPersonGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersons/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesPerson>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesPerson>> SalesPersonGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersons?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesPerson>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> SalesPersonBulkInsertAsync(List<SalesPersonModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersons/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesPersonQuotaHistory> SalesPersonQuotaHistoryCreateAsync(SalesPersonQuotaHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersonQuotaHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesPersonQuotaHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesPersonQuotaHistory> SalesPersonQuotaHistoryUpdateAsync(int id, SalesPersonQuotaHistoryModel item)
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

		public virtual async Task<List<POCOSalesPersonQuotaHistory>> SalesPersonQuotaHistorySearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersonQuotaHistories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesPersonQuotaHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesPersonQuotaHistory> SalesPersonQuotaHistoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersonQuotaHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesPersonQuotaHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesPersonQuotaHistory>> SalesPersonQuotaHistoryGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesPersonQuotaHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesPersonQuotaHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> SalesPersonQuotaHistoryBulkInsertAsync(List<SalesPersonQuotaHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesPersonQuotaHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesReason> SalesReasonCreateAsync(SalesReasonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesReasons", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesReason>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesReason> SalesReasonUpdateAsync(int id, SalesReasonModel item)
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

		public virtual async Task<List<POCOSalesReason>> SalesReasonSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesReasons?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesReason>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesReason> SalesReasonGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesReason>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesReason>> SalesReasonGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesReasons?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesReason>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> SalesReasonBulkInsertAsync(List<SalesReasonModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesReasons/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesTaxRate> SalesTaxRateCreateAsync(SalesTaxRateModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTaxRates", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesTaxRate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesTaxRate> SalesTaxRateUpdateAsync(int id, SalesTaxRateModel item)
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

		public virtual async Task<List<POCOSalesTaxRate>> SalesTaxRateSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTaxRates?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesTaxRate>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesTaxRate> SalesTaxRateGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTaxRates/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesTaxRate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesTaxRate>> SalesTaxRateGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTaxRates?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesTaxRate>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> SalesTaxRateBulkInsertAsync(List<SalesTaxRateModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTaxRates/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesTerritory> SalesTerritoryCreateAsync(SalesTerritoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesTerritory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesTerritory> SalesTerritoryUpdateAsync(int id, SalesTerritoryModel item)
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

		public virtual async Task<List<POCOSalesTerritory>> SalesTerritorySearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesTerritory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesTerritory> SalesTerritoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesTerritory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesTerritory>> SalesTerritoryGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesTerritory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> SalesTerritoryBulkInsertAsync(List<SalesTerritoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesTerritoryHistory> SalesTerritoryHistoryCreateAsync(SalesTerritoryHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritoryHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesTerritoryHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesTerritoryHistory> SalesTerritoryHistoryUpdateAsync(int id, SalesTerritoryHistoryModel item)
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

		public virtual async Task<List<POCOSalesTerritoryHistory>> SalesTerritoryHistorySearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritoryHistories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesTerritoryHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSalesTerritoryHistory> SalesTerritoryHistoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritoryHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSalesTerritoryHistory>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSalesTerritoryHistory>> SalesTerritoryHistoryGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SalesTerritoryHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSalesTerritoryHistory>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> SalesTerritoryHistoryBulkInsertAsync(List<SalesTerritoryHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SalesTerritoryHistories/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOShoppingCartItem> ShoppingCartItemCreateAsync(ShoppingCartItemModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShoppingCartItems", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOShoppingCartItem>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOShoppingCartItem> ShoppingCartItemUpdateAsync(int id, ShoppingCartItemModel item)
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

		public virtual async Task<List<POCOShoppingCartItem>> ShoppingCartItemSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShoppingCartItems?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOShoppingCartItem>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOShoppingCartItem> ShoppingCartItemGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShoppingCartItems/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOShoppingCartItem>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOShoppingCartItem>> ShoppingCartItemGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/ShoppingCartItems?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOShoppingCartItem>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> ShoppingCartItemBulkInsertAsync(List<ShoppingCartItemModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/ShoppingCartItems/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpecialOffer> SpecialOfferCreateAsync(SpecialOfferModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOffers", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpecialOffer>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpecialOffer> SpecialOfferUpdateAsync(int id, SpecialOfferModel item)
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

		public virtual async Task<List<POCOSpecialOffer>> SpecialOfferSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOffers?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpecialOffer>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpecialOffer> SpecialOfferGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOffers/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpecialOffer>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpecialOffer>> SpecialOfferGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOffers?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpecialOffer>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> SpecialOfferBulkInsertAsync(List<SpecialOfferModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOffers/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpecialOfferProduct> SpecialOfferProductCreateAsync(SpecialOfferProductModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOfferProducts", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpecialOfferProduct>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpecialOfferProduct> SpecialOfferProductUpdateAsync(int id, SpecialOfferProductModel item)
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

		public virtual async Task<List<POCOSpecialOfferProduct>> SpecialOfferProductSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOfferProducts?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpecialOfferProduct>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpecialOfferProduct> SpecialOfferProductGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOfferProducts/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpecialOfferProduct>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpecialOfferProduct>> SpecialOfferProductGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpecialOfferProducts?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpecialOfferProduct>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> SpecialOfferProductBulkInsertAsync(List<SpecialOfferProductModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpecialOfferProducts/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStore> StoreCreateAsync(StoreModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Stores", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStore>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStore> StoreUpdateAsync(int id, StoreModel item)
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

		public virtual async Task<List<POCOStore>> StoreSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStore>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStore> StoreGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStore>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOStore>> StoreGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Stores?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStore>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> StoreBulkInsertAsync(List<StoreModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Stores/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>feedf262c7c3528d74acadfb8a73f70d</Hash>
</Codenesium>*/