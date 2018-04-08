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
	public abstract class AbstractCulturesController: AbstractApiController
	{
		protected ICultureRepository cultureRepository;
		protected ICultureModelValidator cultureModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractCulturesController(
			ILogger<AbstractCulturesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICultureRepository cultureRepository,
			ICultureModelValidator cultureModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.cultureRepository = cultureRepository;
			this.cultureModelValidator = cultureModelValidator;
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
		[CultureFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(string id)
		{
			Response response = new Response();

			this.cultureRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[CultureFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.cultureRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[CultureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(CultureModel model)
		{
			this.cultureModelValidator.CreateMode();
			var validationResult = this.cultureModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.cultureRepository.Create(model.Name,
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
		[CultureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<CultureModel> models)
		{
			this.cultureModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.cultureModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.cultureRepository.Create(model.Name,
				                              model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[CultureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(string CultureID,CultureModel model)
		{
			this.cultureModelValidator.UpdateMode();
			var validationResult = this.cultureModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.cultureRepository.Update(CultureID,  model.Name,
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
		[CultureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(string id)
		{
			this.cultureRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>bf925736c8de37e4f91758c4a7c038ab</Hash>
</Codenesium>*/