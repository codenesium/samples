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
	public abstract class AbstractPasswordsController: AbstractEntityFrameworkApiController
	{
		protected IPasswordRepository _passwordRepository;
		protected IPasswordModelValidator _passwordModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractPasswordsController(
			ILogger<AbstractPasswordsController> logger,
			ApplicationContext context,
			IPasswordRepository passwordRepository,
			IPasswordModelValidator passwordModelValidator
			) : base(logger,context)
		{
			this._passwordRepository = passwordRepository;
			this._passwordModelValidator = passwordModelValidator;
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

			this._passwordRepository.GetById(id,response);
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

			this._passwordRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._passwordModelValidator.CreateMode();
			var validationResult = this._passwordModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._passwordRepository.Create(model.PasswordHash,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[PasswordFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<PasswordModel> models)
		{
			this._passwordModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._passwordModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._passwordRepository.Create(model.PasswordHash,
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
		public virtual IActionResult Update(int businessEntityID,PasswordModel model)
		{
			this._passwordModelValidator.UpdateMode();
			var validationResult = this._passwordModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._passwordRepository.Update(businessEntityID,  model.PasswordHash,
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
			this._passwordRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>25af67a02d912b62c7b84cc3cdc9648b</Hash>
</Codenesium>*/