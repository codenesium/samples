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
	public abstract class AbstractSalesOrderHeaderController : AbstractApiController
	{
		protected ISalesOrderHeaderService SalesOrderHeaderService { get; private set; }

		protected IApiSalesOrderHeaderServerModelMapper SalesOrderHeaderModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractSalesOrderHeaderController(
			ApiSettings settings,
			ILogger<AbstractSalesOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderHeaderService salesOrderHeaderService,
			IApiSalesOrderHeaderServerModelMapper salesOrderHeaderModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.SalesOrderHeaderService = salesOrderHeaderService;
			this.SalesOrderHeaderModelMapper = salesOrderHeaderModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSalesOrderHeaderServerResponseModel> response = await this.SalesOrderHeaderService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSalesOrderHeaderServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiSalesOrderHeaderServerResponseModel response = await this.SalesOrderHeaderService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiSalesOrderHeaderServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSalesOrderHeaderServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiSalesOrderHeaderServerResponseModel> records = new List<ApiSalesOrderHeaderServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiSalesOrderHeaderServerResponseModel> result = await this.SalesOrderHeaderService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiSalesOrderHeaderServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiSalesOrderHeaderServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiSalesOrderHeaderServerRequestModel model)
		{
			CreateResponse<ApiSalesOrderHeaderServerResponseModel> result = await this.SalesOrderHeaderService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/SalesOrderHeaders/{result.Record.SalesOrderID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiSalesOrderHeaderServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSalesOrderHeaderServerRequestModel> patch)
		{
			ApiSalesOrderHeaderServerResponseModel record = await this.SalesOrderHeaderService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiSalesOrderHeaderServerRequestModel model = await this.PatchModel(id, patch) as ApiSalesOrderHeaderServerRequestModel;

				UpdateResponse<ApiSalesOrderHeaderServerResponseModel> result = await this.SalesOrderHeaderService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiSalesOrderHeaderServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSalesOrderHeaderServerRequestModel model)
		{
			ApiSalesOrderHeaderServerRequestModel request = await this.PatchModel(id, this.SalesOrderHeaderModelMapper.CreatePatch(model)) as ApiSalesOrderHeaderServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiSalesOrderHeaderServerResponseModel> result = await this.SalesOrderHeaderService.Update(id, request);

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
			ActionResponse result = await this.SalesOrderHeaderService.Delete(id);

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
		[ProducesResponseType(typeof(ApiSalesOrderHeaderServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByRowguid(Guid rowguid)
		{
			ApiSalesOrderHeaderServerResponseModel response = await this.SalesOrderHeaderService.ByRowguid(rowguid);

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
		[Route("bySalesOrderNumber/{salesOrderNumber}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSalesOrderHeaderServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> BySalesOrderNumber(string salesOrderNumber)
		{
			ApiSalesOrderHeaderServerResponseModel response = await this.SalesOrderHeaderService.BySalesOrderNumber(salesOrderNumber);

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
		[Route("byCustomerID/{customerID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByCustomerID(int customerID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSalesOrderHeaderServerResponseModel> response = await this.SalesOrderHeaderService.ByCustomerID(customerID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("bySalesPersonID/{salesPersonID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderServerResponseModel>), 200)]
		public async virtual Task<IActionResult> BySalesPersonID(int? salesPersonID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSalesOrderHeaderServerResponseModel> response = await this.SalesOrderHeaderService.BySalesPersonID(salesPersonID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiSalesOrderHeaderServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiSalesOrderHeaderServerRequestModel> patch)
		{
			var record = await this.SalesOrderHeaderService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiSalesOrderHeaderServerRequestModel request = this.SalesOrderHeaderModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>c25a53e2cfa32cae24fd49249198337a</Hash>
</Codenesium>*/