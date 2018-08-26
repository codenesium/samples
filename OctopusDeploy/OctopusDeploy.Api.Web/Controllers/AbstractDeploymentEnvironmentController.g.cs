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
	public abstract class AbstractDeploymentEnvironmentController : AbstractApiController
	{
		protected IDeploymentEnvironmentService DeploymentEnvironmentService { get; private set; }

		protected IApiDeploymentEnvironmentModelMapper DeploymentEnvironmentModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractDeploymentEnvironmentController(
			ApiSettings settings,
			ILogger<AbstractDeploymentEnvironmentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeploymentEnvironmentService deploymentEnvironmentService,
			IApiDeploymentEnvironmentModelMapper deploymentEnvironmentModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.DeploymentEnvironmentService = deploymentEnvironmentService;
			this.DeploymentEnvironmentModelMapper = deploymentEnvironmentModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDeploymentEnvironmentResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiDeploymentEnvironmentResponseModel> response = await this.DeploymentEnvironmentService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiDeploymentEnvironmentResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(string id)
		{
			ApiDeploymentEnvironmentResponseModel response = await this.DeploymentEnvironmentService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiDeploymentEnvironmentResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiDeploymentEnvironmentRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiDeploymentEnvironmentResponseModel> records = new List<ApiDeploymentEnvironmentResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiDeploymentEnvironmentResponseModel> result = await this.DeploymentEnvironmentService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiDeploymentEnvironmentResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiDeploymentEnvironmentRequestModel model)
		{
			CreateResponse<ApiDeploymentEnvironmentResponseModel> result = await this.DeploymentEnvironmentService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/DeploymentEnvironments/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiDeploymentEnvironmentResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiDeploymentEnvironmentRequestModel> patch)
		{
			ApiDeploymentEnvironmentResponseModel record = await this.DeploymentEnvironmentService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiDeploymentEnvironmentRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiDeploymentEnvironmentResponseModel> result = await this.DeploymentEnvironmentService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiDeploymentEnvironmentResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(string id, [FromBody] ApiDeploymentEnvironmentRequestModel model)
		{
			ApiDeploymentEnvironmentRequestModel request = await this.PatchModel(id, this.DeploymentEnvironmentModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiDeploymentEnvironmentResponseModel> result = await this.DeploymentEnvironmentService.Update(id, request);

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
			ActionResponse result = await this.DeploymentEnvironmentService.Delete(id);

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
		[Route("byName/{name}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiDeploymentEnvironmentResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByName(string name)
		{
			ApiDeploymentEnvironmentResponseModel response = await this.DeploymentEnvironmentService.ByName(name);

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
		[Route("byDataVersion/{dataVersion}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDeploymentEnvironmentResponseModel>), 200)]
		public async virtual Task<IActionResult> ByDataVersion(byte[] dataVersion, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiDeploymentEnvironmentResponseModel> response = await this.DeploymentEnvironmentService.ByDataVersion(dataVersion, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiDeploymentEnvironmentRequestModel> PatchModel(string id, JsonPatchDocument<ApiDeploymentEnvironmentRequestModel> patch)
		{
			var record = await this.DeploymentEnvironmentService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiDeploymentEnvironmentRequestModel request = this.DeploymentEnvironmentModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>a5a9c28681059b0af68e3241629cf36f</Hash>
</Codenesium>*/