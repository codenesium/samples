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
	public abstract class AbstractDocumentsController: AbstractEntityFrameworkApiController
	{
		protected IDocumentRepository _documentRepository;
		protected IDocumentModelValidator _documentModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractDocumentsController(
			ILogger<AbstractDocumentsController> logger,
			ApplicationContext context,
			IDocumentRepository documentRepository,
			IDocumentModelValidator documentModelValidator
			) : base(logger,context)
		{
			this._documentRepository = documentRepository;
			this._documentModelValidator = documentModelValidator;
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
		[DocumentFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(Guid id)
		{
			Response response = new Response();

			this._documentRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[DocumentFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._documentRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
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
			this._documentModelValidator.CreateMode();
			var validationResult = this._documentModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._documentRepository.Create(model.DocumentLevel,
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
		[DocumentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<DocumentModel> models)
		{
			this._documentModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._documentModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._documentRepository.Create(model.DocumentLevel,
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
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[DocumentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(Guid DocumentNode,DocumentModel model)
		{
			this._documentModelValidator.UpdateMode();
			var validationResult = this._documentModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._documentRepository.Update(DocumentNode,  model.DocumentLevel,
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
		[DocumentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(Guid id)
		{
			this._documentRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByOwner/{id}")]
		[DocumentFilter]
		[ReadOnlyFilter]
		[Route("~/api/Employees/{id}/Documents")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByOwner(int id)
		{
			var response = new Response();

			this._documentRepository.GetWhere(x => x.Owner == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>e326af6b8a8c77f0443b6290edfd29fc</Hash>
</Codenesium>*/