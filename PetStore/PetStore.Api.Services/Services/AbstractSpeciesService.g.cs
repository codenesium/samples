using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public abstract class AbstractSpeciesService: AbstractService
        {
                private ISpeciesRepository speciesRepository;

                private IApiSpeciesRequestModelValidator speciesModelValidator;

                private IBOLSpeciesMapper bolSpeciesMapper;

                private IDALSpeciesMapper dalSpeciesMapper;

                private ILogger logger;

                public AbstractSpeciesService(
                        ILogger logger,
                        ISpeciesRepository speciesRepository,
                        IApiSpeciesRequestModelValidator speciesModelValidator,
                        IBOLSpeciesMapper bolspeciesMapper,
                        IDALSpeciesMapper dalspeciesMapper)
                        : base()

                {
                        this.speciesRepository = speciesRepository;
                        this.speciesModelValidator = speciesModelValidator;
                        this.bolSpeciesMapper = bolspeciesMapper;
                        this.dalSpeciesMapper = dalspeciesMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSpeciesResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.speciesRepository.All(skip, take, orderClause);

                        return this.bolSpeciesMapper.MapBOToModel(this.dalSpeciesMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSpeciesResponseModel> Get(int id)
                {
                        var record = await this.speciesRepository.Get(id);

                        return this.bolSpeciesMapper.MapBOToModel(this.dalSpeciesMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiSpeciesResponseModel>> Create(
                        ApiSpeciesRequestModel model)
                {
                        CreateResponse<ApiSpeciesResponseModel> response = new CreateResponse<ApiSpeciesResponseModel>(await this.speciesModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSpeciesMapper.MapModelToBO(default (int), model);
                                var record = await this.speciesRepository.Create(this.dalSpeciesMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSpeciesMapper.MapBOToModel(this.dalSpeciesMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiSpeciesRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.speciesModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolSpeciesMapper.MapModelToBO(id, model);
                                await this.speciesRepository.Update(this.dalSpeciesMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.speciesModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.speciesRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>9f0dc618d9e5645c763a84c5947edd45</Hash>
</Codenesium>*/