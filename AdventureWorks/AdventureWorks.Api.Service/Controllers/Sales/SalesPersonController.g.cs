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
	public abstract class AbstractSalesPersonsController: AbstractEntityFrameworkApiController
	{
		protected ISalesPersonRepository _salesPersonRepository;
		protected ISalesPersonModelValidator _salesPersonModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSalesPersonsController(
			ILogger<AbstractSalesPersonsController> logger,
			ApplicationContext context,
			ISalesPersonRepository salesPersonRepository,
			ISalesPersonModelValidator salesPersonModelValidator
			) : base(logger,context)
		{
			this._salesPersonRepository = salesPersonRepository;
			this._salesPersonModelValidator = salesPersonModelValidator;
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
		[SalesPersonFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._salesPersonRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SalesPersonFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._salesPersonRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SalesPersonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(SalesPersonModel model)
		{
			this._salesPersonModelValidator.CreateMode();
			var validationResult = this._salesPersonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._salesPersonRepository.Create(model.TerritoryID,
				                                            model.SalesQuota,
				                                            model.Bonus,
				                                            model.CommissionPct,
				                                            model.SalesYTD,
				                                            model.SalesLastYear,
				                                            model.Rowguid,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[SalesPersonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<SalesPersonModel> models)
		{
			this._salesPersonModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._salesPersonModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._salesPersonRepository.Create(model.TerritoryID,
				                                   model.SalesQuota,
				                                   model.Bonus,
				                                   model.CommissionPct,
				                                   model.SalesYTD,
				                                   model.SalesLastYear,
				                                   model.Rowguid,
				                                   model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SalesPersonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int businessEntityID,SalesPersonModel model)
		{
			this._salesPersonModelValidator.UpdateMode();
			var validationResult = this._salesPersonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._salesPersonRepository.Update(businessEntityID,  model.TerritoryID,
				                                   model.SalesQuota,
				                                   model.Bonus,
				                                   model.CommissionPct,
				                                   model.SalesYTD,
				                                   model.SalesLastYear,
				                                   model.Rowguid,
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
		[SalesPersonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._salesPersonRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>1824052646862e5be6312e5f10438a57</Hash>
</Codenesium>*/