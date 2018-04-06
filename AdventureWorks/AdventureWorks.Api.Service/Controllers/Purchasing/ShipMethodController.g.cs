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
	public abstract class AbstractShipMethodsController: AbstractEntityFrameworkApiController
	{
		protected IShipMethodRepository _shipMethodRepository;
		protected IShipMethodModelValidator _shipMethodModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractShipMethodsController(
			ILogger<AbstractShipMethodsController> logger,
			ApplicationContext context,
			IShipMethodRepository shipMethodRepository,
			IShipMethodModelValidator shipMethodModelValidator
			) : base(logger,context)
		{
			this._shipMethodRepository = shipMethodRepository;
			this._shipMethodModelValidator = shipMethodModelValidator;
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
		[ShipMethodFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._shipMethodRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ShipMethodFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._shipMethodRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ShipMethodFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ShipMethodModel model)
		{
			this._shipMethodModelValidator.CreateMode();
			var validationResult = this._shipMethodModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._shipMethodRepository.Create(model.Name,
				                                           model.ShipBase,
				                                           model.ShipRate,
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
		[ShipMethodFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<ShipMethodModel> models)
		{
			this._shipMethodModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._shipMethodModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._shipMethodRepository.Create(model.Name,
				                                  model.ShipBase,
				                                  model.ShipRate,
				                                  model.Rowguid,
				                                  model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ShipMethodFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int ShipMethodID,ShipMethodModel model)
		{
			this._shipMethodModelValidator.UpdateMode();
			var validationResult = this._shipMethodModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._shipMethodRepository.Update(ShipMethodID,  model.Name,
				                                  model.ShipBase,
				                                  model.ShipRate,
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
		[ShipMethodFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._shipMethodRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>143bc69698d66bd314cfdc63ef102015</Hash>
</Codenesium>*/