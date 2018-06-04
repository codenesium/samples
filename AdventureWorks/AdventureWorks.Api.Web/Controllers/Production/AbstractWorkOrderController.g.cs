using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	public abstract class AbstractWorkOrderController: AbstractApiController
	{
		protected IWorkOrderService workOrderService;

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractWorkOrderController(
			ServiceSettings settings,
			ILogger<AbstractWorkOrderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IWorkOrderService workOrderService
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.workOrderService = workOrderService;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiWorkOrderResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiWorkOrderResponseModel> response = await this.workOrderService.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiWorkOrderResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiWorkOrderResponseModel response = await this.workOrderService.Get(id);

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
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(ApiWorkOrderResponseModel), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiWorkOrderRequestModel model)
		{
			CreateResponse<ApiWorkOrderResponseModel> result = await this.workOrderService.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.WorkOrderID.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/WorkOrders/{result.Record.WorkOrderID.ToString()}");
				return this.Ok(result.Record);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(List<ApiWorkOrderResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiWorkOrderRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiWorkOrderResponseModel> records = new List<ApiWorkOrderResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiWorkOrderResponseModel> result = await this.workOrderService.Create(model);

				if(result.Success)
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

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(ApiWorkOrderResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiWorkOrderRequestModel model)
		{
			ActionResponse result = await this.workOrderService.Update(id, model);

			if (result.Success)
			{
				ApiWorkOrderResponseModel response = await this.workOrderService.Get(id);

				return this.Ok(response);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.workOrderService.Delete(id);

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
		[Route("getProductID/{productID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiWorkOrderResponseModel>), 200)]
		public async virtual Task<IActionResult> GetProductID(int productID)
		{
			List<ApiWorkOrderResponseModel> response = await this.workOrderService.GetProductID(productID);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("getScrapReasonID/{scrapReasonID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiWorkOrderResponseModel>), 200)]
		public async virtual Task<IActionResult> GetScrapReasonID(Nullable<short> scrapReasonID)
		{
			List<ApiWorkOrderResponseModel> response = await this.workOrderService.GetScrapReasonID(scrapReasonID);

			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>ff79563ca5a89aa2aa286939e556b818</Hash>
</Codenesium>*/