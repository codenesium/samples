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
	public abstract class AbstractUnitMeasureController : AbstractApiController
	{
		protected IUnitMeasureService UnitMeasureService { get; private set; }

		protected IApiUnitMeasureModelMapper UnitMeasureModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractUnitMeasureController(
			ApiSettings settings,
			ILogger<AbstractUnitMeasureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IUnitMeasureService unitMeasureService,
			IApiUnitMeasureModelMapper unitMeasureModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.UnitMeasureService = unitMeasureService;
			this.UnitMeasureModelMapper = unitMeasureModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiUnitMeasureResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiUnitMeasureResponseModel> response = await this.UnitMeasureService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiUnitMeasureResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(string id)
		{
			ApiUnitMeasureResponseModel response = await this.UnitMeasureService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiUnitMeasureResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiUnitMeasureRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiUnitMeasureResponseModel> records = new List<ApiUnitMeasureResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiUnitMeasureResponseModel> result = await this.UnitMeasureService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiUnitMeasureResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiUnitMeasureRequestModel model)
		{
			CreateResponse<ApiUnitMeasureResponseModel> result = await this.UnitMeasureService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/UnitMeasures/{result.Record.UnitMeasureCode}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiUnitMeasureResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiUnitMeasureRequestModel> patch)
		{
			ApiUnitMeasureResponseModel record = await this.UnitMeasureService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiUnitMeasureRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiUnitMeasureResponseModel> result = await this.UnitMeasureService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiUnitMeasureResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(string id, [FromBody] ApiUnitMeasureRequestModel model)
		{
			ApiUnitMeasureRequestModel request = await this.PatchModel(id, this.UnitMeasureModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiUnitMeasureResponseModel> result = await this.UnitMeasureService.Update(id, request);

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
			ActionResponse result = await this.UnitMeasureService.Delete(id);

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
		[ProducesResponseType(typeof(ApiUnitMeasureResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByName(string name)
		{
			ApiUnitMeasureResponseModel response = await this.UnitMeasureService.ByName(name);

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
		[Route("{unitMeasureCode}/BillOfMaterialsByUnitMeasureCode")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiBillOfMaterialResponseModel>), 200)]
		public async virtual Task<IActionResult> BillOfMaterialsByUnitMeasureCode(string unitMeasureCode, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiBillOfMaterialResponseModel> response = await this.UnitMeasureService.BillOfMaterialsByUnitMeasureCode(unitMeasureCode, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{sizeUnitMeasureCode}/ProductsBySizeUnitMeasureCode")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductResponseModel>), 200)]
		public async virtual Task<IActionResult> ProductsBySizeUnitMeasureCode(string sizeUnitMeasureCode, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiProductResponseModel> response = await this.UnitMeasureService.ProductsBySizeUnitMeasureCode(sizeUnitMeasureCode, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{weightUnitMeasureCode}/ProductsByWeightUnitMeasureCode")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductResponseModel>), 200)]
		public async virtual Task<IActionResult> ProductsByWeightUnitMeasureCode(string weightUnitMeasureCode, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiProductResponseModel> response = await this.UnitMeasureService.ProductsByWeightUnitMeasureCode(weightUnitMeasureCode, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiUnitMeasureRequestModel> PatchModel(string id, JsonPatchDocument<ApiUnitMeasureRequestModel> patch)
		{
			var record = await this.UnitMeasureService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiUnitMeasureRequestModel request = this.UnitMeasureModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>4419c0f02dd05c0e5ad80558d94b62c1</Hash>
</Codenesium>*/