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
	public abstract class AbstractDevicesController: AbstractApiController
	{
		protected IDeviceRepository deviceRepository;
		protected IDeviceModelValidator deviceModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractDevicesController(
			ILogger<AbstractDevicesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeviceRepository deviceRepository,
			IDeviceModelValidator deviceModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.deviceRepository = deviceRepository;
			this.deviceModelValidator = deviceModelValidator;
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
		[DeviceFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.deviceRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[DeviceFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.deviceRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[DeviceFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(DeviceModel model)
		{
			this.deviceModelValidator.CreateMode();
			var validationResult = this.deviceModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.deviceRepository.Create(model.PublicId,
				                                      model.Name);
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
		[DeviceFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<DeviceModel> models)
		{
			this.deviceModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.deviceModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.deviceRepository.Create(model.PublicId,
				                             model.Name);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[DeviceFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,DeviceModel model)
		{
			if(this.deviceRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.deviceModelValidator.UpdateMode();
			var validationResult = this.deviceModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.deviceRepository.Update(id,  model.PublicId,
				                             model.Name);
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
		[DeviceFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.deviceRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>d5fc6040d3cd38ee24aa5028d1514b10</Hash>
</Codenesium>*/