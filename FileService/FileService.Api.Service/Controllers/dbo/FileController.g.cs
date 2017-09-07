using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using JsonPatch;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Service
{
	public class FilesControllerAbstract: AbstractEntityFrameworkApiController
	{
		protected FileRepository _fileRepository;
		protected FileModelValidator _fileModelValidator;
		protected int SearchRecordLimit {get; set;} = 1000;
		protected int SearchRecordDefault {get; set;} = 250;
		public FilesControllerAbstract(
			ILogger logger,
			DbContext context,
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
		public virtual IHttpActionResult Get(int id)
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
		public virtual IHttpActionResult Search()
		{
			var queryParameters = ControllerContext.Request.GetQueryNameValuePairs();
			string whereClause = String.Empty;

			int offset = 0;
			int limit = this.SearchRecordDefault;

			if (!queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "OFFSET").Equals(default (KeyValuePair<string, string>)))
			{
				offset = queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "OFFSET").Value.ToInt();
			}

			if (!queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "LIMIT").Equals(default (KeyValuePair<string, string>)))
			{
				limit = queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "LIMIT").Value.ToInt();
			}

			if(limit > this.SearchRecordLimit)
			{
				return BadRequest($"Limit of {limit} exceeds maximum request size of {this.SearchRecordLimit} records");
			}

			foreach(var parameter in queryParameters)
			{
				if(parameter.Key.ToUpper() == "OFFSET" || parameter.Key.ToUpper() == "LIMIT")
				{
					continue;
				}

				if(!String.IsNullOrEmpty(whereClause))
				{
					whereClause += " && ";
				}

				if (parameter.Value.ToNullableInt() != null)
				{
					whereClause += $"{parameter.Key}.Equals({parameter.Value})";
				}
				else if (parameter.Value.ToNullableGuid() != null)
				{
					whereClause += $"{parameter.Key}.Equals(Guid(\"{parameter.Value}\"))";
				}
				else
				{
					whereClause += $"{parameter.Key}.Equals(\"{parameter.Value}\")";
				}
			}
			if(String.IsNullOrWhiteSpace(whereClause))
			{
				whereClause = "1=1";
			}
			Response response = new Response();

			this._fileRepository.GetWhereDynamic(whereClause,response,offset,limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[FileFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Create(FileModel model)
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
		public virtual IHttpActionResult CreateMany(List<FileModel> models)
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
		public virtual IHttpActionResult Update(int id,FileModel model)
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

		[HttpPatch]
		[Route("{id}")]
		[ModelValidateFilter]
		[FileFilter]
		[UnitOfWorkActionFilter]
		public IHttpActionResult Patch(int id, JsonPatchDocument<FileModel> patch)
		{
			Response response = new Response();

			this._fileRepository.GetById(id, response);
			if (response.Files.Count > 0)
			{
				var model = new FileModel(response.Files.First());

				patch.ApplyUpdatesTo(model);
				this._fileModelValidator.PatchMode();
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
			else
			{
				return BadRequest("Entity not found");
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[ModelValidateFilter]
		[FileFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Delete(int id)
		{
			this._fileRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByBucketId/{id}")]
		[FileFilter]
		[ReadOnlyFilter]
		[Route("~/api/Buckets/{id}/Files")]
		public virtual IHttpActionResult ByBucketId(int id)
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
		public virtual IHttpActionResult ByFileTypeId(int id)
		{
			var response = new Response();

			this._fileRepository.GetWhere(x => x.fileTypeId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>10868ea8f0e128a45ca8415e0e1c4cc8</Hash>
</Codenesium>*/