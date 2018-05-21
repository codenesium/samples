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
	public abstract class AbstractStoreController: AbstractApiController
	{
		protected IBOStore storeManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractStoreController(
			ServiceSettings settings,
			ILogger<AbstractStoreController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOStore storeManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.storeManager = storeManager;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOStore>), 200)]
		public async virtual Task<IActionResult> All()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<POCOStore> response = await this.storeManager.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOStore), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			POCOStore response = await this.storeManager.Get(id);

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
		[ProducesResponseType(typeof(POCOStore), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiStoreModel model)
		{
			CreateResponse<POCOStore> result = await this.storeManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.BusinessEntityID.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/Stores/{result.Record.BusinessEntityID.ToString()}");
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
		[ProducesResponseType(typeof(List<POCOStore>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiStoreModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<POCOStore> records = new List<POCOStore>();
			foreach (var model in models)
			{
				CreateResponse<POCOStore> result = await this.storeManager.Create(model);

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
		[ProducesResponseType(typeof(POCOStore), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiStoreModel model)
		{
			try
			{
				ActionResponse result = await this.storeManager.Update(id, model);

				if (result.Success)
				{
					POCOStore response = await this.storeManager.Get(id);

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
			ActionResponse result = await this.storeManager.Delete(id);

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
		[Route("getSalesPersonID/{salesPersonID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOStore>), 200)]
		public async virtual Task<IActionResult> GetSalesPersonID(Nullable<int> salesPersonID)
		{
			List<POCOStore> response = await this.storeManager.GetSalesPersonID(salesPersonID);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("getDemographics/{demographics}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOStore>), 200)]
		public async virtual Task<IActionResult> GetDemographics(string demographics)
		{
			List<POCOStore> response = await this.storeManager.GetDemographics(demographics);

			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>cced7342e32f035190cf60edbaa5a7f4</Hash>
</Codenesium>*/