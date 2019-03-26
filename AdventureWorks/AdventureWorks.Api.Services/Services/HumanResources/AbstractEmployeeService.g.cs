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
		private MediatR.IMediator mediator;

		protected IEmployeeRepository EmployeeRepository { get; private set; }

		protected IApiEmployeeServerRequestModelValidator EmployeeModelValidator { get; private set; }

		protected IDALEmployeeMapper DalEmployeeMapper { get; private set; }

		protected IDALJobCandidateMapper DalJobCandidateMapper { get; private set; }

		private ILogger logger;

		public AbstractEmployeeService(
			ILogger logger,
			MediatR.IMediator mediator,
			IEmployeeRepository employeeRepository,
			IApiEmployeeServerRequestModelValidator employeeModelValidator,
			IDALEmployeeMapper dalEmployeeMapper,
			IDALJobCandidateMapper dalJobCandidateMapper)
			: base()
		{
			this.EmployeeRepository = employeeRepository;
			this.EmployeeModelValidator = employeeModelValidator;
			this.DalEmployeeMapper = dalEmployeeMapper;
			this.DalJobCandidateMapper = dalJobCandidateMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiEmployeeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Employee> records = await this.EmployeeRepository.All(limit, offset, query);

			return this.DalEmployeeMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiEmployeeServerResponseModel> Get(int businessEntityID)
		{
			Employee record = await this.EmployeeRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalEmployeeMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiEmployeeServerResponseModel>> Create(
			ApiEmployeeServerRequestModel model)
		{
			CreateResponse<ApiEmployeeServerResponseModel> response = ValidationResponseFactory<ApiEmployeeServerResponseModel>.CreateResponse(await this.EmployeeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Employee record = this.DalEmployeeMapper.MapModelToEntity(default(int), model);
				record = await this.EmployeeRepository.Create(record);

				response.SetRecord(this.DalEmployeeMapper.MapEntityToModel(record));
				await this.mediator.Publish(new EmployeeCreatedNotification(response.Record));
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
				Employee record = this.DalEmployeeMapper.MapModelToEntity(businessEntityID, model);
				await this.EmployeeRepository.Update(record);

				record = await this.EmployeeRepository.Get(businessEntityID);

				ApiEmployeeServerResponseModel apiModel = this.DalEmployeeMapper.MapEntityToModel(record);
				await this.mediator.Publish(new EmployeeUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiEmployeeServerResponseModel>.UpdateResponse(apiModel);
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

				await this.mediator.Publish(new EmployeeDeletedNotification(businessEntityID));
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
				return this.DalEmployeeMapper.MapEntityToModel(record);
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
				return this.DalEmployeeMapper.MapEntityToModel(record);
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
				return this.DalEmployeeMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiJobCandidateServerResponseModel>> JobCandidatesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<JobCandidate> records = await this.EmployeeRepository.JobCandidatesByBusinessEntityID(businessEntityID, limit, offset);

			return this.DalJobCandidateMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>f4dbff2eaa416dab26d4952b87cfd131</Hash>
</Codenesium>*/