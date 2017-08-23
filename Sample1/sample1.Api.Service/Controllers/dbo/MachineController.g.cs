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
	public class MachineControllerAbstract: AbstractEntityFrameworkApiController
	{
		protected MachineRepository _machineRepository;
		protected MachineModelValidator _machineModelValidator;
		protected int SearchRecordLimit {get; set;} = 1000;
		protected int SearchRecordDefault {get; set;} = 250;
		public MachineControllerAbstract(
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

			this._machineRepository.GetWhereDynamic(whereClause,response,offset,limit);
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
    <Hash>597e73e7c26ba1bac73229f46972581d</Hash>
</Codenesium>*/