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
		private IApiCustomerModelValidator customerModelValidator;
		private ILogger logger;

		public AbstractBOCustomer(
			ILogger logger,
			ICustomerRepository customerRepository,
			IApiCustomerModelValidator customerModelValidator)
			: base()

		{
			this.customerRepository = customerRepository;
			this.customerModelValidator = customerModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOCustomer>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.customerRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOCustomer> Get(int customerID)
		{
			return this.customerRepository.Get(customerID);
		}

		public virtual async Task<CreateResponse<POCOCustomer>> Create(
			ApiCustomerModel model)
		{
			CreateResponse<POCOCustomer> response = new CreateResponse<POCOCustomer>(await this.customerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOCustomer record = await this.customerRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int customerID,
			ApiCustomerModel model)
		{
			ActionResponse response = new ActionResponse(await this.customerModelValidator.ValidateUpdateAsync(customerID, model));

			if (response.Success)
			{
				await this.customerRepository.Update(customerID, model);
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

		public async Task<POCOCustomer> GetAccountNumber(string accountNumber)
		{
			return await this.customerRepository.GetAccountNumber(accountNumber);
		}
		public async Task<List<POCOCustomer>> GetTerritoryID(Nullable<int> territoryID)
		{
			return await this.customerRepository.GetTerritoryID(territoryID);
		}
	}
}

/*<Codenesium>
    <Hash>a8f049c2703efba4abd71363159050d0</Hash>
</Codenesium>*/