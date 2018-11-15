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
	public abstract class AbstractTransactionHistoryArchiveController : AbstractApiController
	{
		protected ITransactionHistoryArchiveService TransactionHistoryArchiveService { get; private set; }

		protected IApiTransactionHistoryArchiveServerModelMapper TransactionHistoryArchiveModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractTransactionHistoryArchiveController(
			ApiSettings settings,
			ILogger<AbstractTransactionHistoryArchiveController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITransactionHistoryArchiveService transactionHistoryArchiveService,
			IApiTransactionHistoryArchiveServerModelMapper transactionHistoryArchiveModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.TransactionHistoryArchiveService = transactionHistoryArchiveService;
			this.TransactionHistoryArchiveModelMapper = transactionHistoryArchiveModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTransactionHistoryArchiveServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTransactionHistoryArchiveServerResponseModel> response = await this.TransactionHistoryArchiveService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiTransactionHistoryArchiveServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiTransactionHistoryArchiveServerResponseModel response = await this.TransactionHistoryArchiveService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiTransactionHistoryArchiveServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTransactionHistoryArchiveServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiTransactionHistoryArchiveServerResponseModel> records = new List<ApiTransactionHistoryArchiveServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiTransactionHistoryArchiveServerResponseModel> result = await this.TransactionHistoryArchiveService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiTransactionHistoryArchiveServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiTransactionHistoryArchiveServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiTransactionHistoryArchiveServerRequestModel model)
		{
			CreateResponse<ApiTransactionHistoryArchiveServerResponseModel> result = await this.TransactionHistoryArchiveService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/TransactionHistoryArchives/{result.Record.TransactionID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiTransactionHistoryArchiveServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiTransactionHistoryArchiveServerRequestModel> patch)
		{
			ApiTransactionHistoryArchiveServerResponseModel record = await this.TransactionHistoryArchiveService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiTransactionHistoryArchiveServerRequestModel model = await this.PatchModel(id, patch) as ApiTransactionHistoryArchiveServerRequestModel;

				UpdateResponse<ApiTransactionHistoryArchiveServerResponseModel> result = await this.TransactionHistoryArchiveService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTransactionHistoryArchiveServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTransactionHistoryArchiveServerRequestModel model)
		{
			ApiTransactionHistoryArchiveServerRequestModel request = await this.PatchModel(id, this.TransactionHistoryArchiveModelMapper.CreatePatch(model)) as ApiTransactionHistoryArchiveServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiTransactionHistoryArchiveServerResponseModel> result = await this.TransactionHistoryArchiveService.Update(id, request);

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
			ActionResponse result = await this.TransactionHistoryArchiveService.Delete(id);

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
		[ProducesResponseType(typeof(List<ApiTransactionHistoryArchiveServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByProductID(int productID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTransactionHistoryArchiveServerResponseModel> response = await this.TransactionHistoryArchiveService.ByProductID(productID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byReferenceOrderIDReferenceOrderLineID/{referenceOrderID}/{referenceOrderLineID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTransactionHistoryArchiveServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTransactionHistoryArchiveServerResponseModel> response = await this.TransactionHistoryArchiveService.ByReferenceOrderIDReferenceOrderLineID(referenceOrderID, referenceOrderLineID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiTransactionHistoryArchiveServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiTransactionHistoryArchiveServerRequestModel> patch)
		{
			var record = await this.TransactionHistoryArchiveService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiTransactionHistoryArchiveServerRequestModel request = this.TransactionHistoryArchiveModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>eeffa115689e421d456797d4356b3457</Hash>
</Codenesium>*/