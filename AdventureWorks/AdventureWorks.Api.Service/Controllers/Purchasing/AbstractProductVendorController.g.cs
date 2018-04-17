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
	public abstract class AbstractProductVendorController: AbstractApiController
	{
		protected IBOProductVendor productVendorManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractProductVendorController(
			ILogger<AbstractProductVendorController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductVendor productVendorManager
			)
			: base(logger, transactionCoordinator)
		{
			this.productVendorManager = productVendorManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.productVendorManager.GetById(id);
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
			ApiResponse response = this.productVendorManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 400)]
		public virtual async Task<IActionResult> Create([FromBody] ProductVendorModel model)
		{
			var result = await this.productVendorManager.Create(model);

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
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ProductVendorModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var result = await this.productVendorManager.Create(model);

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
		public virtual async Task<IActionResult> Update(int id, [FromBody] ProductVendorModel model)
		{
			var result = await this.productVendorManager.Update(id, model);

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
			var result = await this.productVendorManager.Delete(id);

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
		[Route("ByProductID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/ProductVendors")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			ApiResponse response = this.productVendorManager.GetWhere(x => x.ProductID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Vendors/{id}/ProductVendors")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			ApiResponse response = this.productVendorManager.GetWhere(x => x.BusinessEntityID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByUnitMeasureCode/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/UnitMeasures/{id}/ProductVendors")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByUnitMeasureCode(string id)
		{
			ApiResponse response = this.productVendorManager.GetWhere(x => x.UnitMeasureCode == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>d8d715734f914bd6d271ee4efb3dd38f</Hash>
</Codenesium>*/