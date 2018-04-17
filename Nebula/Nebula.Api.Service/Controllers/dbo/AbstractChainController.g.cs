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

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractChainController(
			ILogger<AbstractChainController> logger,
			ITransactionCoordinator transactionCoordinator,
			IChainRepository chainRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.chainRepository = chainRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.chainRepository.GetById(id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.chainRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] ChainModel model)
		{
			var id = this.chainRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<ChainModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.chainRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] ChainModel model)
		{
			this.chainRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.chainRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByTeamId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Teams/{id}/Chains")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByTeamId(int id)
		{
			ApiResponse response = this.chainRepository.GetWhere(x => x.TeamId == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByChainStatusId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/ChainStatus/{id}/Chains")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByChainStatusId(int id)
		{
			ApiResponse response = this.chainRepository.GetWhere(x => x.ChainStatusId == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>20f8028319b53cc9c29a8eaedd1d4bb1</Hash>
</Codenesium>*/