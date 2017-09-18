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
	public class ChainStatusControllerAbstract: AbstractEntityFrameworkApiController
	{
		protected ChainStatusRepository _chainStatusRepository;
		protected ChainStatusModelValidator _chainStatusModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public ChainStatusControllerAbstract(
			ILogger logger,
			DbContext context,
			ChainStatusRepository chainStatusRepository,
			ChainStatusModelValidator chainStatusModelValidator
			) : base(logger,context)
		{
			this._chainStatusRepository = chainStatusRepository;
			this._chainStatusModelValidator = chainStatusModelValidator;
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
		[ChainStatusFilter]
		[ReadOnlyFilter]
		public virtual IHttpActionResult Get(int id)
		{
			Response response = new Response();

			this._chainStatusRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ChainStatusFilter]
		[ReadOnlyFilter]
		public virtual IHttpActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.Request.GetQueryNameValuePairs());
			Response response = new Response();

			this._chainStatusRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ChainStatusFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Create(ChainStatusModel model)
		{
			this._chainStatusModelValidator.CreateMode();
			var validationResult = this._chainStatusModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._chainStatusRepository.Create(model.Id,
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
		[ChainStatusFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult CreateMany(List<ChainStatusModel> models)
		{
			this._chainStatusModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._chainStatusModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._chainStatusRepository.Create(model.Id,
				                                   model.Name);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ChainStatusFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Update(int id,ChainStatusModel model)
		{
			this._chainStatusModelValidator.UpdateMode();
			var validationResult = this._chainStatusModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._chainStatusRepository.Update(model.Id,
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
		[ChainStatusFilter]
		[UnitOfWorkActionFilter]
		public IHttpActionResult Patch(int id, JsonPatchDocument<ChainStatusModel> patch)
		{
			Response response = new Response();

			this._chainStatusRepository.GetById(id, response);
			if (response.ChainStatus.Count > 0)
			{
				var model = new ChainStatusModel(response.ChainStatus.First());

				patch.ApplyUpdatesTo(model);
				this._chainStatusModelValidator.PatchMode();
				var validationResult = this._chainStatusModelValidator.Validate(model);
				if (validationResult.IsValid)
				{
					this._chainStatusRepository.Update(model.Id,
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
		[ChainStatusFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Delete(int id)
		{
			this._chainStatusRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>5ace6c0bf723c2f6788d7d393bbdb74c</Hash>
</Codenesium>*/