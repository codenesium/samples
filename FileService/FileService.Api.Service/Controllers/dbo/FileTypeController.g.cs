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
	public class FileTypesControllerAbstract: AbstractEntityFrameworkApiController
	{
		protected FileTypeRepository _fileTypeRepository;
		protected FileTypeModelValidator _fileTypeModelValidator;
		protected int SearchRecordLimit {get; set;} = 1000;
		protected int SearchRecordDefault {get; set;} = 250;
		public FileTypesControllerAbstract(
			ILogger logger,
			DbContext context,
			FileTypeRepository fileTypeRepository,
			FileTypeModelValidator fileTypeModelValidator
			) : base(logger,context)
		{
			this._fileTypeRepository = fileTypeRepository;
			this._fileTypeModelValidator = fileTypeModelValidator;
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
		public virtual IHttpActionResult Get(int id)
		{
			Response response = new Response();

			this._fileTypeRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[FileTypeFilter]
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

			this._fileTypeRepository.GetWhereDynamic(whereClause,response,offset,limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[FileTypeFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Create(FileTypeModel model)
		{
			this._fileTypeModelValidator.CreateMode();
			var validationResult = this._fileTypeModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._fileTypeRepository.Create(model.Id,
				                                         model.Name);
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
		[FileTypeFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult CreateMany(List<FileTypeModel> models)
		{
			this._fileTypeModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._fileTypeModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._fileTypeRepository.Create(model.Id,
				                                model.Name);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[FileTypeFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Update(int id,FileTypeModel model)
		{
			this._fileTypeModelValidator.UpdateMode();
			var validationResult = this._fileTypeModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._fileTypeRepository.Update(model.Id,
				                                model.Name);
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
		[FileTypeFilter]
		[UnitOfWorkActionFilter]
		public IHttpActionResult Patch(int id, JsonPatchDocument<FileTypeModel> patch)
		{
			Response response = new Response();

			this._fileTypeRepository.GetById(id, response);
			if (response.FileTypes.Count > 0)
			{
				var model = new FileTypeModel(response.FileTypes.First());

				patch.ApplyUpdatesTo(model);
				this._fileTypeModelValidator.PatchMode();
				var validationResult = this._fileTypeModelValidator.Validate(model);
				if (validationResult.IsValid)
				{
					this._fileTypeRepository.Update(model.Id,
					                                model.Name);
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
		[FileTypeFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Delete(int id)
		{
			this._fileTypeRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>a34a8971c455da9da6c85ceff96d0ecb</Hash>
</Codenesium>*/