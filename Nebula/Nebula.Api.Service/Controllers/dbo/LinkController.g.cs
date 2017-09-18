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
	public class LinksControllerAbstract: AbstractEntityFrameworkApiController
	{
		protected LinkRepository _linkRepository;
		protected LinkModelValidator _linkModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public LinksControllerAbstract(
			ILogger logger,
			DbContext context,
			LinkRepository linkRepository,
			LinkModelValidator linkModelValidator
			) : base(logger,context)
		{
			this._linkRepository = linkRepository;
			this._linkModelValidator = linkModelValidator;
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
		[LinkFilter]
		[ReadOnlyFilter]
		public virtual IHttpActionResult Get(int id)
		{
			Response response = new Response();

			this._linkRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[LinkFilter]
		[ReadOnlyFilter]
		public virtual IHttpActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.Request.GetQueryNameValuePairs());
			Response response = new Response();

			this._linkRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[LinkFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Create(LinkModel model)
		{
			this._linkModelValidator.CreateMode();
			var validationResult = this._linkModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._linkRepository.Create(model.AssignedMachineId,
				                                     model.ChainId,
				                                     model.DateCompleted,
				                                     model.DateStarted,
				                                     model.DynamicParameters,
				                                     model.ExternalId,
				                                     model.Id,
				                                     model.LinkStatusId,
				                                     model.Name,
				                                     model.Order,
				                                     model.Response,
				                                     model.StaticParameters);
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
		[LinkFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult CreateMany(List<LinkModel> models)
		{
			this._linkModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._linkModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._linkRepository.Create(model.AssignedMachineId,
				                            model.ChainId,
				                            model.DateCompleted,
				                            model.DateStarted,
				                            model.DynamicParameters,
				                            model.ExternalId,
				                            model.Id,
				                            model.LinkStatusId,
				                            model.Name,
				                            model.Order,
				                            model.Response,
				                            model.StaticParameters);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[LinkFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Update(int id,LinkModel model)
		{
			this._linkModelValidator.UpdateMode();
			var validationResult = this._linkModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._linkRepository.Update(model.AssignedMachineId,
				                            model.ChainId,
				                            model.DateCompleted,
				                            model.DateStarted,
				                            model.DynamicParameters,
				                            model.ExternalId,
				                            model.Id,
				                            model.LinkStatusId,
				                            model.Name,
				                            model.Order,
				                            model.Response,
				                            model.StaticParameters);
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
		[LinkFilter]
		[UnitOfWorkActionFilter]
		public IHttpActionResult Patch(int id, JsonPatchDocument<LinkModel> patch)
		{
			Response response = new Response();

			this._linkRepository.GetById(id, response);
			if (response.Links.Count > 0)
			{
				var model = new LinkModel(response.Links.First());

				patch.ApplyUpdatesTo(model);
				this._linkModelValidator.PatchMode();
				var validationResult = this._linkModelValidator.Validate(model);
				if (validationResult.IsValid)
				{
					this._linkRepository.Update(model.AssignedMachineId,
					                            model.ChainId,
					                            model.DateCompleted,
					                            model.DateStarted,
					                            model.DynamicParameters,
					                            model.ExternalId,
					                            model.Id,
					                            model.LinkStatusId,
					                            model.Name,
					                            model.Order,
					                            model.Response,
					                            model.StaticParameters);
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
		[LinkFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Delete(int id)
		{
			this._linkRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByAssignedMachineId/{id}")]
		[LinkFilter]
		[ReadOnlyFilter]
		[Route("~/api/Machines/{id}/Links")]
		public virtual IHttpActionResult ByAssignedMachineId(int id)
		{
			var response = new Response();

			this._linkRepository.GetWhere(x => x.assignedMachineId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByChainId/{id}")]
		[LinkFilter]
		[ReadOnlyFilter]
		[Route("~/api/Chains/{id}/Links")]
		public virtual IHttpActionResult ByChainId(int id)
		{
			var response = new Response();

			this._linkRepository.GetWhere(x => x.chainId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByLinkStatusId/{id}")]
		[LinkFilter]
		[ReadOnlyFilter]
		[Route("~/api/LinkStatus/{id}/Links")]
		public virtual IHttpActionResult ByLinkStatusId(int id)
		{
			var response = new Response();

			this._linkRepository.GetWhere(x => x.linkStatusId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>40255a08312f01e771798066f457a111</Hash>
</Codenesium>*/