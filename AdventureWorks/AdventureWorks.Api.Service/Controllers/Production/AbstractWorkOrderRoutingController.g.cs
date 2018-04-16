using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractWorkOrderRoutingController: AbstractApiController
	{
		protected IWorkOrderRoutingRepository workOrderRoutingRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractWorkOrderRoutingController(
			ILogger<AbstractWorkOrderRoutingController> logger,
			ITransactionCoordinator transactionCoordinator,
			IWorkOrderRoutingRepository workOrderRoutingRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.workOrderRoutingRepository = workOrderRoutingRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.workOrderRoutingRepository.GetById(id);
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
			ApiResponse response = this.workOrderRoutingRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] WorkOrderRoutingModel model)
		{
			var id = this.workOrderRoutingRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<WorkOrderRoutingModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.workOrderRoutingRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] WorkOrderRoutingModel model)
		{
			this.workOrderRoutingRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.workOrderRoutingRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByWorkOrderID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/WorkOrders/{id}/WorkOrderRoutings")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByWorkOrderID(int id)
		{
			ApiResponse response = this.workOrderRoutingRepository.GetWhere(x => x.WorkOrderID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByLocationID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Locations/{id}/WorkOrderRoutings")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByLocationID(short id)
		{
			ApiResponse response = this.workOrderRoutingRepository.GetWhere(x => x.LocationID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>523620be612df165102adaad08cba0e3</Hash>
</Codenesium>*/