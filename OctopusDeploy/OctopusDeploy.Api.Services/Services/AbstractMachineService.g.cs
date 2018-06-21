using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractMachineService : AbstractService
        {
                private IMachineRepository machineRepository;

                private IApiMachineRequestModelValidator machineModelValidator;

                private IBOLMachineMapper bolMachineMapper;

                private IDALMachineMapper dalMachineMapper;

                private ILogger logger;

                public AbstractMachineService(
                        ILogger logger,
                        IMachineRepository machineRepository,
                        IApiMachineRequestModelValidator machineModelValidator,
                        IBOLMachineMapper bolMachineMapper,
                        IDALMachineMapper dalMachineMapper)
                        : base()
                {
                        this.machineRepository = machineRepository;
                        this.machineModelValidator = machineModelValidator;
                        this.bolMachineMapper = bolMachineMapper;
                        this.dalMachineMapper = dalMachineMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiMachineResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.machineRepository.All(limit, offset);

                        return this.bolMachineMapper.MapBOToModel(this.dalMachineMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiMachineResponseModel> Get(string id)
                {
                        var record = await this.machineRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolMachineMapper.MapBOToModel(this.dalMachineMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiMachineResponseModel>> Create(
                        ApiMachineRequestModel model)
                {
                        CreateResponse<ApiMachineResponseModel> response = new CreateResponse<ApiMachineResponseModel>(await this.machineModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolMachineMapper.MapModelToBO(default(string), model);
                                var record = await this.machineRepository.Create(this.dalMachineMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolMachineMapper.MapBOToModel(this.dalMachineMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
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
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.machineModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.machineRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiMachineResponseModel> GetName(string name)
                {
                        Machine record = await this.machineRepository.GetName(name);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolMachineMapper.MapBOToModel(this.dalMachineMapper.MapEFToBO(record));
                        }
                }

                public async Task<List<ApiMachineResponseModel>> GetMachinePolicyId(string machinePolicyId)
                {
                        List<Machine> records = await this.machineRepository.GetMachinePolicyId(machinePolicyId);

                        return this.bolMachineMapper.MapBOToModel(this.dalMachineMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>58f00e22564430e734006969280bded3</Hash>
</Codenesium>*/