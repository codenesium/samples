using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Service
{
	public abstract class AbstractFileTypesController: AbstractApiController
	{
		protected IFileTypeRepository fileTypeRepository;
		protected IFileTypeModelValidator fileTypeModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractFileTypesController(
			ILogger<AbstractFileTypesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFileTypeRepository fileTypeRepository,
			IFileTypeModelValidator fileTypeModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.fileTypeRepository = fileTypeRepository;
			this.fileTypeModelValidator = fileTypeModelValidator;
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
		[FileTypeFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.fileTypeRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[FileTypeFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.fileTypeRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[FileTypeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(FileTypeModel model)
		{
			this.fileTypeModelValidator.CreateMode();
			var validationResult = this.fileTypeModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.fileTypeRepository.Create(model.Name);
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
		[FileTypeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<FileTypeModel> models)
		{
			this.fileTypeModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.fileTypeModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.fileTypeRepository.Create(model.Name);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[FileTypeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int Id,FileTypeModel model)
		{
			this.fileTypeModelValidator.UpdateMode();
			var validationResult = this.fileTypeModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.fileTypeRepository.Update(Id,  model.Name);
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
		[FileTypeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.fileTypeRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>4f34c489fb1b281493a8750c61cdb030</Hash>
</Codenesium>*/