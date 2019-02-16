using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Web
{
	public abstract class AbstractHandlerPipelineStepController : AbstractApiController
	{
		protected IHandlerPipelineStepService HandlerPipelineStepService { get; private set; }

		protected IApiHandlerPipelineStepServerModelMapper HandlerPipelineStepModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractHandlerPipelineStepController(
			ApiSettings settings,
			ILogger<AbstractHandlerPipelineStepController> logger,
			ITransactionCoordinator transactionCoordinator,
			IHandlerPipelineStepService handlerPipelineStepService,
			IApiHandlerPipelineStepServerModelMapper handlerPipelineStepModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.HandlerPipelineStepService = handlerPipelineStepService;
			this.HandlerPipelineStepModelMapper = handlerPipelineStepModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiHandlerPipelineStepServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiHandlerPipelineStepServerResponseModel> response = await this.HandlerPipelineStepService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiHandlerPipelineStepServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiHandlerPipelineStepServerResponseModel response = await this.HandlerPipelineStepService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiHandlerPipelineStepServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiHandlerPipelineStepServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiHandlerPipelineStepServerResponseModel> records = new List<ApiHandlerPipelineStepServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiHandlerPipelineStepServerResponseModel> result = await this.HandlerPipelineStepService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiHandlerPipelineStepServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiHandlerPipelineStepServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiHandlerPipelineStepServerRequestModel model)
		{
			CreateResponse<ApiHandlerPipelineStepServerResponseModel> result = await this.HandlerPipelineStepService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/HandlerPipelineSteps/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiHandlerPipelineStepServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiHandlerPipelineStepServerRequestModel> patch)
		{
			ApiHandlerPipelineStepServerResponseModel record = await this.HandlerPipelineStepService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiHandlerPipelineStepServerRequestModel model = await this.PatchModel(id, patch) as ApiHandlerPipelineStepServerRequestModel;

				UpdateResponse<ApiHandlerPipelineStepServerResponseModel> result = await this.HandlerPipelineStepService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiHandlerPipelineStepServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiHandlerPipelineStepServerRequestModel model)
		{
			ApiHandlerPipelineStepServerRequestModel request = await this.PatchModel(id, this.HandlerPipelineStepModelMapper.CreatePatch(model)) as ApiHandlerPipelineStepServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiHandlerPipelineStepServerResponseModel> result = await this.HandlerPipelineStepService.Update(id, request);

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
			ActionResponse result = await this.HandlerPipelineStepService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiHandlerPipelineStepServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiHandlerPipelineStepServerRequestModel> patch)
		{
			var record = await this.HandlerPipelineStepService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiHandlerPipelineStepServerRequestModel request = this.HandlerPipelineStepModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>6e795b7ad52f7daf81b364bb3e7450d0</Hash>
</Codenesium>*/