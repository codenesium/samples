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
        public abstract class AbstractPetService: AbstractService
        {
                private IPetRepository petRepository;

                private IApiPetRequestModelValidator petModelValidator;

                private IBOLPetMapper bolPetMapper;

                private IDALPetMapper dalPetMapper;

                private ILogger logger;

                public AbstractPetService(
                        ILogger logger,
                        IPetRepository petRepository,
                        IApiPetRequestModelValidator petModelValidator,
                        IBOLPetMapper bolpetMapper,
                        IDALPetMapper dalpetMapper)
                        : base()

                {
                        this.petRepository = petRepository;
                        this.petModelValidator = petModelValidator;
                        this.bolPetMapper = bolpetMapper;
                        this.dalPetMapper = dalpetMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPetResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.petRepository.All(skip, take, orderClause);

                        return this.bolPetMapper.MapBOToModel(this.dalPetMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPetResponseModel> Get(int id)
                {
                        var record = await this.petRepository.Get(id);

                        return this.bolPetMapper.MapBOToModel(this.dalPetMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiPetResponseModel>> Create(
                        ApiPetRequestModel model)
                {
                        CreateResponse<ApiPetResponseModel> response = new CreateResponse<ApiPetResponseModel>(await this.petModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPetMapper.MapModelToBO(default (int), model);
                                var record = await this.petRepository.Create(this.dalPetMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPetMapper.MapBOToModel(this.dalPetMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiPetRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.petModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolPetMapper.MapModelToBO(id, model);
                                await this.petRepository.Update(this.dalPetMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.petModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.petRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>209a08c6ec2081820a5ac92a2de8e659</Hash>
</Codenesium>*/