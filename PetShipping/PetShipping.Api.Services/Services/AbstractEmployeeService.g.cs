using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractEmployeeService : AbstractService
	{
		private IMediator mediator;

		protected IEmployeeRepository EmployeeRepository { get; private set; }

		protected IApiEmployeeServerRequestModelValidator EmployeeModelValidator { get; private set; }

		protected IBOLEmployeeMapper BolEmployeeMapper { get; private set; }

		protected IDALEmployeeMapper DalEmployeeMapper { get; private set; }

		protected IBOLCustomerCommunicationMapper BolCustomerCommunicationMapper { get; private set; }

		protected IDALCustomerCommunicationMapper DalCustomerCommunicationMapper { get; private set; }

		protected IBOLPipelineStepMapper BolPipelineStepMapper { get; private set; }

		protected IDALPipelineStepMapper DalPipelineStepMapper { get; private set; }

		protected IBOLPipelineStepNoteMapper BolPipelineStepNoteMapper { get; private set; }

		protected IDALPipelineStepNoteMapper DalPipelineStepNoteMapper { get; private set; }

		private ILogger logger;

		public AbstractEmployeeService(
			ILogger logger,
			IMediator mediator,
			IEmployeeRepository employeeRepository,
			IApiEmployeeServerRequestModelValidator employeeModelValidator,
			IBOLEmployeeMapper bolEmployeeMapper,
			IDALEmployeeMapper dalEmployeeMapper,
			IBOLCustomerCommunicationMapper bolCustomerCommunicationMapper,
			IDALCustomerCommunicationMapper dalCustomerCommunicationMapper,
			IBOLPipelineStepMapper bolPipelineStepMapper,
			IDALPipelineStepMapper dalPipelineStepMapper,
			IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper,
			IDALPipelineStepNoteMapper dalPipelineStepNoteMapper)
			: base()
		{
			this.EmployeeRepository = employeeRepository;
			this.EmployeeModelValidator = employeeModelValidator;
			this.BolEmployeeMapper = bolEmployeeMapper;
			this.DalEmployeeMapper = dalEmployeeMapper;
			this.BolCustomerCommunicationMapper = bolCustomerCommunicationMapper;
			this.DalCustomerCommunicationMapper = dalCustomerCommunicationMapper;
			this.BolPipelineStepMapper = bolPipelineStepMapper;
			this.DalPipelineStepMapper = dalPipelineStepMapper;
			this.BolPipelineStepNoteMapper = bolPipelineStepNoteMapper;
			this.DalPipelineStepNoteMapper = dalPipelineStepNoteMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiEmployeeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.EmployeeRepository.All(limit, offset);

			return this.BolEmployeeMapper.MapBOToModel(this.DalEmployeeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEmployeeServerResponseModel> Get(int id)
		{
			var record = await this.EmployeeRepository.Get(id);

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

				var businessObject = this.DalEmployeeMapper.MapEFToBO(record);
				response.SetRecord(this.BolEmployeeMapper.MapBOToModel(businessObject));
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
				var bo = this.BolEmployeeMapper.MapModelToBO(id, model);
				await this.EmployeeRepository.Update(this.DalEmployeeMapper.MapBOToEF(bo));

				var record = await this.EmployeeRepository.Get(id);

				var businessObject = this.DalEmployeeMapper.MapEFToBO(record);
				var apiModel = this.BolEmployeeMapper.MapBOToModel(businessObject);
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

			return this.BolCustomerCommunicationMapper.MapBOToModel(this.DalCustomerCommunicationMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPipelineStepServerResponseModel>> PipelineStepsByShipperId(int shipperId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStep> records = await this.EmployeeRepository.PipelineStepsByShipperId(shipperId, limit, offset);

			return this.BolPipelineStepMapper.MapBOToModel(this.DalPipelineStepMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPipelineStepNoteServerResponseModel>> PipelineStepNotesByEmployeeId(int employeeId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStepNote> records = await this.EmployeeRepository.PipelineStepNotesByEmployeeId(employeeId, limit, offset);

			return this.BolPipelineStepNoteMapper.MapBOToModel(this.DalPipelineStepNoteMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>34319076d799d7075305f054fb045c8c</Hash>
</Codenesium>*/