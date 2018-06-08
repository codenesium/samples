using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractEmployeeDepartmentHistoryService: AbstractService
        {
                private IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository;

                private IApiEmployeeDepartmentHistoryRequestModelValidator employeeDepartmentHistoryModelValidator;

                private IBOLEmployeeDepartmentHistoryMapper bolEmployeeDepartmentHistoryMapper;

                private IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper;

                private ILogger logger;

                public AbstractEmployeeDepartmentHistoryService(
                        ILogger logger,
                        IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository,
                        IApiEmployeeDepartmentHistoryRequestModelValidator employeeDepartmentHistoryModelValidator,
                        IBOLEmployeeDepartmentHistoryMapper bolemployeeDepartmentHistoryMapper,
                        IDALEmployeeDepartmentHistoryMapper dalemployeeDepartmentHistoryMapper)
                        : base()

                {
                        this.employeeDepartmentHistoryRepository = employeeDepartmentHistoryRepository;
                        this.employeeDepartmentHistoryModelValidator = employeeDepartmentHistoryModelValidator;
                        this.bolEmployeeDepartmentHistoryMapper = bolemployeeDepartmentHistoryMapper;
                        this.dalEmployeeDepartmentHistoryMapper = dalemployeeDepartmentHistoryMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.employeeDepartmentHistoryRepository.All(skip, take, orderClause);

                        return this.bolEmployeeDepartmentHistoryMapper.MapBOToModel(this.dalEmployeeDepartmentHistoryMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiEmployeeDepartmentHistoryResponseModel> Get(int businessEntityID)
                {
                        var record = await this.employeeDepartmentHistoryRepository.Get(businessEntityID);

                        return this.bolEmployeeDepartmentHistoryMapper.MapBOToModel(this.dalEmployeeDepartmentHistoryMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>> Create(
                        ApiEmployeeDepartmentHistoryRequestModel model)
                {
                        CreateResponse<ApiEmployeeDepartmentHistoryResponseModel> response = new CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>(await this.employeeDepartmentHistoryModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolEmployeeDepartmentHistoryMapper.MapModelToBO(default (int), model);
                                var record = await this.employeeDepartmentHistoryRepository.Create(this.dalEmployeeDepartmentHistoryMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolEmployeeDepartmentHistoryMapper.MapBOToModel(this.dalEmployeeDepartmentHistoryMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int businessEntityID,
                        ApiEmployeeDepartmentHistoryRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.employeeDepartmentHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model));

                        if (response.Success)
                        {
                                var bo = this.bolEmployeeDepartmentHistoryMapper.MapModelToBO(businessEntityID, model);
                                await this.employeeDepartmentHistoryRepository.Update(this.dalEmployeeDepartmentHistoryMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int businessEntityID)
                {
                        ActionResponse response = new ActionResponse(await this.employeeDepartmentHistoryModelValidator.ValidateDeleteAsync(businessEntityID));

                        if (response.Success)
                        {
                                await this.employeeDepartmentHistoryRepository.Delete(businessEntityID);
                        }

                        return response;
                }

                public async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> GetDepartmentID(short departmentID)
                {
                        List<EmployeeDepartmentHistory> records = await this.employeeDepartmentHistoryRepository.GetDepartmentID(departmentID);

                        return this.bolEmployeeDepartmentHistoryMapper.MapBOToModel(this.dalEmployeeDepartmentHistoryMapper.MapEFToBO(records));
                }
                public async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> GetShiftID(int shiftID)
                {
                        List<EmployeeDepartmentHistory> records = await this.employeeDepartmentHistoryRepository.GetShiftID(shiftID);

                        return this.bolEmployeeDepartmentHistoryMapper.MapBOToModel(this.dalEmployeeDepartmentHistoryMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>bdbcc9532a11cbb752fc7ea7f2d6274a</Hash>
</Codenesium>*/