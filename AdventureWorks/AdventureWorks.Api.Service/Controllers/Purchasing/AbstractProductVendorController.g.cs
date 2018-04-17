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
	public abstract class AbstractProductVendorController: AbstractApiController
	{
		protected IProductVendorRepository productVendorRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractProductVendorController(
			ILogger<AbstractProductVendorController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductVendorRepository productVendorRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.productVendorRepository = productVendorRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.productVendorRepository.GetById(id);
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
			ApiResponse response = this.productVendorRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] ProductVendorModel model)
		{
			var id = this.productVendorRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<ProductVendorModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.productVendorRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] ProductVendorModel model)
		{
			this.productVendorRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.productVendorRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByProductID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/ProductVendors")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			ApiResponse response = this.productVendorRepository.GetWhere(x => x.ProductID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Vendors/{id}/ProductVendors")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			ApiResponse response = this.productVendorRepository.GetWhere(x => x.BusinessEntityID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByUnitMeasureCode/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/UnitMeasures/{id}/ProductVendors")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByUnitMeasureCode(string id)
		{
			ApiResponse response = this.productVendorRepository.GetWhere(x => x.UnitMeasureCode == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>6b0b49bfe19b2f14d9ff0006b6764fb1</Hash>
</Codenesium>*/