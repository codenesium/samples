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
        public abstract class AbstractAccountService: AbstractService
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
                        IBOLAccountMapper bolaccountMapper,
                        IDALAccountMapper dalaccountMapper)
                        : base()

                {
                        this.accountRepository = accountRepository;
                        this.accountModelValidator = accountModelValidator;
                        this.bolAccountMapper = bolaccountMapper;
                        this.dalAccountMapper = dalaccountMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiAccountResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.accountRepository.All(skip, take, orderClause);

                        return this.bolAccountMapper.MapBOToModel(this.dalAccountMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiAccountResponseModel> Get(string id)
                {
                        var record = await this.accountRepository.Get(id);

                        return this.bolAccountMapper.MapBOToModel(this.dalAccountMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiAccountResponseModel>> Create(
                        ApiAccountRequestModel model)
                {
                        CreateResponse<ApiAccountResponseModel> response = new CreateResponse<ApiAccountResponseModel>(await this.accountModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolAccountMapper.MapModelToBO(default (string), model);
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

                        return this.bolAccountMapper.MapBOToModel(this.dalAccountMapper.MapEFToBO(record));
                }
        }
}

/*<Codenesium>
    <Hash>b807c792efa6dfce3d2b0872aeb33b3d</Hash>
</Codenesium>*/