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
        public abstract class AbstractSpaceXSpaceFeatureService : AbstractService
        {
                private ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository;

                private IApiSpaceXSpaceFeatureRequestModelValidator spaceXSpaceFeatureModelValidator;

                private IBOLSpaceXSpaceFeatureMapper bolSpaceXSpaceFeatureMapper;

                private IDALSpaceXSpaceFeatureMapper dalSpaceXSpaceFeatureMapper;

                private ILogger logger;

                public AbstractSpaceXSpaceFeatureService(
                        ILogger logger,
                        ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository,
                        IApiSpaceXSpaceFeatureRequestModelValidator spaceXSpaceFeatureModelValidator,
                        IBOLSpaceXSpaceFeatureMapper bolSpaceXSpaceFeatureMapper,
                        IDALSpaceXSpaceFeatureMapper dalSpaceXSpaceFeatureMapper)
                        : base()
                {
                        this.spaceXSpaceFeatureRepository = spaceXSpaceFeatureRepository;
                        this.spaceXSpaceFeatureModelValidator = spaceXSpaceFeatureModelValidator;
                        this.bolSpaceXSpaceFeatureMapper = bolSpaceXSpaceFeatureMapper;
                        this.dalSpaceXSpaceFeatureMapper = dalSpaceXSpaceFeatureMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSpaceXSpaceFeatureResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.spaceXSpaceFeatureRepository.All(limit, offset);

                        return this.bolSpaceXSpaceFeatureMapper.MapBOToModel(this.dalSpaceXSpaceFeatureMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSpaceXSpaceFeatureResponseModel> Get(int id)
                {
                        var record = await this.spaceXSpaceFeatureRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSpaceXSpaceFeatureMapper.MapBOToModel(this.dalSpaceXSpaceFeatureMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiSpaceXSpaceFeatureResponseModel>> Create(
                        ApiSpaceXSpaceFeatureRequestModel model)
                {
                        CreateResponse<ApiSpaceXSpaceFeatureResponseModel> response = new CreateResponse<ApiSpaceXSpaceFeatureResponseModel>(await this.spaceXSpaceFeatureModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSpaceXSpaceFeatureMapper.MapModelToBO(default(int), model);
                                var record = await this.spaceXSpaceFeatureRepository.Create(this.dalSpaceXSpaceFeatureMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSpaceXSpaceFeatureMapper.MapBOToModel(this.dalSpaceXSpaceFeatureMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>> Update(
                        int id,
                        ApiSpaceXSpaceFeatureRequestModel model)
                {
                        var validationResult = await this.spaceXSpaceFeatureModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolSpaceXSpaceFeatureMapper.MapModelToBO(id, model);
                                await this.spaceXSpaceFeatureRepository.Update(this.dalSpaceXSpaceFeatureMapper.MapBOToEF(bo));

                                var record = await this.spaceXSpaceFeatureRepository.Get(id);

                                return new UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>(this.bolSpaceXSpaceFeatureMapper.MapBOToModel(this.dalSpaceXSpaceFeatureMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.spaceXSpaceFeatureModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.spaceXSpaceFeatureRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>63752ecedc1efe21d7651b4a046ab9cb</Hash>
</Codenesium>*/