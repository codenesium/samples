using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractCustomerController: AbstractApiController
	{
		protected IBOCustomer customerManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractCustomerController(
			ILogger<AbstractCustomerController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCustomer customerManager
			)
			: base(logger, transactionCoordinator)
		{
			this.customerManager = customerManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.customerManager.GetById(id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.customerManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 400)]
		public virtual async Task<IActionResult> Create([FromBody] CustomerModel model)
		{
			var result = await this.customerManager.Create(model);

			if(result.Success)
			{
				return this.Ok(result);
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<CustomerModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var result = await this.customerManager.Create(model);

				if(!result.Success)
				{
					return this.BadRequest(result);
				}
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] CustomerModel model)
		{
			var result = await this.customerManager.Update(id, model);

			if(result.Success)
			{
				return this.Ok();
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			var result = await this.customerManager.Delete(id);

			if(result.Success)
			{
				return this.Ok();
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpGet]
		[Route("ByPersonID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/People/{id}/Customers")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByPersonID(int id)
		{
			ApiResponse response = this.customerManager.GetWhere(x => x.PersonID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByStoreID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Stores/{id}/Customers")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByStoreID(int id)
		{
			ApiResponse response = this.customerManager.GetWhere(x => x.StoreID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByTerritoryID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/SalesTerritories/{id}/Customers")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByTerritoryID(int id)
		{
			ApiResponse response = this.customerManager.GetWhere(x => x.TerritoryID == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>14129ac3ce0641bd1bd5daa3940f06c1</Hash>
</Codenesium>*/