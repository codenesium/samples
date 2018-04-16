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
	public abstract class AbstractChainController: AbstractApiController
	{
		protected IChainRepository chainRepository;

		protected IChainModelValidator chainModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractChainController(
			ILogger<AbstractChainController> logger,
			ITransactionCoordinator transactionCoordinator,
			IChainRepository chainRepository,
			IChainModelValidator chainModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.chainRepository = chainRepository;
			this.chainModelValidator = chainModelValidator;
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
		[ServiceFilter(typeof(ChainFilter))]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.chainRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ServiceFilter(typeof(ChainFilter))]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.chainRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
	
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] ChainModel model)
		{
			this.chainModelValidator.CreateMode();
			var validationResult = this.chainModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.chainRepository.Create(model);
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
		[ServiceFilter(typeof(ChainFilter))]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<ChainModel> models)
		{
			this.chainModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.chainModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.chainRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ServiceFilter(typeof(ChainFilter))]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] ChainModel model)
		{
			if (this.chainRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.chainModelValidator.UpdateMode();
			var validationResult = this.chainModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.chainRepository.Update(id, model);
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
		[ServiceFilter(typeof(ChainFilter))]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.chainRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByTeamId/{id}")]
		[ServiceFilter(typeof(ChainFilter))]
		[ReadOnlyFilter]
		[Route("~/api/Teams/{id}/Chains")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByTeamId(int id)
		{
			ApiResponse response = this.chainRepository.GetWhere(x => x.TeamId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByChainStatusId/{id}")]
		[ServiceFilter(typeof(ChainFilter))]
		[ReadOnlyFilter]
		[Route("~/api/ChainStatus/{id}/Chains")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByChainStatusId(int id)
		{
			ApiResponse response = this.chainRepository.GetWhere(x => x.ChainStatusId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>e62ae190645e50742aefc054a4a74770</Hash>
</Codenesium>*/