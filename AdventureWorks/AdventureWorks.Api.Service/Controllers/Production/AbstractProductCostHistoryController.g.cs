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
	public abstract class AbstractProductCostHistoryController: AbstractApiController
	{
		protected IBOProductCostHistory productCostHistoryManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractProductCostHistoryController(
			ServiceSettings settings,
			ILogger<AbstractProductCostHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductCostHistory productCostHistoryManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.productCostHistoryManager = productCostHistoryManager;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOProductCostHistory>), 200)]
		public async virtual Task<IActionResult> All()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<POCOProductCostHistory> response = await this.productCostHistoryManager.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOProductCostHistory), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			POCOProductCostHistory response = await this.productCostHistoryManager.Get(id);

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
		[ProducesResponseType(typeof(POCOProductCostHistory), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiProductCostHistoryModel model)
		{
			CreateResponse<POCOProductCostHistory> result = await this.productCostHistoryManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.ProductID.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/ProductCostHistories/{result.Record.ProductID.ToString()}");
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
		[ProducesResponseType(typeof(List<POCOProductCostHistory>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiProductCostHistoryModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<POCOProductCostHistory> records = new List<POCOProductCostHistory>();
			foreach (var model in models)
			{
				CreateResponse<POCOProductCostHistory> result = await this.productCostHistoryManager.Create(model);

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
		[ProducesResponseType(typeof(POCOProductCostHistory), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiProductCostHistoryModel model)
		{
			try
			{
				ActionResponse result = await this.productCostHistoryManager.Update(id, model);

				if (result.Success)
				{
					POCOProductCostHistory response = await this.productCostHistoryManager.Get(id);

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
			ActionResponse result = await this.productCostHistoryManager.Delete(id);

			if (result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}
	}
}

/*<Codenesium>
    <Hash>04ab8f91715f31a84199fce9a43657b9</Hash>
</Codenesium>*/