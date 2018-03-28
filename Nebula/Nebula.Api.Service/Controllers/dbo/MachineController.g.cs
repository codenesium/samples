using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service
{
	public abstract class AbstractMachinesController: AbstractEntityFrameworkApiController
	{
		protected IMachineRepository _machineRepository;
		protected IMachineModelValidator _machineModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractMachinesController(
			ILogger<AbstractMachinesController> logger,
			ApplicationContext context,
			IMachineRepository machineRepository,
			IMachineModelValidator machineModelValidator
			) : base(logger,context)
		{
			this._machineRepository = machineRepository;
			this._machineModelValidator = machineModelValidator;
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
		[MachineFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._machineRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[MachineFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._machineRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[MachineFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(MachineModel model)
		{
			this._machineModelValidator.CreateMode();
			var validationResult = this._machineModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._machineRepository.Create(model.Name,
				                                        model.MachineGuid,
				                                        model.JwtKey,
				                                        model.LastIpAddress,
				                                        model.Description);
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
		[MachineFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<MachineModel> models)
		{
			this._machineModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._machineModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._machineRepository.Create(model.Name,
				                               model.MachineGuid,
				                               model.JwtKey,
				                               model.LastIpAddress,
				                               model.Description);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[MachineFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,MachineModel model)
		{
			this._machineModelValidator.UpdateMode();
			var validationResult = this._machineModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._machineRepository.Update(id,  model.Name,
				                               model.MachineGuid,
				                               model.JwtKey,
				                               model.LastIpAddress,
				                               model.Description);
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
		[MachineFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._machineRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>03d5222b6f67ea265ab366cecb18a701</Hash>
</Codenesium>*/