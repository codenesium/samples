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
	public abstract class AbstractPipelineStatusController : AbstractApiController
	{
		protected IPipelineStatusService PipelineStatusService { get; private set; }

		protected IApiPipelineStatusModelMapper PipelineStatusModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractPipelineStatusController(
			ApiSettings settings,
			ILogger<AbstractPipelineStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineStatusService pipelineStatusService,
			IApiPipelineStatusModelMapper pipelineStatusModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.PipelineStatusService = pipelineStatusService;
			this.PipelineStatusModelMapper = pipelineStatusModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPipelineStatusResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiPipelineStatusResponseModel> response = await this.PipelineStatusService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPipelineStatusResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPipelineStatusResponseModel response = await this.PipelineStatusService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiPipelineStatusResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPipelineStatusRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiPipelineStatusResponseModel> records = new List<ApiPipelineStatusResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiPipelineStatusResponseModel> result = await this.PipelineStatusService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiPipelineStatusResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiPipelineStatusRequestModel model)
		{
			CreateResponse<ApiPipelineStatusResponseModel> result = await this.PipelineStatusService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/PipelineStatus/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiPipelineStatusResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPipelineStatusRequestModel> patch)
		{
			ApiPipelineStatusResponseModel record = await this.PipelineStatusService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiPipelineStatusRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiPipelineStatusResponseModel> result = await this.PipelineStatusService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPipelineStatusResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPipelineStatusRequestModel model)
		{
			ApiPipelineStatusRequestModel request = await this.PatchModel(id, this.PipelineStatusModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiPipelineStatusResponseModel> result = await this.PipelineStatusService.Update(id, request);

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
			ActionResponse result = await this.PipelineStatusService.Delete(id);

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
		[Route("{pipelineStatusId}/Pipelines")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPipelineResponseModel>), 200)]
		public async virtual Task<IActionResult> Pipelines(int pipelineStatusId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiPipelineResponseModel> response = await this.PipelineStatusService.Pipelines(pipelineStatusId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiPipelineStatusRequestModel> PatchModel(int id, JsonPatchDocument<ApiPipelineStatusRequestModel> patch)
		{
			var record = await this.PipelineStatusService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiPipelineStatusRequestModel request = this.PipelineStatusModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>09f488877cdee2bf581d3c16a7297065</Hash>
</Codenesium>*/