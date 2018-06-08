using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractLessonStatusService: AbstractService
        {
                private ILessonStatusRepository lessonStatusRepository;

                private IApiLessonStatusRequestModelValidator lessonStatusModelValidator;

                private IBOLLessonStatusMapper bolLessonStatusMapper;

                private IDALLessonStatusMapper dalLessonStatusMapper;

                private ILogger logger;

                public AbstractLessonStatusService(
                        ILogger logger,
                        ILessonStatusRepository lessonStatusRepository,
                        IApiLessonStatusRequestModelValidator lessonStatusModelValidator,
                        IBOLLessonStatusMapper bollessonStatusMapper,
                        IDALLessonStatusMapper dallessonStatusMapper)
                        : base()

                {
                        this.lessonStatusRepository = lessonStatusRepository;
                        this.lessonStatusModelValidator = lessonStatusModelValidator;
                        this.bolLessonStatusMapper = bollessonStatusMapper;
                        this.dalLessonStatusMapper = dallessonStatusMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiLessonStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.lessonStatusRepository.All(skip, take, orderClause);

                        return this.bolLessonStatusMapper.MapBOToModel(this.dalLessonStatusMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiLessonStatusResponseModel> Get(int id)
                {
                        var record = await this.lessonStatusRepository.Get(id);

                        return this.bolLessonStatusMapper.MapBOToModel(this.dalLessonStatusMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiLessonStatusResponseModel>> Create(
                        ApiLessonStatusRequestModel model)
                {
                        CreateResponse<ApiLessonStatusResponseModel> response = new CreateResponse<ApiLessonStatusResponseModel>(await this.lessonStatusModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolLessonStatusMapper.MapModelToBO(default (int), model);
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
        }
}

/*<Codenesium>
    <Hash>d9740acc5b7405262229aabc46925310</Hash>
</Codenesium>*/