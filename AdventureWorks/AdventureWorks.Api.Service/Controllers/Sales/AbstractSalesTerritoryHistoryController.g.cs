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
	public abstract class AbstractSalesTerritoryHistoryController: AbstractApiController
	{
		protected ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository;

		protected ISalesTerritoryHistoryModelValidator salesTerritoryHistoryModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSalesTerritoryHistoryController(
			ILogger<AbstractSalesTerritoryHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository,
			ISalesTerritoryHistoryModelValidator salesTerritoryHistoryModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.salesTerritoryHistoryRepository = salesTerritoryHistoryRepository;
			this.salesTerritoryHistoryModelValidator = salesTerritoryHistoryModelValidator;
		}

		protected void AddErrors(ValidationResult result)
		{
			foreach (var error in result.Errors)
			{
				this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}
		}

		[HttpGet]
		[Route("{id}")]
		[SalesTerritoryHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.salesTerritoryHistoryRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SalesTerritoryHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.salesTerritoryHistoryRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SalesTerritoryHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] SalesTerritoryHistoryModel model)
		{
			this.salesTerritoryHistoryModelValidator.CreateMode();
			var validationResult = this.salesTerritoryHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.salesTerritoryHistoryRepository.Create(
					model.TerritoryID,
					model.StartDate,
					model.EndDate,
					model.Rowguid,
					model.ModifiedDate);
				return this.Ok(id);
			}
			else
			{
				this.AddErrors(validationResult);
				return this.BadRequest(this.ModelState);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[SalesTerritoryHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<SalesTerritoryHistoryModel> models)
		{
			this.salesTerritoryHistoryModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.salesTerritoryHistoryModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.salesTerritoryHistoryRepository.Create(
					model.TerritoryID,
					model.StartDate,
					model.EndDate,
					model.Rowguid,
					model.ModifiedDate);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SalesTerritoryHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] SalesTerritoryHistoryModel model)
		{
			if (this.salesTerritoryHistoryRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.salesTerritoryHistoryModelValidator.UpdateMode();
			var validationResult = this.salesTerritoryHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.salesTerritoryHistoryRepository.Update(
					id,
					model.TerritoryID,
					model.StartDate,
					model.EndDate,
					model.Rowguid,
					model.ModifiedDate);
				return this.Ok();
			}
			else
			{
				this.AddErrors(validationResult);
				return this.BadRequest(this.ModelState);
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
			this.salesTerritoryHistoryRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[SalesTerritoryHistoryFilter]
		[ReadOnlyFilter]
		[Route("~/api/SalesPersons/{id}/SalesTerritoryHistories")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			Response response = this.salesTerritoryHistoryRepository.GetWhere(x => x.BusinessEntityID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByTerritoryID/{id}")]
		[SalesTerritoryHistoryFilter]
		[ReadOnlyFilter]
		[Route("~/api/SalesTerritories/{id}/SalesTerritoryHistories")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByTerritoryID(int id)
		{
			Response response = this.salesTerritoryHistoryRepository.GetWhere(x => x.TerritoryID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>86edbcb23040356aa869b240810a6b17</Hash>
</Codenesium>*/