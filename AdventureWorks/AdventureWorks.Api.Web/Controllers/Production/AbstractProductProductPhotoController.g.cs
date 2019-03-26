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
	public abstract class AbstractProductProductPhotoController : AbstractApiController
	{
		protected IProductProductPhotoService ProductProductPhotoService { get; private set; }

		protected IApiProductProductPhotoServerModelMapper ProductProductPhotoModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractProductProductPhotoController(
			ApiSettings settings,
			ILogger<AbstractProductProductPhotoController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductProductPhotoService productProductPhotoService,
			IApiProductProductPhotoServerModelMapper productProductPhotoModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.ProductProductPhotoService = productProductPhotoService;
			this.ProductProductPhotoModelMapper = productProductPhotoModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProductProductPhotoServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiProductProductPhotoServerResponseModel> response = await this.ProductProductPhotoService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiProductProductPhotoServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiProductProductPhotoServerResponseModel response = await this.ProductProductPhotoService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiProductProductPhotoServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiProductProductPhotoServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiProductProductPhotoServerResponseModel> records = new List<ApiProductProductPhotoServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiProductProductPhotoServerResponseModel> result = await this.ProductProductPhotoService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiProductProductPhotoServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiProductProductPhotoServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiProductProductPhotoServerRequestModel model)
		{
			CreateResponse<ApiProductProductPhotoServerResponseModel> result = await this.ProductProductPhotoService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/ProductProductPhotoes/{result.Record.ProductID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiProductProductPhotoServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiProductProductPhotoServerRequestModel> patch)
		{
			ApiProductProductPhotoServerResponseModel record = await this.ProductProductPhotoService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiProductProductPhotoServerRequestModel model = await this.PatchModel(id, patch) as ApiProductProductPhotoServerRequestModel;

				UpdateResponse<ApiProductProductPhotoServerResponseModel> result = await this.ProductProductPhotoService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiProductProductPhotoServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiProductProductPhotoServerRequestModel model)
		{
			ApiProductProductPhotoServerRequestModel request = await this.PatchModel(id, this.ProductProductPhotoModelMapper.CreatePatch(model)) as ApiProductProductPhotoServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiProductProductPhotoServerResponseModel> result = await this.ProductProductPhotoService.Update(id, request);

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
			ActionResponse result = await this.ProductProductPhotoService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiProductProductPhotoServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiProductProductPhotoServerRequestModel> patch)
		{
			var record = await this.ProductProductPhotoService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiProductProductPhotoServerRequestModel request = this.ProductProductPhotoModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>ad5d8bea48d733d59123546662c62e8f</Hash>
</Codenesium>*/