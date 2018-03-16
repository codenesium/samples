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
	public abstract class AbstractLinksController: AbstractEntityFrameworkApiController
	{
		protected LinkRepository _linkRepository;
		protected LinkModelValidator _linkModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractLinksController(
			ILogger<AbstractLinksController> logger,
			ApplicationContext context,
			LinkRepository linkRepository,
			LinkModelValidator linkModelValidator
			) : base(logger,context)
		{
			this._linkRepository = linkRepository;
			this._linkModelValidator = linkModelValidator;
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
			Response response = new Response();

			this._linkRepository.GetById(id,response);
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
			Response response = new Response();

			this._linkRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._linkModelValidator.CreateMode();
			var validationResult = this._linkModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._linkRepository.Create(model.AssignedMachineId,
				                                     model.ChainId,
				                                     model.DateCompleted,
				                                     model.DateStarted,
				                                     model.DynamicParameters,
				                                     model.ExternalId,
				                                     model.LinkStatusId,
				                                     model.Name,
				                                     model.Order,
				                                     model.Response,
				                                     model.StaticParameters);
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
		[LinkFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<LinkModel> models)
		{
			this._linkModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._linkModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._linkRepository.Create(model.AssignedMachineId,
				                            model.ChainId,
				                            model.DateCompleted,
				                            model.DateStarted,
				                            model.DynamicParameters,
				                            model.ExternalId,
				                            model.LinkStatusId,
				                            model.Name,
				                            model.Order,
				                            model.Response,
				                            model.StaticParameters);
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
			this._linkModelValidator.UpdateMode();
			var validationResult = this._linkModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._linkRepository.Update(id,  model.AssignedMachineId,
				                            model.ChainId,
				                            model.DateCompleted,
				                            model.DateStarted,
				                            model.DynamicParameters,
				                            model.ExternalId,
				                            model.LinkStatusId,
				                            model.Name,
				                            model.Order,
				                            model.Response,
				                            model.StaticParameters);
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
			this._linkRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByAssignedMachineId/{id}")]
		[LinkFilter]
		[ReadOnlyFilter]
		[Route("~/api/Machines/{id}/Links")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByAssignedMachineId(int id)
		{
			var response = new Response();

			this._linkRepository.GetWhere(x => x.assignedMachineId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByChainId/{id}")]
		[LinkFilter]
		[ReadOnlyFilter]
		[Route("~/api/Chains/{id}/Links")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByChainId(int id)
		{
			var response = new Response();

			this._linkRepository.GetWhere(x => x.chainId == id, response);
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
			var response = new Response();

			this._linkRepository.GetWhere(x => x.linkStatusId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>6f42c1c09380d8aad035494726fde9d5</Hash>
</Codenesium>*/