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
	public abstract class AbstractPipelineStepController : AbstractApiController
	{
		protected IPipelineStepService PipelineStepService { get; private set; }

		protected IApiPipelineStepModelMapper PipelineStepModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractPipelineStepController(
			ApiSettings settings,
			ILogger<AbstractPipelineStepController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineStepService pipelineStepService,
			IApiPipelineStepModelMapper pipelineStepModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.PipelineStepService = pipelineStepService;
			this.PipelineStepModelMapper = pipelineStepModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPipelineStepResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiPipelineStepResponseModel> response = await this.PipelineStepService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPipelineStepResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPipelineStepResponseModel response = await this.PipelineStepService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiPipelineStepResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPipelineStepRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiPipelineStepResponseModel> records = new List<ApiPipelineStepResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiPipelineStepResponseModel> result = await this.PipelineStepService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiPipelineStepResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiPipelineStepRequestModel model)
		{
			CreateResponse<ApiPipelineStepResponseModel> result = await this.PipelineStepService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/PipelineSteps/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiPipelineStepResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPipelineStepRequestModel> patch)
		{
			ApiPipelineStepResponseModel record = await this.PipelineStepService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiPipelineStepRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiPipelineStepResponseModel> result = await this.PipelineStepService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPipelineStepResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPipelineStepRequestModel model)
		{
			ApiPipelineStepRequestModel request = await this.PatchModel(id, this.PipelineStepModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiPipelineStepResponseModel> result = await this.PipelineStepService.Update(id, request);

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
			ActionResponse result = await this.PipelineStepService.Delete(id);

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
		[Route("{pipelineStepId}/HandlerPipelineSteps")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPipelineStepResponseModel>), 200)]
		public async virtual Task<IActionResult> HandlerPipelineSteps(int pipelineStepId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiHandlerPipelineStepResponseModel> response = await this.PipelineStepService.HandlerPipelineSteps(pipelineStepId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{pipelineStepId}/OtherTransports")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPipelineStepResponseModel>), 200)]
		public async virtual Task<IActionResult> OtherTransports(int pipelineStepId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiOtherTransportResponseModel> response = await this.PipelineStepService.OtherTransports(pipelineStepId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{pipelineStepId}/PipelineStepDestinations")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPipelineStepResponseModel>), 200)]
		public async virtual Task<IActionResult> PipelineStepDestinations(int pipelineStepId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiPipelineStepDestinationResponseModel> response = await this.PipelineStepService.PipelineStepDestinations(pipelineStepId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{pipelineStepId}/PipelineStepNotes")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPipelineStepResponseModel>), 200)]
		public async virtual Task<IActionResult> PipelineStepNotes(int pipelineStepId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiPipelineStepNoteResponseModel> response = await this.PipelineStepService.PipelineStepNotes(pipelineStepId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{pipelineStepId}/PipelineStepStepRequirements")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPipelineStepResponseModel>), 200)]
		public async virtual Task<IActionResult> PipelineStepStepRequirements(int pipelineStepId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiPipelineStepStepRequirementResponseModel> response = await this.PipelineStepService.PipelineStepStepRequirements(pipelineStepId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiPipelineStepRequestModel> PatchModel(int id, JsonPatchDocument<ApiPipelineStepRequestModel> patch)
		{
			var record = await this.PipelineStepService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiPipelineStepRequestModel request = this.PipelineStepModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>1fcc45a924049c9170055cf4821f58de</Hash>
</Codenesium>*/