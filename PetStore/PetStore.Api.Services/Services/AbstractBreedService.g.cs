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
        public abstract class AbstractBreedService: AbstractService
        {
                private IBreedRepository breedRepository;

                private IApiBreedRequestModelValidator breedModelValidator;

                private IBOLBreedMapper bolBreedMapper;

                private IDALBreedMapper dalBreedMapper;

                private ILogger logger;

                public AbstractBreedService(
                        ILogger logger,
                        IBreedRepository breedRepository,
                        IApiBreedRequestModelValidator breedModelValidator,
                        IBOLBreedMapper bolbreedMapper,
                        IDALBreedMapper dalbreedMapper)
                        : base()

                {
                        this.breedRepository = breedRepository;
                        this.breedModelValidator = breedModelValidator;
                        this.bolBreedMapper = bolbreedMapper;
                        this.dalBreedMapper = dalbreedMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiBreedResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.breedRepository.All(skip, take, orderClause);

                        return this.bolBreedMapper.MapBOToModel(this.dalBreedMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiBreedResponseModel> Get(int id)
                {
                        var record = await this.breedRepository.Get(id);

                        return this.bolBreedMapper.MapBOToModel(this.dalBreedMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiBreedResponseModel>> Create(
                        ApiBreedRequestModel model)
                {
                        CreateResponse<ApiBreedResponseModel> response = new CreateResponse<ApiBreedResponseModel>(await this.breedModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolBreedMapper.MapModelToBO(default (int), model);
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
        }
}

/*<Codenesium>
    <Hash>55185c323cef212ae6724aa23d21e689</Hash>
</Codenesium>*/