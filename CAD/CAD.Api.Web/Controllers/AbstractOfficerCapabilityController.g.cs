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
	public abstract class AbstractOfficerCapabilityController : AbstractApiController
	{
		protected IOfficerCapabilityService OfficerCapabilityService { get; private set; }

		protected IApiOfficerCapabilityServerModelMapper OfficerCapabilityModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractOfficerCapabilityController(
			ApiSettings settings,
			ILogger<AbstractOfficerCapabilityController> logger,
			ITransactionCoordinator transactionCoordinator,
			IOfficerCapabilityService officerCapabilityService,
			IApiOfficerCapabilityServerModelMapper officerCapabilityModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.OfficerCapabilityService = officerCapabilityService;
			this.OfficerCapabilityModelMapper = officerCapabilityModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiOfficerCapabilityServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiOfficerCapabilityServerResponseModel> response = await this.OfficerCapabilityService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiOfficerCapabilityServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiOfficerCapabilityServerResponseModel response = await this.OfficerCapabilityService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiOfficerCapabilityServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiOfficerCapabilityServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiOfficerCapabilityServerResponseModel> records = new List<ApiOfficerCapabilityServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiOfficerCapabilityServerResponseModel> result = await this.OfficerCapabilityService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiOfficerCapabilityServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiOfficerCapabilityServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiOfficerCapabilityServerRequestModel model)
		{
			CreateResponse<ApiOfficerCapabilityServerResponseModel> result = await this.OfficerCapabilityService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/OfficerCapabilities/{result.Record.CapabilityId}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiOfficerCapabilityServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiOfficerCapabilityServerRequestModel> patch)
		{
			ApiOfficerCapabilityServerResponseModel record = await this.OfficerCapabilityService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiOfficerCapabilityServerRequestModel model = await this.PatchModel(id, patch) as ApiOfficerCapabilityServerRequestModel;

				UpdateResponse<ApiOfficerCapabilityServerResponseModel> result = await this.OfficerCapabilityService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiOfficerCapabilityServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiOfficerCapabilityServerRequestModel model)
		{
			ApiOfficerCapabilityServerRequestModel request = await this.PatchModel(id, this.OfficerCapabilityModelMapper.CreatePatch(model)) as ApiOfficerCapabilityServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiOfficerCapabilityServerResponseModel> result = await this.OfficerCapabilityService.Update(id, request);

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
			ActionResponse result = await this.OfficerCapabilityService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiOfficerCapabilityServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiOfficerCapabilityServerRequestModel> patch)
		{
			var record = await this.OfficerCapabilityService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiOfficerCapabilityServerRequestModel request = this.OfficerCapabilityModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>f3fb7c3e2203517ef45fa6ec249860a7</Hash>
</Codenesium>*/