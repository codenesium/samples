using Codenesium.DataConversionExtensions.AspNetCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractAdminService : AbstractService
        {
                private IAdminRepository adminRepository;

                private IApiAdminRequestModelValidator adminModelValidator;

                private IBOLAdminMapper bolAdminMapper;

                private IDALAdminMapper dalAdminMapper;

                private ILogger logger;

                public AbstractAdminService(
                        ILogger logger,
                        IAdminRepository adminRepository,
                        IApiAdminRequestModelValidator adminModelValidator,
                        IBOLAdminMapper bolAdminMapper,
                        IDALAdminMapper dalAdminMapper)
                        : base()
                {
                        this.adminRepository = adminRepository;
                        this.adminModelValidator = adminModelValidator;
                        this.bolAdminMapper = bolAdminMapper;
                        this.dalAdminMapper = dalAdminMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiAdminResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.adminRepository.All(limit, offset);

                        return this.bolAdminMapper.MapBOToModel(this.dalAdminMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiAdminResponseModel> Get(int id)
                {
                        var record = await this.adminRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolAdminMapper.MapBOToModel(this.dalAdminMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiAdminResponseModel>> Create(
                        ApiAdminRequestModel model)
                {
                        CreateResponse<ApiAdminResponseModel> response = new CreateResponse<ApiAdminResponseModel>(await this.adminModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolAdminMapper.MapModelToBO(default(int), model);
                                var record = await this.adminRepository.Create(this.dalAdminMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolAdminMapper.MapBOToModel(this.dalAdminMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiAdminRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.adminModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolAdminMapper.MapModelToBO(id, model);
                                await this.adminRepository.Update(this.dalAdminMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.adminModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.adminRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>036a99b0db953ada056890f00bf8350b</Hash>
</Codenesium>*/