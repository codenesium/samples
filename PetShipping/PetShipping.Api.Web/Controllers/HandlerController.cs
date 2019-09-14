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
	[Route("api/handlers")]
	[ApiController]
	[ApiVersion("1.0")]

	public class HandlerController : AbstractApiController
	{
		protected IHandlerService HandlerService { get; private set; }

		protected IApiHandlerServerModelMapper HandlerModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public HandlerController(
			ApiSettings settings,
			ILogger<HandlerController> logger,
			ITransactionCoordinator transactionCoordinator,
			IHandlerService handlerService,
			IApiHandlerServerModelMapper handlerModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.HandlerService = handlerService;
			this.HandlerModelMapper = handlerModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiHandlerServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiHandlerServerResponseModel> response = await this.HandlerService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiHandlerServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiHandlerServerResponseModel response = await this.HandlerService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiHandlerServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiHandlerServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiHandlerServerResponseModel> records = new List<ApiHandlerServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiHandlerServerResponseModel> result = await this.HandlerService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiHandlerServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiHandlerServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiHandlerServerRequestModel model)
		{
			CreateResponse<ApiHandlerServerResponseModel> result = await this.HandlerService.Create(model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiHandlerServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiHandlerServerRequestModel> patch)
		{
			ApiHandlerServerResponseModel record = await this.HandlerService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiHandlerServerRequestModel model = await this.PatchModel(id, patch) as ApiHandlerServerRequestModel;

				UpdateResponse<ApiHandlerServerResponseModel> result = await this.HandlerService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiHandlerServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiHandlerServerRequestModel model)
		{
			ApiHandlerServerRequestModel request = await this.PatchModel(id, this.HandlerModelMapper.CreatePatch(model)) as ApiHandlerServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiHandlerServerResponseModel> result = await this.HandlerService.Update(id, request);

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
			ActionResponse result = await this.HandlerService.Delete(id);

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
		[Route("{handlerId}/AirTransports")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiAirTransportServerResponseModel>), 200)]
		public async virtual Task<IActionResult> AirTransportsByHandlerId(int handlerId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiAirTransportServerResponseModel> response = await this.HandlerService.AirTransportsByHandlerId(handlerId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{handlerId}/HandlerPipelineSteps")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiHandlerPipelineStepServerResponseModel>), 200)]
		public async virtual Task<IActionResult> HandlerPipelineStepsByHandlerId(int handlerId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiHandlerPipelineStepServerResponseModel> response = await this.HandlerService.HandlerPipelineStepsByHandlerId(handlerId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{handlerId}/OtherTransports")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiOtherTransportServerResponseModel>), 200)]
		public async virtual Task<IActionResult> OtherTransportsByHandlerId(int handlerId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiOtherTransportServerResponseModel> response = await this.HandlerService.OtherTransportsByHandlerId(handlerId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiHandlerServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiHandlerServerRequestModel> patch)
		{
			var record = await this.HandlerService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiHandlerServerRequestModel request = this.HandlerModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>198f9e69114a8eaa062ccca205720f42</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/