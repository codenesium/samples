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
        public abstract class AbstractUserRoleService: AbstractService
        {
                private IUserRoleRepository userRoleRepository;

                private IApiUserRoleRequestModelValidator userRoleModelValidator;

                private IBOLUserRoleMapper bolUserRoleMapper;

                private IDALUserRoleMapper dalUserRoleMapper;

                private ILogger logger;

                public AbstractUserRoleService(
                        ILogger logger,
                        IUserRoleRepository userRoleRepository,
                        IApiUserRoleRequestModelValidator userRoleModelValidator,
                        IBOLUserRoleMapper boluserRoleMapper,
                        IDALUserRoleMapper daluserRoleMapper)
                        : base()

                {
                        this.userRoleRepository = userRoleRepository;
                        this.userRoleModelValidator = userRoleModelValidator;
                        this.bolUserRoleMapper = boluserRoleMapper;
                        this.dalUserRoleMapper = daluserRoleMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiUserRoleResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.userRoleRepository.All(skip, take, orderClause);

                        return this.bolUserRoleMapper.MapBOToModel(this.dalUserRoleMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiUserRoleResponseModel> Get(string id)
                {
                        var record = await this.userRoleRepository.Get(id);

                        return this.bolUserRoleMapper.MapBOToModel(this.dalUserRoleMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiUserRoleResponseModel>> Create(
                        ApiUserRoleRequestModel model)
                {
                        CreateResponse<ApiUserRoleResponseModel> response = new CreateResponse<ApiUserRoleResponseModel>(await this.userRoleModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolUserRoleMapper.MapModelToBO(default (string), model);
                                var record = await this.userRoleRepository.Create(this.dalUserRoleMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolUserRoleMapper.MapBOToModel(this.dalUserRoleMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiUserRoleRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.userRoleModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolUserRoleMapper.MapModelToBO(id, model);
                                await this.userRoleRepository.Update(this.dalUserRoleMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.userRoleModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.userRoleRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiUserRoleResponseModel> GetName(string name)
                {
                        UserRole record = await this.userRoleRepository.GetName(name);

                        return this.bolUserRoleMapper.MapBOToModel(this.dalUserRoleMapper.MapEFToBO(record));
                }
        }
}

/*<Codenesium>
    <Hash>130360868a87523e18147bb4918c1279</Hash>
</Codenesium>*/