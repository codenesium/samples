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
	public abstract class AbstractBusinessEntityAddressController: AbstractApiController
	{
		protected IBOBusinessEntityAddress businessEntityAddressManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractBusinessEntityAddressController(
			ServiceSettings settings,
			ILogger<AbstractBusinessEntityAddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOBusinessEntityAddress businessEntityAddressManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.businessEntityAddressManager = businessEntityAddressManager;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiBusinessEntityAddressResponseModel>), 200)]
		public async virtual Task<IActionResult> All()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiBusinessEntityAddressResponseModel> response = await this.businessEntityAddressManager.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiBusinessEntityAddressResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiBusinessEntityAddressResponseModel response = await this.businessEntityAddressManager.Get(id);

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
		[ProducesResponseType(typeof(ApiBusinessEntityAddressResponseModel), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiBusinessEntityAddressRequestModel model)
		{
			CreateResponse<ApiBusinessEntityAddressResponseModel> result = await this.businessEntityAddressManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.BusinessEntityID.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/BusinessEntityAddresses/{result.Record.BusinessEntityID.ToString()}");
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
		[ProducesResponseType(typeof(List<ApiBusinessEntityAddressResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiBusinessEntityAddressRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiBusinessEntityAddressResponseModel> records = new List<ApiBusinessEntityAddressResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiBusinessEntityAddressResponseModel> result = await this.businessEntityAddressManager.Create(model);

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
		[ProducesResponseType(typeof(DTOBusinessEntityAddress), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiBusinessEntityAddressRequestModel model)
		{
			try
			{
				ActionResponse result = await this.businessEntityAddressManager.Update(id, model);

				if (result.Success)
				{
					ApiBusinessEntityAddressResponseModel response = await this.businessEntityAddressManager.Get(id);

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
			ActionResponse result = await this.businessEntityAddressManager.Delete(id);

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
		[Route("getAddressID/{addressID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiBusinessEntityAddressResponseModel>), 200)]
		public async virtual Task<IActionResult> GetAddressID(int addressID)
		{
			List<ApiBusinessEntityAddressResponseModel> response = await this.businessEntityAddressManager.GetAddressID(addressID);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("getAddressTypeID/{addressTypeID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiBusinessEntityAddressResponseModel>), 200)]
		public async virtual Task<IActionResult> GetAddressTypeID(int addressTypeID)
		{
			List<ApiBusinessEntityAddressResponseModel> response = await this.businessEntityAddressManager.GetAddressTypeID(addressTypeID);

			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>8550ec5bdfb0a88322ca12244658e771</Hash>
</Codenesium>*/