using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
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
                        IBOLTeamMapper bolteamMapper,
                        IDALTeamMapper dalteamMapper)
                        : base()

                {
                        this.teamRepository = teamRepository;
                        this.teamModelValidator = teamModelValidator;
                        this.bolTeamMapper = bolteamMapper;
                        this.dalTeamMapper = dalteamMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTeamResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.teamRepository.All(skip, take, orderClause);

                        return this.bolTeamMapper.MapBOToModel(this.dalTeamMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTeamResponseModel> Get(int id)
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
                                var bo = this.bolTeamMapper.MapModelToBO(default (int), model);
                                var record = await this.teamRepository.Create(this.dalTeamMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolTeamMapper.MapBOToModel(this.dalTeamMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
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
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.teamModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.teamRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>b1fdbe210c44a22b457c80b87c38df0f</Hash>
</Codenesium>*/