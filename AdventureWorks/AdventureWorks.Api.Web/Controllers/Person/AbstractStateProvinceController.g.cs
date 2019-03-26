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
	public abstract class AbstractStateProvinceController : AbstractApiController
	{
		protected IStateProvinceService StateProvinceService { get; private set; }

		protected IApiStateProvinceServerModelMapper StateProvinceModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractStateProvinceController(
			ApiSettings settings,
			ILogger<AbstractStateProvinceController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStateProvinceService stateProvinceService,
			IApiStateProvinceServerModelMapper stateProvinceModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.StateProvinceService = stateProvinceService;
			this.StateProvinceModelMapper = stateProvinceModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiStateProvinceServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiStateProvinceServerResponseModel> response = await this.StateProvinceService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiStateProvinceServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiStateProvinceServerResponseModel response = await this.StateProvinceService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiStateProvinceServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiStateProvinceServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiStateProvinceServerResponseModel> records = new List<ApiStateProvinceServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiStateProvinceServerResponseModel> result = await this.StateProvinceService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiStateProvinceServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiStateProvinceServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiStateProvinceServerRequestModel model)
		{
			CreateResponse<ApiStateProvinceServerResponseModel> result = await this.StateProvinceService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/StateProvinces/{result.Record.StateProvinceID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiStateProvinceServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiStateProvinceServerRequestModel> patch)
		{
			ApiStateProvinceServerResponseModel record = await this.StateProvinceService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiStateProvinceServerRequestModel model = await this.PatchModel(id, patch) as ApiStateProvinceServerRequestModel;

				UpdateResponse<ApiStateProvinceServerResponseModel> result = await this.StateProvinceService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiStateProvinceServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiStateProvinceServerRequestModel model)
		{
			ApiStateProvinceServerRequestModel request = await this.PatchModel(id, this.StateProvinceModelMapper.CreatePatch(model)) as ApiStateProvinceServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiStateProvinceServerResponseModel> result = await this.StateProvinceService.Update(id, request);

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
			ActionResponse result = await this.StateProvinceService.Delete(id);

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
		[ProducesResponseType(typeof(ApiStateProvinceServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByName(string name)
		{
			ApiStateProvinceServerResponseModel response = await this.StateProvinceService.ByName(name);

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
		[Route("byRowguid/{rowguid}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiStateProvinceServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByRowguid(Guid rowguid)
		{
			ApiStateProvinceServerResponseModel response = await this.StateProvinceService.ByRowguid(rowguid);

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
		[Route("byStateProvinceCodeCountryRegionCode/{stateProvinceCode}/{countryRegionCode}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiStateProvinceServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode)
		{
			ApiStateProvinceServerResponseModel response = await this.StateProvinceService.ByStateProvinceCodeCountryRegionCode(stateProvinceCode, countryRegionCode);

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
		[Route("{stateProvinceID}/Addresses")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiAddressServerResponseModel>), 200)]
		public async virtual Task<IActionResult> AddressesByStateProvinceID(int stateProvinceID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiAddressServerResponseModel> response = await this.StateProvinceService.AddressesByStateProvinceID(stateProvinceID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiStateProvinceServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiStateProvinceServerRequestModel> patch)
		{
			var record = await this.StateProvinceService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiStateProvinceServerRequestModel request = this.StateProvinceModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>6e1f9f03e54f507d554db01af1c394e9</Hash>
</Codenesium>*/