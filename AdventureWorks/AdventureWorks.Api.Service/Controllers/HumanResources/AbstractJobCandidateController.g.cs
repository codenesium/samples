using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractJobCandidatesController: AbstractApiController
	{
		protected IJobCandidateRepository jobCandidateRepository;
		protected IJobCandidateModelValidator jobCandidateModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractJobCandidatesController(
			ILogger<AbstractJobCandidatesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IJobCandidateRepository jobCandidateRepository,
			IJobCandidateModelValidator jobCandidateModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.jobCandidateRepository = jobCandidateRepository;
			this.jobCandidateModelValidator = jobCandidateModelValidator;
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
		[JobCandidateFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.jobCandidateRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[JobCandidateFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.jobCandidateRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[JobCandidateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(JobCandidateModel model)
		{
			this.jobCandidateModelValidator.CreateMode();
			var validationResult = this.jobCandidateModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.jobCandidateRepository.Create(model.BusinessEntityID,
				                                            model.Resume,
				                                            model.ModifiedDate);
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
		[JobCandidateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<JobCandidateModel> models)
		{
			this.jobCandidateModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.jobCandidateModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.jobCandidateRepository.Create(model.BusinessEntityID,
				                                   model.Resume,
				                                   model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[JobCandidateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int JobCandidateID,JobCandidateModel model)
		{
			this.jobCandidateModelValidator.UpdateMode();
			var validationResult = this.jobCandidateModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.jobCandidateRepository.Update(JobCandidateID,  model.BusinessEntityID,
				                                   model.Resume,
				                                   model.ModifiedDate);
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
		[JobCandidateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.jobCandidateRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[JobCandidateFilter]
		[ReadOnlyFilter]
		[Route("~/api/Employees/{id}/JobCandidates")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			var response = new Response();

			this.jobCandidateRepository.GetWhere(x => x.BusinessEntityID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>56d40c761fcf72389e555354edb985ad</Hash>
</Codenesium>*/