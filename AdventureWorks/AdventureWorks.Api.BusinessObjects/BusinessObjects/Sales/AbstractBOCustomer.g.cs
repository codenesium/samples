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
	public abstract class AbstractBOCustomer
	{
		private ICustomerRepository customerRepository;
		private IApiCustomerModelValidator customerModelValidator;
		private ILogger logger;

		public AbstractBOCustomer(
			ILogger logger,
			ICustomerRepository customerRepository,
			IApiCustomerModelValidator customerModelValidator)

		{
			this.customerRepository = customerRepository;
			this.customerModelValidator = customerModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOCustomer> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.customerRepository.All(skip, take, orderClause);
		}

		public virtual POCOCustomer Get(int customerID)
		{
			return this.customerRepository.Get(customerID);
		}

		public virtual async Task<CreateResponse<POCOCustomer>> Create(
			ApiCustomerModel model)
		{
			CreateResponse<POCOCustomer> response = new CreateResponse<POCOCustomer>(await this.customerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOCustomer record = this.customerRepository.Create(model);
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
				this.customerRepository.Update(customerID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int customerID)
		{
			ActionResponse response = new ActionResponse(await this.customerModelValidator.ValidateDeleteAsync(customerID));

			if (response.Success)
			{
				this.customerRepository.Delete(customerID);
			}
			return response;
		}

		public POCOCustomer GetAccountNumber(string accountNumber)
		{
			return this.customerRepository.GetAccountNumber(accountNumber);
		}

		public List<POCOCustomer> GetTerritoryID(Nullable<int> territoryID)
		{
			return this.customerRepository.GetTerritoryID(territoryID);
		}
	}
}

/*<Codenesium>
    <Hash>fa2311f147d7fd54211ba01f59104383</Hash>
</Codenesium>*/