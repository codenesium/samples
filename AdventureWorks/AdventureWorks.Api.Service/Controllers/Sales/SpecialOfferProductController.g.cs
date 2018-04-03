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
	public abstract class AbstractSpecialOfferProductsController: AbstractEntityFrameworkApiController
	{
		protected ISpecialOfferProductRepository _specialOfferProductRepository;
		protected ISpecialOfferProductModelValidator _specialOfferProductModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSpecialOfferProductsController(
			ILogger<AbstractSpecialOfferProductsController> logger,
			ApplicationContext context,
			ISpecialOfferProductRepository specialOfferProductRepository,
			ISpecialOfferProductModelValidator specialOfferProductModelValidator
			) : base(logger,context)
		{
			this._specialOfferProductRepository = specialOfferProductRepository;
			this._specialOfferProductModelValidator = specialOfferProductModelValidator;
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
		[SpecialOfferProductFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._specialOfferProductRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SpecialOfferProductFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._specialOfferProductRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SpecialOfferProductFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(SpecialOfferProductModel model)
		{
			this._specialOfferProductModelValidator.CreateMode();
			var validationResult = this._specialOfferProductModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._specialOfferProductRepository.Create(model.ProductID,
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
		[SpecialOfferProductFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<SpecialOfferProductModel> models)
		{
			this._specialOfferProductModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._specialOfferProductModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._specialOfferProductRepository.Create(model.ProductID,
				                                           model.Rowguid,
				                                           model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SpecialOfferProductFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int specialOfferID,SpecialOfferProductModel model)
		{
			this._specialOfferProductModelValidator.UpdateMode();
			var validationResult = this._specialOfferProductModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._specialOfferProductRepository.Update(specialOfferID,  model.ProductID,
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
		[SpecialOfferProductFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._specialOfferProductRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>f3d037e95837e221c5fd5b3891de5529</Hash>
</Codenesium>*/