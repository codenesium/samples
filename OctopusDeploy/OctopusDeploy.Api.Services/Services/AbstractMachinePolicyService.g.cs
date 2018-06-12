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
        public abstract class AbstractMachinePolicyService: AbstractService
        {
                private IMachinePolicyRepository machinePolicyRepository;

                private IApiMachinePolicyRequestModelValidator machinePolicyModelValidator;

                private IBOLMachinePolicyMapper bolMachinePolicyMapper;

                private IDALMachinePolicyMapper dalMachinePolicyMapper;

                private ILogger logger;

                public AbstractMachinePolicyService(
                        ILogger logger,
                        IMachinePolicyRepository machinePolicyRepository,
                        IApiMachinePolicyRequestModelValidator machinePolicyModelValidator,
                        IBOLMachinePolicyMapper bolmachinePolicyMapper,
                        IDALMachinePolicyMapper dalmachinePolicyMapper)
                        : base()

                {
                        this.machinePolicyRepository = machinePolicyRepository;
                        this.machinePolicyModelValidator = machinePolicyModelValidator;
                        this.bolMachinePolicyMapper = bolmachinePolicyMapper;
                        this.dalMachinePolicyMapper = dalmachinePolicyMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiMachinePolicyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.machinePolicyRepository.All(skip, take, orderClause);

                        return this.bolMachinePolicyMapper.MapBOToModel(this.dalMachinePolicyMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiMachinePolicyResponseModel> Get(string id)
                {
                        var record = await this.machinePolicyRepository.Get(id);

                        return this.bolMachinePolicyMapper.MapBOToModel(this.dalMachinePolicyMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiMachinePolicyResponseModel>> Create(
                        ApiMachinePolicyRequestModel model)
                {
                        CreateResponse<ApiMachinePolicyResponseModel> response = new CreateResponse<ApiMachinePolicyResponseModel>(await this.machinePolicyModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolMachinePolicyMapper.MapModelToBO(default (string), model);
                                var record = await this.machinePolicyRepository.Create(this.dalMachinePolicyMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolMachinePolicyMapper.MapBOToModel(this.dalMachinePolicyMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiMachinePolicyRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.machinePolicyModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolMachinePolicyMapper.MapModelToBO(id, model);
                                await this.machinePolicyRepository.Update(this.dalMachinePolicyMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.machinePolicyModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.machinePolicyRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiMachinePolicyResponseModel> GetName(string name)
                {
                        MachinePolicy record = await this.machinePolicyRepository.GetName(name);

                        return this.bolMachinePolicyMapper.MapBOToModel(this.dalMachinePolicyMapper.MapEFToBO(record));
                }
        }
}

/*<Codenesium>
    <Hash>818576d1ea691b66df2c96410d675736</Hash>
</Codenesium>*/