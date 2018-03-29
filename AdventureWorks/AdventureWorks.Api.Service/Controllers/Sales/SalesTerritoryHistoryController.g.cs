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
	public abstract class AbstractSalesTerritoryHistoriesController: AbstractEntityFrameworkApiController
	{
		protected ISalesTerritoryHistoryRepository _salesTerritoryHistoryRepository;
		protected ISalesTerritoryHistoryModelValidator _salesTerritoryHistoryModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSalesTerritoryHistoriesController(
			ILogger<AbstractSalesTerritoryHistoriesController> logger,
			ApplicationContext context,
			ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository,
			ISalesTerritoryHistoryModelValidator salesTerritoryHistoryModelValidator
			) : base(logger,context)
		{
			this._salesTerritoryHistoryRepository = salesTerritoryHistoryRepository;
			this._salesTerritoryHistoryModelValidator = salesTerritoryHistoryModelValidator;
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
		[SalesTerritoryHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._salesTerritoryHistoryRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SalesTerritoryHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._salesTerritoryHistoryRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SalesTerritoryHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(SalesTerritoryHistoryModel model)
		{
			this._salesTerritoryHistoryModelValidator.CreateMode();
			var validationResult = this._salesTerritoryHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._salesTerritoryHistoryRepository.Create(model.TerritoryID,
				                                                      model.StartDate,
				                                                      model.EndDate,
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
		[SalesTerritoryHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<SalesTerritoryHistoryModel> models)
		{
			this._salesTerritoryHistoryModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._salesTerritoryHistoryModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._salesTerritoryHistoryRepository.Create(model.TerritoryID,
				                                             model.StartDate,
				                                             model.EndDate,
				                                             model.Rowguid,
				                                             model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SalesTerritoryHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int BusinessEntityID,SalesTerritoryHistoryModel model)
		{
			this._salesTerritoryHistoryModelValidator.UpdateMode();
			var validationResult = this._salesTerritoryHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._salesTerritoryHistoryRepository.Update(BusinessEntityID,  model.TerritoryID,
				                                             model.StartDate,
				                                             model.EndDate,
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
		[SalesTerritoryHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._salesTerritoryHistoryRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[SalesTerritoryHistoryFilter]
		[ReadOnlyFilter]
		[Route("~/api/SalesPersons/{id}/SalesTerritoryHistories")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			var response = new Response();

			this._salesTerritoryHistoryRepository.GetWhere(x => x.BusinessEntityID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByTerritoryID/{id}")]
		[SalesTerritoryHistoryFilter]
		[ReadOnlyFilter]
		[Route("~/api/SalesTerritories/{id}/SalesTerritoryHistories")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByTerritoryID(int id)
		{
			var response = new Response();

			this._salesTerritoryHistoryRepository.GetWhere(x => x.TerritoryID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>26fc900ccfaff161195791d15a04979e</Hash>
</Codenesium>*/