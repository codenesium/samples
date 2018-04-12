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
	public abstract class AbstractLinkLogController: AbstractApiController
	{
		protected ILinkLogRepository linkLogRepository;

		protected ILinkLogModelValidator linkLogModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractLinkLogController(
			ILogger<AbstractLinkLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkLogRepository linkLogRepository,
			ILinkLogModelValidator linkLogModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.linkLogRepository = linkLogRepository;
			this.linkLogModelValidator = linkLogModelValidator;
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
		[LinkLogFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.linkLogRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[LinkLogFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.linkLogRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[LinkLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] LinkLogModel model)
		{
			this.linkLogModelValidator.CreateMode();
			var validationResult = this.linkLogModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.linkLogRepository.Create(
					model.LinkId,
					model.Log,
					model.DateEntered);
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
		[LinkLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<LinkLogModel> models)
		{
			this.linkLogModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.linkLogModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.linkLogRepository.Create(
					model.LinkId,
					model.Log,
					model.DateEntered);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[LinkLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] LinkLogModel model)
		{
			if (this.linkLogRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.linkLogModelValidator.UpdateMode();
			var validationResult = this.linkLogModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.linkLogRepository.Update(
					id,
					model.LinkId,
					model.Log,
					model.DateEntered);
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
		[LinkLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.linkLogRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByLinkId/{id}")]
		[LinkLogFilter]
		[ReadOnlyFilter]
		[Route("~/api/Links/{id}/LinkLogs")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByLinkId(int id)
		{
			Response response = this.linkLogRepository.GetWhere(x => x.LinkId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>e8a698b958e8e0e68110e3269fced570</Hash>
</Codenesium>*/