using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractOrganizationService: AbstractService
        {
                private IOrganizationRepository organizationRepository;

                private IApiOrganizationRequestModelValidator organizationModelValidator;

                private IBOLOrganizationMapper bolOrganizationMapper;

                private IDALOrganizationMapper dalOrganizationMapper;

                private ILogger logger;

                public AbstractOrganizationService(
                        ILogger logger,
                        IOrganizationRepository organizationRepository,
                        IApiOrganizationRequestModelValidator organizationModelValidator,
                        IBOLOrganizationMapper bolorganizationMapper,
                        IDALOrganizationMapper dalorganizationMapper)
                        : base()

                {
                        this.organizationRepository = organizationRepository;
                        this.organizationModelValidator = organizationModelValidator;
                        this.bolOrganizationMapper = bolorganizationMapper;
                        this.dalOrganizationMapper = dalorganizationMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiOrganizationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.organizationRepository.All(skip, take, orderClause);

                        return this.bolOrganizationMapper.MapBOToModel(this.dalOrganizationMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiOrganizationResponseModel> Get(int id)
                {
                        var record = await this.organizationRepository.Get(id);

                        return this.bolOrganizationMapper.MapBOToModel(this.dalOrganizationMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiOrganizationResponseModel>> Create(
                        ApiOrganizationRequestModel model)
                {
                        CreateResponse<ApiOrganizationResponseModel> response = new CreateResponse<ApiOrganizationResponseModel>(await this.organizationModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolOrganizationMapper.MapModelToBO(default (int), model);
                                var record = await this.organizationRepository.Create(this.dalOrganizationMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolOrganizationMapper.MapBOToModel(this.dalOrganizationMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiOrganizationRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.organizationModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolOrganizationMapper.MapModelToBO(id, model);
                                await this.organizationRepository.Update(this.dalOrganizationMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.organizationModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.organizationRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>4da9e92a8b30bcd38ef52fdcdaa8737a</Hash>
</Codenesium>*/