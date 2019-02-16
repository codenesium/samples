using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractCustomerService : AbstractService
	{
		private IMediator mediator;

		protected ICustomerRepository CustomerRepository { get; private set; }

		protected IApiCustomerServerRequestModelValidator CustomerModelValidator { get; private set; }

		protected IDALCustomerMapper DalCustomerMapper { get; private set; }

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }

		private ILogger logger;

		public AbstractCustomerService(
			ILogger logger,
			IMediator mediator,
			ICustomerRepository customerRepository,
			IApiCustomerServerRequestModelValidator customerModelValidator,
			IDALCustomerMapper dalCustomerMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
			: base()
		{
			this.CustomerRepository = customerRepository;
			this.CustomerModelValidator = customerModelValidator;
			this.DalCustomerMapper = dalCustomerMapper;
			this.DalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCustomerServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.CustomerRepository.All(limit, offset, query);

			return this.DalCustomerMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiCustomerServerResponseModel> Get(int customerID)
		{
			var record = await this.CustomerRepository.Get(customerID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCustomerMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCustomerServerResponseModel>> Create(
			ApiCustomerServerRequestModel model)
		{
			CreateResponse<ApiCustomerServerResponseModel> response = ValidationResponseFactory<ApiCustomerServerResponseModel>.CreateResponse(await this.CustomerModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalCustomerMapper.MapModelToBO(default(int), model);
				var record = await this.CustomerRepository.Create(bo);

				response.SetRecord(this.DalCustomerMapper.MapBOToModel(record));
				await this.mediator.Publish(new CustomerCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCustomerServerResponseModel>> Update(
			int customerID,
			ApiCustomerServerRequestModel model)
		{
			var validationResult = await this.CustomerModelValidator.ValidateUpdateAsync(customerID, model);

			if (validationResult.IsValid)
			{
				var bo = this.DalCustomerMapper.MapModelToBO(customerID, model);
				await this.CustomerRepository.Update(bo);

				var record = await this.CustomerRepository.Get(customerID);

				var apiModel = this.DalCustomerMapper.MapBOToModel(record);
				await this.mediator.Publish(new CustomerUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCustomerServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCustomerServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int customerID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CustomerModelValidator.ValidateDeleteAsync(customerID));

			if (response.Success)
			{
				await this.CustomerRepository.Delete(customerID);

				await this.mediator.Publish(new CustomerDeletedNotification(customerID));
			}

			return response;
		}

		public async virtual Task<ApiCustomerServerResponseModel> ByAccountNumber(string accountNumber)
		{
			Customer record = await this.CustomerRepository.ByAccountNumber(accountNumber);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCustomerMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<ApiCustomerServerResponseModel> ByRowguid(Guid rowguid)
		{
			Customer record = await this.CustomerRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCustomerMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<List<ApiCustomerServerResponseModel>> ByTerritoryID(int? territoryID, int limit = 0, int offset = int.MaxValue)
		{
			List<Customer> records = await this.CustomerRepository.ByTerritoryID(territoryID, limit, offset);

			return this.DalCustomerMapper.MapBOToModel(records);
		}

		public async virtual Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersByCustomerID(int customerID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderHeader> records = await this.CustomerRepository.SalesOrderHeadersByCustomerID(customerID, limit, offset);

			return this.DalSalesOrderHeaderMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>43581ecd98012bc526e916199a4175b7</Hash>
</Codenesium>*/