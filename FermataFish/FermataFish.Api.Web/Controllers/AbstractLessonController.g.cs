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
        public abstract class AbstractLessonController : AbstractApiController
        {
                protected ILessonService LessonService { get; private set; }

                protected IApiLessonModelMapper LessonModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractLessonController(
                        ApiSettings settings,
                        ILogger<AbstractLessonController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ILessonService lessonService,
                        IApiLessonModelMapper lessonModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.LessonService = lessonService;
                        this.LessonModelMapper = lessonModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiLessonResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiLessonResponseModel> response = await this.LessonService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiLessonResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiLessonResponseModel response = await this.LessonService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiLessonResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiLessonRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiLessonResponseModel> records = new List<ApiLessonResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiLessonResponseModel> result = await this.LessonService.Create(model);

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
                [ProducesResponseType(typeof(ApiLessonResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiLessonRequestModel model)
                {
                        CreateResponse<ApiLessonResponseModel> result = await this.LessonService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Lessons/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiLessonResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiLessonRequestModel> patch)
                {
                        ApiLessonResponseModel record = await this.LessonService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiLessonRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.LessonService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiLessonResponseModel response = await this.LessonService.Get(id);

                                        return this.Ok(response);
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
                [ProducesResponseType(typeof(ApiLessonResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiLessonRequestModel model)
                {
                        ApiLessonRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.LessonService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiLessonResponseModel response = await this.LessonService.Get(id);

                                        return this.Ok(response);
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
                        ActionResponse result = await this.LessonService.Delete(id);

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
                [Route("{lessonId}/LessonXStudents")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiLessonResponseModel>), 200)]
                public async virtual Task<IActionResult> LessonXStudents(int lessonId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiLessonXStudentResponseModel> response = await this.LessonService.LessonXStudents(lessonId, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{lessonId}/LessonXTeachers")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiLessonResponseModel>), 200)]
                public async virtual Task<IActionResult> LessonXTeachers(int lessonId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiLessonXTeacherResponseModel> response = await this.LessonService.LessonXTeachers(lessonId, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiLessonRequestModel> CreatePatch(ApiLessonRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiLessonRequestModel>();
                        patch.Replace(x => x.ActualEndDate, model.ActualEndDate);
                        patch.Replace(x => x.ActualStartDate, model.ActualStartDate);
                        patch.Replace(x => x.BillAmount, model.BillAmount);
                        patch.Replace(x => x.LessonStatusId, model.LessonStatusId);
                        patch.Replace(x => x.ScheduledEndDate, model.ScheduledEndDate);
                        patch.Replace(x => x.ScheduledStartDate, model.ScheduledStartDate);
                        patch.Replace(x => x.StudentNotes, model.StudentNotes);
                        patch.Replace(x => x.StudioId, model.StudioId);
                        patch.Replace(x => x.TeacherNotes, model.TeacherNotes);
                        return patch;
                }

                private async Task<ApiLessonRequestModel> PatchModel(int id, JsonPatchDocument<ApiLessonRequestModel> patch)
                {
                        var record = await this.LessonService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiLessonRequestModel request = this.LessonModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>b91c2c06ff2685a86e13183c0f8c3329</Hash>
</Codenesium>*/