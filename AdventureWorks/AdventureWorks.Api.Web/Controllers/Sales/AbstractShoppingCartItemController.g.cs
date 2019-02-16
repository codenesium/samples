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
	public abstract class AbstractShoppingCartItemController : AbstractApiController
	{
		protected IShoppingCartItemService ShoppingCartItemService { get; private set; }

		protected IApiShoppingCartItemServerModelMapper ShoppingCartItemModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractShoppingCartItemController(
			ApiSettings settings,
			ILogger<AbstractShoppingCartItemController> logger,
			ITransactionCoordinator transactionCoordinator,
			IShoppingCartItemService shoppingCartItemService,
			IApiShoppingCartItemServerModelMapper shoppingCartItemModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.ShoppingCartItemService = shoppingCartItemService;
			this.ShoppingCartItemModelMapper = shoppingCartItemModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiShoppingCartItemServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiShoppingCartItemServerResponseModel> response = await this.ShoppingCartItemService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiShoppingCartItemServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiShoppingCartItemServerResponseModel response = await this.ShoppingCartItemService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiShoppingCartItemServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiShoppingCartItemServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiShoppingCartItemServerResponseModel> records = new List<ApiShoppingCartItemServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiShoppingCartItemServerResponseModel> result = await this.ShoppingCartItemService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiShoppingCartItemServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiShoppingCartItemServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiShoppingCartItemServerRequestModel model)
		{
			CreateResponse<ApiShoppingCartItemServerResponseModel> result = await this.ShoppingCartItemService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/ShoppingCartItems/{result.Record.ShoppingCartItemID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiShoppingCartItemServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiShoppingCartItemServerRequestModel> patch)
		{
			ApiShoppingCartItemServerResponseModel record = await this.ShoppingCartItemService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiShoppingCartItemServerRequestModel model = await this.PatchModel(id, patch) as ApiShoppingCartItemServerRequestModel;

				UpdateResponse<ApiShoppingCartItemServerResponseModel> result = await this.ShoppingCartItemService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiShoppingCartItemServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiShoppingCartItemServerRequestModel model)
		{
			ApiShoppingCartItemServerRequestModel request = await this.PatchModel(id, this.ShoppingCartItemModelMapper.CreatePatch(model)) as ApiShoppingCartItemServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiShoppingCartItemServerResponseModel> result = await this.ShoppingCartItemService.Update(id, request);

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
			ActionResponse result = await this.ShoppingCartItemService.Delete(id);

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
		[Route("byShoppingCartIDProductID/{shoppingCartID}/{productID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiShoppingCartItemServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByShoppingCartIDProductID(string shoppingCartID, int productID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiShoppingCartItemServerResponseModel> response = await this.ShoppingCartItemService.ByShoppingCartIDProductID(shoppingCartID, productID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiShoppingCartItemServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiShoppingCartItemServerRequestModel> patch)
		{
			var record = await this.ShoppingCartItemService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiShoppingCartItemServerRequestModel request = this.ShoppingCartItemModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>a2ddb196566a7023836c358f033ad0ba</Hash>
</Codenesium>*/