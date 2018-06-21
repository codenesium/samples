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
        public abstract class AbstractChainService : AbstractService
        {
                private IChainRepository chainRepository;

                private IApiChainRequestModelValidator chainModelValidator;

                private IBOLChainMapper bolChainMapper;

                private IDALChainMapper dalChainMapper;

                private IBOLClaspMapper bolClaspMapper;

                private IDALClaspMapper dalClaspMapper;
                private IBOLLinkMapper bolLinkMapper;

                private IDALLinkMapper dalLinkMapper;

                private ILogger logger;

                public AbstractChainService(
                        ILogger logger,
                        IChainRepository chainRepository,
                        IApiChainRequestModelValidator chainModelValidator,
                        IBOLChainMapper bolChainMapper,
                        IDALChainMapper dalChainMapper,
                        IBOLClaspMapper bolClaspMapper,
                        IDALClaspMapper dalClaspMapper,
                        IBOLLinkMapper bolLinkMapper,
                        IDALLinkMapper dalLinkMapper)
                        : base()
                {
                        this.chainRepository = chainRepository;
                        this.chainModelValidator = chainModelValidator;
                        this.bolChainMapper = bolChainMapper;
                        this.dalChainMapper = dalChainMapper;
                        this.bolClaspMapper = bolClaspMapper;
                        this.dalClaspMapper = dalClaspMapper;
                        this.bolLinkMapper = bolLinkMapper;
                        this.dalLinkMapper = dalLinkMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiChainResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.chainRepository.All(limit, offset);

                        return this.bolChainMapper.MapBOToModel(this.dalChainMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiChainResponseModel> Get(int id)
                {
                        var record = await this.chainRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolChainMapper.MapBOToModel(this.dalChainMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiChainResponseModel>> Create(
                        ApiChainRequestModel model)
                {
                        CreateResponse<ApiChainResponseModel> response = new CreateResponse<ApiChainResponseModel>(await this.chainModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolChainMapper.MapModelToBO(default(int), model);
                                var record = await this.chainRepository.Create(this.dalChainMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolChainMapper.MapBOToModel(this.dalChainMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiChainRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.chainModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolChainMapper.MapModelToBO(id, model);
                                await this.chainRepository.Update(this.dalChainMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.chainModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.chainRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiClaspResponseModel>> Clasps(int nextChainId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Clasp> records = await this.chainRepository.Clasps(nextChainId, limit, offset);

                        return this.bolClaspMapper.MapBOToModel(this.dalClaspMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiLinkResponseModel>> Links(int chainId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Link> records = await this.chainRepository.Links(chainId, limit, offset);

                        return this.bolLinkMapper.MapBOToModel(this.dalLinkMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>0616d0ecbf38e4cf42b91a7e96994138</Hash>
</Codenesium>*/