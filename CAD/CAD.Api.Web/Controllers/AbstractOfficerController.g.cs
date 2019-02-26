using CADNS.Api.Contracts;
using CADNS.Api.Services;
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

namespace CADNS.Api.Web
{
	public abstract class AbstractOfficerController : AbstractApiController
	{
		protected IOfficerService OfficerService { get; private set; }

		protected IApiOfficerServerModelMapper OfficerModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractOfficerController(
			ApiSettings settings,
			ILogger<AbstractOfficerController> logger,
			ITransactionCoordinator transactionCoordinator,
			IOfficerService officerService,
			IApiOfficerServerModelMapper officerModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.OfficerService = officerService;
			this.OfficerModelMapper = officerModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiOfficerServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiOfficerServerResponseModel> response = await this.OfficerService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiOfficerServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiOfficerServerResponseModel response = await this.OfficerService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiOfficerServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiOfficerServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiOfficerServerResponseModel> records = new List<ApiOfficerServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiOfficerServerResponseModel> result = await this.OfficerService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiOfficerServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiOfficerServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiOfficerServerRequestModel model)
		{
			CreateResponse<ApiOfficerServerResponseModel> result = await this.OfficerService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Officers/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiOfficerServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiOfficerServerRequestModel> patch)
		{
			ApiOfficerServerResponseModel record = await this.OfficerService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiOfficerServerRequestModel model = await this.PatchModel(id, patch) as ApiOfficerServerRequestModel;

				UpdateResponse<ApiOfficerServerResponseModel> result = await this.OfficerService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiOfficerServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiOfficerServerRequestModel model)
		{
			ApiOfficerServerRequestModel request = await this.PatchModel(id, this.OfficerModelMapper.CreatePatch(model)) as ApiOfficerServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiOfficerServerResponseModel> result = await this.OfficerService.Update(id, request);

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
			ActionResponse result = await this.OfficerService.Delete(id);

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
		[Route("{officerId}/Notes")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiNoteServerResponseModel>), 200)]
		public async virtual Task<IActionResult> NotesByOfficerId(int officerId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiNoteServerResponseModel> response = await this.OfficerService.NotesByOfficerId(officerId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{officerId}/OfficerCapabilities")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiOfficerCapabilitiesServerResponseModel>), 200)]
		public async virtual Task<IActionResult> OfficerCapabilitiesByOfficerId(int officerId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiOfficerCapabilitiesServerResponseModel> response = await this.OfficerService.OfficerCapabilitiesByOfficerId(officerId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byCapabilityId/{capabilityId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiOfficerServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByCapabilityId(int capabilityId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiOfficerServerResponseModel> response = await this.OfficerService.ByCapabilityId(capabilityId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiOfficerServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiOfficerServerRequestModel> patch)
		{
			var record = await this.OfficerService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiOfficerServerRequestModel request = this.OfficerModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>b47f7eecd649ec70b83223b1d0f61fd3</Hash>
</Codenesium>*/