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
	public class LinkStatusControllerAbstract: AbstractEntityFrameworkApiController
	{
		protected LinkStatusRepository _linkStatusRepository;
		protected LinkStatusModelValidator _linkStatusModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public LinkStatusControllerAbstract(
			ILogger logger,
			DbContext context,
			LinkStatusRepository linkStatusRepository,
			LinkStatusModelValidator linkStatusModelValidator
			) : base(logger,context)
		{
			this._linkStatusRepository = linkStatusRepository;
			this._linkStatusModelValidator = linkStatusModelValidator;
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
		[LinkStatusFilter]
		[ReadOnlyFilter]
		public virtual IHttpActionResult Get(int id)
		{
			Response response = new Response();

			this._linkStatusRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[LinkStatusFilter]
		[ReadOnlyFilter]
		public virtual IHttpActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.Request.GetQueryNameValuePairs());
			Response response = new Response();

			this._linkStatusRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[LinkStatusFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Create(LinkStatusModel model)
		{
			this._linkStatusModelValidator.CreateMode();
			var validationResult = this._linkStatusModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._linkStatusRepository.Create(model.Id,
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
		[LinkStatusFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult CreateMany(List<LinkStatusModel> models)
		{
			this._linkStatusModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._linkStatusModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._linkStatusRepository.Create(model.Id,
				                                  model.Name);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[LinkStatusFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Update(int id,LinkStatusModel model)
		{
			this._linkStatusModelValidator.UpdateMode();
			var validationResult = this._linkStatusModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._linkStatusRepository.Update(model.Id,
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
		[LinkStatusFilter]
		[UnitOfWorkActionFilter]
		public IHttpActionResult Patch(int id, JsonPatchDocument<LinkStatusModel> patch)
		{
			Response response = new Response();

			this._linkStatusRepository.GetById(id, response);
			if (response.LinkStatus.Count > 0)
			{
				var model = new LinkStatusModel(response.LinkStatus.First());

				patch.ApplyUpdatesTo(model);
				this._linkStatusModelValidator.PatchMode();
				var validationResult = this._linkStatusModelValidator.Validate(model);
				if (validationResult.IsValid)
				{
					this._linkStatusRepository.Update(model.Id,
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
		[LinkStatusFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Delete(int id)
		{
			this._linkStatusRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>53cf4e4e877a038a3b6b5ec38f22e0f8</Hash>
</Codenesium>*/