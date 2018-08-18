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
	public abstract class AbstractDeploymentController : AbstractApiController
	{
		protected IDeploymentService DeploymentService { get; private set; }

		protected IApiDeploymentModelMapper DeploymentModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractDeploymentController(
			ApiSettings settings,
			ILogger<AbstractDeploymentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeploymentService deploymentService,
			IApiDeploymentModelMapper deploymentModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.DeploymentService = deploymentService;
			this.DeploymentModelMapper = deploymentModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDeploymentResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiDeploymentResponseModel> response = await this.DeploymentService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiDeploymentResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(string id)
		{
			ApiDeploymentResponseModel response = await this.DeploymentService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiDeploymentResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiDeploymentRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiDeploymentResponseModel> records = new List<ApiDeploymentResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiDeploymentResponseModel> result = await this.DeploymentService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiDeploymentResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiDeploymentRequestModel model)
		{
			CreateResponse<ApiDeploymentResponseModel> result = await this.DeploymentService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Deployments/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiDeploymentResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiDeploymentRequestModel> patch)
		{
			ApiDeploymentResponseModel record = await this.DeploymentService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiDeploymentRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiDeploymentResponseModel> result = await this.DeploymentService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiDeploymentResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(string id, [FromBody] ApiDeploymentRequestModel model)
		{
			ApiDeploymentRequestModel request = await this.PatchModel(id, this.DeploymentModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiDeploymentResponseModel> result = await this.DeploymentService.Update(id, request);

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
			ActionResponse result = await this.DeploymentService.Delete(id);

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
		[Route("byChannelId/{channelId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDeploymentResponseModel>), 200)]
		public async virtual Task<IActionResult> ByChannelId(string channelId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiDeploymentResponseModel> response = await this.DeploymentService.ByChannelId(channelId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId/{id}/{projectId}/{projectGroupId}/{name}/{created}/{releaseId}/{taskId}/{environmentId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDeploymentResponseModel>), 200)]
		public async virtual Task<IActionResult> ByIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(string id, string projectId, string projectGroupId, string name, DateTimeOffset created, string releaseId, string taskId, string environmentId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiDeploymentResponseModel> response = await this.DeploymentService.ByIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(id, projectId, projectGroupId, name, created, releaseId, taskId, environmentId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byTenantId/{tenantId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDeploymentResponseModel>), 200)]
		public async virtual Task<IActionResult> ByTenantId(string tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiDeploymentResponseModel> response = await this.DeploymentService.ByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{deploymentId}/DeploymentRelatedMachines")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDeploymentRelatedMachineResponseModel>), 200)]
		public async virtual Task<IActionResult> DeploymentRelatedMachines(string deploymentId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiDeploymentRelatedMachineResponseModel> response = await this.DeploymentService.DeploymentRelatedMachines(deploymentId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiDeploymentRequestModel> PatchModel(string id, JsonPatchDocument<ApiDeploymentRequestModel> patch)
		{
			var record = await this.DeploymentService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiDeploymentRequestModel request = this.DeploymentModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>e4222eeb035257027ae05293fec86a5c</Hash>
</Codenesium>*/