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
	public abstract class AbstractPasswordsController: AbstractApiController
	{
		protected IPasswordRepository passwordRepository;
		protected IPasswordModelValidator passwordModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractPasswordsController(
			ILogger<AbstractPasswordsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPasswordRepository passwordRepository,
			IPasswordModelValidator passwordModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.passwordRepository = passwordRepository;
			this.passwordModelValidator = passwordModelValidator;
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
		[PasswordFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.passwordRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[PasswordFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.passwordRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[PasswordFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(PasswordModel model)
		{
			this.passwordModelValidator.CreateMode();
			var validationResult = this.passwordModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.passwordRepository.Create(model.PasswordHash,
				                                        model.PasswordSalt,
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
		[PasswordFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<PasswordModel> models)
		{
			this.passwordModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.passwordModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.passwordRepository.Create(model.PasswordHash,
				                               model.PasswordSalt,
				                               model.Rowguid,
				                               model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[PasswordFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int BusinessEntityID,PasswordModel model)
		{
			this.passwordModelValidator.UpdateMode();
			var validationResult = this.passwordModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.passwordRepository.Update(BusinessEntityID,  model.PasswordHash,
				                               model.PasswordSalt,
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
		[PasswordFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.passwordRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[PasswordFilter]
		[ReadOnlyFilter]
		[Route("~/api/People/{id}/Passwords")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			var response = new Response();

			this.passwordRepository.GetWhere(x => x.BusinessEntityID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>a42c47e6341f7215c2174ef04bc836bf</Hash>
</Codenesium>*/