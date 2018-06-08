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
        public abstract class AbstractLinkStatusService: AbstractService
        {
                private ILinkStatusRepository linkStatusRepository;

                private IApiLinkStatusRequestModelValidator linkStatusModelValidator;

                private IBOLLinkStatusMapper bolLinkStatusMapper;

                private IDALLinkStatusMapper dalLinkStatusMapper;

                private ILogger logger;

                public AbstractLinkStatusService(
                        ILogger logger,
                        ILinkStatusRepository linkStatusRepository,
                        IApiLinkStatusRequestModelValidator linkStatusModelValidator,
                        IBOLLinkStatusMapper bollinkStatusMapper,
                        IDALLinkStatusMapper dallinkStatusMapper)
                        : base()

                {
                        this.linkStatusRepository = linkStatusRepository;
                        this.linkStatusModelValidator = linkStatusModelValidator;
                        this.bolLinkStatusMapper = bollinkStatusMapper;
                        this.dalLinkStatusMapper = dallinkStatusMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiLinkStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.linkStatusRepository.All(skip, take, orderClause);

                        return this.bolLinkStatusMapper.MapBOToModel(this.dalLinkStatusMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiLinkStatusResponseModel> Get(int id)
                {
                        var record = await this.linkStatusRepository.Get(id);

                        return this.bolLinkStatusMapper.MapBOToModel(this.dalLinkStatusMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiLinkStatusResponseModel>> Create(
                        ApiLinkStatusRequestModel model)
                {
                        CreateResponse<ApiLinkStatusResponseModel> response = new CreateResponse<ApiLinkStatusResponseModel>(await this.linkStatusModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolLinkStatusMapper.MapModelToBO(default (int), model);
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
        }
}

/*<Codenesium>
    <Hash>6514dcd92f31134a000de812642be60f</Hash>
</Codenesium>*/