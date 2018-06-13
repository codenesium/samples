using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractOtherTransportService: AbstractService
        {
                private IOtherTransportRepository otherTransportRepository;

                private IApiOtherTransportRequestModelValidator otherTransportModelValidator;

                private IBOLOtherTransportMapper bolOtherTransportMapper;

                private IDALOtherTransportMapper dalOtherTransportMapper;

                private ILogger logger;

                public AbstractOtherTransportService(
                        ILogger logger,
                        IOtherTransportRepository otherTransportRepository,
                        IApiOtherTransportRequestModelValidator otherTransportModelValidator,
                        IBOLOtherTransportMapper bolOtherTransportMapper,
                        IDALOtherTransportMapper dalOtherTransportMapper

                        )
                        : base()

                {
                        this.otherTransportRepository = otherTransportRepository;
                        this.otherTransportModelValidator = otherTransportModelValidator;
                        this.bolOtherTransportMapper = bolOtherTransportMapper;
                        this.dalOtherTransportMapper = dalOtherTransportMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiOtherTransportResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.otherTransportRepository.All(limit, offset, orderClause);

                        return this.bolOtherTransportMapper.MapBOToModel(this.dalOtherTransportMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiOtherTransportResponseModel> Get(int id)
                {
                        var record = await this.otherTransportRepository.Get(id);

                        return this.bolOtherTransportMapper.MapBOToModel(this.dalOtherTransportMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiOtherTransportResponseModel>> Create(
                        ApiOtherTransportRequestModel model)
                {
                        CreateResponse<ApiOtherTransportResponseModel> response = new CreateResponse<ApiOtherTransportResponseModel>(await this.otherTransportModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolOtherTransportMapper.MapModelToBO(default (int), model);
                                var record = await this.otherTransportRepository.Create(this.dalOtherTransportMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolOtherTransportMapper.MapBOToModel(this.dalOtherTransportMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiOtherTransportRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.otherTransportModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolOtherTransportMapper.MapModelToBO(id, model);
                                await this.otherTransportRepository.Update(this.dalOtherTransportMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.otherTransportModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.otherTransportRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>84a261a30c121987bf86e452885ba4bf</Hash>
</Codenesium>*/