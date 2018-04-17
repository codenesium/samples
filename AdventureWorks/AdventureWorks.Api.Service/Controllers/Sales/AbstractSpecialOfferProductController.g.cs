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
	public abstract class AbstractSpecialOfferProductController: AbstractApiController
	{
		protected IBOSpecialOfferProduct specialOfferProductManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSpecialOfferProductController(
			ILogger<AbstractSpecialOfferProductController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSpecialOfferProduct specialOfferProductManager
			)
			: base(logger, transactionCoordinator)
		{
			this.specialOfferProductManager = specialOfferProductManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.specialOfferProductManager.GetById(id);
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
			ApiResponse response = this.specialOfferProductManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 400)]
		public virtual async Task<IActionResult> Create([FromBody] SpecialOfferProductModel model)
		{
			var result = await this.specialOfferProductManager.Create(model);

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
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<SpecialOfferProductModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var result = await this.specialOfferProductManager.Create(model);

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
		public virtual async Task<IActionResult> Update(int id, [FromBody] SpecialOfferProductModel model)
		{
			var result = await this.specialOfferProductManager.Update(id, model);

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
			var result = await this.specialOfferProductManager.Delete(id);

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
		[Route("BySpecialOfferID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/SpecialOffers/{id}/SpecialOfferProducts")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult BySpecialOfferID(int id)
		{
			ApiResponse response = this.specialOfferProductManager.GetWhere(x => x.SpecialOfferID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByProductID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/SpecialOfferProducts")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			ApiResponse response = this.specialOfferProductManager.GetWhere(x => x.ProductID == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>481af491a2d9298358eadbfc3f7b5774</Hash>
</Codenesium>*/