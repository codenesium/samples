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
	public abstract class AbstractProductDescriptionController : AbstractApiController
	{
		protected IProductDescriptionService ProductDescriptionService { get; private set; }

		protected IApiProductDescriptionServerModelMapper ProductDescriptionModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractProductDescriptionController(
			ApiSettings settings,
			ILogger<AbstractProductDescriptionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductDescriptionService productDescriptionService,
			IApiProductDescriptionServerModelMapper productDescriptionModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.ProductDescriptionService = productDescriptionService;
			this.ProductDescriptionModelMapper = productDescriptionModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductDescriptionServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiProductDescriptionServerResponseModel> response = await this.ProductDescriptionService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiProductDescriptionServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiProductDescriptionServerResponseModel response = await this.ProductDescriptionService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiProductDescriptionServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiProductDescriptionServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiProductDescriptionServerResponseModel> records = new List<ApiProductDescriptionServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiProductDescriptionServerResponseModel> result = await this.ProductDescriptionService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiProductDescriptionServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiProductDescriptionServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiProductDescriptionServerRequestModel model)
		{
			CreateResponse<ApiProductDescriptionServerResponseModel> result = await this.ProductDescriptionService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/ProductDescriptions/{result.Record.ProductDescriptionID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiProductDescriptionServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiProductDescriptionServerRequestModel> patch)
		{
			ApiProductDescriptionServerResponseModel record = await this.ProductDescriptionService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiProductDescriptionServerRequestModel model = await this.PatchModel(id, patch) as ApiProductDescriptionServerRequestModel;

				UpdateResponse<ApiProductDescriptionServerResponseModel> result = await this.ProductDescriptionService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiProductDescriptionServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiProductDescriptionServerRequestModel model)
		{
			ApiProductDescriptionServerRequestModel request = await this.PatchModel(id, this.ProductDescriptionModelMapper.CreatePatch(model)) as ApiProductDescriptionServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiProductDescriptionServerResponseModel> result = await this.ProductDescriptionService.Update(id, request);

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
			ActionResponse result = await this.ProductDescriptionService.Delete(id);

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
		[ProducesResponseType(typeof(ApiProductDescriptionServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByRowguid(Guid rowguid)
		{
			ApiProductDescriptionServerResponseModel response = await this.ProductDescriptionService.ByRowguid(rowguid);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		private async Task<ApiProductDescriptionServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiProductDescriptionServerRequestModel> patch)
		{
			var record = await this.ProductDescriptionService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiProductDescriptionServerRequestModel request = this.ProductDescriptionModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>1748797ea6667c6f1f5f9b2a8952577f</Hash>
</Codenesium>*/