using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.Service
{
	public abstract class AbstractDeviceActionsController: AbstractApiController
	{
		protected IDeviceActionRepository deviceActionRepository;
		protected IDeviceActionModelValidator deviceActionModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractDeviceActionsController(
			ILogger<AbstractDeviceActionsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeviceActionRepository deviceActionRepository,
			IDeviceActionModelValidator deviceActionModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.deviceActionRepository = deviceActionRepository;
			this.deviceActionModelValidator = deviceActionModelValidator;
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
		[DeviceActionFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.deviceActionRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[DeviceActionFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.deviceActionRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[DeviceActionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(DeviceActionModel model)
		{
			this.deviceActionModelValidator.CreateMode();
			var validationResult = this.deviceActionModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.deviceActionRepository.Create(model.DeviceId,
				                                            model.Name,
				                                            model.@Value);
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
		[DeviceActionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<DeviceActionModel> models)
		{
			this.deviceActionModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.deviceActionModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.deviceActionRepository.Create(model.DeviceId,
				                                   model.Name,
				                                   model.@Value);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[DeviceActionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,DeviceActionModel model)
		{
			if(this.deviceActionRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.deviceActionModelValidator.UpdateMode();
			var validationResult = this.deviceActionModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.deviceActionRepository.Update(id,  model.DeviceId,
				                                   model.Name,
				                                   model.@Value);
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
		[DeviceActionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.deviceActionRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByDeviceId/{id}")]
		[DeviceActionFilter]
		[ReadOnlyFilter]
		[Route("~/api/Devices/{id}/DeviceActions")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByDeviceId(int id)
		{
			Response response = this.deviceActionRepository.GetWhere(x => x.DeviceId == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>d4b0e6201f493d474fb80992b71c63d2</Hash>
</Codenesium>*/