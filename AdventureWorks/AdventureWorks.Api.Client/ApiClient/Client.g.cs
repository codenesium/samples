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
	public abstract partial class AbstractApiClient
	{
		public HttpClient _client;
		protected string ApiUrl { get; set; }
		public AbstractApiClient(string apiUri)
		{
			if (String.IsNullOrWhiteSpace(apiUri))
			{
				throw new ArgumentException("apiUrl is not set");
			}
			if (apiUri[apiUri.Length - 1] != '/')
			{
				throw new ArgumentException("The apiUrl must end in a / for httpClient to work correctly");
			}

			this.ApiUrl = apiUri;
			this._client = new HttpClient();

			this._client.BaseAddress = new Uri(apiUri);

			this._client.DefaultRequestHeaders.Accept.Clear();
			this._client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public virtual async Task<List<POCOAWBuildVersion>>AWBuildVersionSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/AWBuildVersions?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).AWBuildVersions;
		}

		public virtual async Task<List<POCOAWBuildVersion>> AWBuildVersionGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/AWBuildVersions/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).AWBuildVersions;
		}

		public virtual async Task<POCOAWBuildVersion> AWBuildVersionGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/AWBuildVersions/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).AWBuildVersions.FirstOrDefault();
		}

		public virtual async Task<List<POCOAWBuildVersion>> AWBuildVersionGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/AWBuildVersions?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).AWBuildVersions;
		}

		public virtual async Task AWBuildVersionDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/AWBuildVersions/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task AWBuildVersionUpdateAsync(int id,AWBuildVersionModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/AWBuildVersions/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> AWBuildVersionCreateAsync(AWBuildVersionModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/AWBuildVersions", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task AWBuildVersionCreateManyAsync(List<AWBuildVersionModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/AWBuildVersions/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCODatabaseLog>>DatabaseLogSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/DatabaseLogs?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).DatabaseLogs;
		}

		public virtual async Task<List<POCODatabaseLog>> DatabaseLogGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/DatabaseLogs/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).DatabaseLogs;
		}

		public virtual async Task<POCODatabaseLog> DatabaseLogGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/DatabaseLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).DatabaseLogs.FirstOrDefault();
		}

		public virtual async Task<List<POCODatabaseLog>> DatabaseLogGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/DatabaseLogs?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).DatabaseLogs;
		}

		public virtual async Task DatabaseLogDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/DatabaseLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task DatabaseLogUpdateAsync(int id,DatabaseLogModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/DatabaseLogs/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> DatabaseLogCreateAsync(DatabaseLogModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/DatabaseLogs", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task DatabaseLogCreateManyAsync(List<DatabaseLogModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/DatabaseLogs/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOErrorLog>>ErrorLogSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ErrorLogs?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ErrorLogs;
		}

		public virtual async Task<List<POCOErrorLog>> ErrorLogGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ErrorLogs/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ErrorLogs;
		}

		public virtual async Task<POCOErrorLog> ErrorLogGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ErrorLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ErrorLogs.FirstOrDefault();
		}

		public virtual async Task<List<POCOErrorLog>> ErrorLogGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ErrorLogs?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ErrorLogs;
		}

		public virtual async Task ErrorLogDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ErrorLogs/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ErrorLogUpdateAsync(int id,ErrorLogModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ErrorLogs/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ErrorLogCreateAsync(ErrorLogModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ErrorLogs", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ErrorLogCreateManyAsync(List<ErrorLogModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ErrorLogs/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCODepartment>>DepartmentSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Departments?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Departments;
		}

		public virtual async Task<List<POCODepartment>> DepartmentGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Departments/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Departments;
		}

		public virtual async Task<POCODepartment> DepartmentGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Departments/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Departments.FirstOrDefault();
		}

		public virtual async Task<List<POCODepartment>> DepartmentGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Departments?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Departments;
		}

		public virtual async Task DepartmentDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Departments/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task DepartmentUpdateAsync(int id,DepartmentModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Departments/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> DepartmentCreateAsync(DepartmentModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Departments", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task DepartmentCreateManyAsync(List<DepartmentModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Departments/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOEmployee>>EmployeeSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Employees?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Employees;
		}

		public virtual async Task<List<POCOEmployee>> EmployeeGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Employees/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Employees;
		}

		public virtual async Task<POCOEmployee> EmployeeGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Employees/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Employees.FirstOrDefault();
		}

		public virtual async Task<List<POCOEmployee>> EmployeeGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Employees?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Employees;
		}

		public virtual async Task EmployeeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Employees/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task EmployeeUpdateAsync(int id,EmployeeModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Employees/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> EmployeeCreateAsync(EmployeeModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Employees", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task EmployeeCreateManyAsync(List<EmployeeModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Employees/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOEmployeeDepartmentHistory>>EmployeeDepartmentHistorySearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/EmployeeDepartmentHistories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).EmployeeDepartmentHistories;
		}

		public virtual async Task<List<POCOEmployeeDepartmentHistory>> EmployeeDepartmentHistoryGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/EmployeeDepartmentHistories/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).EmployeeDepartmentHistories;
		}

		public virtual async Task<POCOEmployeeDepartmentHistory> EmployeeDepartmentHistoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/EmployeeDepartmentHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).EmployeeDepartmentHistories.FirstOrDefault();
		}

		public virtual async Task<List<POCOEmployeeDepartmentHistory>> EmployeeDepartmentHistoryGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/EmployeeDepartmentHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).EmployeeDepartmentHistories;
		}

		public virtual async Task EmployeeDepartmentHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/EmployeeDepartmentHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task EmployeeDepartmentHistoryUpdateAsync(int id,EmployeeDepartmentHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/EmployeeDepartmentHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> EmployeeDepartmentHistoryCreateAsync(EmployeeDepartmentHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/EmployeeDepartmentHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task EmployeeDepartmentHistoryCreateManyAsync(List<EmployeeDepartmentHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/EmployeeDepartmentHistories/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOEmployeePayHistory>>EmployeePayHistorySearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/EmployeePayHistories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).EmployeePayHistories;
		}

		public virtual async Task<List<POCOEmployeePayHistory>> EmployeePayHistoryGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/EmployeePayHistories/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).EmployeePayHistories;
		}

		public virtual async Task<POCOEmployeePayHistory> EmployeePayHistoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/EmployeePayHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).EmployeePayHistories.FirstOrDefault();
		}

		public virtual async Task<List<POCOEmployeePayHistory>> EmployeePayHistoryGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/EmployeePayHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).EmployeePayHistories;
		}

		public virtual async Task EmployeePayHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/EmployeePayHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task EmployeePayHistoryUpdateAsync(int id,EmployeePayHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/EmployeePayHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> EmployeePayHistoryCreateAsync(EmployeePayHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/EmployeePayHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task EmployeePayHistoryCreateManyAsync(List<EmployeePayHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/EmployeePayHistories/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOJobCandidate>>JobCandidateSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/JobCandidates?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).JobCandidates;
		}

		public virtual async Task<List<POCOJobCandidate>> JobCandidateGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/JobCandidates/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).JobCandidates;
		}

		public virtual async Task<POCOJobCandidate> JobCandidateGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/JobCandidates/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).JobCandidates.FirstOrDefault();
		}

		public virtual async Task<List<POCOJobCandidate>> JobCandidateGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/JobCandidates?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).JobCandidates;
		}

		public virtual async Task JobCandidateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/JobCandidates/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task JobCandidateUpdateAsync(int id,JobCandidateModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/JobCandidates/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> JobCandidateCreateAsync(JobCandidateModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/JobCandidates", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task JobCandidateCreateManyAsync(List<JobCandidateModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/JobCandidates/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOShift>>ShiftSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Shifts?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Shifts;
		}

		public virtual async Task<List<POCOShift>> ShiftGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Shifts/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Shifts;
		}

		public virtual async Task<POCOShift> ShiftGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Shifts/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Shifts.FirstOrDefault();
		}

		public virtual async Task<List<POCOShift>> ShiftGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Shifts?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Shifts;
		}

		public virtual async Task ShiftDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Shifts/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ShiftUpdateAsync(int id,ShiftModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Shifts/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ShiftCreateAsync(ShiftModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Shifts", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ShiftCreateManyAsync(List<ShiftModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Shifts/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOAddress>>AddressSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Addresses?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Addresses;
		}

		public virtual async Task<List<POCOAddress>> AddressGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Addresses/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Addresses;
		}

		public virtual async Task<POCOAddress> AddressGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Addresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Addresses.FirstOrDefault();
		}

		public virtual async Task<List<POCOAddress>> AddressGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Addresses?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Addresses;
		}

		public virtual async Task AddressDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Addresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task AddressUpdateAsync(int id,AddressModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Addresses/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> AddressCreateAsync(AddressModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Addresses", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task AddressCreateManyAsync(List<AddressModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Addresses/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOAddressType>>AddressTypeSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/AddressTypes?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).AddressTypes;
		}

		public virtual async Task<List<POCOAddressType>> AddressTypeGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/AddressTypes/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).AddressTypes;
		}

		public virtual async Task<POCOAddressType> AddressTypeGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/AddressTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).AddressTypes.FirstOrDefault();
		}

		public virtual async Task<List<POCOAddressType>> AddressTypeGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/AddressTypes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).AddressTypes;
		}

		public virtual async Task AddressTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/AddressTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task AddressTypeUpdateAsync(int id,AddressTypeModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/AddressTypes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> AddressTypeCreateAsync(AddressTypeModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/AddressTypes", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task AddressTypeCreateManyAsync(List<AddressTypeModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/AddressTypes/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOBusinessEntity>>BusinessEntitySearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/BusinessEntities?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).BusinessEntities;
		}

		public virtual async Task<List<POCOBusinessEntity>> BusinessEntityGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/BusinessEntities/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).BusinessEntities;
		}

		public virtual async Task<POCOBusinessEntity> BusinessEntityGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/BusinessEntities/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).BusinessEntities.FirstOrDefault();
		}

		public virtual async Task<List<POCOBusinessEntity>> BusinessEntityGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/BusinessEntities?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).BusinessEntities;
		}

		public virtual async Task BusinessEntityDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/BusinessEntities/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task BusinessEntityUpdateAsync(int id,BusinessEntityModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/BusinessEntities/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> BusinessEntityCreateAsync(BusinessEntityModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/BusinessEntities", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task BusinessEntityCreateManyAsync(List<BusinessEntityModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/BusinessEntities/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOBusinessEntityAddress>>BusinessEntityAddressSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/BusinessEntityAddresses?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).BusinessEntityAddresses;
		}

		public virtual async Task<List<POCOBusinessEntityAddress>> BusinessEntityAddressGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/BusinessEntityAddresses/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).BusinessEntityAddresses;
		}

		public virtual async Task<POCOBusinessEntityAddress> BusinessEntityAddressGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/BusinessEntityAddresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).BusinessEntityAddresses.FirstOrDefault();
		}

		public virtual async Task<List<POCOBusinessEntityAddress>> BusinessEntityAddressGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/BusinessEntityAddresses?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).BusinessEntityAddresses;
		}

		public virtual async Task BusinessEntityAddressDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/BusinessEntityAddresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task BusinessEntityAddressUpdateAsync(int id,BusinessEntityAddressModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/BusinessEntityAddresses/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> BusinessEntityAddressCreateAsync(BusinessEntityAddressModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/BusinessEntityAddresses", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task BusinessEntityAddressCreateManyAsync(List<BusinessEntityAddressModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/BusinessEntityAddresses/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOBusinessEntityContact>>BusinessEntityContactSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/BusinessEntityContacts?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).BusinessEntityContacts;
		}

		public virtual async Task<List<POCOBusinessEntityContact>> BusinessEntityContactGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/BusinessEntityContacts/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).BusinessEntityContacts;
		}

		public virtual async Task<POCOBusinessEntityContact> BusinessEntityContactGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/BusinessEntityContacts/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).BusinessEntityContacts.FirstOrDefault();
		}

		public virtual async Task<List<POCOBusinessEntityContact>> BusinessEntityContactGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/BusinessEntityContacts?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).BusinessEntityContacts;
		}

		public virtual async Task BusinessEntityContactDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/BusinessEntityContacts/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task BusinessEntityContactUpdateAsync(int id,BusinessEntityContactModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/BusinessEntityContacts/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> BusinessEntityContactCreateAsync(BusinessEntityContactModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/BusinessEntityContacts", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task BusinessEntityContactCreateManyAsync(List<BusinessEntityContactModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/BusinessEntityContacts/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOContactType>>ContactTypeSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ContactTypes?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ContactTypes;
		}

		public virtual async Task<List<POCOContactType>> ContactTypeGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ContactTypes/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ContactTypes;
		}

		public virtual async Task<POCOContactType> ContactTypeGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ContactTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ContactTypes.FirstOrDefault();
		}

		public virtual async Task<List<POCOContactType>> ContactTypeGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ContactTypes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ContactTypes;
		}

		public virtual async Task ContactTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ContactTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ContactTypeUpdateAsync(int id,ContactTypeModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ContactTypes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ContactTypeCreateAsync(ContactTypeModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ContactTypes", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ContactTypeCreateManyAsync(List<ContactTypeModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ContactTypes/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOCountryRegion>>CountryRegionSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/CountryRegions?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).CountryRegions;
		}

		public virtual async Task<List<POCOCountryRegion>> CountryRegionGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/CountryRegions/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).CountryRegions;
		}

		public virtual async Task<POCOCountryRegion> CountryRegionGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/CountryRegions/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).CountryRegions.FirstOrDefault();
		}

		public virtual async Task<List<POCOCountryRegion>> CountryRegionGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/CountryRegions?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).CountryRegions;
		}

		public virtual async Task CountryRegionDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/CountryRegions/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task CountryRegionUpdateAsync(int id,CountryRegionModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/CountryRegions/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> CountryRegionCreateAsync(CountryRegionModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/CountryRegions", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task CountryRegionCreateManyAsync(List<CountryRegionModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/CountryRegions/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOEmailAddress>>EmailAddressSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/EmailAddresses?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).EmailAddresses;
		}

		public virtual async Task<List<POCOEmailAddress>> EmailAddressGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/EmailAddresses/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).EmailAddresses;
		}

		public virtual async Task<POCOEmailAddress> EmailAddressGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/EmailAddresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).EmailAddresses.FirstOrDefault();
		}

		public virtual async Task<List<POCOEmailAddress>> EmailAddressGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/EmailAddresses?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).EmailAddresses;
		}

		public virtual async Task EmailAddressDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/EmailAddresses/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task EmailAddressUpdateAsync(int id,EmailAddressModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/EmailAddresses/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> EmailAddressCreateAsync(EmailAddressModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/EmailAddresses", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task EmailAddressCreateManyAsync(List<EmailAddressModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/EmailAddresses/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOPassword>>PasswordSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Passwords?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Passwords;
		}

		public virtual async Task<List<POCOPassword>> PasswordGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Passwords/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Passwords;
		}

		public virtual async Task<POCOPassword> PasswordGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Passwords/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Passwords.FirstOrDefault();
		}

		public virtual async Task<List<POCOPassword>> PasswordGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Passwords?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Passwords;
		}

		public virtual async Task PasswordDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Passwords/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task PasswordUpdateAsync(int id,PasswordModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Passwords/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> PasswordCreateAsync(PasswordModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Passwords", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task PasswordCreateManyAsync(List<PasswordModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Passwords/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOPerson>>PersonSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/People?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).People;
		}

		public virtual async Task<List<POCOPerson>> PersonGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/People/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).People;
		}

		public virtual async Task<POCOPerson> PersonGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/People/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).People.FirstOrDefault();
		}

		public virtual async Task<List<POCOPerson>> PersonGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/People?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).People;
		}

		public virtual async Task PersonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/People/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task PersonUpdateAsync(int id,PersonModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/People/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> PersonCreateAsync(PersonModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/People", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task PersonCreateManyAsync(List<PersonModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/People/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOPersonPhone>>PersonPhoneSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PersonPhones?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PersonPhones;
		}

		public virtual async Task<List<POCOPersonPhone>> PersonPhoneGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PersonPhones/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PersonPhones;
		}

		public virtual async Task<POCOPersonPhone> PersonPhoneGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PersonPhones/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PersonPhones.FirstOrDefault();
		}

		public virtual async Task<List<POCOPersonPhone>> PersonPhoneGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PersonPhones?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PersonPhones;
		}

		public virtual async Task PersonPhoneDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/PersonPhones/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task PersonPhoneUpdateAsync(int id,PersonPhoneModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/PersonPhones/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> PersonPhoneCreateAsync(PersonPhoneModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/PersonPhones", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task PersonPhoneCreateManyAsync(List<PersonPhoneModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/PersonPhones/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOPhoneNumberType>>PhoneNumberTypeSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PhoneNumberTypes?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PhoneNumberTypes;
		}

		public virtual async Task<List<POCOPhoneNumberType>> PhoneNumberTypeGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PhoneNumberTypes/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PhoneNumberTypes;
		}

		public virtual async Task<POCOPhoneNumberType> PhoneNumberTypeGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PhoneNumberTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PhoneNumberTypes.FirstOrDefault();
		}

		public virtual async Task<List<POCOPhoneNumberType>> PhoneNumberTypeGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PhoneNumberTypes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PhoneNumberTypes;
		}

		public virtual async Task PhoneNumberTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/PhoneNumberTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task PhoneNumberTypeUpdateAsync(int id,PhoneNumberTypeModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/PhoneNumberTypes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> PhoneNumberTypeCreateAsync(PhoneNumberTypeModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/PhoneNumberTypes", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task PhoneNumberTypeCreateManyAsync(List<PhoneNumberTypeModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/PhoneNumberTypes/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOStateProvince>>StateProvinceSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/StateProvinces?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).StateProvinces;
		}

		public virtual async Task<List<POCOStateProvince>> StateProvinceGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/StateProvinces/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).StateProvinces;
		}

		public virtual async Task<POCOStateProvince> StateProvinceGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/StateProvinces/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).StateProvinces.FirstOrDefault();
		}

		public virtual async Task<List<POCOStateProvince>> StateProvinceGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/StateProvinces?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).StateProvinces;
		}

		public virtual async Task StateProvinceDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/StateProvinces/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task StateProvinceUpdateAsync(int id,StateProvinceModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/StateProvinces/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> StateProvinceCreateAsync(StateProvinceModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/StateProvinces", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task StateProvinceCreateManyAsync(List<StateProvinceModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/StateProvinces/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOBillOfMaterials>>BillOfMaterialsSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/BillOfMaterials?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).BillOfMaterials;
		}

		public virtual async Task<List<POCOBillOfMaterials>> BillOfMaterialsGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/BillOfMaterials/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).BillOfMaterials;
		}

		public virtual async Task<POCOBillOfMaterials> BillOfMaterialsGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/BillOfMaterials/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).BillOfMaterials.FirstOrDefault();
		}

		public virtual async Task<List<POCOBillOfMaterials>> BillOfMaterialsGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/BillOfMaterials?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).BillOfMaterials;
		}

		public virtual async Task BillOfMaterialsDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/BillOfMaterials/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task BillOfMaterialsUpdateAsync(int id,BillOfMaterialsModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/BillOfMaterials/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> BillOfMaterialsCreateAsync(BillOfMaterialsModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/BillOfMaterials", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task BillOfMaterialsCreateManyAsync(List<BillOfMaterialsModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/BillOfMaterials/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOCulture>>CultureSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Cultures?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Cultures;
		}

		public virtual async Task<List<POCOCulture>> CultureGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Cultures/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Cultures;
		}

		public virtual async Task<POCOCulture> CultureGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Cultures/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Cultures.FirstOrDefault();
		}

		public virtual async Task<List<POCOCulture>> CultureGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Cultures?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Cultures;
		}

		public virtual async Task CultureDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Cultures/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task CultureUpdateAsync(int id,CultureModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Cultures/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> CultureCreateAsync(CultureModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Cultures", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task CultureCreateManyAsync(List<CultureModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Cultures/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCODocument>>DocumentSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Documents?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Documents;
		}

		public virtual async Task<List<POCODocument>> DocumentGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Documents/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Documents;
		}

		public virtual async Task<POCODocument> DocumentGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Documents/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Documents.FirstOrDefault();
		}

		public virtual async Task<List<POCODocument>> DocumentGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Documents?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Documents;
		}

		public virtual async Task DocumentDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Documents/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task DocumentUpdateAsync(int id,DocumentModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Documents/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> DocumentCreateAsync(DocumentModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Documents", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task DocumentCreateManyAsync(List<DocumentModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Documents/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOIllustration>>IllustrationSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Illustrations?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Illustrations;
		}

		public virtual async Task<List<POCOIllustration>> IllustrationGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Illustrations/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Illustrations;
		}

		public virtual async Task<POCOIllustration> IllustrationGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Illustrations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Illustrations.FirstOrDefault();
		}

		public virtual async Task<List<POCOIllustration>> IllustrationGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Illustrations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Illustrations;
		}

		public virtual async Task IllustrationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Illustrations/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task IllustrationUpdateAsync(int id,IllustrationModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Illustrations/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> IllustrationCreateAsync(IllustrationModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Illustrations", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task IllustrationCreateManyAsync(List<IllustrationModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Illustrations/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOLocation>>LocationSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Locations?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Locations;
		}

		public virtual async Task<List<POCOLocation>> LocationGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Locations/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Locations;
		}

		public virtual async Task<POCOLocation> LocationGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Locations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Locations.FirstOrDefault();
		}

		public virtual async Task<List<POCOLocation>> LocationGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Locations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Locations;
		}

		public virtual async Task LocationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Locations/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task LocationUpdateAsync(int id,LocationModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Locations/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> LocationCreateAsync(LocationModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Locations", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task LocationCreateManyAsync(List<LocationModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Locations/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOProduct>>ProductSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Products?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Products;
		}

		public virtual async Task<List<POCOProduct>> ProductGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Products/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Products;
		}

		public virtual async Task<POCOProduct> ProductGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Products/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Products.FirstOrDefault();
		}

		public virtual async Task<List<POCOProduct>> ProductGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Products?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Products;
		}

		public virtual async Task ProductDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Products/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ProductUpdateAsync(int id,ProductModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Products/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ProductCreateAsync(ProductModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Products", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductCreateManyAsync(List<ProductModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Products/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOProductCategory>>ProductCategorySearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductCategories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductCategories;
		}

		public virtual async Task<List<POCOProductCategory>> ProductCategoryGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductCategories/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductCategories;
		}

		public virtual async Task<POCOProductCategory> ProductCategoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductCategories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductCategories.FirstOrDefault();
		}

		public virtual async Task<List<POCOProductCategory>> ProductCategoryGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductCategories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductCategories;
		}

		public virtual async Task ProductCategoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ProductCategories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ProductCategoryUpdateAsync(int id,ProductCategoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ProductCategories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ProductCategoryCreateAsync(ProductCategoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductCategories", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductCategoryCreateManyAsync(List<ProductCategoryModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductCategories/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOProductCostHistory>>ProductCostHistorySearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductCostHistories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductCostHistories;
		}

		public virtual async Task<List<POCOProductCostHistory>> ProductCostHistoryGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductCostHistories/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductCostHistories;
		}

		public virtual async Task<POCOProductCostHistory> ProductCostHistoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductCostHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductCostHistories.FirstOrDefault();
		}

		public virtual async Task<List<POCOProductCostHistory>> ProductCostHistoryGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductCostHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductCostHistories;
		}

		public virtual async Task ProductCostHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ProductCostHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ProductCostHistoryUpdateAsync(int id,ProductCostHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ProductCostHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ProductCostHistoryCreateAsync(ProductCostHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductCostHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductCostHistoryCreateManyAsync(List<ProductCostHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductCostHistories/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOProductDescription>>ProductDescriptionSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductDescriptions?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductDescriptions;
		}

		public virtual async Task<List<POCOProductDescription>> ProductDescriptionGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductDescriptions/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductDescriptions;
		}

		public virtual async Task<POCOProductDescription> ProductDescriptionGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductDescriptions/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductDescriptions.FirstOrDefault();
		}

		public virtual async Task<List<POCOProductDescription>> ProductDescriptionGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductDescriptions?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductDescriptions;
		}

		public virtual async Task ProductDescriptionDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ProductDescriptions/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ProductDescriptionUpdateAsync(int id,ProductDescriptionModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ProductDescriptions/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ProductDescriptionCreateAsync(ProductDescriptionModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductDescriptions", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductDescriptionCreateManyAsync(List<ProductDescriptionModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductDescriptions/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOProductDocument>>ProductDocumentSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductDocuments?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductDocuments;
		}

		public virtual async Task<List<POCOProductDocument>> ProductDocumentGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductDocuments/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductDocuments;
		}

		public virtual async Task<POCOProductDocument> ProductDocumentGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductDocuments/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductDocuments.FirstOrDefault();
		}

		public virtual async Task<List<POCOProductDocument>> ProductDocumentGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductDocuments?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductDocuments;
		}

		public virtual async Task ProductDocumentDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ProductDocuments/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ProductDocumentUpdateAsync(int id,ProductDocumentModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ProductDocuments/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ProductDocumentCreateAsync(ProductDocumentModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductDocuments", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductDocumentCreateManyAsync(List<ProductDocumentModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductDocuments/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOProductInventory>>ProductInventorySearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductInventories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductInventories;
		}

		public virtual async Task<List<POCOProductInventory>> ProductInventoryGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductInventories/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductInventories;
		}

		public virtual async Task<POCOProductInventory> ProductInventoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductInventories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductInventories.FirstOrDefault();
		}

		public virtual async Task<List<POCOProductInventory>> ProductInventoryGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductInventories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductInventories;
		}

		public virtual async Task ProductInventoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ProductInventories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ProductInventoryUpdateAsync(int id,ProductInventoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ProductInventories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ProductInventoryCreateAsync(ProductInventoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductInventories", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductInventoryCreateManyAsync(List<ProductInventoryModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductInventories/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOProductListPriceHistory>>ProductListPriceHistorySearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductListPriceHistories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductListPriceHistories;
		}

		public virtual async Task<List<POCOProductListPriceHistory>> ProductListPriceHistoryGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductListPriceHistories/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductListPriceHistories;
		}

		public virtual async Task<POCOProductListPriceHistory> ProductListPriceHistoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductListPriceHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductListPriceHistories.FirstOrDefault();
		}

		public virtual async Task<List<POCOProductListPriceHistory>> ProductListPriceHistoryGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductListPriceHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductListPriceHistories;
		}

		public virtual async Task ProductListPriceHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ProductListPriceHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ProductListPriceHistoryUpdateAsync(int id,ProductListPriceHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ProductListPriceHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ProductListPriceHistoryCreateAsync(ProductListPriceHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductListPriceHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductListPriceHistoryCreateManyAsync(List<ProductListPriceHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductListPriceHistories/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOProductModel>>ProductModelSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductModels?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductModels;
		}

		public virtual async Task<List<POCOProductModel>> ProductModelGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductModels/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductModels;
		}

		public virtual async Task<POCOProductModel> ProductModelGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductModels/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductModels.FirstOrDefault();
		}

		public virtual async Task<List<POCOProductModel>> ProductModelGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductModels?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductModels;
		}

		public virtual async Task ProductModelDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ProductModels/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ProductModelUpdateAsync(int id,ProductModelModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ProductModels/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ProductModelCreateAsync(ProductModelModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductModels", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductModelCreateManyAsync(List<ProductModelModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductModels/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOProductModelIllustration>>ProductModelIllustrationSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductModelIllustrations?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductModelIllustrations;
		}

		public virtual async Task<List<POCOProductModelIllustration>> ProductModelIllustrationGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductModelIllustrations/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductModelIllustrations;
		}

		public virtual async Task<POCOProductModelIllustration> ProductModelIllustrationGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductModelIllustrations/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductModelIllustrations.FirstOrDefault();
		}

		public virtual async Task<List<POCOProductModelIllustration>> ProductModelIllustrationGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductModelIllustrations?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductModelIllustrations;
		}

		public virtual async Task ProductModelIllustrationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ProductModelIllustrations/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ProductModelIllustrationUpdateAsync(int id,ProductModelIllustrationModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ProductModelIllustrations/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ProductModelIllustrationCreateAsync(ProductModelIllustrationModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductModelIllustrations", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductModelIllustrationCreateManyAsync(List<ProductModelIllustrationModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductModelIllustrations/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOProductModelProductDescriptionCulture>>ProductModelProductDescriptionCultureSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductModelProductDescriptionCultures?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductModelProductDescriptionCultures;
		}

		public virtual async Task<List<POCOProductModelProductDescriptionCulture>> ProductModelProductDescriptionCultureGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductModelProductDescriptionCultures/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductModelProductDescriptionCultures;
		}

		public virtual async Task<POCOProductModelProductDescriptionCulture> ProductModelProductDescriptionCultureGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductModelProductDescriptionCultures/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductModelProductDescriptionCultures.FirstOrDefault();
		}

		public virtual async Task<List<POCOProductModelProductDescriptionCulture>> ProductModelProductDescriptionCultureGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductModelProductDescriptionCultures?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductModelProductDescriptionCultures;
		}

		public virtual async Task ProductModelProductDescriptionCultureDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ProductModelProductDescriptionCultures/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ProductModelProductDescriptionCultureUpdateAsync(int id,ProductModelProductDescriptionCultureModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ProductModelProductDescriptionCultures/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ProductModelProductDescriptionCultureCreateAsync(ProductModelProductDescriptionCultureModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductModelProductDescriptionCultures", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductModelProductDescriptionCultureCreateManyAsync(List<ProductModelProductDescriptionCultureModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductModelProductDescriptionCultures/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOProductPhoto>>ProductPhotoSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductPhotoes?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductPhotoes;
		}

		public virtual async Task<List<POCOProductPhoto>> ProductPhotoGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductPhotoes/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductPhotoes;
		}

		public virtual async Task<POCOProductPhoto> ProductPhotoGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductPhotoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductPhotoes.FirstOrDefault();
		}

		public virtual async Task<List<POCOProductPhoto>> ProductPhotoGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductPhotoes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductPhotoes;
		}

		public virtual async Task ProductPhotoDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ProductPhotoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ProductPhotoUpdateAsync(int id,ProductPhotoModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ProductPhotoes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ProductPhotoCreateAsync(ProductPhotoModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductPhotoes", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductPhotoCreateManyAsync(List<ProductPhotoModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductPhotoes/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOProductProductPhoto>>ProductProductPhotoSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductProductPhotoes?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductProductPhotoes;
		}

		public virtual async Task<List<POCOProductProductPhoto>> ProductProductPhotoGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductProductPhotoes/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductProductPhotoes;
		}

		public virtual async Task<POCOProductProductPhoto> ProductProductPhotoGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductProductPhotoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductProductPhotoes.FirstOrDefault();
		}

		public virtual async Task<List<POCOProductProductPhoto>> ProductProductPhotoGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductProductPhotoes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductProductPhotoes;
		}

		public virtual async Task ProductProductPhotoDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ProductProductPhotoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ProductProductPhotoUpdateAsync(int id,ProductProductPhotoModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ProductProductPhotoes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ProductProductPhotoCreateAsync(ProductProductPhotoModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductProductPhotoes", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductProductPhotoCreateManyAsync(List<ProductProductPhotoModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductProductPhotoes/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOProductReview>>ProductReviewSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductReviews?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductReviews;
		}

		public virtual async Task<List<POCOProductReview>> ProductReviewGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductReviews/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductReviews;
		}

		public virtual async Task<POCOProductReview> ProductReviewGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductReviews/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductReviews.FirstOrDefault();
		}

		public virtual async Task<List<POCOProductReview>> ProductReviewGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductReviews?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductReviews;
		}

		public virtual async Task ProductReviewDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ProductReviews/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ProductReviewUpdateAsync(int id,ProductReviewModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ProductReviews/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ProductReviewCreateAsync(ProductReviewModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductReviews", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductReviewCreateManyAsync(List<ProductReviewModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductReviews/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOProductSubcategory>>ProductSubcategorySearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductSubcategories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductSubcategories;
		}

		public virtual async Task<List<POCOProductSubcategory>> ProductSubcategoryGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductSubcategories/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductSubcategories;
		}

		public virtual async Task<POCOProductSubcategory> ProductSubcategoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductSubcategories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductSubcategories.FirstOrDefault();
		}

		public virtual async Task<List<POCOProductSubcategory>> ProductSubcategoryGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductSubcategories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductSubcategories;
		}

		public virtual async Task ProductSubcategoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ProductSubcategories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ProductSubcategoryUpdateAsync(int id,ProductSubcategoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ProductSubcategories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ProductSubcategoryCreateAsync(ProductSubcategoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductSubcategories", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductSubcategoryCreateManyAsync(List<ProductSubcategoryModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductSubcategories/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOScrapReason>>ScrapReasonSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ScrapReasons?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ScrapReasons;
		}

		public virtual async Task<List<POCOScrapReason>> ScrapReasonGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ScrapReasons/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ScrapReasons;
		}

		public virtual async Task<POCOScrapReason> ScrapReasonGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ScrapReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ScrapReasons.FirstOrDefault();
		}

		public virtual async Task<List<POCOScrapReason>> ScrapReasonGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ScrapReasons?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ScrapReasons;
		}

		public virtual async Task ScrapReasonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ScrapReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ScrapReasonUpdateAsync(int id,ScrapReasonModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ScrapReasons/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ScrapReasonCreateAsync(ScrapReasonModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ScrapReasons", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ScrapReasonCreateManyAsync(List<ScrapReasonModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ScrapReasons/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOTransactionHistory>>TransactionHistorySearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/TransactionHistories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).TransactionHistories;
		}

		public virtual async Task<List<POCOTransactionHistory>> TransactionHistoryGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/TransactionHistories/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).TransactionHistories;
		}

		public virtual async Task<POCOTransactionHistory> TransactionHistoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/TransactionHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).TransactionHistories.FirstOrDefault();
		}

		public virtual async Task<List<POCOTransactionHistory>> TransactionHistoryGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/TransactionHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).TransactionHistories;
		}

		public virtual async Task TransactionHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/TransactionHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task TransactionHistoryUpdateAsync(int id,TransactionHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/TransactionHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> TransactionHistoryCreateAsync(TransactionHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/TransactionHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task TransactionHistoryCreateManyAsync(List<TransactionHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/TransactionHistories/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOTransactionHistoryArchive>>TransactionHistoryArchiveSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/TransactionHistoryArchives?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).TransactionHistoryArchives;
		}

		public virtual async Task<List<POCOTransactionHistoryArchive>> TransactionHistoryArchiveGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/TransactionHistoryArchives/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).TransactionHistoryArchives;
		}

		public virtual async Task<POCOTransactionHistoryArchive> TransactionHistoryArchiveGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/TransactionHistoryArchives/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).TransactionHistoryArchives.FirstOrDefault();
		}

		public virtual async Task<List<POCOTransactionHistoryArchive>> TransactionHistoryArchiveGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/TransactionHistoryArchives?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).TransactionHistoryArchives;
		}

		public virtual async Task TransactionHistoryArchiveDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/TransactionHistoryArchives/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task TransactionHistoryArchiveUpdateAsync(int id,TransactionHistoryArchiveModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/TransactionHistoryArchives/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> TransactionHistoryArchiveCreateAsync(TransactionHistoryArchiveModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/TransactionHistoryArchives", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task TransactionHistoryArchiveCreateManyAsync(List<TransactionHistoryArchiveModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/TransactionHistoryArchives/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOUnitMeasure>>UnitMeasureSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/UnitMeasures?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).UnitMeasures;
		}

		public virtual async Task<List<POCOUnitMeasure>> UnitMeasureGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/UnitMeasures/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).UnitMeasures;
		}

		public virtual async Task<POCOUnitMeasure> UnitMeasureGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/UnitMeasures/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).UnitMeasures.FirstOrDefault();
		}

		public virtual async Task<List<POCOUnitMeasure>> UnitMeasureGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/UnitMeasures?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).UnitMeasures;
		}

		public virtual async Task UnitMeasureDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/UnitMeasures/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task UnitMeasureUpdateAsync(int id,UnitMeasureModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/UnitMeasures/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> UnitMeasureCreateAsync(UnitMeasureModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/UnitMeasures", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task UnitMeasureCreateManyAsync(List<UnitMeasureModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/UnitMeasures/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOWorkOrder>>WorkOrderSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/WorkOrders?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).WorkOrders;
		}

		public virtual async Task<List<POCOWorkOrder>> WorkOrderGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/WorkOrders/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).WorkOrders;
		}

		public virtual async Task<POCOWorkOrder> WorkOrderGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/WorkOrders/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).WorkOrders.FirstOrDefault();
		}

		public virtual async Task<List<POCOWorkOrder>> WorkOrderGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/WorkOrders?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).WorkOrders;
		}

		public virtual async Task WorkOrderDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/WorkOrders/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task WorkOrderUpdateAsync(int id,WorkOrderModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/WorkOrders/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> WorkOrderCreateAsync(WorkOrderModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/WorkOrders", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task WorkOrderCreateManyAsync(List<WorkOrderModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/WorkOrders/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOWorkOrderRouting>>WorkOrderRoutingSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/WorkOrderRoutings?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).WorkOrderRoutings;
		}

		public virtual async Task<List<POCOWorkOrderRouting>> WorkOrderRoutingGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/WorkOrderRoutings/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).WorkOrderRoutings;
		}

		public virtual async Task<POCOWorkOrderRouting> WorkOrderRoutingGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/WorkOrderRoutings/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).WorkOrderRoutings.FirstOrDefault();
		}

		public virtual async Task<List<POCOWorkOrderRouting>> WorkOrderRoutingGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/WorkOrderRoutings?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).WorkOrderRoutings;
		}

		public virtual async Task WorkOrderRoutingDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/WorkOrderRoutings/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task WorkOrderRoutingUpdateAsync(int id,WorkOrderRoutingModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/WorkOrderRoutings/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> WorkOrderRoutingCreateAsync(WorkOrderRoutingModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/WorkOrderRoutings", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task WorkOrderRoutingCreateManyAsync(List<WorkOrderRoutingModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/WorkOrderRoutings/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOProductVendor>>ProductVendorSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductVendors?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductVendors;
		}

		public virtual async Task<List<POCOProductVendor>> ProductVendorGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductVendors/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductVendors;
		}

		public virtual async Task<POCOProductVendor> ProductVendorGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductVendors/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductVendors.FirstOrDefault();
		}

		public virtual async Task<List<POCOProductVendor>> ProductVendorGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ProductVendors?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ProductVendors;
		}

		public virtual async Task ProductVendorDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ProductVendors/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ProductVendorUpdateAsync(int id,ProductVendorModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ProductVendors/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ProductVendorCreateAsync(ProductVendorModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductVendors", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ProductVendorCreateManyAsync(List<ProductVendorModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ProductVendors/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOPurchaseOrderDetail>>PurchaseOrderDetailSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PurchaseOrderDetails?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PurchaseOrderDetails;
		}

		public virtual async Task<List<POCOPurchaseOrderDetail>> PurchaseOrderDetailGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PurchaseOrderDetails/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PurchaseOrderDetails;
		}

		public virtual async Task<POCOPurchaseOrderDetail> PurchaseOrderDetailGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PurchaseOrderDetails/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PurchaseOrderDetails.FirstOrDefault();
		}

		public virtual async Task<List<POCOPurchaseOrderDetail>> PurchaseOrderDetailGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PurchaseOrderDetails?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PurchaseOrderDetails;
		}

		public virtual async Task PurchaseOrderDetailDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/PurchaseOrderDetails/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task PurchaseOrderDetailUpdateAsync(int id,PurchaseOrderDetailModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/PurchaseOrderDetails/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> PurchaseOrderDetailCreateAsync(PurchaseOrderDetailModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/PurchaseOrderDetails", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task PurchaseOrderDetailCreateManyAsync(List<PurchaseOrderDetailModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/PurchaseOrderDetails/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOPurchaseOrderHeader>>PurchaseOrderHeaderSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PurchaseOrderHeaders?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PurchaseOrderHeaders;
		}

		public virtual async Task<List<POCOPurchaseOrderHeader>> PurchaseOrderHeaderGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PurchaseOrderHeaders/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PurchaseOrderHeaders;
		}

		public virtual async Task<POCOPurchaseOrderHeader> PurchaseOrderHeaderGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PurchaseOrderHeaders/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PurchaseOrderHeaders.FirstOrDefault();
		}

		public virtual async Task<List<POCOPurchaseOrderHeader>> PurchaseOrderHeaderGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PurchaseOrderHeaders?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PurchaseOrderHeaders;
		}

		public virtual async Task PurchaseOrderHeaderDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/PurchaseOrderHeaders/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task PurchaseOrderHeaderUpdateAsync(int id,PurchaseOrderHeaderModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/PurchaseOrderHeaders/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> PurchaseOrderHeaderCreateAsync(PurchaseOrderHeaderModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/PurchaseOrderHeaders", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task PurchaseOrderHeaderCreateManyAsync(List<PurchaseOrderHeaderModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/PurchaseOrderHeaders/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOShipMethod>>ShipMethodSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ShipMethods?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ShipMethods;
		}

		public virtual async Task<List<POCOShipMethod>> ShipMethodGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ShipMethods/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ShipMethods;
		}

		public virtual async Task<POCOShipMethod> ShipMethodGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ShipMethods/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ShipMethods.FirstOrDefault();
		}

		public virtual async Task<List<POCOShipMethod>> ShipMethodGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ShipMethods?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ShipMethods;
		}

		public virtual async Task ShipMethodDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ShipMethods/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ShipMethodUpdateAsync(int id,ShipMethodModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ShipMethods/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ShipMethodCreateAsync(ShipMethodModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ShipMethods", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ShipMethodCreateManyAsync(List<ShipMethodModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ShipMethods/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOVendor>>VendorSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Vendors?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Vendors;
		}

		public virtual async Task<List<POCOVendor>> VendorGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Vendors/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Vendors;
		}

		public virtual async Task<POCOVendor> VendorGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Vendors/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Vendors.FirstOrDefault();
		}

		public virtual async Task<List<POCOVendor>> VendorGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Vendors?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Vendors;
		}

		public virtual async Task VendorDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Vendors/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task VendorUpdateAsync(int id,VendorModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Vendors/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> VendorCreateAsync(VendorModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Vendors", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task VendorCreateManyAsync(List<VendorModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Vendors/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOCountryRegionCurrency>>CountryRegionCurrencySearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/CountryRegionCurrencies?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).CountryRegionCurrencies;
		}

		public virtual async Task<List<POCOCountryRegionCurrency>> CountryRegionCurrencyGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/CountryRegionCurrencies/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).CountryRegionCurrencies;
		}

		public virtual async Task<POCOCountryRegionCurrency> CountryRegionCurrencyGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/CountryRegionCurrencies/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).CountryRegionCurrencies.FirstOrDefault();
		}

		public virtual async Task<List<POCOCountryRegionCurrency>> CountryRegionCurrencyGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/CountryRegionCurrencies?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).CountryRegionCurrencies;
		}

		public virtual async Task CountryRegionCurrencyDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/CountryRegionCurrencies/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task CountryRegionCurrencyUpdateAsync(int id,CountryRegionCurrencyModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/CountryRegionCurrencies/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> CountryRegionCurrencyCreateAsync(CountryRegionCurrencyModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/CountryRegionCurrencies", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task CountryRegionCurrencyCreateManyAsync(List<CountryRegionCurrencyModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/CountryRegionCurrencies/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOCreditCard>>CreditCardSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/CreditCards?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).CreditCards;
		}

		public virtual async Task<List<POCOCreditCard>> CreditCardGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/CreditCards/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).CreditCards;
		}

		public virtual async Task<POCOCreditCard> CreditCardGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/CreditCards/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).CreditCards.FirstOrDefault();
		}

		public virtual async Task<List<POCOCreditCard>> CreditCardGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/CreditCards?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).CreditCards;
		}

		public virtual async Task CreditCardDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/CreditCards/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task CreditCardUpdateAsync(int id,CreditCardModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/CreditCards/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> CreditCardCreateAsync(CreditCardModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/CreditCards", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task CreditCardCreateManyAsync(List<CreditCardModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/CreditCards/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOCurrency>>CurrencySearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Currencies?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Currencies;
		}

		public virtual async Task<List<POCOCurrency>> CurrencyGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Currencies/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Currencies;
		}

		public virtual async Task<POCOCurrency> CurrencyGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Currencies/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Currencies.FirstOrDefault();
		}

		public virtual async Task<List<POCOCurrency>> CurrencyGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Currencies?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Currencies;
		}

		public virtual async Task CurrencyDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Currencies/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task CurrencyUpdateAsync(int id,CurrencyModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Currencies/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> CurrencyCreateAsync(CurrencyModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Currencies", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task CurrencyCreateManyAsync(List<CurrencyModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Currencies/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOCurrencyRate>>CurrencyRateSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/CurrencyRates?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).CurrencyRates;
		}

		public virtual async Task<List<POCOCurrencyRate>> CurrencyRateGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/CurrencyRates/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).CurrencyRates;
		}

		public virtual async Task<POCOCurrencyRate> CurrencyRateGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/CurrencyRates/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).CurrencyRates.FirstOrDefault();
		}

		public virtual async Task<List<POCOCurrencyRate>> CurrencyRateGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/CurrencyRates?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).CurrencyRates;
		}

		public virtual async Task CurrencyRateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/CurrencyRates/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task CurrencyRateUpdateAsync(int id,CurrencyRateModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/CurrencyRates/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> CurrencyRateCreateAsync(CurrencyRateModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/CurrencyRates", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task CurrencyRateCreateManyAsync(List<CurrencyRateModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/CurrencyRates/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOCustomer>>CustomerSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Customers?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Customers;
		}

		public virtual async Task<List<POCOCustomer>> CustomerGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Customers/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Customers;
		}

		public virtual async Task<POCOCustomer> CustomerGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Customers/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Customers.FirstOrDefault();
		}

		public virtual async Task<List<POCOCustomer>> CustomerGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Customers?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Customers;
		}

		public virtual async Task CustomerDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Customers/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task CustomerUpdateAsync(int id,CustomerModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Customers/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> CustomerCreateAsync(CustomerModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Customers", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task CustomerCreateManyAsync(List<CustomerModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Customers/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOPersonCreditCard>>PersonCreditCardSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PersonCreditCards?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PersonCreditCards;
		}

		public virtual async Task<List<POCOPersonCreditCard>> PersonCreditCardGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PersonCreditCards/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PersonCreditCards;
		}

		public virtual async Task<POCOPersonCreditCard> PersonCreditCardGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PersonCreditCards/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PersonCreditCards.FirstOrDefault();
		}

		public virtual async Task<List<POCOPersonCreditCard>> PersonCreditCardGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/PersonCreditCards?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).PersonCreditCards;
		}

		public virtual async Task PersonCreditCardDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/PersonCreditCards/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task PersonCreditCardUpdateAsync(int id,PersonCreditCardModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/PersonCreditCards/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> PersonCreditCardCreateAsync(PersonCreditCardModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/PersonCreditCards", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task PersonCreditCardCreateManyAsync(List<PersonCreditCardModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/PersonCreditCards/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOSalesOrderDetail>>SalesOrderDetailSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesOrderDetails?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesOrderDetails;
		}

		public virtual async Task<List<POCOSalesOrderDetail>> SalesOrderDetailGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesOrderDetails/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesOrderDetails;
		}

		public virtual async Task<POCOSalesOrderDetail> SalesOrderDetailGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesOrderDetails/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesOrderDetails.FirstOrDefault();
		}

		public virtual async Task<List<POCOSalesOrderDetail>> SalesOrderDetailGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesOrderDetails?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesOrderDetails;
		}

		public virtual async Task SalesOrderDetailDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/SalesOrderDetails/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task SalesOrderDetailUpdateAsync(int id,SalesOrderDetailModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/SalesOrderDetails/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> SalesOrderDetailCreateAsync(SalesOrderDetailModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SalesOrderDetails", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesOrderDetailCreateManyAsync(List<SalesOrderDetailModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SalesOrderDetails/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOSalesOrderHeader>>SalesOrderHeaderSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesOrderHeaders?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesOrderHeaders;
		}

		public virtual async Task<List<POCOSalesOrderHeader>> SalesOrderHeaderGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesOrderHeaders/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesOrderHeaders;
		}

		public virtual async Task<POCOSalesOrderHeader> SalesOrderHeaderGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesOrderHeaders/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesOrderHeaders.FirstOrDefault();
		}

		public virtual async Task<List<POCOSalesOrderHeader>> SalesOrderHeaderGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesOrderHeaders?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesOrderHeaders;
		}

		public virtual async Task SalesOrderHeaderDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/SalesOrderHeaders/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task SalesOrderHeaderUpdateAsync(int id,SalesOrderHeaderModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/SalesOrderHeaders/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> SalesOrderHeaderCreateAsync(SalesOrderHeaderModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SalesOrderHeaders", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesOrderHeaderCreateManyAsync(List<SalesOrderHeaderModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SalesOrderHeaders/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOSalesOrderHeaderSalesReason>>SalesOrderHeaderSalesReasonSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesOrderHeaderSalesReasons?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesOrderHeaderSalesReasons;
		}

		public virtual async Task<List<POCOSalesOrderHeaderSalesReason>> SalesOrderHeaderSalesReasonGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesOrderHeaderSalesReasons/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesOrderHeaderSalesReasons;
		}

		public virtual async Task<POCOSalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasonGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesOrderHeaderSalesReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesOrderHeaderSalesReasons.FirstOrDefault();
		}

		public virtual async Task<List<POCOSalesOrderHeaderSalesReason>> SalesOrderHeaderSalesReasonGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesOrderHeaderSalesReasons?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesOrderHeaderSalesReasons;
		}

		public virtual async Task SalesOrderHeaderSalesReasonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/SalesOrderHeaderSalesReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task SalesOrderHeaderSalesReasonUpdateAsync(int id,SalesOrderHeaderSalesReasonModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/SalesOrderHeaderSalesReasons/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> SalesOrderHeaderSalesReasonCreateAsync(SalesOrderHeaderSalesReasonModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SalesOrderHeaderSalesReasons", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesOrderHeaderSalesReasonCreateManyAsync(List<SalesOrderHeaderSalesReasonModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SalesOrderHeaderSalesReasons/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOSalesPerson>>SalesPersonSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesPersons?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesPersons;
		}

		public virtual async Task<List<POCOSalesPerson>> SalesPersonGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesPersons/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesPersons;
		}

		public virtual async Task<POCOSalesPerson> SalesPersonGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesPersons/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesPersons.FirstOrDefault();
		}

		public virtual async Task<List<POCOSalesPerson>> SalesPersonGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesPersons?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesPersons;
		}

		public virtual async Task SalesPersonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/SalesPersons/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task SalesPersonUpdateAsync(int id,SalesPersonModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/SalesPersons/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> SalesPersonCreateAsync(SalesPersonModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SalesPersons", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesPersonCreateManyAsync(List<SalesPersonModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SalesPersons/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOSalesPersonQuotaHistory>>SalesPersonQuotaHistorySearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesPersonQuotaHistories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesPersonQuotaHistories;
		}

		public virtual async Task<List<POCOSalesPersonQuotaHistory>> SalesPersonQuotaHistoryGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesPersonQuotaHistories/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesPersonQuotaHistories;
		}

		public virtual async Task<POCOSalesPersonQuotaHistory> SalesPersonQuotaHistoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesPersonQuotaHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesPersonQuotaHistories.FirstOrDefault();
		}

		public virtual async Task<List<POCOSalesPersonQuotaHistory>> SalesPersonQuotaHistoryGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesPersonQuotaHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesPersonQuotaHistories;
		}

		public virtual async Task SalesPersonQuotaHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/SalesPersonQuotaHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task SalesPersonQuotaHistoryUpdateAsync(int id,SalesPersonQuotaHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/SalesPersonQuotaHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> SalesPersonQuotaHistoryCreateAsync(SalesPersonQuotaHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SalesPersonQuotaHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesPersonQuotaHistoryCreateManyAsync(List<SalesPersonQuotaHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SalesPersonQuotaHistories/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOSalesReason>>SalesReasonSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesReasons?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesReasons;
		}

		public virtual async Task<List<POCOSalesReason>> SalesReasonGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesReasons/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesReasons;
		}

		public virtual async Task<POCOSalesReason> SalesReasonGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesReasons.FirstOrDefault();
		}

		public virtual async Task<List<POCOSalesReason>> SalesReasonGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesReasons?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesReasons;
		}

		public virtual async Task SalesReasonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/SalesReasons/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task SalesReasonUpdateAsync(int id,SalesReasonModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/SalesReasons/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> SalesReasonCreateAsync(SalesReasonModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SalesReasons", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesReasonCreateManyAsync(List<SalesReasonModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SalesReasons/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOSalesTaxRate>>SalesTaxRateSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesTaxRates?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesTaxRates;
		}

		public virtual async Task<List<POCOSalesTaxRate>> SalesTaxRateGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesTaxRates/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesTaxRates;
		}

		public virtual async Task<POCOSalesTaxRate> SalesTaxRateGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesTaxRates/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesTaxRates.FirstOrDefault();
		}

		public virtual async Task<List<POCOSalesTaxRate>> SalesTaxRateGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesTaxRates?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesTaxRates;
		}

		public virtual async Task SalesTaxRateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/SalesTaxRates/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task SalesTaxRateUpdateAsync(int id,SalesTaxRateModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/SalesTaxRates/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> SalesTaxRateCreateAsync(SalesTaxRateModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SalesTaxRates", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesTaxRateCreateManyAsync(List<SalesTaxRateModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SalesTaxRates/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOSalesTerritory>>SalesTerritorySearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesTerritories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesTerritories;
		}

		public virtual async Task<List<POCOSalesTerritory>> SalesTerritoryGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesTerritories/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesTerritories;
		}

		public virtual async Task<POCOSalesTerritory> SalesTerritoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesTerritories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesTerritories.FirstOrDefault();
		}

		public virtual async Task<List<POCOSalesTerritory>> SalesTerritoryGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesTerritories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesTerritories;
		}

		public virtual async Task SalesTerritoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/SalesTerritories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task SalesTerritoryUpdateAsync(int id,SalesTerritoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/SalesTerritories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> SalesTerritoryCreateAsync(SalesTerritoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SalesTerritories", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesTerritoryCreateManyAsync(List<SalesTerritoryModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SalesTerritories/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOSalesTerritoryHistory>>SalesTerritoryHistorySearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesTerritoryHistories?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesTerritoryHistories;
		}

		public virtual async Task<List<POCOSalesTerritoryHistory>> SalesTerritoryHistoryGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesTerritoryHistories/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesTerritoryHistories;
		}

		public virtual async Task<POCOSalesTerritoryHistory> SalesTerritoryHistoryGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesTerritoryHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesTerritoryHistories.FirstOrDefault();
		}

		public virtual async Task<List<POCOSalesTerritoryHistory>> SalesTerritoryHistoryGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SalesTerritoryHistories?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SalesTerritoryHistories;
		}

		public virtual async Task SalesTerritoryHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/SalesTerritoryHistories/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task SalesTerritoryHistoryUpdateAsync(int id,SalesTerritoryHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/SalesTerritoryHistories/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> SalesTerritoryHistoryCreateAsync(SalesTerritoryHistoryModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SalesTerritoryHistories", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task SalesTerritoryHistoryCreateManyAsync(List<SalesTerritoryHistoryModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SalesTerritoryHistories/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOShoppingCartItem>>ShoppingCartItemSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ShoppingCartItems?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ShoppingCartItems;
		}

		public virtual async Task<List<POCOShoppingCartItem>> ShoppingCartItemGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ShoppingCartItems/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ShoppingCartItems;
		}

		public virtual async Task<POCOShoppingCartItem> ShoppingCartItemGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ShoppingCartItems/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ShoppingCartItems.FirstOrDefault();
		}

		public virtual async Task<List<POCOShoppingCartItem>> ShoppingCartItemGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/ShoppingCartItems?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).ShoppingCartItems;
		}

		public virtual async Task ShoppingCartItemDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/ShoppingCartItems/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task ShoppingCartItemUpdateAsync(int id,ShoppingCartItemModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/ShoppingCartItems/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> ShoppingCartItemCreateAsync(ShoppingCartItemModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ShoppingCartItems", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task ShoppingCartItemCreateManyAsync(List<ShoppingCartItemModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/ShoppingCartItems/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOSpecialOffer>>SpecialOfferSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SpecialOffers?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SpecialOffers;
		}

		public virtual async Task<List<POCOSpecialOffer>> SpecialOfferGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SpecialOffers/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SpecialOffers;
		}

		public virtual async Task<POCOSpecialOffer> SpecialOfferGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SpecialOffers/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SpecialOffers.FirstOrDefault();
		}

		public virtual async Task<List<POCOSpecialOffer>> SpecialOfferGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SpecialOffers?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SpecialOffers;
		}

		public virtual async Task SpecialOfferDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/SpecialOffers/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task SpecialOfferUpdateAsync(int id,SpecialOfferModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/SpecialOffers/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> SpecialOfferCreateAsync(SpecialOfferModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SpecialOffers", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task SpecialOfferCreateManyAsync(List<SpecialOfferModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SpecialOffers/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOSpecialOfferProduct>>SpecialOfferProductSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SpecialOfferProducts?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SpecialOfferProducts;
		}

		public virtual async Task<List<POCOSpecialOfferProduct>> SpecialOfferProductGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SpecialOfferProducts/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SpecialOfferProducts;
		}

		public virtual async Task<POCOSpecialOfferProduct> SpecialOfferProductGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SpecialOfferProducts/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SpecialOfferProducts.FirstOrDefault();
		}

		public virtual async Task<List<POCOSpecialOfferProduct>> SpecialOfferProductGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/SpecialOfferProducts?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).SpecialOfferProducts;
		}

		public virtual async Task SpecialOfferProductDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/SpecialOfferProducts/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task SpecialOfferProductUpdateAsync(int id,SpecialOfferProductModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/SpecialOfferProducts/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> SpecialOfferProductCreateAsync(SpecialOfferProductModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SpecialOfferProducts", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task SpecialOfferProductCreateManyAsync(List<SpecialOfferProductModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/SpecialOfferProducts/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOStore>>StoreSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Stores?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Stores;
		}

		public virtual async Task<List<POCOStore>> StoreGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Stores/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Stores;
		}

		public virtual async Task<POCOStore> StoreGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Stores/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Stores.FirstOrDefault();
		}

		public virtual async Task<List<POCOStore>> StoreGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Stores?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Stores;
		}

		public virtual async Task StoreDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Stores/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task StoreUpdateAsync(int id,StoreModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Stores/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> StoreCreateAsync(StoreModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Stores", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task StoreCreateManyAsync(List<StoreModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Stores/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}
	}
}

/*<Codenesium>
    <Hash>5ec75c8ff156617cf50b0de770b8169c</Hash>
</Codenesium>*/