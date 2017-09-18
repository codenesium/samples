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
	public class LinkLogsControllerAbstract: AbstractEntityFrameworkApiController
	{
		protected LinkLogRepository _linkLogRepository;
		protected LinkLogModelValidator _linkLogModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public LinkLogsControllerAbstract(
			ILogger logger,
			DbContext context,
			LinkLogRepository linkLogRepository,
			LinkLogModelValidator linkLogModelValidator
			) : base(logger,context)
		{
			this._linkLogRepository = linkLogRepository;
			this._linkLogModelValidator = linkLogModelValidator;
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
		[LinkLogFilter]
		[ReadOnlyFilter]
		public virtual IHttpActionResult Get(int id)
		{
			Response response = new Response();

			this._linkLogRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[LinkLogFilter]
		[ReadOnlyFilter]
		public virtual IHttpActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.Request.GetQueryNameValuePairs());
			Response response = new Response();

			this._linkLogRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[LinkLogFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Create(LinkLogModel model)
		{
			this._linkLogModelValidator.CreateMode();
			var validationResult = this._linkLogModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._linkLogRepository.Create(model.DateEntered,
				                                        model.Id,
				                                        model.LinkId,
				                                        model.Log);
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
		[LinkLogFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult CreateMany(List<LinkLogModel> models)
		{
			this._linkLogModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._linkLogModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._linkLogRepository.Create(model.DateEntered,
				                               model.Id,
				                               model.LinkId,
				                               model.Log);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[LinkLogFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Update(int id,LinkLogModel model)
		{
			this._linkLogModelValidator.UpdateMode();
			var validationResult = this._linkLogModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._linkLogRepository.Update(model.DateEntered,
				                               model.Id,
				                               model.LinkId,
				                               model.Log);
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
		[LinkLogFilter]
		[UnitOfWorkActionFilter]
		public IHttpActionResult Patch(int id, JsonPatchDocument<LinkLogModel> patch)
		{
			Response response = new Response();

			this._linkLogRepository.GetById(id, response);
			if (response.LinkLogs.Count > 0)
			{
				var model = new LinkLogModel(response.LinkLogs.First());

				patch.ApplyUpdatesTo(model);
				this._linkLogModelValidator.PatchMode();
				var validationResult = this._linkLogModelValidator.Validate(model);
				if (validationResult.IsValid)
				{
					this._linkLogRepository.Update(model.DateEntered,
					                               model.Id,
					                               model.LinkId,
					                               model.Log);
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
		[LinkLogFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Delete(int id)
		{
			this._linkLogRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByLinkId/{id}")]
		[LinkLogFilter]
		[ReadOnlyFilter]
		[Route("~/api/Links/{id}/LinkLogs")]
		public virtual IHttpActionResult ByLinkId(int id)
		{
			var response = new Response();

			this._linkLogRepository.GetWhere(x => x.linkId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>0ed42f578fa8744990b274633f50b020</Hash>
</Codenesium>*/