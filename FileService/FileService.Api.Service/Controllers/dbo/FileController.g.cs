using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Service
{
	public abstract class AbstractFilesController: AbstractEntityFrameworkApiController
	{
		protected FileRepository _fileRepository;
		protected FileModelValidator _fileModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractFilesController(
			ILogger<AbstractFilesController> logger,
			ApplicationContext context,
			FileRepository fileRepository,
			FileModelValidator fileModelValidator
			) : base(logger,context)
		{
			this._fileRepository = fileRepository;
			this._fileModelValidator = fileModelValidator;
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
		[FileFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._fileRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[FileFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._fileRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[FileFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), 400)]
		public virtual IActionResult Create(FileModel model)
		{
			this._fileModelValidator.CreateMode();
			var validationResult = this._fileModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._fileRepository.Create(model.BucketId,
				                                     model.DateCreated,
				                                     model.Description,
				                                     model.Expiration,
				                                     model.Extension,
				                                     model.ExternalId,
				                                     model.FileSizeInBytes,
				                                     model.FileTypeId,
				                                     model.Id,
				                                     model.Location,
				                                     model.PrivateKey,
				                                     model.PublicKey);
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
		[FileFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<FileModel> models)
		{
			this._fileModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._fileModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._fileRepository.Create(model.BucketId,
				                            model.DateCreated,
				                            model.Description,
				                            model.Expiration,
				                            model.Extension,
				                            model.ExternalId,
				                            model.FileSizeInBytes,
				                            model.FileTypeId,
				                            model.Id,
				                            model.Location,
				                            model.PrivateKey,
				                            model.PublicKey);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[FileFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,FileModel model)
		{
			this._fileModelValidator.UpdateMode();
			var validationResult = this._fileModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._fileRepository.Update(model.BucketId,
				                            model.DateCreated,
				                            model.Description,
				                            model.Expiration,
				                            model.Extension,
				                            model.ExternalId,
				                            model.FileSizeInBytes,
				                            model.FileTypeId,
				                            model.Id,
				                            model.Location,
				                            model.PrivateKey,
				                            model.PublicKey);
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
		[FileFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._fileRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByBucketId/{id}")]
		[FileFilter]
		[ReadOnlyFilter]
		[Route("~/api/Buckets/{id}/Files")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBucketId(int id)
		{
			var response = new Response();

			this._fileRepository.GetWhere(x => x.bucketId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByFileTypeId/{id}")]
		[FileFilter]
		[ReadOnlyFilter]
		[Route("~/api/FileTypes/{id}/Files")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByFileTypeId(int id)
		{
			var response = new Response();

			this._fileRepository.GetWhere(x => x.fileTypeId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>37aadd5ef82603e94988ae7d5d797259</Hash>
</Codenesium>*/