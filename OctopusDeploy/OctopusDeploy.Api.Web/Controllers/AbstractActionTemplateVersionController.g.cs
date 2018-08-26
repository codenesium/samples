using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
	public abstract class AbstractActionTemplateVersionController : AbstractApiController
	{
		protected IActionTemplateVersionService ActionTemplateVersionService { get; private set; }

		protected IApiActionTemplateVersionModelMapper ActionTemplateVersionModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractActionTemplateVersionController(
			ApiSettings settings,
			ILogger<AbstractActionTemplateVersionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IActionTemplateVersionService actionTemplateVersionService,
			IApiActionTemplateVersionModelMapper actionTemplateVersionModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.ActionTemplateVersionService = actionTemplateVersionService;
			this.ActionTemplateVersionModelMapper = actionTemplateVersionModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiActionTemplateVersionResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiActionTemplateVersionResponseModel> response = await this.ActionTemplateVersionService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiActionTemplateVersionResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(string id)
		{
			ApiActionTemplateVersionResponseModel response = await this.ActionTemplateVersionService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiActionTemplateVersionResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiActionTemplateVersionRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiActionTemplateVersionResponseModel> records = new List<ApiActionTemplateVersionResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiActionTemplateVersionResponseModel> result = await this.ActionTemplateVersionService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiActionTemplateVersionResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiActionTemplateVersionRequestModel model)
		{
			CreateResponse<ApiActionTemplateVersionResponseModel> result = await this.ActionTemplateVersionService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/ActionTemplateVersions/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiActionTemplateVersionResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiActionTemplateVersionRequestModel> patch)
		{
			ApiActionTemplateVersionResponseModel record = await this.ActionTemplateVersionService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiActionTemplateVersionRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiActionTemplateVersionResponseModel> result = await this.ActionTemplateVersionService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiActionTemplateVersionResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(string id, [FromBody] ApiActionTemplateVersionRequestModel model)
		{
			ApiActionTemplateVersionRequestModel request = await this.PatchModel(id, this.ActionTemplateVersionModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiActionTemplateVersionResponseModel> result = await this.ActionTemplateVersionService.Update(id, request);

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
		public virtual async Task<IActionResult> Delete(string id)
		{
			ActionResponse result = await this.ActionTemplateVersionService.Delete(id);

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
		[Route("byNameVersion/{name}/{version}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiActionTemplateVersionResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByNameVersion(string name, int version)
		{
			ApiActionTemplateVersionResponseModel response = await this.ActionTemplateVersionService.ByNameVersion(name, version);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpGet]
		[Route("byLatestActionTemplateId/{latestActionTemplateId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiActionTemplateVersionResponseModel>), 200)]
		public async virtual Task<IActionResult> ByLatestActionTemplateId(string latestActionTemplateId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiActionTemplateVersionResponseModel> response = await this.ActionTemplateVersionService.ByLatestActionTemplateId(latestActionTemplateId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiActionTemplateVersionRequestModel> PatchModel(string id, JsonPatchDocument<ApiActionTemplateVersionRequestModel> patch)
		{
			var record = await this.ActionTemplateVersionService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiActionTemplateVersionRequestModel request = this.ActionTemplateVersionModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>8ba42f3d85cdab8fbd4d8afd84d602d0</Hash>
</Codenesium>*/