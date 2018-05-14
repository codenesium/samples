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

		public virtual List<POCOTeacherSkill> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teacherSkillRepository.All(skip, take, orderClause);
		}

		public virtual POCOTeacherSkill Get(int id)
		{
			return this.teacherSkillRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOTeacherSkill>> Create(
			TeacherSkillModel model)
		{
			CreateResponse<POCOTeacherSkill> response = new CreateResponse<POCOTeacherSkill>(await this.teacherSkillModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOTeacherSkill record = this.teacherSkillRepository.Create(model);
				response.SetRecord(record);
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
	}
}

/*<Codenesium>
    <Hash>5bd966b11c297aaea2ac92a14cedac13</Hash>
</Codenesium>*/