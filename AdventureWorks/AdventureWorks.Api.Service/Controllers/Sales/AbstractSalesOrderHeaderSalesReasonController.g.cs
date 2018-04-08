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
	public abstract class AbstractSalesOrderHeaderSalesReasonsController: AbstractApiController
	{
		protected ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository;
		protected ISalesOrderHeaderSalesReasonModelValidator salesOrderHeaderSalesReasonModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSalesOrderHeaderSalesReasonsController(
			ILogger<AbstractSalesOrderHeaderSalesReasonsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
			ISalesOrderHeaderSalesReasonModelValidator salesOrderHeaderSalesReasonModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.salesOrderHeaderSalesReasonRepository = salesOrderHeaderSalesReasonRepository;
			this.salesOrderHeaderSalesReasonModelValidator = salesOrderHeaderSalesReasonModelValidator;
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
		[SalesOrderHeaderSalesReasonFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.salesOrderHeaderSalesReasonRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SalesOrderHeaderSalesReasonFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.salesOrderHeaderSalesReasonRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SalesOrderHeaderSalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(SalesOrderHeaderSalesReasonModel model)
		{
			this.salesOrderHeaderSalesReasonModelValidator.CreateMode();
			var validationResult = this.salesOrderHeaderSalesReasonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.salesOrderHeaderSalesReasonRepository.Create(model.SalesReasonID,
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
		[SalesOrderHeaderSalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<SalesOrderHeaderSalesReasonModel> models)
		{
			this.salesOrderHeaderSalesReasonModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.salesOrderHeaderSalesReasonModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.salesOrderHeaderSalesReasonRepository.Create(model.SalesReasonID,
				                                                  model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SalesOrderHeaderSalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int SalesOrderID,SalesOrderHeaderSalesReasonModel model)
		{
			this.salesOrderHeaderSalesReasonModelValidator.UpdateMode();
			var validationResult = this.salesOrderHeaderSalesReasonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.salesOrderHeaderSalesReasonRepository.Update(SalesOrderID,  model.SalesReasonID,
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
		[SalesOrderHeaderSalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.salesOrderHeaderSalesReasonRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("BySalesOrderID/{id}")]
		[SalesOrderHeaderSalesReasonFilter]
		[ReadOnlyFilter]
		[Route("~/api/SalesOrderHeaders/{id}/SalesOrderHeaderSalesReasons")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult BySalesOrderID(int id)
		{
			var response = new Response();

			this.salesOrderHeaderSalesReasonRepository.GetWhere(x => x.SalesOrderID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("BySalesReasonID/{id}")]
		[SalesOrderHeaderSalesReasonFilter]
		[ReadOnlyFilter]
		[Route("~/api/SalesReasons/{id}/SalesOrderHeaderSalesReasons")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult BySalesReasonID(int id)
		{
			var response = new Response();

			this.salesOrderHeaderSalesReasonRepository.GetWhere(x => x.SalesReasonID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>922a1313430f868b71b606003adce148</Hash>
</Codenesium>*/