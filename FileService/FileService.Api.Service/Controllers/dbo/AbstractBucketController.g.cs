using System;
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
	public abstract class AbstractBucketsController: AbstractApiController
	{
		protected IBucketRepository bucketRepository;
		protected IBucketModelValidator bucketModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractBucketsController(
			ILogger<AbstractBucketsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBucketRepository bucketRepository,
			IBucketModelValidator bucketModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.bucketRepository = bucketRepository;
			this.bucketModelValidator = bucketModelValidator;
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
			Response response = this.bucketRepository.GetById(id);
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
			Response response = this.bucketRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
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
			this.bucketModelValidator.CreateMode();
			var validationResult = this.bucketModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.bucketRepository.Create(model.Name,
				                                      model.ExternalId);
				return Ok(id);
			}
			else
			{
				AddErrors(validationResult);
				return BadRequest(this.ModelState);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[BucketFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<BucketModel> models)
		{
			this.bucketModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.bucketModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.bucketRepository.Create(model.Name,
				                             model.ExternalId);
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
			if(this.bucketRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.bucketModelValidator.UpdateMode();
			var validationResult = this.bucketModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.bucketRepository.Update(id,  model.Name,
				                             model.ExternalId);
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
			this.bucketRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>91861e15110953991f0c75122f780473</Hash>
</Codenesium>*/