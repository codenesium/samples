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
        public abstract class AbstractSpaceXSpaceFeatureService: AbstractService
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
                        IDALSpaceXSpaceFeatureMapper dalSpaceXSpaceFeatureMapper

                        )
                        : base()

                {
                        this.spaceXSpaceFeatureRepository = spaceXSpaceFeatureRepository;
                        this.spaceXSpaceFeatureModelValidator = spaceXSpaceFeatureModelValidator;
                        this.bolSpaceXSpaceFeatureMapper = bolSpaceXSpaceFeatureMapper;
                        this.dalSpaceXSpaceFeatureMapper = dalSpaceXSpaceFeatureMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSpaceXSpaceFeatureResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.spaceXSpaceFeatureRepository.All(limit, offset, orderClause);

                        return this.bolSpaceXSpaceFeatureMapper.MapBOToModel(this.dalSpaceXSpaceFeatureMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSpaceXSpaceFeatureResponseModel> Get(int id)
                {
                        var record = await this.spaceXSpaceFeatureRepository.Get(id);

                        return this.bolSpaceXSpaceFeatureMapper.MapBOToModel(this.dalSpaceXSpaceFeatureMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiSpaceXSpaceFeatureResponseModel>> Create(
                        ApiSpaceXSpaceFeatureRequestModel model)
                {
                        CreateResponse<ApiSpaceXSpaceFeatureResponseModel> response = new CreateResponse<ApiSpaceXSpaceFeatureResponseModel>(await this.spaceXSpaceFeatureModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSpaceXSpaceFeatureMapper.MapModelToBO(default (int), model);
                                var record = await this.spaceXSpaceFeatureRepository.Create(this.dalSpaceXSpaceFeatureMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSpaceXSpaceFeatureMapper.MapBOToModel(this.dalSpaceXSpaceFeatureMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiSpaceXSpaceFeatureRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.spaceXSpaceFeatureModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolSpaceXSpaceFeatureMapper.MapModelToBO(id, model);
                                await this.spaceXSpaceFeatureRepository.Update(this.dalSpaceXSpaceFeatureMapper.MapBOToEF(bo));
                        }

                        return response;
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
    <Hash>f92260227afc9fa9e35d183ab022965e</Hash>
</Codenesium>*/