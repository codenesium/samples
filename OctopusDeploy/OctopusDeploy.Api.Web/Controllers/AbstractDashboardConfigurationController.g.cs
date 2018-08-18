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
	public abstract class AbstractDashboardConfigurationController : AbstractApiController
	{
		protected IDashboardConfigurationService DashboardConfigurationService { get; private set; }

		protected IApiDashboardConfigurationModelMapper DashboardConfigurationModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractDashboardConfigurationController(
			ApiSettings settings,
			ILogger<AbstractDashboardConfigurationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDashboardConfigurationService dashboardConfigurationService,
			IApiDashboardConfigurationModelMapper dashboardConfigurationModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.DashboardConfigurationService = dashboardConfigurationService;
			this.DashboardConfigurationModelMapper = dashboardConfigurationModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDashboardConfigurationResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiDashboardConfigurationResponseModel> response = await this.DashboardConfigurationService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiDashboardConfigurationResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(string id)
		{
			ApiDashboardConfigurationResponseModel response = await this.DashboardConfigurationService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiDashboardConfigurationResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiDashboardConfigurationRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiDashboardConfigurationResponseModel> records = new List<ApiDashboardConfigurationResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiDashboardConfigurationResponseModel> result = await this.DashboardConfigurationService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiDashboardConfigurationResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiDashboardConfigurationRequestModel model)
		{
			CreateResponse<ApiDashboardConfigurationResponseModel> result = await this.DashboardConfigurationService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/DashboardConfigurations/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiDashboardConfigurationResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiDashboardConfigurationRequestModel> patch)
		{
			ApiDashboardConfigurationResponseModel record = await this.DashboardConfigurationService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiDashboardConfigurationRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiDashboardConfigurationResponseModel> result = await this.DashboardConfigurationService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiDashboardConfigurationResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(string id, [FromBody] ApiDashboardConfigurationRequestModel model)
		{
			ApiDashboardConfigurationRequestModel request = await this.PatchModel(id, this.DashboardConfigurationModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiDashboardConfigurationResponseModel> result = await this.DashboardConfigurationService.Update(id, request);

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
			ActionResponse result = await this.DashboardConfigurationService.Delete(id);

			if (result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiDashboardConfigurationRequestModel> PatchModel(string id, JsonPatchDocument<ApiDashboardConfigurationRequestModel> patch)
		{
			var record = await this.DashboardConfigurationService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiDashboardConfigurationRequestModel request = this.DashboardConfigurationModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>ccd60a8f35dfe8214aec3302f5eb7004</Hash>
</Codenesium>*/