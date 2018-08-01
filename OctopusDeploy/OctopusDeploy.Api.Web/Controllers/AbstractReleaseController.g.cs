using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
	public abstract class AbstractReleaseController : AbstractApiController
	{
		protected IReleaseService ReleaseService { get; private set; }

		protected IApiReleaseModelMapper ReleaseModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractReleaseController(
			ApiSettings settings,
			ILogger<AbstractReleaseController> logger,
			ITransactionCoordinator transactionCoordinator,
			IReleaseService releaseService,
			IApiReleaseModelMapper releaseModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.ReleaseService = releaseService;
			this.ReleaseModelMapper = releaseModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiReleaseResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiReleaseResponseModel> response = await this.ReleaseService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiReleaseResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(string id)
		{
			ApiReleaseResponseModel response = await this.ReleaseService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiReleaseResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiReleaseRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiReleaseResponseModel> records = new List<ApiReleaseResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiReleaseResponseModel> result = await this.ReleaseService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiReleaseResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiReleaseRequestModel model)
		{
			CreateResponse<ApiReleaseResponseModel> result = await this.ReleaseService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Releases/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiReleaseResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiReleaseRequestModel> patch)
		{
			ApiReleaseResponseModel record = await this.ReleaseService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiReleaseRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiReleaseResponseModel> result = await this.ReleaseService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiReleaseResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(string id, [FromBody] ApiReleaseRequestModel model)
		{
			ApiReleaseRequestModel request = await this.PatchModel(id, this.ReleaseModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiReleaseResponseModel> result = await this.ReleaseService.Update(id, request);

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
			ActionResponse result = await this.ReleaseService.Delete(id);

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
		[Route("byVersionProjectId/{version}/{projectId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiReleaseResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByVersionProjectId(string version, string projectId)
		{
			ApiReleaseResponseModel response = await this.ReleaseService.ByVersionProjectId(version, projectId);

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
		[Route("byIdAssembled/{id}/{assembled}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiReleaseResponseModel>), 200)]
		public async virtual Task<IActionResult> ByIdAssembled(string id, DateTimeOffset assembled)
		{
			List<ApiReleaseResponseModel> response = await this.ReleaseService.ByIdAssembled(id, assembled);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byProjectDeploymentProcessSnapshotId/{projectDeploymentProcessSnapshotId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiReleaseResponseModel>), 200)]
		public async virtual Task<IActionResult> ByProjectDeploymentProcessSnapshotId(string projectDeploymentProcessSnapshotId)
		{
			List<ApiReleaseResponseModel> response = await this.ReleaseService.ByProjectDeploymentProcessSnapshotId(projectDeploymentProcessSnapshotId);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled/{id}/{version}/{projectVariableSetSnapshotId}/{projectDeploymentProcessSnapshotId}/{jSON}/{projectId}/{channelId}/{assembled}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiReleaseResponseModel>), 200)]
		public async virtual Task<IActionResult> ByIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(string id, string version, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string channelId, DateTimeOffset assembled)
		{
			List<ApiReleaseResponseModel> response = await this.ReleaseService.ByIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(id, version, projectVariableSetSnapshotId, projectDeploymentProcessSnapshotId, jSON, projectId, channelId, assembled);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled/{id}/{channelId}/{projectVariableSetSnapshotId}/{projectDeploymentProcessSnapshotId}/{jSON}/{projectId}/{version}/{assembled}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiReleaseResponseModel>), 200)]
		public async virtual Task<IActionResult> ByIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(string id, string channelId, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string version, DateTimeOffset assembled)
		{
			List<ApiReleaseResponseModel> response = await this.ReleaseService.ByIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(id, channelId, projectVariableSetSnapshotId, projectDeploymentProcessSnapshotId, jSON, projectId, version, assembled);

			return this.Ok(response);
		}

		private async Task<ApiReleaseRequestModel> PatchModel(string id, JsonPatchDocument<ApiReleaseRequestModel> patch)
		{
			var record = await this.ReleaseService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiReleaseRequestModel request = this.ReleaseModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>1ba566242373540025a5cfa904c84855</Hash>
</Codenesium>*/