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
		private IApiTeacherXTeacherSkillRequestModelValidator teacherXTeacherSkillModelValidator;
		private IBOLTeacherXTeacherSkillMapper teacherXTeacherSkillMapper;
		private ILogger logger;

		public AbstractBOTeacherXTeacherSkill(
			ILogger logger,
			ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository,
			IApiTeacherXTeacherSkillRequestModelValidator teacherXTeacherSkillModelValidator,
			IBOLTeacherXTeacherSkillMapper teacherXTeacherSkillMapper)
			: base()

		{
			this.teacherXTeacherSkillRepository = teacherXTeacherSkillRepository;
			this.teacherXTeacherSkillModelValidator = teacherXTeacherSkillModelValidator;
			this.teacherXTeacherSkillMapper = teacherXTeacherSkillMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTeacherXTeacherSkillResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.teacherXTeacherSkillRepository.All(skip, take, orderClause);

			return this.teacherXTeacherSkillMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiTeacherXTeacherSkillResponseModel> Get(int id)
		{
			var record = await teacherXTeacherSkillRepository.Get(id);

			return this.teacherXTeacherSkillMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiTeacherXTeacherSkillResponseModel>> Create(
			ApiTeacherXTeacherSkillRequestModel model)
		{
			CreateResponse<ApiTeacherXTeacherSkillResponseModel> response = new CreateResponse<ApiTeacherXTeacherSkillResponseModel>(await this.teacherXTeacherSkillModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.teacherXTeacherSkillMapper.MapModelToDTO(default (int), model);
				var record = await this.teacherXTeacherSkillRepository.Create(dto);

				response.SetRecord(this.teacherXTeacherSkillMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiTeacherXTeacherSkillRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.teacherXTeacherSkillModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.teacherXTeacherSkillMapper.MapModelToDTO(id, model);
				await this.teacherXTeacherSkillRepository.Update(id, dto);
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
    <Hash>06e183e6534c7d506d8ae4089322988b</Hash>
</Codenesium>*/