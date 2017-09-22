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
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
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
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.Request.GetQueryNameValuePairs());
			Response response = new Response();

			this._fileTypeRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
    <Hash>b241893b1eaf8322d626d959b70b9dc1</Hash>
</Codenesium>*/