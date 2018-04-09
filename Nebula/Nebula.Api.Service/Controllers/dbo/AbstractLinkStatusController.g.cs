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
	public abstract class AbstractLinkStatusController: AbstractApiController
	{
		protected ILinkStatusRepository linkStatusRepository;
		protected ILinkStatusModelValidator linkStatusModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractLinkStatusController(
			ILogger<AbstractLinkStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkStatusRepository linkStatusRepository,
			ILinkStatusModelValidator linkStatusModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.linkStatusRepository = linkStatusRepository;
			this.linkStatusModelValidator = linkStatusModelValidator;
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
		[LinkStatusFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.linkStatusRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[LinkStatusFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.linkStatusRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[LinkStatusFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(LinkStatusModel model)
		{
			this.linkStatusModelValidator.CreateMode();
			var validationResult = this.linkStatusModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.linkStatusRepository.Create(model.Name);
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
		[LinkStatusFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<LinkStatusModel> models)
		{
			this.linkStatusModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.linkStatusModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.linkStatusRepository.Create(model.Name);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[LinkStatusFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,LinkStatusModel model)
		{
			if(this.linkStatusRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.linkStatusModelValidator.UpdateMode();
			var validationResult = this.linkStatusModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.linkStatusRepository.Update(id,  model.Name);
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
		[LinkStatusFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.linkStatusRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>fc4af66a59c4b433e5681c6ffb81ce8e</Hash>
</Codenesium>*/