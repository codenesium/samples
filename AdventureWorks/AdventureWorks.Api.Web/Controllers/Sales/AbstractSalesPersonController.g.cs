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
	public abstract class AbstractSalesPersonController : AbstractApiController
	{
		protected ISalesPersonService SalesPersonService { get; private set; }

		protected IApiSalesPersonModelMapper SalesPersonModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractSalesPersonController(
			ApiSettings settings,
			ILogger<AbstractSalesPersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesPersonService salesPersonService,
			IApiSalesPersonModelMapper salesPersonModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.SalesPersonService = salesPersonService;
			this.SalesPersonModelMapper = salesPersonModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesPersonResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSalesPersonResponseModel> response = await this.SalesPersonService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSalesPersonResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiSalesPersonResponseModel response = await this.SalesPersonService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiSalesPersonResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSalesPersonRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiSalesPersonResponseModel> records = new List<ApiSalesPersonResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiSalesPersonResponseModel> result = await this.SalesPersonService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiSalesPersonResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiSalesPersonRequestModel model)
		{
			CreateResponse<ApiSalesPersonResponseModel> result = await this.SalesPersonService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/SalesPersons/{result.Record.BusinessEntityID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiSalesPersonResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSalesPersonRequestModel> patch)
		{
			ApiSalesPersonResponseModel record = await this.SalesPersonService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiSalesPersonRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiSalesPersonResponseModel> result = await this.SalesPersonService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiSalesPersonResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSalesPersonRequestModel model)
		{
			ApiSalesPersonRequestModel request = await this.PatchModel(id, this.SalesPersonModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiSalesPersonResponseModel> result = await this.SalesPersonService.Update(id, request);

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
			ActionResponse result = await this.SalesPersonService.Delete(id);

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
		[Route("{salesPersonID}/SalesOrderHeadersBySalesPersonID")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderResponseModel>), 200)]
		public async virtual Task<IActionResult> SalesOrderHeadersBySalesPersonID(int salesPersonID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSalesOrderHeaderResponseModel> response = await this.SalesPersonService.SalesOrderHeadersBySalesPersonID(salesPersonID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{businessEntityID}/SalesPersonQuotaHistoriesByBusinessEntityID")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesPersonQuotaHistoryResponseModel>), 200)]
		public async virtual Task<IActionResult> SalesPersonQuotaHistoriesByBusinessEntityID(int businessEntityID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSalesPersonQuotaHistoryResponseModel> response = await this.SalesPersonService.SalesPersonQuotaHistoriesByBusinessEntityID(businessEntityID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{businessEntityID}/SalesTerritoryHistoriesByBusinessEntityID")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesTerritoryHistoryResponseModel>), 200)]
		public async virtual Task<IActionResult> SalesTerritoryHistoriesByBusinessEntityID(int businessEntityID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSalesTerritoryHistoryResponseModel> response = await this.SalesPersonService.SalesTerritoryHistoriesByBusinessEntityID(businessEntityID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{salesPersonID}/StoresBySalesPersonID")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiStoreResponseModel>), 200)]
		public async virtual Task<IActionResult> StoresBySalesPersonID(int salesPersonID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiStoreResponseModel> response = await this.SalesPersonService.StoresBySalesPersonID(salesPersonID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiSalesPersonRequestModel> PatchModel(int id, JsonPatchDocument<ApiSalesPersonRequestModel> patch)
		{
			var record = await this.SalesPersonService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiSalesPersonRequestModel request = this.SalesPersonModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>08a810bb97da535ad7677f5434704626</Hash>
</Codenesium>*/