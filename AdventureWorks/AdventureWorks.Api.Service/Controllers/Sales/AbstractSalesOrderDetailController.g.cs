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
	public abstract class AbstractSalesOrderDetailController: AbstractApiController
	{
		protected ISalesOrderDetailRepository salesOrderDetailRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSalesOrderDetailController(
			ILogger<AbstractSalesOrderDetailController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderDetailRepository salesOrderDetailRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.salesOrderDetailRepository = salesOrderDetailRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.salesOrderDetailRepository.GetById(id);
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
			ApiResponse response = this.salesOrderDetailRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] SalesOrderDetailModel model)
		{
			var id = this.salesOrderDetailRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<SalesOrderDetailModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.salesOrderDetailRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] SalesOrderDetailModel model)
		{
			this.salesOrderDetailRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.salesOrderDetailRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("BySalesOrderID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/SalesOrderHeaders/{id}/SalesOrderDetails")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult BySalesOrderID(int id)
		{
			ApiResponse response = this.salesOrderDetailRepository.GetWhere(x => x.SalesOrderID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("BySpecialOfferID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/SpecialOfferProducts/{id}/SalesOrderDetails")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult BySpecialOfferID(int id)
		{
			ApiResponse response = this.salesOrderDetailRepository.GetWhere(x => x.SpecialOfferID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>78be7cc6e864ca3bef2ad16b7c1385b4</Hash>
</Codenesium>*/