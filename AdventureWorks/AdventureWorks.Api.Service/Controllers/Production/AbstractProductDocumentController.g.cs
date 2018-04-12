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
	public abstract class AbstractProductDocumentController: AbstractApiController
	{
		protected IProductDocumentRepository productDocumentRepository;

		protected IProductDocumentModelValidator productDocumentModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractProductDocumentController(
			ILogger<AbstractProductDocumentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductDocumentRepository productDocumentRepository,
			IProductDocumentModelValidator productDocumentModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.productDocumentRepository = productDocumentRepository;
			this.productDocumentModelValidator = productDocumentModelValidator;
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
		[ProductDocumentFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.productDocumentRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductDocumentFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.productDocumentRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductDocumentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] ProductDocumentModel model)
		{
			this.productDocumentModelValidator.CreateMode();
			var validationResult = this.productDocumentModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.productDocumentRepository.Create(
					model.DocumentNode,
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
		[ProductDocumentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<ProductDocumentModel> models)
		{
			this.productDocumentModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.productDocumentModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.productDocumentRepository.Create(
					model.DocumentNode,
					model.ModifiedDate);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductDocumentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] ProductDocumentModel model)
		{
			if (this.productDocumentRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.productDocumentModelValidator.UpdateMode();
			var validationResult = this.productDocumentModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.productDocumentRepository.Update(
					id,
					model.DocumentNode,
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
		[ProductDocumentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.productDocumentRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByProductID/{id}")]
		[ProductDocumentFilter]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/ProductDocuments")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			Response response = this.productDocumentRepository.GetWhere(x => x.ProductID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByDocumentNode/{id}")]
		[ProductDocumentFilter]
		[ReadOnlyFilter]
		[Route("~/api/Documents/{id}/ProductDocuments")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByDocumentNode(Guid id)
		{
			Response response = this.productDocumentRepository.GetWhere(x => x.DocumentNode == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>18a5d2c6cc2703c455227a312087f5a9</Hash>
</Codenesium>*/