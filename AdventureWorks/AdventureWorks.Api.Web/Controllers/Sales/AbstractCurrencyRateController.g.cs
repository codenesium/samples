using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
	public abstract class AbstractCurrencyRateController : AbstractApiController
	{
		protected ICurrencyRateService CurrencyRateService { get; private set; }

		protected IApiCurrencyRateModelMapper CurrencyRateModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractCurrencyRateController(
			ApiSettings settings,
			ILogger<AbstractCurrencyRateController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICurrencyRateService currencyRateService,
			IApiCurrencyRateModelMapper currencyRateModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.CurrencyRateService = currencyRateService;
			this.CurrencyRateModelMapper = currencyRateModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCurrencyRateResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiCurrencyRateResponseModel> response = await this.CurrencyRateService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiCurrencyRateResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiCurrencyRateResponseModel response = await this.CurrencyRateService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiCurrencyRateResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiCurrencyRateRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiCurrencyRateResponseModel> records = new List<ApiCurrencyRateResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiCurrencyRateResponseModel> result = await this.CurrencyRateService.Create(model);

				if (result.Success)
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

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiCurrencyRateResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiCurrencyRateRequestModel model)
		{
			CreateResponse<ApiCurrencyRateResponseModel> result = await this.CurrencyRateService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/CurrencyRates/{result.Record.CurrencyRateID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiCurrencyRateResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiCurrencyRateRequestModel> patch)
		{
			ApiCurrencyRateResponseModel record = await this.CurrencyRateService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiCurrencyRateRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiCurrencyRateResponseModel> result = await this.CurrencyRateService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiCurrencyRateResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiCurrencyRateRequestModel model)
		{
			ApiCurrencyRateRequestModel request = await this.PatchModel(id, this.CurrencyRateModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiCurrencyRateResponseModel> result = await this.CurrencyRateService.Update(id, request);

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
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.CurrencyRateService.Delete(id);

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
		[Route("byCurrencyRateDateFromCurrencyCodeToCurrencyCode/{currencyRateDate}/{fromCurrencyCode}/{toCurrencyCode}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiCurrencyRateResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode)
		{
			ApiCurrencyRateResponseModel response = await this.CurrencyRateService.ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(currencyRateDate, fromCurrencyCode, toCurrencyCode);

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
		[Route("{currencyRateID}/SalesOrderHeaders")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderResponseModel>), 200)]
		public async virtual Task<IActionResult> SalesOrderHeaders(int currencyRateID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiSalesOrderHeaderResponseModel> response = await this.CurrencyRateService.SalesOrderHeaders(currencyRateID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiCurrencyRateRequestModel> PatchModel(int id, JsonPatchDocument<ApiCurrencyRateRequestModel> patch)
		{
			var record = await this.CurrencyRateService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiCurrencyRateRequestModel request = this.CurrencyRateModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>ecac066280b6a0b3c4847245e913be31</Hash>
</Codenesium>*/