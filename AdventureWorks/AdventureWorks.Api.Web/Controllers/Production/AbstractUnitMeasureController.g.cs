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

		protected IApiUnitMeasureServerModelMapper UnitMeasureModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractUnitMeasureController(
			ApiSettings settings,
			ILogger<AbstractUnitMeasureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IUnitMeasureService unitMeasureService,
			IApiUnitMeasureServerModelMapper unitMeasureModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.UnitMeasureService = unitMeasureService;
			this.UnitMeasureModelMapper = unitMeasureModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiUnitMeasureServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiUnitMeasureServerResponseModel> response = await this.UnitMeasureService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiUnitMeasureServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(string id)
		{
			ApiUnitMeasureServerResponseModel response = await this.UnitMeasureService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiUnitMeasureServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiUnitMeasureServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiUnitMeasureServerResponseModel> records = new List<ApiUnitMeasureServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiUnitMeasureServerResponseModel> result = await this.UnitMeasureService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiUnitMeasureServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiUnitMeasureServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiUnitMeasureServerRequestModel model)
		{
			CreateResponse<ApiUnitMeasureServerResponseModel> result = await this.UnitMeasureService.Create(model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiUnitMeasureServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiUnitMeasureServerRequestModel> patch)
		{
			ApiUnitMeasureServerResponseModel record = await this.UnitMeasureService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiUnitMeasureServerRequestModel model = await this.PatchModel(id, patch) as ApiUnitMeasureServerRequestModel;

				UpdateResponse<ApiUnitMeasureServerResponseModel> result = await this.UnitMeasureService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiUnitMeasureServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(string id, [FromBody] ApiUnitMeasureServerRequestModel model)
		{
			ApiUnitMeasureServerRequestModel request = await this.PatchModel(id, this.UnitMeasureModelMapper.CreatePatch(model)) as ApiUnitMeasureServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiUnitMeasureServerResponseModel> result = await this.UnitMeasureService.Update(id, request);

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
		[ProducesResponseType(typeof(ApiUnitMeasureServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByName(string name)
		{
			ApiUnitMeasureServerResponseModel response = await this.UnitMeasureService.ByName(name);

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
		[Route("{unitMeasureCode}/BillOfMaterials")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiBillOfMaterialServerResponseModel>), 200)]
		public async virtual Task<IActionResult> BillOfMaterialsByUnitMeasureCode(string unitMeasureCode, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiBillOfMaterialServerResponseModel> response = await this.UnitMeasureService.BillOfMaterialsByUnitMeasureCode(unitMeasureCode, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{sizeUnitMeasureCode}/Products")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ProductsBySizeUnitMeasureCode(string sizeUnitMeasureCode, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiProductServerResponseModel> response = await this.UnitMeasureService.ProductsBySizeUnitMeasureCode(sizeUnitMeasureCode, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{weightUnitMeasureCode}/ProductsByWeightUnitMeasureCode")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ProductsByWeightUnitMeasureCode(string weightUnitMeasureCode, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiProductServerResponseModel> response = await this.UnitMeasureService.ProductsByWeightUnitMeasureCode(weightUnitMeasureCode, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiUnitMeasureServerRequestModel> PatchModel(string id, JsonPatchDocument<ApiUnitMeasureServerRequestModel> patch)
		{
			var record = await this.UnitMeasureService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiUnitMeasureServerRequestModel request = this.UnitMeasureModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>4ca40bcfe4dc045ea676742deed8b160</Hash>
</Codenesium>*/