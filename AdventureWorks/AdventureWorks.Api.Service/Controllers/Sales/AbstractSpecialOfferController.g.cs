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
	public abstract class AbstractSpecialOffersController: AbstractApiController
	{
		protected ISpecialOfferRepository specialOfferRepository;
		protected ISpecialOfferModelValidator specialOfferModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSpecialOffersController(
			ILogger<AbstractSpecialOffersController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpecialOfferRepository specialOfferRepository,
			ISpecialOfferModelValidator specialOfferModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.specialOfferRepository = specialOfferRepository;
			this.specialOfferModelValidator = specialOfferModelValidator;
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
		[SpecialOfferFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.specialOfferRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SpecialOfferFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.specialOfferRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SpecialOfferFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(SpecialOfferModel model)
		{
			this.specialOfferModelValidator.CreateMode();
			var validationResult = this.specialOfferModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.specialOfferRepository.Create(model.Description,
				                                            model.DiscountPct,
				                                            model.Type,
				                                            model.Category,
				                                            model.StartDate,
				                                            model.EndDate,
				                                            model.MinQty,
				                                            model.MaxQty,
				                                            model.Rowguid,
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
		[SpecialOfferFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<SpecialOfferModel> models)
		{
			this.specialOfferModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.specialOfferModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.specialOfferRepository.Create(model.Description,
				                                   model.DiscountPct,
				                                   model.Type,
				                                   model.Category,
				                                   model.StartDate,
				                                   model.EndDate,
				                                   model.MinQty,
				                                   model.MaxQty,
				                                   model.Rowguid,
				                                   model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SpecialOfferFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,SpecialOfferModel model)
		{
			if(this.specialOfferRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.specialOfferModelValidator.UpdateMode();
			var validationResult = this.specialOfferModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.specialOfferRepository.Update(id,  model.Description,
				                                   model.DiscountPct,
				                                   model.Type,
				                                   model.Category,
				                                   model.StartDate,
				                                   model.EndDate,
				                                   model.MinQty,
				                                   model.MaxQty,
				                                   model.Rowguid,
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
		[SpecialOfferFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.specialOfferRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>80af2cefd1fc3a1428170b46db8d273f</Hash>
</Codenesium>*/