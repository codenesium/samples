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
	public abstract class AbstractRowVersionCheckController : AbstractApiController
	{
		protected IRowVersionCheckService RowVersionCheckService { get; private set; }

		protected IApiRowVersionCheckServerModelMapper RowVersionCheckModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractRowVersionCheckController(
			ApiSettings settings,
			ILogger<AbstractRowVersionCheckController> logger,
			ITransactionCoordinator transactionCoordinator,
			IRowVersionCheckService rowVersionCheckService,
			IApiRowVersionCheckServerModelMapper rowVersionCheckModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.RowVersionCheckService = rowVersionCheckService;
			this.RowVersionCheckModelMapper = rowVersionCheckModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiRowVersionCheckServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiRowVersionCheckServerResponseModel> response = await this.RowVersionCheckService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiRowVersionCheckServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiRowVersionCheckServerResponseModel response = await this.RowVersionCheckService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiRowVersionCheckServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiRowVersionCheckServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiRowVersionCheckServerResponseModel> records = new List<ApiRowVersionCheckServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiRowVersionCheckServerResponseModel> result = await this.RowVersionCheckService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiRowVersionCheckServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiRowVersionCheckServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiRowVersionCheckServerRequestModel model)
		{
			CreateResponse<ApiRowVersionCheckServerResponseModel> result = await this.RowVersionCheckService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/RowVersionChecks/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiRowVersionCheckServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiRowVersionCheckServerRequestModel> patch)
		{
			ApiRowVersionCheckServerResponseModel record = await this.RowVersionCheckService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiRowVersionCheckServerRequestModel model = await this.PatchModel(id, patch) as ApiRowVersionCheckServerRequestModel;

				UpdateResponse<ApiRowVersionCheckServerResponseModel> result = await this.RowVersionCheckService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiRowVersionCheckServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiRowVersionCheckServerRequestModel model)
		{
			ApiRowVersionCheckServerRequestModel request = await this.PatchModel(id, this.RowVersionCheckModelMapper.CreatePatch(model)) as ApiRowVersionCheckServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiRowVersionCheckServerResponseModel> result = await this.RowVersionCheckService.Update(id, request);

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
			ActionResponse result = await this.RowVersionCheckService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiRowVersionCheckServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiRowVersionCheckServerRequestModel> patch)
		{
			var record = await this.RowVersionCheckService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiRowVersionCheckServerRequestModel request = this.RowVersionCheckModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>1f48c43568b53ec275afcde3d45469db</Hash>
</Codenesium>*/