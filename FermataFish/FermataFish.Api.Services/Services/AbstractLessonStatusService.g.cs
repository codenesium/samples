using Codenesium.DataConversionExtensions.AspNetCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractLessonStatusService : AbstractService
        {
                private ILessonStatusRepository lessonStatusRepository;

                private IApiLessonStatusRequestModelValidator lessonStatusModelValidator;

                private IBOLLessonStatusMapper bolLessonStatusMapper;

                private IDALLessonStatusMapper dalLessonStatusMapper;

                private IBOLLessonMapper bolLessonMapper;

                private IDALLessonMapper dalLessonMapper;

                private ILogger logger;

                public AbstractLessonStatusService(
                        ILogger logger,
                        ILessonStatusRepository lessonStatusRepository,
                        IApiLessonStatusRequestModelValidator lessonStatusModelValidator,
                        IBOLLessonStatusMapper bolLessonStatusMapper,
                        IDALLessonStatusMapper dalLessonStatusMapper,
                        IBOLLessonMapper bolLessonMapper,
                        IDALLessonMapper dalLessonMapper)
                        : base()
                {
                        this.lessonStatusRepository = lessonStatusRepository;
                        this.lessonStatusModelValidator = lessonStatusModelValidator;
                        this.bolLessonStatusMapper = bolLessonStatusMapper;
                        this.dalLessonStatusMapper = dalLessonStatusMapper;
                        this.bolLessonMapper = bolLessonMapper;
                        this.dalLessonMapper = dalLessonMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiLessonStatusResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.lessonStatusRepository.All(limit, offset);

                        return this.bolLessonStatusMapper.MapBOToModel(this.dalLessonStatusMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiLessonStatusResponseModel> Get(int id)
                {
                        var record = await this.lessonStatusRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolLessonStatusMapper.MapBOToModel(this.dalLessonStatusMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiLessonStatusResponseModel>> Create(
                        ApiLessonStatusRequestModel model)
                {
                        CreateResponse<ApiLessonStatusResponseModel> response = new CreateResponse<ApiLessonStatusResponseModel>(await this.lessonStatusModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolLessonStatusMapper.MapModelToBO(default(int), model);
                                var record = await this.lessonStatusRepository.Create(this.dalLessonStatusMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolLessonStatusMapper.MapBOToModel(this.dalLessonStatusMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiLessonStatusRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.lessonStatusModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolLessonStatusMapper.MapModelToBO(id, model);
                                await this.lessonStatusRepository.Update(this.dalLessonStatusMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.lessonStatusModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.lessonStatusRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiLessonResponseModel>> Lessons(int lessonStatusId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Lesson> records = await this.lessonStatusRepository.Lessons(lessonStatusId, limit, offset);

                        return this.bolLessonMapper.MapBOToModel(this.dalLessonMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>515fe3041213aed102ad0ab3a6d9f138</Hash>
</Codenesium>*/