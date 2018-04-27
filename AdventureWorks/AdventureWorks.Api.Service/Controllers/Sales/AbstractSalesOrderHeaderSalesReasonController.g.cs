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
	public abstract class AbstractSalesOrderHeaderSalesReasonController: AbstractApiController
	{
		protected IBOSalesOrderHeaderSalesReason salesOrderHeaderSalesReasonManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSalesOrderHeaderSalesReasonController(
			ServiceSettings settings,
			ILogger<AbstractSalesOrderHeaderSalesReasonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesOrderHeaderSalesReason salesOrderHeaderSalesReasonManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.salesOrderHeaderSalesReasonManager = salesOrderHeaderSalesReasonManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOSalesOrderHeaderSalesReason), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Get(int id)
		{
			POCOSalesOrderHeaderSalesReason response = this.salesOrderHeaderSalesReasonManager.GetById(id).SalesOrderHeaderSalesReasons.FirstOrDefault();
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
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOSalesOrderHeaderSalesReason>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Search()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.salesOrderHeaderSalesReasonManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.SalesOrderHeaderSalesReasons);
			}
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOSalesOrderHeaderSalesReason), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] SalesOrderHeaderSalesReasonModel model)
		{
			CreateResponse<int> result = await this.salesOrderHeaderSalesReasonManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Id.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/SalesOrderHeaderSalesReasons/{result.Id.ToString()}");
				POCOSalesOrderHeaderSalesReason response = this.salesOrderHeaderSalesReasonManager.GetById(result.Id).SalesOrderHeaderSalesReasons.First();
				return this.Ok(response);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(List<int>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<SalesOrderHeaderSalesReasonModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<int> ids = new List<int>();
			foreach (var model in models)
			{
				CreateResponse<int> result = await this.salesOrderHeaderSalesReasonManager.Create(model);

				if(result.Success)
				{
					ids.Add(result.Id);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			return this.Ok(ids);
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOSalesOrderHeaderSalesReason), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] SalesOrderHeaderSalesReasonModel model)
		{
			try
			{
				ActionResponse result = await this.salesOrderHeaderSalesReasonManager.Update(id, model);

				if (result.Success)
				{
					POCOSalesOrderHeaderSalesReason response = this.salesOrderHeaderSalesReasonManager.GetById(id).SalesOrderHeaderSalesReasons.First();
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
			ActionResponse result = await this.salesOrderHeaderSalesReasonManager.Delete(id);

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
		[Route("BySalesOrderID/{id}")]
		[ReadOnly]
		[Route("~/api/SalesOrderHeaders/{id}/SalesOrderHeaderSalesReasons")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOSalesOrderHeaderSalesReason>), 200)]
		public virtual IActionResult BySalesOrderID(int id)
		{
			ApiResponse response = this.salesOrderHeaderSalesReasonManager.GetWhere(x => x.SalesOrderID == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.SalesOrderHeaderSalesReasons);
			}
		}

		[HttpGet]
		[Route("BySalesReasonID/{id}")]
		[ReadOnly]
		[Route("~/api/SalesReasons/{id}/SalesOrderHeaderSalesReasons")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOSalesOrderHeaderSalesReason>), 200)]
		public virtual IActionResult BySalesReasonID(int id)
		{
			ApiResponse response = this.salesOrderHeaderSalesReasonManager.GetWhere(x => x.SalesReasonID == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.SalesOrderHeaderSalesReasons);
			}
		}
	}
}

/*<Codenesium>
    <Hash>d7fc01d951e7c678febbc6cb69fb1d91</Hash>
</Codenesium>*/