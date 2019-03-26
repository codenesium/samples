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
	public abstract class AbstractCountryRegionController : AbstractApiController
	{
		protected ICountryRegionService CountryRegionService { get; private set; }

		protected IApiCountryRegionServerModelMapper CountryRegionModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractCountryRegionController(
			ApiSettings settings,
			ILogger<AbstractCountryRegionController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryRegionService countryRegionService,
			IApiCountryRegionServerModelMapper countryRegionModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.CountryRegionService = countryRegionService;
			this.CountryRegionModelMapper = countryRegionModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCountryRegionServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiCountryRegionServerResponseModel> response = await this.CountryRegionService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiCountryRegionServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(string id)
		{
			ApiCountryRegionServerResponseModel response = await this.CountryRegionService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiCountryRegionServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiCountryRegionServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiCountryRegionServerResponseModel> records = new List<ApiCountryRegionServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiCountryRegionServerResponseModel> result = await this.CountryRegionService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiCountryRegionServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiCountryRegionServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiCountryRegionServerRequestModel model)
		{
			CreateResponse<ApiCountryRegionServerResponseModel> result = await this.CountryRegionService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/CountryRegions/{result.Record.CountryRegionCode}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiCountryRegionServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiCountryRegionServerRequestModel> patch)
		{
			ApiCountryRegionServerResponseModel record = await this.CountryRegionService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiCountryRegionServerRequestModel model = await this.PatchModel(id, patch) as ApiCountryRegionServerRequestModel;

				UpdateResponse<ApiCountryRegionServerResponseModel> result = await this.CountryRegionService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiCountryRegionServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(string id, [FromBody] ApiCountryRegionServerRequestModel model)
		{
			ApiCountryRegionServerRequestModel request = await this.PatchModel(id, this.CountryRegionModelMapper.CreatePatch(model)) as ApiCountryRegionServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiCountryRegionServerResponseModel> result = await this.CountryRegionService.Update(id, request);

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
			ActionResponse result = await this.CountryRegionService.Delete(id);

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
		[ProducesResponseType(typeof(ApiCountryRegionServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByName(string name)
		{
			ApiCountryRegionServerResponseModel response = await this.CountryRegionService.ByName(name);

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
		[Route("{countryRegionCode}/StateProvinces")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiStateProvinceServerResponseModel>), 200)]
		public async virtual Task<IActionResult> StateProvincesByCountryRegionCode(string countryRegionCode, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiStateProvinceServerResponseModel> response = await this.CountryRegionService.StateProvincesByCountryRegionCode(countryRegionCode, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiCountryRegionServerRequestModel> PatchModel(string id, JsonPatchDocument<ApiCountryRegionServerRequestModel> patch)
		{
			var record = await this.CountryRegionService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiCountryRegionServerRequestModel request = this.CountryRegionModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>8dd2ae85060670fbb4dede26d6570588</Hash>
</Codenesium>*/