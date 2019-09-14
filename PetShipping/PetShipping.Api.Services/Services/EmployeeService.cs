using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class EmployeeService : AbstractService, IEmployeeService
	{
		private MediatR.IMediator mediator;

		protected IEmployeeRepository EmployeeRepository { get; private set; }

		protected IApiEmployeeServerRequestModelValidator EmployeeModelValidator { get; private set; }

		protected IDALEmployeeMapper DalEmployeeMapper { get; private set; }

		protected IDALCustomerCommunicationMapper DalCustomerCommunicationMapper { get; private set; }

		protected IDALPipelineStepMapper DalPipelineStepMapper { get; private set; }

		protected IDALPipelineStepNoteMapper DalPipelineStepNoteMapper { get; private set; }

		private ILogger logger;

		public EmployeeService(
			ILogger<IEmployeeService> logger,
			MediatR.IMediator mediator,
			IEmployeeRepository employeeRepository,
			IApiEmployeeServerRequestModelValidator employeeModelValidator,
			IDALEmployeeMapper dalEmployeeMapper,
			IDALCustomerCommunicationMapper dalCustomerCommunicationMapper,
			IDALPipelineStepMapper dalPipelineStepMapper,
			IDALPipelineStepNoteMapper dalPipelineStepNoteMapper)
			: base()
		{
			this.EmployeeRepository = employeeRepository;
			this.EmployeeModelValidator = employeeModelValidator;
			this.DalEmployeeMapper = dalEmployeeMapper;
			this.DalCustomerCommunicationMapper = dalCustomerCommunicationMapper;
			this.DalPipelineStepMapper = dalPipelineStepMapper;
			this.DalPipelineStepNoteMapper = dalPipelineStepNoteMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiEmployeeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Employee> records = await this.EmployeeRepository.All(limit, offset, query);

			return this.DalEmployeeMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiEmployeeServerResponseModel> Get(int id)
		{
			Employee record = await this.EmployeeRepository.Get(id);

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
			int id,
			ApiEmployeeServerRequestModel model)
		{
			var validationResult = await this.EmployeeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Employee record = this.DalEmployeeMapper.MapModelToEntity(id, model);
				await this.EmployeeRepository.Update(record);

				record = await this.EmployeeRepository.Get(id);

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
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.EmployeeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.EmployeeRepository.Delete(id);

				await this.mediator.Publish(new EmployeeDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiCustomerCommunicationServerResponseModel>> CustomerCommunicationsByEmployeeId(int employeeId, int limit = int.MaxValue, int offset = 0)
		{
			List<CustomerCommunication> records = await this.EmployeeRepository.CustomerCommunicationsByEmployeeId(employeeId, limit, offset);

			return this.DalCustomerCommunicationMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPipelineStepServerResponseModel>> PipelineStepsByShipperId(int shipperId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStep> records = await this.EmployeeRepository.PipelineStepsByShipperId(shipperId, limit, offset);

			return this.DalPipelineStepMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPipelineStepNoteServerResponseModel>> PipelineStepNotesByEmployeeId(int employeeId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStepNote> records = await this.EmployeeRepository.PipelineStepNotesByEmployeeId(employeeId, limit, offset);

			return this.DalPipelineStepNoteMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>92f60c1800310702982a16a0a2ddedd8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/