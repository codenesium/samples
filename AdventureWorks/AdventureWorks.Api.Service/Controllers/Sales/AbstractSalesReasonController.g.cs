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
	public abstract class AbstractSalesReasonController: AbstractApiController
	{
		protected ISalesReasonRepository salesReasonRepository;

		protected ISalesReasonModelValidator salesReasonModelValidator;

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSalesReasonController(
			ILogger<AbstractSalesReasonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesReasonRepository salesReasonRepository,
			ISalesReasonModelValidator salesReasonModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.salesReasonRepository = salesReasonRepository;
			this.salesReasonModelValidator = salesReasonModelValidator;
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
		[SalesReasonFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.salesReasonRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SalesReasonFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.salesReasonRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(SalesReasonModel model)
		{
			this.salesReasonModelValidator.CreateMode();
			var validationResult = this.salesReasonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.salesReasonRepository.Create(
					model.Name,
					model.ReasonType,
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
		[SalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<SalesReasonModel> models)
		{
			this.salesReasonModelValidator.CreateMode();
			foreach (var model in models)
			{
				var validationResult = this.salesReasonModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.salesReasonRepository.Create(
					model.Name,
					model.ReasonType,
					model.ModifiedDate);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, SalesReasonModel model)
		{
			if (this.salesReasonRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.salesReasonModelValidator.UpdateMode();
			var validationResult = this.salesReasonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.salesReasonRepository.Update(
					id,
					model.Name,
					model.ReasonType,
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
		[SalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.salesReasonRepository.Delete(id);
			return this.Ok();
		}
	}
}

/*<Codenesium>
    <Hash>a380ce0baae7da5a2aafb0b869e75a6c</Hash>
</Codenesium>*/