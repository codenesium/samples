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
	public abstract class AbstractLinksController: AbstractApiController
	{
		protected ILinkRepository linkRepository;
		protected ILinkModelValidator linkModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractLinksController(
			ILogger<AbstractLinksController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkRepository linkRepository,
			ILinkModelValidator linkModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.linkRepository = linkRepository;
			this.linkModelValidator = linkModelValidator;
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
		[LinkFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.linkRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[LinkFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.linkRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[LinkFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(LinkModel model)
		{
			this.linkModelValidator.CreateMode();
			var validationResult = this.linkModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.linkRepository.Create(model.Name,
				                                    model.DynamicParameters,
				                                    model.StaticParameters,
				                                    model.ChainId,
				                                    model.AssignedMachineId,
				                                    model.LinkStatusId,
				                                    model.Order,
				                                    model.DateStarted,
				                                    model.DateCompleted,
				                                    model.Response,
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
		[LinkFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<LinkModel> models)
		{
			this.linkModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.linkModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.linkRepository.Create(model.Name,
				                           model.DynamicParameters,
				                           model.StaticParameters,
				                           model.ChainId,
				                           model.AssignedMachineId,
				                           model.LinkStatusId,
				                           model.Order,
				                           model.DateStarted,
				                           model.DateCompleted,
				                           model.Response,
				                           model.ExternalId);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[LinkFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,LinkModel model)
		{
			if(this.linkRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.linkModelValidator.UpdateMode();
			var validationResult = this.linkModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.linkRepository.Update(id,  model.Name,
				                           model.DynamicParameters,
				                           model.StaticParameters,
				                           model.ChainId,
				                           model.AssignedMachineId,
				                           model.LinkStatusId,
				                           model.Order,
				                           model.DateStarted,
				                           model.DateCompleted,
				                           model.Response,
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
		[LinkFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.linkRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByChainId/{id}")]
		[LinkFilter]
		[ReadOnlyFilter]
		[Route("~/api/Chains/{id}/Links")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByChainId(int id)
		{
			Response response = this.linkRepository.GetWhere(x => x.ChainId == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByAssignedMachineId/{id}")]
		[LinkFilter]
		[ReadOnlyFilter]
		[Route("~/api/Machines/{id}/Links")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByAssignedMachineId(int id)
		{
			Response response = this.linkRepository.GetWhere(x => x.AssignedMachineId == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByLinkStatusId/{id}")]
		[LinkFilter]
		[ReadOnlyFilter]
		[Route("~/api/LinkStatus/{id}/Links")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByLinkStatusId(int id)
		{
			Response response = this.linkRepository.GetWhere(x => x.LinkStatusId == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>d30ace32fe288b8601add57f28b2a411</Hash>
</Codenesium>*/