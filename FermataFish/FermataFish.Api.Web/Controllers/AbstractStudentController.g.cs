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
        public abstract class AbstractStudentController : AbstractApiController
        {
                protected IStudentService StudentService { get; private set; }

                protected IApiStudentModelMapper StudentModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractStudentController(
                        ApiSettings settings,
                        ILogger<AbstractStudentController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IStudentService studentService,
                        IApiStudentModelMapper studentModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.StudentService = studentService;
                        this.StudentModelMapper = studentModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStudentResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiStudentResponseModel> response = await this.StudentService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiStudentResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiStudentResponseModel response = await this.StudentService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiStudentResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiStudentRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiStudentResponseModel> records = new List<ApiStudentResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiStudentResponseModel> result = await this.StudentService.Create(model);

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
                [ProducesResponseType(typeof(ApiStudentResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiStudentRequestModel model)
                {
                        CreateResponse<ApiStudentResponseModel> result = await this.StudentService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Students/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiStudentResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiStudentRequestModel> patch)
                {
                        ApiStudentResponseModel record = await this.StudentService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiStudentRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.StudentService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiStudentResponseModel response = await this.StudentService.Get(id);

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
                [ProducesResponseType(typeof(ApiStudentResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiStudentRequestModel model)
                {
                        ApiStudentRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.StudentService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiStudentResponseModel response = await this.StudentService.Get(id);

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
                        ActionResponse result = await this.StudentService.Delete(id);

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
                [Route("{studentId}/LessonXStudents")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStudentResponseModel>), 200)]
                public async virtual Task<IActionResult> LessonXStudents(int studentId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiLessonXStudentResponseModel> response = await this.StudentService.LessonXStudents(studentId, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{studentId}/LessonXTeachers")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStudentResponseModel>), 200)]
                public async virtual Task<IActionResult> LessonXTeachers(int studentId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiLessonXTeacherResponseModel> response = await this.StudentService.LessonXTeachers(studentId, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{studentId}/StudentXFamilies")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStudentResponseModel>), 200)]
                public async virtual Task<IActionResult> StudentXFamilies(int studentId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiStudentXFamilyResponseModel> response = await this.StudentService.StudentXFamilies(studentId, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiStudentRequestModel> CreatePatch(ApiStudentRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiStudentRequestModel>();
                        patch.Replace(x => x.Birthday, model.Birthday);
                        patch.Replace(x => x.Email, model.Email);
                        patch.Replace(x => x.EmailRemindersEnabled, model.EmailRemindersEnabled);
                        patch.Replace(x => x.FamilyId, model.FamilyId);
                        patch.Replace(x => x.FirstName, model.FirstName);
                        patch.Replace(x => x.IsAdult, model.IsAdult);
                        patch.Replace(x => x.LastName, model.LastName);
                        patch.Replace(x => x.Phone, model.Phone);
                        patch.Replace(x => x.SmsRemindersEnabled, model.SmsRemindersEnabled);
                        patch.Replace(x => x.StudioId, model.StudioId);
                        return patch;
                }

                private async Task<ApiStudentRequestModel> PatchModel(int id, JsonPatchDocument<ApiStudentRequestModel> patch)
                {
                        var record = await this.StudentService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiStudentRequestModel request = this.StudentModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>8b9c26a073c9f4217e5616816011b9ae</Hash>
</Codenesium>*/