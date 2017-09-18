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
	public class OrganizationsControllerAbstract: AbstractEntityFrameworkApiController
	{
		protected OrganizationRepository _organizationRepository;
		protected OrganizationModelValidator _organizationModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public OrganizationsControllerAbstract(
			ILogger logger,
			DbContext context,
			OrganizationRepository organizationRepository,
			OrganizationModelValidator organizationModelValidator
			) : base(logger,context)
		{
			this._organizationRepository = organizationRepository;
			this._organizationModelValidator = organizationModelValidator;
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
		[OrganizationFilter]
		[ReadOnlyFilter]
		public virtual IHttpActionResult Get(int id)
		{
			Response response = new Response();

			this._organizationRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[OrganizationFilter]
		[ReadOnlyFilter]
		public virtual IHttpActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.Request.GetQueryNameValuePairs());
			Response response = new Response();

			this._organizationRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[OrganizationFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Create(OrganizationModel model)
		{
			this._organizationModelValidator.CreateMode();
			var validationResult = this._organizationModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._organizationRepository.Create(model.Id,
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
		[OrganizationFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult CreateMany(List<OrganizationModel> models)
		{
			this._organizationModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._organizationModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._organizationRepository.Create(model.Id,
				                                    model.Name);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[OrganizationFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Update(int id,OrganizationModel model)
		{
			this._organizationModelValidator.UpdateMode();
			var validationResult = this._organizationModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._organizationRepository.Update(model.Id,
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
		[OrganizationFilter]
		[UnitOfWorkActionFilter]
		public IHttpActionResult Patch(int id, JsonPatchDocument<OrganizationModel> patch)
		{
			Response response = new Response();

			this._organizationRepository.GetById(id, response);
			if (response.Organizations.Count > 0)
			{
				var model = new OrganizationModel(response.Organizations.First());

				patch.ApplyUpdatesTo(model);
				this._organizationModelValidator.PatchMode();
				var validationResult = this._organizationModelValidator.Validate(model);
				if (validationResult.IsValid)
				{
					this._organizationRepository.Update(model.Id,
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
		[OrganizationFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Delete(int id)
		{
			this._organizationRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>20b2b13efab90c8d27e6ab3c11b5c704</Hash>
</Codenesium>*/