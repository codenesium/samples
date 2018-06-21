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
        public abstract class AbstractTeacherService : AbstractService
        {
                private ITeacherRepository teacherRepository;

                private IApiTeacherRequestModelValidator teacherModelValidator;

                private IBOLTeacherMapper bolTeacherMapper;

                private IDALTeacherMapper dalTeacherMapper;

                private IBOLRateMapper bolRateMapper;

                private IDALRateMapper dalRateMapper;
                private IBOLTeacherXTeacherSkillMapper bolTeacherXTeacherSkillMapper;

                private IDALTeacherXTeacherSkillMapper dalTeacherXTeacherSkillMapper;

                private ILogger logger;

                public AbstractTeacherService(
                        ILogger logger,
                        ITeacherRepository teacherRepository,
                        IApiTeacherRequestModelValidator teacherModelValidator,
                        IBOLTeacherMapper bolTeacherMapper,
                        IDALTeacherMapper dalTeacherMapper,
                        IBOLRateMapper bolRateMapper,
                        IDALRateMapper dalRateMapper,
                        IBOLTeacherXTeacherSkillMapper bolTeacherXTeacherSkillMapper,
                        IDALTeacherXTeacherSkillMapper dalTeacherXTeacherSkillMapper)
                        : base()
                {
                        this.teacherRepository = teacherRepository;
                        this.teacherModelValidator = teacherModelValidator;
                        this.bolTeacherMapper = bolTeacherMapper;
                        this.dalTeacherMapper = dalTeacherMapper;
                        this.bolRateMapper = bolRateMapper;
                        this.dalRateMapper = dalRateMapper;
                        this.bolTeacherXTeacherSkillMapper = bolTeacherXTeacherSkillMapper;
                        this.dalTeacherXTeacherSkillMapper = dalTeacherXTeacherSkillMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTeacherResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.teacherRepository.All(limit, offset);

                        return this.bolTeacherMapper.MapBOToModel(this.dalTeacherMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTeacherResponseModel> Get(int id)
                {
                        var record = await this.teacherRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolTeacherMapper.MapBOToModel(this.dalTeacherMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiTeacherResponseModel>> Create(
                        ApiTeacherRequestModel model)
                {
                        CreateResponse<ApiTeacherResponseModel> response = new CreateResponse<ApiTeacherResponseModel>(await this.teacherModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTeacherMapper.MapModelToBO(default(int), model);
                                var record = await this.teacherRepository.Create(this.dalTeacherMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolTeacherMapper.MapBOToModel(this.dalTeacherMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiTeacherRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.teacherModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolTeacherMapper.MapModelToBO(id, model);
                                await this.teacherRepository.Update(this.dalTeacherMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.teacherModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.teacherRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiRateResponseModel>> Rates(int teacherId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Rate> records = await this.teacherRepository.Rates(teacherId, limit, offset);

                        return this.bolRateMapper.MapBOToModel(this.dalRateMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiTeacherXTeacherSkillResponseModel>> TeacherXTeacherSkills(int teacherId, int limit = int.MaxValue, int offset = 0)
                {
                        List<TeacherXTeacherSkill> records = await this.teacherRepository.TeacherXTeacherSkills(teacherId, limit, offset);

                        return this.bolTeacherXTeacherSkillMapper.MapBOToModel(this.dalTeacherXTeacherSkillMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>9d01887900ac4e24bb888f2235ea9f3e</Hash>
</Codenesium>*/