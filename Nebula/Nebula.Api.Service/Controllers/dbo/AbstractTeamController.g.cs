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
			Response response = new Response();

			this.teamRepository.GetById(id,response);
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

			this.teamRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
		public virtual IActionResult Update(int Id,TeamModel model)
		{
			this.teamModelValidator.UpdateMode();
			var validationResult = this.teamModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.teamRepository.Update(Id,  model.Name,
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
			var response = new Response();

			this.teamRepository.GetWhere(x => x.OrganizationId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>3f30b39df17525a29e4ccb3f33893b0c</Hash>
</Codenesium>*/