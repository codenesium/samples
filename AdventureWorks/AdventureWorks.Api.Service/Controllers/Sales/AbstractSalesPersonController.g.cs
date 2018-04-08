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
	public abstract class AbstractSalesPersonsController: AbstractApiController
	{
		protected ISalesPersonRepository salesPersonRepository;
		protected ISalesPersonModelValidator salesPersonModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSalesPersonsController(
			ILogger<AbstractSalesPersonsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesPersonRepository salesPersonRepository,
			ISalesPersonModelValidator salesPersonModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.salesPersonRepository = salesPersonRepository;
			this.salesPersonModelValidator = salesPersonModelValidator;
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

			this.salesPersonRepository.GetById(id,response);
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

			this.salesPersonRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this.salesPersonModelValidator.CreateMode();
			var validationResult = this.salesPersonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.salesPersonRepository.Create(model.TerritoryID,
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
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[SalesPersonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<SalesPersonModel> models)
		{
			this.salesPersonModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.salesPersonModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.salesPersonRepository.Create(model.TerritoryID,
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
		public virtual IActionResult Update(int BusinessEntityID,SalesPersonModel model)
		{
			this.salesPersonModelValidator.UpdateMode();
			var validationResult = this.salesPersonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.salesPersonRepository.Update(BusinessEntityID,  model.TerritoryID,
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
			this.salesPersonRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[SalesPersonFilter]
		[ReadOnlyFilter]
		[Route("~/api/Employees/{id}/SalesPersons")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			var response = new Response();

			this.salesPersonRepository.GetWhere(x => x.BusinessEntityID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByTerritoryID/{id}")]
		[SalesPersonFilter]
		[ReadOnlyFilter]
		[Route("~/api/SalesTerritories/{id}/SalesPersons")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByTerritoryID(int id)
		{
			var response = new Response();

			this.salesPersonRepository.GetWhere(x => x.TerritoryID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>46c8e933b8bd6009ec9279bac9c6493d</Hash>
</Codenesium>*/