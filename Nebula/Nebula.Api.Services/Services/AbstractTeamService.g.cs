using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractTeamService : AbstractService
        {
                private ITeamRepository teamRepository;

                private IApiTeamRequestModelValidator teamModelValidator;

                private IBOLTeamMapper bolTeamMapper;

                private IDALTeamMapper dalTeamMapper;

                private IBOLChainMapper bolChainMapper;

                private IDALChainMapper dalChainMapper;
                private IBOLMachineRefTeamMapper bolMachineRefTeamMapper;

                private IDALMachineRefTeamMapper dalMachineRefTeamMapper;

                private ILogger logger;

                public AbstractTeamService(
                        ILogger logger,
                        ITeamRepository teamRepository,
                        IApiTeamRequestModelValidator teamModelValidator,
                        IBOLTeamMapper bolTeamMapper,
                        IDALTeamMapper dalTeamMapper,
                        IBOLChainMapper bolChainMapper,
                        IDALChainMapper dalChainMapper,
                        IBOLMachineRefTeamMapper bolMachineRefTeamMapper,
                        IDALMachineRefTeamMapper dalMachineRefTeamMapper)
                        : base()
                {
                        this.teamRepository = teamRepository;
                        this.teamModelValidator = teamModelValidator;
                        this.bolTeamMapper = bolTeamMapper;
                        this.dalTeamMapper = dalTeamMapper;
                        this.bolChainMapper = bolChainMapper;
                        this.dalChainMapper = dalChainMapper;
                        this.bolMachineRefTeamMapper = bolMachineRefTeamMapper;
                        this.dalMachineRefTeamMapper = dalMachineRefTeamMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTeamResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.teamRepository.All(limit, offset);

                        return this.bolTeamMapper.MapBOToModel(this.dalTeamMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTeamResponseModel> Get(int id)
                {
                        var record = await this.teamRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolTeamMapper.MapBOToModel(this.dalTeamMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiTeamResponseModel>> Create(
                        ApiTeamRequestModel model)
                {
                        CreateResponse<ApiTeamResponseModel> response = new CreateResponse<ApiTeamResponseModel>(await this.teamModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTeamMapper.MapModelToBO(default(int), model);
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

                public async virtual Task<List<ApiChainResponseModel>> Chains(int teamId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Chain> records = await this.teamRepository.Chains(teamId, limit, offset);

                        return this.bolChainMapper.MapBOToModel(this.dalChainMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiMachineRefTeamResponseModel>> MachineRefTeams(int teamId, int limit = int.MaxValue, int offset = 0)
                {
                        List<MachineRefTeam> records = await this.teamRepository.MachineRefTeams(teamId, limit, offset);

                        return this.bolMachineRefTeamMapper.MapBOToModel(this.dalMachineRefTeamMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>7e5c81df8e989f81717a7c1d832f8a3f</Hash>
</Codenesium>*/