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
using sample1NS.Api.Contracts;
using sample1NS.Api.DataAccess;
namespace sample1NS.Api.Service
{
	public class MachineRefTeamControllerAbstract: AbstractEntityFrameworkApiController
	{
		protected MachineRefTeamRepository _machineRefTeamRepository;
		protected MachineRefTeamModelValidator _machineRefTeamModelValidator;
		protected int SearchRecordLimit {get; set;} = 1000;
		protected int SearchRecordDefault {get; set;} = 250;
		public MachineRefTeamControllerAbstract(
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
			var queryParameters = ControllerContext.Request.GetQueryNameValuePairs();
			string whereClause = String.Empty;

			int offset = 0;
			int limit = this.SearchRecordDefault;

			if (!queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "OFFSET").Equals(default (KeyValuePair<string, string>)))
			{
				offset = queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "OFFSET").Value.ToInt();
			}

			if (!queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "LIMIT").Equals(default (KeyValuePair<string, string>)))
			{
				limit = queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "LIMIT").Value.ToInt();
			}

			if(limit > this.SearchRecordLimit)
			{
				return BadRequest($"Limit of {limit} exceeds maximum request size of {this.SearchRecordLimit} records");
			}

			foreach(var parameter in queryParameters)
			{
				if(parameter.Key.ToUpper() == "OFFSET" || parameter.Key.ToUpper() == "LIMIT")
				{
					continue;
				}

				if(!String.IsNullOrEmpty(whereClause))
				{
					whereClause += " && ";
				}

				if (parameter.Value.ToNullableInt() != null)
				{
					whereClause += $"{parameter.Key}.Equals({parameter.Value})";
				}
				else if (parameter.Value.ToNullableGuid() != null)
				{
					whereClause += $"{parameter.Key}.Equals(Guid(\"{parameter.Value}\"))";
				}
				else
				{
					whereClause += $"{parameter.Key}.Equals(\"{parameter.Value}\")";
				}
			}
			if(String.IsNullOrWhiteSpace(whereClause))
			{
				whereClause = "1=1";
			}
			Response response = new Response();

			this._machineRefTeamRepository.GetWhereDynamic(whereClause,response,offset,limit);
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
    <Hash>d154c46415b4e878bcea10745c5c95f5</Hash>
</Codenesium>*/