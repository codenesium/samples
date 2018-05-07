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

		public virtual POCOTeacherSkill Get(int id)
		{
			return this.teacherSkillRepository.Get(id);
		}

		public virtual List<POCOTeacherSkill> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teacherSkillRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>810c2a66912d6b73f092f2da82adf1b3</Hash>
</Codenesium>*/