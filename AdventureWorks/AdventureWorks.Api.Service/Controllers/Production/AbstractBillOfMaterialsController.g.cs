using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
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
			ServiceSettings settings,
			ILogger<AbstractBillOfMaterialsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOBillOfMaterials billOfMaterialsManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.billOfMaterialsManager = billOfMaterialsManager;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOBillOfMaterials>), 200)]
		public async virtual Task<IActionResult> All()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<POCOBillOfMaterials> response = await this.billOfMaterialsManager.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOBillOfMaterials), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			POCOBillOfMaterials response = await this.billOfMaterialsManager.Get(id);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOBillOfMaterials), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiBillOfMaterialsModel model)
		{
			CreateResponse<POCOBillOfMaterials> result = await this.billOfMaterialsManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.BillOfMaterialsID.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/BillOfMaterials/{result.Record.BillOfMaterialsID.ToString()}");
				return this.Ok(result.Record);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(List<POCOBillOfMaterials>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiBillOfMaterialsModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<POCOBillOfMaterials> records = new List<POCOBillOfMaterials>();
			foreach (var model in models)
			{
				CreateResponse<POCOBillOfMaterials> result = await this.billOfMaterialsManager.Create(model);

				if(result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			return this.Ok(records);
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOBillOfMaterials), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiBillOfMaterialsModel model)
		{
			try
			{
				ActionResponse result = await this.billOfMaterialsManager.Update(id, model);

				if (result.Success)
				{
					POCOBillOfMaterials response = await this.billOfMaterialsManager.Get(id);

					return this.Ok(response);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
			catch(RecordNotFoundException)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.billOfMaterialsManager.Delete(id);

			if (result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("getProductAssemblyIDComponentIDStartDate/{productAssemblyID}/{componentID}/{startDate}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOBillOfMaterials), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> GetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID,int componentID,DateTime startDate)
		{
			POCOBillOfMaterials response = await this.billOfMaterialsManager.GetProductAssemblyIDComponentIDStartDate(productAssemblyID,componentID,startDate);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpGet]
		[Route("getUnitMeasureCode/{unitMeasureCode}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOBillOfMaterials>), 200)]
		public async virtual Task<IActionResult> GetUnitMeasureCode(string unitMeasureCode)
		{
			List<POCOBillOfMaterials> response = await this.billOfMaterialsManager.GetUnitMeasureCode(unitMeasureCode);

			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>5f273c0a5dbf886f2114b2c85d30193b</Hash>
</Codenesium>*/