using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
        public abstract class AbstractPetService : AbstractService
        {
                private IPetRepository petRepository;

                private IApiPetRequestModelValidator petModelValidator;

                private IBOLPetMapper bolPetMapper;

                private IDALPetMapper dalPetMapper;

                private IBOLSaleMapper bolSaleMapper;

                private IDALSaleMapper dalSaleMapper;

                private ILogger logger;

                public AbstractPetService(
                        ILogger logger,
                        IPetRepository petRepository,
                        IApiPetRequestModelValidator petModelValidator,
                        IBOLPetMapper bolPetMapper,
                        IDALPetMapper dalPetMapper,
                        IBOLSaleMapper bolSaleMapper,
                        IDALSaleMapper dalSaleMapper)
                        : base()
                {
                        this.petRepository = petRepository;
                        this.petModelValidator = petModelValidator;
                        this.bolPetMapper = bolPetMapper;
                        this.dalPetMapper = dalPetMapper;
                        this.bolSaleMapper = bolSaleMapper;
                        this.dalSaleMapper = dalSaleMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPetResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.petRepository.All(limit, offset);

                        return this.bolPetMapper.MapBOToModel(this.dalPetMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPetResponseModel> Get(int id)
                {
                        var record = await this.petRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolPetMapper.MapBOToModel(this.dalPetMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiPetResponseModel>> Create(
                        ApiPetRequestModel model)
                {
                        CreateResponse<ApiPetResponseModel> response = new CreateResponse<ApiPetResponseModel>(await this.petModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPetMapper.MapModelToBO(default(int), model);
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

                public async virtual Task<List<ApiSaleResponseModel>> Sales(int petId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Sale> records = await this.petRepository.Sales(petId, limit, offset);

                        return this.bolSaleMapper.MapBOToModel(this.dalSaleMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>603330eff865e72618cae184abafbed8</Hash>
</Codenesium>*/