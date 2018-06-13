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
        public abstract class AbstractTeacherSkillService: AbstractService
        {
                private ITeacherSkillRepository teacherSkillRepository;

                private IApiTeacherSkillRequestModelValidator teacherSkillModelValidator;

                private IBOLTeacherSkillMapper bolTeacherSkillMapper;

                private IDALTeacherSkillMapper dalTeacherSkillMapper;

                private IBOLRateMapper bolRateMapper;

                private IDALRateMapper dalRateMapper;
                private IBOLTeacherXTeacherSkillMapper bolTeacherXTeacherSkillMapper;

                private IDALTeacherXTeacherSkillMapper dalTeacherXTeacherSkillMapper;

                private ILogger logger;

                public AbstractTeacherSkillService(
                        ILogger logger,
                        ITeacherSkillRepository teacherSkillRepository,
                        IApiTeacherSkillRequestModelValidator teacherSkillModelValidator,
                        IBOLTeacherSkillMapper bolTeacherSkillMapper,
                        IDALTeacherSkillMapper dalTeacherSkillMapper

                        ,
                        IBOLRateMapper bolRateMapper,
                        IDALRateMapper dalRateMapper
                        ,
                        IBOLTeacherXTeacherSkillMapper bolTeacherXTeacherSkillMapper,
                        IDALTeacherXTeacherSkillMapper dalTeacherXTeacherSkillMapper

                        )
                        : base()

                {
                        this.teacherSkillRepository = teacherSkillRepository;
                        this.teacherSkillModelValidator = teacherSkillModelValidator;
                        this.bolTeacherSkillMapper = bolTeacherSkillMapper;
                        this.dalTeacherSkillMapper = dalTeacherSkillMapper;
                        this.bolRateMapper = bolRateMapper;
                        this.dalRateMapper = dalRateMapper;
                        this.bolTeacherXTeacherSkillMapper = bolTeacherXTeacherSkillMapper;
                        this.dalTeacherXTeacherSkillMapper = dalTeacherXTeacherSkillMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTeacherSkillResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.teacherSkillRepository.All(limit, offset, orderClause);

                        return this.bolTeacherSkillMapper.MapBOToModel(this.dalTeacherSkillMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTeacherSkillResponseModel> Get(int id)
                {
                        var record = await this.teacherSkillRepository.Get(id);

                        return this.bolTeacherSkillMapper.MapBOToModel(this.dalTeacherSkillMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiTeacherSkillResponseModel>> Create(
                        ApiTeacherSkillRequestModel model)
                {
                        CreateResponse<ApiTeacherSkillResponseModel> response = new CreateResponse<ApiTeacherSkillResponseModel>(await this.teacherSkillModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTeacherSkillMapper.MapModelToBO(default (int), model);
                                var record = await this.teacherSkillRepository.Create(this.dalTeacherSkillMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolTeacherSkillMapper.MapBOToModel(this.dalTeacherSkillMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiTeacherSkillRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.teacherSkillModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolTeacherSkillMapper.MapModelToBO(id, model);
                                await this.teacherSkillRepository.Update(this.dalTeacherSkillMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.teacherSkillModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.teacherSkillRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiRateResponseModel>> Rates(int teacherSkillId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Rate> records = await this.teacherSkillRepository.Rates(teacherSkillId, limit, offset);

                        return this.bolRateMapper.MapBOToModel(this.dalRateMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiTeacherXTeacherSkillResponseModel>> TeacherXTeacherSkills(int teacherSkillId, int limit = int.MaxValue, int offset = 0)
                {
                        List<TeacherXTeacherSkill> records = await this.teacherSkillRepository.TeacherXTeacherSkills(teacherSkillId, limit, offset);

                        return this.bolTeacherXTeacherSkillMapper.MapBOToModel(this.dalTeacherXTeacherSkillMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>46fe7f1bad91e81300e8ab0be67111de</Hash>
</Codenesium>*/