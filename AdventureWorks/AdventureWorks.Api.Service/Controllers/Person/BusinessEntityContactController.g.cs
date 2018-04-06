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
	public abstract class AbstractBusinessEntityContactsController: AbstractEntityFrameworkApiController
	{
		protected IBusinessEntityContactRepository _businessEntityContactRepository;
		protected IBusinessEntityContactModelValidator _businessEntityContactModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractBusinessEntityContactsController(
			ILogger<AbstractBusinessEntityContactsController> logger,
			ApplicationContext context,
			IBusinessEntityContactRepository businessEntityContactRepository,
			IBusinessEntityContactModelValidator businessEntityContactModelValidator
			) : base(logger,context)
		{
			this._businessEntityContactRepository = businessEntityContactRepository;
			this._businessEntityContactModelValidator = businessEntityContactModelValidator;
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
			Response response = new Response();

			this._businessEntityContactRepository.GetById(id,response);
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
			Response response = new Response();

			this._businessEntityContactRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._businessEntityContactModelValidator.CreateMode();
			var validationResult = this._businessEntityContactModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._businessEntityContactRepository.Create(model.PersonID,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[BusinessEntityContactFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<BusinessEntityContactModel> models)
		{
			this._businessEntityContactModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._businessEntityContactModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._businessEntityContactRepository.Create(model.PersonID,
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
		public virtual IActionResult Update(int BusinessEntityID,BusinessEntityContactModel model)
		{
			this._businessEntityContactModelValidator.UpdateMode();
			var validationResult = this._businessEntityContactModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._businessEntityContactRepository.Update(BusinessEntityID,  model.PersonID,
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
			this._businessEntityContactRepository.Delete(id);
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
			var response = new Response();

			this._businessEntityContactRepository.GetWhere(x => x.BusinessEntityID == id, response);
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
			var response = new Response();

			this._businessEntityContactRepository.GetWhere(x => x.PersonID == id, response);
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
			var response = new Response();

			this._businessEntityContactRepository.GetWhere(x => x.ContactTypeID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>f4d95dc4a7ba503bf390d62a59f4fe40</Hash>
</Codenesium>*/