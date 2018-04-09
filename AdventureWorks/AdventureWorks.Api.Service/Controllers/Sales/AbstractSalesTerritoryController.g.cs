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
	public abstract class AbstractSalesTerritoriesController: AbstractApiController
	{
		protected ISalesTerritoryRepository salesTerritoryRepository;
		protected ISalesTerritoryModelValidator salesTerritoryModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSalesTerritoriesController(
			ILogger<AbstractSalesTerritoriesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesTerritoryRepository salesTerritoryRepository,
			ISalesTerritoryModelValidator salesTerritoryModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.salesTerritoryRepository = salesTerritoryRepository;
			this.salesTerritoryModelValidator = salesTerritoryModelValidator;
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
		[SalesTerritoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.salesTerritoryRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SalesTerritoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.salesTerritoryRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SalesTerritoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(SalesTerritoryModel model)
		{
			this.salesTerritoryModelValidator.CreateMode();
			var validationResult = this.salesTerritoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.salesTerritoryRepository.Create(model.Name,
				                                              model.CountryRegionCode,
				                                              model.@Group,
				                                              model.SalesYTD,
				                                              model.SalesLastYear,
				                                              model.CostYTD,
				                                              model.CostLastYear,
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
		[SalesTerritoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<SalesTerritoryModel> models)
		{
			this.salesTerritoryModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.salesTerritoryModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.salesTerritoryRepository.Create(model.Name,
				                                     model.CountryRegionCode,
				                                     model.@Group,
				                                     model.SalesYTD,
				                                     model.SalesLastYear,
				                                     model.CostYTD,
				                                     model.CostLastYear,
				                                     model.Rowguid,
				                                     model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SalesTerritoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,SalesTerritoryModel model)
		{
			if(this.salesTerritoryRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.salesTerritoryModelValidator.UpdateMode();
			var validationResult = this.salesTerritoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.salesTerritoryRepository.Update(id,  model.Name,
				                                     model.CountryRegionCode,
				                                     model.@Group,
				                                     model.SalesYTD,
				                                     model.SalesLastYear,
				                                     model.CostYTD,
				                                     model.CostLastYear,
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
		[SalesTerritoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.salesTerritoryRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByCountryRegionCode/{id}")]
		[SalesTerritoryFilter]
		[ReadOnlyFilter]
		[Route("~/api/CountryRegions/{id}/SalesTerritories")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByCountryRegionCode(string id)
		{
			Response response = this.salesTerritoryRepository.GetWhere(x => x.CountryRegionCode == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>72196a1821cda5236579ec125f975fff</Hash>
</Codenesium>*/