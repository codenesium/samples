using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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

		protected IApiTestAllFieldTypesNullableModelMapper TestAllFieldTypesNullableModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractTestAllFieldTypesNullableController(
			ApiSettings settings,
			ILogger<AbstractTestAllFieldTypesNullableController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITestAllFieldTypesNullableService testAllFieldTypesNullableService,
			IApiTestAllFieldTypesNullableModelMapper testAllFieldTypesNullableModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.TestAllFieldTypesNullableService = testAllFieldTypesNullableService;
			this.TestAllFieldTypesNullableModelMapper = testAllFieldTypesNullableModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTestAllFieldTypesNullableResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTestAllFieldTypesNullableResponseModel> response = await this.TestAllFieldTypesNullableService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiTestAllFieldTypesNullableResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiTestAllFieldTypesNullableResponseModel response = await this.TestAllFieldTypesNullableService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiTestAllFieldTypesNullableResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTestAllFieldTypesNullableRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiTestAllFieldTypesNullableResponseModel> records = new List<ApiTestAllFieldTypesNullableResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiTestAllFieldTypesNullableResponseModel> result = await this.TestAllFieldTypesNullableService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiTestAllFieldTypesNullableResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiTestAllFieldTypesNullableRequestModel model)
		{
			CreateResponse<ApiTestAllFieldTypesNullableResponseModel> result = await this.TestAllFieldTypesNullableService.Create(model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiTestAllFieldTypesNullableRequestModel> patch)
		{
			ApiTestAllFieldTypesNullableResponseModel record = await this.TestAllFieldTypesNullableService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiTestAllFieldTypesNullableRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiTestAllFieldTypesNullableResponseModel> result = await this.TestAllFieldTypesNullableService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTestAllFieldTypesNullableRequestModel model)
		{
			ApiTestAllFieldTypesNullableRequestModel request = await this.PatchModel(id, this.TestAllFieldTypesNullableModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiTestAllFieldTypesNullableResponseModel> result = await this.TestAllFieldTypesNullableService.Update(id, request);

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
			ActionResponse result = await this.TestAllFieldTypesNullableService.Delete(id);

			if (result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiTestAllFieldTypesNullableRequestModel> PatchModel(int id, JsonPatchDocument<ApiTestAllFieldTypesNullableRequestModel> patch)
		{
			var record = await this.TestAllFieldTypesNullableService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiTestAllFieldTypesNullableRequestModel request = this.TestAllFieldTypesNullableModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>44389cd258104b4157ed11adf42441fd</Hash>
</Codenesium>*/