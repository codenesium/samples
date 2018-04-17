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
	public abstract class AbstractProductModelIllustrationController: AbstractApiController
	{
		protected IBOProductModelIllustration productModelIllustrationManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractProductModelIllustrationController(
			ILogger<AbstractProductModelIllustrationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductModelIllustration productModelIllustrationManager
			)
			: base(logger, transactionCoordinator)
		{
			this.productModelIllustrationManager = productModelIllustrationManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.productModelIllustrationManager.GetById(id);
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
			ApiResponse response = this.productModelIllustrationManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 400)]
		public virtual async Task<IActionResult> Create([FromBody] ProductModelIllustrationModel model)
		{
			var result = await this.productModelIllustrationManager.Create(model);

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
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ProductModelIllustrationModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var result = await this.productModelIllustrationManager.Create(model);

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
		public virtual async Task<IActionResult> Update(int id, [FromBody] ProductModelIllustrationModel model)
		{
			var result = await this.productModelIllustrationManager.Update(id, model);

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
			var result = await this.productModelIllustrationManager.Delete(id);

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
		[Route("ByProductModelID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/ProductModels/{id}/ProductModelIllustrations")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByProductModelID(int id)
		{
			ApiResponse response = this.productModelIllustrationManager.GetWhere(x => x.ProductModelID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByIllustrationID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Illustrations/{id}/ProductModelIllustrations")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByIllustrationID(int id)
		{
			ApiResponse response = this.productModelIllustrationManager.GetWhere(x => x.IllustrationID == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>9c6dddc6c221578784cbe7b98e5654cc</Hash>
</Codenesium>*/