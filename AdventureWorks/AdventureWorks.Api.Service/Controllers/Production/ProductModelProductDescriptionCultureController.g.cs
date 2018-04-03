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
	public abstract class AbstractProductModelProductDescriptionCulturesController: AbstractEntityFrameworkApiController
	{
		protected IProductModelProductDescriptionCultureRepository _productModelProductDescriptionCultureRepository;
		protected IProductModelProductDescriptionCultureModelValidator _productModelProductDescriptionCultureModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductModelProductDescriptionCulturesController(
			ILogger<AbstractProductModelProductDescriptionCulturesController> logger,
			ApplicationContext context,
			IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository,
			IProductModelProductDescriptionCultureModelValidator productModelProductDescriptionCultureModelValidator
			) : base(logger,context)
		{
			this._productModelProductDescriptionCultureRepository = productModelProductDescriptionCultureRepository;
			this._productModelProductDescriptionCultureModelValidator = productModelProductDescriptionCultureModelValidator;
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
		[ProductModelProductDescriptionCultureFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._productModelProductDescriptionCultureRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductModelProductDescriptionCultureFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._productModelProductDescriptionCultureRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductModelProductDescriptionCultureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ProductModelProductDescriptionCultureModel model)
		{
			this._productModelProductDescriptionCultureModelValidator.CreateMode();
			var validationResult = this._productModelProductDescriptionCultureModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._productModelProductDescriptionCultureRepository.Create(model.ProductDescriptionID,
				                                                                      model.CultureID,
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
		[ProductModelProductDescriptionCultureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<ProductModelProductDescriptionCultureModel> models)
		{
			this._productModelProductDescriptionCultureModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._productModelProductDescriptionCultureModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._productModelProductDescriptionCultureRepository.Create(model.ProductDescriptionID,
				                                                             model.CultureID,
				                                                             model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductModelProductDescriptionCultureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int productModelID,ProductModelProductDescriptionCultureModel model)
		{
			this._productModelProductDescriptionCultureModelValidator.UpdateMode();
			var validationResult = this._productModelProductDescriptionCultureModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._productModelProductDescriptionCultureRepository.Update(productModelID,  model.ProductDescriptionID,
				                                                             model.CultureID,
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
		[ProductModelProductDescriptionCultureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._productModelProductDescriptionCultureRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>a9fdec6f3ec39501605557fa79bd6f1b</Hash>
</Codenesium>*/