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
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;

namespace TestsNS.Api.Web
{
	public abstract class AbstractTestAllFieldTypesNullableController : AbstractApiController
	{
		protected ITestAllFieldTypesNullableService TestAllFieldTypesNullableService { get; private set; }

		protected IApiTestAllFieldTypesNullableServerModelMapper TestAllFieldTypesNullableModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractTestAllFieldTypesNullableController(
			ApiSettings settings,
			ILogger<AbstractTestAllFieldTypesNullableController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITestAllFieldTypesNullableService testAllFieldTypesNullableService,
			IApiTestAllFieldTypesNullableServerModelMapper testAllFieldTypesNullableModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.TestAllFieldTypesNullableService = testAllFieldTypesNullableService;
			this.TestAllFieldTypesNullableModelMapper = testAllFieldTypesNullableModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTestAllFieldTypesNullableServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTestAllFieldTypesNullableServerResponseModel> response = await this.TestAllFieldTypesNullableService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiTestAllFieldTypesNullableServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiTestAllFieldTypesNullableServerResponseModel response = await this.TestAllFieldTypesNullableService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiTestAllFieldTypesNullableServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTestAllFieldTypesNullableServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiTestAllFieldTypesNullableServerResponseModel> records = new List<ApiTestAllFieldTypesNullableServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiTestAllFieldTypesNullableServerResponseModel> result = await this.TestAllFieldTypesNullableService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiTestAllFieldTypesNullableServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiTestAllFieldTypesNullableServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiTestAllFieldTypesNullableServerRequestModel model)
		{
			CreateResponse<ApiTestAllFieldTypesNullableServerResponseModel> result = await this.TestAllFieldTypesNullableService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/TestAllFieldTypesNullables/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiTestAllFieldTypesNullableServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiTestAllFieldTypesNullableServerRequestModel> patch)
		{
			ApiTestAllFieldTypesNullableServerResponseModel record = await this.TestAllFieldTypesNullableService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiTestAllFieldTypesNullableServerRequestModel model = await this.PatchModel(id, patch) as ApiTestAllFieldTypesNullableServerRequestModel;

				UpdateResponse<ApiTestAllFieldTypesNullableServerResponseModel> result = await this.TestAllFieldTypesNullableService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTestAllFieldTypesNullableServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTestAllFieldTypesNullableServerRequestModel model)
		{
			ApiTestAllFieldTypesNullableServerRequestModel request = await this.PatchModel(id, this.TestAllFieldTypesNullableModelMapper.CreatePatch(model)) as ApiTestAllFieldTypesNullableServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiTestAllFieldTypesNullableServerResponseModel> result = await this.TestAllFieldTypesNullableService.Update(id, request);

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
			ActionResponse result = await this.TestAllFieldTypesNullableService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiTestAllFieldTypesNullableServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiTestAllFieldTypesNullableServerRequestModel> patch)
		{
			var record = await this.TestAllFieldTypesNullableService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiTestAllFieldTypesNullableServerRequestModel request = this.TestAllFieldTypesNullableModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>531dacbd2f97e092427dcc386fffe90a</Hash>
</Codenesium>*/