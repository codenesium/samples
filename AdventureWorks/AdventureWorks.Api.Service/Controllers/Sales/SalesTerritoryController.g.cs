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
	public abstract class AbstractSalesTerritoriesController: AbstractEntityFrameworkApiController
	{
		protected ISalesTerritoryRepository _salesTerritoryRepository;
		protected ISalesTerritoryModelValidator _salesTerritoryModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSalesTerritoriesController(
			ILogger<AbstractSalesTerritoriesController> logger,
			ApplicationContext context,
			ISalesTerritoryRepository salesTerritoryRepository,
			ISalesTerritoryModelValidator salesTerritoryModelValidator
			) : base(logger,context)
		{
			this._salesTerritoryRepository = salesTerritoryRepository;
			this._salesTerritoryModelValidator = salesTerritoryModelValidator;
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
			Response response = new Response();

			this._salesTerritoryRepository.GetById(id,response);
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
			Response response = new Response();

			this._salesTerritoryRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._salesTerritoryModelValidator.CreateMode();
			var validationResult = this._salesTerritoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._salesTerritoryRepository.Create(model.Name,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[SalesTerritoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<SalesTerritoryModel> models)
		{
			this._salesTerritoryModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._salesTerritoryModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._salesTerritoryRepository.Create(model.Name,
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
		public virtual IActionResult Update(int territoryID,SalesTerritoryModel model)
		{
			this._salesTerritoryModelValidator.UpdateMode();
			var validationResult = this._salesTerritoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._salesTerritoryRepository.Update(territoryID,  model.Name,
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
			this._salesTerritoryRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>ef5da5e60fe9dcf2fb9231d620ff0350</Hash>
</Codenesium>*/