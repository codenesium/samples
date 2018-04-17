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
	public abstract class AbstractBOTeacherSkill
	{
		private ITeacherSkillRepository teacherSkillRepository;
		private ITeacherSkillModelValidator teacherSkillModelValidator;
		private ILogger logger;

		public AbstractBOTeacherSkill(
			ILogger logger,
			ITeacherSkillRepository teacherSkillRepository,
			ITeacherSkillModelValidator teacherSkillModelValidator)

		{
			this.teacherSkillRepository = teacherSkillRepository;
			this.teacherSkillModelValidator = teacherSkillModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			TeacherSkillModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.teacherSkillModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.teacherSkillRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			TeacherSkillModel model)
		{
			ActionResponse response = new ActionResponse(await this.teacherSkillModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.teacherSkillRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.teacherSkillModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.teacherSkillRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.teacherSkillRepository.GetById(id);
		}

		public virtual POCOTeacherSkill GetByIdDirect(int id)
		{
			return this.teacherSkillRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teacherSkillRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teacherSkillRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOTeacherSkill> GetWhereDirect(Expression<Func<EFTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teacherSkillRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>0683e041b845c715892ea4f5ae880b0e</Hash>
</Codenesium>*/