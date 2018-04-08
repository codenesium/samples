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
	public abstract class AbstractSalesPersonQuotaHistoriesController: AbstractApiController
	{
		protected ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository;
		protected ISalesPersonQuotaHistoryModelValidator salesPersonQuotaHistoryModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSalesPersonQuotaHistoriesController(
			ILogger<AbstractSalesPersonQuotaHistoriesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository,
			ISalesPersonQuotaHistoryModelValidator salesPersonQuotaHistoryModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.salesPersonQuotaHistoryRepository = salesPersonQuotaHistoryRepository;
			this.salesPersonQuotaHistoryModelValidator = salesPersonQuotaHistoryModelValidator;
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
		[SalesPersonQuotaHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.salesPersonQuotaHistoryRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SalesPersonQuotaHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.salesPersonQuotaHistoryRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SalesPersonQuotaHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(SalesPersonQuotaHistoryModel model)
		{
			this.salesPersonQuotaHistoryModelValidator.CreateMode();
			var validationResult = this.salesPersonQuotaHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.salesPersonQuotaHistoryRepository.Create(model.QuotaDate,
				                                                       model.SalesQuota,
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
		[SalesPersonQuotaHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<SalesPersonQuotaHistoryModel> models)
		{
			this.salesPersonQuotaHistoryModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.salesPersonQuotaHistoryModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.salesPersonQuotaHistoryRepository.Create(model.QuotaDate,
				                                              model.SalesQuota,
				                                              model.Rowguid,
				                                              model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SalesPersonQuotaHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int BusinessEntityID,SalesPersonQuotaHistoryModel model)
		{
			this.salesPersonQuotaHistoryModelValidator.UpdateMode();
			var validationResult = this.salesPersonQuotaHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.salesPersonQuotaHistoryRepository.Update(BusinessEntityID,  model.QuotaDate,
				                                              model.SalesQuota,
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
		[SalesPersonQuotaHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.salesPersonQuotaHistoryRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[SalesPersonQuotaHistoryFilter]
		[ReadOnlyFilter]
		[Route("~/api/SalesPersons/{id}/SalesPersonQuotaHistories")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			var response = new Response();

			this.salesPersonQuotaHistoryRepository.GetWhere(x => x.BusinessEntityID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>07dbee6e8766287be3fd46e31e1b564d</Hash>
</Codenesium>*/