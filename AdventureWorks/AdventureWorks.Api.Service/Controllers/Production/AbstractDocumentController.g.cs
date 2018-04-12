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
	public abstract class AbstractDocumentController: AbstractApiController
	{
		protected IDocumentRepository documentRepository;

		protected IDocumentModelValidator documentModelValidator;

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractDocumentController(
			ILogger<AbstractDocumentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDocumentRepository documentRepository,
			IDocumentModelValidator documentModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.documentRepository = documentRepository;
			this.documentModelValidator = documentModelValidator;
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
		[DocumentFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(Guid id)
		{
			Response response = this.documentRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[DocumentFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.documentRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[DocumentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(DocumentModel model)
		{
			this.documentModelValidator.CreateMode();
			var validationResult = this.documentModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.documentRepository.Create(
					model.DocumentLevel,
					model.Title,
					model.Owner,
					model.FolderFlag,
					model.FileName,
					model.FileExtension,
					model.Revision,
					model.ChangeNumber,
					model.Status,
					model.DocumentSummary,
					model.Document1,
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
		[DocumentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<DocumentModel> models)
		{
			this.documentModelValidator.CreateMode();
			foreach (var model in models)
			{
				var validationResult = this.documentModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.documentRepository.Create(
					model.DocumentLevel,
					model.Title,
					model.Owner,
					model.FolderFlag,
					model.FileName,
					model.FileExtension,
					model.Revision,
					model.ChangeNumber,
					model.Status,
					model.DocumentSummary,
					model.Document1,
					model.Rowguid,
					model.ModifiedDate);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[DocumentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(Guid id, DocumentModel model)
		{
			if (this.documentRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.documentModelValidator.UpdateMode();
			var validationResult = this.documentModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.documentRepository.Update(
					id,
					model.DocumentLevel,
					model.Title,
					model.Owner,
					model.FolderFlag,
					model.FileName,
					model.FileExtension,
					model.Revision,
					model.ChangeNumber,
					model.Status,
					model.DocumentSummary,
					model.Document1,
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
		[DocumentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(Guid id)
		{
			this.documentRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByOwner/{id}")]
		[DocumentFilter]
		[ReadOnlyFilter]
		[Route("~/api/Employees/{id}/Documents")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByOwner(int id)
		{
			Response response = this.documentRepository.GetWhere(x => x.Owner == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>6a9c804a3c9555c87338d3f77d2cac80</Hash>
</Codenesium>*/