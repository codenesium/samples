using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
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

namespace AdventureWorksNS.Api.Web
{
	public abstract class AbstractScrapReasonController : AbstractApiController
	{
		protected IScrapReasonService ScrapReasonService { get; private set; }

		protected IApiScrapReasonServerModelMapper ScrapReasonModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractScrapReasonController(
			ApiSettings settings,
			ILogger<AbstractScrapReasonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IScrapReasonService scrapReasonService,
			IApiScrapReasonServerModelMapper scrapReasonModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.ScrapReasonService = scrapReasonService;
			this.ScrapReasonModelMapper = scrapReasonModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiScrapReasonServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiScrapReasonServerResponseModel> response = await this.ScrapReasonService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiScrapReasonServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(short id)
		{
			ApiScrapReasonServerResponseModel response = await this.ScrapReasonService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiScrapReasonServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiScrapReasonServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiScrapReasonServerResponseModel> records = new List<ApiScrapReasonServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiScrapReasonServerResponseModel> result = await this.ScrapReasonService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiScrapReasonServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiScrapReasonServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiScrapReasonServerRequestModel model)
		{
			CreateResponse<ApiScrapReasonServerResponseModel> result = await this.ScrapReasonService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/ScrapReasons/{result.Record.ScrapReasonID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiScrapReasonServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(short id, [FromBody] JsonPatchDocument<ApiScrapReasonServerRequestModel> patch)
		{
			ApiScrapReasonServerResponseModel record = await this.ScrapReasonService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiScrapReasonServerRequestModel model = await this.PatchModel(id, patch) as ApiScrapReasonServerRequestModel;

				UpdateResponse<ApiScrapReasonServerResponseModel> result = await this.ScrapReasonService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiScrapReasonServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(short id, [FromBody] ApiScrapReasonServerRequestModel model)
		{
			ApiScrapReasonServerRequestModel request = await this.PatchModel(id, this.ScrapReasonModelMapper.CreatePatch(model)) as ApiScrapReasonServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiScrapReasonServerResponseModel> result = await this.ScrapReasonService.Update(id, request);

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

		public virtual async Task<IActionResult> Delete(short id)
		{
			ActionResponse result = await this.ScrapReasonService.Delete(id);

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
		[Route("byName/{name}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiScrapReasonServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByName(string name)
		{
			ApiScrapReasonServerResponseModel response = await this.ScrapReasonService.ByName(name);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpGet]
		[Route("{scrapReasonID}/WorkOrders")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiWorkOrderServerResponseModel>), 200)]
		public async virtual Task<IActionResult> WorkOrdersByScrapReasonID(short scrapReasonID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiWorkOrderServerResponseModel> response = await this.ScrapReasonService.WorkOrdersByScrapReasonID(scrapReasonID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiScrapReasonServerRequestModel> PatchModel(short id, JsonPatchDocument<ApiScrapReasonServerRequestModel> patch)
		{
			var record = await this.ScrapReasonService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiScrapReasonServerRequestModel request = this.ScrapReasonModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>1b4ebabfda68f54dd86cbe8dbfe9a60a</Hash>
</Codenesium>*/