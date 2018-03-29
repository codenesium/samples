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
	public abstract class AbstractProductModelsController: AbstractEntityFrameworkApiController
	{
		protected IProductModelRepository _productModelRepository;
		protected IProductModelModelValidator _productModelModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductModelsController(
			ILogger<AbstractProductModelsController> logger,
			ApplicationContext context,
			IProductModelRepository productModelRepository,
			IProductModelModelValidator productModelModelValidator
			) : base(logger,context)
		{
			this._productModelRepository = productModelRepository;
			this._productModelModelValidator = productModelModelValidator;
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
		[ProductModelFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._productModelRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductModelFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._productModelRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductModelFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ProductModelModel model)
		{
			this._productModelModelValidator.CreateMode();
			var validationResult = this._productModelModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._productModelRepository.Create(model.Name,
				                                             model.CatalogDescription,
				                                             model.Instructions,
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
		[ProductModelFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<ProductModelModel> models)
		{
			this._productModelModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._productModelModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._productModelRepository.Create(model.Name,
				                                    model.CatalogDescription,
				                                    model.Instructions,
				                                    model.Rowguid,
				                                    model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductModelFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int ProductModelID,ProductModelModel model)
		{
			this._productModelModelValidator.UpdateMode();
			var validationResult = this._productModelModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._productModelRepository.Update(ProductModelID,  model.Name,
				                                    model.CatalogDescription,
				                                    model.Instructions,
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
		[ProductModelFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._productModelRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>1acbc3a90d7104b67efeb63e1941fa7e</Hash>
</Codenesium>*/