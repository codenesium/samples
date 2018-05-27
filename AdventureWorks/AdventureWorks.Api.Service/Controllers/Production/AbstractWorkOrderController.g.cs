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
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractWorkOrderController: AbstractApiController
	{
		protected IBOWorkOrder workOrderManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractWorkOrderController(
			ServiceSettings settings,
			ILogger<AbstractWorkOrderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOWorkOrder workOrderManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.workOrderManager = workOrderManager;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiWorkOrderResponseModel>), 200)]
		public async virtual Task<IActionResult> All()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiWorkOrderResponseModel> response = await this.workOrderManager.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiWorkOrderResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiWorkOrderResponseModel response = await this.workOrderManager.Get(id);

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
			CreateResponse<ApiWorkOrderResponseModel> result = await this.workOrderManager.Create(model);

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
				CreateResponse<ApiWorkOrderResponseModel> result = await this.workOrderManager.Create(model);

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
		[ProducesResponseType(typeof(DTOWorkOrder), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiWorkOrderRequestModel model)
		{
			try
			{
				ActionResponse result = await this.workOrderManager.Update(id, model);

				if (result.Success)
				{
					ApiWorkOrderResponseModel response = await this.workOrderManager.Get(id);

					return this.Ok(response);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
			catch(RecordNotFoundException)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.workOrderManager.Delete(id);

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
			List<ApiWorkOrderResponseModel> response = await this.workOrderManager.GetProductID(productID);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("getScrapReasonID/{scrapReasonID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiWorkOrderResponseModel>), 200)]
		public async virtual Task<IActionResult> GetScrapReasonID(Nullable<short> scrapReasonID)
		{
			List<ApiWorkOrderResponseModel> response = await this.workOrderManager.GetScrapReasonID(scrapReasonID);

			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>ded1496eea26900813b429e3f4f67b8f</Hash>
</Codenesium>*/