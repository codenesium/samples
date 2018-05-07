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
	public abstract class AbstractBODepartment
	{
		private IDepartmentRepository departmentRepository;
		private IDepartmentModelValidator departmentModelValidator;
		private ILogger logger;

		public AbstractBODepartment(
			ILogger logger,
			IDepartmentRepository departmentRepository,
			IDepartmentModelValidator departmentModelValidator)

		{
			this.departmentRepository = departmentRepository;
			this.departmentModelValidator = departmentModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<short>> Create(
			DepartmentModel model)
		{
			CreateResponse<short> response = new CreateResponse<short>(await this.departmentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				short id = this.departmentRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			short departmentID,
			DepartmentModel model)
		{
			ActionResponse response = new ActionResponse(await this.departmentModelValidator.ValidateUpdateAsync(departmentID, model));

			if (response.Success)
			{
				this.departmentRepository.Update(departmentID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			short departmentID)
		{
			ActionResponse response = new ActionResponse(await this.departmentModelValidator.ValidateDeleteAsync(departmentID));

			if (response.Success)
			{
				this.departmentRepository.Delete(departmentID);
			}
			return response;
		}

		public virtual POCODepartment Get(short departmentID)
		{
			return this.departmentRepository.Get(departmentID);
		}

		public virtual List<POCODepartment> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.departmentRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>e84984d5794b6766552ea7920e5cdc10</Hash>
</Codenesium>*/