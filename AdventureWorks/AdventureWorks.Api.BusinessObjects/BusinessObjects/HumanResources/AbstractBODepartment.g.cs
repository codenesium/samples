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

		public virtual ApiResponse GetById(short departmentID)
		{
			return this.departmentRepository.GetById(departmentID);
		}

		public virtual POCODepartment GetByIdDirect(short departmentID)
		{
			return this.departmentRepository.GetByIdDirect(departmentID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.departmentRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.departmentRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCODepartment> GetWhereDirect(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.departmentRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>b14854cf1eabdbdd4584ff0d7c8abda1</Hash>
</Codenesium>*/