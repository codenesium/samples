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
	public abstract class AbstractSpecialOffersController: AbstractEntityFrameworkApiController
	{
		protected ISpecialOfferRepository _specialOfferRepository;
		protected ISpecialOfferModelValidator _specialOfferModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSpecialOffersController(
			ILogger<AbstractSpecialOffersController> logger,
			ApplicationContext context,
			ISpecialOfferRepository specialOfferRepository,
			ISpecialOfferModelValidator specialOfferModelValidator
			) : base(logger,context)
		{
			this._specialOfferRepository = specialOfferRepository;
			this._specialOfferModelValidator = specialOfferModelValidator;
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
			Response response = new Response();

			this._specialOfferRepository.GetById(id,response);
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
			Response response = new Response();

			this._specialOfferRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._specialOfferModelValidator.CreateMode();
			var validationResult = this._specialOfferModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._specialOfferRepository.Create(model.Description,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[SpecialOfferFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<SpecialOfferModel> models)
		{
			this._specialOfferModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._specialOfferModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._specialOfferRepository.Create(model.Description,
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
		public virtual IActionResult Update(int specialOfferID,SpecialOfferModel model)
		{
			this._specialOfferModelValidator.UpdateMode();
			var validationResult = this._specialOfferModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._specialOfferRepository.Update(specialOfferID,  model.Description,
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
			this._specialOfferRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>aefcb11321f046f5f987e13d85630a57</Hash>
</Codenesium>*/