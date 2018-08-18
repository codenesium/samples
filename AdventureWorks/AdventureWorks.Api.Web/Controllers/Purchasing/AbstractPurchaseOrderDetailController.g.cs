using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
	public abstract class AbstractPurchaseOrderDetailController : AbstractApiController
	{
		protected IPurchaseOrderDetailService PurchaseOrderDetailService { get; private set; }

		protected IApiPurchaseOrderDetailModelMapper PurchaseOrderDetailModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractPurchaseOrderDetailController(
			ApiSettings settings,
			ILogger<AbstractPurchaseOrderDetailController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPurchaseOrderDetailService purchaseOrderDetailService,
			IApiPurchaseOrderDetailModelMapper purchaseOrderDetailModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.PurchaseOrderDetailService = purchaseOrderDetailService;
			this.PurchaseOrderDetailModelMapper = purchaseOrderDetailModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPurchaseOrderDetailResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPurchaseOrderDetailResponseModel> response = await this.PurchaseOrderDetailService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPurchaseOrderDetailResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPurchaseOrderDetailResponseModel response = await this.PurchaseOrderDetailService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiPurchaseOrderDetailResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPurchaseOrderDetailRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiPurchaseOrderDetailResponseModel> records = new List<ApiPurchaseOrderDetailResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiPurchaseOrderDetailResponseModel> result = await this.PurchaseOrderDetailService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiPurchaseOrderDetailResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiPurchaseOrderDetailRequestModel model)
		{
			CreateResponse<ApiPurchaseOrderDetailResponseModel> result = await this.PurchaseOrderDetailService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/PurchaseOrderDetails/{result.Record.PurchaseOrderID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiPurchaseOrderDetailResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPurchaseOrderDetailRequestModel> patch)
		{
			ApiPurchaseOrderDetailResponseModel record = await this.PurchaseOrderDetailService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiPurchaseOrderDetailRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiPurchaseOrderDetailResponseModel> result = await this.PurchaseOrderDetailService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPurchaseOrderDetailResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPurchaseOrderDetailRequestModel model)
		{
			ApiPurchaseOrderDetailRequestModel request = await this.PatchModel(id, this.PurchaseOrderDetailModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiPurchaseOrderDetailResponseModel> result = await this.PurchaseOrderDetailService.Update(id, request);

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
			ActionResponse result = await this.PurchaseOrderDetailService.Delete(id);

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
		[Route("byProductID/{productID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPurchaseOrderDetailResponseModel>), 200)]
		public async virtual Task<IActionResult> ByProductID(int productID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPurchaseOrderDetailResponseModel> response = await this.PurchaseOrderDetailService.ByProductID(productID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiPurchaseOrderDetailRequestModel> PatchModel(int id, JsonPatchDocument<ApiPurchaseOrderDetailRequestModel> patch)
		{
			var record = await this.PurchaseOrderDetailService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiPurchaseOrderDetailRequestModel request = this.PurchaseOrderDetailModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>63fb20131b29e584bb9b95ffdb11a665</Hash>
</Codenesium>*/