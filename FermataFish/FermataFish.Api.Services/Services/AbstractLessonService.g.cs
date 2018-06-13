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
        public abstract class AbstractLessonService: AbstractService
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
                        IDALLessonMapper dalLessonMapper

                        ,
                        IBOLLessonXStudentMapper bolLessonXStudentMapper,
                        IDALLessonXStudentMapper dalLessonXStudentMapper
                        ,
                        IBOLLessonXTeacherMapper bolLessonXTeacherMapper,
                        IDALLessonXTeacherMapper dalLessonXTeacherMapper

                        )
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

                public virtual async Task<List<ApiLessonResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.lessonRepository.All(limit, offset, orderClause);

                        return this.bolLessonMapper.MapBOToModel(this.dalLessonMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiLessonResponseModel> Get(int id)
                {
                        var record = await this.lessonRepository.Get(id);

                        return this.bolLessonMapper.MapBOToModel(this.dalLessonMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiLessonResponseModel>> Create(
                        ApiLessonRequestModel model)
                {
                        CreateResponse<ApiLessonResponseModel> response = new CreateResponse<ApiLessonResponseModel>(await this.lessonModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolLessonMapper.MapModelToBO(default (int), model);
                                var record = await this.lessonRepository.Create(this.dalLessonMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolLessonMapper.MapBOToModel(this.dalLessonMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiLessonRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.lessonModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolLessonMapper.MapModelToBO(id, model);
                                await this.lessonRepository.Update(this.dalLessonMapper.MapBOToEF(bo));
                        }

                        return response;
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
    <Hash>ffe4fc507baee903a63df684c4e8495b</Hash>
</Codenesium>*/