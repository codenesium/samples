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
	public abstract class AbstractSalesOrderHeaderController : AbstractApiController
	{
		protected ISalesOrderHeaderService SalesOrderHeaderService { get; private set; }

		protected IApiSalesOrderHeaderModelMapper SalesOrderHeaderModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractSalesOrderHeaderController(
			ApiSettings settings,
			ILogger<AbstractSalesOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderHeaderService salesOrderHeaderService,
			IApiSalesOrderHeaderModelMapper salesOrderHeaderModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.SalesOrderHeaderService = salesOrderHeaderService;
			this.SalesOrderHeaderModelMapper = salesOrderHeaderModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiSalesOrderHeaderResponseModel> response = await this.SalesOrderHeaderService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSalesOrderHeaderResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiSalesOrderHeaderResponseModel response = await this.SalesOrderHeaderService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSalesOrderHeaderRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiSalesOrderHeaderResponseModel> records = new List<ApiSalesOrderHeaderResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiSalesOrderHeaderResponseModel> result = await this.SalesOrderHeaderService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiSalesOrderHeaderResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiSalesOrderHeaderRequestModel model)
		{
			CreateResponse<ApiSalesOrderHeaderResponseModel> result = await this.SalesOrderHeaderService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/SalesOrderHeaders/{result.Record.SalesOrderID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiSalesOrderHeaderResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSalesOrderHeaderRequestModel> patch)
		{
			ApiSalesOrderHeaderResponseModel record = await this.SalesOrderHeaderService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiSalesOrderHeaderRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiSalesOrderHeaderResponseModel> result = await this.SalesOrderHeaderService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiSalesOrderHeaderResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSalesOrderHeaderRequestModel model)
		{
			ApiSalesOrderHeaderRequestModel request = await this.PatchModel(id, this.SalesOrderHeaderModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiSalesOrderHeaderResponseModel> result = await this.SalesOrderHeaderService.Update(id, request);

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
			ActionResponse result = await this.SalesOrderHeaderService.Delete(id);

			if (result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("bySalesOrderNumber/{salesOrderNumber}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSalesOrderHeaderResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> BySalesOrderNumber(string salesOrderNumber)
		{
			ApiSalesOrderHeaderResponseModel response = await this.SalesOrderHeaderService.BySalesOrderNumber(salesOrderNumber);

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
		[Route("byCustomerID/{customerID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderResponseModel>), 200)]
		public async virtual Task<IActionResult> ByCustomerID(int customerID)
		{
			List<ApiSalesOrderHeaderResponseModel> response = await this.SalesOrderHeaderService.ByCustomerID(customerID);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("bySalesPersonID/{salesPersonID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderResponseModel>), 200)]
		public async virtual Task<IActionResult> BySalesPersonID(int? salesPersonID)
		{
			List<ApiSalesOrderHeaderResponseModel> response = await this.SalesOrderHeaderService.BySalesPersonID(salesPersonID);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{salesOrderID}/SalesOrderDetails")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderResponseModel>), 200)]
		public async virtual Task<IActionResult> SalesOrderDetails(int salesOrderID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiSalesOrderDetailResponseModel> response = await this.SalesOrderHeaderService.SalesOrderDetails(salesOrderID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{salesOrderID}/SalesOrderHeaderSalesReasons")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderResponseModel>), 200)]
		public async virtual Task<IActionResult> SalesOrderHeaderSalesReasons(int salesOrderID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiSalesOrderHeaderSalesReasonResponseModel> response = await this.SalesOrderHeaderService.SalesOrderHeaderSalesReasons(salesOrderID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiSalesOrderHeaderRequestModel> PatchModel(int id, JsonPatchDocument<ApiSalesOrderHeaderRequestModel> patch)
		{
			var record = await this.SalesOrderHeaderService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiSalesOrderHeaderRequestModel request = this.SalesOrderHeaderModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>3c10ec25ad04669e2d327149d9a06d3b</Hash>
</Codenesium>*/