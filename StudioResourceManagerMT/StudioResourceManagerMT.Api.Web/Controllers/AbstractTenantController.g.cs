using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Web
{
	public abstract class AbstractTenantController : AbstractApiController
	{
		protected ITenantService TenantService { get; private set; }

		protected IApiTenantServerModelMapper TenantModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractTenantController(
			ApiSettings settings,
			ILogger<AbstractTenantController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITenantService tenantService,
			IApiTenantServerModelMapper tenantModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.TenantService = tenantService;
			this.TenantModelMapper = tenantModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTenantServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiTenantServerResponseModel> response = await this.TenantService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiTenantServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiTenantServerResponseModel response = await this.TenantService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiTenantServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTenantServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiTenantServerResponseModel> records = new List<ApiTenantServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiTenantServerResponseModel> result = await this.TenantService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiTenantServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiTenantServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiTenantServerRequestModel model)
		{
			CreateResponse<ApiTenantServerResponseModel> result = await this.TenantService.Create(model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTenantServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiTenantServerRequestModel> patch)
		{
			ApiTenantServerResponseModel record = await this.TenantService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiTenantServerRequestModel model = await this.PatchModel(id, patch) as ApiTenantServerRequestModel;

				UpdateResponse<ApiTenantServerResponseModel> result = await this.TenantService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTenantServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTenantServerRequestModel model)
		{
			ApiTenantServerRequestModel request = await this.PatchModel(id, this.TenantModelMapper.CreatePatch(model)) as ApiTenantServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiTenantServerResponseModel> result = await this.TenantService.Update(id, request);

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
		[Route("{tenantId}/Admins")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiAdminServerResponseModel>), 200)]
		public async virtual Task<IActionResult> AdminsByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiAdminServerResponseModel> response = await this.TenantService.AdminsByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/Events")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiEventServerResponseModel>), 200)]
		public async virtual Task<IActionResult> EventsByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiEventServerResponseModel> response = await this.TenantService.EventsByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/EventStatus")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiEventStatusServerResponseModel>), 200)]
		public async virtual Task<IActionResult> EventStatusByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiEventStatusServerResponseModel> response = await this.TenantService.EventStatusByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/EventStudents")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiEventStudentServerResponseModel>), 200)]
		public async virtual Task<IActionResult> EventStudentsByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiEventStudentServerResponseModel> response = await this.TenantService.EventStudentsByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/EventTeachers")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiEventTeacherServerResponseModel>), 200)]
		public async virtual Task<IActionResult> EventTeachersByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiEventTeacherServerResponseModel> response = await this.TenantService.EventTeachersByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/Families")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiFamilyServerResponseModel>), 200)]
		public async virtual Task<IActionResult> FamiliesByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiFamilyServerResponseModel> response = await this.TenantService.FamiliesByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/Rates")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiRateServerResponseModel>), 200)]
		public async virtual Task<IActionResult> RatesByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiRateServerResponseModel> response = await this.TenantService.RatesByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/Spaces")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSpaceServerResponseModel>), 200)]
		public async virtual Task<IActionResult> SpacesByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSpaceServerResponseModel> response = await this.TenantService.SpacesByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/SpaceFeatures")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSpaceFeatureServerResponseModel>), 200)]
		public async virtual Task<IActionResult> SpaceFeaturesByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSpaceFeatureServerResponseModel> response = await this.TenantService.SpaceFeaturesByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/SpaceSpaceFeatures")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSpaceSpaceFeatureServerResponseModel>), 200)]
		public async virtual Task<IActionResult> SpaceSpaceFeaturesByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSpaceSpaceFeatureServerResponseModel> response = await this.TenantService.SpaceSpaceFeaturesByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/Students")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiStudentServerResponseModel>), 200)]
		public async virtual Task<IActionResult> StudentsByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiStudentServerResponseModel> response = await this.TenantService.StudentsByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/Studios")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiStudioServerResponseModel>), 200)]
		public async virtual Task<IActionResult> StudiosByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiStudioServerResponseModel> response = await this.TenantService.StudiosByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/Teachers")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTeacherServerResponseModel>), 200)]
		public async virtual Task<IActionResult> TeachersByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTeacherServerResponseModel> response = await this.TenantService.TeachersByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/TeacherSkills")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTeacherSkillServerResponseModel>), 200)]
		public async virtual Task<IActionResult> TeacherSkillsByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTeacherSkillServerResponseModel> response = await this.TenantService.TeacherSkillsByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/TeacherTeacherSkills")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTeacherTeacherSkillServerResponseModel>), 200)]
		public async virtual Task<IActionResult> TeacherTeacherSkillsByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTeacherTeacherSkillServerResponseModel> response = await this.TenantService.TeacherTeacherSkillsByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tenantId}/Users")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiUserServerResponseModel>), 200)]
		public async virtual Task<IActionResult> UsersByTenantId(int tenantId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiUserServerResponseModel> response = await this.TenantService.UsersByTenantId(tenantId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiTenantServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiTenantServerRequestModel> patch)
		{
			var record = await this.TenantService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiTenantServerRequestModel request = this.TenantModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>f5a023ff3c4c8a0bafd33f7cf4dbb706</Hash>
</Codenesium>*/