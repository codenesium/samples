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
	public abstract class AbstractProductController: AbstractApiController
	{
		protected IBOProduct productManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractProductController(
			ILogger<AbstractProductController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProduct productManager
			)
			: base(logger, transactionCoordinator)
		{
			this.productManager = productManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.productManager.GetById(id);
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
			ApiResponse response = this.productManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 400)]
		public virtual async Task<IActionResult> Create([FromBody] ProductModel model)
		{
			var result = await this.productManager.Create(model);

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
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ProductModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var result = await this.productManager.Create(model);

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
		public virtual async Task<IActionResult> Update(int id, [FromBody] ProductModel model)
		{
			var result = await this.productManager.Update(id, model);

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
			var result = await this.productManager.Delete(id);

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
		[Route("BySizeUnitMeasureCode/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/UnitMeasures/{id}/Products")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult BySizeUnitMeasureCode(string id)
		{
			ApiResponse response = this.productManager.GetWhere(x => x.SizeUnitMeasureCode == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByWeightUnitMeasureCode/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/UnitMeasures/{id}/Products")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByWeightUnitMeasureCode(string id)
		{
			ApiResponse response = this.productManager.GetWhere(x => x.WeightUnitMeasureCode == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByProductSubcategoryID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/ProductSubcategories/{id}/Products")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByProductSubcategoryID(int id)
		{
			ApiResponse response = this.productManager.GetWhere(x => x.ProductSubcategoryID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByProductModelID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/ProductModels/{id}/Products")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByProductModelID(int id)
		{
			ApiResponse response = this.productManager.GetWhere(x => x.ProductModelID == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>d00517b4a159a95e42ca93bbf69269f5</Hash>
</Codenesium>*/