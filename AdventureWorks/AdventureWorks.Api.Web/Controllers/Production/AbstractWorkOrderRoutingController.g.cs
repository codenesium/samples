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
	public abstract class AbstractWorkOrderRoutingController: AbstractApiController
	{
		protected IWorkOrderRoutingService workOrderRoutingService;

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractWorkOrderRoutingController(
			ServiceSettings settings,
			ILogger<AbstractWorkOrderRoutingController> logger,
			ITransactionCoordinator transactionCoordinator,
			IWorkOrderRoutingService workOrderRoutingService
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.workOrderRoutingService = workOrderRoutingService;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiWorkOrderRoutingResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiWorkOrderRoutingResponseModel> response = await this.workOrderRoutingService.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiWorkOrderRoutingResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiWorkOrderRoutingResponseModel response = await this.workOrderRoutingService.Get(id);

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
		[ProducesResponseType(typeof(ApiWorkOrderRoutingResponseModel), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiWorkOrderRoutingRequestModel model)
		{
			CreateResponse<ApiWorkOrderRoutingResponseModel> result = await this.workOrderRoutingService.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.WorkOrderID.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/WorkOrderRoutings/{result.Record.WorkOrderID.ToString()}");
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
		[ProducesResponseType(typeof(List<ApiWorkOrderRoutingResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiWorkOrderRoutingRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiWorkOrderRoutingResponseModel> records = new List<ApiWorkOrderRoutingResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiWorkOrderRoutingResponseModel> result = await this.workOrderRoutingService.Create(model);

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
		[ProducesResponseType(typeof(ApiWorkOrderRoutingResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiWorkOrderRoutingRequestModel model)
		{
			ActionResponse result = await this.workOrderRoutingService.Update(id, model);

			if (result.Success)
			{
				ApiWorkOrderRoutingResponseModel response = await this.workOrderRoutingService.Get(id);

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
			ActionResponse result = await this.workOrderRoutingService.Delete(id);

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
		[ProducesResponseType(typeof(List<ApiWorkOrderRoutingResponseModel>), 200)]
		public async virtual Task<IActionResult> GetProductID(int productID)
		{
			List<ApiWorkOrderRoutingResponseModel> response = await this.workOrderRoutingService.GetProductID(productID);

			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>92301230e8262505c30f21ca006532a9</Hash>
</Codenesium>*/