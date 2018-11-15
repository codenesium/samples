using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	public abstract class AbstractSalesTaxRateController : AbstractApiController
	{
		protected ISalesTaxRateService SalesTaxRateService { get; private set; }

		protected IApiSalesTaxRateServerModelMapper SalesTaxRateModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractSalesTaxRateController(
			ApiSettings settings,
			ILogger<AbstractSalesTaxRateController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesTaxRateService salesTaxRateService,
			IApiSalesTaxRateServerModelMapper salesTaxRateModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.SalesTaxRateService = salesTaxRateService;
			this.SalesTaxRateModelMapper = salesTaxRateModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesTaxRateServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSalesTaxRateServerResponseModel> response = await this.SalesTaxRateService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSalesTaxRateServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiSalesTaxRateServerResponseModel response = await this.SalesTaxRateService.Get(id);

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
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<List<ApiSalesTaxRateServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSalesTaxRateServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiSalesTaxRateServerResponseModel> records = new List<ApiSalesTaxRateServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiSalesTaxRateServerResponseModel> result = await this.SalesTaxRateService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiSalesTaxRateServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiSalesTaxRateServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiSalesTaxRateServerRequestModel model)
		{
			CreateResponse<ApiSalesTaxRateServerResponseModel> result = await this.SalesTaxRateService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/SalesTaxRates/{result.Record.SalesTaxRateID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiSalesTaxRateServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSalesTaxRateServerRequestModel> patch)
		{
			ApiSalesTaxRateServerResponseModel record = await this.SalesTaxRateService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiSalesTaxRateServerRequestModel model = await this.PatchModel(id, patch) as ApiSalesTaxRateServerRequestModel;

				UpdateResponse<ApiSalesTaxRateServerResponseModel> result = await this.SalesTaxRateService.Update(id, model);

				if (result.Success)
				{
					return this.Ok(result);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiSalesTaxRateServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSalesTaxRateServerRequestModel model)
		{
			ApiSalesTaxRateServerRequestModel request = await this.PatchModel(id, this.SalesTaxRateModelMapper.CreatePatch(model)) as ApiSalesTaxRateServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiSalesTaxRateServerResponseModel> result = await this.SalesTaxRateService.Update(id, request);

				if (result.Success)
				{
					return this.Ok(result);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(ActionResponse), 200)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.SalesTaxRateService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("byRowguid/{rowguid}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSalesTaxRateServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByRowguid(Guid rowguid)
		{
			ApiSalesTaxRateServerResponseModel response = await this.SalesTaxRateService.ByRowguid(rowguid);

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
		[Route("byStateProvinceIDTaxType/{stateProvinceID}/{taxType}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSalesTaxRateServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByStateProvinceIDTaxType(int stateProvinceID, int taxType)
		{
			ApiSalesTaxRateServerResponseModel response = await this.SalesTaxRateService.ByStateProvinceIDTaxType(stateProvinceID, taxType);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		private async Task<ApiSalesTaxRateServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiSalesTaxRateServerRequestModel> patch)
		{
			var record = await this.SalesTaxRateService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiSalesTaxRateServerRequestModel request = this.SalesTaxRateModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>6847277e68cd2b58628637c79cbf17a2</Hash>
</Codenesium>*/