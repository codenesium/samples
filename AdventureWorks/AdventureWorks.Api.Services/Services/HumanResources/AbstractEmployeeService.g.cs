using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractEmployeeService : AbstractService
	{
		protected IEmployeeRepository EmployeeRepository { get; private set; }

		protected IApiEmployeeServerRequestModelValidator EmployeeModelValidator { get; private set; }

		protected IBOLEmployeeMapper BolEmployeeMapper { get; private set; }

		protected IDALEmployeeMapper DalEmployeeMapper { get; private set; }

		protected IBOLJobCandidateMapper BolJobCandidateMapper { get; private set; }

		protected IDALJobCandidateMapper DalJobCandidateMapper { get; private set; }

		private ILogger logger;

		public AbstractEmployeeService(
			ILogger logger,
			IEmployeeRepository employeeRepository,
			IApiEmployeeServerRequestModelValidator employeeModelValidator,
			IBOLEmployeeMapper bolEmployeeMapper,
			IDALEmployeeMapper dalEmployeeMapper,
			IBOLJobCandidateMapper bolJobCandidateMapper,
			IDALJobCandidateMapper dalJobCandidateMapper)
			: base()
		{
			this.EmployeeRepository = employeeRepository;
			this.EmployeeModelValidator = employeeModelValidator;
			this.BolEmployeeMapper = bolEmployeeMapper;
			this.DalEmployeeMapper = dalEmployeeMapper;
			this.BolJobCandidateMapper = bolJobCandidateMapper;
			this.DalJobCandidateMapper = dalJobCandidateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEmployeeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.EmployeeRepository.All(limit, offset);

			return this.BolEmployeeMapper.MapBOToModel(this.DalEmployeeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEmployeeServerResponseModel> Get(int businessEntityID)
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

		public virtual async Task<CreateResponse<ApiEmployeeServerResponseModel>> Create(
			ApiEmployeeServerRequestModel model)
		{
			CreateResponse<ApiEmployeeServerResponseModel> response = ValidationResponseFactory<ApiEmployeeServerResponseModel>.CreateResponse(await this.EmployeeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolEmployeeMapper.MapModelToBO(default(int), model);
				var record = await this.EmployeeRepository.Create(this.DalEmployeeMapper.MapBOToEF(bo));

				response.SetRecord(this.BolEmployeeMapper.MapBOToModel(this.DalEmployeeMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEmployeeServerResponseModel>> Update(
			int businessEntityID,
			ApiEmployeeServerRequestModel model)
		{
			var validationResult = await this.EmployeeModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolEmployeeMapper.MapModelToBO(businessEntityID, model);
				await this.EmployeeRepository.Update(this.DalEmployeeMapper.MapBOToEF(bo));

				var record = await this.EmployeeRepository.Get(businessEntityID);

				return ValidationResponseFactory<ApiEmployeeServerResponseModel>.UpdateResponse(this.BolEmployeeMapper.MapBOToModel(this.DalEmployeeMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiEmployeeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.EmployeeModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.EmployeeRepository.Delete(businessEntityID);
			}

			return response;
		}

		public async virtual Task<ApiEmployeeServerResponseModel> ByLoginID(string loginID)
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

		public async virtual Task<ApiEmployeeServerResponseModel> ByNationalIDNumber(string nationalIDNumber)
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

		public async virtual Task<ApiEmployeeServerResponseModel> ByRowguid(Guid rowguid)
		{
			Employee record = await this.EmployeeRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolEmployeeMapper.MapBOToModel(this.DalEmployeeMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiJobCandidateServerResponseModel>> JobCandidatesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<JobCandidate> records = await this.EmployeeRepository.JobCandidatesByBusinessEntityID(businessEntityID, limit, offset);

			return this.BolJobCandidateMapper.MapBOToModel(this.DalJobCandidateMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>fd5c66619c86b8e5c12b7ce3588bacec</Hash>
</Codenesium>*/