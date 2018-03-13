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
	public abstract class AbstractDevicesController: AbstractEntityFrameworkApiController
	{
		protected DeviceRepository _deviceRepository;
		protected DeviceModelValidator _deviceModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractDevicesController(
			ILogger<AbstractDevicesController> logger,
			ApplicationContext context,
			DeviceRepository deviceRepository,
			DeviceModelValidator deviceModelValidator
			) : base(logger,context)
		{
			this._deviceRepository = deviceRepository;
			this._deviceModelValidator = deviceModelValidator;
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
			Response response = new Response();

			this._deviceRepository.GetById(id,response);
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
			Response response = new Response();

			this._deviceRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[DeviceFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), 400)]
		public virtual IActionResult Create(DeviceModel model)
		{
			this._deviceModelValidator.CreateMode();
			var validationResult = this._deviceModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._deviceRepository.Create(model.Id,
				                                       model.Name,
				                                       model.PublicId);
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
		[DeviceFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<DeviceModel> models)
		{
			this._deviceModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._deviceModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._deviceRepository.Create(model.Id,
				                              model.Name,
				                              model.PublicId);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[DeviceFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,DeviceModel model)
		{
			this._deviceModelValidator.UpdateMode();
			var validationResult = this._deviceModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._deviceRepository.Update(model.Id,
				                              model.Name,
				                              model.PublicId);
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
			this._deviceRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>d142835de7c0c1079ffc81794e799127</Hash>
</Codenesium>*/