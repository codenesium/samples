using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOStudent
	{
		private IStudentRepository studentRepository;
		private IStudentModelValidator studentModelValidator;
		private ILogger logger;

		public AbstractBOStudent(
			ILogger logger,
			IStudentRepository studentRepository,
			IStudentModelValidator studentModelValidator)

		{
			this.studentRepository = studentRepository;
			this.studentModelValidator = studentModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			StudentModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.studentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.studentRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			StudentModel model)
		{
			ActionResponse response = new ActionResponse(await this.studentModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.studentRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.studentModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.studentRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.studentRepository.GetById(id);
		}

		public virtual POCOStudent GetByIdDirect(int id)
		{
			return this.studentRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.studentRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.studentRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOStudent> GetWhereDirect(Expression<Func<EFStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.studentRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>249140615700aae23a3b1008e8c24c72</Hash>
</Codenesium>*/