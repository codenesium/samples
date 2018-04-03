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
	public abstract class AbstractProductProductPhotoesController: AbstractEntityFrameworkApiController
	{
		protected IProductProductPhotoRepository _productProductPhotoRepository;
		protected IProductProductPhotoModelValidator _productProductPhotoModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductProductPhotoesController(
			ILogger<AbstractProductProductPhotoesController> logger,
			ApplicationContext context,
			IProductProductPhotoRepository productProductPhotoRepository,
			IProductProductPhotoModelValidator productProductPhotoModelValidator
			) : base(logger,context)
		{
			this._productProductPhotoRepository = productProductPhotoRepository;
			this._productProductPhotoModelValidator = productProductPhotoModelValidator;
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
		[ProductProductPhotoFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._productProductPhotoRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductProductPhotoFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._productProductPhotoRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductProductPhotoFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ProductProductPhotoModel model)
		{
			this._productProductPhotoModelValidator.CreateMode();
			var validationResult = this._productProductPhotoModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._productProductPhotoRepository.Create(model.ProductPhotoID,
				                                                    model.Primary,
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
		[ProductProductPhotoFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<ProductProductPhotoModel> models)
		{
			this._productProductPhotoModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._productProductPhotoModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._productProductPhotoRepository.Create(model.ProductPhotoID,
				                                           model.Primary,
				                                           model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductProductPhotoFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int productID,ProductProductPhotoModel model)
		{
			this._productProductPhotoModelValidator.UpdateMode();
			var validationResult = this._productProductPhotoModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._productProductPhotoRepository.Update(productID,  model.ProductPhotoID,
				                                           model.Primary,
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
		[ProductProductPhotoFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._productProductPhotoRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>2fd3406d143b9c1db77e95d1d80e7bee</Hash>
</Codenesium>*/