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
	public abstract class AbstractOfficerRefCapabilityController : AbstractApiController
	{
		protected IOfficerRefCapabilityService OfficerRefCapabilityService { get; private set; }

		protected IApiOfficerRefCapabilityServerModelMapper OfficerRefCapabilityModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractOfficerRefCapabilityController(
			ApiSettings settings,
			ILogger<AbstractOfficerRefCapabilityController> logger,
			ITransactionCoordinator transactionCoordinator,
			IOfficerRefCapabilityService officerRefCapabilityService,
			IApiOfficerRefCapabilityServerModelMapper officerRefCapabilityModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.OfficerRefCapabilityService = officerRefCapabilityService;
			this.OfficerRefCapabilityModelMapper = officerRefCapabilityModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiOfficerRefCapabilityServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiOfficerRefCapabilityServerResponseModel> response = await this.OfficerRefCapabilityService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiOfficerRefCapabilityServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiOfficerRefCapabilityServerResponseModel response = await this.OfficerRefCapabilityService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiOfficerRefCapabilityServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiOfficerRefCapabilityServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiOfficerRefCapabilityServerResponseModel> records = new List<ApiOfficerRefCapabilityServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiOfficerRefCapabilityServerResponseModel> result = await this.OfficerRefCapabilityService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiOfficerRefCapabilityServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiOfficerRefCapabilityServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiOfficerRefCapabilityServerRequestModel model)
		{
			CreateResponse<ApiOfficerRefCapabilityServerResponseModel> result = await this.OfficerRefCapabilityService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/OfficerRefCapabilities/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiOfficerRefCapabilityServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiOfficerRefCapabilityServerRequestModel> patch)
		{
			ApiOfficerRefCapabilityServerResponseModel record = await this.OfficerRefCapabilityService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiOfficerRefCapabilityServerRequestModel model = await this.PatchModel(id, patch) as ApiOfficerRefCapabilityServerRequestModel;

				UpdateResponse<ApiOfficerRefCapabilityServerResponseModel> result = await this.OfficerRefCapabilityService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiOfficerRefCapabilityServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiOfficerRefCapabilityServerRequestModel model)
		{
			ApiOfficerRefCapabilityServerRequestModel request = await this.PatchModel(id, this.OfficerRefCapabilityModelMapper.CreatePatch(model)) as ApiOfficerRefCapabilityServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiOfficerRefCapabilityServerResponseModel> result = await this.OfficerRefCapabilityService.Update(id, request);

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
			ActionResponse result = await this.OfficerRefCapabilityService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiOfficerRefCapabilityServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiOfficerRefCapabilityServerRequestModel> patch)
		{
			var record = await this.OfficerRefCapabilityService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiOfficerRefCapabilityServerRequestModel request = this.OfficerRefCapabilityModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>def2ceae73aa4b7e2f6831515191eaab</Hash>
</Codenesium>*/