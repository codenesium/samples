using System;
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
	public abstract class AbstractMachinesController: AbstractApiController
	{
		protected IMachineRepository machineRepository;
		protected IMachineModelValidator machineModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractMachinesController(
			ILogger<AbstractMachinesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IMachineRepository machineRepository,
			IMachineModelValidator machineModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.machineRepository = machineRepository;
			this.machineModelValidator = machineModelValidator;
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
			Response response = this.machineRepository.GetById(id);
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
			Response response = this.machineRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
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
			this.machineModelValidator.CreateMode();
			var validationResult = this.machineModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.machineRepository.Create(model.Name,
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
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[MachineFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<MachineModel> models)
		{
			this.machineModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.machineModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.machineRepository.Create(model.Name,
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
			if(this.machineRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.machineModelValidator.UpdateMode();
			var validationResult = this.machineModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.machineRepository.Update(id,  model.Name,
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
			this.machineRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>472ae628725aa50c6276b9d8ae4abe8e</Hash>
</Codenesium>*/