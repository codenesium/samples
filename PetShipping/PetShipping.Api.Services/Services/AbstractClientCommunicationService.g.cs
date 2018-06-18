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
        public abstract class AbstractClientCommunicationService: AbstractService
        {
                private IClientCommunicationRepository clientCommunicationRepository;

                private IApiClientCommunicationRequestModelValidator clientCommunicationModelValidator;

                private IBOLClientCommunicationMapper bolClientCommunicationMapper;

                private IDALClientCommunicationMapper dalClientCommunicationMapper;

                private ILogger logger;

                public AbstractClientCommunicationService(
                        ILogger logger,
                        IClientCommunicationRepository clientCommunicationRepository,
                        IApiClientCommunicationRequestModelValidator clientCommunicationModelValidator,
                        IBOLClientCommunicationMapper bolClientCommunicationMapper,
                        IDALClientCommunicationMapper dalClientCommunicationMapper

                        )
                        : base()

                {
                        this.clientCommunicationRepository = clientCommunicationRepository;
                        this.clientCommunicationModelValidator = clientCommunicationModelValidator;
                        this.bolClientCommunicationMapper = bolClientCommunicationMapper;
                        this.dalClientCommunicationMapper = dalClientCommunicationMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiClientCommunicationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.clientCommunicationRepository.All(limit, offset);

                        return this.bolClientCommunicationMapper.MapBOToModel(this.dalClientCommunicationMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiClientCommunicationResponseModel> Get(int id)
                {
                        var record = await this.clientCommunicationRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolClientCommunicationMapper.MapBOToModel(this.dalClientCommunicationMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiClientCommunicationResponseModel>> Create(
                        ApiClientCommunicationRequestModel model)
                {
                        CreateResponse<ApiClientCommunicationResponseModel> response = new CreateResponse<ApiClientCommunicationResponseModel>(await this.clientCommunicationModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolClientCommunicationMapper.MapModelToBO(default (int), model);
                                var record = await this.clientCommunicationRepository.Create(this.dalClientCommunicationMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolClientCommunicationMapper.MapBOToModel(this.dalClientCommunicationMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiClientCommunicationRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.clientCommunicationModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolClientCommunicationMapper.MapModelToBO(id, model);
                                await this.clientCommunicationRepository.Update(this.dalClientCommunicationMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.clientCommunicationModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.clientCommunicationRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>16dadf55f973fac8c0ae903d96abb8b4</Hash>
</Codenesium>*/