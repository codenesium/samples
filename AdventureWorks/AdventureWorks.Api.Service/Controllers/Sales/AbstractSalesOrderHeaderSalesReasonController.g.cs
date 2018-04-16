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
	public abstract class AbstractSalesOrderHeaderSalesReasonController: AbstractApiController
	{
		protected ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSalesOrderHeaderSalesReasonController(
			ILogger<AbstractSalesOrderHeaderSalesReasonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.salesOrderHeaderSalesReasonRepository = salesOrderHeaderSalesReasonRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.salesOrderHeaderSalesReasonRepository.GetById(id);
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
			ApiResponse response = this.salesOrderHeaderSalesReasonRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] SalesOrderHeaderSalesReasonModel model)
		{
			var id = this.salesOrderHeaderSalesReasonRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<SalesOrderHeaderSalesReasonModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.salesOrderHeaderSalesReasonRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] SalesOrderHeaderSalesReasonModel model)
		{
			this.salesOrderHeaderSalesReasonRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.salesOrderHeaderSalesReasonRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("BySalesOrderID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/SalesOrderHeaders/{id}/SalesOrderHeaderSalesReasons")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult BySalesOrderID(int id)
		{
			ApiResponse response = this.salesOrderHeaderSalesReasonRepository.GetWhere(x => x.SalesOrderID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("BySalesReasonID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/SalesReasons/{id}/SalesOrderHeaderSalesReasons")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult BySalesReasonID(int id)
		{
			ApiResponse response = this.salesOrderHeaderSalesReasonRepository.GetWhere(x => x.SalesReasonID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>fa827340705af84d6fa071ee9cb35355</Hash>
</Codenesium>*/