using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
	public abstract class AbstractHandlerController : AbstractApiController
	{
		protected IHandlerService HandlerService { get; private set; }

		protected IApiHandlerModelMapper HandlerModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractHandlerController(
			ApiSettings settings,
			ILogger<AbstractHandlerController> logger,
			ITransactionCoordinator transactionCoordinator,
			IHandlerService handlerService,
			IApiHandlerModelMapper handlerModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.HandlerService = handlerService;
			this.HandlerModelMapper = handlerModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiHandlerResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiHandlerResponseModel> response = await this.HandlerService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiHandlerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiHandlerResponseModel response = await this.HandlerService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiHandlerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiHandlerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiHandlerResponseModel> records = new List<ApiHandlerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiHandlerResponseModel> result = await this.HandlerService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			return this.Ok(records);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiHandlerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiHandlerRequestModel model)
		{
			CreateResponse<ApiHandlerResponseModel> result = await this.HandlerService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Handlers/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiHandlerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiHandlerRequestModel> patch)
		{
			ApiHandlerResponseModel record = await this.HandlerService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiHandlerRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiHandlerResponseModel> result = await this.HandlerService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiHandlerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiHandlerRequestModel model)
		{
			ApiHandlerRequestModel request = await this.PatchModel(id, this.HandlerModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiHandlerResponseModel> result = await this.HandlerService.Update(id, request);

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
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.HandlerService.Delete(id);

			if (result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("{handlerId}/AirTransports")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiHandlerResponseModel>), 200)]
		public async virtual Task<IActionResult> AirTransports(int handlerId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiAirTransportResponseModel> response = await this.HandlerService.AirTransports(handlerId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{handlerId}/HandlerPipelineSteps")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiHandlerResponseModel>), 200)]
		public async virtual Task<IActionResult> HandlerPipelineSteps(int handlerId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiHandlerPipelineStepResponseModel> response = await this.HandlerService.HandlerPipelineSteps(handlerId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{handlerId}/OtherTransports")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiHandlerResponseModel>), 200)]
		public async virtual Task<IActionResult> OtherTransports(int handlerId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiOtherTransportResponseModel> response = await this.HandlerService.OtherTransports(handlerId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiHandlerRequestModel> PatchModel(int id, JsonPatchDocument<ApiHandlerRequestModel> patch)
		{
			var record = await this.HandlerService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiHandlerRequestModel request = this.HandlerModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>e1b613d09f86a3d096abdd702ef365c1</Hash>
</Codenesium>*/