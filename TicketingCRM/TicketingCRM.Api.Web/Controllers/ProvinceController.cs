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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
	[Route("api/provinces")]
	[ApiController]
	[ApiVersion("1.0")]

	public class ProvinceController : AbstractApiController
	{
		protected IProvinceService ProvinceService { get; private set; }

		protected IApiProvinceServerModelMapper ProvinceModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public ProvinceController(
			ApiSettings settings,
			ILogger<ProvinceController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProvinceService provinceService,
			IApiProvinceServerModelMapper provinceModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.ProvinceService = provinceService;
			this.ProvinceModelMapper = provinceModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProvinceServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiProvinceServerResponseModel> response = await this.ProvinceService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiProvinceServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiProvinceServerResponseModel response = await this.ProvinceService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiProvinceServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiProvinceServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiProvinceServerResponseModel> records = new List<ApiProvinceServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiProvinceServerResponseModel> result = await this.ProvinceService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiProvinceServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiProvinceServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiProvinceServerRequestModel model)
		{
			CreateResponse<ApiProvinceServerResponseModel> result = await this.ProvinceService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Provinces/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiProvinceServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiProvinceServerRequestModel> patch)
		{
			ApiProvinceServerResponseModel record = await this.ProvinceService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiProvinceServerRequestModel model = await this.PatchModel(id, patch) as ApiProvinceServerRequestModel;

				UpdateResponse<ApiProvinceServerResponseModel> result = await this.ProvinceService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiProvinceServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiProvinceServerRequestModel model)
		{
			ApiProvinceServerRequestModel request = await this.PatchModel(id, this.ProvinceModelMapper.CreatePatch(model)) as ApiProvinceServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiProvinceServerResponseModel> result = await this.ProvinceService.Update(id, request);

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
			ActionResponse result = await this.ProvinceService.Delete(id);

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
		[Route("byCountryId/{countryId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProvinceServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByCountryId(int countryId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiProvinceServerResponseModel> response = await this.ProvinceService.ByCountryId(countryId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{provinceId}/Cities")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCityServerResponseModel>), 200)]
		public async virtual Task<IActionResult> CitiesByProvinceId(int provinceId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiCityServerResponseModel> response = await this.ProvinceService.CitiesByProvinceId(provinceId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{provinceId}/Venues")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVenueServerResponseModel>), 200)]
		public async virtual Task<IActionResult> VenuesByProvinceId(int provinceId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiVenueServerResponseModel> response = await this.ProvinceService.VenuesByProvinceId(provinceId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiProvinceServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiProvinceServerRequestModel> patch)
		{
			var record = await this.ProvinceService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiProvinceServerRequestModel request = this.ProvinceModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>ef759a61eb0c7fd3b2621517eecd25c6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/