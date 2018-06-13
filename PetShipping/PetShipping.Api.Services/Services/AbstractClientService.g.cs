using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractClientService: AbstractService
        {
                private IClientRepository clientRepository;

                private IApiClientRequestModelValidator clientModelValidator;

                private IBOLClientMapper bolClientMapper;

                private IDALClientMapper dalClientMapper;

                private IBOLClientCommunicationMapper bolClientCommunicationMapper;

                private IDALClientCommunicationMapper dalClientCommunicationMapper;
                private IBOLPetMapper bolPetMapper;

                private IDALPetMapper dalPetMapper;
                private IBOLSaleMapper bolSaleMapper;

                private IDALSaleMapper dalSaleMapper;

                private ILogger logger;

                public AbstractClientService(
                        ILogger logger,
                        IClientRepository clientRepository,
                        IApiClientRequestModelValidator clientModelValidator,
                        IBOLClientMapper bolClientMapper,
                        IDALClientMapper dalClientMapper

                        ,
                        IBOLClientCommunicationMapper bolClientCommunicationMapper,
                        IDALClientCommunicationMapper dalClientCommunicationMapper
                        ,
                        IBOLPetMapper bolPetMapper,
                        IDALPetMapper dalPetMapper
                        ,
                        IBOLSaleMapper bolSaleMapper,
                        IDALSaleMapper dalSaleMapper

                        )
                        : base()

                {
                        this.clientRepository = clientRepository;
                        this.clientModelValidator = clientModelValidator;
                        this.bolClientMapper = bolClientMapper;
                        this.dalClientMapper = dalClientMapper;
                        this.bolClientCommunicationMapper = bolClientCommunicationMapper;
                        this.dalClientCommunicationMapper = dalClientCommunicationMapper;
                        this.bolPetMapper = bolPetMapper;
                        this.dalPetMapper = dalPetMapper;
                        this.bolSaleMapper = bolSaleMapper;
                        this.dalSaleMapper = dalSaleMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiClientResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.clientRepository.All(limit, offset, orderClause);

                        return this.bolClientMapper.MapBOToModel(this.dalClientMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiClientResponseModel> Get(int id)
                {
                        var record = await this.clientRepository.Get(id);

                        return this.bolClientMapper.MapBOToModel(this.dalClientMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiClientResponseModel>> Create(
                        ApiClientRequestModel model)
                {
                        CreateResponse<ApiClientResponseModel> response = new CreateResponse<ApiClientResponseModel>(await this.clientModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolClientMapper.MapModelToBO(default (int), model);
                                var record = await this.clientRepository.Create(this.dalClientMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolClientMapper.MapBOToModel(this.dalClientMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiClientRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.clientModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolClientMapper.MapModelToBO(id, model);
                                await this.clientRepository.Update(this.dalClientMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.clientModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.clientRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiClientCommunicationResponseModel>> ClientCommunications(int clientId, int limit = int.MaxValue, int offset = 0)
                {
                        List<ClientCommunication> records = await this.clientRepository.ClientCommunications(clientId, limit, offset);

                        return this.bolClientCommunicationMapper.MapBOToModel(this.dalClientCommunicationMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiPetResponseModel>> Pets(int clientId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Pet> records = await this.clientRepository.Pets(clientId, limit, offset);

                        return this.bolPetMapper.MapBOToModel(this.dalPetMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiSaleResponseModel>> Sales(int clientId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Sale> records = await this.clientRepository.Sales(clientId, limit, offset);

                        return this.bolSaleMapper.MapBOToModel(this.dalSaleMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>31dcf9dfb72e0608ea0051fa9d2e6815</Hash>
</Codenesium>*/