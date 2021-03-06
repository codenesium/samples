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
	[Route("api/teachers")]
	[ApiController]
	[ApiVersion("1.0")]

	public class TeacherController : AbstractApiController
	{
		protected ITeacherService TeacherService { get; private set; }

		protected IApiTeacherServerModelMapper TeacherModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public TeacherController(
			ApiSettings settings,
			ILogger<TeacherController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherService teacherService,
			IApiTeacherServerModelMapper teacherModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.TeacherService = teacherService;
			this.TeacherModelMapper = teacherModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTeacherServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiTeacherServerResponseModel> response = await this.TeacherService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiTeacherServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiTeacherServerResponseModel response = await this.TeacherService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiTeacherServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTeacherServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiTeacherServerResponseModel> records = new List<ApiTeacherServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiTeacherServerResponseModel> result = await this.TeacherService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiTeacherServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiTeacherServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiTeacherServerRequestModel model)
		{
			CreateResponse<ApiTeacherServerResponseModel> result = await this.TeacherService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Teachers/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiTeacherServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiTeacherServerRequestModel> patch)
		{
			ApiTeacherServerResponseModel record = await this.TeacherService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiTeacherServerRequestModel model = await this.PatchModel(id, patch) as ApiTeacherServerRequestModel;

				UpdateResponse<ApiTeacherServerResponseModel> result = await this.TeacherService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTeacherServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTeacherServerRequestModel model)
		{
			ApiTeacherServerRequestModel request = await this.PatchModel(id, this.TeacherModelMapper.CreatePatch(model)) as ApiTeacherServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiTeacherServerResponseModel> result = await this.TeacherService.Update(id, request);

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
			ActionResponse result = await this.TeacherService.Delete(id);

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
		[Route("byUserId/{userId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTeacherServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByUserId(int userId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTeacherServerResponseModel> response = await this.TeacherService.ByUserId(userId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{teacherId}/EventTeachers")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiEventTeacherServerResponseModel>), 200)]
		public async virtual Task<IActionResult> EventTeachersByTeacherId(int teacherId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiEventTeacherServerResponseModel> response = await this.TeacherService.EventTeachersByTeacherId(teacherId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{teacherId}/Rates")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiRateServerResponseModel>), 200)]
		public async virtual Task<IActionResult> RatesByTeacherId(int teacherId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiRateServerResponseModel> response = await this.TeacherService.RatesByTeacherId(teacherId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{teacherId}/TeacherTeacherSkills")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTeacherTeacherSkillServerResponseModel>), 200)]
		public async virtual Task<IActionResult> TeacherTeacherSkillsByTeacherId(int teacherId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTeacherTeacherSkillServerResponseModel> response = await this.TeacherService.TeacherTeacherSkillsByTeacherId(teacherId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiTeacherServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiTeacherServerRequestModel> patch)
		{
			var record = await this.TeacherService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiTeacherServerRequestModel request = this.TeacherModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>384e66aa7d183b49c3e1ac142ae5861a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/