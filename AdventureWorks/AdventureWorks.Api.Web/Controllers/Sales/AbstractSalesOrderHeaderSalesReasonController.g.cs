using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
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

namespace AdventureWorksNS.Api.Web
{
	public abstract class AbstractSalesOrderHeaderSalesReasonController : AbstractApiController
	{
		protected ISalesOrderHeaderSalesReasonService SalesOrderHeaderSalesReasonService { get; private set; }

		protected IApiSalesOrderHeaderSalesReasonModelMapper SalesOrderHeaderSalesReasonModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractSalesOrderHeaderSalesReasonController(
			ApiSettings settings,
			ILogger<AbstractSalesOrderHeaderSalesReasonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderHeaderSalesReasonService salesOrderHeaderSalesReasonService,
			IApiSalesOrderHeaderSalesReasonModelMapper salesOrderHeaderSalesReasonModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.SalesOrderHeaderSalesReasonService = salesOrderHeaderSalesReasonService;
			this.SalesOrderHeaderSalesReasonModelMapper = salesOrderHeaderSalesReasonModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderSalesReasonResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiSalesOrderHeaderSalesReasonResponseModel> response = await this.SalesOrderHeaderSalesReasonService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSalesOrderHeaderSalesReasonResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiSalesOrderHeaderSalesReasonResponseModel response = await this.SalesOrderHeaderSalesReasonService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderSalesReasonResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSalesOrderHeaderSalesReasonRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiSalesOrderHeaderSalesReasonResponseModel> records = new List<ApiSalesOrderHeaderSalesReasonResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel> result = await this.SalesOrderHeaderSalesReasonService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiSalesOrderHeaderSalesReasonRequestModel model)
		{
			CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel> result = await this.SalesOrderHeaderSalesReasonService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/SalesOrderHeaderSalesReasons/{result.Record.SalesOrderID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSalesOrderHeaderSalesReasonRequestModel> patch)
		{
			ApiSalesOrderHeaderSalesReasonResponseModel record = await this.SalesOrderHeaderSalesReasonService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiSalesOrderHeaderSalesReasonRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel> result = await this.SalesOrderHeaderSalesReasonService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSalesOrderHeaderSalesReasonRequestModel model)
		{
			ApiSalesOrderHeaderSalesReasonRequestModel request = await this.PatchModel(id, this.SalesOrderHeaderSalesReasonModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel> result = await this.SalesOrderHeaderSalesReasonService.Update(id, request);

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
			ActionResponse result = await this.SalesOrderHeaderSalesReasonService.Delete(id);

			if (result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiSalesOrderHeaderSalesReasonRequestModel> PatchModel(int id, JsonPatchDocument<ApiSalesOrderHeaderSalesReasonRequestModel> patch)
		{
			var record = await this.SalesOrderHeaderSalesReasonService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiSalesOrderHeaderSalesReasonRequestModel request = this.SalesOrderHeaderSalesReasonModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>90215db51c1fe242e192cc14ee793382</Hash>
</Codenesium>*/