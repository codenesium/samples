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
using TwitterNS.Api.Contracts;
using TwitterNS.Api.Services;

namespace TwitterNS.Api.Web
{
	[Route("api/messages")]
	[ApiController]
	[ApiVersion("1.0")]

	public class MessageController : AbstractApiController
	{
		protected IMessageService MessageService { get; private set; }

		protected IApiMessageServerModelMapper MessageModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public MessageController(
			ApiSettings settings,
			ILogger<MessageController> logger,
			ITransactionCoordinator transactionCoordinator,
			IMessageService messageService,
			IApiMessageServerModelMapper messageModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.MessageService = messageService;
			this.MessageModelMapper = messageModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiMessageServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiMessageServerResponseModel> response = await this.MessageService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiMessageServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiMessageServerResponseModel response = await this.MessageService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiMessageServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiMessageServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiMessageServerResponseModel> records = new List<ApiMessageServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiMessageServerResponseModel> result = await this.MessageService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiMessageServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiMessageServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiMessageServerRequestModel model)
		{
			CreateResponse<ApiMessageServerResponseModel> result = await this.MessageService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Messages/{result.Record.MessageId}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiMessageServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiMessageServerRequestModel> patch)
		{
			ApiMessageServerResponseModel record = await this.MessageService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiMessageServerRequestModel model = await this.PatchModel(id, patch) as ApiMessageServerRequestModel;

				UpdateResponse<ApiMessageServerResponseModel> result = await this.MessageService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiMessageServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiMessageServerRequestModel model)
		{
			ApiMessageServerRequestModel request = await this.PatchModel(id, this.MessageModelMapper.CreatePatch(model)) as ApiMessageServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiMessageServerResponseModel> result = await this.MessageService.Update(id, request);

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
			ActionResponse result = await this.MessageService.Delete(id);

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
		[Route("bySenderUserId/{senderUserId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiMessageServerResponseModel>), 200)]
		public async virtual Task<IActionResult> BySenderUserId(int? senderUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiMessageServerResponseModel> response = await this.MessageService.BySenderUserId(senderUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{messageId}/Messengers")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiMessengerServerResponseModel>), 200)]
		public async virtual Task<IActionResult> MessengersByMessageId(int messageId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiMessengerServerResponseModel> response = await this.MessageService.MessengersByMessageId(messageId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiMessageServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiMessageServerRequestModel> patch)
		{
			var record = await this.MessageService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiMessageServerRequestModel request = this.MessageModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>43ee84d22280b02367ae31b3ef58c1f9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/