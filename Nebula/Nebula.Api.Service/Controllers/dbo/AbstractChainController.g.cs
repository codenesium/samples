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
	public abstract class AbstractChainsController: AbstractApiController
	{
		protected IChainRepository chainRepository;
		protected IChainModelValidator chainModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractChainsController(
			ILogger<AbstractChainsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IChainRepository chainRepository,
			IChainModelValidator chainModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.chainRepository = chainRepository;
			this.chainModelValidator = chainModelValidator;
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
		[ChainFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.chainRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ChainFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.chainRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ChainFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ChainModel model)
		{
			this.chainModelValidator.CreateMode();
			var validationResult = this.chainModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.chainRepository.Create(model.Name,
				                                     model.TeamId,
				                                     model.ChainStatusId,
				                                     model.ExternalId);
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
		[ChainFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ChainModel> models)
		{
			this.chainModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.chainModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.chainRepository.Create(model.Name,
				                            model.TeamId,
				                            model.ChainStatusId,
				                            model.ExternalId);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ChainFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int Id,ChainModel model)
		{
			this.chainModelValidator.UpdateMode();
			var validationResult = this.chainModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.chainRepository.Update(Id,  model.Name,
				                            model.TeamId,
				                            model.ChainStatusId,
				                            model.ExternalId);
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
		[ChainFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.chainRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByTeamId/{id}")]
		[ChainFilter]
		[ReadOnlyFilter]
		[Route("~/api/Teams/{id}/Chains")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByTeamId(int id)
		{
			var response = new Response();

			this.chainRepository.GetWhere(x => x.TeamId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByChainStatusId/{id}")]
		[ChainFilter]
		[ReadOnlyFilter]
		[Route("~/api/ChainStatus/{id}/Chains")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByChainStatusId(int id)
		{
			var response = new Response();

			this.chainRepository.GetWhere(x => x.ChainStatusId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>3bb802702c218d7e413e14a60ce71a4c</Hash>
</Codenesium>*/