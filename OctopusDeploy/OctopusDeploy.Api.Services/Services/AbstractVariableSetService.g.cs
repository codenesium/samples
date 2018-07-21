using Codenesium.DataConversionExtensions;
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
        public abstract class AbstractVariableSetService : AbstractService
        {
                private IVariableSetRepository variableSetRepository;

                private IApiVariableSetRequestModelValidator variableSetModelValidator;

                private IBOLVariableSetMapper bolVariableSetMapper;

                private IDALVariableSetMapper dalVariableSetMapper;

                private ILogger logger;

                public AbstractVariableSetService(
                        ILogger logger,
                        IVariableSetRepository variableSetRepository,
                        IApiVariableSetRequestModelValidator variableSetModelValidator,
                        IBOLVariableSetMapper bolVariableSetMapper,
                        IDALVariableSetMapper dalVariableSetMapper)
                        : base()
                {
                        this.variableSetRepository = variableSetRepository;
                        this.variableSetModelValidator = variableSetModelValidator;
                        this.bolVariableSetMapper = bolVariableSetMapper;
                        this.dalVariableSetMapper = dalVariableSetMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiVariableSetResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.variableSetRepository.All(limit, offset);

                        return this.bolVariableSetMapper.MapBOToModel(this.dalVariableSetMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiVariableSetResponseModel> Get(string id)
                {
                        var record = await this.variableSetRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolVariableSetMapper.MapBOToModel(this.dalVariableSetMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiVariableSetResponseModel>> Create(
                        ApiVariableSetRequestModel model)
                {
                        CreateResponse<ApiVariableSetResponseModel> response = new CreateResponse<ApiVariableSetResponseModel>(await this.variableSetModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolVariableSetMapper.MapModelToBO(default(string), model);
                                var record = await this.variableSetRepository.Create(this.dalVariableSetMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolVariableSetMapper.MapBOToModel(this.dalVariableSetMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiVariableSetResponseModel>> Update(
                        string id,
                        ApiVariableSetRequestModel model)
                {
                        var validationResult = await this.variableSetModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolVariableSetMapper.MapModelToBO(id, model);
                                await this.variableSetRepository.Update(this.dalVariableSetMapper.MapBOToEF(bo));

                                var record = await this.variableSetRepository.Get(id);

                                return new UpdateResponse<ApiVariableSetResponseModel>(this.bolVariableSetMapper.MapBOToModel(this.dalVariableSetMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiVariableSetResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.variableSetModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.variableSetRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>1794839ac6e6a5cc7ed3645035c3346d</Hash>
</Codenesium>*/