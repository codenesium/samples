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
	public abstract class AbstractFileController: AbstractApiController
	{
		protected IFileRepository fileRepository;

		protected IFileModelValidator fileModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractFileController(
			ILogger<AbstractFileController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFileRepository fileRepository,
			IFileModelValidator fileModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.fileRepository = fileRepository;
			this.fileModelValidator = fileModelValidator;
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
		[FileFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.fileRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[FileFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.fileRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[FileFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] FileModel model)
		{
			this.fileModelValidator.CreateMode();
			var validationResult = this.fileModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.fileRepository.Create(
					model.ExternalId,
					model.PrivateKey,
					model.PublicKey,
					model.Location,
					model.Expiration,
					model.Extension,
					model.DateCreated,
					model.FileSizeInBytes,
					model.FileTypeId,
					model.BucketId,
					model.Description);
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
		[FileFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<FileModel> models)
		{
			this.fileModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.fileModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.fileRepository.Create(
					model.ExternalId,
					model.PrivateKey,
					model.PublicKey,
					model.Location,
					model.Expiration,
					model.Extension,
					model.DateCreated,
					model.FileSizeInBytes,
					model.FileTypeId,
					model.BucketId,
					model.Description);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[FileFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] FileModel model)
		{
			if (this.fileRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.fileModelValidator.UpdateMode();
			var validationResult = this.fileModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.fileRepository.Update(
					id,
					model.ExternalId,
					model.PrivateKey,
					model.PublicKey,
					model.Location,
					model.Expiration,
					model.Extension,
					model.DateCreated,
					model.FileSizeInBytes,
					model.FileTypeId,
					model.BucketId,
					model.Description);
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
		[FileFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.fileRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByFileTypeId/{id}")]
		[FileFilter]
		[ReadOnlyFilter]
		[Route("~/api/FileTypes/{id}/Files")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByFileTypeId(int id)
		{
			Response response = this.fileRepository.GetWhere(x => x.FileTypeId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByBucketId/{id}")]
		[FileFilter]
		[ReadOnlyFilter]
		[Route("~/api/Buckets/{id}/Files")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBucketId(int id)
		{
			Response response = this.fileRepository.GetWhere(x => x.BucketId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>4a4fc36420d391678f5b9daf2fc4400e</Hash>
</Codenesium>*/