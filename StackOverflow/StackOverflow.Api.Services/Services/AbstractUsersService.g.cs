using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public abstract class AbstractUsersService : AbstractService
        {
                private IUsersRepository usersRepository;

                private IApiUsersRequestModelValidator usersModelValidator;

                private IBOLUsersMapper bolUsersMapper;

                private IDALUsersMapper dalUsersMapper;

                private ILogger logger;

                public AbstractUsersService(
                        ILogger logger,
                        IUsersRepository usersRepository,
                        IApiUsersRequestModelValidator usersModelValidator,
                        IBOLUsersMapper bolUsersMapper,
                        IDALUsersMapper dalUsersMapper)
                        : base()
                {
                        this.usersRepository = usersRepository;
                        this.usersModelValidator = usersModelValidator;
                        this.bolUsersMapper = bolUsersMapper;
                        this.dalUsersMapper = dalUsersMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiUsersResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.usersRepository.All(limit, offset);

                        return this.bolUsersMapper.MapBOToModel(this.dalUsersMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiUsersResponseModel> Get(int id)
                {
                        var record = await this.usersRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolUsersMapper.MapBOToModel(this.dalUsersMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiUsersResponseModel>> Create(
                        ApiUsersRequestModel model)
                {
                        CreateResponse<ApiUsersResponseModel> response = new CreateResponse<ApiUsersResponseModel>(await this.usersModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolUsersMapper.MapModelToBO(default(int), model);
                                var record = await this.usersRepository.Create(this.dalUsersMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolUsersMapper.MapBOToModel(this.dalUsersMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiUsersRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.usersModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolUsersMapper.MapModelToBO(id, model);
                                await this.usersRepository.Update(this.dalUsersMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.usersModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.usersRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>ff5564926b657ed02fc2bcd3dbad52ee</Hash>
</Codenesium>*/