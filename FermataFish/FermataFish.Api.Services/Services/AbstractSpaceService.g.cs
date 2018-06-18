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
        public abstract class AbstractSpaceService: AbstractService
        {
                private ISpaceRepository spaceRepository;

                private IApiSpaceRequestModelValidator spaceModelValidator;

                private IBOLSpaceMapper bolSpaceMapper;

                private IDALSpaceMapper dalSpaceMapper;

                private IBOLSpaceXSpaceFeatureMapper bolSpaceXSpaceFeatureMapper;

                private IDALSpaceXSpaceFeatureMapper dalSpaceXSpaceFeatureMapper;

                private ILogger logger;

                public AbstractSpaceService(
                        ILogger logger,
                        ISpaceRepository spaceRepository,
                        IApiSpaceRequestModelValidator spaceModelValidator,
                        IBOLSpaceMapper bolSpaceMapper,
                        IDALSpaceMapper dalSpaceMapper

                        ,
                        IBOLSpaceXSpaceFeatureMapper bolSpaceXSpaceFeatureMapper,
                        IDALSpaceXSpaceFeatureMapper dalSpaceXSpaceFeatureMapper

                        )
                        : base()

                {
                        this.spaceRepository = spaceRepository;
                        this.spaceModelValidator = spaceModelValidator;
                        this.bolSpaceMapper = bolSpaceMapper;
                        this.dalSpaceMapper = dalSpaceMapper;
                        this.bolSpaceXSpaceFeatureMapper = bolSpaceXSpaceFeatureMapper;
                        this.dalSpaceXSpaceFeatureMapper = dalSpaceXSpaceFeatureMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSpaceResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.spaceRepository.All(limit, offset);

                        return this.bolSpaceMapper.MapBOToModel(this.dalSpaceMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSpaceResponseModel> Get(int id)
                {
                        var record = await this.spaceRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSpaceMapper.MapBOToModel(this.dalSpaceMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiSpaceResponseModel>> Create(
                        ApiSpaceRequestModel model)
                {
                        CreateResponse<ApiSpaceResponseModel> response = new CreateResponse<ApiSpaceResponseModel>(await this.spaceModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSpaceMapper.MapModelToBO(default (int), model);
                                var record = await this.spaceRepository.Create(this.dalSpaceMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSpaceMapper.MapBOToModel(this.dalSpaceMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiSpaceRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.spaceModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolSpaceMapper.MapModelToBO(id, model);
                                await this.spaceRepository.Update(this.dalSpaceMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.spaceModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.spaceRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatures(int spaceId, int limit = int.MaxValue, int offset = 0)
                {
                        List<SpaceXSpaceFeature> records = await this.spaceRepository.SpaceXSpaceFeatures(spaceId, limit, offset);

                        return this.bolSpaceXSpaceFeatureMapper.MapBOToModel(this.dalSpaceXSpaceFeatureMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>53434cfd8ac2f8e2410fcf7ee9e18d92</Hash>
</Codenesium>*/