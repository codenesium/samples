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
        public abstract class AbstractEmployeeService : AbstractService
        {
                private IEmployeeRepository employeeRepository;

                private IApiEmployeeRequestModelValidator employeeModelValidator;

                private IBOLEmployeeMapper bolEmployeeMapper;

                private IDALEmployeeMapper dalEmployeeMapper;

                private IBOLEmployeeDepartmentHistoryMapper bolEmployeeDepartmentHistoryMapper;

                private IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper;
                private IBOLEmployeePayHistoryMapper bolEmployeePayHistoryMapper;

                private IDALEmployeePayHistoryMapper dalEmployeePayHistoryMapper;
                private IBOLJobCandidateMapper bolJobCandidateMapper;

                private IDALJobCandidateMapper dalJobCandidateMapper;

                private ILogger logger;

                public AbstractEmployeeService(
                        ILogger logger,
                        IEmployeeRepository employeeRepository,
                        IApiEmployeeRequestModelValidator employeeModelValidator,
                        IBOLEmployeeMapper bolEmployeeMapper,
                        IDALEmployeeMapper dalEmployeeMapper,
                        IBOLEmployeeDepartmentHistoryMapper bolEmployeeDepartmentHistoryMapper,
                        IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper,
                        IBOLEmployeePayHistoryMapper bolEmployeePayHistoryMapper,
                        IDALEmployeePayHistoryMapper dalEmployeePayHistoryMapper,
                        IBOLJobCandidateMapper bolJobCandidateMapper,
                        IDALJobCandidateMapper dalJobCandidateMapper)
                        : base()
                {
                        this.employeeRepository = employeeRepository;
                        this.employeeModelValidator = employeeModelValidator;
                        this.bolEmployeeMapper = bolEmployeeMapper;
                        this.dalEmployeeMapper = dalEmployeeMapper;
                        this.bolEmployeeDepartmentHistoryMapper = bolEmployeeDepartmentHistoryMapper;
                        this.dalEmployeeDepartmentHistoryMapper = dalEmployeeDepartmentHistoryMapper;
                        this.bolEmployeePayHistoryMapper = bolEmployeePayHistoryMapper;
                        this.dalEmployeePayHistoryMapper = dalEmployeePayHistoryMapper;
                        this.bolJobCandidateMapper = bolJobCandidateMapper;
                        this.dalJobCandidateMapper = dalJobCandidateMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiEmployeeResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.employeeRepository.All(limit, offset);

                        return this.bolEmployeeMapper.MapBOToModel(this.dalEmployeeMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiEmployeeResponseModel> Get(int businessEntityID)
                {
                        var record = await this.employeeRepository.Get(businessEntityID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolEmployeeMapper.MapBOToModel(this.dalEmployeeMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiEmployeeResponseModel>> Create(
                        ApiEmployeeRequestModel model)
                {
                        CreateResponse<ApiEmployeeResponseModel> response = new CreateResponse<ApiEmployeeResponseModel>(await this.employeeModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolEmployeeMapper.MapModelToBO(default(int), model);
                                var record = await this.employeeRepository.Create(this.dalEmployeeMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolEmployeeMapper.MapBOToModel(this.dalEmployeeMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int businessEntityID,
                        ApiEmployeeRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.employeeModelValidator.ValidateUpdateAsync(businessEntityID, model));
                        if (response.Success)
                        {
                                var bo = this.bolEmployeeMapper.MapModelToBO(businessEntityID, model);
                                await this.employeeRepository.Update(this.dalEmployeeMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int businessEntityID)
                {
                        ActionResponse response = new ActionResponse(await this.employeeModelValidator.ValidateDeleteAsync(businessEntityID));
                        if (response.Success)
                        {
                                await this.employeeRepository.Delete(businessEntityID);
                        }

                        return response;
                }

                public async Task<ApiEmployeeResponseModel> ByLoginID(string loginID)
                {
                        Employee record = await this.employeeRepository.ByLoginID(loginID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolEmployeeMapper.MapBOToModel(this.dalEmployeeMapper.MapEFToBO(record));
                        }
                }

                public async Task<ApiEmployeeResponseModel> ByNationalIDNumber(string nationalIDNumber)
                {
                        Employee record = await this.employeeRepository.ByNationalIDNumber(nationalIDNumber);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolEmployeeMapper.MapBOToModel(this.dalEmployeeMapper.MapEFToBO(record));
                        }
                }

                public async virtual Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        List<EmployeeDepartmentHistory> records = await this.employeeRepository.EmployeeDepartmentHistories(businessEntityID, limit, offset);

                        return this.bolEmployeeDepartmentHistoryMapper.MapBOToModel(this.dalEmployeeDepartmentHistoryMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiEmployeePayHistoryResponseModel>> EmployeePayHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        List<EmployeePayHistory> records = await this.employeeRepository.EmployeePayHistories(businessEntityID, limit, offset);

                        return this.bolEmployeePayHistoryMapper.MapBOToModel(this.dalEmployeePayHistoryMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiJobCandidateResponseModel>> JobCandidates(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        List<JobCandidate> records = await this.employeeRepository.JobCandidates(businessEntityID, limit, offset);

                        return this.bolJobCandidateMapper.MapBOToModel(this.dalJobCandidateMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>5da02fa2bd942f4a6381a338071995d3</Hash>
</Codenesium>*/