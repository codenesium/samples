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
	public abstract class AbstractProjectController : AbstractApiController
	{
		protected IProjectService ProjectService { get; private set; }

		protected IApiProjectModelMapper ProjectModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractProjectController(
			ApiSettings settings,
			ILogger<AbstractProjectController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProjectService projectService,
			IApiProjectModelMapper projectModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.ProjectService = projectService;
			this.ProjectModelMapper = projectModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProjectResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiProjectResponseModel> response = await this.ProjectService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiProjectResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(string id)
		{
			ApiProjectResponseModel response = await this.ProjectService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiProjectResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiProjectRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiProjectResponseModel> records = new List<ApiProjectResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiProjectResponseModel> result = await this.ProjectService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiProjectResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiProjectRequestModel model)
		{
			CreateResponse<ApiProjectResponseModel> result = await this.ProjectService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Projects/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiProjectResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiProjectRequestModel> patch)
		{
			ApiProjectResponseModel record = await this.ProjectService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiProjectRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiProjectResponseModel> result = await this.ProjectService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiProjectResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(string id, [FromBody] ApiProjectRequestModel model)
		{
			ApiProjectRequestModel request = await this.PatchModel(id, this.ProjectModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiProjectResponseModel> result = await this.ProjectService.Update(id, request);

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
			ActionResponse result = await this.ProjectService.Delete(id);

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
		[ProducesResponseType(typeof(ApiProjectResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByName(string name)
		{
			ApiProjectResponseModel response = await this.ProjectService.ByName(name);

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
		[Route("bySlug/{slug}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiProjectResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> BySlug(string slug)
		{
			ApiProjectResponseModel response = await this.ProjectService.BySlug(slug);

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
		[ProducesResponseType(typeof(List<ApiProjectResponseModel>), 200)]
		public async virtual Task<IActionResult> ByDataVersion(byte[] dataVersion)
		{
			List<ApiProjectResponseModel> response = await this.ProjectService.ByDataVersion(dataVersion);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byDiscreteChannelReleaseId/{discreteChannelRelease}/{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiProjectResponseModel>), 200)]
		public async virtual Task<IActionResult> ByDiscreteChannelReleaseId(bool discreteChannelRelease, string id)
		{
			List<ApiProjectResponseModel> response = await this.ProjectService.ByDiscreteChannelReleaseId(discreteChannelRelease, id);

			return this.Ok(response);
		}

		private async Task<ApiProjectRequestModel> PatchModel(string id, JsonPatchDocument<ApiProjectRequestModel> patch)
		{
			var record = await this.ProjectService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiProjectRequestModel request = this.ProjectModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>d51dee264a3b2c535e8d7148b93b8e17</Hash>
</Codenesium>*/