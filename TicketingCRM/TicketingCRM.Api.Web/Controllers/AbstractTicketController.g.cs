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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
	public abstract class AbstractTicketController : AbstractApiController
	{
		protected ITicketService TicketService { get; private set; }

		protected IApiTicketModelMapper TicketModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractTicketController(
			ApiSettings settings,
			ILogger<AbstractTicketController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITicketService ticketService,
			IApiTicketModelMapper ticketModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.TicketService = ticketService;
			this.TicketModelMapper = ticketModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTicketResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiTicketResponseModel> response = await this.TicketService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiTicketResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiTicketResponseModel response = await this.TicketService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiTicketResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTicketRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiTicketResponseModel> records = new List<ApiTicketResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiTicketResponseModel> result = await this.TicketService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiTicketResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiTicketRequestModel model)
		{
			CreateResponse<ApiTicketResponseModel> result = await this.TicketService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Tickets/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiTicketResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiTicketRequestModel> patch)
		{
			ApiTicketResponseModel record = await this.TicketService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiTicketRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiTicketResponseModel> result = await this.TicketService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTicketResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTicketRequestModel model)
		{
			ApiTicketRequestModel request = await this.PatchModel(id, this.TicketModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiTicketResponseModel> result = await this.TicketService.Update(id, request);

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
			ActionResponse result = await this.TicketService.Delete(id);

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
		[Route("byTicketStatusId/{ticketStatusId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTicketResponseModel>), 200)]
		public async virtual Task<IActionResult> ByTicketStatusId(int ticketStatusId)
		{
			List<ApiTicketResponseModel> response = await this.TicketService.ByTicketStatusId(ticketStatusId);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{ticketId}/SaleTickets")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSaleTicketsResponseModel>), 200)]
		public async virtual Task<IActionResult> SaleTickets(int ticketId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiSaleTicketsResponseModel> response = await this.TicketService.SaleTickets(ticketId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiTicketRequestModel> PatchModel(int id, JsonPatchDocument<ApiTicketRequestModel> patch)
		{
			var record = await this.TicketService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiTicketRequestModel request = this.TicketModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>9d75be166a0e7b480e1ec90f01dcbbd3</Hash>
</Codenesium>*/