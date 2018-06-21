using Codenesium.DataConversionExtensions.AspNetCore;
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
        public abstract class AbstractAccountService : AbstractService
        {
                private IAccountRepository accountRepository;

                private IApiAccountRequestModelValidator accountModelValidator;

                private IBOLAccountMapper bolAccountMapper;

                private IDALAccountMapper dalAccountMapper;

                private ILogger logger;

                public AbstractAccountService(
                        ILogger logger,
                        IAccountRepository accountRepository,
                        IApiAccountRequestModelValidator accountModelValidator,
                        IBOLAccountMapper bolAccountMapper,
                        IDALAccountMapper dalAccountMapper)
                        : base()
                {
                        this.accountRepository = accountRepository;
                        this.accountModelValidator = accountModelValidator;
                        this.bolAccountMapper = bolAccountMapper;
                        this.dalAccountMapper = dalAccountMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiAccountResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.accountRepository.All(limit, offset);

                        return this.bolAccountMapper.MapBOToModel(this.dalAccountMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiAccountResponseModel> Get(string id)
                {
                        var record = await this.accountRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolAccountMapper.MapBOToModel(this.dalAccountMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiAccountResponseModel>> Create(
                        ApiAccountRequestModel model)
                {
                        CreateResponse<ApiAccountResponseModel> response = new CreateResponse<ApiAccountResponseModel>(await this.accountModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolAccountMapper.MapModelToBO(default(string), model);
                                var record = await this.accountRepository.Create(this.dalAccountMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolAccountMapper.MapBOToModel(this.dalAccountMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiAccountRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.accountModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolAccountMapper.MapModelToBO(id, model);
                                await this.accountRepository.Update(this.dalAccountMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.accountModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.accountRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiAccountResponseModel> GetName(string name)
                {
                        Account record = await this.accountRepository.GetName(name);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolAccountMapper.MapBOToModel(this.dalAccountMapper.MapEFToBO(record));
                        }
                }
        }
}

/*<Codenesium>
    <Hash>a639a7490edbcdbcfdd49b470df3f9ab</Hash>
</Codenesium>*/