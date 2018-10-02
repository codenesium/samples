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
	public abstract class AbstractVStateProvinceCountryRegionController : AbstractApiController
	{
		protected IVStateProvinceCountryRegionService VStateProvinceCountryRegionService { get; private set; }

		protected IApiVStateProvinceCountryRegionModelMapper VStateProvinceCountryRegionModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractVStateProvinceCountryRegionController(
			ApiSettings settings,
			ILogger<AbstractVStateProvinceCountryRegionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVStateProvinceCountryRegionService vStateProvinceCountryRegionService,
			IApiVStateProvinceCountryRegionModelMapper vStateProvinceCountryRegionModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.VStateProvinceCountryRegionService = vStateProvinceCountryRegionService;
			this.VStateProvinceCountryRegionModelMapper = vStateProvinceCountryRegionModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVStateProvinceCountryRegionResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiVStateProvinceCountryRegionResponseModel> response = await this.VStateProvinceCountryRegionService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiVStateProvinceCountryRegionResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiVStateProvinceCountryRegionResponseModel response = await this.VStateProvinceCountryRegionService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiVStateProvinceCountryRegionResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiVStateProvinceCountryRegionRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiVStateProvinceCountryRegionResponseModel> records = new List<ApiVStateProvinceCountryRegionResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiVStateProvinceCountryRegionResponseModel> result = await this.VStateProvinceCountryRegionService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiVStateProvinceCountryRegionResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiVStateProvinceCountryRegionRequestModel model)
		{
			CreateResponse<ApiVStateProvinceCountryRegionResponseModel> result = await this.VStateProvinceCountryRegionService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/VStateProvinceCountryRegions/{result.Record.StateProvinceID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiVStateProvinceCountryRegionResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiVStateProvinceCountryRegionRequestModel> patch)
		{
			ApiVStateProvinceCountryRegionResponseModel record = await this.VStateProvinceCountryRegionService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiVStateProvinceCountryRegionRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiVStateProvinceCountryRegionResponseModel> result = await this.VStateProvinceCountryRegionService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiVStateProvinceCountryRegionResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiVStateProvinceCountryRegionRequestModel model)
		{
			ApiVStateProvinceCountryRegionRequestModel request = await this.PatchModel(id, this.VStateProvinceCountryRegionModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiVStateProvinceCountryRegionResponseModel> result = await this.VStateProvinceCountryRegionService.Update(id, request);

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
			ActionResponse result = await this.VStateProvinceCountryRegionService.Delete(id);

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
		[Route("byStateProvinceIDCountryRegionCode/{stateProvinceID}/{countryRegionCode}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiVStateProvinceCountryRegionResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByStateProvinceIDCountryRegionCode(int stateProvinceID, string countryRegionCode)
		{
			ApiVStateProvinceCountryRegionResponseModel response = await this.VStateProvinceCountryRegionService.ByStateProvinceIDCountryRegionCode(stateProvinceID, countryRegionCode);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		private async Task<ApiVStateProvinceCountryRegionRequestModel> PatchModel(int id, JsonPatchDocument<ApiVStateProvinceCountryRegionRequestModel> patch)
		{
			var record = await this.VStateProvinceCountryRegionService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiVStateProvinceCountryRegionRequestModel request = this.VStateProvinceCountryRegionModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>34232b8624e2c62c1a41f7c067470358</Hash>
</Codenesium>*/