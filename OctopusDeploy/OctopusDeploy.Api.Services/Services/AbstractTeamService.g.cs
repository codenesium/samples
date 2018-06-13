using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractTeamService: AbstractService
        {
                private ITeamRepository teamRepository;

                private IApiTeamRequestModelValidator teamModelValidator;

                private IBOLTeamMapper bolTeamMapper;

                private IDALTeamMapper dalTeamMapper;

                private ILogger logger;

                public AbstractTeamService(
                        ILogger logger,
                        ITeamRepository teamRepository,
                        IApiTeamRequestModelValidator teamModelValidator,
                        IBOLTeamMapper bolTeamMapper,
                        IDALTeamMapper dalTeamMapper

                        )
                        : base()

                {
                        this.teamRepository = teamRepository;
                        this.teamModelValidator = teamModelValidator;
                        this.bolTeamMapper = bolTeamMapper;
                        this.dalTeamMapper = dalTeamMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTeamResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.teamRepository.All(limit, offset, orderClause);

                        return this.bolTeamMapper.MapBOToModel(this.dalTeamMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTeamResponseModel> Get(string id)
                {
                        var record = await this.teamRepository.Get(id);

                        return this.bolTeamMapper.MapBOToModel(this.dalTeamMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiTeamResponseModel>> Create(
                        ApiTeamRequestModel model)
                {
                        CreateResponse<ApiTeamResponseModel> response = new CreateResponse<ApiTeamResponseModel>(await this.teamModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTeamMapper.MapModelToBO(default (string), model);
                                var record = await this.teamRepository.Create(this.dalTeamMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolTeamMapper.MapBOToModel(this.dalTeamMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiTeamRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.teamModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolTeamMapper.MapModelToBO(id, model);
                                await this.teamRepository.Update(this.dalTeamMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.teamModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.teamRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiTeamResponseModel> GetName(string name)
                {
                        Team record = await this.teamRepository.GetName(name);

                        return this.bolTeamMapper.MapBOToModel(this.dalTeamMapper.MapEFToBO(record));
                }
        }
}

/*<Codenesium>
    <Hash>a6b4082b07edea22310b9f0f226e7ba0</Hash>
</Codenesium>*/