using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractInvitationService: AbstractService
        {
                private IInvitationRepository invitationRepository;

                private IApiInvitationRequestModelValidator invitationModelValidator;

                private IBOLInvitationMapper bolInvitationMapper;

                private IDALInvitationMapper dalInvitationMapper;

                private ILogger logger;

                public AbstractInvitationService(
                        ILogger logger,
                        IInvitationRepository invitationRepository,
                        IApiInvitationRequestModelValidator invitationModelValidator,
                        IBOLInvitationMapper bolInvitationMapper,
                        IDALInvitationMapper dalInvitationMapper

                        )
                        : base()

                {
                        this.invitationRepository = invitationRepository;
                        this.invitationModelValidator = invitationModelValidator;
                        this.bolInvitationMapper = bolInvitationMapper;
                        this.dalInvitationMapper = dalInvitationMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiInvitationResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.invitationRepository.All(limit, offset, orderClause);

                        return this.bolInvitationMapper.MapBOToModel(this.dalInvitationMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiInvitationResponseModel> Get(string id)
                {
                        var record = await this.invitationRepository.Get(id);

                        return this.bolInvitationMapper.MapBOToModel(this.dalInvitationMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiInvitationResponseModel>> Create(
                        ApiInvitationRequestModel model)
                {
                        CreateResponse<ApiInvitationResponseModel> response = new CreateResponse<ApiInvitationResponseModel>(await this.invitationModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolInvitationMapper.MapModelToBO(default (string), model);
                                var record = await this.invitationRepository.Create(this.dalInvitationMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolInvitationMapper.MapBOToModel(this.dalInvitationMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiInvitationRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.invitationModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolInvitationMapper.MapModelToBO(id, model);
                                await this.invitationRepository.Update(this.dalInvitationMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.invitationModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.invitationRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>534db29c0c61cc1247d72264a058d105</Hash>
</Codenesium>*/