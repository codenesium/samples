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
	public abstract class AbstractProductSubcategoriesController: AbstractApiController
	{
		protected IProductSubcategoryRepository productSubcategoryRepository;
		protected IProductSubcategoryModelValidator productSubcategoryModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductSubcategoriesController(
			ILogger<AbstractProductSubcategoriesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductSubcategoryRepository productSubcategoryRepository,
			IProductSubcategoryModelValidator productSubcategoryModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.productSubcategoryRepository = productSubcategoryRepository;
			this.productSubcategoryModelValidator = productSubcategoryModelValidator;
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
			Response response = this.productSubcategoryRepository.GetById(id);
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
			Response response = this.productSubcategoryRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
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
			this.productSubcategoryModelValidator.CreateMode();
			var validationResult = this.productSubcategoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.productSubcategoryRepository.Create(model.ProductCategoryID,
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
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[ProductSubcategoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ProductSubcategoryModel> models)
		{
			this.productSubcategoryModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.productSubcategoryModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.productSubcategoryRepository.Create(model.ProductCategoryID,
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
		public virtual IActionResult Update(int id,ProductSubcategoryModel model)
		{
			if(this.productSubcategoryRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.productSubcategoryModelValidator.UpdateMode();
			var validationResult = this.productSubcategoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.productSubcategoryRepository.Update(id,  model.ProductCategoryID,
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
			this.productSubcategoryRepository.Delete(id);
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
			Response response = this.productSubcategoryRepository.GetWhere(x => x.ProductCategoryID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>e3930d8295405d27d77504e759f0d249</Hash>
</Codenesium>*/