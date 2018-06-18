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
        public abstract class AbstractLessonXStudentService: AbstractService
        {
                private ILessonXStudentRepository lessonXStudentRepository;

                private IApiLessonXStudentRequestModelValidator lessonXStudentModelValidator;

                private IBOLLessonXStudentMapper bolLessonXStudentMapper;

                private IDALLessonXStudentMapper dalLessonXStudentMapper;

                private ILogger logger;

                public AbstractLessonXStudentService(
                        ILogger logger,
                        ILessonXStudentRepository lessonXStudentRepository,
                        IApiLessonXStudentRequestModelValidator lessonXStudentModelValidator,
                        IBOLLessonXStudentMapper bolLessonXStudentMapper,
                        IDALLessonXStudentMapper dalLessonXStudentMapper

                        )
                        : base()

                {
                        this.lessonXStudentRepository = lessonXStudentRepository;
                        this.lessonXStudentModelValidator = lessonXStudentModelValidator;
                        this.bolLessonXStudentMapper = bolLessonXStudentMapper;
                        this.dalLessonXStudentMapper = dalLessonXStudentMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiLessonXStudentResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.lessonXStudentRepository.All(limit, offset);

                        return this.bolLessonXStudentMapper.MapBOToModel(this.dalLessonXStudentMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiLessonXStudentResponseModel> Get(int id)
                {
                        var record = await this.lessonXStudentRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolLessonXStudentMapper.MapBOToModel(this.dalLessonXStudentMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiLessonXStudentResponseModel>> Create(
                        ApiLessonXStudentRequestModel model)
                {
                        CreateResponse<ApiLessonXStudentResponseModel> response = new CreateResponse<ApiLessonXStudentResponseModel>(await this.lessonXStudentModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolLessonXStudentMapper.MapModelToBO(default (int), model);
                                var record = await this.lessonXStudentRepository.Create(this.dalLessonXStudentMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolLessonXStudentMapper.MapBOToModel(this.dalLessonXStudentMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiLessonXStudentRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.lessonXStudentModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolLessonXStudentMapper.MapModelToBO(id, model);
                                await this.lessonXStudentRepository.Update(this.dalLessonXStudentMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.lessonXStudentModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.lessonXStudentRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>fa1b4f1ed5a6b653ecc0545164aa59d0</Hash>
</Codenesium>*/