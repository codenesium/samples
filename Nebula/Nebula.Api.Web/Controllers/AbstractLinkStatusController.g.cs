using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NebulaNS.Api.Web
{
	public abstract class AbstractLinkStatusController : AbstractApiController
	{
		protected ILinkStatusService LinkStatusService { get; private set; }

		protected IApiLinkStatusModelMapper LinkStatusModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractLinkStatusController(
			ApiSettings settings,
			ILogger<AbstractLinkStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkStatusService linkStatusService,
			IApiLinkStatusModelMapper linkStatusModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.LinkStatusService = linkStatusService;
			this.LinkStatusModelMapper = linkStatusModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiLinkStatusResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiLinkStatusResponseModel> response = await this.LinkStatusService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiLinkStatusResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiLinkStatusResponseModel response = await this.LinkStatusService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiLinkStatusResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiLinkStatusRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiLinkStatusResponseModel> records = new List<ApiLinkStatusResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiLinkStatusResponseModel> result = await this.LinkStatusService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiLinkStatusResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiLinkStatusRequestModel model)
		{
			CreateResponse<ApiLinkStatusResponseModel> result = await this.LinkStatusService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/LinkStatus/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiLinkStatusResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiLinkStatusRequestModel> patch)
		{
			ApiLinkStatusResponseModel record = await this.LinkStatusService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiLinkStatusRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiLinkStatusResponseModel> result = await this.LinkStatusService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiLinkStatusResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiLinkStatusRequestModel model)
		{
			ApiLinkStatusRequestModel request = await this.PatchModel(id, this.LinkStatusModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiLinkStatusResponseModel> result = await this.LinkStatusService.Update(id, request);

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
			ActionResponse result = await this.LinkStatusService.Delete(id);

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
		[Route("{linkStatusId}/Links")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiLinkResponseModel>), 200)]
		public async virtual Task<IActionResult> Links(int linkStatusId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiLinkResponseModel> response = await this.LinkStatusService.Links(linkStatusId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiLinkStatusRequestModel> PatchModel(int id, JsonPatchDocument<ApiLinkStatusRequestModel> patch)
		{
			var record = await this.LinkStatusService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiLinkStatusRequestModel request = this.LinkStatusModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>1c3b02dba36c80a27f54cd8d25f234be</Hash>
</Codenesium>*/