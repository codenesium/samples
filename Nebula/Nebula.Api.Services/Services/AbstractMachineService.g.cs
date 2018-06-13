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
        public abstract class AbstractMachineService: AbstractService
        {
                private IMachineRepository machineRepository;

                private IApiMachineRequestModelValidator machineModelValidator;

                private IBOLMachineMapper bolMachineMapper;

                private IDALMachineMapper dalMachineMapper;

                private IBOLLinkMapper bolLinkMapper;

                private IDALLinkMapper dalLinkMapper;
                private IBOLMachineRefTeamMapper bolMachineRefTeamMapper;

                private IDALMachineRefTeamMapper dalMachineRefTeamMapper;

                private ILogger logger;

                public AbstractMachineService(
                        ILogger logger,
                        IMachineRepository machineRepository,
                        IApiMachineRequestModelValidator machineModelValidator,
                        IBOLMachineMapper bolMachineMapper,
                        IDALMachineMapper dalMachineMapper

                        ,
                        IBOLLinkMapper bolLinkMapper,
                        IDALLinkMapper dalLinkMapper
                        ,
                        IBOLMachineRefTeamMapper bolMachineRefTeamMapper,
                        IDALMachineRefTeamMapper dalMachineRefTeamMapper

                        )
                        : base()

                {
                        this.machineRepository = machineRepository;
                        this.machineModelValidator = machineModelValidator;
                        this.bolMachineMapper = bolMachineMapper;
                        this.dalMachineMapper = dalMachineMapper;
                        this.bolLinkMapper = bolLinkMapper;
                        this.dalLinkMapper = dalLinkMapper;
                        this.bolMachineRefTeamMapper = bolMachineRefTeamMapper;
                        this.dalMachineRefTeamMapper = dalMachineRefTeamMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiMachineResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.machineRepository.All(limit, offset, orderClause);

                        return this.bolMachineMapper.MapBOToModel(this.dalMachineMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiMachineResponseModel> Get(int id)
                {
                        var record = await this.machineRepository.Get(id);

                        return this.bolMachineMapper.MapBOToModel(this.dalMachineMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiMachineResponseModel>> Create(
                        ApiMachineRequestModel model)
                {
                        CreateResponse<ApiMachineResponseModel> response = new CreateResponse<ApiMachineResponseModel>(await this.machineModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolMachineMapper.MapModelToBO(default (int), model);
                                var record = await this.machineRepository.Create(this.dalMachineMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolMachineMapper.MapBOToModel(this.dalMachineMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiMachineRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.machineModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolMachineMapper.MapModelToBO(id, model);
                                await this.machineRepository.Update(this.dalMachineMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.machineModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.machineRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiLinkResponseModel>> Links(int assignedMachineId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Link> records = await this.machineRepository.Links(assignedMachineId, limit, offset);

                        return this.bolLinkMapper.MapBOToModel(this.dalLinkMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiMachineRefTeamResponseModel>> MachineRefTeams(int machineId, int limit = int.MaxValue, int offset = 0)
                {
                        List<MachineRefTeam> records = await this.machineRepository.MachineRefTeams(machineId, limit, offset);

                        return this.bolMachineRefTeamMapper.MapBOToModel(this.dalMachineRefTeamMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>2ed48271d34e827d7a19b337d36add7b</Hash>
</Codenesium>*/