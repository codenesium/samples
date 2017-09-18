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
	public class MachinesControllerAbstract: AbstractEntityFrameworkApiController
	{
		protected MachineRepository _machineRepository;
		protected MachineModelValidator _machineModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public MachinesControllerAbstract(
			ILogger logger,
			DbContext context,
			MachineRepository machineRepository,
			MachineModelValidator machineModelValidator
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
		public virtual IHttpActionResult Get(int id)
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
		public virtual IHttpActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.Request.GetQueryNameValuePairs());
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
		public virtual IHttpActionResult Create(MachineModel model)
		{
			this._machineModelValidator.CreateMode();
			var validationResult = this._machineModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._machineRepository.Create(model.Description,
				                                        model.Id,
				                                        model.JwtKey,
				                                        model.LastIpAddress,
				                                        model.MachineGuid,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[MachineFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult CreateMany(List<MachineModel> models)
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
				this._machineRepository.Create(model.Description,
				                               model.Id,
				                               model.JwtKey,
				                               model.LastIpAddress,
				                               model.MachineGuid,
				                               model.Name);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[MachineFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Update(int id,MachineModel model)
		{
			this._machineModelValidator.UpdateMode();
			var validationResult = this._machineModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._machineRepository.Update(model.Description,
				                               model.Id,
				                               model.JwtKey,
				                               model.LastIpAddress,
				                               model.MachineGuid,
				                               model.Name);
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
		[MachineFilter]
		[UnitOfWorkActionFilter]
		public IHttpActionResult Patch(int id, JsonPatchDocument<MachineModel> patch)
		{
			Response response = new Response();

			this._machineRepository.GetById(id, response);
			if (response.Machines.Count > 0)
			{
				var model = new MachineModel(response.Machines.First());

				patch.ApplyUpdatesTo(model);
				this._machineModelValidator.PatchMode();
				var validationResult = this._machineModelValidator.Validate(model);
				if (validationResult.IsValid)
				{
					this._machineRepository.Update(model.Description,
					                               model.Id,
					                               model.JwtKey,
					                               model.LastIpAddress,
					                               model.MachineGuid,
					                               model.Name);
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
		[MachineFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Delete(int id)
		{
			this._machineRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>6815a0fb3bb6892a455573b3e115d86a</Hash>
</Codenesium>*/