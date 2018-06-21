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
        public abstract class AbstractLinkStatusService : AbstractService
        {
                private ILinkStatusRepository linkStatusRepository;

                private IApiLinkStatusRequestModelValidator linkStatusModelValidator;

                private IBOLLinkStatusMapper bolLinkStatusMapper;

                private IDALLinkStatusMapper dalLinkStatusMapper;

                private IBOLLinkMapper bolLinkMapper;

                private IDALLinkMapper dalLinkMapper;

                private ILogger logger;

                public AbstractLinkStatusService(
                        ILogger logger,
                        ILinkStatusRepository linkStatusRepository,
                        IApiLinkStatusRequestModelValidator linkStatusModelValidator,
                        IBOLLinkStatusMapper bolLinkStatusMapper,
                        IDALLinkStatusMapper dalLinkStatusMapper,
                        IBOLLinkMapper bolLinkMapper,
                        IDALLinkMapper dalLinkMapper)
                        : base()
                {
                        this.linkStatusRepository = linkStatusRepository;
                        this.linkStatusModelValidator = linkStatusModelValidator;
                        this.bolLinkStatusMapper = bolLinkStatusMapper;
                        this.dalLinkStatusMapper = dalLinkStatusMapper;
                        this.bolLinkMapper = bolLinkMapper;
                        this.dalLinkMapper = dalLinkMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiLinkStatusResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.linkStatusRepository.All(limit, offset);

                        return this.bolLinkStatusMapper.MapBOToModel(this.dalLinkStatusMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiLinkStatusResponseModel> Get(int id)
                {
                        var record = await this.linkStatusRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolLinkStatusMapper.MapBOToModel(this.dalLinkStatusMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiLinkStatusResponseModel>> Create(
                        ApiLinkStatusRequestModel model)
                {
                        CreateResponse<ApiLinkStatusResponseModel> response = new CreateResponse<ApiLinkStatusResponseModel>(await this.linkStatusModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolLinkStatusMapper.MapModelToBO(default(int), model);
                                var record = await this.linkStatusRepository.Create(this.dalLinkStatusMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolLinkStatusMapper.MapBOToModel(this.dalLinkStatusMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiLinkStatusRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.linkStatusModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolLinkStatusMapper.MapModelToBO(id, model);
                                await this.linkStatusRepository.Update(this.dalLinkStatusMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.linkStatusModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.linkStatusRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiLinkResponseModel>> Links(int linkStatusId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Link> records = await this.linkStatusRepository.Links(linkStatusId, limit, offset);

                        return this.bolLinkMapper.MapBOToModel(this.dalLinkMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>0fca9c6fa9db504693341feb054ea7c2</Hash>
</Codenesium>*/