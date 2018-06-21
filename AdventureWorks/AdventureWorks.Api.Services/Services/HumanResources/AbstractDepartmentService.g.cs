using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
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
        public abstract class AbstractDepartmentService : AbstractService
        {
                private IDepartmentRepository departmentRepository;

                private IApiDepartmentRequestModelValidator departmentModelValidator;

                private IBOLDepartmentMapper bolDepartmentMapper;

                private IDALDepartmentMapper dalDepartmentMapper;

                private IBOLEmployeeDepartmentHistoryMapper bolEmployeeDepartmentHistoryMapper;

                private IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper;

                private ILogger logger;

                public AbstractDepartmentService(
                        ILogger logger,
                        IDepartmentRepository departmentRepository,
                        IApiDepartmentRequestModelValidator departmentModelValidator,
                        IBOLDepartmentMapper bolDepartmentMapper,
                        IDALDepartmentMapper dalDepartmentMapper,
                        IBOLEmployeeDepartmentHistoryMapper bolEmployeeDepartmentHistoryMapper,
                        IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper)
                        : base()
                {
                        this.departmentRepository = departmentRepository;
                        this.departmentModelValidator = departmentModelValidator;
                        this.bolDepartmentMapper = bolDepartmentMapper;
                        this.dalDepartmentMapper = dalDepartmentMapper;
                        this.bolEmployeeDepartmentHistoryMapper = bolEmployeeDepartmentHistoryMapper;
                        this.dalEmployeeDepartmentHistoryMapper = dalEmployeeDepartmentHistoryMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiDepartmentResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.departmentRepository.All(limit, offset);

                        return this.bolDepartmentMapper.MapBOToModel(this.dalDepartmentMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiDepartmentResponseModel> Get(short departmentID)
                {
                        var record = await this.departmentRepository.Get(departmentID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolDepartmentMapper.MapBOToModel(this.dalDepartmentMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiDepartmentResponseModel>> Create(
                        ApiDepartmentRequestModel model)
                {
                        CreateResponse<ApiDepartmentResponseModel> response = new CreateResponse<ApiDepartmentResponseModel>(await this.departmentModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolDepartmentMapper.MapModelToBO(default(short), model);
                                var record = await this.departmentRepository.Create(this.dalDepartmentMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolDepartmentMapper.MapBOToModel(this.dalDepartmentMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        short departmentID,
                        ApiDepartmentRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.departmentModelValidator.ValidateUpdateAsync(departmentID, model));
                        if (response.Success)
                        {
                                var bo = this.bolDepartmentMapper.MapModelToBO(departmentID, model);
                                await this.departmentRepository.Update(this.dalDepartmentMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        short departmentID)
                {
                        ActionResponse response = new ActionResponse(await this.departmentModelValidator.ValidateDeleteAsync(departmentID));
                        if (response.Success)
                        {
                                await this.departmentRepository.Delete(departmentID);
                        }

                        return response;
                }

                public async Task<ApiDepartmentResponseModel> ByName(string name)
                {
                        Department record = await this.departmentRepository.ByName(name);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolDepartmentMapper.MapBOToModel(this.dalDepartmentMapper.MapEFToBO(record));
                        }
                }

                public async virtual Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistories(short departmentID, int limit = int.MaxValue, int offset = 0)
                {
                        List<EmployeeDepartmentHistory> records = await this.departmentRepository.EmployeeDepartmentHistories(departmentID, limit, offset);

                        return this.bolEmployeeDepartmentHistoryMapper.MapBOToModel(this.dalEmployeeDepartmentHistoryMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>1c3f1d601d6390b8499581288f64abf8</Hash>
</Codenesium>*/