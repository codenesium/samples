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
	public abstract class AbstractLinkController: AbstractApiController
	{
		protected ILinkRepository linkRepository;

		protected ILinkModelValidator linkModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractLinkController(
			ILogger<AbstractLinkController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkRepository linkRepository,
			ILinkModelValidator linkModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.linkRepository = linkRepository;
			this.linkModelValidator = linkModelValidator;
		}

		protected void AddErrors(ValidationResult result)
		{
			foreach (var error in result.Errors)
			{
				this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
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
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[LinkFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.linkRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[LinkFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] LinkModel model)
		{
			this.linkModelValidator.CreateMode();
			var validationResult = this.linkModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.linkRepository.Create(
					model.Name,
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
				return this.Ok(id);
			}
			else
			{
				this.AddErrors(validationResult);
				return this.BadRequest(this.ModelState);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[LinkFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<LinkModel> models)
		{
			this.linkModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.linkModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.linkRepository.Create(
					model.Name,
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

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[LinkFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] LinkModel model)
		{
			if (this.linkRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.linkModelValidator.UpdateMode();
			var validationResult = this.linkModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.linkRepository.Update(
					id,
					model.Name,
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
				return this.Ok();
			}
			else
			{
				this.AddErrors(validationResult);
				return this.BadRequest(this.ModelState);
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
			return this.Ok();
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
			return this.Ok(response);
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
			return this.Ok(response);
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
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>65d22047f850512267648f0c0042bda9</Hash>
</Codenesium>*/