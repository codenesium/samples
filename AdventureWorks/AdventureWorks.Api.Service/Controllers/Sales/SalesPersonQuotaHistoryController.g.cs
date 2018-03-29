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
	public abstract class AbstractSalesPersonQuotaHistoriesController: AbstractEntityFrameworkApiController
	{
		protected ISalesPersonQuotaHistoryRepository _salesPersonQuotaHistoryRepository;
		protected ISalesPersonQuotaHistoryModelValidator _salesPersonQuotaHistoryModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSalesPersonQuotaHistoriesController(
			ILogger<AbstractSalesPersonQuotaHistoriesController> logger,
			ApplicationContext context,
			ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository,
			ISalesPersonQuotaHistoryModelValidator salesPersonQuotaHistoryModelValidator
			) : base(logger,context)
		{
			this._salesPersonQuotaHistoryRepository = salesPersonQuotaHistoryRepository;
			this._salesPersonQuotaHistoryModelValidator = salesPersonQuotaHistoryModelValidator;
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

			this._salesPersonQuotaHistoryRepository.GetById(id,response);
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

			this._salesPersonQuotaHistoryRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._salesPersonQuotaHistoryModelValidator.CreateMode();
			var validationResult = this._salesPersonQuotaHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._salesPersonQuotaHistoryRepository.Create(model.QuotaDate,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[SalesPersonQuotaHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<SalesPersonQuotaHistoryModel> models)
		{
			this._salesPersonQuotaHistoryModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._salesPersonQuotaHistoryModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._salesPersonQuotaHistoryRepository.Create(model.QuotaDate,
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
			this._salesPersonQuotaHistoryModelValidator.UpdateMode();
			var validationResult = this._salesPersonQuotaHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._salesPersonQuotaHistoryRepository.Update(BusinessEntityID,  model.QuotaDate,
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
			this._salesPersonQuotaHistoryRepository.Delete(id);
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

			this._salesPersonQuotaHistoryRepository.GetWhere(x => x.BusinessEntityID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>edeb96ac504890ec052cb7d7f9850161</Hash>
</Codenesium>*/