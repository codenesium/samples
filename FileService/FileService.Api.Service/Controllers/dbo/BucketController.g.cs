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
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Service
{
	public class BucketsControllerAbstract: AbstractEntityFrameworkApiController
	{
		protected BucketRepository _bucketRepository;
		protected BucketModelValidator _bucketModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public BucketsControllerAbstract(
			ILogger logger,
			DbContext context,
			BucketRepository bucketRepository,
			BucketModelValidator bucketModelValidator
			) : base(logger,context)
		{
			this._bucketRepository = bucketRepository;
			this._bucketModelValidator = bucketModelValidator;
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
		[BucketFilter]
		[ReadOnlyFilter]
		public virtual IHttpActionResult Get(int id)
		{
			Response response = new Response();

			this._bucketRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[BucketFilter]
		[ReadOnlyFilter]
		public virtual IHttpActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.Request.GetQueryNameValuePairs());
			Response response = new Response();

			this._bucketRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[BucketFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Create(BucketModel model)
		{
			this._bucketModelValidator.CreateMode();
			var validationResult = this._bucketModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._bucketRepository.Create(model.ExternalId,
				                                       model.Id,
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
		[BucketFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult CreateMany(List<BucketModel> models)
		{
			this._bucketModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._bucketModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._bucketRepository.Create(model.ExternalId,
				                              model.Id,
				                              model.Name);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[BucketFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Update(int id,BucketModel model)
		{
			this._bucketModelValidator.UpdateMode();
			var validationResult = this._bucketModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._bucketRepository.Update(model.ExternalId,
				                              model.Id,
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
		[BucketFilter]
		[UnitOfWorkActionFilter]
		public IHttpActionResult Patch(int id, JsonPatchDocument<BucketModel> patch)
		{
			Response response = new Response();

			this._bucketRepository.GetById(id, response);
			if (response.Buckets.Count > 0)
			{
				var model = new BucketModel(response.Buckets.First());

				patch.ApplyUpdatesTo(model);
				this._bucketModelValidator.PatchMode();
				var validationResult = this._bucketModelValidator.Validate(model);
				if (validationResult.IsValid)
				{
					this._bucketRepository.Update(model.ExternalId,
					                              model.Id,
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
		[BucketFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Delete(int id)
		{
			this._bucketRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>b5e91eb0f29fee437b6731060111e9b6</Hash>
</Codenesium>*/