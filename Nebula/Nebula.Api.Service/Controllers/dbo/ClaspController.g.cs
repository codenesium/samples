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
	public class ClaspsControllerAbstract: AbstractEntityFrameworkApiController
	{
		protected ClaspRepository _claspRepository;
		protected ClaspModelValidator _claspModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public ClaspsControllerAbstract(
			ILogger logger,
			DbContext context,
			ClaspRepository claspRepository,
			ClaspModelValidator claspModelValidator
			) : base(logger,context)
		{
			this._claspRepository = claspRepository;
			this._claspModelValidator = claspModelValidator;
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
		[ClaspFilter]
		[ReadOnlyFilter]
		public virtual IHttpActionResult Get(int id)
		{
			Response response = new Response();

			this._claspRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ClaspFilter]
		[ReadOnlyFilter]
		public virtual IHttpActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.Request.GetQueryNameValuePairs());
			Response response = new Response();

			this._claspRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ClaspFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Create(ClaspModel model)
		{
			this._claspModelValidator.CreateMode();
			var validationResult = this._claspModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._claspRepository.Create(model.Id,
				                                      model.NextChainId,
				                                      model.PreviousChainId);
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
		[ClaspFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult CreateMany(List<ClaspModel> models)
		{
			this._claspModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._claspModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._claspRepository.Create(model.Id,
				                             model.NextChainId,
				                             model.PreviousChainId);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ClaspFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Update(int id,ClaspModel model)
		{
			this._claspModelValidator.UpdateMode();
			var validationResult = this._claspModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._claspRepository.Update(model.Id,
				                             model.NextChainId,
				                             model.PreviousChainId);
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
		[ClaspFilter]
		[UnitOfWorkActionFilter]
		public IHttpActionResult Patch(int id, JsonPatchDocument<ClaspModel> patch)
		{
			Response response = new Response();

			this._claspRepository.GetById(id, response);
			if (response.Clasps.Count > 0)
			{
				var model = new ClaspModel(response.Clasps.First());

				patch.ApplyUpdatesTo(model);
				this._claspModelValidator.PatchMode();
				var validationResult = this._claspModelValidator.Validate(model);
				if (validationResult.IsValid)
				{
					this._claspRepository.Update(model.Id,
					                             model.NextChainId,
					                             model.PreviousChainId);
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
		[ClaspFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Delete(int id)
		{
			this._claspRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByNextChainId/{id}")]
		[ClaspFilter]
		[ReadOnlyFilter]
		[Route("~/api/Chains/{id}/Clasps")]
		public virtual IHttpActionResult ByNextChainId(int id)
		{
			var response = new Response();

			this._claspRepository.GetWhere(x => x.nextChainId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByPreviousChainId/{id}")]
		[ClaspFilter]
		[ReadOnlyFilter]
		[Route("~/api/Chains/{id}/Clasps")]
		public virtual IHttpActionResult ByPreviousChainId(int id)
		{
			var response = new Response();

			this._claspRepository.GetWhere(x => x.previousChainId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>96d842abec9a16cd53fb23ea4fb43474</Hash>
</Codenesium>*/