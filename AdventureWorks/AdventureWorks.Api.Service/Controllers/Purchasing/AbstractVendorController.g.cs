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
	public abstract class AbstractVendorController: AbstractApiController
	{
		protected IBOVendor vendorManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractVendorController(
			ServiceSettings settings,
			ILogger<AbstractVendorController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOVendor vendorManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.vendorManager = vendorManager;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOVendor>), 200)]
		public async virtual Task<IActionResult> All()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<POCOVendor> response = await this.vendorManager.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOVendor), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			POCOVendor response = await this.vendorManager.Get(id);

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
		[ProducesResponseType(typeof(POCOVendor), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiVendorModel model)
		{
			CreateResponse<POCOVendor> result = await this.vendorManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.BusinessEntityID.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/Vendors/{result.Record.BusinessEntityID.ToString()}");
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
		[ProducesResponseType(typeof(List<POCOVendor>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiVendorModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<POCOVendor> records = new List<POCOVendor>();
			foreach (var model in models)
			{
				CreateResponse<POCOVendor> result = await this.vendorManager.Create(model);

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
		[ProducesResponseType(typeof(POCOVendor), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiVendorModel model)
		{
			try
			{
				ActionResponse result = await this.vendorManager.Update(id, model);

				if (result.Success)
				{
					POCOVendor response = await this.vendorManager.Get(id);

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
			ActionResponse result = await this.vendorManager.Delete(id);

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
		[Route("getAccountNumber/{accountNumber}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOVendor), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> GetAccountNumber(string accountNumber)
		{
			POCOVendor response = await this.vendorManager.GetAccountNumber(accountNumber);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}
	}
}

/*<Codenesium>
    <Hash>3897f2aacc1f3877c4f445d1c2b21ed0</Hash>
</Codenesium>*/