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
	public abstract class AbstractBillOfMaterialsController: AbstractApiController
	{
		protected IBillOfMaterialsRepository billOfMaterialsRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractBillOfMaterialsController(
			ILogger<AbstractBillOfMaterialsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBillOfMaterialsRepository billOfMaterialsRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.billOfMaterialsRepository = billOfMaterialsRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.billOfMaterialsRepository.GetById(id);
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
			ApiResponse response = this.billOfMaterialsRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] BillOfMaterialsModel model)
		{
			var id = this.billOfMaterialsRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<BillOfMaterialsModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.billOfMaterialsRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] BillOfMaterialsModel model)
		{
			this.billOfMaterialsRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.billOfMaterialsRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByProductAssemblyID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/BillOfMaterials")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByProductAssemblyID(int id)
		{
			ApiResponse response = this.billOfMaterialsRepository.GetWhere(x => x.ProductAssemblyID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByComponentID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/BillOfMaterials")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByComponentID(int id)
		{
			ApiResponse response = this.billOfMaterialsRepository.GetWhere(x => x.ComponentID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByUnitMeasureCode/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/UnitMeasures/{id}/BillOfMaterials")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByUnitMeasureCode(string id)
		{
			ApiResponse response = this.billOfMaterialsRepository.GetWhere(x => x.UnitMeasureCode == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>824b31ea0008fcd74f61b565127318de</Hash>
</Codenesium>*/