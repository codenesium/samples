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
        public abstract class AbstractTeacherXTeacherSkillService : AbstractService
        {
                private ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository;

                private IApiTeacherXTeacherSkillRequestModelValidator teacherXTeacherSkillModelValidator;

                private IBOLTeacherXTeacherSkillMapper bolTeacherXTeacherSkillMapper;

                private IDALTeacherXTeacherSkillMapper dalTeacherXTeacherSkillMapper;

                private ILogger logger;

                public AbstractTeacherXTeacherSkillService(
                        ILogger logger,
                        ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository,
                        IApiTeacherXTeacherSkillRequestModelValidator teacherXTeacherSkillModelValidator,
                        IBOLTeacherXTeacherSkillMapper bolTeacherXTeacherSkillMapper,
                        IDALTeacherXTeacherSkillMapper dalTeacherXTeacherSkillMapper)
                        : base()
                {
                        this.teacherXTeacherSkillRepository = teacherXTeacherSkillRepository;
                        this.teacherXTeacherSkillModelValidator = teacherXTeacherSkillModelValidator;
                        this.bolTeacherXTeacherSkillMapper = bolTeacherXTeacherSkillMapper;
                        this.dalTeacherXTeacherSkillMapper = dalTeacherXTeacherSkillMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTeacherXTeacherSkillResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.teacherXTeacherSkillRepository.All(limit, offset);

                        return this.bolTeacherXTeacherSkillMapper.MapBOToModel(this.dalTeacherXTeacherSkillMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTeacherXTeacherSkillResponseModel> Get(int id)
                {
                        var record = await this.teacherXTeacherSkillRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolTeacherXTeacherSkillMapper.MapBOToModel(this.dalTeacherXTeacherSkillMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiTeacherXTeacherSkillResponseModel>> Create(
                        ApiTeacherXTeacherSkillRequestModel model)
                {
                        CreateResponse<ApiTeacherXTeacherSkillResponseModel> response = new CreateResponse<ApiTeacherXTeacherSkillResponseModel>(await this.teacherXTeacherSkillModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTeacherXTeacherSkillMapper.MapModelToBO(default(int), model);
                                var record = await this.teacherXTeacherSkillRepository.Create(this.dalTeacherXTeacherSkillMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolTeacherXTeacherSkillMapper.MapBOToModel(this.dalTeacherXTeacherSkillMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiTeacherXTeacherSkillRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.teacherXTeacherSkillModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolTeacherXTeacherSkillMapper.MapModelToBO(id, model);
                                await this.teacherXTeacherSkillRepository.Update(this.dalTeacherXTeacherSkillMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.teacherXTeacherSkillModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.teacherXTeacherSkillRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a3220c14a15b810fe02a3629be7beae8</Hash>
</Codenesium>*/