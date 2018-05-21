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
	public abstract class AbstractTransactionHistoryArchiveController: AbstractApiController
	{
		protected IBOTransactionHistoryArchive transactionHistoryArchiveManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractTransactionHistoryArchiveController(
			ServiceSettings settings,
			ILogger<AbstractTransactionHistoryArchiveController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOTransactionHistoryArchive transactionHistoryArchiveManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.transactionHistoryArchiveManager = transactionHistoryArchiveManager;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOTransactionHistoryArchive>), 200)]
		public async virtual Task<IActionResult> All()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<POCOTransactionHistoryArchive> response = await this.transactionHistoryArchiveManager.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOTransactionHistoryArchive), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			POCOTransactionHistoryArchive response = await this.transactionHistoryArchiveManager.Get(id);

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
		[ProducesResponseType(typeof(POCOTransactionHistoryArchive), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiTransactionHistoryArchiveModel model)
		{
			CreateResponse<POCOTransactionHistoryArchive> result = await this.transactionHistoryArchiveManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.TransactionID.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/TransactionHistoryArchives/{result.Record.TransactionID.ToString()}");
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
		[ProducesResponseType(typeof(List<POCOTransactionHistoryArchive>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTransactionHistoryArchiveModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<POCOTransactionHistoryArchive> records = new List<POCOTransactionHistoryArchive>();
			foreach (var model in models)
			{
				CreateResponse<POCOTransactionHistoryArchive> result = await this.transactionHistoryArchiveManager.Create(model);

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
		[ProducesResponseType(typeof(POCOTransactionHistoryArchive), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTransactionHistoryArchiveModel model)
		{
			try
			{
				ActionResponse result = await this.transactionHistoryArchiveManager.Update(id, model);

				if (result.Success)
				{
					POCOTransactionHistoryArchive response = await this.transactionHistoryArchiveManager.Get(id);

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
			ActionResponse result = await this.transactionHistoryArchiveManager.Delete(id);

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
		[Route("getProductID/{productID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOTransactionHistoryArchive>), 200)]
		public async virtual Task<IActionResult> GetProductID(int productID)
		{
			List<POCOTransactionHistoryArchive> response = await this.transactionHistoryArchiveManager.GetProductID(productID);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("getReferenceOrderIDReferenceOrderLineID/{referenceOrderID}/{referenceOrderLineID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOTransactionHistoryArchive>), 200)]
		public async virtual Task<IActionResult> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID)
		{
			List<POCOTransactionHistoryArchive> response = await this.transactionHistoryArchiveManager.GetReferenceOrderIDReferenceOrderLineID(referenceOrderID,referenceOrderLineID);

			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>509044989d75042c890e23264cc9ed8d</Hash>
</Codenesium>*/