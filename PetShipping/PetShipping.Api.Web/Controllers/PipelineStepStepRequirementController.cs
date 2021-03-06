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
	[Route("api/pipelineStepStepRequirements")]
	[ApiController]
	[ApiVersion("1.0")]

	public class PipelineStepStepRequirementController : AbstractApiController
	{
		protected IPipelineStepStepRequirementService PipelineStepStepRequirementService { get; private set; }

		protected IApiPipelineStepStepRequirementServerModelMapper PipelineStepStepRequirementModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public PipelineStepStepRequirementController(
			ApiSettings settings,
			ILogger<PipelineStepStepRequirementController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineStepStepRequirementService pipelineStepStepRequirementService,
			IApiPipelineStepStepRequirementServerModelMapper pipelineStepStepRequirementModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.PipelineStepStepRequirementService = pipelineStepStepRequirementService;
			this.PipelineStepStepRequirementModelMapper = pipelineStepStepRequirementModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPipelineStepStepRequirementServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiPipelineStepStepRequirementServerResponseModel> response = await this.PipelineStepStepRequirementService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPipelineStepStepRequirementServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPipelineStepStepRequirementServerResponseModel response = await this.PipelineStepStepRequirementService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiPipelineStepStepRequirementServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPipelineStepStepRequirementServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiPipelineStepStepRequirementServerResponseModel> records = new List<ApiPipelineStepStepRequirementServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiPipelineStepStepRequirementServerResponseModel> result = await this.PipelineStepStepRequirementService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiPipelineStepStepRequirementServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiPipelineStepStepRequirementServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiPipelineStepStepRequirementServerRequestModel model)
		{
			CreateResponse<ApiPipelineStepStepRequirementServerResponseModel> result = await this.PipelineStepStepRequirementService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/PipelineStepStepRequirements/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiPipelineStepStepRequirementServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPipelineStepStepRequirementServerRequestModel> patch)
		{
			ApiPipelineStepStepRequirementServerResponseModel record = await this.PipelineStepStepRequirementService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiPipelineStepStepRequirementServerRequestModel model = await this.PatchModel(id, patch) as ApiPipelineStepStepRequirementServerRequestModel;

				UpdateResponse<ApiPipelineStepStepRequirementServerResponseModel> result = await this.PipelineStepStepRequirementService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPipelineStepStepRequirementServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPipelineStepStepRequirementServerRequestModel model)
		{
			ApiPipelineStepStepRequirementServerRequestModel request = await this.PatchModel(id, this.PipelineStepStepRequirementModelMapper.CreatePatch(model)) as ApiPipelineStepStepRequirementServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiPipelineStepStepRequirementServerResponseModel> result = await this.PipelineStepStepRequirementService.Update(id, request);

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
			ActionResponse result = await this.PipelineStepStepRequirementService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiPipelineStepStepRequirementServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiPipelineStepStepRequirementServerRequestModel> patch)
		{
			var record = await this.PipelineStepStepRequirementService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiPipelineStepStepRequirementServerRequestModel request = this.PipelineStepStepRequirementModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>d9ccef757c916aefdcd0049432705c23</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/