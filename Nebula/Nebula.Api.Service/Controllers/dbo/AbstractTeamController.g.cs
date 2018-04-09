using System;
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
	public abstract class AbstractTeamsController: AbstractApiController
	{
		protected ITeamRepository teamRepository;
		protected ITeamModelValidator teamModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractTeamsController(
			ILogger<AbstractTeamsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeamRepository teamRepository,
			ITeamModelValidator teamModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.teamRepository = teamRepository;
			this.teamModelValidator = teamModelValidator;
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
			Response response = this.teamRepository.GetById(id);
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
			Response response = this.teamRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[TeamFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(TeamModel model)
		{
			this.teamModelValidator.CreateMode();
			var validationResult = this.teamModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.teamRepository.Create(model.Name,
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
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[TeamFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<TeamModel> models)
		{
			this.teamModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.teamModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.teamRepository.Create(model.Name,
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
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,TeamModel model)
		{
			if(this.teamRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.teamModelValidator.UpdateMode();
			var validationResult = this.teamModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.teamRepository.Update(id,  model.Name,
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
			this.teamRepository.Delete(id);
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
			Response response = this.teamRepository.GetWhere(x => x.OrganizationId == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>a16ee04b9192b9f8be979eb4347de4e7</Hash>
</Codenesium>*/