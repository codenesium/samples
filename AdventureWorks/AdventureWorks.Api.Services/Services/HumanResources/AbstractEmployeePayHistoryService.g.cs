using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractEmployeePayHistoryService : AbstractService
        {
                private IEmployeePayHistoryRepository employeePayHistoryRepository;

                private IApiEmployeePayHistoryRequestModelValidator employeePayHistoryModelValidator;

                private IBOLEmployeePayHistoryMapper bolEmployeePayHistoryMapper;

                private IDALEmployeePayHistoryMapper dalEmployeePayHistoryMapper;

                private ILogger logger;

                public AbstractEmployeePayHistoryService(
                        ILogger logger,
                        IEmployeePayHistoryRepository employeePayHistoryRepository,
                        IApiEmployeePayHistoryRequestModelValidator employeePayHistoryModelValidator,
                        IBOLEmployeePayHistoryMapper bolEmployeePayHistoryMapper,
                        IDALEmployeePayHistoryMapper dalEmployeePayHistoryMapper)
                        : base()
                {
                        this.employeePayHistoryRepository = employeePayHistoryRepository;
                        this.employeePayHistoryModelValidator = employeePayHistoryModelValidator;
                        this.bolEmployeePayHistoryMapper = bolEmployeePayHistoryMapper;
                        this.dalEmployeePayHistoryMapper = dalEmployeePayHistoryMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiEmployeePayHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.employeePayHistoryRepository.All(limit, offset);

                        return this.bolEmployeePayHistoryMapper.MapBOToModel(this.dalEmployeePayHistoryMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiEmployeePayHistoryResponseModel> Get(int businessEntityID)
                {
                        var record = await this.employeePayHistoryRepository.Get(businessEntityID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolEmployeePayHistoryMapper.MapBOToModel(this.dalEmployeePayHistoryMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiEmployeePayHistoryResponseModel>> Create(
                        ApiEmployeePayHistoryRequestModel model)
                {
                        CreateResponse<ApiEmployeePayHistoryResponseModel> response = new CreateResponse<ApiEmployeePayHistoryResponseModel>(await this.employeePayHistoryModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolEmployeePayHistoryMapper.MapModelToBO(default(int), model);
                                var record = await this.employeePayHistoryRepository.Create(this.dalEmployeePayHistoryMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolEmployeePayHistoryMapper.MapBOToModel(this.dalEmployeePayHistoryMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int businessEntityID,
                        ApiEmployeePayHistoryRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.employeePayHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model));
                        if (response.Success)
                        {
                                var bo = this.bolEmployeePayHistoryMapper.MapModelToBO(businessEntityID, model);
                                await this.employeePayHistoryRepository.Update(this.dalEmployeePayHistoryMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int businessEntityID)
                {
                        ActionResponse response = new ActionResponse(await this.employeePayHistoryModelValidator.ValidateDeleteAsync(businessEntityID));
                        if (response.Success)
                        {
                                await this.employeePayHistoryRepository.Delete(businessEntityID);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>3ea687e82f289a906363867141d05629</Hash>
</Codenesium>*/