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
	public abstract class AbstractBusinessEntitiesController: AbstractApiController
	{
		protected IBusinessEntityRepository businessEntityRepository;
		protected IBusinessEntityModelValidator businessEntityModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractBusinessEntitiesController(
			ILogger<AbstractBusinessEntitiesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityRepository businessEntityRepository,
			IBusinessEntityModelValidator businessEntityModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.businessEntityRepository = businessEntityRepository;
			this.businessEntityModelValidator = businessEntityModelValidator;
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
		[BusinessEntityFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.businessEntityRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[BusinessEntityFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.businessEntityRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[BusinessEntityFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(BusinessEntityModel model)
		{
			this.businessEntityModelValidator.CreateMode();
			var validationResult = this.businessEntityModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.businessEntityRepository.Create(model.Rowguid,
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
		[BusinessEntityFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<BusinessEntityModel> models)
		{
			this.businessEntityModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.businessEntityModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.businessEntityRepository.Create(model.Rowguid,
				                                     model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[BusinessEntityFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int BusinessEntityID,BusinessEntityModel model)
		{
			this.businessEntityModelValidator.UpdateMode();
			var validationResult = this.businessEntityModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.businessEntityRepository.Update(BusinessEntityID,  model.Rowguid,
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
		[BusinessEntityFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.businessEntityRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>ad5ea9cc7c90ad976540d02c3dc6eae8</Hash>
</Codenesium>*/