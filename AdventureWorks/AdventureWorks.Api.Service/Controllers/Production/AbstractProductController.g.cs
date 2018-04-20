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
	public abstract class AbstractProductController: AbstractApiController
	{
		protected IBOProduct productManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractProductController(
			ServiceSettings settings,
			ILogger<AbstractProductController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProduct productManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.productManager = productManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(ApiResponse), 404)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.productManager.GetById(id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(ApiResponse), 404)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.productManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ProductModel model)
		{
			var result = await this.productManager.Create(model);

			if(result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Id.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.settings.ExternalBaseUrl}/api/products/{result.Id.ToString()}");
				return this.Ok(result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ProductModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			foreach (var model in models)
			{
				var result = await this.productManager.Create(model);

				if(!result.Success)
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			return this.NoContent();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ProductModel model)
		{
			var result = await this.productManager.Update(id, model);

			if(result.Success)
			{
				return this.NoContent();
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
			var result = await this.productManager.Delete(id);

			if(result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("BySizeUnitMeasureCode/{id}")]
		[ReadOnly]
		[Route("~/api/UnitMeasures/{id}/Products")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult BySizeUnitMeasureCode(string id)
		{
			ApiResponse response = this.productManager.GetWhere(x => x.SizeUnitMeasureCode == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByWeightUnitMeasureCode/{id}")]
		[ReadOnly]
		[Route("~/api/UnitMeasures/{id}/Products")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByWeightUnitMeasureCode(string id)
		{
			ApiResponse response = this.productManager.GetWhere(x => x.WeightUnitMeasureCode == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByProductSubcategoryID/{id}")]
		[ReadOnly]
		[Route("~/api/ProductSubcategories/{id}/Products")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByProductSubcategoryID(int id)
		{
			ApiResponse response = this.productManager.GetWhere(x => x.ProductSubcategoryID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByProductModelID/{id}")]
		[ReadOnly]
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
    <Hash>91d02b2d4c072ea85f5b4802ecbacf10</Hash>
</Codenesium>*/