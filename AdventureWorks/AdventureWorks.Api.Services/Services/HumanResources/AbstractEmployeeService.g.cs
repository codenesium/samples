using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractEmployeeService : AbstractService
	{
		private IMediator mediator;

		protected IEmployeeRepository EmployeeRepository { get; private set; }

		protected IApiEmployeeServerRequestModelValidator EmployeeModelValidator { get; private set; }

		protected IDALEmployeeMapper DalEmployeeMapper { get; private set; }

		protected IDALJobCandidateMapper DalJobCandidateMapper { get; private set; }

		private ILogger logger;

		public AbstractEmployeeService(
			ILogger logger,
			IMediator mediator,
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
			var records = await this.EmployeeRepository.All(limit, offset, query);

			return this.DalEmployeeMapper.MapBOToModel(records);
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
				return this.DalEmployeeMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiEmployeeServerResponseModel>> Create(
			ApiEmployeeServerRequestModel model)
		{
			CreateResponse<ApiEmployeeServerResponseModel> response = ValidationResponseFactory<ApiEmployeeServerResponseModel>.CreateResponse(await this.EmployeeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalEmployeeMapper.MapModelToBO(default(int), model);
				var record = await this.EmployeeRepository.Create(bo);

				response.SetRecord(this.DalEmployeeMapper.MapBOToModel(record));
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
				var bo = this.DalEmployeeMapper.MapModelToBO(businessEntityID, model);
				await this.EmployeeRepository.Update(bo);

				var record = await this.EmployeeRepository.Get(businessEntityID);

				var apiModel = this.DalEmployeeMapper.MapBOToModel(record);
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
				return this.DalEmployeeMapper.MapBOToModel(record);
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
				return this.DalEmployeeMapper.MapBOToModel(record);
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
				return this.DalEmployeeMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<List<ApiJobCandidateServerResponseModel>> JobCandidatesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<JobCandidate> records = await this.EmployeeRepository.JobCandidatesByBusinessEntityID(businessEntityID, limit, offset);

			return this.DalJobCandidateMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>aed54c8ef75553792eb71761294cfe2e</Hash>
</Codenesium>*/