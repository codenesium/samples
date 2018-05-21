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
	public abstract class AbstractBODepartment: AbstractBOManager
	{
		private IDepartmentRepository departmentRepository;
		private IApiDepartmentModelValidator departmentModelValidator;
		private ILogger logger;

		public AbstractBODepartment(
			ILogger logger,
			IDepartmentRepository departmentRepository,
			IApiDepartmentModelValidator departmentModelValidator)
			: base()

		{
			this.departmentRepository = departmentRepository;
			this.departmentModelValidator = departmentModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCODepartment>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.departmentRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCODepartment> Get(short departmentID)
		{
			return this.departmentRepository.Get(departmentID);
		}

		public virtual async Task<CreateResponse<POCODepartment>> Create(
			ApiDepartmentModel model)
		{
			CreateResponse<POCODepartment> response = new CreateResponse<POCODepartment>(await this.departmentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCODepartment record = await this.departmentRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			short departmentID,
			ApiDepartmentModel model)
		{
			ActionResponse response = new ActionResponse(await this.departmentModelValidator.ValidateUpdateAsync(departmentID, model));

			if (response.Success)
			{
				await this.departmentRepository.Update(departmentID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			short departmentID)
		{
			ActionResponse response = new ActionResponse(await this.departmentModelValidator.ValidateDeleteAsync(departmentID));

			if (response.Success)
			{
				await this.departmentRepository.Delete(departmentID);
			}
			return response;
		}

		public async Task<POCODepartment> GetName(string name)
		{
			return await this.departmentRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>8780d0d67865b4214f77a4c5483bb06f</Hash>
</Codenesium>*/