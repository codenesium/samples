using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Client
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

		public virtual async Task<POCOAdmin> AdminCreateAsync(ApiAdminModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Admins", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAdmin>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAdmin> AdminUpdateAsync(int id, ApiAdminModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Admins/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAdmin>(httpResponse.Content.ContentToString());
		}

		public virtual async Task AdminDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Admins/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOAdmin> AdminGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Admins/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAdmin>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOAdmin>> AdminAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Admins?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAdmin>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOAdmin>> AdminBulkInsertAsync(List<ApiAdminModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Admins/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAdmin>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOFamily> FamilyCreateAsync(ApiFamilyModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Families", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOFamily>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOFamily> FamilyUpdateAsync(int id, ApiFamilyModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Families/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOFamily>(httpResponse.Content.ContentToString());
		}

		public virtual async Task FamilyDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Families/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOFamily> FamilyGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Families/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOFamily>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOFamily>> FamilyAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Families?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOFamily>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOFamily>> FamilyBulkInsertAsync(List<ApiFamilyModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Families/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOFamily>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLesson> LessonCreateAsync(ApiLessonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Lessons", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLesson>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLesson> LessonUpdateAsync(int id, ApiLessonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Lessons/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLesson>(httpResponse.Content.ContentToString());
		}

		public virtual async Task LessonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Lessons/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOLesson> LessonGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lessons/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLesson>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLesson>> LessonAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lessons?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLesson>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLesson>> LessonBulkInsertAsync(List<ApiLessonModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Lessons/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLesson>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLessonStatus> LessonStatusCreateAsync(ApiLessonStatusModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonStatus", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLessonStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLessonStatus> LessonStatusUpdateAsync(int id, ApiLessonStatusModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LessonStatus/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLessonStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task LessonStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LessonStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOLessonStatus> LessonStatusGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLessonStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLessonStatus>> LessonStatusAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonStatus?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLessonStatus>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLessonStatus>> LessonStatusBulkInsertAsync(List<ApiLessonStatusModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonStatus/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLessonStatus>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLessonXStudent> LessonXStudentCreateAsync(ApiLessonXStudentModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonXStudents", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLessonXStudent>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLessonXStudent> LessonXStudentUpdateAsync(int id, ApiLessonXStudentModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LessonXStudents/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLessonXStudent>(httpResponse.Content.ContentToString());
		}

		public virtual async Task LessonXStudentDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LessonXStudents/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOLessonXStudent> LessonXStudentGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonXStudents/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLessonXStudent>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLessonXStudent>> LessonXStudentAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonXStudents?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLessonXStudent>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLessonXStudent>> LessonXStudentBulkInsertAsync(List<ApiLessonXStudentModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonXStudents/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLessonXStudent>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLessonXTeacher> LessonXTeacherCreateAsync(ApiLessonXTeacherModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonXTeachers", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLessonXTeacher>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLessonXTeacher> LessonXTeacherUpdateAsync(int id, ApiLessonXTeacherModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LessonXTeachers/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLessonXTeacher>(httpResponse.Content.ContentToString());
		}

		public virtual async Task LessonXTeacherDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LessonXTeachers/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOLessonXTeacher> LessonXTeacherGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonXTeachers/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLessonXTeacher>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLessonXTeacher>> LessonXTeacherAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonXTeachers?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLessonXTeacher>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLessonXTeacher>> LessonXTeacherBulkInsertAsync(List<ApiLessonXTeacherModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonXTeachers/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLessonXTeacher>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCORate> RateCreateAsync(ApiRateModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Rates", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCORate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCORate> RateUpdateAsync(int id, ApiRateModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Rates/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCORate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task RateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Rates/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCORate> RateGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Rates/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCORate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCORate>> RateAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Rates?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCORate>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCORate>> RateBulkInsertAsync(List<ApiRateModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Rates/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCORate>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpace> SpaceCreateAsync(ApiSpaceModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Spaces", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpace>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpace> SpaceUpdateAsync(int id, ApiSpaceModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Spaces/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpace>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SpaceDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Spaces/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOSpace> SpaceGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Spaces/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpace>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpace>> SpaceAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Spaces?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpace>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpace>> SpaceBulkInsertAsync(List<ApiSpaceModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Spaces/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpace>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpaceFeature> SpaceFeatureCreateAsync(ApiSpaceFeatureModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceFeatures", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpaceFeature>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpaceFeature> SpaceFeatureUpdateAsync(int id, ApiSpaceFeatureModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SpaceFeatures/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpaceFeature>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SpaceFeatureDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SpaceFeatures/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOSpaceFeature> SpaceFeatureGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceFeatures/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpaceFeature>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpaceFeature>> SpaceFeatureAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceFeatures?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpaceFeature>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpaceFeature>> SpaceFeatureBulkInsertAsync(List<ApiSpaceFeatureModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceFeatures/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpaceFeature>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpaceXSpaceFeature> SpaceXSpaceFeatureCreateAsync(ApiSpaceXSpaceFeatureModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceXSpaceFeatures", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpaceXSpaceFeature>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpaceXSpaceFeature> SpaceXSpaceFeatureUpdateAsync(int id, ApiSpaceXSpaceFeatureModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SpaceXSpaceFeatures/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpaceXSpaceFeature>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SpaceXSpaceFeatureDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SpaceXSpaceFeatures/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOSpaceXSpaceFeature> SpaceXSpaceFeatureGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceXSpaceFeatures/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpaceXSpaceFeature>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpaceXSpaceFeature>> SpaceXSpaceFeatureAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceXSpaceFeatures?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpaceXSpaceFeature>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpaceXSpaceFeature>> SpaceXSpaceFeatureBulkInsertAsync(List<ApiSpaceXSpaceFeatureModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceXSpaceFeatures/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpaceXSpaceFeature>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOState> StateCreateAsync(ApiStateModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/States", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOState>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOState> StateUpdateAsync(int id, ApiStateModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/States/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOState>(httpResponse.Content.ContentToString());
		}

		public virtual async Task StateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/States/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOState> StateGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/States/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOState>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOState>> StateAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/States?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOState>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOState>> StateBulkInsertAsync(List<ApiStateModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/States/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOState>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStudent> StudentCreateAsync(ApiStudentModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Students", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStudent>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStudent> StudentUpdateAsync(int id, ApiStudentModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Students/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStudent>(httpResponse.Content.ContentToString());
		}

		public virtual async Task StudentDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Students/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOStudent> StudentGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Students/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStudent>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOStudent>> StudentAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Students?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStudent>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOStudent>> StudentBulkInsertAsync(List<ApiStudentModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Students/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStudent>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStudentXFamily> StudentXFamilyCreateAsync(ApiStudentXFamilyModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/StudentXFamilies", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStudentXFamily>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStudentXFamily> StudentXFamilyUpdateAsync(int id, ApiStudentXFamilyModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/StudentXFamilies/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStudentXFamily>(httpResponse.Content.ContentToString());
		}

		public virtual async Task StudentXFamilyDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/StudentXFamilies/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOStudentXFamily> StudentXFamilyGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StudentXFamilies/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStudentXFamily>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOStudentXFamily>> StudentXFamilyAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StudentXFamilies?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStudentXFamily>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOStudentXFamily>> StudentXFamilyBulkInsertAsync(List<ApiStudentXFamilyModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/StudentXFamilies/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStudentXFamily>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStudio> StudioCreateAsync(ApiStudioModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Studios", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStudio>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStudio> StudioUpdateAsync(int id, ApiStudioModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Studios/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStudio>(httpResponse.Content.ContentToString());
		}

		public virtual async Task StudioDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Studios/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOStudio> StudioGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStudio>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOStudio>> StudioAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStudio>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOStudio>> StudioBulkInsertAsync(List<ApiStudioModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Studios/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStudio>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTeacher> TeacherCreateAsync(ApiTeacherModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teachers", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeacher>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTeacher> TeacherUpdateAsync(int id, ApiTeacherModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Teachers/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeacher>(httpResponse.Content.ContentToString());
		}

		public virtual async Task TeacherDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Teachers/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOTeacher> TeacherGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teachers/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeacher>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTeacher>> TeacherAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teachers?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTeacher>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTeacher>> TeacherBulkInsertAsync(List<ApiTeacherModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teachers/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTeacher>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTeacherSkill> TeacherSkillCreateAsync(ApiTeacherSkillModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherSkills", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeacherSkill>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTeacherSkill> TeacherSkillUpdateAsync(int id, ApiTeacherSkillModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TeacherSkills/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeacherSkill>(httpResponse.Content.ContentToString());
		}

		public virtual async Task TeacherSkillDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TeacherSkills/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOTeacherSkill> TeacherSkillGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherSkills/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeacherSkill>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTeacherSkill>> TeacherSkillAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherSkills?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTeacherSkill>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTeacherSkill>> TeacherSkillBulkInsertAsync(List<ApiTeacherSkillModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherSkills/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTeacherSkill>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTeacherXTeacherSkill> TeacherXTeacherSkillCreateAsync(ApiTeacherXTeacherSkillModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherXTeacherSkills", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeacherXTeacherSkill>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTeacherXTeacherSkill> TeacherXTeacherSkillUpdateAsync(int id, ApiTeacherXTeacherSkillModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TeacherXTeacherSkills/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeacherXTeacherSkill>(httpResponse.Content.ContentToString());
		}

		public virtual async Task TeacherXTeacherSkillDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TeacherXTeacherSkills/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOTeacherXTeacherSkill> TeacherXTeacherSkillGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherXTeacherSkills/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeacherXTeacherSkill>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTeacherXTeacherSkill>> TeacherXTeacherSkillAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherXTeacherSkills?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTeacherXTeacherSkill>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTeacherXTeacherSkill>> TeacherXTeacherSkillBulkInsertAsync(List<ApiTeacherXTeacherSkillModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherXTeacherSkills/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTeacherXTeacherSkill>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>9e663e67eba4665585a5b2922ff3102f</Hash>
</Codenesium>*/