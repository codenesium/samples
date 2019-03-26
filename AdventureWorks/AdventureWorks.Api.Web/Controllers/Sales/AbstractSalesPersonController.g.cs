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

		protected IApiSalesPersonServerModelMapper SalesPersonModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractSalesPersonController(
			ApiSettings settings,
			ILogger<AbstractSalesPersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesPersonService salesPersonService,
			IApiSalesPersonServerModelMapper salesPersonModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.SalesPersonService = salesPersonService;
			this.SalesPersonModelMapper = salesPersonModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesPersonServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiSalesPersonServerResponseModel> response = await this.SalesPersonService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSalesPersonServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiSalesPersonServerResponseModel response = await this.SalesPersonService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiSalesPersonServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSalesPersonServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiSalesPersonServerResponseModel> records = new List<ApiSalesPersonServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiSalesPersonServerResponseModel> result = await this.SalesPersonService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiSalesPersonServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiSalesPersonServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiSalesPersonServerRequestModel model)
		{
			CreateResponse<ApiSalesPersonServerResponseModel> result = await this.SalesPersonService.Create(model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiSalesPersonServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSalesPersonServerRequestModel> patch)
		{
			ApiSalesPersonServerResponseModel record = await this.SalesPersonService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiSalesPersonServerRequestModel model = await this.PatchModel(id, patch) as ApiSalesPersonServerRequestModel;

				UpdateResponse<ApiSalesPersonServerResponseModel> result = await this.SalesPersonService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiSalesPersonServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSalesPersonServerRequestModel model)
		{
			ApiSalesPersonServerRequestModel request = await this.PatchModel(id, this.SalesPersonModelMapper.CreatePatch(model)) as ApiSalesPersonServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiSalesPersonServerResponseModel> result = await this.SalesPersonService.Update(id, request);

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
		[Route("byRowguid/{rowguid}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSalesPersonServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByRowguid(Guid rowguid)
		{
			ApiSalesPersonServerResponseModel response = await this.SalesPersonService.ByRowguid(rowguid);

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
		[Route("{salesPersonID}/SalesOrderHeaders")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderServerResponseModel>), 200)]
		public async virtual Task<IActionResult> SalesOrderHeadersBySalesPersonID(int salesPersonID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSalesOrderHeaderServerResponseModel> response = await this.SalesPersonService.SalesOrderHeadersBySalesPersonID(salesPersonID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{salesPersonID}/Stores")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiStoreServerResponseModel>), 200)]
		public async virtual Task<IActionResult> StoresBySalesPersonID(int salesPersonID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiStoreServerResponseModel> response = await this.SalesPersonService.StoresBySalesPersonID(salesPersonID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiSalesPersonServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiSalesPersonServerRequestModel> patch)
		{
			var record = await this.SalesPersonService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiSalesPersonServerRequestModel request = this.SalesPersonModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>02228da30c032d7ffd5bccbe465c6a11</Hash>
</Codenesium>*/