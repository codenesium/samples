using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractShoppingCartItemController: AbstractApiController
	{
		protected IBOShoppingCartItem shoppingCartItemManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractShoppingCartItemController(
			ServiceSettings settings,
			ILogger<AbstractShoppingCartItemController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOShoppingCartItem shoppingCartItemManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.shoppingCartItemManager = shoppingCartItemManager;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiShoppingCartItemResponseModel>), 200)]
		public async virtual Task<IActionResult> All()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiShoppingCartItemResponseModel> response = await this.shoppingCartItemManager.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiShoppingCartItemResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiShoppingCartItemResponseModel response = await this.shoppingCartItemManager.Get(id);

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
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(ApiShoppingCartItemResponseModel), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiShoppingCartItemRequestModel model)
		{
			CreateResponse<ApiShoppingCartItemResponseModel> result = await this.shoppingCartItemManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.ShoppingCartItemID.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/ShoppingCartItems/{result.Record.ShoppingCartItemID.ToString()}");
				return this.Ok(result.Record);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(List<ApiShoppingCartItemResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiShoppingCartItemRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiShoppingCartItemResponseModel> records = new List<ApiShoppingCartItemResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiShoppingCartItemResponseModel> result = await this.shoppingCartItemManager.Create(model);

				if(result.Success)
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

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(DTOShoppingCartItem), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiShoppingCartItemRequestModel model)
		{
			try
			{
				ActionResponse result = await this.shoppingCartItemManager.Update(id, model);

				if (result.Success)
				{
					ApiShoppingCartItemResponseModel response = await this.shoppingCartItemManager.Get(id);

					return this.Ok(response);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
			catch(RecordNotFoundException)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.shoppingCartItemManager.Delete(id);

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
		[Route("getShoppingCartIDProductID/{shoppingCartID}/{productID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiShoppingCartItemResponseModel>), 200)]
		public async virtual Task<IActionResult> GetShoppingCartIDProductID(string shoppingCartID,int productID)
		{
			List<ApiShoppingCartItemResponseModel> response = await this.shoppingCartItemManager.GetShoppingCartIDProductID(shoppingCartID,productID);

			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>718090587ad7f0c19daa95918cbf74ae</Hash>
</Codenesium>*/