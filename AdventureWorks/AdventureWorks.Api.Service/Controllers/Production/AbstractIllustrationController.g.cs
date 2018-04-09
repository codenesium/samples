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
	public abstract class AbstractIllustrationsController: AbstractApiController
	{
		protected IIllustrationRepository illustrationRepository;
		protected IIllustrationModelValidator illustrationModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractIllustrationsController(
			ILogger<AbstractIllustrationsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IIllustrationRepository illustrationRepository,
			IIllustrationModelValidator illustrationModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.illustrationRepository = illustrationRepository;
			this.illustrationModelValidator = illustrationModelValidator;
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
		[IllustrationFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.illustrationRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[IllustrationFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.illustrationRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[IllustrationFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(IllustrationModel model)
		{
			this.illustrationModelValidator.CreateMode();
			var validationResult = this.illustrationModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.illustrationRepository.Create(model.Diagram,
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
		[IllustrationFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<IllustrationModel> models)
		{
			this.illustrationModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.illustrationModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.illustrationRepository.Create(model.Diagram,
				                                   model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[IllustrationFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,IllustrationModel model)
		{
			if(this.illustrationRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.illustrationModelValidator.UpdateMode();
			var validationResult = this.illustrationModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.illustrationRepository.Update(id,  model.Diagram,
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
		[IllustrationFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.illustrationRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>89e80fa103679d62e558c5873362b4e9</Hash>
</Codenesium>*/