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
	public abstract class AbstractAWBuildVersionsController: AbstractApiController
	{
		protected IAWBuildVersionRepository aWBuildVersionRepository;
		protected IAWBuildVersionModelValidator aWBuildVersionModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractAWBuildVersionsController(
			ILogger<AbstractAWBuildVersionsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAWBuildVersionRepository aWBuildVersionRepository,
			IAWBuildVersionModelValidator aWBuildVersionModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.aWBuildVersionRepository = aWBuildVersionRepository;
			this.aWBuildVersionModelValidator = aWBuildVersionModelValidator;
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
		[AWBuildVersionFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.aWBuildVersionRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[AWBuildVersionFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.aWBuildVersionRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[AWBuildVersionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(AWBuildVersionModel model)
		{
			this.aWBuildVersionModelValidator.CreateMode();
			var validationResult = this.aWBuildVersionModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.aWBuildVersionRepository.Create(model.Database_Version,
				                                              model.VersionDate,
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
		[AWBuildVersionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<AWBuildVersionModel> models)
		{
			this.aWBuildVersionModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.aWBuildVersionModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.aWBuildVersionRepository.Create(model.Database_Version,
				                                     model.VersionDate,
				                                     model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[AWBuildVersionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int SystemInformationID,AWBuildVersionModel model)
		{
			this.aWBuildVersionModelValidator.UpdateMode();
			var validationResult = this.aWBuildVersionModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.aWBuildVersionRepository.Update(SystemInformationID,  model.Database_Version,
				                                     model.VersionDate,
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
		[AWBuildVersionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.aWBuildVersionRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>ebf4bd2819f7f2644a657b94a94543b9</Hash>
</Codenesium>*/