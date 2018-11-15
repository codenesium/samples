using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractCustomerCommunicationService : AbstractService
	{
		protected ICustomerCommunicationRepository CustomerCommunicationRepository { get; private set; }

		protected IApiCustomerCommunicationServerRequestModelValidator CustomerCommunicationModelValidator { get; private set; }

		protected IBOLCustomerCommunicationMapper BolCustomerCommunicationMapper { get; private set; }

		protected IDALCustomerCommunicationMapper DalCustomerCommunicationMapper { get; private set; }

		private ILogger logger;

		public AbstractCustomerCommunicationService(
			ILogger logger,
			ICustomerCommunicationRepository customerCommunicationRepository,
			IApiCustomerCommunicationServerRequestModelValidator customerCommunicationModelValidator,
			IBOLCustomerCommunicationMapper bolCustomerCommunicationMapper,
			IDALCustomerCommunicationMapper dalCustomerCommunicationMapper)
			: base()
		{
			this.CustomerCommunicationRepository = customerCommunicationRepository;
			this.CustomerCommunicationModelValidator = customerCommunicationModelValidator;
			this.BolCustomerCommunicationMapper = bolCustomerCommunicationMapper;
			this.DalCustomerCommunicationMapper = dalCustomerCommunicationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCustomerCommunicationServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CustomerCommunicationRepository.All(limit, offset);

			return this.BolCustomerCommunicationMapper.MapBOToModel(this.DalCustomerCommunicationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCustomerCommunicationServerResponseModel> Get(int id)
		{
			var record = await this.CustomerCommunicationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCustomerCommunicationMapper.MapBOToModel(this.DalCustomerCommunicationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCustomerCommunicationServerResponseModel>> Create(
			ApiCustomerCommunicationServerRequestModel model)
		{
			CreateResponse<ApiCustomerCommunicationServerResponseModel> response = ValidationResponseFactory<ApiCustomerCommunicationServerResponseModel>.CreateResponse(await this.CustomerCommunicationModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolCustomerCommunicationMapper.MapModelToBO(default(int), model);
				var record = await this.CustomerCommunicationRepository.Create(this.DalCustomerCommunicationMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCustomerCommunicationMapper.MapBOToModel(this.DalCustomerCommunicationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCustomerCommunicationServerResponseModel>> Update(
			int id,
			ApiCustomerCommunicationServerRequestModel model)
		{
			var validationResult = await this.CustomerCommunicationModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCustomerCommunicationMapper.MapModelToBO(id, model);
				await this.CustomerCommunicationRepository.Update(this.DalCustomerCommunicationMapper.MapBOToEF(bo));

				var record = await this.CustomerCommunicationRepository.Get(id);

				return ValidationResponseFactory<ApiCustomerCommunicationServerResponseModel>.UpdateResponse(this.BolCustomerCommunicationMapper.MapBOToModel(this.DalCustomerCommunicationMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiCustomerCommunicationServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CustomerCommunicationModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.CustomerCommunicationRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiCustomerCommunicationServerResponseModel>> ByCustomerId(int customerId, int limit = 0, int offset = int.MaxValue)
		{
			List<CustomerCommunication> records = await this.CustomerCommunicationRepository.ByCustomerId(customerId, limit, offset);

			return this.BolCustomerCommunicationMapper.MapBOToModel(this.DalCustomerCommunicationMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiCustomerCommunicationServerResponseModel>> ByEmployeeId(int employeeId, int limit = 0, int offset = int.MaxValue)
		{
			List<CustomerCommunication> records = await this.CustomerCommunicationRepository.ByEmployeeId(employeeId, limit, offset);

			return this.BolCustomerCommunicationMapper.MapBOToModel(this.DalCustomerCommunicationMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>e97ee506d0873145e99a6105cca2cdd6</Hash>
</Codenesium>*/