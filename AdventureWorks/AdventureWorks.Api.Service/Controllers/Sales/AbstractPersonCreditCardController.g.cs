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
	public abstract class AbstractPersonCreditCardController: AbstractApiController
	{
		protected IBOPersonCreditCard personCreditCardManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractPersonCreditCardController(
			ServiceSettings settings,
			ILogger<AbstractPersonCreditCardController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPersonCreditCard personCreditCardManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.personCreditCardManager = personCreditCardManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOPersonCreditCard), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Get(int id)
		{
			POCOPersonCreditCard response = this.personCreditCardManager.GetById(id).PersonCreditCards.FirstOrDefault();
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
		[ProducesResponseType(typeof(List<POCOPersonCreditCard>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Search()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.personCreditCardManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.PersonCreditCards);
			}
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOPersonCreditCard), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] PersonCreditCardModel model)
		{
			CreateResponse<int> result = await this.personCreditCardManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Id.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/personCreditCards/{result.Id.ToString()}");
				POCOPersonCreditCard response = this.personCreditCardManager.GetById(result.Id).PersonCreditCards.First();
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
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<PersonCreditCardModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<int> ids = new List<int>();
			foreach (var model in models)
			{
				CreateResponse<int> result = await this.personCreditCardManager.Create(model);

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
		[ProducesResponseType(typeof(POCOPersonCreditCard), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] PersonCreditCardModel model)
		{
			try
			{
				ActionResponse result = await this.personCreditCardManager.Update(id, model);

				if (result.Success)
				{
					POCOPersonCreditCard response = this.personCreditCardManager.GetById(id).PersonCreditCards.First();
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
			ActionResponse result = await this.personCreditCardManager.Delete(id);

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
		[Route("ByBusinessEntityID/{id}")]
		[ReadOnly]
		[Route("~/api/People/{id}/PersonCreditCards")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOPersonCreditCard>), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			ApiResponse response = this.personCreditCardManager.GetWhere(x => x.BusinessEntityID == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.PersonCreditCards);
			}
		}

		[HttpGet]
		[Route("ByCreditCardID/{id}")]
		[ReadOnly]
		[Route("~/api/CreditCards/{id}/PersonCreditCards")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOPersonCreditCard>), 200)]
		public virtual IActionResult ByCreditCardID(int id)
		{
			ApiResponse response = this.personCreditCardManager.GetWhere(x => x.CreditCardID == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.PersonCreditCards);
			}
		}
	}
}

/*<Codenesium>
    <Hash>be5d2e210b64431185be686223758e09</Hash>
</Codenesium>*/