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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
	[Route("api/ticketStatus")]
	[ApiController]
	[ApiVersion("1.0")]

	public class TicketStatusController : AbstractApiController
	{
		protected ITicketStatusService TicketStatusService { get; private set; }

		protected IApiTicketStatusServerModelMapper TicketStatusModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public TicketStatusController(
			ApiSettings settings,
			ILogger<TicketStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITicketStatusService ticketStatusService,
			IApiTicketStatusServerModelMapper ticketStatusModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.TicketStatusService = ticketStatusService;
			this.TicketStatusModelMapper = ticketStatusModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTicketStatusServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiTicketStatusServerResponseModel> response = await this.TicketStatusService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiTicketStatusServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiTicketStatusServerResponseModel response = await this.TicketStatusService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiTicketStatusServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTicketStatusServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiTicketStatusServerResponseModel> records = new List<ApiTicketStatusServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiTicketStatusServerResponseModel> result = await this.TicketStatusService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiTicketStatusServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiTicketStatusServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiTicketStatusServerRequestModel model)
		{
			CreateResponse<ApiTicketStatusServerResponseModel> result = await this.TicketStatusService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/TicketStatus/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiTicketStatusServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiTicketStatusServerRequestModel> patch)
		{
			ApiTicketStatusServerResponseModel record = await this.TicketStatusService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiTicketStatusServerRequestModel model = await this.PatchModel(id, patch) as ApiTicketStatusServerRequestModel;

				UpdateResponse<ApiTicketStatusServerResponseModel> result = await this.TicketStatusService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTicketStatusServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTicketStatusServerRequestModel model)
		{
			ApiTicketStatusServerRequestModel request = await this.PatchModel(id, this.TicketStatusModelMapper.CreatePatch(model)) as ApiTicketStatusServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiTicketStatusServerResponseModel> result = await this.TicketStatusService.Update(id, request);

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
			ActionResponse result = await this.TicketStatusService.Delete(id);

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
		[Route("{ticketStatusId}/Tickets")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTicketServerResponseModel>), 200)]
		public async virtual Task<IActionResult> TicketsByTicketStatusId(int ticketStatusId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTicketServerResponseModel> response = await this.TicketStatusService.TicketsByTicketStatusId(ticketStatusId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiTicketStatusServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiTicketStatusServerRequestModel> patch)
		{
			var record = await this.TicketStatusService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiTicketStatusServerRequestModel request = this.TicketStatusModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>6907ae62d17ea17474cb80c200706b4e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/