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
	public abstract class AbstractProductModelProductDescriptionCultureController : AbstractApiController
	{
		protected IProductModelProductDescriptionCultureService ProductModelProductDescriptionCultureService { get; private set; }

		protected IApiProductModelProductDescriptionCultureModelMapper ProductModelProductDescriptionCultureModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractProductModelProductDescriptionCultureController(
			ApiSettings settings,
			ILogger<AbstractProductModelProductDescriptionCultureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelProductDescriptionCultureService productModelProductDescriptionCultureService,
			IApiProductModelProductDescriptionCultureModelMapper productModelProductDescriptionCultureModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.ProductModelProductDescriptionCultureService = productModelProductDescriptionCultureService;
			this.ProductModelProductDescriptionCultureModelMapper = productModelProductDescriptionCultureModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductModelProductDescriptionCultureResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiProductModelProductDescriptionCultureResponseModel> response = await this.ProductModelProductDescriptionCultureService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiProductModelProductDescriptionCultureResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiProductModelProductDescriptionCultureResponseModel response = await this.ProductModelProductDescriptionCultureService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiProductModelProductDescriptionCultureResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiProductModelProductDescriptionCultureRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiProductModelProductDescriptionCultureResponseModel> records = new List<ApiProductModelProductDescriptionCultureResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiProductModelProductDescriptionCultureResponseModel> result = await this.ProductModelProductDescriptionCultureService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiProductModelProductDescriptionCultureRequestModel model)
		{
			CreateResponse<ApiProductModelProductDescriptionCultureResponseModel> result = await this.ProductModelProductDescriptionCultureService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/ProductModelProductDescriptionCultures/{result.Record.ProductModelID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiProductModelProductDescriptionCultureResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiProductModelProductDescriptionCultureRequestModel> patch)
		{
			ApiProductModelProductDescriptionCultureResponseModel record = await this.ProductModelProductDescriptionCultureService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiProductModelProductDescriptionCultureRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiProductModelProductDescriptionCultureResponseModel> result = await this.ProductModelProductDescriptionCultureService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiProductModelProductDescriptionCultureResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiProductModelProductDescriptionCultureRequestModel model)
		{
			ApiProductModelProductDescriptionCultureRequestModel request = await this.PatchModel(id, this.ProductModelProductDescriptionCultureModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiProductModelProductDescriptionCultureResponseModel> result = await this.ProductModelProductDescriptionCultureService.Update(id, request);

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
			ActionResponse result = await this.ProductModelProductDescriptionCultureService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiProductModelProductDescriptionCultureRequestModel> PatchModel(int id, JsonPatchDocument<ApiProductModelProductDescriptionCultureRequestModel> patch)
		{
			var record = await this.ProductModelProductDescriptionCultureService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiProductModelProductDescriptionCultureRequestModel request = this.ProductModelProductDescriptionCultureModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>4b16aed7b6ce230562db8c97b9293995</Hash>
</Codenesium>*/