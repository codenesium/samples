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
	public abstract class AbstractTransactionHistoryController : AbstractApiController
	{
		protected ITransactionHistoryService TransactionHistoryService { get; private set; }

		protected IApiTransactionHistoryServerModelMapper TransactionHistoryModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractTransactionHistoryController(
			ApiSettings settings,
			ILogger<AbstractTransactionHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITransactionHistoryService transactionHistoryService,
			IApiTransactionHistoryServerModelMapper transactionHistoryModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.TransactionHistoryService = transactionHistoryService;
			this.TransactionHistoryModelMapper = transactionHistoryModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTransactionHistoryServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiTransactionHistoryServerResponseModel> response = await this.TransactionHistoryService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiTransactionHistoryServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiTransactionHistoryServerResponseModel response = await this.TransactionHistoryService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiTransactionHistoryServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTransactionHistoryServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiTransactionHistoryServerResponseModel> records = new List<ApiTransactionHistoryServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiTransactionHistoryServerResponseModel> result = await this.TransactionHistoryService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiTransactionHistoryServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiTransactionHistoryServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiTransactionHistoryServerRequestModel model)
		{
			CreateResponse<ApiTransactionHistoryServerResponseModel> result = await this.TransactionHistoryService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/TransactionHistories/{result.Record.TransactionID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiTransactionHistoryServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiTransactionHistoryServerRequestModel> patch)
		{
			ApiTransactionHistoryServerResponseModel record = await this.TransactionHistoryService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiTransactionHistoryServerRequestModel model = await this.PatchModel(id, patch) as ApiTransactionHistoryServerRequestModel;

				UpdateResponse<ApiTransactionHistoryServerResponseModel> result = await this.TransactionHistoryService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTransactionHistoryServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTransactionHistoryServerRequestModel model)
		{
			ApiTransactionHistoryServerRequestModel request = await this.PatchModel(id, this.TransactionHistoryModelMapper.CreatePatch(model)) as ApiTransactionHistoryServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiTransactionHistoryServerResponseModel> result = await this.TransactionHistoryService.Update(id, request);

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
			ActionResponse result = await this.TransactionHistoryService.Delete(id);

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
		[Route("byProductID/{productID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTransactionHistoryServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByProductID(int productID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTransactionHistoryServerResponseModel> response = await this.TransactionHistoryService.ByProductID(productID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byReferenceOrderIDReferenceOrderLineID/{referenceOrderID}/{referenceOrderLineID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTransactionHistoryServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTransactionHistoryServerResponseModel> response = await this.TransactionHistoryService.ByReferenceOrderIDReferenceOrderLineID(referenceOrderID, referenceOrderLineID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiTransactionHistoryServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiTransactionHistoryServerRequestModel> patch)
		{
			var record = await this.TransactionHistoryService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiTransactionHistoryServerRequestModel request = this.TransactionHistoryModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>c78e3c37bd8ce7e3d5fb12c5c5368264</Hash>
</Codenesium>*/