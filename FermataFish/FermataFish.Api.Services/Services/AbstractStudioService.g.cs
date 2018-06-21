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
        public abstract class AbstractStudioService : AbstractService
        {
                private IStudioRepository studioRepository;

                private IApiStudioRequestModelValidator studioModelValidator;

                private IBOLStudioMapper bolStudioMapper;

                private IDALStudioMapper dalStudioMapper;

                private IBOLAdminMapper bolAdminMapper;

                private IDALAdminMapper dalAdminMapper;
                private IBOLFamilyMapper bolFamilyMapper;

                private IDALFamilyMapper dalFamilyMapper;
                private IBOLLessonMapper bolLessonMapper;

                private IDALLessonMapper dalLessonMapper;
                private IBOLLessonStatusMapper bolLessonStatusMapper;

                private IDALLessonStatusMapper dalLessonStatusMapper;
                private IBOLSpaceMapper bolSpaceMapper;

                private IDALSpaceMapper dalSpaceMapper;
                private IBOLSpaceFeatureMapper bolSpaceFeatureMapper;

                private IDALSpaceFeatureMapper dalSpaceFeatureMapper;
                private IBOLStudentMapper bolStudentMapper;

                private IDALStudentMapper dalStudentMapper;
                private IBOLTeacherMapper bolTeacherMapper;

                private IDALTeacherMapper dalTeacherMapper;
                private IBOLTeacherSkillMapper bolTeacherSkillMapper;

                private IDALTeacherSkillMapper dalTeacherSkillMapper;

                private ILogger logger;

                public AbstractStudioService(
                        ILogger logger,
                        IStudioRepository studioRepository,
                        IApiStudioRequestModelValidator studioModelValidator,
                        IBOLStudioMapper bolStudioMapper,
                        IDALStudioMapper dalStudioMapper,
                        IBOLAdminMapper bolAdminMapper,
                        IDALAdminMapper dalAdminMapper,
                        IBOLFamilyMapper bolFamilyMapper,
                        IDALFamilyMapper dalFamilyMapper,
                        IBOLLessonMapper bolLessonMapper,
                        IDALLessonMapper dalLessonMapper,
                        IBOLLessonStatusMapper bolLessonStatusMapper,
                        IDALLessonStatusMapper dalLessonStatusMapper,
                        IBOLSpaceMapper bolSpaceMapper,
                        IDALSpaceMapper dalSpaceMapper,
                        IBOLSpaceFeatureMapper bolSpaceFeatureMapper,
                        IDALSpaceFeatureMapper dalSpaceFeatureMapper,
                        IBOLStudentMapper bolStudentMapper,
                        IDALStudentMapper dalStudentMapper,
                        IBOLTeacherMapper bolTeacherMapper,
                        IDALTeacherMapper dalTeacherMapper,
                        IBOLTeacherSkillMapper bolTeacherSkillMapper,
                        IDALTeacherSkillMapper dalTeacherSkillMapper)
                        : base()
                {
                        this.studioRepository = studioRepository;
                        this.studioModelValidator = studioModelValidator;
                        this.bolStudioMapper = bolStudioMapper;
                        this.dalStudioMapper = dalStudioMapper;
                        this.bolAdminMapper = bolAdminMapper;
                        this.dalAdminMapper = dalAdminMapper;
                        this.bolFamilyMapper = bolFamilyMapper;
                        this.dalFamilyMapper = dalFamilyMapper;
                        this.bolLessonMapper = bolLessonMapper;
                        this.dalLessonMapper = dalLessonMapper;
                        this.bolLessonStatusMapper = bolLessonStatusMapper;
                        this.dalLessonStatusMapper = dalLessonStatusMapper;
                        this.bolSpaceMapper = bolSpaceMapper;
                        this.dalSpaceMapper = dalSpaceMapper;
                        this.bolSpaceFeatureMapper = bolSpaceFeatureMapper;
                        this.dalSpaceFeatureMapper = dalSpaceFeatureMapper;
                        this.bolStudentMapper = bolStudentMapper;
                        this.dalStudentMapper = dalStudentMapper;
                        this.bolTeacherMapper = bolTeacherMapper;
                        this.dalTeacherMapper = dalTeacherMapper;
                        this.bolTeacherSkillMapper = bolTeacherSkillMapper;
                        this.dalTeacherSkillMapper = dalTeacherSkillMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiStudioResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.studioRepository.All(limit, offset);

                        return this.bolStudioMapper.MapBOToModel(this.dalStudioMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiStudioResponseModel> Get(int id)
                {
                        var record = await this.studioRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolStudioMapper.MapBOToModel(this.dalStudioMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiStudioResponseModel>> Create(
                        ApiStudioRequestModel model)
                {
                        CreateResponse<ApiStudioResponseModel> response = new CreateResponse<ApiStudioResponseModel>(await this.studioModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolStudioMapper.MapModelToBO(default(int), model);
                                var record = await this.studioRepository.Create(this.dalStudioMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolStudioMapper.MapBOToModel(this.dalStudioMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiStudioRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.studioModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolStudioMapper.MapModelToBO(id, model);
                                await this.studioRepository.Update(this.dalStudioMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.studioModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.studioRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiAdminResponseModel>> Admins(int studioId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Admin> records = await this.studioRepository.Admins(studioId, limit, offset);

                        return this.bolAdminMapper.MapBOToModel(this.dalAdminMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiFamilyResponseModel>> Families(int id, int limit = int.MaxValue, int offset = 0)
                {
                        List<Family> records = await this.studioRepository.Families(id, limit, offset);

                        return this.bolFamilyMapper.MapBOToModel(this.dalFamilyMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiLessonResponseModel>> Lessons(int studioId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Lesson> records = await this.studioRepository.Lessons(studioId, limit, offset);

                        return this.bolLessonMapper.MapBOToModel(this.dalLessonMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiLessonStatusResponseModel>> LessonStatus(int id, int limit = int.MaxValue, int offset = 0)
                {
                        List<LessonStatus> records = await this.studioRepository.LessonStatus(id, limit, offset);

                        return this.bolLessonStatusMapper.MapBOToModel(this.dalLessonStatusMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiSpaceResponseModel>> Spaces(int studioId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Space> records = await this.studioRepository.Spaces(studioId, limit, offset);

                        return this.bolSpaceMapper.MapBOToModel(this.dalSpaceMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiSpaceFeatureResponseModel>> SpaceFeatures(int studioId, int limit = int.MaxValue, int offset = 0)
                {
                        List<SpaceFeature> records = await this.studioRepository.SpaceFeatures(studioId, limit, offset);

                        return this.bolSpaceFeatureMapper.MapBOToModel(this.dalSpaceFeatureMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiStudentResponseModel>> Students(int studioId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Student> records = await this.studioRepository.Students(studioId, limit, offset);

                        return this.bolStudentMapper.MapBOToModel(this.dalStudentMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiTeacherResponseModel>> Teachers(int studioId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Teacher> records = await this.studioRepository.Teachers(studioId, limit, offset);

                        return this.bolTeacherMapper.MapBOToModel(this.dalTeacherMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiTeacherSkillResponseModel>> TeacherSkills(int studioId, int limit = int.MaxValue, int offset = 0)
                {
                        List<TeacherSkill> records = await this.studioRepository.TeacherSkills(studioId, limit, offset);

                        return this.bolTeacherSkillMapper.MapBOToModel(this.dalTeacherSkillMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>480b1a6004023deadde95b06e1e37b9f</Hash>
</Codenesium>*/