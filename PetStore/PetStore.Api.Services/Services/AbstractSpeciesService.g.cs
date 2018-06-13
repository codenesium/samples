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

                private IBOLPetMapper bolPetMapper;

                private IDALPetMapper dalPetMapper;

                private ILogger logger;

                public AbstractSpeciesService(
                        ILogger logger,
                        ISpeciesRepository speciesRepository,
                        IApiSpeciesRequestModelValidator speciesModelValidator,
                        IBOLSpeciesMapper bolSpeciesMapper,
                        IDALSpeciesMapper dalSpeciesMapper

                        ,
                        IBOLPetMapper bolPetMapper,
                        IDALPetMapper dalPetMapper

                        )
                        : base()

                {
                        this.speciesRepository = speciesRepository;
                        this.speciesModelValidator = speciesModelValidator;
                        this.bolSpeciesMapper = bolSpeciesMapper;
                        this.dalSpeciesMapper = dalSpeciesMapper;
                        this.bolPetMapper = bolPetMapper;
                        this.dalPetMapper = dalPetMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSpeciesResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.speciesRepository.All(limit, offset, orderClause);

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

                public async virtual Task<List<ApiPetResponseModel>> Pets(int speciesId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Pet> records = await this.speciesRepository.Pets(speciesId, limit, offset);

                        return this.bolPetMapper.MapBOToModel(this.dalPetMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>c323995c04ce033212c6fcf80ab8c06b</Hash>
</Codenesium>*/