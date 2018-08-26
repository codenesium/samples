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
	public abstract class AbstractDeploymentRelatedMachineController : AbstractApiController
	{
		protected IDeploymentRelatedMachineService DeploymentRelatedMachineService { get; private set; }

		protected IApiDeploymentRelatedMachineModelMapper DeploymentRelatedMachineModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractDeploymentRelatedMachineController(
			ApiSettings settings,
			ILogger<AbstractDeploymentRelatedMachineController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeploymentRelatedMachineService deploymentRelatedMachineService,
			IApiDeploymentRelatedMachineModelMapper deploymentRelatedMachineModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.DeploymentRelatedMachineService = deploymentRelatedMachineService;
			this.DeploymentRelatedMachineModelMapper = deploymentRelatedMachineModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDeploymentRelatedMachineResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiDeploymentRelatedMachineResponseModel> response = await this.DeploymentRelatedMachineService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiDeploymentRelatedMachineResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiDeploymentRelatedMachineResponseModel response = await this.DeploymentRelatedMachineService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiDeploymentRelatedMachineResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiDeploymentRelatedMachineRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiDeploymentRelatedMachineResponseModel> records = new List<ApiDeploymentRelatedMachineResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiDeploymentRelatedMachineResponseModel> result = await this.DeploymentRelatedMachineService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiDeploymentRelatedMachineResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiDeploymentRelatedMachineRequestModel model)
		{
			CreateResponse<ApiDeploymentRelatedMachineResponseModel> result = await this.DeploymentRelatedMachineService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/DeploymentRelatedMachines/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiDeploymentRelatedMachineResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiDeploymentRelatedMachineRequestModel> patch)
		{
			ApiDeploymentRelatedMachineResponseModel record = await this.DeploymentRelatedMachineService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiDeploymentRelatedMachineRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiDeploymentRelatedMachineResponseModel> result = await this.DeploymentRelatedMachineService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiDeploymentRelatedMachineResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiDeploymentRelatedMachineRequestModel model)
		{
			ApiDeploymentRelatedMachineRequestModel request = await this.PatchModel(id, this.DeploymentRelatedMachineModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiDeploymentRelatedMachineResponseModel> result = await this.DeploymentRelatedMachineService.Update(id, request);

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
			ActionResponse result = await this.DeploymentRelatedMachineService.Delete(id);

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
		[Route("byDeploymentId/{deploymentId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDeploymentRelatedMachineResponseModel>), 200)]
		public async virtual Task<IActionResult> ByDeploymentId(string deploymentId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiDeploymentRelatedMachineResponseModel> response = await this.DeploymentRelatedMachineService.ByDeploymentId(deploymentId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byMachineId/{machineId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDeploymentRelatedMachineResponseModel>), 200)]
		public async virtual Task<IActionResult> ByMachineId(string machineId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiDeploymentRelatedMachineResponseModel> response = await this.DeploymentRelatedMachineService.ByMachineId(machineId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiDeploymentRelatedMachineRequestModel> PatchModel(int id, JsonPatchDocument<ApiDeploymentRelatedMachineRequestModel> patch)
		{
			var record = await this.DeploymentRelatedMachineService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiDeploymentRelatedMachineRequestModel request = this.DeploymentRelatedMachineModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>ba8287f825e2413ff6ad23ff0209e9b2</Hash>
</Codenesium>*/