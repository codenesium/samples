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
		private ICustomerModelValidator customerModelValidator;
		private ILogger logger;

		public AbstractBOCustomer(
			ILogger logger,
			ICustomerRepository customerRepository,
			ICustomerModelValidator customerModelValidator)

		{
			this.customerRepository = customerRepository;
			this.customerModelValidator = customerModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			CustomerModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.customerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.customerRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int customerID,
			CustomerModel model)
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

		public virtual POCOCustomer Get(int customerID)
		{
			return this.customerRepository.Get(customerID);
		}

		public virtual List<POCOCustomer> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.customerRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>c6fea29139d156ba1cdda926c6889884</Hash>
</Codenesium>*/