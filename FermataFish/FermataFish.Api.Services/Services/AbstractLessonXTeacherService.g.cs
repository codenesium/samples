using Codenesium.DataConversionExtensions;
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
        public abstract class AbstractLessonXTeacherService : AbstractService
        {
                private ILessonXTeacherRepository lessonXTeacherRepository;

                private IApiLessonXTeacherRequestModelValidator lessonXTeacherModelValidator;

                private IBOLLessonXTeacherMapper bolLessonXTeacherMapper;

                private IDALLessonXTeacherMapper dalLessonXTeacherMapper;

                private ILogger logger;

                public AbstractLessonXTeacherService(
                        ILogger logger,
                        ILessonXTeacherRepository lessonXTeacherRepository,
                        IApiLessonXTeacherRequestModelValidator lessonXTeacherModelValidator,
                        IBOLLessonXTeacherMapper bolLessonXTeacherMapper,
                        IDALLessonXTeacherMapper dalLessonXTeacherMapper)
                        : base()
                {
                        this.lessonXTeacherRepository = lessonXTeacherRepository;
                        this.lessonXTeacherModelValidator = lessonXTeacherModelValidator;
                        this.bolLessonXTeacherMapper = bolLessonXTeacherMapper;
                        this.dalLessonXTeacherMapper = dalLessonXTeacherMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiLessonXTeacherResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.lessonXTeacherRepository.All(limit, offset);

                        return this.bolLessonXTeacherMapper.MapBOToModel(this.dalLessonXTeacherMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiLessonXTeacherResponseModel> Get(int id)
                {
                        var record = await this.lessonXTeacherRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolLessonXTeacherMapper.MapBOToModel(this.dalLessonXTeacherMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiLessonXTeacherResponseModel>> Create(
                        ApiLessonXTeacherRequestModel model)
                {
                        CreateResponse<ApiLessonXTeacherResponseModel> response = new CreateResponse<ApiLessonXTeacherResponseModel>(await this.lessonXTeacherModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolLessonXTeacherMapper.MapModelToBO(default(int), model);
                                var record = await this.lessonXTeacherRepository.Create(this.dalLessonXTeacherMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolLessonXTeacherMapper.MapBOToModel(this.dalLessonXTeacherMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiLessonXTeacherRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.lessonXTeacherModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolLessonXTeacherMapper.MapModelToBO(id, model);
                                await this.lessonXTeacherRepository.Update(this.dalLessonXTeacherMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.lessonXTeacherModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.lessonXTeacherRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>2c72ca084da779d56bcf482f1fa3bde8</Hash>
</Codenesium>*/