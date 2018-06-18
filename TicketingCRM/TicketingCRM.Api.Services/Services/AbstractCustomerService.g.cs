using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractCustomerService: AbstractService
        {
                private ICustomerRepository customerRepository;

                private IApiCustomerRequestModelValidator customerModelValidator;

                private IBOLCustomerMapper bolCustomerMapper;

                private IDALCustomerMapper dalCustomerMapper;

                private ILogger logger;

                public AbstractCustomerService(
                        ILogger logger,
                        ICustomerRepository customerRepository,
                        IApiCustomerRequestModelValidator customerModelValidator,
                        IBOLCustomerMapper bolCustomerMapper,
                        IDALCustomerMapper dalCustomerMapper

                        )
                        : base()

                {
                        this.customerRepository = customerRepository;
                        this.customerModelValidator = customerModelValidator;
                        this.bolCustomerMapper = bolCustomerMapper;
                        this.dalCustomerMapper = dalCustomerMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiCustomerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.customerRepository.All(limit, offset);

                        return this.bolCustomerMapper.MapBOToModel(this.dalCustomerMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiCustomerResponseModel> Get(int id)
                {
                        var record = await this.customerRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolCustomerMapper.MapBOToModel(this.dalCustomerMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiCustomerResponseModel>> Create(
                        ApiCustomerRequestModel model)
                {
                        CreateResponse<ApiCustomerResponseModel> response = new CreateResponse<ApiCustomerResponseModel>(await this.customerModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolCustomerMapper.MapModelToBO(default (int), model);
                                var record = await this.customerRepository.Create(this.dalCustomerMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolCustomerMapper.MapBOToModel(this.dalCustomerMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiCustomerRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.customerModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolCustomerMapper.MapModelToBO(id, model);
                                await this.customerRepository.Update(this.dalCustomerMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.customerModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.customerRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>602e24461e0c072c1ce153fe49c3145f</Hash>
</Codenesium>*/