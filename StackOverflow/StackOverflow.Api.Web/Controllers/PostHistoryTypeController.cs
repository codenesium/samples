using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Web
{
	[Route("api/postHistoryTypes")]
	[ApiController]
	[ApiVersion("1.0")]

	public class PostHistoryTypeController : AbstractApiController
	{
		protected IPostHistoryTypeService PostHistoryTypeService { get; private set; }

		protected IApiPostHistoryTypeServerModelMapper PostHistoryTypeModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public PostHistoryTypeController(
			ApiSettings settings,
			ILogger<PostHistoryTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPostHistoryTypeService postHistoryTypeService,
			IApiPostHistoryTypeServerModelMapper postHistoryTypeModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.PostHistoryTypeService = postHistoryTypeService;
			this.PostHistoryTypeModelMapper = postHistoryTypeModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostHistoryTypeServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiPostHistoryTypeServerResponseModel> response = await this.PostHistoryTypeService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPostHistoryTypeServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPostHistoryTypeServerResponseModel response = await this.PostHistoryTypeService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiPostHistoryTypeServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPostHistoryTypeServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiPostHistoryTypeServerResponseModel> records = new List<ApiPostHistoryTypeServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiPostHistoryTypeServerResponseModel> result = await this.PostHistoryTypeService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiPostHistoryTypeServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiPostHistoryTypeServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiPostHistoryTypeServerRequestModel model)
		{
			CreateResponse<ApiPostHistoryTypeServerResponseModel> result = await this.PostHistoryTypeService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/PostHistoryTypes/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiPostHistoryTypeServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPostHistoryTypeServerRequestModel> patch)
		{
			ApiPostHistoryTypeServerResponseModel record = await this.PostHistoryTypeService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiPostHistoryTypeServerRequestModel model = await this.PatchModel(id, patch) as ApiPostHistoryTypeServerRequestModel;

				UpdateResponse<ApiPostHistoryTypeServerResponseModel> result = await this.PostHistoryTypeService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPostHistoryTypeServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPostHistoryTypeServerRequestModel model)
		{
			ApiPostHistoryTypeServerRequestModel request = await this.PatchModel(id, this.PostHistoryTypeModelMapper.CreatePatch(model)) as ApiPostHistoryTypeServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiPostHistoryTypeServerResponseModel> result = await this.PostHistoryTypeService.Update(id, request);

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
			ActionResponse result = await this.PostHistoryTypeService.Delete(id);

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
		[Route("{postHistoryTypeId}/PostHistories")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostHistoryServerResponseModel>), 200)]
		public async virtual Task<IActionResult> PostHistoriesByPostHistoryTypeId(int postHistoryTypeId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostHistoryServerResponseModel> response = await this.PostHistoryTypeService.PostHistoriesByPostHistoryTypeId(postHistoryTypeId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiPostHistoryTypeServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiPostHistoryTypeServerRequestModel> patch)
		{
			var record = await this.PostHistoryTypeService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiPostHistoryTypeServerRequestModel request = this.PostHistoryTypeModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>a17e2a202519425ee06ce279813a5a33</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/