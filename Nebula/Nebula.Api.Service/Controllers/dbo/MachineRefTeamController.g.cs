using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using JsonPatch;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service
{
	public class MachineRefTeamsControllerAbstract: AbstractEntityFrameworkApiController
	{
		protected MachineRefTeamRepository _machineRefTeamRepository;
		protected MachineRefTeamModelValidator _machineRefTeamModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public MachineRefTeamsControllerAbstract(
			ILogger logger,
			DbContext context,
			MachineRefTeamRepository machineRefTeamRepository,
			MachineRefTeamModelValidator machineRefTeamModelValidator
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
		public virtual IHttpActionResult Get(int id)
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
		public virtual IHttpActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.Request.GetQueryNameValuePairs());
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
		public virtual IHttpActionResult Create(MachineRefTeamModel model)
		{
			this._machineRefTeamModelValidator.CreateMode();
			var validationResult = this._machineRefTeamModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._machineRefTeamRepository.Create(model.Id,
				                                               model.MachineId,
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
		public virtual IHttpActionResult CreateMany(List<MachineRefTeamModel> models)
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
				this._machineRefTeamRepository.Create(model.Id,
				                                      model.MachineId,
				                                      model.TeamId);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[MachineRefTeamFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Update(int id,MachineRefTeamModel model)
		{
			this._machineRefTeamModelValidator.UpdateMode();
			var validationResult = this._machineRefTeamModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._machineRefTeamRepository.Update(model.Id,
				                                      model.MachineId,
				                                      model.TeamId);
				return Ok();
			}
			else
			{
				AddErrors(validationResult);
				return BadRequest(this.ModelState);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[ModelValidateFilter]
		[MachineRefTeamFilter]
		[UnitOfWorkActionFilter]
		public IHttpActionResult Patch(int id, JsonPatchDocument<MachineRefTeamModel> patch)
		{
			Response response = new Response();

			this._machineRefTeamRepository.GetById(id, response);
			if (response.MachineRefTeams.Count > 0)
			{
				var model = new MachineRefTeamModel(response.MachineRefTeams.First());

				patch.ApplyUpdatesTo(model);
				this._machineRefTeamModelValidator.PatchMode();
				var validationResult = this._machineRefTeamModelValidator.Validate(model);
				if (validationResult.IsValid)
				{
					this._machineRefTeamRepository.Update(model.Id,
					                                      model.MachineId,
					                                      model.TeamId);
					return Ok();
				}
				else
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}
			else
			{
				return BadRequest("Entity not found");
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[ModelValidateFilter]
		[MachineRefTeamFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Delete(int id)
		{
			this._machineRefTeamRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByMachineId/{id}")]
		[MachineRefTeamFilter]
		[ReadOnlyFilter]
		[Route("~/api/Machines/{id}/MachineRefTeams")]
		public virtual IHttpActionResult ByMachineId(int id)
		{
			var response = new Response();

			this._machineRefTeamRepository.GetWhere(x => x.machineId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByTeamId/{id}")]
		[MachineRefTeamFilter]
		[ReadOnlyFilter]
		[Route("~/api/Teams/{id}/MachineRefTeams")]
		public virtual IHttpActionResult ByTeamId(int id)
		{
			var response = new Response();

			this._machineRefTeamRepository.GetWhere(x => x.teamId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>55fe7917d31f101a25c61e2769e51abc</Hash>
</Codenesium>*/