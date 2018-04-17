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
	public abstract class AbstractMachineRefTeamController: AbstractApiController
	{
		protected IMachineRefTeamRepository machineRefTeamRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractMachineRefTeamController(
			ILogger<AbstractMachineRefTeamController> logger,
			ITransactionCoordinator transactionCoordinator,
			IMachineRefTeamRepository machineRefTeamRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.machineRefTeamRepository = machineRefTeamRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.machineRefTeamRepository.GetById(id);
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
			ApiResponse response = this.machineRefTeamRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] MachineRefTeamModel model)
		{
			var id = this.machineRefTeamRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<MachineRefTeamModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.machineRefTeamRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] MachineRefTeamModel model)
		{
			this.machineRefTeamRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.machineRefTeamRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByMachineId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Machines/{id}/MachineRefTeams")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByMachineId(int id)
		{
			ApiResponse response = this.machineRefTeamRepository.GetWhere(x => x.MachineId == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByTeamId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Teams/{id}/MachineRefTeams")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByTeamId(int id)
		{
			ApiResponse response = this.machineRefTeamRepository.GetWhere(x => x.TeamId == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>3ed8f5d8d25dbed8b08f5957ee79e5b4</Hash>
</Codenesium>*/