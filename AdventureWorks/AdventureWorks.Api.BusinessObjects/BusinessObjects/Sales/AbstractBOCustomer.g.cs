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

		public virtual ApiResponse GetById(int customerID)
		{
			return this.customerRepository.GetById(customerID);
		}

		public virtual POCOCustomer GetByIdDirect(int customerID)
		{
			return this.customerRepository.GetByIdDirect(customerID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCustomer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.customerRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.customerRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOCustomer> GetWhereDirect(Expression<Func<EFCustomer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.customerRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>8bbb15261ccaf62f9fe7a03d79b5d3c4</Hash>
</Codenesium>*/