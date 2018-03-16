using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Service
{
	public abstract class AbstractBucketsController: AbstractEntityFrameworkApiController
	{
		protected BucketRepository _bucketRepository;
		protected BucketModelValidator _bucketModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractBucketsController(
			ILogger<AbstractBucketsController> logger,
			ApplicationContext context,
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
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
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
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
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
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(BucketModel model)
		{
			this._bucketModelValidator.CreateMode();
			var validationResult = this._bucketModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._bucketRepository.Create(model.ExternalId,
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
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<BucketModel> models)
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
				                              model.Name);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[BucketFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,BucketModel model)
		{
			this._bucketModelValidator.UpdateMode();
			var validationResult = this._bucketModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._bucketRepository.Update(id,  model.ExternalId,
				                              model.Name);
				return Ok();
			}
			else
			{
				AddErrors(validationResult);
				return BadRequest(this.ModelState);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[ModelValidateFilter]
		[BucketFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._bucketRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>afde00a45da5ce88a49e89d2b5377416</Hash>
</Codenesium>*/