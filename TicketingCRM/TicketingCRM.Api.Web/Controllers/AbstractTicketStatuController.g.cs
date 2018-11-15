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
	public abstract class AbstractTicketStatuController : AbstractApiController
	{
		protected ITicketStatuService TicketStatuService { get; private set; }

		protected IApiTicketStatuServerModelMapper TicketStatuModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractTicketStatuController(
			ApiSettings settings,
			ILogger<AbstractTicketStatuController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITicketStatuService ticketStatuService,
			IApiTicketStatuServerModelMapper ticketStatuModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.TicketStatuService = ticketStatuService;
			this.TicketStatuModelMapper = ticketStatuModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTicketStatuServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTicketStatuServerResponseModel> response = await this.TicketStatuService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiTicketStatuServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiTicketStatuServerResponseModel response = await this.TicketStatuService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiTicketStatuServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTicketStatuServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiTicketStatuServerResponseModel> records = new List<ApiTicketStatuServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiTicketStatuServerResponseModel> result = await this.TicketStatuService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiTicketStatuServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiTicketStatuServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiTicketStatuServerRequestModel model)
		{
			CreateResponse<ApiTicketStatuServerResponseModel> result = await this.TicketStatuService.Create(model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTicketStatuServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiTicketStatuServerRequestModel> patch)
		{
			ApiTicketStatuServerResponseModel record = await this.TicketStatuService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiTicketStatuServerRequestModel model = await this.PatchModel(id, patch) as ApiTicketStatuServerRequestModel;

				UpdateResponse<ApiTicketStatuServerResponseModel> result = await this.TicketStatuService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTicketStatuServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTicketStatuServerRequestModel model)
		{
			ApiTicketStatuServerRequestModel request = await this.PatchModel(id, this.TicketStatuModelMapper.CreatePatch(model)) as ApiTicketStatuServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiTicketStatuServerResponseModel> result = await this.TicketStatuService.Update(id, request);

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
			ActionResponse result = await this.TicketStatuService.Delete(id);

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
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTicketServerResponseModel> response = await this.TicketStatuService.TicketsByTicketStatusId(ticketStatusId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiTicketStatuServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiTicketStatuServerRequestModel> patch)
		{
			var record = await this.TicketStatuService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiTicketStatuServerRequestModel request = this.TicketStatuModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>f0ef041c2ca75045b026fe80f30b1b19</Hash>
</Codenesium>*/