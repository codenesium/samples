using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;

namespace TestsNS.Api.Web
{
	[Route("api/selfReferences")]
	[ApiController]
	[ApiVersion("1.0")]

	public class SelfReferenceController : AbstractApiController
	{
		protected ISelfReferenceService SelfReferenceService { get; private set; }

		protected IApiSelfReferenceServerModelMapper SelfReferenceModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public SelfReferenceController(
			ApiSettings settings,
			ILogger<SelfReferenceController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISelfReferenceService selfReferenceService,
			IApiSelfReferenceServerModelMapper selfReferenceModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.SelfReferenceService = selfReferenceService;
			this.SelfReferenceModelMapper = selfReferenceModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSelfReferenceServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiSelfReferenceServerResponseModel> response = await this.SelfReferenceService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSelfReferenceServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiSelfReferenceServerResponseModel response = await this.SelfReferenceService.Get(id);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<List<ApiSelfReferenceServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSelfReferenceServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiSelfReferenceServerResponseModel> records = new List<ApiSelfReferenceServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiSelfReferenceServerResponseModel> result = await this.SelfReferenceService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiSelfReferenceServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiSelfReferenceServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiSelfReferenceServerRequestModel model)
		{
			CreateResponse<ApiSelfReferenceServerResponseModel> result = await this.SelfReferenceService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/SelfReferences/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiSelfReferenceServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSelfReferenceServerRequestModel> patch)
		{
			ApiSelfReferenceServerResponseModel record = await this.SelfReferenceService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiSelfReferenceServerRequestModel model = await this.PatchModel(id, patch) as ApiSelfReferenceServerRequestModel;

				UpdateResponse<ApiSelfReferenceServerResponseModel> result = await this.SelfReferenceService.Update(id, model);

				if (result.Success)
				{
					return this.Ok(result);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiSelfReferenceServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSelfReferenceServerRequestModel model)
		{
			ApiSelfReferenceServerRequestModel request = await this.PatchModel(id, this.SelfReferenceModelMapper.CreatePatch(model)) as ApiSelfReferenceServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiSelfReferenceServerResponseModel> result = await this.SelfReferenceService.Update(id, request);

				if (result.Success)
				{
					return this.Ok(result);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(ActionResponse), 200)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.SelfReferenceService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("{selfReferenceId}/SelfReferences")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSelfReferenceServerResponseModel>), 200)]
		public async virtual Task<IActionResult> SelfReferencesBySelfReferenceId(int selfReferenceId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSelfReferenceServerResponseModel> response = await this.SelfReferenceService.SelfReferencesBySelfReferenceId(selfReferenceId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{selfReferenceId2}/SelfReferencesBySelfReferenceId2")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSelfReferenceServerResponseModel>), 200)]
		public async virtual Task<IActionResult> SelfReferencesBySelfReferenceId2(int selfReferenceId2, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSelfReferenceServerResponseModel> response = await this.SelfReferenceService.SelfReferencesBySelfReferenceId2(selfReferenceId2, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiSelfReferenceServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiSelfReferenceServerRequestModel> patch)
		{
			var record = await this.SelfReferenceService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiSelfReferenceServerRequestModel request = this.SelfReferenceModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>d52f99f04ef7cf0c203bc9e4b6a1455e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/