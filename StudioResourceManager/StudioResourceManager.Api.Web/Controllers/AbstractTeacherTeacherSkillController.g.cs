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
	public abstract class AbstractTeacherTeacherSkillController : AbstractApiController
	{
		protected ITeacherTeacherSkillService TeacherTeacherSkillService { get; private set; }

		protected IApiTeacherTeacherSkillServerModelMapper TeacherTeacherSkillModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractTeacherTeacherSkillController(
			ApiSettings settings,
			ILogger<AbstractTeacherTeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherTeacherSkillService teacherTeacherSkillService,
			IApiTeacherTeacherSkillServerModelMapper teacherTeacherSkillModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.TeacherTeacherSkillService = teacherTeacherSkillService;
			this.TeacherTeacherSkillModelMapper = teacherTeacherSkillModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTeacherTeacherSkillServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiTeacherTeacherSkillServerResponseModel> response = await this.TeacherTeacherSkillService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiTeacherTeacherSkillServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiTeacherTeacherSkillServerResponseModel response = await this.TeacherTeacherSkillService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiTeacherTeacherSkillServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTeacherTeacherSkillServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiTeacherTeacherSkillServerResponseModel> records = new List<ApiTeacherTeacherSkillServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiTeacherTeacherSkillServerResponseModel> result = await this.TeacherTeacherSkillService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiTeacherTeacherSkillServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiTeacherTeacherSkillServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiTeacherTeacherSkillServerRequestModel model)
		{
			CreateResponse<ApiTeacherTeacherSkillServerResponseModel> result = await this.TeacherTeacherSkillService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/TeacherTeacherSkills/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiTeacherTeacherSkillServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiTeacherTeacherSkillServerRequestModel> patch)
		{
			ApiTeacherTeacherSkillServerResponseModel record = await this.TeacherTeacherSkillService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiTeacherTeacherSkillServerRequestModel model = await this.PatchModel(id, patch) as ApiTeacherTeacherSkillServerRequestModel;

				UpdateResponse<ApiTeacherTeacherSkillServerResponseModel> result = await this.TeacherTeacherSkillService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTeacherTeacherSkillServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTeacherTeacherSkillServerRequestModel model)
		{
			ApiTeacherTeacherSkillServerRequestModel request = await this.PatchModel(id, this.TeacherTeacherSkillModelMapper.CreatePatch(model)) as ApiTeacherTeacherSkillServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiTeacherTeacherSkillServerResponseModel> result = await this.TeacherTeacherSkillService.Update(id, request);

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
			ActionResponse result = await this.TeacherTeacherSkillService.Delete(id);

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
		[Route("byTeacherId/{teacherId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTeacherTeacherSkillServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByTeacherId(int teacherId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTeacherTeacherSkillServerResponseModel> response = await this.TeacherTeacherSkillService.ByTeacherId(teacherId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byTeacherSkillId/{teacherSkillId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTeacherTeacherSkillServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByTeacherSkillId(int teacherSkillId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTeacherTeacherSkillServerResponseModel> response = await this.TeacherTeacherSkillService.ByTeacherSkillId(teacherSkillId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiTeacherTeacherSkillServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiTeacherTeacherSkillServerRequestModel> patch)
		{
			var record = await this.TeacherTeacherSkillService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiTeacherTeacherSkillServerRequestModel request = this.TeacherTeacherSkillModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>034a836213970870bd038b38ad97db49</Hash>
</Codenesium>*/