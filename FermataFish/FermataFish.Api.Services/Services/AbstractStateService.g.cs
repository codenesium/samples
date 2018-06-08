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
        public abstract class AbstractStateService: AbstractService
        {
                private IStateRepository stateRepository;

                private IApiStateRequestModelValidator stateModelValidator;

                private IBOLStateMapper bolStateMapper;

                private IDALStateMapper dalStateMapper;

                private ILogger logger;

                public AbstractStateService(
                        ILogger logger,
                        IStateRepository stateRepository,
                        IApiStateRequestModelValidator stateModelValidator,
                        IBOLStateMapper bolstateMapper,
                        IDALStateMapper dalstateMapper)
                        : base()

                {
                        this.stateRepository = stateRepository;
                        this.stateModelValidator = stateModelValidator;
                        this.bolStateMapper = bolstateMapper;
                        this.dalStateMapper = dalstateMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiStateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.stateRepository.All(skip, take, orderClause);

                        return this.bolStateMapper.MapBOToModel(this.dalStateMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiStateResponseModel> Get(int id)
                {
                        var record = await this.stateRepository.Get(id);

                        return this.bolStateMapper.MapBOToModel(this.dalStateMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiStateResponseModel>> Create(
                        ApiStateRequestModel model)
                {
                        CreateResponse<ApiStateResponseModel> response = new CreateResponse<ApiStateResponseModel>(await this.stateModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolStateMapper.MapModelToBO(default (int), model);
                                var record = await this.stateRepository.Create(this.dalStateMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolStateMapper.MapBOToModel(this.dalStateMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiStateRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.stateModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolStateMapper.MapModelToBO(id, model);
                                await this.stateRepository.Update(this.dalStateMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.stateModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.stateRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>ff1306d367d238824217e519b1a1b357</Hash>
</Codenesium>*/