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
	public abstract class AbstractSpecialOfferController: AbstractApiController
	{
		protected IBOSpecialOffer specialOfferManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSpecialOfferController(
			ILogger<AbstractSpecialOfferController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSpecialOffer specialOfferManager
			)
			: base(logger, transactionCoordinator)
		{
			this.specialOfferManager = specialOfferManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.specialOfferManager.GetById(id);
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
			ApiResponse response = this.specialOfferManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 400)]
		public virtual async Task<IActionResult> Create([FromBody] SpecialOfferModel model)
		{
			var result = await this.specialOfferManager.Create(model);

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
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<SpecialOfferModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var result = await this.specialOfferManager.Create(model);

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
		public virtual async Task<IActionResult> Update(int id, [FromBody] SpecialOfferModel model)
		{
			var result = await this.specialOfferManager.Update(id, model);

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
			var result = await this.specialOfferManager.Delete(id);

			if(result.Success)
			{
				return this.Ok();
			}
			else
			{
				return this.BadRequest(result);
			}
		}
	}
}

/*<Codenesium>
    <Hash>a6274c79d7b2f175c79dd2b3370d87e3</Hash>
</Codenesium>*/