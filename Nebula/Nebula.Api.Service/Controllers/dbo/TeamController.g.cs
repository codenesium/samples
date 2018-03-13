using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service
{
	public abstract class AbstractTeamsController: AbstractEntityFrameworkApiController
	{
		protected TeamRepository _teamRepository;
		protected TeamModelValidator _teamModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractTeamsController(
			ILogger<AbstractTeamsController> logger,
			ApplicationContext context,
			TeamRepository teamRepository,
			TeamModelValidator teamModelValidator
			) : base(logger,context)
		{
			this._teamRepository = teamRepository;
			this._teamModelValidator = teamModelValidator;
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
		[TeamFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._teamRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[TeamFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._teamRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[TeamFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), 400)]
		public virtual IActionResult Create(TeamModel model)
		{
			this._teamModelValidator.CreateMode();
			var validationResult = this._teamModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._teamRepository.Create(model.Id,
				                                     model.Name,
				                                     model.OrganizationId);
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
		[TeamFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<TeamModel> models)
		{
			this._teamModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._teamModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._teamRepository.Create(model.Id,
				                            model.Name,
				                            model.OrganizationId);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[TeamFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,TeamModel model)
		{
			this._teamModelValidator.UpdateMode();
			var validationResult = this._teamModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._teamRepository.Update(model.Id,
				                            model.Name,
				                            model.OrganizationId);
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
		[TeamFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._teamRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByOrganizationId/{id}")]
		[TeamFilter]
		[ReadOnlyFilter]
		[Route("~/api/Organizations/{id}/Teams")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByOrganizationId(int id)
		{
			var response = new Response();

			this._teamRepository.GetWhere(x => x.organizationId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>5e070459b9a9b7e3cfcd2ac7ac497bb4</Hash>
</Codenesium>*/