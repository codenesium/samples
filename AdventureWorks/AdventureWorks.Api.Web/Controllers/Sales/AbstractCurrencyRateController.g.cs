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
	public abstract class AbstractCurrencyRateController : AbstractApiController
	{
		protected ICurrencyRateService CurrencyRateService { get; private set; }

		protected IApiCurrencyRateServerModelMapper CurrencyRateModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractCurrencyRateController(
			ApiSettings settings,
			ILogger<AbstractCurrencyRateController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICurrencyRateService currencyRateService,
			IApiCurrencyRateServerModelMapper currencyRateModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.CurrencyRateService = currencyRateService;
			this.CurrencyRateModelMapper = currencyRateModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCurrencyRateServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiCurrencyRateServerResponseModel> response = await this.CurrencyRateService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiCurrencyRateServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiCurrencyRateServerResponseModel response = await this.CurrencyRateService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiCurrencyRateServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiCurrencyRateServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiCurrencyRateServerResponseModel> records = new List<ApiCurrencyRateServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiCurrencyRateServerResponseModel> result = await this.CurrencyRateService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiCurrencyRateServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiCurrencyRateServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiCurrencyRateServerRequestModel model)
		{
			CreateResponse<ApiCurrencyRateServerResponseModel> result = await this.CurrencyRateService.Create(model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiCurrencyRateServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiCurrencyRateServerRequestModel> patch)
		{
			ApiCurrencyRateServerResponseModel record = await this.CurrencyRateService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiCurrencyRateServerRequestModel model = await this.PatchModel(id, patch) as ApiCurrencyRateServerRequestModel;

				UpdateResponse<ApiCurrencyRateServerResponseModel> result = await this.CurrencyRateService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiCurrencyRateServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiCurrencyRateServerRequestModel model)
		{
			ApiCurrencyRateServerRequestModel request = await this.PatchModel(id, this.CurrencyRateModelMapper.CreatePatch(model)) as ApiCurrencyRateServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiCurrencyRateServerResponseModel> result = await this.CurrencyRateService.Update(id, request);

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
			ActionResponse result = await this.CurrencyRateService.Delete(id);

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
		[Route("byCurrencyRateDateFromCurrencyCodeToCurrencyCode/{currencyRateDate}/{fromCurrencyCode}/{toCurrencyCode}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiCurrencyRateServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode)
		{
			ApiCurrencyRateServerResponseModel response = await this.CurrencyRateService.ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(currencyRateDate, fromCurrencyCode, toCurrencyCode);

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
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderServerResponseModel>), 200)]
		public async virtual Task<IActionResult> SalesOrderHeadersByCurrencyRateID(int currencyRateID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSalesOrderHeaderServerResponseModel> response = await this.CurrencyRateService.SalesOrderHeadersByCurrencyRateID(currencyRateID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiCurrencyRateServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiCurrencyRateServerRequestModel> patch)
		{
			var record = await this.CurrencyRateService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiCurrencyRateServerRequestModel request = this.CurrencyRateModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>be7dd1148660af3514dcce25977e5fdd</Hash>
</Codenesium>*/