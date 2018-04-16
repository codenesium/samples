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

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractLinkController(
			ILogger<AbstractLinkController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkRepository linkRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.linkRepository = linkRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.linkRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
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
			ApiResponse response = this.linkRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] LinkModel model)
		{
			var id = this.linkRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<LinkModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.linkRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] LinkModel model)
		{
			this.linkRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.linkRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByChainId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Chains/{id}/Links")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByChainId(int id)
		{
			ApiResponse response = this.linkRepository.GetWhere(x => x.ChainId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByAssignedMachineId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Machines/{id}/Links")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByAssignedMachineId(int id)
		{
			ApiResponse response = this.linkRepository.GetWhere(x => x.AssignedMachineId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByLinkStatusId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/LinkStatus/{id}/Links")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByLinkStatusId(int id)
		{
			ApiResponse response = this.linkRepository.GetWhere(x => x.LinkStatusId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>a7fbbda1b87ab6b21d80432fd4b270dc</Hash>
</Codenesium>*/