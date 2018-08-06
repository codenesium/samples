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
	public abstract class AbstractProductModelController : AbstractApiController
	{
		protected IProductModelService ProductModelService { get; private set; }

		protected IApiProductModelModelMapper ProductModelModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractProductModelController(
			ApiSettings settings,
			ILogger<AbstractProductModelController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelService productModelService,
			IApiProductModelModelMapper productModelModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.ProductModelService = productModelService;
			this.ProductModelModelMapper = productModelModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductModelResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiProductModelResponseModel> response = await this.ProductModelService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiProductModelResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiProductModelResponseModel response = await this.ProductModelService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiProductModelResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiProductModelRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiProductModelResponseModel> records = new List<ApiProductModelResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiProductModelResponseModel> result = await this.ProductModelService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiProductModelResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiProductModelRequestModel model)
		{
			CreateResponse<ApiProductModelResponseModel> result = await this.ProductModelService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/ProductModels/{result.Record.ProductModelID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiProductModelResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiProductModelRequestModel> patch)
		{
			ApiProductModelResponseModel record = await this.ProductModelService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiProductModelRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiProductModelResponseModel> result = await this.ProductModelService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiProductModelResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiProductModelRequestModel model)
		{
			ApiProductModelRequestModel request = await this.PatchModel(id, this.ProductModelModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiProductModelResponseModel> result = await this.ProductModelService.Update(id, request);

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
			ActionResponse result = await this.ProductModelService.Delete(id);

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
		[Route("byName/{name}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiProductModelResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByName(string name)
		{
			ApiProductModelResponseModel response = await this.ProductModelService.ByName(name);

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
		[Route("byCatalogDescription/{catalogDescription}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductModelResponseModel>), 200)]
		public async virtual Task<IActionResult> ByCatalogDescription(string catalogDescription)
		{
			List<ApiProductModelResponseModel> response = await this.ProductModelService.ByCatalogDescription(catalogDescription);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byInstructions/{instruction}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductModelResponseModel>), 200)]
		public async virtual Task<IActionResult> ByInstruction(string instruction)
		{
			List<ApiProductModelResponseModel> response = await this.ProductModelService.ByInstruction(instruction);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{productModelID}/Products")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductResponseModel>), 200)]
		public async virtual Task<IActionResult> Products(int productModelID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiProductResponseModel> response = await this.ProductModelService.Products(productModelID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{productModelID}/ProductModelIllustrations")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductModelIllustrationResponseModel>), 200)]
		public async virtual Task<IActionResult> ProductModelIllustrations(int productModelID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiProductModelIllustrationResponseModel> response = await this.ProductModelService.ProductModelIllustrations(productModelID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{productModelID}/ProductModelProductDescriptionCultures")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductModelProductDescriptionCultureResponseModel>), 200)]
		public async virtual Task<IActionResult> ProductModelProductDescriptionCultures(int productModelID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiProductModelProductDescriptionCultureResponseModel> response = await this.ProductModelService.ProductModelProductDescriptionCultures(productModelID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiProductModelRequestModel> PatchModel(int id, JsonPatchDocument<ApiProductModelRequestModel> patch)
		{
			var record = await this.ProductModelService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiProductModelRequestModel request = this.ProductModelModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>84c4c704467a994d981ac0e9ddc30a00</Hash>
</Codenesium>*/