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
	public abstract class AbstractChainStatusController: AbstractApiController
	{
		protected IChainStatusRepository chainStatusRepository;
		protected IChainStatusModelValidator chainStatusModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractChainStatusController(
			ILogger<AbstractChainStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IChainStatusRepository chainStatusRepository,
			IChainStatusModelValidator chainStatusModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.chainStatusRepository = chainStatusRepository;
			this.chainStatusModelValidator = chainStatusModelValidator;
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
		[ChainStatusFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.chainStatusRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ChainStatusFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.chainStatusRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ChainStatusFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ChainStatusModel model)
		{
			this.chainStatusModelValidator.CreateMode();
			var validationResult = this.chainStatusModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.chainStatusRepository.Create(model.Name);
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
		[ChainStatusFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ChainStatusModel> models)
		{
			this.chainStatusModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.chainStatusModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.chainStatusRepository.Create(model.Name);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ChainStatusFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int Id,ChainStatusModel model)
		{
			this.chainStatusModelValidator.UpdateMode();
			var validationResult = this.chainStatusModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.chainStatusRepository.Update(Id,  model.Name);
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
		[ChainStatusFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.chainStatusRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>0f43074b973eb5d9d67e9c4cc2b16413</Hash>
</Codenesium>*/