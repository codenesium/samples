using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentValidation.Results;
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

namespace FermataFishNS.Api.Web
{
	public abstract class AbstractStudioController : AbstractApiController
	{
		protected IStudioService StudioService { get; private set; }

		protected IApiStudioModelMapper StudioModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractStudioController(
			ApiSettings settings,
			ILogger<AbstractStudioController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStudioService studioService,
			IApiStudioModelMapper studioModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.StudioService = studioService;
			this.StudioModelMapper = studioModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiStudioResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiStudioResponseModel> response = await this.StudioService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiStudioResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiStudioResponseModel response = await this.StudioService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiStudioResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiStudioRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiStudioResponseModel> records = new List<ApiStudioResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiStudioResponseModel> result = await this.StudioService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiStudioResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiStudioRequestModel model)
		{
			CreateResponse<ApiStudioResponseModel> result = await this.StudioService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Studios/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiStudioResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiStudioRequestModel> patch)
		{
			ApiStudioResponseModel record = await this.StudioService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiStudioRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiStudioResponseModel> result = await this.StudioService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiStudioResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiStudioRequestModel model)
		{
			ApiStudioRequestModel request = await this.PatchModel(id, this.StudioModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiStudioResponseModel> result = await this.StudioService.Update(id, request);

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
			ActionResponse result = await this.StudioService.Delete(id);

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
		[Route("{studioId}/Admins")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiAdminResponseModel>), 200)]
		public async virtual Task<IActionResult> Admins(int studioId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiAdminResponseModel> response = await this.StudioService.Admins(studioId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}/Families")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiFamilyResponseModel>), 200)]
		public async virtual Task<IActionResult> Families(int id, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiFamilyResponseModel> response = await this.StudioService.Families(id, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{studioId}/Lessons")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiLessonResponseModel>), 200)]
		public async virtual Task<IActionResult> Lessons(int studioId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiLessonResponseModel> response = await this.StudioService.Lessons(studioId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}/LessonStatus")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiLessonStatusResponseModel>), 200)]
		public async virtual Task<IActionResult> LessonStatus(int id, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiLessonStatusResponseModel> response = await this.StudioService.LessonStatus(id, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{studioId}/Spaces")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSpaceResponseModel>), 200)]
		public async virtual Task<IActionResult> Spaces(int studioId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiSpaceResponseModel> response = await this.StudioService.Spaces(studioId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{studioId}/SpaceFeatures")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSpaceFeatureResponseModel>), 200)]
		public async virtual Task<IActionResult> SpaceFeatures(int studioId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiSpaceFeatureResponseModel> response = await this.StudioService.SpaceFeatures(studioId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{studioId}/Students")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiStudentResponseModel>), 200)]
		public async virtual Task<IActionResult> Students(int studioId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiStudentResponseModel> response = await this.StudioService.Students(studioId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{studioId}/Teachers")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTeacherResponseModel>), 200)]
		public async virtual Task<IActionResult> Teachers(int studioId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiTeacherResponseModel> response = await this.StudioService.Teachers(studioId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{studioId}/TeacherSkills")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTeacherSkillResponseModel>), 200)]
		public async virtual Task<IActionResult> TeacherSkills(int studioId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiTeacherSkillResponseModel> response = await this.StudioService.TeacherSkills(studioId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiStudioRequestModel> PatchModel(int id, JsonPatchDocument<ApiStudioRequestModel> patch)
		{
			var record = await this.StudioService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiStudioRequestModel request = this.StudioModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>f1dbd3c76d914dcbac350d68abdb5f5b</Hash>
</Codenesium>*/