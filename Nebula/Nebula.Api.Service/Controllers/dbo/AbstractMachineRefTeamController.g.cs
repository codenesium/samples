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
	public abstract class AbstractMachineRefTeamsController: AbstractApiController
	{
		protected IMachineRefTeamRepository machineRefTeamRepository;
		protected IMachineRefTeamModelValidator machineRefTeamModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractMachineRefTeamsController(
			ILogger<AbstractMachineRefTeamsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IMachineRefTeamRepository machineRefTeamRepository,
			IMachineRefTeamModelValidator machineRefTeamModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.machineRefTeamRepository = machineRefTeamRepository;
			this.machineRefTeamModelValidator = machineRefTeamModelValidator;
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
		[MachineRefTeamFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.machineRefTeamRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[MachineRefTeamFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.machineRefTeamRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[MachineRefTeamFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(MachineRefTeamModel model)
		{
			this.machineRefTeamModelValidator.CreateMode();
			var validationResult = this.machineRefTeamModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.machineRefTeamRepository.Create(model.MachineId,
				                                              model.TeamId);
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
		[MachineRefTeamFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<MachineRefTeamModel> models)
		{
			this.machineRefTeamModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.machineRefTeamModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.machineRefTeamRepository.Create(model.MachineId,
				                                     model.TeamId);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[MachineRefTeamFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,MachineRefTeamModel model)
		{
			if(this.machineRefTeamRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.machineRefTeamModelValidator.UpdateMode();
			var validationResult = this.machineRefTeamModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.machineRefTeamRepository.Update(id,  model.MachineId,
				                                     model.TeamId);
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
		[MachineRefTeamFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.machineRefTeamRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByMachineId/{id}")]
		[MachineRefTeamFilter]
		[ReadOnlyFilter]
		[Route("~/api/Machines/{id}/MachineRefTeams")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByMachineId(int id)
		{
			Response response = this.machineRefTeamRepository.GetWhere(x => x.MachineId == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByTeamId/{id}")]
		[MachineRefTeamFilter]
		[ReadOnlyFilter]
		[Route("~/api/Teams/{id}/MachineRefTeams")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByTeamId(int id)
		{
			Response response = this.machineRefTeamRepository.GetWhere(x => x.TeamId == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>180d0b5779d0003fe2272627a839d8a5</Hash>
</Codenesium>*/