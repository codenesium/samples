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
	public abstract class AbstractProductDescriptionsController: AbstractApiController
	{
		protected IProductDescriptionRepository productDescriptionRepository;
		protected IProductDescriptionModelValidator productDescriptionModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductDescriptionsController(
			ILogger<AbstractProductDescriptionsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductDescriptionRepository productDescriptionRepository,
			IProductDescriptionModelValidator productDescriptionModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.productDescriptionRepository = productDescriptionRepository;
			this.productDescriptionModelValidator = productDescriptionModelValidator;
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

			this.productDescriptionRepository.GetById(id,response);
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

			this.productDescriptionRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this.productDescriptionModelValidator.CreateMode();
			var validationResult = this.productDescriptionModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.productDescriptionRepository.Create(model.Description,
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
		[ProductDescriptionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ProductDescriptionModel> models)
		{
			this.productDescriptionModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.productDescriptionModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.productDescriptionRepository.Create(model.Description,
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
		public virtual IActionResult Update(int ProductDescriptionID,ProductDescriptionModel model)
		{
			this.productDescriptionModelValidator.UpdateMode();
			var validationResult = this.productDescriptionModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.productDescriptionRepository.Update(ProductDescriptionID,  model.Description,
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
			this.productDescriptionRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>54b6a26045b7ea8e4ed798048e884d1b</Hash>
</Codenesium>*/