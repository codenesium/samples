using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractBillOfMaterialsController: AbstractApiController
	{
		protected IBOBillOfMaterials billOfMaterialsManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractBillOfMaterialsController(
			ILogger<AbstractBillOfMaterialsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOBillOfMaterials billOfMaterialsManager
			)
			: base(logger, transactionCoordinator)
		{
			this.billOfMaterialsManager = billOfMaterialsManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.billOfMaterialsManager.GetById(id);
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
			ApiResponse response = this.billOfMaterialsManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 400)]
		public virtual async Task<IActionResult> Create([FromBody] BillOfMaterialsModel model)
		{
			var result = await this.billOfMaterialsManager.Create(model);

			if(result.Success)
			{
				return this.Ok(result);
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<BillOfMaterialsModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var result = await this.billOfMaterialsManager.Create(model);

				if(!result.Success)
				{
					return this.BadRequest(result);
				}
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] BillOfMaterialsModel model)
		{
			var result = await this.billOfMaterialsManager.Update(id, model);

			if(result.Success)
			{
				return this.Ok();
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			var result = await this.billOfMaterialsManager.Delete(id);

			if(result.Success)
			{
				return this.Ok();
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpGet]
		[Route("ByProductAssemblyID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/BillOfMaterials")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByProductAssemblyID(int id)
		{
			ApiResponse response = this.billOfMaterialsManager.GetWhere(x => x.ProductAssemblyID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByComponentID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/BillOfMaterials")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByComponentID(int id)
		{
			ApiResponse response = this.billOfMaterialsManager.GetWhere(x => x.ComponentID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByUnitMeasureCode/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/UnitMeasures/{id}/BillOfMaterials")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByUnitMeasureCode(string id)
		{
			ApiResponse response = this.billOfMaterialsManager.GetWhere(x => x.UnitMeasureCode == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>902100b0fd5e61d14e4985d6f23c743d</Hash>
</Codenesium>*/