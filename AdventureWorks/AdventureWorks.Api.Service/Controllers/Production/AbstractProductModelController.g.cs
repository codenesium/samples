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
	public abstract class AbstractProductModelsController: AbstractApiController
	{
		protected IProductModelRepository productModelRepository;
		protected IProductModelModelValidator productModelModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductModelsController(
			ILogger<AbstractProductModelsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelRepository productModelRepository,
			IProductModelModelValidator productModelModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.productModelRepository = productModelRepository;
			this.productModelModelValidator = productModelModelValidator;
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

			this.productModelRepository.GetById(id,response);
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

			this.productModelRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this.productModelModelValidator.CreateMode();
			var validationResult = this.productModelModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.productModelRepository.Create(model.Name,
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
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[ProductModelFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ProductModelModel> models)
		{
			this.productModelModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.productModelModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.productModelRepository.Create(model.Name,
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
			this.productModelModelValidator.UpdateMode();
			var validationResult = this.productModelModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.productModelRepository.Update(ProductModelID,  model.Name,
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
			this.productModelRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>c2ca61cb2a5e060d25fb2471459b635c</Hash>
</Codenesium>*/