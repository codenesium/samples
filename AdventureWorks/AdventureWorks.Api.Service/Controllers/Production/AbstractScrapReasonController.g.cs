using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractScrapReasonsController: AbstractApiController
	{
		protected IScrapReasonRepository scrapReasonRepository;
		protected IScrapReasonModelValidator scrapReasonModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractScrapReasonsController(
			ILogger<AbstractScrapReasonsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IScrapReasonRepository scrapReasonRepository,
			IScrapReasonModelValidator scrapReasonModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.scrapReasonRepository = scrapReasonRepository;
			this.scrapReasonModelValidator = scrapReasonModelValidator;
		}

		protected void AddErrors(ValidationResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}
		}

		[HttpGet]
		[Route("{id}")]
		[ScrapReasonFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(short id)
		{
			Response response = new Response();

			this.scrapReasonRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ScrapReasonFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.scrapReasonRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ScrapReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ScrapReasonModel model)
		{
			this.scrapReasonModelValidator.CreateMode();
			var validationResult = this.scrapReasonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.scrapReasonRepository.Create(model.Name,
				                                           model.ModifiedDate);
				return Ok(id);
			}
			else
			{
				AddErrors(validationResult);
				return BadRequest(this.ModelState);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[ScrapReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ScrapReasonModel> models)
		{
			this.scrapReasonModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.scrapReasonModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.scrapReasonRepository.Create(model.Name,
				                                  model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ScrapReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(short ScrapReasonID,ScrapReasonModel model)
		{
			this.scrapReasonModelValidator.UpdateMode();
			var validationResult = this.scrapReasonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.scrapReasonRepository.Update(ScrapReasonID,  model.Name,
				                                  model.ModifiedDate);
				return Ok();
			}
			else
			{
				AddErrors(validationResult);
				return BadRequest(this.ModelState);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[ModelValidateFilter]
		[ScrapReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(short id)
		{
			this.scrapReasonRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>489331d85e6cdcae577c896b2f76d6e9</Hash>
</Codenesium>*/