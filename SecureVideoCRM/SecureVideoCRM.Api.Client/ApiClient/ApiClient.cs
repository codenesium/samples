using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using SecureVideoCRMNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Client
{
	public class ApiClient
	{
		protected HttpClient Client { get; private set; }

		protected string ApiUrl { get; set; }

		protected string ApiVersion { get; set; }

		protected int MaxLimit { get; set; } = 1000;

		public ApiClient(HttpClient client)
		{
			this.Client = client;
		}

		public ApiClient(string apiUrl, string apiVersion = "1.0")
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
			this.Client = new HttpClient();
			this.Client.BaseAddress = new Uri(apiUrl);
			this.Client.DefaultRequestHeaders.Accept.Clear();
			this.Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			this.Client.DefaultRequestHeaders.Add("api-version", this.ApiVersion);
		}

		public void SetBearerToken(string token)
		{
			this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		}

		public virtual async Task<CreateResponse<List<ApiVideoClientResponseModel>>> VideoBulkInsertAsync(List<ApiVideoClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Videos/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiVideoClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiVideoClientResponseModel>> VideoCreateAsync(ApiVideoClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Videos", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiVideoClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiVideoClientResponseModel>> VideoUpdateAsync(int id, ApiVideoClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Videos/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiVideoClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> VideoDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Videos/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVideoClientResponseModel> VideoGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Videos/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiVideoClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVideoClientResponseModel>> VideoAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiVideoClientResponseModel> response = new List<ApiVideoClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Videos?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiVideoClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiVideoClientResponseModel>>(httpResponse.Content.ContentToString());
				response.AddRange(records);
				if (records.Count < this.MaxLimit)
				{
					moreRecords = false;
				}
				else
				{
					offset += this.MaxLimit;
				}
			}

			return response;
		}

		public virtual async Task<CreateResponse<List<ApiUserClientResponseModel>>> UserBulkInsertAsync(List<ApiUserClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Users/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiUserClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiUserClientResponseModel>> UserCreateAsync(ApiUserClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Users", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiUserClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiUserClientResponseModel>> UserUpdateAsync(int id, ApiUserClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Users/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiUserClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> UserDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Users/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiUserClientResponseModel> UserGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Users/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiUserClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUserClientResponseModel>> UserAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiUserClientResponseModel> response = new List<ApiUserClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Users?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiUserClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiUserClientResponseModel>>(httpResponse.Content.ContentToString());
				response.AddRange(records);
				if (records.Count < this.MaxLimit)
				{
					moreRecords = false;
				}
				else
				{
					offset += this.MaxLimit;
				}
			}

			return response;
		}

		public virtual async Task<CreateResponse<List<ApiSubscriptionClientResponseModel>>> SubscriptionBulkInsertAsync(List<ApiSubscriptionClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Subscriptions/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiSubscriptionClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSubscriptionClientResponseModel>> SubscriptionCreateAsync(ApiSubscriptionClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Subscriptions", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiSubscriptionClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSubscriptionClientResponseModel>> SubscriptionUpdateAsync(int id, ApiSubscriptionClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Subscriptions/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiSubscriptionClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SubscriptionDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Subscriptions/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSubscriptionClientResponseModel> SubscriptionGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Subscriptions/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiSubscriptionClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSubscriptionClientResponseModel>> SubscriptionAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiSubscriptionClientResponseModel> response = new List<ApiSubscriptionClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Subscriptions?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiSubscriptionClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiSubscriptionClientResponseModel>>(httpResponse.Content.ContentToString());
				response.AddRange(records);
				if (records.Count < this.MaxLimit)
				{
					moreRecords = false;
				}
				else
				{
					offset += this.MaxLimit;
				}
			}

			return response;
		}

		public virtual async Task<AuthResponse> Login(LoginRequestModel model, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/auth/login", model, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<AuthResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<AuthResponse> Register(RegisterRequestModel model, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/auth/register", model, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<AuthResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<AuthResponse> ResetPassword(ResetPasswordRequestModel model, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/auth/resetpassword", model, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<AuthResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<AuthResponse> ConfirmResetPassword(ConfirmPasswordResetRequestModel model, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/auth/confirmpasswordreset", model, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<AuthResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<AuthResponse> ChangePassword(ChangePasswordRequestModel model, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/auth/changepassword", model, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<AuthResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<AuthResponse> ChangeEmail(ChangeEmailRequestModel model, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/auth/changeemail", model, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<AuthResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<AuthResponse> ConfirmChangeEmail(ConfirmChangeEmailRequestModel model, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/auth/confirmchangeemail", model, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<AuthResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<AuthResponse> ConfirmRegistration(ConfirmRegistrationRequestModel model, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/auth/confirmregistration", model, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<AuthResponse>(httpResponse.Content.ContentToString());
		}

		protected void HandleResponseCode(HttpResponseMessage httpResponse)
		{
			int responseCode = (int)httpResponse.StatusCode;
			if (responseCode >= 400 && responseCode != 422)
			{
				switch (responseCode)
				{
				case 401:
				{
					throw new UnauthorizedAccessException("Response from server was 401.");
				}

				case 404:
				{
					break;
				}

				default:
				{
					throw new Exception($"Received error response from server. Response code was {responseCode}. Message was {httpResponse.Content.ContentToString()}");
				}
				}
			}
		}
	}
}

/*<Codenesium>
    <Hash>3a5786d3d00cbb985ae5c9fdaf8b6184</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/