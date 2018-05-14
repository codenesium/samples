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
	public abstract class AbstractBOEmployee
	{
		private IEmployeeRepository employeeRepository;
		private IApiEmployeeModelValidator employeeModelValidator;
		private ILogger logger;

		public AbstractBOEmployee(
			ILogger logger,
			IEmployeeRepository employeeRepository,
			IApiEmployeeModelValidator employeeModelValidator)

		{
			this.employeeRepository = employeeRepository;
			this.employeeModelValidator = employeeModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOEmployee> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.employeeRepository.All(skip, take, orderClause);
		}

		public virtual POCOEmployee Get(int businessEntityID)
		{
			return this.employeeRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOEmployee>> Create(
			ApiEmployeeModel model)
		{
			CreateResponse<POCOEmployee> response = new CreateResponse<POCOEmployee>(await this.employeeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOEmployee record = this.employeeRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiEmployeeModel model)
		{
			ActionResponse response = new ActionResponse(await this.employeeModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				this.employeeRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.employeeModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				this.employeeRepository.Delete(businessEntityID);
			}
			return response;
		}

		public POCOEmployee GetLoginID(string loginID)
		{
			return this.employeeRepository.GetLoginID(loginID);
		}

		public POCOEmployee GetNationalIDNumber(string nationalIDNumber)
		{
			return this.employeeRepository.GetNationalIDNumber(nationalIDNumber);
		}

		public List<POCOEmployee> GetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel,Nullable<Guid> organizationNode)
		{
			return this.employeeRepository.GetOrganizationLevelOrganizationNode(organizationLevel,organizationNode);
		}
		public List<POCOEmployee> GetOrganizationNode(Nullable<Guid> organizationNode)
		{
			return this.employeeRepository.GetOrganizationNode(organizationNode);
		}
	}
}

/*<Codenesium>
    <Hash>e32cd97bfd7f5759fb39a81a285f1e69</Hash>
</Codenesium>*/