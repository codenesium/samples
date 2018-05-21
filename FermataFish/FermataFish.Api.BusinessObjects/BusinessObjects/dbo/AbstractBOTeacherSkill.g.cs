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
	public abstract class AbstractBOTeacherSkill: AbstractBOManager
	{
		private ITeacherSkillRepository teacherSkillRepository;
		private IApiTeacherSkillModelValidator teacherSkillModelValidator;
		private ILogger logger;

		public AbstractBOTeacherSkill(
			ILogger logger,
			ITeacherSkillRepository teacherSkillRepository,
			IApiTeacherSkillModelValidator teacherSkillModelValidator)
			: base()

		{
			this.teacherSkillRepository = teacherSkillRepository;
			this.teacherSkillModelValidator = teacherSkillModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOTeacherSkill>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teacherSkillRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOTeacherSkill> Get(int id)
		{
			return this.teacherSkillRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOTeacherSkill>> Create(
			ApiTeacherSkillModel model)
		{
			CreateResponse<POCOTeacherSkill> response = new CreateResponse<POCOTeacherSkill>(await this.teacherSkillModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOTeacherSkill record = await this.teacherSkillRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiTeacherSkillModel model)
		{
			ActionResponse response = new ActionResponse(await this.teacherSkillModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.teacherSkillRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.teacherSkillModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.teacherSkillRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c7205cc77691b10b6db5e0e79bf55728</Hash>
</Codenesium>*/