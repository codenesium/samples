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
        public abstract class AbstractTeacherXTeacherSkillController : AbstractApiController
        {
                protected ITeacherXTeacherSkillService TeacherXTeacherSkillService { get; private set; }

                protected IApiTeacherXTeacherSkillModelMapper TeacherXTeacherSkillModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractTeacherXTeacherSkillController(
                        ApiSettings settings,
                        ILogger<AbstractTeacherXTeacherSkillController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITeacherXTeacherSkillService teacherXTeacherSkillService,
                        IApiTeacherXTeacherSkillModelMapper teacherXTeacherSkillModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.TeacherXTeacherSkillService = teacherXTeacherSkillService;
                        this.TeacherXTeacherSkillModelMapper = teacherXTeacherSkillModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiTeacherXTeacherSkillResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiTeacherXTeacherSkillResponseModel> response = await this.TeacherXTeacherSkillService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiTeacherXTeacherSkillResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiTeacherXTeacherSkillResponseModel response = await this.TeacherXTeacherSkillService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiTeacherXTeacherSkillResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTeacherXTeacherSkillRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiTeacherXTeacherSkillResponseModel> records = new List<ApiTeacherXTeacherSkillResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiTeacherXTeacherSkillResponseModel> result = await this.TeacherXTeacherSkillService.Create(model);

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
                [ProducesResponseType(typeof(ApiTeacherXTeacherSkillResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiTeacherXTeacherSkillRequestModel model)
                {
                        CreateResponse<ApiTeacherXTeacherSkillResponseModel> result = await this.TeacherXTeacherSkillService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/TeacherXTeacherSkills/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiTeacherXTeacherSkillResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiTeacherXTeacherSkillRequestModel> patch)
                {
                        ApiTeacherXTeacherSkillResponseModel record = await this.TeacherXTeacherSkillService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiTeacherXTeacherSkillRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.TeacherXTeacherSkillService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiTeacherXTeacherSkillResponseModel response = await this.TeacherXTeacherSkillService.Get(id);

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
                [ProducesResponseType(typeof(ApiTeacherXTeacherSkillResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTeacherXTeacherSkillRequestModel model)
                {
                        ApiTeacherXTeacherSkillRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.TeacherXTeacherSkillService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiTeacherXTeacherSkillResponseModel response = await this.TeacherXTeacherSkillService.Get(id);

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
                        ActionResponse result = await this.TeacherXTeacherSkillService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiTeacherXTeacherSkillRequestModel> CreatePatch(ApiTeacherXTeacherSkillRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiTeacherXTeacherSkillRequestModel>();
                        patch.Replace(x => x.TeacherId, model.TeacherId);
                        patch.Replace(x => x.TeacherSkillId, model.TeacherSkillId);
                        return patch;
                }

                private async Task<ApiTeacherXTeacherSkillRequestModel> PatchModel(int id, JsonPatchDocument<ApiTeacherXTeacherSkillRequestModel> patch)
                {
                        var record = await this.TeacherXTeacherSkillService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiTeacherXTeacherSkillRequestModel request = this.TeacherXTeacherSkillModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>63ce2ef9c784b5be12acac3f37d5618f</Hash>
</Codenesium>*/