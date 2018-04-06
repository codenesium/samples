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
	public abstract class AbstractAWBuildVersionsController: AbstractEntityFrameworkApiController
	{
		protected IAWBuildVersionRepository _aWBuildVersionRepository;
		protected IAWBuildVersionModelValidator _aWBuildVersionModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractAWBuildVersionsController(
			ILogger<AbstractAWBuildVersionsController> logger,
			ApplicationContext context,
			IAWBuildVersionRepository aWBuildVersionRepository,
			IAWBuildVersionModelValidator aWBuildVersionModelValidator
			) : base(logger,context)
		{
			this._aWBuildVersionRepository = aWBuildVersionRepository;
			this._aWBuildVersionModelValidator = aWBuildVersionModelValidator;
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
		[AWBuildVersionFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._aWBuildVersionRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[AWBuildVersionFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._aWBuildVersionRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[AWBuildVersionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(AWBuildVersionModel model)
		{
			this._aWBuildVersionModelValidator.CreateMode();
			var validationResult = this._aWBuildVersionModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._aWBuildVersionRepository.Create(model.Database_Version,
				                                               model.VersionDate,
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
		[AWBuildVersionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<AWBuildVersionModel> models)
		{
			this._aWBuildVersionModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._aWBuildVersionModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._aWBuildVersionRepository.Create(model.Database_Version,
				                                      model.VersionDate,
				                                      model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[AWBuildVersionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int SystemInformationID,AWBuildVersionModel model)
		{
			this._aWBuildVersionModelValidator.UpdateMode();
			var validationResult = this._aWBuildVersionModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._aWBuildVersionRepository.Update(SystemInformationID,  model.Database_Version,
				                                      model.VersionDate,
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
		[AWBuildVersionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._aWBuildVersionRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>c610a0a538238e928f4f4dfac89606ac</Hash>
</Codenesium>*/