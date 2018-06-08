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
        public abstract class AbstractChainStatusService: AbstractService
        {
                private IChainStatusRepository chainStatusRepository;

                private IApiChainStatusRequestModelValidator chainStatusModelValidator;

                private IBOLChainStatusMapper bolChainStatusMapper;

                private IDALChainStatusMapper dalChainStatusMapper;

                private ILogger logger;

                public AbstractChainStatusService(
                        ILogger logger,
                        IChainStatusRepository chainStatusRepository,
                        IApiChainStatusRequestModelValidator chainStatusModelValidator,
                        IBOLChainStatusMapper bolchainStatusMapper,
                        IDALChainStatusMapper dalchainStatusMapper)
                        : base()

                {
                        this.chainStatusRepository = chainStatusRepository;
                        this.chainStatusModelValidator = chainStatusModelValidator;
                        this.bolChainStatusMapper = bolchainStatusMapper;
                        this.dalChainStatusMapper = dalchainStatusMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiChainStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.chainStatusRepository.All(skip, take, orderClause);

                        return this.bolChainStatusMapper.MapBOToModel(this.dalChainStatusMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiChainStatusResponseModel> Get(int id)
                {
                        var record = await this.chainStatusRepository.Get(id);

                        return this.bolChainStatusMapper.MapBOToModel(this.dalChainStatusMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiChainStatusResponseModel>> Create(
                        ApiChainStatusRequestModel model)
                {
                        CreateResponse<ApiChainStatusResponseModel> response = new CreateResponse<ApiChainStatusResponseModel>(await this.chainStatusModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolChainStatusMapper.MapModelToBO(default (int), model);
                                var record = await this.chainStatusRepository.Create(this.dalChainStatusMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolChainStatusMapper.MapBOToModel(this.dalChainStatusMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiChainStatusRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.chainStatusModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolChainStatusMapper.MapModelToBO(id, model);
                                await this.chainStatusRepository.Update(this.dalChainStatusMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.chainStatusModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.chainStatusRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a70171ebacc5b53308c31fc49afcf4ec</Hash>
</Codenesium>*/