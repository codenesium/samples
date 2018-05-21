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
	public abstract class AbstractBOEmployee: AbstractBOManager
	{
		private IEmployeeRepository employeeRepository;
		private IApiEmployeeModelValidator employeeModelValidator;
		private ILogger logger;

		public AbstractBOEmployee(
			ILogger logger,
			IEmployeeRepository employeeRepository,
			IApiEmployeeModelValidator employeeModelValidator)
			: base()

		{
			this.employeeRepository = employeeRepository;
			this.employeeModelValidator = employeeModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOEmployee>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.employeeRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOEmployee> Get(int businessEntityID)
		{
			return this.employeeRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOEmployee>> Create(
			ApiEmployeeModel model)
		{
			CreateResponse<POCOEmployee> response = new CreateResponse<POCOEmployee>(await this.employeeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOEmployee record = await this.employeeRepository.Create(model);

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
				await this.employeeRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.employeeModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.employeeRepository.Delete(businessEntityID);
			}
			return response;
		}

		public async Task<POCOEmployee> GetLoginID(string loginID)
		{
			return await this.employeeRepository.GetLoginID(loginID);
		}
		public async Task<POCOEmployee> GetNationalIDNumber(string nationalIDNumber)
		{
			return await this.employeeRepository.GetNationalIDNumber(nationalIDNumber);
		}
		public async Task<List<POCOEmployee>> GetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel,Nullable<Guid> organizationNode)
		{
			return await this.employeeRepository.GetOrganizationLevelOrganizationNode(organizationLevel,organizationNode);
		}
		public async Task<List<POCOEmployee>> GetOrganizationNode(Nullable<Guid> organizationNode)
		{
			return await this.employeeRepository.GetOrganizationNode(organizationNode);
		}
	}
}

/*<Codenesium>
    <Hash>d0ce4d7329ecdb7265ab9ecdcf6d2991</Hash>
</Codenesium>*/