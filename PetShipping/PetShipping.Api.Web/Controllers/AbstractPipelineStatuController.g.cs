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
	public abstract class AbstractPipelineStatuController : AbstractApiController
	{
		protected IPipelineStatuService PipelineStatuService { get; private set; }

		protected IApiPipelineStatuServerModelMapper PipelineStatuModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractPipelineStatuController(
			ApiSettings settings,
			ILogger<AbstractPipelineStatuController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineStatuService pipelineStatuService,
			IApiPipelineStatuServerModelMapper pipelineStatuModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.PipelineStatuService = pipelineStatuService;
			this.PipelineStatuModelMapper = pipelineStatuModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPipelineStatuServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPipelineStatuServerResponseModel> response = await this.PipelineStatuService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPipelineStatuServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPipelineStatuServerResponseModel response = await this.PipelineStatuService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiPipelineStatuServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPipelineStatuServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiPipelineStatuServerResponseModel> records = new List<ApiPipelineStatuServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiPipelineStatuServerResponseModel> result = await this.PipelineStatuService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiPipelineStatuServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiPipelineStatuServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiPipelineStatuServerRequestModel model)
		{
			CreateResponse<ApiPipelineStatuServerResponseModel> result = await this.PipelineStatuService.Create(model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPipelineStatuServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPipelineStatuServerRequestModel> patch)
		{
			ApiPipelineStatuServerResponseModel record = await this.PipelineStatuService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiPipelineStatuServerRequestModel model = await this.PatchModel(id, patch) as ApiPipelineStatuServerRequestModel;

				UpdateResponse<ApiPipelineStatuServerResponseModel> result = await this.PipelineStatuService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPipelineStatuServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPipelineStatuServerRequestModel model)
		{
			ApiPipelineStatuServerRequestModel request = await this.PatchModel(id, this.PipelineStatuModelMapper.CreatePatch(model)) as ApiPipelineStatuServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiPipelineStatuServerResponseModel> result = await this.PipelineStatuService.Update(id, request);

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
			ActionResponse result = await this.PipelineStatuService.Delete(id);

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
		[Route("{pipelineStatusId}/Pipelines")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPipelineServerResponseModel>), 200)]
		public async virtual Task<IActionResult> PipelinesByPipelineStatusId(int pipelineStatusId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPipelineServerResponseModel> response = await this.PipelineStatuService.PipelinesByPipelineStatusId(pipelineStatusId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiPipelineStatuServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiPipelineStatuServerRequestModel> patch)
		{
			var record = await this.PipelineStatuService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiPipelineStatuServerRequestModel request = this.PipelineStatuModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>1768e2b4a12ad1856c6388844b81b92f</Hash>
</Codenesium>*/