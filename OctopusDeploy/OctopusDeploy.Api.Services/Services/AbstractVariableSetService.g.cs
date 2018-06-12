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
        public abstract class AbstractVariableSetService: AbstractService
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
                        IBOLVariableSetMapper bolvariableSetMapper,
                        IDALVariableSetMapper dalvariableSetMapper)
                        : base()

                {
                        this.variableSetRepository = variableSetRepository;
                        this.variableSetModelValidator = variableSetModelValidator;
                        this.bolVariableSetMapper = bolvariableSetMapper;
                        this.dalVariableSetMapper = dalvariableSetMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiVariableSetResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.variableSetRepository.All(skip, take, orderClause);

                        return this.bolVariableSetMapper.MapBOToModel(this.dalVariableSetMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiVariableSetResponseModel> Get(string id)
                {
                        var record = await this.variableSetRepository.Get(id);

                        return this.bolVariableSetMapper.MapBOToModel(this.dalVariableSetMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiVariableSetResponseModel>> Create(
                        ApiVariableSetRequestModel model)
                {
                        CreateResponse<ApiVariableSetResponseModel> response = new CreateResponse<ApiVariableSetResponseModel>(await this.variableSetModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolVariableSetMapper.MapModelToBO(default (string), model);
                                var record = await this.variableSetRepository.Create(this.dalVariableSetMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolVariableSetMapper.MapBOToModel(this.dalVariableSetMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiVariableSetRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.variableSetModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolVariableSetMapper.MapModelToBO(id, model);
                                await this.variableSetRepository.Update(this.dalVariableSetMapper.MapBOToEF(bo));
                        }

                        return response;
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
    <Hash>4716b28a41f5f79e3cb32cb18f3fde55</Hash>
</Codenesium>*/