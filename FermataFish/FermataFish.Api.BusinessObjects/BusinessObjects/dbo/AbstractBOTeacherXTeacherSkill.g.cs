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
	public abstract class AbstractBOTeacherXTeacherSkill
	{
		private ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository;
		private IApiTeacherXTeacherSkillModelValidator teacherXTeacherSkillModelValidator;
		private ILogger logger;

		public AbstractBOTeacherXTeacherSkill(
			ILogger logger,
			ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository,
			IApiTeacherXTeacherSkillModelValidator teacherXTeacherSkillModelValidator)

		{
			this.teacherXTeacherSkillRepository = teacherXTeacherSkillRepository;
			this.teacherXTeacherSkillModelValidator = teacherXTeacherSkillModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOTeacherXTeacherSkill> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teacherXTeacherSkillRepository.All(skip, take, orderClause);
		}

		public virtual POCOTeacherXTeacherSkill Get(int id)
		{
			return this.teacherXTeacherSkillRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOTeacherXTeacherSkill>> Create(
			ApiTeacherXTeacherSkillModel model)
		{
			CreateResponse<POCOTeacherXTeacherSkill> response = new CreateResponse<POCOTeacherXTeacherSkill>(await this.teacherXTeacherSkillModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOTeacherXTeacherSkill record = this.teacherXTeacherSkillRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiTeacherXTeacherSkillModel model)
		{
			ActionResponse response = new ActionResponse(await this.teacherXTeacherSkillModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.teacherXTeacherSkillRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.teacherXTeacherSkillModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.teacherXTeacherSkillRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b2fdbd78562c4c4c897370415094fbe4</Hash>
</Codenesium>*/