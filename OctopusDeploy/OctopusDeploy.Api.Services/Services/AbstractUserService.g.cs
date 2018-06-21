using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractUserService : AbstractService
        {
                private IUserRepository userRepository;

                private IApiUserRequestModelValidator userModelValidator;

                private IBOLUserMapper bolUserMapper;

                private IDALUserMapper dalUserMapper;

                private ILogger logger;

                public AbstractUserService(
                        ILogger logger,
                        IUserRepository userRepository,
                        IApiUserRequestModelValidator userModelValidator,
                        IBOLUserMapper bolUserMapper,
                        IDALUserMapper dalUserMapper)
                        : base()
                {
                        this.userRepository = userRepository;
                        this.userModelValidator = userModelValidator;
                        this.bolUserMapper = bolUserMapper;
                        this.dalUserMapper = dalUserMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiUserResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.userRepository.All(limit, offset);

                        return this.bolUserMapper.MapBOToModel(this.dalUserMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiUserResponseModel> Get(string id)
                {
                        var record = await this.userRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolUserMapper.MapBOToModel(this.dalUserMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiUserResponseModel>> Create(
                        ApiUserRequestModel model)
                {
                        CreateResponse<ApiUserResponseModel> response = new CreateResponse<ApiUserResponseModel>(await this.userModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolUserMapper.MapModelToBO(default(string), model);
                                var record = await this.userRepository.Create(this.dalUserMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolUserMapper.MapBOToModel(this.dalUserMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiUserRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.userModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolUserMapper.MapModelToBO(id, model);
                                await this.userRepository.Update(this.dalUserMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.userModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.userRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiUserResponseModel> GetUsername(string username)
                {
                        User record = await this.userRepository.GetUsername(username);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolUserMapper.MapBOToModel(this.dalUserMapper.MapEFToBO(record));
                        }
                }

                public async Task<List<ApiUserResponseModel>> GetDisplayName(string displayName)
                {
                        List<User> records = await this.userRepository.GetDisplayName(displayName);

                        return this.bolUserMapper.MapBOToModel(this.dalUserMapper.MapEFToBO(records));
                }

                public async Task<List<ApiUserResponseModel>> GetEmailAddress(string emailAddress)
                {
                        List<User> records = await this.userRepository.GetEmailAddress(emailAddress);

                        return this.bolUserMapper.MapBOToModel(this.dalUserMapper.MapEFToBO(records));
                }

                public async Task<List<ApiUserResponseModel>> GetExternalId(string externalId)
                {
                        List<User> records = await this.userRepository.GetExternalId(externalId);

                        return this.bolUserMapper.MapBOToModel(this.dalUserMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>8bae3c14a65e913b79799fdc7df1d3df</Hash>
</Codenesium>*/