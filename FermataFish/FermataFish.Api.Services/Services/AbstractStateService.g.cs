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

                private IBOLStudioMapper bolStudioMapper;

                private IDALStudioMapper dalStudioMapper;

                private ILogger logger;

                public AbstractStateService(
                        ILogger logger,
                        IStateRepository stateRepository,
                        IApiStateRequestModelValidator stateModelValidator,
                        IBOLStateMapper bolStateMapper,
                        IDALStateMapper dalStateMapper

                        ,
                        IBOLStudioMapper bolStudioMapper,
                        IDALStudioMapper dalStudioMapper

                        )
                        : base()

                {
                        this.stateRepository = stateRepository;
                        this.stateModelValidator = stateModelValidator;
                        this.bolStateMapper = bolStateMapper;
                        this.dalStateMapper = dalStateMapper;
                        this.bolStudioMapper = bolStudioMapper;
                        this.dalStudioMapper = dalStudioMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiStateResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.stateRepository.All(limit, offset);

                        return this.bolStateMapper.MapBOToModel(this.dalStateMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiStateResponseModel> Get(int id)
                {
                        var record = await this.stateRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolStateMapper.MapBOToModel(this.dalStateMapper.MapEFToBO(record));
                        }
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

                public async virtual Task<List<ApiStudioResponseModel>> Studios(int stateId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Studio> records = await this.stateRepository.Studios(stateId, limit, offset);

                        return this.bolStudioMapper.MapBOToModel(this.dalStudioMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>d57291519c705d7248aac951f1291c8c</Hash>
</Codenesium>*/