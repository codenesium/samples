using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractSpaceFeatureService : AbstractService
        {
                private ISpaceFeatureRepository spaceFeatureRepository;

                private IApiSpaceFeatureRequestModelValidator spaceFeatureModelValidator;

                private IBOLSpaceFeatureMapper bolSpaceFeatureMapper;

                private IDALSpaceFeatureMapper dalSpaceFeatureMapper;

                private IBOLSpaceXSpaceFeatureMapper bolSpaceXSpaceFeatureMapper;

                private IDALSpaceXSpaceFeatureMapper dalSpaceXSpaceFeatureMapper;

                private ILogger logger;

                public AbstractSpaceFeatureService(
                        ILogger logger,
                        ISpaceFeatureRepository spaceFeatureRepository,
                        IApiSpaceFeatureRequestModelValidator spaceFeatureModelValidator,
                        IBOLSpaceFeatureMapper bolSpaceFeatureMapper,
                        IDALSpaceFeatureMapper dalSpaceFeatureMapper,
                        IBOLSpaceXSpaceFeatureMapper bolSpaceXSpaceFeatureMapper,
                        IDALSpaceXSpaceFeatureMapper dalSpaceXSpaceFeatureMapper)
                        : base()
                {
                        this.spaceFeatureRepository = spaceFeatureRepository;
                        this.spaceFeatureModelValidator = spaceFeatureModelValidator;
                        this.bolSpaceFeatureMapper = bolSpaceFeatureMapper;
                        this.dalSpaceFeatureMapper = dalSpaceFeatureMapper;
                        this.bolSpaceXSpaceFeatureMapper = bolSpaceXSpaceFeatureMapper;
                        this.dalSpaceXSpaceFeatureMapper = dalSpaceXSpaceFeatureMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSpaceFeatureResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.spaceFeatureRepository.All(limit, offset);

                        return this.bolSpaceFeatureMapper.MapBOToModel(this.dalSpaceFeatureMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSpaceFeatureResponseModel> Get(int id)
                {
                        var record = await this.spaceFeatureRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSpaceFeatureMapper.MapBOToModel(this.dalSpaceFeatureMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiSpaceFeatureResponseModel>> Create(
                        ApiSpaceFeatureRequestModel model)
                {
                        CreateResponse<ApiSpaceFeatureResponseModel> response = new CreateResponse<ApiSpaceFeatureResponseModel>(await this.spaceFeatureModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSpaceFeatureMapper.MapModelToBO(default(int), model);
                                var record = await this.spaceFeatureRepository.Create(this.dalSpaceFeatureMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSpaceFeatureMapper.MapBOToModel(this.dalSpaceFeatureMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiSpaceFeatureResponseModel>> Update(
                        int id,
                        ApiSpaceFeatureRequestModel model)
                {
                        var validationResult = await this.spaceFeatureModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolSpaceFeatureMapper.MapModelToBO(id, model);
                                await this.spaceFeatureRepository.Update(this.dalSpaceFeatureMapper.MapBOToEF(bo));

                                var record = await this.spaceFeatureRepository.Get(id);

                                return new UpdateResponse<ApiSpaceFeatureResponseModel>(this.bolSpaceFeatureMapper.MapBOToModel(this.dalSpaceFeatureMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiSpaceFeatureResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.spaceFeatureModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.spaceFeatureRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatures(int spaceFeatureId, int limit = int.MaxValue, int offset = 0)
                {
                        List<SpaceXSpaceFeature> records = await this.spaceFeatureRepository.SpaceXSpaceFeatures(spaceFeatureId, limit, offset);

                        return this.bolSpaceXSpaceFeatureMapper.MapBOToModel(this.dalSpaceXSpaceFeatureMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>84daefda6940d866cd5efe8e7196faad</Hash>
</Codenesium>*/