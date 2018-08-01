using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Client
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

		public virtual async Task<List<ApiPersonResponseModel>> PersonBulkInsertAsync(List<ApiPersonRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/People/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiRowVersionCheckResponseModel>> RowVersionCheckCreateAsync(ApiRowVersionCheckRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/RowVersionChecks", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiRowVersionCheckResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiRowVersionCheckResponseModel>> RowVersionCheckUpdateAsync(int id, ApiRowVersionCheckRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/RowVersionChecks/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiRowVersionCheckResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> RowVersionCheckDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/RowVersionChecks/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiRowVersionCheckResponseModel> RowVersionCheckGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/RowVersionChecks/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiRowVersionCheckResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiRowVersionCheckResponseModel>> RowVersionCheckAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/RowVersionChecks?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiRowVersionCheckResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiRowVersionCheckResponseModel>> RowVersionCheckBulkInsertAsync(List<ApiRowVersionCheckRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/RowVersionChecks/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiRowVersionCheckResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSelfReferenceResponseModel>> SelfReferenceCreateAsync(ApiSelfReferenceRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SelfReferences", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSelfReferenceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSelfReferenceResponseModel>> SelfReferenceUpdateAsync(int id, ApiSelfReferenceRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SelfReferences/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSelfReferenceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SelfReferenceDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SelfReferences/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSelfReferenceResponseModel> SelfReferenceGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SelfReferences/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSelfReferenceResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSelfReferenceResponseModel>> SelfReferenceAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SelfReferences?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSelfReferenceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSelfReferenceResponseModel>> SelfReferenceBulkInsertAsync(List<ApiSelfReferenceRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SelfReferences/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSelfReferenceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSelfReferenceResponseModel>> SelfReferences(int selfReferenceId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SelfReferences/SelfReferences/{selfReferenceId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSelfReferenceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTableResponseModel>> TableCreateAsync(ApiTableRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Tables", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTableResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTableResponseModel>> TableUpdateAsync(int id, ApiTableRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Tables/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTableResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TableDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Tables/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTableResponseModel> TableGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tables/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTableResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTableResponseModel>> TableAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tables?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTableResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTableResponseModel>> TableBulkInsertAsync(List<ApiTableRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Tables/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTableResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTestAllFieldTypeResponseModel>> TestAllFieldTypeCreateAsync(ApiTestAllFieldTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TestAllFieldTypes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTestAllFieldTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTestAllFieldTypeResponseModel>> TestAllFieldTypeUpdateAsync(int id, ApiTestAllFieldTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TestAllFieldTypes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTestAllFieldTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TestAllFieldTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TestAllFieldTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTestAllFieldTypeResponseModel> TestAllFieldTypeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TestAllFieldTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTestAllFieldTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTestAllFieldTypeResponseModel>> TestAllFieldTypeAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TestAllFieldTypes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTestAllFieldTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTestAllFieldTypeResponseModel>> TestAllFieldTypeBulkInsertAsync(List<ApiTestAllFieldTypeRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TestAllFieldTypes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTestAllFieldTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTestAllFieldTypesNullableResponseModel>> TestAllFieldTypesNullableCreateAsync(ApiTestAllFieldTypesNullableRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TestAllFieldTypesNullables", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTestAllFieldTypesNullableResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>> TestAllFieldTypesNullableUpdateAsync(int id, ApiTestAllFieldTypesNullableRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TestAllFieldTypesNullables/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TestAllFieldTypesNullableDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TestAllFieldTypesNullables/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTestAllFieldTypesNullableResponseModel> TestAllFieldTypesNullableGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TestAllFieldTypesNullables/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTestAllFieldTypesNullableResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTestAllFieldTypesNullableResponseModel>> TestAllFieldTypesNullableAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TestAllFieldTypesNullables?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTestAllFieldTypesNullableResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTestAllFieldTypesNullableResponseModel>> TestAllFieldTypesNullableBulkInsertAsync(List<ApiTestAllFieldTypesNullableRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TestAllFieldTypesNullables/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTestAllFieldTypesNullableResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTimestampCheckResponseModel>> TimestampCheckCreateAsync(ApiTimestampCheckRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TimestampChecks", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTimestampCheckResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTimestampCheckResponseModel>> TimestampCheckUpdateAsync(int id, ApiTimestampCheckRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TimestampChecks/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTimestampCheckResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TimestampCheckDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TimestampChecks/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTimestampCheckResponseModel> TimestampCheckGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TimestampChecks/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTimestampCheckResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTimestampCheckResponseModel>> TimestampCheckAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TimestampChecks?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTimestampCheckResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTimestampCheckResponseModel>> TimestampCheckBulkInsertAsync(List<ApiTimestampCheckRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TimestampChecks/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTimestampCheckResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSchemaAPersonResponseModel>> SchemaAPersonCreateAsync(ApiSchemaAPersonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SchemaAPersons", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSchemaAPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSchemaAPersonResponseModel>> SchemaAPersonUpdateAsync(int id, ApiSchemaAPersonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SchemaAPersons/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSchemaAPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SchemaAPersonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SchemaAPersons/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSchemaAPersonResponseModel> SchemaAPersonGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SchemaAPersons/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSchemaAPersonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSchemaAPersonResponseModel>> SchemaAPersonAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SchemaAPersons?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSchemaAPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSchemaAPersonResponseModel>> SchemaAPersonBulkInsertAsync(List<ApiSchemaAPersonRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SchemaAPersons/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSchemaAPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSchemaBPersonResponseModel>> SchemaBPersonCreateAsync(ApiSchemaBPersonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SchemaBPersons", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSchemaBPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSchemaBPersonResponseModel>> SchemaBPersonUpdateAsync(int id, ApiSchemaBPersonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SchemaBPersons/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSchemaBPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SchemaBPersonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SchemaBPersons/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSchemaBPersonResponseModel> SchemaBPersonGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SchemaBPersons/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSchemaBPersonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSchemaBPersonResponseModel>> SchemaBPersonAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SchemaBPersons?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSchemaBPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSchemaBPersonResponseModel>> SchemaBPersonBulkInsertAsync(List<ApiSchemaBPersonRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SchemaBPersons/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSchemaBPersonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonRefResponseModel>> PersonRefs(int personBId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SchemaBPersons/PersonRefs/{personBId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPersonRefResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPersonRefResponseModel>> PersonRefCreateAsync(ApiPersonRefRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonRefs", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPersonRefResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPersonRefResponseModel>> PersonRefUpdateAsync(int id, ApiPersonRefRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PersonRefs/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPersonRefResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PersonRefDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PersonRefs/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPersonRefResponseModel> PersonRefGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonRefs/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPersonRefResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonRefResponseModel>> PersonRefAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PersonRefs?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPersonRefResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPersonRefResponseModel>> PersonRefBulkInsertAsync(List<ApiPersonRefRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PersonRefs/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPersonRefResponseModel>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>8ccc0920023174f1e8443d3c514fa1eb</Hash>
</Codenesium>*/