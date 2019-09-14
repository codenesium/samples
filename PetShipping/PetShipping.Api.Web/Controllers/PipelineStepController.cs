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
	[Route("api/pipelineSteps")]
	[ApiController]
	[ApiVersion("1.0")]

	public class PipelineStepController : AbstractApiController
	{
		protected IPipelineStepService PipelineStepService { get; private set; }

		protected IApiPipelineStepServerModelMapper PipelineStepModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public PipelineStepController(
			ApiSettings settings,
			ILogger<PipelineStepController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineStepService pipelineStepService,
			IApiPipelineStepServerModelMapper pipelineStepModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.PipelineStepService = pipelineStepService;
			this.PipelineStepModelMapper = pipelineStepModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPipelineStepServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiPipelineStepServerResponseModel> response = await this.PipelineStepService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPipelineStepServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPipelineStepServerResponseModel response = await this.PipelineStepService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiPipelineStepServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPipelineStepServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiPipelineStepServerResponseModel> records = new List<ApiPipelineStepServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiPipelineStepServerResponseModel> result = await this.PipelineStepService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiPipelineStepServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiPipelineStepServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiPipelineStepServerRequestModel model)
		{
			CreateResponse<ApiPipelineStepServerResponseModel> result = await this.PipelineStepService.Create(model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPipelineStepServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPipelineStepServerRequestModel> patch)
		{
			ApiPipelineStepServerResponseModel record = await this.PipelineStepService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiPipelineStepServerRequestModel model = await this.PatchModel(id, patch) as ApiPipelineStepServerRequestModel;

				UpdateResponse<ApiPipelineStepServerResponseModel> result = await this.PipelineStepService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPipelineStepServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPipelineStepServerRequestModel model)
		{
			ApiPipelineStepServerRequestModel request = await this.PatchModel(id, this.PipelineStepModelMapper.CreatePatch(model)) as ApiPipelineStepServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiPipelineStepServerResponseModel> result = await this.PipelineStepService.Update(id, request);

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
			ActionResponse result = await this.PipelineStepService.Delete(id);

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
		[Route("{pipelineStepId}/HandlerPipelineSteps")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiHandlerPipelineStepServerResponseModel>), 200)]
		public async virtual Task<IActionResult> HandlerPipelineStepsByPipelineStepId(int pipelineStepId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiHandlerPipelineStepServerResponseModel> response = await this.PipelineStepService.HandlerPipelineStepsByPipelineStepId(pipelineStepId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{pipelineStepId}/OtherTransports")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiOtherTransportServerResponseModel>), 200)]
		public async virtual Task<IActionResult> OtherTransportsByPipelineStepId(int pipelineStepId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiOtherTransportServerResponseModel> response = await this.PipelineStepService.OtherTransportsByPipelineStepId(pipelineStepId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{pipelineStepId}/PipelineStepDestinations")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPipelineStepDestinationServerResponseModel>), 200)]
		public async virtual Task<IActionResult> PipelineStepDestinationsByPipelineStepId(int pipelineStepId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPipelineStepDestinationServerResponseModel> response = await this.PipelineStepService.PipelineStepDestinationsByPipelineStepId(pipelineStepId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{pipelineStepId}/PipelineStepNotes")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPipelineStepNoteServerResponseModel>), 200)]
		public async virtual Task<IActionResult> PipelineStepNotesByPipelineStepId(int pipelineStepId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPipelineStepNoteServerResponseModel> response = await this.PipelineStepService.PipelineStepNotesByPipelineStepId(pipelineStepId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{pipelineStepId}/PipelineStepStepRequirements")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPipelineStepStepRequirementServerResponseModel>), 200)]
		public async virtual Task<IActionResult> PipelineStepStepRequirementsByPipelineStepId(int pipelineStepId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPipelineStepStepRequirementServerResponseModel> response = await this.PipelineStepService.PipelineStepStepRequirementsByPipelineStepId(pipelineStepId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiPipelineStepServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiPipelineStepServerRequestModel> patch)
		{
			var record = await this.PipelineStepService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiPipelineStepServerRequestModel request = this.PipelineStepModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>61790c258efca082f9e2044326b46496</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/