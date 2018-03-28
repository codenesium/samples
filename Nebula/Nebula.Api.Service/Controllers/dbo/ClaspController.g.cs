using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service
{
	public abstract class AbstractClaspsController: AbstractEntityFrameworkApiController
	{
		protected IClaspRepository _claspRepository;
		protected IClaspModelValidator _claspModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractClaspsController(
			ILogger<AbstractClaspsController> logger,
			ApplicationContext context,
			IClaspRepository claspRepository,
			IClaspModelValidator claspModelValidator
			) : base(logger,context)
		{
			this._claspRepository = claspRepository;
			this._claspModelValidator = claspModelValidator;
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
		[ClaspFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._claspRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ClaspFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._claspRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ClaspFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ClaspModel model)
		{
			this._claspModelValidator.CreateMode();
			var validationResult = this._claspModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._claspRepository.Create(model.PreviousChainId,
				                                      model.NextChainId);
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
		[ClaspFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<ClaspModel> models)
		{
			this._claspModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._claspModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._claspRepository.Create(model.PreviousChainId,
				                             model.NextChainId);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ClaspFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,ClaspModel model)
		{
			this._claspModelValidator.UpdateMode();
			var validationResult = this._claspModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._claspRepository.Update(id,  model.PreviousChainId,
				                             model.NextChainId);
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
		[ClaspFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._claspRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByPreviousChainId/{id}")]
		[ClaspFilter]
		[ReadOnlyFilter]
		[Route("~/api/Chains/{id}/Clasps")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByPreviousChainId(int id)
		{
			var response = new Response();

			this._claspRepository.GetWhere(x => x.previousChainId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByNextChainId/{id}")]
		[ClaspFilter]
		[ReadOnlyFilter]
		[Route("~/api/Chains/{id}/Clasps")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByNextChainId(int id)
		{
			var response = new Response();

			this._claspRepository.GetWhere(x => x.nextChainId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>d31aa6f26669c93efa377f0947c7a121</Hash>
</Codenesium>*/