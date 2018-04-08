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
	public abstract class AbstractUnitMeasuresController: AbstractApiController
	{
		protected IUnitMeasureRepository unitMeasureRepository;
		protected IUnitMeasureModelValidator unitMeasureModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractUnitMeasuresController(
			ILogger<AbstractUnitMeasuresController> logger,
			ITransactionCoordinator transactionCoordinator,
			IUnitMeasureRepository unitMeasureRepository,
			IUnitMeasureModelValidator unitMeasureModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.unitMeasureRepository = unitMeasureRepository;
			this.unitMeasureModelValidator = unitMeasureModelValidator;
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
		[UnitMeasureFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(string id)
		{
			Response response = new Response();

			this.unitMeasureRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[UnitMeasureFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.unitMeasureRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[UnitMeasureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(UnitMeasureModel model)
		{
			this.unitMeasureModelValidator.CreateMode();
			var validationResult = this.unitMeasureModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.unitMeasureRepository.Create(model.Name,
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
		[UnitMeasureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<UnitMeasureModel> models)
		{
			this.unitMeasureModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.unitMeasureModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.unitMeasureRepository.Create(model.Name,
				                                  model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[UnitMeasureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(string UnitMeasureCode,UnitMeasureModel model)
		{
			this.unitMeasureModelValidator.UpdateMode();
			var validationResult = this.unitMeasureModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.unitMeasureRepository.Update(UnitMeasureCode,  model.Name,
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
		[UnitMeasureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(string id)
		{
			this.unitMeasureRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>c5ac0afd7d42218a0c7a3d4c67075deb</Hash>
</Codenesium>*/