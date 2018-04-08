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
	public abstract class AbstractProductCategoriesController: AbstractApiController
	{
		protected IProductCategoryRepository productCategoryRepository;
		protected IProductCategoryModelValidator productCategoryModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductCategoriesController(
			ILogger<AbstractProductCategoriesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductCategoryRepository productCategoryRepository,
			IProductCategoryModelValidator productCategoryModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.productCategoryRepository = productCategoryRepository;
			this.productCategoryModelValidator = productCategoryModelValidator;
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
		[ProductCategoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.productCategoryRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductCategoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.productCategoryRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductCategoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ProductCategoryModel model)
		{
			this.productCategoryModelValidator.CreateMode();
			var validationResult = this.productCategoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.productCategoryRepository.Create(model.Name,
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
		[ProductCategoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ProductCategoryModel> models)
		{
			this.productCategoryModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.productCategoryModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.productCategoryRepository.Create(model.Name,
				                                      model.Rowguid,
				                                      model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductCategoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int ProductCategoryID,ProductCategoryModel model)
		{
			this.productCategoryModelValidator.UpdateMode();
			var validationResult = this.productCategoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.productCategoryRepository.Update(ProductCategoryID,  model.Name,
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
		[ProductCategoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.productCategoryRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>21d054fbe0889c74c2712b383a394ff8</Hash>
</Codenesium>*/