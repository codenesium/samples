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
	public abstract class AbstractColumnSameAsFKTableController : AbstractApiController
	{
		protected IColumnSameAsFKTableService ColumnSameAsFKTableService { get; private set; }

		protected IApiColumnSameAsFKTableServerModelMapper ColumnSameAsFKTableModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractColumnSameAsFKTableController(
			ApiSettings settings,
			ILogger<AbstractColumnSameAsFKTableController> logger,
			ITransactionCoordinator transactionCoordinator,
			IColumnSameAsFKTableService columnSameAsFKTableService,
			IApiColumnSameAsFKTableServerModelMapper columnSameAsFKTableModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.ColumnSameAsFKTableService = columnSameAsFKTableService;
			this.ColumnSameAsFKTableModelMapper = columnSameAsFKTableModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiColumnSameAsFKTableServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiColumnSameAsFKTableServerResponseModel> response = await this.ColumnSameAsFKTableService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiColumnSameAsFKTableServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiColumnSameAsFKTableServerResponseModel response = await this.ColumnSameAsFKTableService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiColumnSameAsFKTableServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiColumnSameAsFKTableServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiColumnSameAsFKTableServerResponseModel> records = new List<ApiColumnSameAsFKTableServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiColumnSameAsFKTableServerResponseModel> result = await this.ColumnSameAsFKTableService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiColumnSameAsFKTableServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiColumnSameAsFKTableServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiColumnSameAsFKTableServerRequestModel model)
		{
			CreateResponse<ApiColumnSameAsFKTableServerResponseModel> result = await this.ColumnSameAsFKTableService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/ColumnSameAsFKTables/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiColumnSameAsFKTableServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiColumnSameAsFKTableServerRequestModel> patch)
		{
			ApiColumnSameAsFKTableServerResponseModel record = await this.ColumnSameAsFKTableService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiColumnSameAsFKTableServerRequestModel model = await this.PatchModel(id, patch) as ApiColumnSameAsFKTableServerRequestModel;

				UpdateResponse<ApiColumnSameAsFKTableServerResponseModel> result = await this.ColumnSameAsFKTableService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiColumnSameAsFKTableServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiColumnSameAsFKTableServerRequestModel model)
		{
			ApiColumnSameAsFKTableServerRequestModel request = await this.PatchModel(id, this.ColumnSameAsFKTableModelMapper.CreatePatch(model)) as ApiColumnSameAsFKTableServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiColumnSameAsFKTableServerResponseModel> result = await this.ColumnSameAsFKTableService.Update(id, request);

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
			ActionResponse result = await this.ColumnSameAsFKTableService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiColumnSameAsFKTableServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiColumnSameAsFKTableServerRequestModel> patch)
		{
			var record = await this.ColumnSameAsFKTableService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiColumnSameAsFKTableServerRequestModel request = this.ColumnSameAsFKTableModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>07cbbba809b56be5a7fb730c93277f1a</Hash>
</Codenesium>*/