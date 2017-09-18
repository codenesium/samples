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
	public class TeamsControllerAbstract: AbstractEntityFrameworkApiController
	{
		protected TeamRepository _teamRepository;
		protected TeamModelValidator _teamModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public TeamsControllerAbstract(
			ILogger logger,
			DbContext context,
			TeamRepository teamRepository,
			TeamModelValidator teamModelValidator
			) : base(logger,context)
		{
			this._teamRepository = teamRepository;
			this._teamModelValidator = teamModelValidator;
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
		[TeamFilter]
		[ReadOnlyFilter]
		public virtual IHttpActionResult Get(int id)
		{
			Response response = new Response();

			this._teamRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[TeamFilter]
		[ReadOnlyFilter]
		public virtual IHttpActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.Request.GetQueryNameValuePairs());
			Response response = new Response();

			this._teamRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[TeamFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Create(TeamModel model)
		{
			this._teamModelValidator.CreateMode();
			var validationResult = this._teamModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._teamRepository.Create(model.Id,
				                                     model.Name,
				                                     model.OrganizationId);
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
		[TeamFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult CreateMany(List<TeamModel> models)
		{
			this._teamModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._teamModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._teamRepository.Create(model.Id,
				                            model.Name,
				                            model.OrganizationId);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[TeamFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Update(int id,TeamModel model)
		{
			this._teamModelValidator.UpdateMode();
			var validationResult = this._teamModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._teamRepository.Update(model.Id,
				                            model.Name,
				                            model.OrganizationId);
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
		[TeamFilter]
		[UnitOfWorkActionFilter]
		public IHttpActionResult Patch(int id, JsonPatchDocument<TeamModel> patch)
		{
			Response response = new Response();

			this._teamRepository.GetById(id, response);
			if (response.Teams.Count > 0)
			{
				var model = new TeamModel(response.Teams.First());

				patch.ApplyUpdatesTo(model);
				this._teamModelValidator.PatchMode();
				var validationResult = this._teamModelValidator.Validate(model);
				if (validationResult.IsValid)
				{
					this._teamRepository.Update(model.Id,
					                            model.Name,
					                            model.OrganizationId);
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
		[TeamFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Delete(int id)
		{
			this._teamRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByOrganizationId/{id}")]
		[TeamFilter]
		[ReadOnlyFilter]
		[Route("~/api/Organizations/{id}/Teams")]
		public virtual IHttpActionResult ByOrganizationId(int id)
		{
			var response = new Response();

			this._teamRepository.GetWhere(x => x.organizationId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>c4a8f8c1ece8348b335114a8e4aa6894</Hash>
</Codenesium>*/