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
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	public abstract class AbstractBillOfMaterialsController: AbstractApiController
	{
		protected IBillOfMaterialsService billOfMaterialsService;

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractBillOfMaterialsController(
			ServiceSettings settings,
			ILogger<AbstractBillOfMaterialsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBillOfMaterialsService billOfMaterialsService
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.billOfMaterialsService = billOfMaterialsService;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiBillOfMaterialsResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiBillOfMaterialsResponseModel> response = await this.billOfMaterialsService.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiBillOfMaterialsResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiBillOfMaterialsResponseModel response = await this.billOfMaterialsService.Get(id);

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
		[ProducesResponseType(typeof(ApiBillOfMaterialsResponseModel), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiBillOfMaterialsRequestModel model)
		{
			CreateResponse<ApiBillOfMaterialsResponseModel> result = await this.billOfMaterialsService.Create(model);

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
		[ProducesResponseType(typeof(List<ApiBillOfMaterialsResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiBillOfMaterialsRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiBillOfMaterialsResponseModel> records = new List<ApiBillOfMaterialsResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiBillOfMaterialsResponseModel> result = await this.billOfMaterialsService.Create(model);

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
		[ProducesResponseType(typeof(ApiBillOfMaterialsResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiBillOfMaterialsRequestModel model)
		{
			ActionResponse result = await this.billOfMaterialsService.Update(id, model);

			if (result.Success)
			{
				ApiBillOfMaterialsResponseModel response = await this.billOfMaterialsService.Get(id);

				return this.Ok(response);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.billOfMaterialsService.Delete(id);

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
		[ProducesResponseType(typeof(ApiBillOfMaterialsResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> GetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID,int componentID,DateTime startDate)
		{
			ApiBillOfMaterialsResponseModel response = await this.billOfMaterialsService.GetProductAssemblyIDComponentIDStartDate(productAssemblyID,componentID,startDate);

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
		[ProducesResponseType(typeof(List<ApiBillOfMaterialsResponseModel>), 200)]
		public async virtual Task<IActionResult> GetUnitMeasureCode(string unitMeasureCode)
		{
			List<ApiBillOfMaterialsResponseModel> response = await this.billOfMaterialsService.GetUnitMeasureCode(unitMeasureCode);

			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>a64183db41585daa8bcfc4475dfc5dec</Hash>
</Codenesium>*/