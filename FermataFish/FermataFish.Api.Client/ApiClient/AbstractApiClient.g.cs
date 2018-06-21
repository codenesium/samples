using Codenesium.DataConversionExtensions.AspNetCore;
using FermataFishNS.Api.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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

                public virtual async Task<ApiAdminResponseModel> AdminCreateAsync(ApiAdminRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Admins", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAdminResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiAdminResponseModel> AdminUpdateAsync(int id, ApiAdminRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Admins/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAdminResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task AdminDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Admins/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiAdminResponseModel> AdminGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Admins/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiAdminResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiAdminResponseModel>> AdminAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Admins?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiAdminResponseModel>> AdminBulkInsertAsync(List<ApiAdminRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Admins/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiFamilyResponseModel> FamilyCreateAsync(ApiFamilyRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Families", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiFamilyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiFamilyResponseModel> FamilyUpdateAsync(int id, ApiFamilyRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Families/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiFamilyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task FamilyDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Families/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiFamilyResponseModel> FamilyGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Families/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiFamilyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiFamilyResponseModel>> FamilyAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Families?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiFamilyResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiFamilyResponseModel>> FamilyBulkInsertAsync(List<ApiFamilyRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Families/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiFamilyResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStudentResponseModel>> Students(int familyId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Families/Students/{familyId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStudentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStudentXFamilyResponseModel>> StudentXFamilies(int familyId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Families/StudentXFamilies/{familyId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStudentXFamilyResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLessonResponseModel> LessonCreateAsync(ApiLessonRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Lessons", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLessonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLessonResponseModel> LessonUpdateAsync(int id, ApiLessonRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Lessons/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLessonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task LessonDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Lessons/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiLessonResponseModel> LessonGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lessons/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLessonResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLessonResponseModel>> LessonAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lessons?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLessonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLessonResponseModel>> LessonBulkInsertAsync(List<ApiLessonRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Lessons/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLessonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLessonXStudentResponseModel>> LessonXStudents(int lessonId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lessons/LessonXStudents/{lessonId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLessonXStudentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLessonXTeacherResponseModel>> LessonXTeachers(int lessonId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lessons/LessonXTeachers/{lessonId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLessonXTeacherResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLessonStatusResponseModel> LessonStatusCreateAsync(ApiLessonStatusRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonStatus", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLessonStatusResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLessonStatusResponseModel> LessonStatusUpdateAsync(int id, ApiLessonStatusRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LessonStatus/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLessonStatusResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task LessonStatusDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LessonStatus/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiLessonStatusResponseModel> LessonStatusGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonStatus/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLessonStatusResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLessonStatusResponseModel>> LessonStatusAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonStatus?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLessonStatusResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLessonStatusResponseModel>> LessonStatusBulkInsertAsync(List<ApiLessonStatusRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonStatus/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLessonStatusResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLessonResponseModel>> Lessons(int lessonStatusId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonStatus/Lessons/{lessonStatusId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLessonResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLessonXStudentResponseModel> LessonXStudentCreateAsync(ApiLessonXStudentRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonXStudents", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLessonXStudentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLessonXStudentResponseModel> LessonXStudentUpdateAsync(int id, ApiLessonXStudentRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LessonXStudents/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLessonXStudentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task LessonXStudentDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LessonXStudents/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiLessonXStudentResponseModel> LessonXStudentGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonXStudents/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLessonXStudentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLessonXStudentResponseModel>> LessonXStudentAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonXStudents?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLessonXStudentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLessonXStudentResponseModel>> LessonXStudentBulkInsertAsync(List<ApiLessonXStudentRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonXStudents/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLessonXStudentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLessonXTeacherResponseModel> LessonXTeacherCreateAsync(ApiLessonXTeacherRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonXTeachers", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLessonXTeacherResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiLessonXTeacherResponseModel> LessonXTeacherUpdateAsync(int id, ApiLessonXTeacherRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LessonXTeachers/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLessonXTeacherResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task LessonXTeacherDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LessonXTeachers/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiLessonXTeacherResponseModel> LessonXTeacherGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonXTeachers/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiLessonXTeacherResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLessonXTeacherResponseModel>> LessonXTeacherAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonXTeachers?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLessonXTeacherResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLessonXTeacherResponseModel>> LessonXTeacherBulkInsertAsync(List<ApiLessonXTeacherRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonXTeachers/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLessonXTeacherResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiRateResponseModel> RateCreateAsync(ApiRateRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Rates", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiRateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiRateResponseModel> RateUpdateAsync(int id, ApiRateRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Rates/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiRateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task RateDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Rates/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiRateResponseModel> RateGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Rates/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiRateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiRateResponseModel>> RateAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Rates?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiRateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiRateResponseModel>> RateBulkInsertAsync(List<ApiRateRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Rates/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiRateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSpaceResponseModel> SpaceCreateAsync(ApiSpaceRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Spaces", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSpaceResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSpaceResponseModel> SpaceUpdateAsync(int id, ApiSpaceRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Spaces/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSpaceResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SpaceDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Spaces/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSpaceResponseModel> SpaceGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Spaces/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSpaceResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSpaceResponseModel>> SpaceAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Spaces?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSpaceResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSpaceResponseModel>> SpaceBulkInsertAsync(List<ApiSpaceRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Spaces/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSpaceResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatures(int spaceId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Spaces/SpaceXSpaceFeatures/{spaceId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSpaceXSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSpaceFeatureResponseModel> SpaceFeatureCreateAsync(ApiSpaceFeatureRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceFeatures", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSpaceFeatureResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSpaceFeatureResponseModel> SpaceFeatureUpdateAsync(int id, ApiSpaceFeatureRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SpaceFeatures/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSpaceFeatureResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SpaceFeatureDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SpaceFeatures/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSpaceFeatureResponseModel> SpaceFeatureGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceFeatures/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSpaceFeatureResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSpaceFeatureResponseModel>> SpaceFeatureAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceFeatures?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSpaceFeatureResponseModel>> SpaceFeatureBulkInsertAsync(List<ApiSpaceFeatureRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceFeatures/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSpaceXSpaceFeatureResponseModel> SpaceXSpaceFeatureCreateAsync(ApiSpaceXSpaceFeatureRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceXSpaceFeatures", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSpaceXSpaceFeatureResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiSpaceXSpaceFeatureResponseModel> SpaceXSpaceFeatureUpdateAsync(int id, ApiSpaceXSpaceFeatureRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SpaceXSpaceFeatures/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSpaceXSpaceFeatureResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task SpaceXSpaceFeatureDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SpaceXSpaceFeatures/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiSpaceXSpaceFeatureResponseModel> SpaceXSpaceFeatureGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceXSpaceFeatures/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiSpaceXSpaceFeatureResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatureAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceXSpaceFeatures?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSpaceXSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatureBulkInsertAsync(List<ApiSpaceXSpaceFeatureRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceXSpaceFeatures/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSpaceXSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiStateResponseModel> StateCreateAsync(ApiStateRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/States", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiStateResponseModel> StateUpdateAsync(int id, ApiStateRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/States/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task StateDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/States/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiStateResponseModel> StateGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/States/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStateResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStateResponseModel>> StateAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/States?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStateResponseModel>> StateBulkInsertAsync(List<ApiStateRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/States/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStudioResponseModel>> Studios(int stateId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/States/Studios/{stateId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStudioResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiStudentResponseModel> StudentCreateAsync(ApiStudentRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Students", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStudentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiStudentResponseModel> StudentUpdateAsync(int id, ApiStudentRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Students/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStudentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task StudentDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Students/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiStudentResponseModel> StudentGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Students/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStudentResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStudentResponseModel>> StudentAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Students?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStudentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStudentResponseModel>> StudentBulkInsertAsync(List<ApiStudentRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Students/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStudentResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiStudentXFamilyResponseModel> StudentXFamilyCreateAsync(ApiStudentXFamilyRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/StudentXFamilies", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStudentXFamilyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiStudentXFamilyResponseModel> StudentXFamilyUpdateAsync(int id, ApiStudentXFamilyRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/StudentXFamilies/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStudentXFamilyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task StudentXFamilyDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/StudentXFamilies/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiStudentXFamilyResponseModel> StudentXFamilyGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StudentXFamilies/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStudentXFamilyResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStudentXFamilyResponseModel>> StudentXFamilyAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StudentXFamilies?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStudentXFamilyResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStudentXFamilyResponseModel>> StudentXFamilyBulkInsertAsync(List<ApiStudentXFamilyRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/StudentXFamilies/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStudentXFamilyResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiStudioResponseModel> StudioCreateAsync(ApiStudioRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Studios", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStudioResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiStudioResponseModel> StudioUpdateAsync(int id, ApiStudioRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Studios/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStudioResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task StudioDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Studios/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiStudioResponseModel> StudioGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiStudioResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStudioResponseModel>> StudioAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStudioResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiStudioResponseModel>> StudioBulkInsertAsync(List<ApiStudioRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Studios/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiStudioResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiAdminResponseModel>> Admins(int studioId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/Admins/{studioId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiFamilyResponseModel>> Families(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/Families/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiFamilyResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiLessonStatusResponseModel>> LessonStatus(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/LessonStatus/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiLessonStatusResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSpaceResponseModel>> Spaces(int studioId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/Spaces/{studioId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSpaceResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiSpaceFeatureResponseModel>> SpaceFeatures(int studioId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/SpaceFeatures/{studioId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTeacherResponseModel>> Teachers(int studioId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/Teachers/{studioId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTeacherResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTeacherSkillResponseModel>> TeacherSkills(int studioId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/TeacherSkills/{studioId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTeacherResponseModel> TeacherCreateAsync(ApiTeacherRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teachers", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTeacherResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTeacherResponseModel> TeacherUpdateAsync(int id, ApiTeacherRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Teachers/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTeacherResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task TeacherDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Teachers/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiTeacherResponseModel> TeacherGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teachers/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTeacherResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTeacherResponseModel>> TeacherAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teachers?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTeacherResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTeacherResponseModel>> TeacherBulkInsertAsync(List<ApiTeacherRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teachers/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTeacherResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiRateResponseModel>> Rates(int teacherId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teachers/Rates/{teacherId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiRateResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTeacherXTeacherSkillResponseModel>> TeacherXTeacherSkills(int teacherId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teachers/TeacherXTeacherSkills/{teacherId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTeacherXTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTeacherSkillResponseModel> TeacherSkillCreateAsync(ApiTeacherSkillRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherSkills", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTeacherSkillResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTeacherSkillResponseModel> TeacherSkillUpdateAsync(int id, ApiTeacherSkillRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TeacherSkills/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTeacherSkillResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task TeacherSkillDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TeacherSkills/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiTeacherSkillResponseModel> TeacherSkillGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherSkills/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTeacherSkillResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTeacherSkillResponseModel>> TeacherSkillAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherSkills?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTeacherSkillResponseModel>> TeacherSkillBulkInsertAsync(List<ApiTeacherSkillRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherSkills/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTeacherXTeacherSkillResponseModel> TeacherXTeacherSkillCreateAsync(ApiTeacherXTeacherSkillRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherXTeacherSkills", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTeacherXTeacherSkillResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiTeacherXTeacherSkillResponseModel> TeacherXTeacherSkillUpdateAsync(int id, ApiTeacherXTeacherSkillRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TeacherXTeacherSkills/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTeacherXTeacherSkillResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task TeacherXTeacherSkillDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TeacherXTeacherSkills/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiTeacherXTeacherSkillResponseModel> TeacherXTeacherSkillGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherXTeacherSkills/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiTeacherXTeacherSkillResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTeacherXTeacherSkillResponseModel>> TeacherXTeacherSkillAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherXTeacherSkills?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTeacherXTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiTeacherXTeacherSkillResponseModel>> TeacherXTeacherSkillBulkInsertAsync(List<ApiTeacherXTeacherSkillRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherXTeacherSkills/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiTeacherXTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
                }
        }
}

/*<Codenesium>
    <Hash>59bcbe320bbd915880bef51557344286</Hash>
</Codenesium>*/