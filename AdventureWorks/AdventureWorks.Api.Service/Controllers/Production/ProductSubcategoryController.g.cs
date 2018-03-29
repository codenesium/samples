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
	public abstract class AbstractProductSubcategoriesController: AbstractEntityFrameworkApiController
	{
		protected IProductSubcategoryRepository _productSubcategoryRepository;
		protected IProductSubcategoryModelValidator _productSubcategoryModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductSubcategoriesController(
			ILogger<AbstractProductSubcategoriesController> logger,
			ApplicationContext context,
			IProductSubcategoryRepository productSubcategoryRepository,
			IProductSubcategoryModelValidator productSubcategoryModelValidator
			) : base(logger,context)
		{
			this._productSubcategoryRepository = productSubcategoryRepository;
			this._productSubcategoryModelValidator = productSubcategoryModelValidator;
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
		[ProductSubcategoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._productSubcategoryRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductSubcategoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._productSubcategoryRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductSubcategoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ProductSubcategoryModel model)
		{
			this._productSubcategoryModelValidator.CreateMode();
			var validationResult = this._productSubcategoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._productSubcategoryRepository.Create(model.ProductCategoryID,
				                                                   model.Name,
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
		[ProductSubcategoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<ProductSubcategoryModel> models)
		{
			this._productSubcategoryModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._productSubcategoryModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._productSubcategoryRepository.Create(model.ProductCategoryID,
				                                          model.Name,
				                                          model.Rowguid,
				                                          model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductSubcategoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int ProductSubcategoryID,ProductSubcategoryModel model)
		{
			this._productSubcategoryModelValidator.UpdateMode();
			var validationResult = this._productSubcategoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._productSubcategoryRepository.Update(ProductSubcategoryID,  model.ProductCategoryID,
				                                          model.Name,
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
		[ProductSubcategoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._productSubcategoryRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByProductCategoryID/{id}")]
		[ProductSubcategoryFilter]
		[ReadOnlyFilter]
		[Route("~/api/ProductCategories/{id}/ProductSubcategories")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductCategoryID(int id)
		{
			var response = new Response();

			this._productSubcategoryRepository.GetWhere(x => x.ProductCategoryID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>87f1a672c5f0096c0dc5ab849b569655</Hash>
</Codenesium>*/