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
	public abstract class AbstractProductDescriptionsController: AbstractEntityFrameworkApiController
	{
		protected IProductDescriptionRepository _productDescriptionRepository;
		protected IProductDescriptionModelValidator _productDescriptionModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductDescriptionsController(
			ILogger<AbstractProductDescriptionsController> logger,
			ApplicationContext context,
			IProductDescriptionRepository productDescriptionRepository,
			IProductDescriptionModelValidator productDescriptionModelValidator
			) : base(logger,context)
		{
			this._productDescriptionRepository = productDescriptionRepository;
			this._productDescriptionModelValidator = productDescriptionModelValidator;
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
		[ProductDescriptionFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._productDescriptionRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductDescriptionFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._productDescriptionRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductDescriptionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ProductDescriptionModel model)
		{
			this._productDescriptionModelValidator.CreateMode();
			var validationResult = this._productDescriptionModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._productDescriptionRepository.Create(model.Description,
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
		[ProductDescriptionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<ProductDescriptionModel> models)
		{
			this._productDescriptionModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._productDescriptionModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._productDescriptionRepository.Create(model.Description,
				                                          model.Rowguid,
				                                          model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductDescriptionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int productDescriptionID,ProductDescriptionModel model)
		{
			this._productDescriptionModelValidator.UpdateMode();
			var validationResult = this._productDescriptionModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._productDescriptionRepository.Update(productDescriptionID,  model.Description,
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
		[ProductDescriptionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._productDescriptionRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>78770b98385e755bba5df6c430ac8309</Hash>
</Codenesium>*/