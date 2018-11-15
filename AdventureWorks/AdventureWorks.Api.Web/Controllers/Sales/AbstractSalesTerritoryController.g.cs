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
	public abstract class AbstractSalesTerritoryController : AbstractApiController
	{
		protected ISalesTerritoryService SalesTerritoryService { get; private set; }

		protected IApiSalesTerritoryServerModelMapper SalesTerritoryModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractSalesTerritoryController(
			ApiSettings settings,
			ILogger<AbstractSalesTerritoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesTerritoryService salesTerritoryService,
			IApiSalesTerritoryServerModelMapper salesTerritoryModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.SalesTerritoryService = salesTerritoryService;
			this.SalesTerritoryModelMapper = salesTerritoryModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesTerritoryServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSalesTerritoryServerResponseModel> response = await this.SalesTerritoryService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSalesTerritoryServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiSalesTerritoryServerResponseModel response = await this.SalesTerritoryService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiSalesTerritoryServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSalesTerritoryServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiSalesTerritoryServerResponseModel> records = new List<ApiSalesTerritoryServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiSalesTerritoryServerResponseModel> result = await this.SalesTerritoryService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiSalesTerritoryServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiSalesTerritoryServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiSalesTerritoryServerRequestModel model)
		{
			CreateResponse<ApiSalesTerritoryServerResponseModel> result = await this.SalesTerritoryService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/SalesTerritories/{result.Record.TerritoryID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiSalesTerritoryServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSalesTerritoryServerRequestModel> patch)
		{
			ApiSalesTerritoryServerResponseModel record = await this.SalesTerritoryService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiSalesTerritoryServerRequestModel model = await this.PatchModel(id, patch) as ApiSalesTerritoryServerRequestModel;

				UpdateResponse<ApiSalesTerritoryServerResponseModel> result = await this.SalesTerritoryService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiSalesTerritoryServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSalesTerritoryServerRequestModel model)
		{
			ApiSalesTerritoryServerRequestModel request = await this.PatchModel(id, this.SalesTerritoryModelMapper.CreatePatch(model)) as ApiSalesTerritoryServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiSalesTerritoryServerResponseModel> result = await this.SalesTerritoryService.Update(id, request);

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
			ActionResponse result = await this.SalesTerritoryService.Delete(id);

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
		[ProducesResponseType(typeof(ApiSalesTerritoryServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByName(string name)
		{
			ApiSalesTerritoryServerResponseModel response = await this.SalesTerritoryService.ByName(name);

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
		[ProducesResponseType(typeof(ApiSalesTerritoryServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByRowguid(Guid rowguid)
		{
			ApiSalesTerritoryServerResponseModel response = await this.SalesTerritoryService.ByRowguid(rowguid);

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
		[Route("{territoryID}/Customers")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCustomerServerResponseModel>), 200)]
		public async virtual Task<IActionResult> CustomersByTerritoryID(int territoryID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiCustomerServerResponseModel> response = await this.SalesTerritoryService.CustomersByTerritoryID(territoryID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{territoryID}/SalesOrderHeaders")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderServerResponseModel>), 200)]
		public async virtual Task<IActionResult> SalesOrderHeadersByTerritoryID(int territoryID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSalesOrderHeaderServerResponseModel> response = await this.SalesTerritoryService.SalesOrderHeadersByTerritoryID(territoryID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{territoryID}/SalesPersons")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesPersonServerResponseModel>), 200)]
		public async virtual Task<IActionResult> SalesPersonsByTerritoryID(int territoryID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSalesPersonServerResponseModel> response = await this.SalesTerritoryService.SalesPersonsByTerritoryID(territoryID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiSalesTerritoryServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiSalesTerritoryServerRequestModel> patch)
		{
			var record = await this.SalesTerritoryService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiSalesTerritoryServerRequestModel request = this.SalesTerritoryModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>63e5841d202899ee9f5e774c61ca89ab</Hash>
</Codenesium>*/