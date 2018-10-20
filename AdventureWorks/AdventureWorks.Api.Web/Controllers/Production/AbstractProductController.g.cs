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
	public abstract class AbstractProductController : AbstractApiController
	{
		protected IProductService ProductService { get; private set; }

		protected IApiProductModelMapper ProductModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractProductController(
			ApiSettings settings,
			ILogger<AbstractProductController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductService productService,
			IApiProductModelMapper productModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.ProductService = productService;
			this.ProductModelMapper = productModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiProductResponseModel> response = await this.ProductService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiProductResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiProductResponseModel response = await this.ProductService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiProductResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiProductRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiProductResponseModel> records = new List<ApiProductResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiProductResponseModel> result = await this.ProductService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiProductResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiProductRequestModel model)
		{
			CreateResponse<ApiProductResponseModel> result = await this.ProductService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Products/{result.Record.ProductID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiProductResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiProductRequestModel> patch)
		{
			ApiProductResponseModel record = await this.ProductService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiProductRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiProductResponseModel> result = await this.ProductService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiProductResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiProductRequestModel model)
		{
			ApiProductRequestModel request = await this.PatchModel(id, this.ProductModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiProductResponseModel> result = await this.ProductService.Update(id, request);

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
			ActionResponse result = await this.ProductService.Delete(id);

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
		[ProducesResponseType(typeof(ApiProductResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByName(string name)
		{
			ApiProductResponseModel response = await this.ProductService.ByName(name);

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
		[Route("byProductNumber/{productNumber}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiProductResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByProductNumber(string productNumber)
		{
			ApiProductResponseModel response = await this.ProductService.ByProductNumber(productNumber);

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
		[Route("{productAssemblyID}/BillOfMaterialsByProductAssemblyID")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiBillOfMaterialResponseModel>), 200)]
		public async virtual Task<IActionResult> BillOfMaterialsByProductAssemblyID(int productAssemblyID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiBillOfMaterialResponseModel> response = await this.ProductService.BillOfMaterialsByProductAssemblyID(productAssemblyID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{componentID}/BillOfMaterialsByComponentID")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiBillOfMaterialResponseModel>), 200)]
		public async virtual Task<IActionResult> BillOfMaterialsByComponentID(int componentID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiBillOfMaterialResponseModel> response = await this.ProductService.BillOfMaterialsByComponentID(componentID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{productID}/ProductCostHistoriesByProductID")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductCostHistoryResponseModel>), 200)]
		public async virtual Task<IActionResult> ProductCostHistoriesByProductID(int productID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiProductCostHistoryResponseModel> response = await this.ProductService.ProductCostHistoriesByProductID(productID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{productID}/ProductInventoriesByProductID")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductInventoryResponseModel>), 200)]
		public async virtual Task<IActionResult> ProductInventoriesByProductID(int productID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiProductInventoryResponseModel> response = await this.ProductService.ProductInventoriesByProductID(productID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{productID}/ProductListPriceHistoriesByProductID")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductListPriceHistoryResponseModel>), 200)]
		public async virtual Task<IActionResult> ProductListPriceHistoriesByProductID(int productID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiProductListPriceHistoryResponseModel> response = await this.ProductService.ProductListPriceHistoriesByProductID(productID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{productID}/ProductProductPhotoesByProductID")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductProductPhotoResponseModel>), 200)]
		public async virtual Task<IActionResult> ProductProductPhotoesByProductID(int productID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiProductProductPhotoResponseModel> response = await this.ProductService.ProductProductPhotoesByProductID(productID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{productID}/ProductReviewsByProductID")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductReviewResponseModel>), 200)]
		public async virtual Task<IActionResult> ProductReviewsByProductID(int productID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiProductReviewResponseModel> response = await this.ProductService.ProductReviewsByProductID(productID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{productID}/TransactionHistoriesByProductID")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTransactionHistoryResponseModel>), 200)]
		public async virtual Task<IActionResult> TransactionHistoriesByProductID(int productID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTransactionHistoryResponseModel> response = await this.ProductService.TransactionHistoriesByProductID(productID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{productID}/WorkOrdersByProductID")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiWorkOrderResponseModel>), 200)]
		public async virtual Task<IActionResult> WorkOrdersByProductID(int productID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiWorkOrderResponseModel> response = await this.ProductService.WorkOrdersByProductID(productID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byDocumentNode/{documentNode}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductResponseModel>), 200)]
		public async virtual Task<IActionResult> ByDocumentNode(int documentNode, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiProductResponseModel> response = await this.ProductService.ByDocumentNode(documentNode, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiProductRequestModel> PatchModel(int id, JsonPatchDocument<ApiProductRequestModel> patch)
		{
			var record = await this.ProductService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiProductRequestModel request = this.ProductModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>f71f4139000d21038f56047e389a82b2</Hash>
</Codenesium>*/