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
	public abstract class AbstractBusinessEntityContactsController: AbstractApiController
	{
		protected IBusinessEntityContactRepository businessEntityContactRepository;
		protected IBusinessEntityContactModelValidator businessEntityContactModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractBusinessEntityContactsController(
			ILogger<AbstractBusinessEntityContactsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityContactRepository businessEntityContactRepository,
			IBusinessEntityContactModelValidator businessEntityContactModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.businessEntityContactRepository = businessEntityContactRepository;
			this.businessEntityContactModelValidator = businessEntityContactModelValidator;
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
		[BusinessEntityContactFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.businessEntityContactRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[BusinessEntityContactFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.businessEntityContactRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[BusinessEntityContactFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(BusinessEntityContactModel model)
		{
			this.businessEntityContactModelValidator.CreateMode();
			var validationResult = this.businessEntityContactModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.businessEntityContactRepository.Create(model.PersonID,
				                                                     model.ContactTypeID,
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
		[BusinessEntityContactFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<BusinessEntityContactModel> models)
		{
			this.businessEntityContactModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.businessEntityContactModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.businessEntityContactRepository.Create(model.PersonID,
				                                            model.ContactTypeID,
				                                            model.Rowguid,
				                                            model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[BusinessEntityContactFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,BusinessEntityContactModel model)
		{
			if(this.businessEntityContactRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.businessEntityContactModelValidator.UpdateMode();
			var validationResult = this.businessEntityContactModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.businessEntityContactRepository.Update(id,  model.PersonID,
				                                            model.ContactTypeID,
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
		[BusinessEntityContactFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.businessEntityContactRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[BusinessEntityContactFilter]
		[ReadOnlyFilter]
		[Route("~/api/BusinessEntities/{id}/BusinessEntityContacts")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			Response response = this.businessEntityContactRepository.GetWhere(x => x.BusinessEntityID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByPersonID/{id}")]
		[BusinessEntityContactFilter]
		[ReadOnlyFilter]
		[Route("~/api/People/{id}/BusinessEntityContacts")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByPersonID(int id)
		{
			Response response = this.businessEntityContactRepository.GetWhere(x => x.PersonID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByContactTypeID/{id}")]
		[BusinessEntityContactFilter]
		[ReadOnlyFilter]
		[Route("~/api/ContactTypes/{id}/BusinessEntityContacts")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByContactTypeID(int id)
		{
			Response response = this.businessEntityContactRepository.GetWhere(x => x.ContactTypeID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>9df83bae5141767ba1f598d10b4d0852</Hash>
</Codenesium>*/