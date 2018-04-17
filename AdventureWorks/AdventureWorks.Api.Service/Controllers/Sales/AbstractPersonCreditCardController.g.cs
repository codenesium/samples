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
	public abstract class AbstractPersonCreditCardController: AbstractApiController
	{
		protected IBOPersonCreditCard personCreditCardManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractPersonCreditCardController(
			ILogger<AbstractPersonCreditCardController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPersonCreditCard personCreditCardManager
			)
			: base(logger, transactionCoordinator)
		{
			this.personCreditCardManager = personCreditCardManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.personCreditCardManager.GetById(id);
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
			ApiResponse response = this.personCreditCardManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 400)]
		public virtual async Task<IActionResult> Create([FromBody] PersonCreditCardModel model)
		{
			var result = await this.personCreditCardManager.Create(model);

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
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<PersonCreditCardModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var result = await this.personCreditCardManager.Create(model);

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
		public virtual async Task<IActionResult> Update(int id, [FromBody] PersonCreditCardModel model)
		{
			var result = await this.personCreditCardManager.Update(id, model);

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
			var result = await this.personCreditCardManager.Delete(id);

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
		[Route("ByBusinessEntityID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/People/{id}/PersonCreditCards")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			ApiResponse response = this.personCreditCardManager.GetWhere(x => x.BusinessEntityID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByCreditCardID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/CreditCards/{id}/PersonCreditCards")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByCreditCardID(int id)
		{
			ApiResponse response = this.personCreditCardManager.GetWhere(x => x.CreditCardID == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>962db86d8421f7559044fc5efd06b0bc</Hash>
</Codenesium>*/