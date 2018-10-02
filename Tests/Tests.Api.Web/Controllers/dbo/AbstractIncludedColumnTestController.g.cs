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
	public abstract class AbstractIncludedColumnTestController : AbstractApiController
	{
		protected IIncludedColumnTestService IncludedColumnTestService { get; private set; }

		protected IApiIncludedColumnTestModelMapper IncludedColumnTestModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractIncludedColumnTestController(
			ApiSettings settings,
			ILogger<AbstractIncludedColumnTestController> logger,
			ITransactionCoordinator transactionCoordinator,
			IIncludedColumnTestService includedColumnTestService,
			IApiIncludedColumnTestModelMapper includedColumnTestModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.IncludedColumnTestService = includedColumnTestService;
			this.IncludedColumnTestModelMapper = includedColumnTestModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiIncludedColumnTestResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiIncludedColumnTestResponseModel> response = await this.IncludedColumnTestService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiIncludedColumnTestResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiIncludedColumnTestResponseModel response = await this.IncludedColumnTestService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiIncludedColumnTestResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiIncludedColumnTestRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiIncludedColumnTestResponseModel> records = new List<ApiIncludedColumnTestResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiIncludedColumnTestResponseModel> result = await this.IncludedColumnTestService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiIncludedColumnTestResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiIncludedColumnTestRequestModel model)
		{
			CreateResponse<ApiIncludedColumnTestResponseModel> result = await this.IncludedColumnTestService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/IncludedColumnTests/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiIncludedColumnTestResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiIncludedColumnTestRequestModel> patch)
		{
			ApiIncludedColumnTestResponseModel record = await this.IncludedColumnTestService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiIncludedColumnTestRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiIncludedColumnTestResponseModel> result = await this.IncludedColumnTestService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiIncludedColumnTestResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiIncludedColumnTestRequestModel model)
		{
			ApiIncludedColumnTestRequestModel request = await this.PatchModel(id, this.IncludedColumnTestModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiIncludedColumnTestResponseModel> result = await this.IncludedColumnTestService.Update(id, request);

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
			ActionResponse result = await this.IncludedColumnTestService.Delete(id);

			if (result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiIncludedColumnTestRequestModel> PatchModel(int id, JsonPatchDocument<ApiIncludedColumnTestRequestModel> patch)
		{
			var record = await this.IncludedColumnTestService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiIncludedColumnTestRequestModel request = this.IncludedColumnTestModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>245ff4b86e42175c0e42ac86bea328fe</Hash>
</Codenesium>*/