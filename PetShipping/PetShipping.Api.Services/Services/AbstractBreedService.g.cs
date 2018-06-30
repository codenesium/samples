using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBreedService : AbstractService
        {
                private IBreedRepository breedRepository;

                private IApiBreedRequestModelValidator breedModelValidator;

                private IBOLBreedMapper bolBreedMapper;

                private IDALBreedMapper dalBreedMapper;

                private IBOLPetMapper bolPetMapper;

                private IDALPetMapper dalPetMapper;

                private ILogger logger;

                public AbstractBreedService(
                        ILogger logger,
                        IBreedRepository breedRepository,
                        IApiBreedRequestModelValidator breedModelValidator,
                        IBOLBreedMapper bolBreedMapper,
                        IDALBreedMapper dalBreedMapper,
                        IBOLPetMapper bolPetMapper,
                        IDALPetMapper dalPetMapper)
                        : base()
                {
                        this.breedRepository = breedRepository;
                        this.breedModelValidator = breedModelValidator;
                        this.bolBreedMapper = bolBreedMapper;
                        this.dalBreedMapper = dalBreedMapper;
                        this.bolPetMapper = bolPetMapper;
                        this.dalPetMapper = dalPetMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiBreedResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.breedRepository.All(limit, offset);

                        return this.bolBreedMapper.MapBOToModel(this.dalBreedMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiBreedResponseModel> Get(int id)
                {
                        var record = await this.breedRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolBreedMapper.MapBOToModel(this.dalBreedMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiBreedResponseModel>> Create(
                        ApiBreedRequestModel model)
                {
                        CreateResponse<ApiBreedResponseModel> response = new CreateResponse<ApiBreedResponseModel>(await this.breedModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolBreedMapper.MapModelToBO(default(int), model);
                                var record = await this.breedRepository.Create(this.dalBreedMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolBreedMapper.MapBOToModel(this.dalBreedMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiBreedRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.breedModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolBreedMapper.MapModelToBO(id, model);
                                await this.breedRepository.Update(this.dalBreedMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.breedModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.breedRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiPetResponseModel>> Pets(int breedId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Pet> records = await this.breedRepository.Pets(breedId, limit, offset);

                        return this.bolPetMapper.MapBOToModel(this.dalPetMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>1962c4abec4c3cbacbe7fb11c7edcc89</Hash>
</Codenesium>*/