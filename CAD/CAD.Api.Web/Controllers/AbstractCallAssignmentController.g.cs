using CADNS.Api.Contracts;
using CADNS.Api.Services;
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

namespace CADNS.Api.Web
{
	public abstract class AbstractCallAssignmentController : AbstractApiController
	{
		protected ICallAssignmentService CallAssignmentService { get; private set; }

		protected IApiCallAssignmentServerModelMapper CallAssignmentModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractCallAssignmentController(
			ApiSettings settings,
			ILogger<AbstractCallAssignmentController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICallAssignmentService callAssignmentService,
			IApiCallAssignmentServerModelMapper callAssignmentModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.CallAssignmentService = callAssignmentService;
			this.CallAssignmentModelMapper = callAssignmentModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCallAssignmentServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiCallAssignmentServerResponseModel> response = await this.CallAssignmentService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiCallAssignmentServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiCallAssignmentServerResponseModel response = await this.CallAssignmentService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiCallAssignmentServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiCallAssignmentServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiCallAssignmentServerResponseModel> records = new List<ApiCallAssignmentServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiCallAssignmentServerResponseModel> result = await this.CallAssignmentService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiCallAssignmentServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiCallAssignmentServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiCallAssignmentServerRequestModel model)
		{
			CreateResponse<ApiCallAssignmentServerResponseModel> result = await this.CallAssignmentService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/CallAssignments/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiCallAssignmentServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiCallAssignmentServerRequestModel> patch)
		{
			ApiCallAssignmentServerResponseModel record = await this.CallAssignmentService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiCallAssignmentServerRequestModel model = await this.PatchModel(id, patch) as ApiCallAssignmentServerRequestModel;

				UpdateResponse<ApiCallAssignmentServerResponseModel> result = await this.CallAssignmentService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiCallAssignmentServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiCallAssignmentServerRequestModel model)
		{
			ApiCallAssignmentServerRequestModel request = await this.PatchModel(id, this.CallAssignmentModelMapper.CreatePatch(model)) as ApiCallAssignmentServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiCallAssignmentServerResponseModel> result = await this.CallAssignmentService.Update(id, request);

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
			ActionResponse result = await this.CallAssignmentService.Delete(id);

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
		[Route("byCallId/{callId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCallAssignmentServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByCallId(int callId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiCallAssignmentServerResponseModel> response = await this.CallAssignmentService.ByCallId(callId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byUnitId/{unitId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCallAssignmentServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByUnitId(int unitId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiCallAssignmentServerResponseModel> response = await this.CallAssignmentService.ByUnitId(unitId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiCallAssignmentServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiCallAssignmentServerRequestModel> patch)
		{
			var record = await this.CallAssignmentService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiCallAssignmentServerRequestModel request = this.CallAssignmentModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>5b38b3ef920f4a4bfa5ff0e968fa2fbe</Hash>
</Codenesium>*/