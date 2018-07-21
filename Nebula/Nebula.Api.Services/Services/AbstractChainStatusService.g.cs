using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractChainStatusService : AbstractService
        {
                private IChainStatusRepository chainStatusRepository;

                private IApiChainStatusRequestModelValidator chainStatusModelValidator;

                private IBOLChainStatusMapper bolChainStatusMapper;

                private IDALChainStatusMapper dalChainStatusMapper;

                private IBOLChainMapper bolChainMapper;

                private IDALChainMapper dalChainMapper;

                private ILogger logger;

                public AbstractChainStatusService(
                        ILogger logger,
                        IChainStatusRepository chainStatusRepository,
                        IApiChainStatusRequestModelValidator chainStatusModelValidator,
                        IBOLChainStatusMapper bolChainStatusMapper,
                        IDALChainStatusMapper dalChainStatusMapper,
                        IBOLChainMapper bolChainMapper,
                        IDALChainMapper dalChainMapper)
                        : base()
                {
                        this.chainStatusRepository = chainStatusRepository;
                        this.chainStatusModelValidator = chainStatusModelValidator;
                        this.bolChainStatusMapper = bolChainStatusMapper;
                        this.dalChainStatusMapper = dalChainStatusMapper;
                        this.bolChainMapper = bolChainMapper;
                        this.dalChainMapper = dalChainMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiChainStatusResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.chainStatusRepository.All(limit, offset);

                        return this.bolChainStatusMapper.MapBOToModel(this.dalChainStatusMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiChainStatusResponseModel> Get(int id)
                {
                        var record = await this.chainStatusRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolChainStatusMapper.MapBOToModel(this.dalChainStatusMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiChainStatusResponseModel>> Create(
                        ApiChainStatusRequestModel model)
                {
                        CreateResponse<ApiChainStatusResponseModel> response = new CreateResponse<ApiChainStatusResponseModel>(await this.chainStatusModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolChainStatusMapper.MapModelToBO(default(int), model);
                                var record = await this.chainStatusRepository.Create(this.dalChainStatusMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolChainStatusMapper.MapBOToModel(this.dalChainStatusMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiChainStatusResponseModel>> Update(
                        int id,
                        ApiChainStatusRequestModel model)
                {
                        var validationResult = await this.chainStatusModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolChainStatusMapper.MapModelToBO(id, model);
                                await this.chainStatusRepository.Update(this.dalChainStatusMapper.MapBOToEF(bo));

                                var record = await this.chainStatusRepository.Get(id);

                                return new UpdateResponse<ApiChainStatusResponseModel>(this.bolChainStatusMapper.MapBOToModel(this.dalChainStatusMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiChainStatusResponseModel>(validationResult);
                        }
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

                public async virtual Task<List<ApiChainResponseModel>> Chains(int chainStatusId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Chain> records = await this.chainStatusRepository.Chains(chainStatusId, limit, offset);

                        return this.bolChainMapper.MapBOToModel(this.dalChainMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>a5ba3941b7a883ae080aaec64fc6583b</Hash>
</Codenesium>*/