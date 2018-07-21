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
        public abstract class AbstractLessonService : AbstractService
        {
                private ILessonRepository lessonRepository;

                private IApiLessonRequestModelValidator lessonModelValidator;

                private IBOLLessonMapper bolLessonMapper;

                private IDALLessonMapper dalLessonMapper;

                private IBOLLessonXStudentMapper bolLessonXStudentMapper;

                private IDALLessonXStudentMapper dalLessonXStudentMapper;
                private IBOLLessonXTeacherMapper bolLessonXTeacherMapper;

                private IDALLessonXTeacherMapper dalLessonXTeacherMapper;

                private ILogger logger;

                public AbstractLessonService(
                        ILogger logger,
                        ILessonRepository lessonRepository,
                        IApiLessonRequestModelValidator lessonModelValidator,
                        IBOLLessonMapper bolLessonMapper,
                        IDALLessonMapper dalLessonMapper,
                        IBOLLessonXStudentMapper bolLessonXStudentMapper,
                        IDALLessonXStudentMapper dalLessonXStudentMapper,
                        IBOLLessonXTeacherMapper bolLessonXTeacherMapper,
                        IDALLessonXTeacherMapper dalLessonXTeacherMapper)
                        : base()
                {
                        this.lessonRepository = lessonRepository;
                        this.lessonModelValidator = lessonModelValidator;
                        this.bolLessonMapper = bolLessonMapper;
                        this.dalLessonMapper = dalLessonMapper;
                        this.bolLessonXStudentMapper = bolLessonXStudentMapper;
                        this.dalLessonXStudentMapper = dalLessonXStudentMapper;
                        this.bolLessonXTeacherMapper = bolLessonXTeacherMapper;
                        this.dalLessonXTeacherMapper = dalLessonXTeacherMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiLessonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.lessonRepository.All(limit, offset);

                        return this.bolLessonMapper.MapBOToModel(this.dalLessonMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiLessonResponseModel> Get(int id)
                {
                        var record = await this.lessonRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolLessonMapper.MapBOToModel(this.dalLessonMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiLessonResponseModel>> Create(
                        ApiLessonRequestModel model)
                {
                        CreateResponse<ApiLessonResponseModel> response = new CreateResponse<ApiLessonResponseModel>(await this.lessonModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolLessonMapper.MapModelToBO(default(int), model);
                                var record = await this.lessonRepository.Create(this.dalLessonMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolLessonMapper.MapBOToModel(this.dalLessonMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiLessonResponseModel>> Update(
                        int id,
                        ApiLessonRequestModel model)
                {
                        var validationResult = await this.lessonModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolLessonMapper.MapModelToBO(id, model);
                                await this.lessonRepository.Update(this.dalLessonMapper.MapBOToEF(bo));

                                var record = await this.lessonRepository.Get(id);

                                return new UpdateResponse<ApiLessonResponseModel>(this.bolLessonMapper.MapBOToModel(this.dalLessonMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiLessonResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.lessonModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.lessonRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiLessonXStudentResponseModel>> LessonXStudents(int lessonId, int limit = int.MaxValue, int offset = 0)
                {
                        List<LessonXStudent> records = await this.lessonRepository.LessonXStudents(lessonId, limit, offset);

                        return this.bolLessonXStudentMapper.MapBOToModel(this.dalLessonXStudentMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiLessonXTeacherResponseModel>> LessonXTeachers(int lessonId, int limit = int.MaxValue, int offset = 0)
                {
                        List<LessonXTeacher> records = await this.lessonRepository.LessonXTeachers(lessonId, limit, offset);

                        return this.bolLessonXTeacherMapper.MapBOToModel(this.dalLessonXTeacherMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>501d87c6d0ecf753e115a1ed43749613</Hash>
</Codenesium>*/