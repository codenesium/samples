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
	public abstract class AbstractShipMethodsController: AbstractApiController
	{
		protected IShipMethodRepository shipMethodRepository;
		protected IShipMethodModelValidator shipMethodModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractShipMethodsController(
			ILogger<AbstractShipMethodsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IShipMethodRepository shipMethodRepository,
			IShipMethodModelValidator shipMethodModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.shipMethodRepository = shipMethodRepository;
			this.shipMethodModelValidator = shipMethodModelValidator;
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
			Response response = this.shipMethodRepository.GetById(id);
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
			Response response = this.shipMethodRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
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
			this.shipMethodModelValidator.CreateMode();
			var validationResult = this.shipMethodModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.shipMethodRepository.Create(model.Name,
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
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[ShipMethodFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ShipMethodModel> models)
		{
			this.shipMethodModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.shipMethodModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.shipMethodRepository.Create(model.Name,
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
		public virtual IActionResult Update(int id,ShipMethodModel model)
		{
			if(this.shipMethodRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.shipMethodModelValidator.UpdateMode();
			var validationResult = this.shipMethodModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.shipMethodRepository.Update(id,  model.Name,
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
			this.shipMethodRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>e1d468c80f9ef9667d4341b581eed853</Hash>
</Codenesium>*/