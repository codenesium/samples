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
	public abstract class AbstractEmployeeService : AbstractService
	{
		protected IEmployeeRepository EmployeeRepository { get; private set; }

		protected IApiEmployeeRequestModelValidator EmployeeModelValidator { get; private set; }

		protected IBOLEmployeeMapper BolEmployeeMapper { get; private set; }

		protected IDALEmployeeMapper DalEmployeeMapper { get; private set; }

		protected IBOLEmployeeDepartmentHistoryMapper BolEmployeeDepartmentHistoryMapper { get; private set; }

		protected IDALEmployeeDepartmentHistoryMapper DalEmployeeDepartmentHistoryMapper { get; private set; }

		protected IBOLEmployeePayHistoryMapper BolEmployeePayHistoryMapper { get; private set; }

		protected IDALEmployeePayHistoryMapper DalEmployeePayHistoryMapper { get; private set; }

		protected IBOLJobCandidateMapper BolJobCandidateMapper { get; private set; }

		protected IDALJobCandidateMapper DalJobCandidateMapper { get; private set; }

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
			this.EmployeeRepository = employeeRepository;
			this.EmployeeModelValidator = employeeModelValidator;
			this.BolEmployeeMapper = bolEmployeeMapper;
			this.DalEmployeeMapper = dalEmployeeMapper;
			this.BolEmployeeDepartmentHistoryMapper = bolEmployeeDepartmentHistoryMapper;
			this.DalEmployeeDepartmentHistoryMapper = dalEmployeeDepartmentHistoryMapper;
			this.BolEmployeePayHistoryMapper = bolEmployeePayHistoryMapper;
			this.DalEmployeePayHistoryMapper = dalEmployeePayHistoryMapper;
			this.BolJobCandidateMapper = bolJobCandidateMapper;
			this.DalJobCandidateMapper = dalJobCandidateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEmployeeResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.EmployeeRepository.All(limit, offset);

			return this.BolEmployeeMapper.MapBOToModel(this.DalEmployeeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEmployeeResponseModel> Get(int businessEntityID)
		{
			var record = await this.EmployeeRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolEmployeeMapper.MapBOToModel(this.DalEmployeeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiEmployeeResponseModel>> Create(
			ApiEmployeeRequestModel model)
		{
			CreateResponse<ApiEmployeeResponseModel> response = new CreateResponse<ApiEmployeeResponseModel>(await this.EmployeeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolEmployeeMapper.MapModelToBO(default(int), model);
				var record = await this.EmployeeRepository.Create(this.DalEmployeeMapper.MapBOToEF(bo));

				response.SetRecord(this.BolEmployeeMapper.MapBOToModel(this.DalEmployeeMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEmployeeResponseModel>> Update(
			int businessEntityID,
			ApiEmployeeRequestModel model)
		{
			var validationResult = await this.EmployeeModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolEmployeeMapper.MapModelToBO(businessEntityID, model);
				await this.EmployeeRepository.Update(this.DalEmployeeMapper.MapBOToEF(bo));

				var record = await this.EmployeeRepository.Get(businessEntityID);

				return new UpdateResponse<ApiEmployeeResponseModel>(this.BolEmployeeMapper.MapBOToModel(this.DalEmployeeMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiEmployeeResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.EmployeeModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.EmployeeRepository.Delete(businessEntityID);
			}

			return response;
		}

		public async Task<ApiEmployeeResponseModel> ByLoginID(string loginID)
		{
			Employee record = await this.EmployeeRepository.ByLoginID(loginID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolEmployeeMapper.MapBOToModel(this.DalEmployeeMapper.MapEFToBO(record));
			}
		}

		public async Task<ApiEmployeeResponseModel> ByNationalIDNumber(string nationalIDNumber)
		{
			Employee record = await this.EmployeeRepository.ByNationalIDNumber(nationalIDNumber);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolEmployeeMapper.MapBOToModel(this.DalEmployeeMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<EmployeeDepartmentHistory> records = await this.EmployeeRepository.EmployeeDepartmentHistories(businessEntityID, limit, offset);

			return this.BolEmployeeDepartmentHistoryMapper.MapBOToModel(this.DalEmployeeDepartmentHistoryMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiEmployeePayHistoryResponseModel>> EmployeePayHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<EmployeePayHistory> records = await this.EmployeeRepository.EmployeePayHistories(businessEntityID, limit, offset);

			return this.BolEmployeePayHistoryMapper.MapBOToModel(this.DalEmployeePayHistoryMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiJobCandidateResponseModel>> JobCandidates(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<JobCandidate> records = await this.EmployeeRepository.JobCandidates(businessEntityID, limit, offset);

			return this.BolJobCandidateMapper.MapBOToModel(this.DalJobCandidateMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>1d17fd19e2117bc39d17786cf664ae3a</Hash>
</Codenesium>*/