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
	public abstract class AbstractSalesOrderHeaderSalesReasonController: AbstractApiController
	{
		protected ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository;

		protected ISalesOrderHeaderSalesReasonModelValidator salesOrderHeaderSalesReasonModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSalesOrderHeaderSalesReasonController(
			ILogger<AbstractSalesOrderHeaderSalesReasonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
			ISalesOrderHeaderSalesReasonModelValidator salesOrderHeaderSalesReasonModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.salesOrderHeaderSalesReasonRepository = salesOrderHeaderSalesReasonRepository;
			this.salesOrderHeaderSalesReasonModelValidator = salesOrderHeaderSalesReasonModelValidator;
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
		[SalesOrderHeaderSalesReasonFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.salesOrderHeaderSalesReasonRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SalesOrderHeaderSalesReasonFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.salesOrderHeaderSalesReasonRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SalesOrderHeaderSalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] SalesOrderHeaderSalesReasonModel model)
		{
			this.salesOrderHeaderSalesReasonModelValidator.CreateMode();
			var validationResult = this.salesOrderHeaderSalesReasonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.salesOrderHeaderSalesReasonRepository.Create(
					model.SalesReasonID,
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
		[SalesOrderHeaderSalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<SalesOrderHeaderSalesReasonModel> models)
		{
			this.salesOrderHeaderSalesReasonModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.salesOrderHeaderSalesReasonModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.salesOrderHeaderSalesReasonRepository.Create(
					model.SalesReasonID,
					model.ModifiedDate);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SalesOrderHeaderSalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] SalesOrderHeaderSalesReasonModel model)
		{
			if (this.salesOrderHeaderSalesReasonRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.salesOrderHeaderSalesReasonModelValidator.UpdateMode();
			var validationResult = this.salesOrderHeaderSalesReasonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.salesOrderHeaderSalesReasonRepository.Update(
					id,
					model.SalesReasonID,
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
		[SalesOrderHeaderSalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.salesOrderHeaderSalesReasonRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("BySalesOrderID/{id}")]
		[SalesOrderHeaderSalesReasonFilter]
		[ReadOnlyFilter]
		[Route("~/api/SalesOrderHeaders/{id}/SalesOrderHeaderSalesReasons")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult BySalesOrderID(int id)
		{
			Response response = this.salesOrderHeaderSalesReasonRepository.GetWhere(x => x.SalesOrderID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("BySalesReasonID/{id}")]
		[SalesOrderHeaderSalesReasonFilter]
		[ReadOnlyFilter]
		[Route("~/api/SalesReasons/{id}/SalesOrderHeaderSalesReasons")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult BySalesReasonID(int id)
		{
			Response response = this.salesOrderHeaderSalesReasonRepository.GetWhere(x => x.SalesReasonID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>0efd4f123e506e2d1567707e853672ba</Hash>
</Codenesium>*/