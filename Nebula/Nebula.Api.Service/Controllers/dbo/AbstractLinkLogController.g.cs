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
	public abstract class AbstractLinkLogsController: AbstractApiController
	{
		protected ILinkLogRepository linkLogRepository;
		protected ILinkLogModelValidator linkLogModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractLinkLogsController(
			ILogger<AbstractLinkLogsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkLogRepository linkLogRepository,
			ILinkLogModelValidator linkLogModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.linkLogRepository = linkLogRepository;
			this.linkLogModelValidator = linkLogModelValidator;
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
		[LinkLogFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.linkLogRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[LinkLogFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.linkLogRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[LinkLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(LinkLogModel model)
		{
			this.linkLogModelValidator.CreateMode();
			var validationResult = this.linkLogModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.linkLogRepository.Create(model.LinkId,
				                                       model.Log,
				                                       model.DateEntered);
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
		[LinkLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<LinkLogModel> models)
		{
			this.linkLogModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.linkLogModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.linkLogRepository.Create(model.LinkId,
				                              model.Log,
				                              model.DateEntered);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[LinkLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int Id,LinkLogModel model)
		{
			this.linkLogModelValidator.UpdateMode();
			var validationResult = this.linkLogModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.linkLogRepository.Update(Id,  model.LinkId,
				                              model.Log,
				                              model.DateEntered);
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
		[LinkLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.linkLogRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByLinkId/{id}")]
		[LinkLogFilter]
		[ReadOnlyFilter]
		[Route("~/api/Links/{id}/LinkLogs")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByLinkId(int id)
		{
			var response = new Response();

			this.linkLogRepository.GetWhere(x => x.LinkId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>2d4709ea3e3bba3352d9af13cad8b313</Hash>
</Codenesium>*/