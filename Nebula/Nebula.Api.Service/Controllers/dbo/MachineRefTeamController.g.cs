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
	public abstract class AbstractMachineRefTeamsController: AbstractEntityFrameworkApiController
	{
		protected IMachineRefTeamRepository _machineRefTeamRepository;
		protected IMachineRefTeamModelValidator _machineRefTeamModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractMachineRefTeamsController(
			ILogger<AbstractMachineRefTeamsController> logger,
			ApplicationContext context,
			IMachineRefTeamRepository machineRefTeamRepository,
			IMachineRefTeamModelValidator machineRefTeamModelValidator
			) : base(logger,context)
		{
			this._machineRefTeamRepository = machineRefTeamRepository;
			this._machineRefTeamModelValidator = machineRefTeamModelValidator;
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
			Response response = new Response();

			this._machineRefTeamRepository.GetById(id,response);
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
			Response response = new Response();

			this._machineRefTeamRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._machineRefTeamModelValidator.CreateMode();
			var validationResult = this._machineRefTeamModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._machineRefTeamRepository.Create(model.MachineId,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[MachineRefTeamFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<MachineRefTeamModel> models)
		{
			this._machineRefTeamModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._machineRefTeamModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._machineRefTeamRepository.Create(model.MachineId,
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
		public virtual IActionResult Update(int Id,MachineRefTeamModel model)
		{
			this._machineRefTeamModelValidator.UpdateMode();
			var validationResult = this._machineRefTeamModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._machineRefTeamRepository.Update(Id,  model.MachineId,
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
			this._machineRefTeamRepository.Delete(id);
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
			var response = new Response();

			this._machineRefTeamRepository.GetWhere(x => x.MachineId == id, response);
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
			var response = new Response();

			this._machineRefTeamRepository.GetWhere(x => x.TeamId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>861493508c823817ed87bf97474aa63a</Hash>
</Codenesium>*/