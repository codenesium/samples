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
	public abstract class AbstractPipelineStepNoteController : AbstractApiController
	{
		protected IPipelineStepNoteService PipelineStepNoteService { get; private set; }

		protected IApiPipelineStepNoteServerModelMapper PipelineStepNoteModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractPipelineStepNoteController(
			ApiSettings settings,
			ILogger<AbstractPipelineStepNoteController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineStepNoteService pipelineStepNoteService,
			IApiPipelineStepNoteServerModelMapper pipelineStepNoteModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.PipelineStepNoteService = pipelineStepNoteService;
			this.PipelineStepNoteModelMapper = pipelineStepNoteModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPipelineStepNoteServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiPipelineStepNoteServerResponseModel> response = await this.PipelineStepNoteService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPipelineStepNoteServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPipelineStepNoteServerResponseModel response = await this.PipelineStepNoteService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiPipelineStepNoteServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPipelineStepNoteServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiPipelineStepNoteServerResponseModel> records = new List<ApiPipelineStepNoteServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiPipelineStepNoteServerResponseModel> result = await this.PipelineStepNoteService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiPipelineStepNoteServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiPipelineStepNoteServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiPipelineStepNoteServerRequestModel model)
		{
			CreateResponse<ApiPipelineStepNoteServerResponseModel> result = await this.PipelineStepNoteService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/PipelineStepNotes/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiPipelineStepNoteServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPipelineStepNoteServerRequestModel> patch)
		{
			ApiPipelineStepNoteServerResponseModel record = await this.PipelineStepNoteService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiPipelineStepNoteServerRequestModel model = await this.PatchModel(id, patch) as ApiPipelineStepNoteServerRequestModel;

				UpdateResponse<ApiPipelineStepNoteServerResponseModel> result = await this.PipelineStepNoteService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPipelineStepNoteServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPipelineStepNoteServerRequestModel model)
		{
			ApiPipelineStepNoteServerRequestModel request = await this.PatchModel(id, this.PipelineStepNoteModelMapper.CreatePatch(model)) as ApiPipelineStepNoteServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiPipelineStepNoteServerResponseModel> result = await this.PipelineStepNoteService.Update(id, request);

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
			ActionResponse result = await this.PipelineStepNoteService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiPipelineStepNoteServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiPipelineStepNoteServerRequestModel> patch)
		{
			var record = await this.PipelineStepNoteService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiPipelineStepNoteServerRequestModel request = this.PipelineStepNoteModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>114e945621910ff8d9ed9032d60a215b</Hash>
</Codenesium>*/