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
	public abstract class AbstractBusinessEntityAddressController: AbstractApiController
	{
		protected IBusinessEntityAddressService businessEntityAddressService;

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractBusinessEntityAddressController(
			ServiceSettings settings,
			ILogger<AbstractBusinessEntityAddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityAddressService businessEntityAddressService
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.businessEntityAddressService = businessEntityAddressService;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiBusinessEntityAddressResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiBusinessEntityAddressResponseModel> response = await this.businessEntityAddressService.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiBusinessEntityAddressResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiBusinessEntityAddressResponseModel response = await this.businessEntityAddressService.Get(id);

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
			CreateResponse<ApiBusinessEntityAddressResponseModel> result = await this.businessEntityAddressService.Create(model);

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
				CreateResponse<ApiBusinessEntityAddressResponseModel> result = await this.businessEntityAddressService.Create(model);

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
		[ProducesResponseType(typeof(ApiBusinessEntityAddressResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiBusinessEntityAddressRequestModel model)
		{
			ActionResponse result = await this.businessEntityAddressService.Update(id, model);

			if (result.Success)
			{
				ApiBusinessEntityAddressResponseModel response = await this.businessEntityAddressService.Get(id);

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
			ActionResponse result = await this.businessEntityAddressService.Delete(id);

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
			List<ApiBusinessEntityAddressResponseModel> response = await this.businessEntityAddressService.GetAddressID(addressID);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("getAddressTypeID/{addressTypeID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiBusinessEntityAddressResponseModel>), 200)]
		public async virtual Task<IActionResult> GetAddressTypeID(int addressTypeID)
		{
			List<ApiBusinessEntityAddressResponseModel> response = await this.businessEntityAddressService.GetAddressTypeID(addressTypeID);

			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>e085bf1c10d44441c7dabc33bf574847</Hash>
</Codenesium>*/