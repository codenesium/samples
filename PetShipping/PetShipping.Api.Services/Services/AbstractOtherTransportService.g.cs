using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractOtherTransportService : AbstractService
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
                        IDALOtherTransportMapper dalOtherTransportMapper)
                        : base()
                {
                        this.otherTransportRepository = otherTransportRepository;
                        this.otherTransportModelValidator = otherTransportModelValidator;
                        this.bolOtherTransportMapper = bolOtherTransportMapper;
                        this.dalOtherTransportMapper = dalOtherTransportMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiOtherTransportResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.otherTransportRepository.All(limit, offset);

                        return this.bolOtherTransportMapper.MapBOToModel(this.dalOtherTransportMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiOtherTransportResponseModel> Get(int id)
                {
                        var record = await this.otherTransportRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolOtherTransportMapper.MapBOToModel(this.dalOtherTransportMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiOtherTransportResponseModel>> Create(
                        ApiOtherTransportRequestModel model)
                {
                        CreateResponse<ApiOtherTransportResponseModel> response = new CreateResponse<ApiOtherTransportResponseModel>(await this.otherTransportModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolOtherTransportMapper.MapModelToBO(default(int), model);
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
    <Hash>7162978d3ae1a5d6d92b2c65b3a3c8d4</Hash>
</Codenesium>*/