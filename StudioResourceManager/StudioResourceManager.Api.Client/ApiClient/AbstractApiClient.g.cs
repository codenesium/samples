using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
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

		public virtual async Task<List<ApiAdminResponseModel>> AdminBulkInsertAsync(List<ApiAdminRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Admins/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiAdminResponseModel>> AdminCreateAsync(ApiAdminRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Admins", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiAdminResponseModel>> AdminUpdateAsync(int id, ApiAdminRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Admins/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> AdminDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Admins/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAdminResponseModel> AdminGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Admins/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiAdminResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAdminResponseModel>> AdminAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Admins?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventResponseModel>> EventBulkInsertAsync(List<ApiEventRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Events/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiEventResponseModel>> EventCreateAsync(ApiEventRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Events", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiEventResponseModel>> EventUpdateAsync(int id, ApiEventRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Events/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> EventDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Events/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEventResponseModel> EventGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiEventResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventResponseModel>> EventAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventStudentResponseModel>> EventStudents(int eventId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events/EventStudents/{eventId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventTeacherResponseModel>> EventTeachers(int eventId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Events/EventTeachers/{eventId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventStatusResponseModel>> EventStatusBulkInsertAsync(List<ApiEventStatusRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EventStatuses/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiEventStatusResponseModel>> EventStatusCreateAsync(ApiEventStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EventStatuses", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiEventStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiEventStatusResponseModel>> EventStatusUpdateAsync(int id, ApiEventStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/EventStatuses/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiEventStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> EventStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/EventStatuses/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEventStatusResponseModel> EventStatusGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EventStatuses/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiEventStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventStatusResponseModel>> EventStatusAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EventStatuses?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventResponseModel>> Events(int eventStatusId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EventStatuses/Events/{eventStatusId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventStudentResponseModel>> EventStudentBulkInsertAsync(List<ApiEventStudentRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EventStudents/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiEventStudentResponseModel>> EventStudentCreateAsync(ApiEventStudentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EventStudents", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiEventStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiEventStudentResponseModel>> EventStudentUpdateAsync(int id, ApiEventStudentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/EventStudents/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiEventStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> EventStudentDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/EventStudents/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEventStudentResponseModel> EventStudentGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EventStudents/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiEventStudentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventStudentResponseModel>> EventStudentAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EventStudents?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventTeacherResponseModel>> EventTeacherBulkInsertAsync(List<ApiEventTeacherRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EventTeachers/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiEventTeacherResponseModel>> EventTeacherCreateAsync(ApiEventTeacherRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/EventTeachers", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiEventTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiEventTeacherResponseModel>> EventTeacherUpdateAsync(int id, ApiEventTeacherRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/EventTeachers/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiEventTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> EventTeacherDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/EventTeachers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiEventTeacherResponseModel> EventTeacherGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EventTeachers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiEventTeacherResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiEventTeacherResponseModel>> EventTeacherAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/EventTeachers?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiEventTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiFamilyResponseModel>> FamilyBulkInsertAsync(List<ApiFamilyRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Families/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiFamilyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiFamilyResponseModel>> FamilyCreateAsync(ApiFamilyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Families", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiFamilyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiFamilyResponseModel>> FamilyUpdateAsync(int id, ApiFamilyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Families/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiFamilyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> FamilyDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Families/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiFamilyResponseModel> FamilyGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Families/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiFamilyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiFamilyResponseModel>> FamilyAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Families?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiFamilyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStudentResponseModel>> Students(int familyId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Families/Students/{familyId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiRateResponseModel>> RateBulkInsertAsync(List<ApiRateRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Rates/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiRateResponseModel>> RateCreateAsync(ApiRateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Rates", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiRateResponseModel>> RateUpdateAsync(int id, ApiRateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Rates/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> RateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Rates/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiRateResponseModel> RateGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Rates/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiRateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiRateResponseModel>> RateAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Rates?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpaceResponseModel>> SpaceBulkInsertAsync(List<ApiSpaceRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Spaces/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpaceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSpaceResponseModel>> SpaceCreateAsync(ApiSpaceRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Spaces", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSpaceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSpaceResponseModel>> SpaceUpdateAsync(int id, ApiSpaceRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Spaces/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSpaceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SpaceDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Spaces/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSpaceResponseModel> SpaceGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Spaces/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSpaceResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpaceResponseModel>> SpaceAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Spaces?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpaceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpaceSpaceFeatureResponseModel>> SpaceSpaceFeatures(int spaceId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Spaces/SpaceSpaceFeatures/{spaceId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpaceSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpaceFeatureResponseModel>> SpaceFeatureBulkInsertAsync(List<ApiSpaceFeatureRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceFeatures/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSpaceFeatureResponseModel>> SpaceFeatureCreateAsync(ApiSpaceFeatureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceFeatures", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSpaceFeatureResponseModel>> SpaceFeatureUpdateAsync(int id, ApiSpaceFeatureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SpaceFeatures/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SpaceFeatureDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SpaceFeatures/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSpaceFeatureResponseModel> SpaceFeatureGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceFeatures/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSpaceFeatureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpaceFeatureResponseModel>> SpaceFeatureAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceFeatures?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpaceSpaceFeatureResponseModel>> SpaceSpaceFeatureBulkInsertAsync(List<ApiSpaceSpaceFeatureRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceSpaceFeatures/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpaceSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSpaceSpaceFeatureResponseModel>> SpaceSpaceFeatureCreateAsync(ApiSpaceSpaceFeatureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceSpaceFeatures", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSpaceSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSpaceSpaceFeatureResponseModel>> SpaceSpaceFeatureUpdateAsync(int id, ApiSpaceSpaceFeatureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SpaceSpaceFeatures/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSpaceSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SpaceSpaceFeatureDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SpaceSpaceFeatures/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSpaceSpaceFeatureResponseModel> SpaceSpaceFeatureGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceSpaceFeatures/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSpaceSpaceFeatureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpaceSpaceFeatureResponseModel>> SpaceSpaceFeatureAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceSpaceFeatures?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpaceSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStudentResponseModel>> StudentBulkInsertAsync(List<ApiStudentRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Students/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiStudentResponseModel>> StudentCreateAsync(ApiStudentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Students", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiStudentResponseModel>> StudentUpdateAsync(int id, ApiStudentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Students/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> StudentDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Students/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiStudentResponseModel> StudentGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Students/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiStudentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStudentResponseModel>> StudentAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Students?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStudioResponseModel>> StudioBulkInsertAsync(List<ApiStudioRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Studios/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStudioResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiStudioResponseModel>> StudioCreateAsync(ApiStudioRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Studios", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiStudioResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiStudioResponseModel>> StudioUpdateAsync(int id, ApiStudioRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Studios/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiStudioResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> StudioDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Studios/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiStudioResponseModel> StudioGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiStudioResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStudioResponseModel>> StudioAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStudioResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeacherResponseModel>> TeacherBulkInsertAsync(List<ApiTeacherRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teachers/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTeacherResponseModel>> TeacherCreateAsync(ApiTeacherRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teachers", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTeacherResponseModel>> TeacherUpdateAsync(int id, ApiTeacherRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Teachers/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TeacherDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Teachers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTeacherResponseModel> TeacherGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teachers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTeacherResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeacherResponseModel>> TeacherAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teachers?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiRateResponseModel>> Rates(int teacherId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teachers/Rates/{teacherId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeacherTeacherSkillResponseModel>> TeacherTeacherSkills(int teacherId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teachers/TeacherTeacherSkills/{teacherId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeacherTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeacherSkillResponseModel>> TeacherSkillBulkInsertAsync(List<ApiTeacherSkillRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherSkills/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTeacherSkillResponseModel>> TeacherSkillCreateAsync(ApiTeacherSkillRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherSkills", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTeacherSkillResponseModel>> TeacherSkillUpdateAsync(int id, ApiTeacherSkillRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TeacherSkills/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TeacherSkillDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TeacherSkills/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTeacherSkillResponseModel> TeacherSkillGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherSkills/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTeacherSkillResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeacherSkillResponseModel>> TeacherSkillAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherSkills?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeacherTeacherSkillResponseModel>> TeacherTeacherSkillBulkInsertAsync(List<ApiTeacherTeacherSkillRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherTeacherSkills/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeacherTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTeacherTeacherSkillResponseModel>> TeacherTeacherSkillCreateAsync(ApiTeacherTeacherSkillRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherTeacherSkills", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTeacherTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTeacherTeacherSkillResponseModel>> TeacherTeacherSkillUpdateAsync(int id, ApiTeacherTeacherSkillRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TeacherTeacherSkills/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTeacherTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TeacherTeacherSkillDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TeacherTeacherSkills/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTeacherTeacherSkillResponseModel> TeacherTeacherSkillGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherTeacherSkills/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTeacherTeacherSkillResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeacherTeacherSkillResponseModel>> TeacherTeacherSkillAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherTeacherSkills?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeacherTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTenantResponseModel>> TenantBulkInsertAsync(List<ApiTenantRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Tenants/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTenantResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTenantResponseModel>> TenantCreateAsync(ApiTenantRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Tenants", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTenantResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTenantResponseModel>> TenantUpdateAsync(int id, ApiTenantRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Tenants/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTenantResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TenantDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Tenants/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTenantResponseModel> TenantGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tenants/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTenantResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTenantResponseModel>> TenantAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tenants?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTenantResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUserResponseModel>> UserBulkInsertAsync(List<ApiUserRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Users/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiUserResponseModel>> UserCreateAsync(ApiUserRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Users", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiUserResponseModel>> UserUpdateAsync(int id, ApiUserRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Users/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> UserDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Users/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiUserResponseModel> UserGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiUserResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUserResponseModel>> UserAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAdminResponseModel>> Admins(int userId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/Admins/{userId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeacherResponseModel>> Teachers(int userId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/Teachers/{userId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVEventResponseModel> VEventGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VEvents/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiVEventResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVEventResponseModel>> VEventAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VEvents?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVEventResponseModel>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>cb98e0cda3d68ba07406c7825ad06359</Hash>
</Codenesium>*/