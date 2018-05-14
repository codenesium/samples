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
	public abstract class AbstractSalesOrderHeaderController: AbstractApiController
	{
		protected IBOSalesOrderHeader salesOrderHeaderManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSalesOrderHeaderController(
			ServiceSettings settings,
			ILogger<AbstractSalesOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesOrderHeader salesOrderHeaderManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.salesOrderHeaderManager = salesOrderHeaderManager;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOSalesOrderHeader>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult All()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<POCOSalesOrderHeader> response = this.salesOrderHeaderManager.All(query.Offset, query.Limit);

			if (response.Count == 0)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOSalesOrderHeader), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Get(int id)
		{
			POCOSalesOrderHeader response = this.salesOrderHeaderManager.Get(id);
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
		[ProducesResponseType(typeof(POCOSalesOrderHeader), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiSalesOrderHeaderModel model)
		{
			CreateResponse<POCOSalesOrderHeader> result = await this.salesOrderHeaderManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.SalesOrderID.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/SalesOrderHeaders/{result.Record.SalesOrderID.ToString()}");
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
		[ProducesResponseType(typeof(List<POCOSalesOrderHeader>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSalesOrderHeaderModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<POCOSalesOrderHeader> records = new List<POCOSalesOrderHeader>();
			foreach (var model in models)
			{
				CreateResponse<POCOSalesOrderHeader> result = await this.salesOrderHeaderManager.Create(model);

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
		[ProducesResponseType(typeof(POCOSalesOrderHeader), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSalesOrderHeaderModel model)
		{
			try
			{
				ActionResponse result = await this.salesOrderHeaderManager.Update(id, model);

				if (result.Success)
				{
					POCOSalesOrderHeader response = this.salesOrderHeaderManager.Get(id);
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
			ActionResponse result = await this.salesOrderHeaderManager.Delete(id);

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
		[Route("getSalesOrderNumber/{salesOrderNumber}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOSalesOrderHeader), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult GetSalesOrderNumber(string salesOrderNumber)
		{
			POCOSalesOrderHeader response = this.salesOrderHeaderManager.GetSalesOrderNumber(salesOrderNumber);
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
		[Route("getCustomerID/{customerID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOSalesOrderHeader>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult GetCustomerID(int customerID)
		{
			List<POCOSalesOrderHeader> response = this.salesOrderHeaderManager.GetCustomerID(customerID);
			if (response.Count == 0)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpGet]
		[Route("getSalesPersonID/{salesPersonID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOSalesOrderHeader>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult GetSalesPersonID(Nullable<int> salesPersonID)
		{
			List<POCOSalesOrderHeader> response = this.salesOrderHeaderManager.GetSalesPersonID(salesPersonID);
			if (response.Count == 0)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}
	}
}

/*<Codenesium>
    <Hash>4632fd5a5bdf3763ce2e1fdc32d98810</Hash>
</Codenesium>*/