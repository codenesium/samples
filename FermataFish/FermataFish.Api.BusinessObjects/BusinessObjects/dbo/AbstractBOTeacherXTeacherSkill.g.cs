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
	public abstract class AbstractBOTeacherXTeacherSkill: AbstractBOManager
	{
		private ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository;
		private IApiTeacherXTeacherSkillModelValidator teacherXTeacherSkillModelValidator;
		private ILogger logger;

		public AbstractBOTeacherXTeacherSkill(
			ILogger logger,
			ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository,
			IApiTeacherXTeacherSkillModelValidator teacherXTeacherSkillModelValidator)
			: base()

		{
			this.teacherXTeacherSkillRepository = teacherXTeacherSkillRepository;
			this.teacherXTeacherSkillModelValidator = teacherXTeacherSkillModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOTeacherXTeacherSkill>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teacherXTeacherSkillRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOTeacherXTeacherSkill> Get(int id)
		{
			return this.teacherXTeacherSkillRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOTeacherXTeacherSkill>> Create(
			ApiTeacherXTeacherSkillModel model)
		{
			CreateResponse<POCOTeacherXTeacherSkill> response = new CreateResponse<POCOTeacherXTeacherSkill>(await this.teacherXTeacherSkillModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOTeacherXTeacherSkill record = await this.teacherXTeacherSkillRepository.Create(model);

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
				await this.teacherXTeacherSkillRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.teacherXTeacherSkillModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.teacherXTeacherSkillRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c359746dae3a8a01a50a6a54a00b5e70</Hash>
</Codenesium>*/