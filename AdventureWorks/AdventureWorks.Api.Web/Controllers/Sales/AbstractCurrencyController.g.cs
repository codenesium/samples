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
	public abstract class AbstractCurrencyController : AbstractApiController
	{
		protected ICurrencyService CurrencyService { get; private set; }

		protected IApiCurrencyServerModelMapper CurrencyModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractCurrencyController(
			ApiSettings settings,
			ILogger<AbstractCurrencyController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICurrencyService currencyService,
			IApiCurrencyServerModelMapper currencyModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.CurrencyService = currencyService;
			this.CurrencyModelMapper = currencyModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCurrencyServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiCurrencyServerResponseModel> response = await this.CurrencyService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiCurrencyServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(string id)
		{
			ApiCurrencyServerResponseModel response = await this.CurrencyService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiCurrencyServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiCurrencyServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiCurrencyServerResponseModel> records = new List<ApiCurrencyServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiCurrencyServerResponseModel> result = await this.CurrencyService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiCurrencyServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiCurrencyServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiCurrencyServerRequestModel model)
		{
			CreateResponse<ApiCurrencyServerResponseModel> result = await this.CurrencyService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Currencies/{result.Record.CurrencyCode}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiCurrencyServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiCurrencyServerRequestModel> patch)
		{
			ApiCurrencyServerResponseModel record = await this.CurrencyService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiCurrencyServerRequestModel model = await this.PatchModel(id, patch) as ApiCurrencyServerRequestModel;

				UpdateResponse<ApiCurrencyServerResponseModel> result = await this.CurrencyService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiCurrencyServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(string id, [FromBody] ApiCurrencyServerRequestModel model)
		{
			ApiCurrencyServerRequestModel request = await this.PatchModel(id, this.CurrencyModelMapper.CreatePatch(model)) as ApiCurrencyServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiCurrencyServerResponseModel> result = await this.CurrencyService.Update(id, request);

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

		public virtual async Task<IActionResult> Delete(string id)
		{
			ActionResponse result = await this.CurrencyService.Delete(id);

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
		[Route("byName/{name}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiCurrencyServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByName(string name)
		{
			ApiCurrencyServerResponseModel response = await this.CurrencyService.ByName(name);

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
		[Route("{fromCurrencyCode}/CurrencyRates")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCurrencyRateServerResponseModel>), 200)]
		public async virtual Task<IActionResult> CurrencyRatesByFromCurrencyCode(string fromCurrencyCode, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiCurrencyRateServerResponseModel> response = await this.CurrencyService.CurrencyRatesByFromCurrencyCode(fromCurrencyCode, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{toCurrencyCode}/CurrencyRatesByToCurrencyCode")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCurrencyRateServerResponseModel>), 200)]
		public async virtual Task<IActionResult> CurrencyRatesByToCurrencyCode(string toCurrencyCode, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiCurrencyRateServerResponseModel> response = await this.CurrencyService.CurrencyRatesByToCurrencyCode(toCurrencyCode, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiCurrencyServerRequestModel> PatchModel(string id, JsonPatchDocument<ApiCurrencyServerRequestModel> patch)
		{
			var record = await this.CurrencyService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiCurrencyServerRequestModel request = this.CurrencyModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>182bd2bab53551616742971d3e12eb28</Hash>
</Codenesium>*/