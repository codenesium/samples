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
	public abstract class AbstractSalesReasonsController: AbstractApiController
	{
		protected ISalesReasonRepository salesReasonRepository;
		protected ISalesReasonModelValidator salesReasonModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSalesReasonsController(
			ILogger<AbstractSalesReasonsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesReasonRepository salesReasonRepository,
			ISalesReasonModelValidator salesReasonModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.salesReasonRepository = salesReasonRepository;
			this.salesReasonModelValidator = salesReasonModelValidator;
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
		[SalesReasonFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.salesReasonRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SalesReasonFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.salesReasonRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(SalesReasonModel model)
		{
			this.salesReasonModelValidator.CreateMode();
			var validationResult = this.salesReasonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.salesReasonRepository.Create(model.Name,
				                                           model.ReasonType,
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
		[SalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<SalesReasonModel> models)
		{
			this.salesReasonModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.salesReasonModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.salesReasonRepository.Create(model.Name,
				                                  model.ReasonType,
				                                  model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int SalesReasonID,SalesReasonModel model)
		{
			this.salesReasonModelValidator.UpdateMode();
			var validationResult = this.salesReasonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.salesReasonRepository.Update(SalesReasonID,  model.Name,
				                                  model.ReasonType,
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
		[SalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.salesReasonRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>4b60180330f8f1d632d1924ddd1bc8f0</Hash>
</Codenesium>*/