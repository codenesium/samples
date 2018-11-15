using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractCustomerService : AbstractService
	{
		protected ICustomerRepository CustomerRepository { get; private set; }

		protected IApiCustomerServerRequestModelValidator CustomerModelValidator { get; private set; }

		protected IBOLCustomerMapper BolCustomerMapper { get; private set; }

		protected IDALCustomerMapper DalCustomerMapper { get; private set; }

		protected IBOLCustomerCommunicationMapper BolCustomerCommunicationMapper { get; private set; }

		protected IDALCustomerCommunicationMapper DalCustomerCommunicationMapper { get; private set; }

		private ILogger logger;

		public AbstractCustomerService(
			ILogger logger,
			ICustomerRepository customerRepository,
			IApiCustomerServerRequestModelValidator customerModelValidator,
			IBOLCustomerMapper bolCustomerMapper,
			IDALCustomerMapper dalCustomerMapper,
			IBOLCustomerCommunicationMapper bolCustomerCommunicationMapper,
			IDALCustomerCommunicationMapper dalCustomerCommunicationMapper)
			: base()
		{
			this.CustomerRepository = customerRepository;
			this.CustomerModelValidator = customerModelValidator;
			this.BolCustomerMapper = bolCustomerMapper;
			this.DalCustomerMapper = dalCustomerMapper;
			this.BolCustomerCommunicationMapper = bolCustomerCommunicationMapper;
			this.DalCustomerCommunicationMapper = dalCustomerCommunicationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCustomerServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CustomerRepository.All(limit, offset);

			return this.BolCustomerMapper.MapBOToModel(this.DalCustomerMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCustomerServerResponseModel> Get(int id)
		{
			var record = await this.CustomerRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCustomerMapper.MapBOToModel(this.DalCustomerMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCustomerServerResponseModel>> Create(
			ApiCustomerServerRequestModel model)
		{
			CreateResponse<ApiCustomerServerResponseModel> response = ValidationResponseFactory<ApiCustomerServerResponseModel>.CreateResponse(await this.CustomerModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolCustomerMapper.MapModelToBO(default(int), model);
				var record = await this.CustomerRepository.Create(this.DalCustomerMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCustomerMapper.MapBOToModel(this.DalCustomerMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCustomerServerResponseModel>> Update(
			int id,
			ApiCustomerServerRequestModel model)
		{
			var validationResult = await this.CustomerModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCustomerMapper.MapModelToBO(id, model);
				await this.CustomerRepository.Update(this.DalCustomerMapper.MapBOToEF(bo));

				var record = await this.CustomerRepository.Get(id);

				return ValidationResponseFactory<ApiCustomerServerResponseModel>.UpdateResponse(this.BolCustomerMapper.MapBOToModel(this.DalCustomerMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiCustomerServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CustomerModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.CustomerRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiCustomerCommunicationServerResponseModel>> CustomerCommunicationsByCustomerId(int customerId, int limit = int.MaxValue, int offset = 0)
		{
			List<CustomerCommunication> records = await this.CustomerRepository.CustomerCommunicationsByCustomerId(customerId, limit, offset);

			return this.BolCustomerCommunicationMapper.MapBOToModel(this.DalCustomerCommunicationMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>a1c288436c735f20bc222277eecb9b22</Hash>
</Codenesium>*/