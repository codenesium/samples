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
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	public abstract class AbstractSpecialOfferProductController: AbstractApiController
	{
		protected ISpecialOfferProductService specialOfferProductService;

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractSpecialOfferProductController(
			ServiceSettings settings,
			ILogger<AbstractSpecialOfferProductController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpecialOfferProductService specialOfferProductService
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.specialOfferProductService = specialOfferProductService;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSpecialOfferProductResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiSpecialOfferProductResponseModel> response = await this.specialOfferProductService.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSpecialOfferProductResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiSpecialOfferProductResponseModel response = await this.specialOfferProductService.Get(id);

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
		[ProducesResponseType(typeof(ApiSpecialOfferProductResponseModel), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiSpecialOfferProductRequestModel model)
		{
			CreateResponse<ApiSpecialOfferProductResponseModel> result = await this.specialOfferProductService.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.SpecialOfferID.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/SpecialOfferProducts/{result.Record.SpecialOfferID.ToString()}");
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
		[ProducesResponseType(typeof(List<ApiSpecialOfferProductResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSpecialOfferProductRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiSpecialOfferProductResponseModel> records = new List<ApiSpecialOfferProductResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiSpecialOfferProductResponseModel> result = await this.specialOfferProductService.Create(model);

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
		[ProducesResponseType(typeof(ApiSpecialOfferProductResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSpecialOfferProductRequestModel model)
		{
			ActionResponse result = await this.specialOfferProductService.Update(id, model);

			if (result.Success)
			{
				ApiSpecialOfferProductResponseModel response = await this.specialOfferProductService.Get(id);

				return this.Ok(response);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.specialOfferProductService.Delete(id);

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
		[Route("getProductID/{productID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSpecialOfferProductResponseModel>), 200)]
		public async virtual Task<IActionResult> GetProductID(int productID)
		{
			List<ApiSpecialOfferProductResponseModel> response = await this.specialOfferProductService.GetProductID(productID);

			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>1fa85ab1cdae7597c3acc0eea5efea31</Hash>
</Codenesium>*/