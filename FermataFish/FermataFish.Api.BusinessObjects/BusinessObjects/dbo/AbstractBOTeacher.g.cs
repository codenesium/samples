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
	public abstract class AbstractBOTeacher
	{
		private ITeacherRepository teacherRepository;
		private ITeacherModelValidator teacherModelValidator;
		private ILogger logger;

		public AbstractBOTeacher(
			ILogger logger,
			ITeacherRepository teacherRepository,
			ITeacherModelValidator teacherModelValidator)

		{
			this.teacherRepository = teacherRepository;
			this.teacherModelValidator = teacherModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			TeacherModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.teacherModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.teacherRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			TeacherModel model)
		{
			ActionResponse response = new ActionResponse(await this.teacherModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.teacherRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.teacherModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.teacherRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOTeacher Get(int id)
		{
			return this.teacherRepository.Get(id);
		}

		public virtual List<POCOTeacher> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teacherRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>eaafcc95bce3e4f6bab6ff81fc56769d</Hash>
</Codenesium>*/