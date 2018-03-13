using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.Service
{
	public abstract class AbstractDeviceActionsController: AbstractEntityFrameworkApiController
	{
		protected DeviceActionRepository _deviceActionRepository;
		protected DeviceActionModelValidator _deviceActionModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractDeviceActionsController(
			ILogger<AbstractDeviceActionsController> logger,
			ApplicationContext context,
			DeviceActionRepository deviceActionRepository,
			DeviceActionModelValidator deviceActionModelValidator
			) : base(logger,context)
		{
			this._deviceActionRepository = deviceActionRepository;
			this._deviceActionModelValidator = deviceActionModelValidator;
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
			Response response = new Response();

			this._deviceActionRepository.GetById(id,response);
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
			Response response = new Response();

			this._deviceActionRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[DeviceActionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), 400)]
		public virtual IActionResult Create(DeviceActionModel model)
		{
			this._deviceActionModelValidator.CreateMode();
			var validationResult = this._deviceActionModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._deviceActionRepository.Create(model.DeviceId,
				                                             model.Id,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[DeviceActionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<DeviceActionModel> models)
		{
			this._deviceActionModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._deviceActionModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._deviceActionRepository.Create(model.DeviceId,
				                                    model.Id,
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
		[ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,DeviceActionModel model)
		{
			this._deviceActionModelValidator.UpdateMode();
			var validationResult = this._deviceActionModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._deviceActionRepository.Update(model.DeviceId,
				                                    model.Id,
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
			this._deviceActionRepository.Delete(id);
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
			var response = new Response();

			this._deviceActionRepository.GetWhere(x => x.deviceId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>55af591a678193790ce1704d03baccec</Hash>
</Codenesium>*/