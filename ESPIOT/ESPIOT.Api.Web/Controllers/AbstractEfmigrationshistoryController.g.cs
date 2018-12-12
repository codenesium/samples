using Codenesium.Foundation.CommonMVC;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.Services;
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

namespace ESPIOTNS.Api.Web
{
	public abstract class AbstractEfmigrationshistoryController : AbstractApiController
	{
		protected IEfmigrationshistoryService EfmigrationshistoryService { get; private set; }

		protected IApiEfmigrationshistoryServerModelMapper EfmigrationshistoryModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractEfmigrationshistoryController(
			ApiSettings settings,
			ILogger<AbstractEfmigrationshistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEfmigrationshistoryService efmigrationshistoryService,
			IApiEfmigrationshistoryServerModelMapper efmigrationshistoryModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.EfmigrationshistoryService = efmigrationshistoryService;
			this.EfmigrationshistoryModelMapper = efmigrationshistoryModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiEfmigrationshistoryServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiEfmigrationshistoryServerResponseModel> response = await this.EfmigrationshistoryService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiEfmigrationshistoryServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(string id)
		{
			ApiEfmigrationshistoryServerResponseModel response = await this.EfmigrationshistoryService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiEfmigrationshistoryServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiEfmigrationshistoryServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiEfmigrationshistoryServerResponseModel> records = new List<ApiEfmigrationshistoryServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiEfmigrationshistoryServerResponseModel> result = await this.EfmigrationshistoryService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiEfmigrationshistoryServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiEfmigrationshistoryServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiEfmigrationshistoryServerRequestModel model)
		{
			CreateResponse<ApiEfmigrationshistoryServerResponseModel> result = await this.EfmigrationshistoryService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Efmigrationshistories/{result.Record.MigrationId}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiEfmigrationshistoryServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiEfmigrationshistoryServerRequestModel> patch)
		{
			ApiEfmigrationshistoryServerResponseModel record = await this.EfmigrationshistoryService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiEfmigrationshistoryServerRequestModel model = await this.PatchModel(id, patch) as ApiEfmigrationshistoryServerRequestModel;

				UpdateResponse<ApiEfmigrationshistoryServerResponseModel> result = await this.EfmigrationshistoryService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiEfmigrationshistoryServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(string id, [FromBody] ApiEfmigrationshistoryServerRequestModel model)
		{
			ApiEfmigrationshistoryServerRequestModel request = await this.PatchModel(id, this.EfmigrationshistoryModelMapper.CreatePatch(model)) as ApiEfmigrationshistoryServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiEfmigrationshistoryServerResponseModel> result = await this.EfmigrationshistoryService.Update(id, request);

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

		public virtual async Task<IActionResult> Delete(string id)
		{
			ActionResponse result = await this.EfmigrationshistoryService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiEfmigrationshistoryServerRequestModel> PatchModel(string id, JsonPatchDocument<ApiEfmigrationshistoryServerRequestModel> patch)
		{
			var record = await this.EfmigrationshistoryService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiEfmigrationshistoryServerRequestModel request = this.EfmigrationshistoryModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>73fc87a05e71edf8f43c068c54dbe43a</Hash>
</Codenesium>*/