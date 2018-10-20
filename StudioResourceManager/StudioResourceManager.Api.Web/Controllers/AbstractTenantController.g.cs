using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Web
{
	public abstract class AbstractTenantController : AbstractApiController
	{
		protected ITenantService TenantService { get; private set; }

		protected IApiTenantModelMapper TenantModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractTenantController(
			ApiSettings settings,
			ILogger<AbstractTenantController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITenantService tenantService,
			IApiTenantModelMapper tenantModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.TenantService = tenantService;
			this.TenantModelMapper = tenantModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTenantResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTenantResponseModel> response = await this.TenantService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiTenantResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiTenantResponseModel response = await this.TenantService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiTenantResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTenantRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiTenantResponseModel> records = new List<ApiTenantResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiTenantResponseModel> result = await this.TenantService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiTenantResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiTenantRequestModel model)
		{
			CreateResponse<ApiTenantResponseModel> result = await this.TenantService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Tenants/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiTenantResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiTenantRequestModel> patch)
		{
			ApiTenantResponseModel record = await this.TenantService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiTenantRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiTenantResponseModel> result = await this.TenantService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTenantResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTenantRequestModel model)
		{
			ApiTenantRequestModel request = await this.PatchModel(id, this.TenantModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiTenantResponseModel> result = await this.TenantService.Update(id, request);

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
			ActionResponse result = await this.TenantService.Delete(id);

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
		[Route("{tenantId}/AdminsByTenantId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiAdminResponseModel>), 200)]
		public async virtual Task<IActionResult> AdminsByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiAdminResponseModel> response = await this.TenantService.AdminsByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/EventsByTenantId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiEventResponseModel>), 200)]
		public async virtual Task<IActionResult> EventsByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiEventResponseModel> response = await this.TenantService.EventsByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/EventStatusesByTenantId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiEventStatusResponseModel>), 200)]
		public async virtual Task<IActionResult> EventStatusesByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiEventStatusResponseModel> response = await this.TenantService.EventStatusesByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/EventStudentsByTenantId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiEventStudentResponseModel>), 200)]
		public async virtual Task<IActionResult> EventStudentsByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiEventStudentResponseModel> response = await this.TenantService.EventStudentsByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/EventTeachersByTenantId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiEventTeacherResponseModel>), 200)]
		public async virtual Task<IActionResult> EventTeachersByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiEventTeacherResponseModel> response = await this.TenantService.EventTeachersByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/FamiliesByTenantId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiFamilyResponseModel>), 200)]
		public async virtual Task<IActionResult> FamiliesByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiFamilyResponseModel> response = await this.TenantService.FamiliesByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/RatesByTenantId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiRateResponseModel>), 200)]
		public async virtual Task<IActionResult> RatesByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiRateResponseModel> response = await this.TenantService.RatesByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/SpacesByTenantId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSpaceResponseModel>), 200)]
		public async virtual Task<IActionResult> SpacesByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSpaceResponseModel> response = await this.TenantService.SpacesByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/SpaceFeaturesByTenantId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSpaceFeatureResponseModel>), 200)]
		public async virtual Task<IActionResult> SpaceFeaturesByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSpaceFeatureResponseModel> response = await this.TenantService.SpaceFeaturesByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/SpaceSpaceFeaturesByTenantId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSpaceSpaceFeatureResponseModel>), 200)]
		public async virtual Task<IActionResult> SpaceSpaceFeaturesByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSpaceSpaceFeatureResponseModel> response = await this.TenantService.SpaceSpaceFeaturesByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/StudentsByTenantId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiStudentResponseModel>), 200)]
		public async virtual Task<IActionResult> StudentsByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiStudentResponseModel> response = await this.TenantService.StudentsByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/StudiosByTenantId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiStudioResponseModel>), 200)]
		public async virtual Task<IActionResult> StudiosByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiStudioResponseModel> response = await this.TenantService.StudiosByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/TeachersByTenantId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTeacherResponseModel>), 200)]
		public async virtual Task<IActionResult> TeachersByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTeacherResponseModel> response = await this.TenantService.TeachersByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/TeacherSkillsByTenantId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTeacherSkillResponseModel>), 200)]
		public async virtual Task<IActionResult> TeacherSkillsByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTeacherSkillResponseModel> response = await this.TenantService.TeacherSkillsByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/TeacherTeacherSkillsByTenantId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTeacherTeacherSkillResponseModel>), 200)]
		public async virtual Task<IActionResult> TeacherTeacherSkillsByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTeacherTeacherSkillResponseModel> response = await this.TenantService.TeacherTeacherSkillsByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/UsersByTenantId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiUserResponseModel>), 200)]
		public async virtual Task<IActionResult> UsersByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiUserResponseModel> response = await this.TenantService.UsersByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiTenantRequestModel> PatchModel(int id, JsonPatchDocument<ApiTenantRequestModel> patch)
		{
			var record = await this.TenantService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiTenantRequestModel request = this.TenantModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>d4b8ed74b9046c51e0119997c1b1a21b</Hash>
</Codenesium>*/