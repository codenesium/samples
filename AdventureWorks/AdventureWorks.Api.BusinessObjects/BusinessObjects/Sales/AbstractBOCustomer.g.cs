using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOCustomer: AbstractBOManager
	{
		private ICustomerRepository customerRepository;
		private IApiCustomerRequestModelValidator customerModelValidator;
		private IBOLCustomerMapper customerMapper;
		private ILogger logger;

		public AbstractBOCustomer(
			ILogger logger,
			ICustomerRepository customerRepository,
			IApiCustomerRequestModelValidator customerModelValidator,
			IBOLCustomerMapper customerMapper)
			: base()

		{
			this.customerRepository = customerRepository;
			this.customerModelValidator = customerModelValidator;
			this.customerMapper = customerMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCustomerResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.customerRepository.All(skip, take, orderClause);

			return this.customerMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiCustomerResponseModel> Get(int customerID)
		{
			var record = await customerRepository.Get(customerID);

			return this.customerMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiCustomerResponseModel>> Create(
			ApiCustomerRequestModel model)
		{
			CreateResponse<ApiCustomerResponseModel> response = new CreateResponse<ApiCustomerResponseModel>(await this.customerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.customerMapper.MapModelToDTO(default (int), model);
				var record = await this.customerRepository.Create(dto);

				response.SetRecord(this.customerMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int customerID,
			ApiCustomerRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.customerModelValidator.ValidateUpdateAsync(customerID, model));

			if (response.Success)
			{
				var dto = this.customerMapper.MapModelToDTO(customerID, model);
				await this.customerRepository.Update(customerID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int customerID)
		{
			ActionResponse response = new ActionResponse(await this.customerModelValidator.ValidateDeleteAsync(customerID));

			if (response.Success)
			{
				await this.customerRepository.Delete(customerID);
			}
			return response;
		}

		public async Task<ApiCustomerResponseModel> GetAccountNumber(string accountNumber)
		{
			DTOCustomer record = await this.customerRepository.GetAccountNumber(accountNumber);

			return this.customerMapper.MapDTOToModel(record);
		}
		public async Task<List<ApiCustomerResponseModel>> GetTerritoryID(Nullable<int> territoryID)
		{
			List<DTOCustomer> records = await this.customerRepository.GetTerritoryID(territoryID);

			return this.customerMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>edae4946af743872e3714fda7525c215</Hash>
</Codenesium>*/