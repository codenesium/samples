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
		private IApiTeacherSkillRequestModelValidator teacherSkillModelValidator;
		private IBOLTeacherSkillMapper teacherSkillMapper;
		private ILogger logger;

		public AbstractBOTeacherSkill(
			ILogger logger,
			ITeacherSkillRepository teacherSkillRepository,
			IApiTeacherSkillRequestModelValidator teacherSkillModelValidator,
			IBOLTeacherSkillMapper teacherSkillMapper)
			: base()

		{
			this.teacherSkillRepository = teacherSkillRepository;
			this.teacherSkillModelValidator = teacherSkillModelValidator;
			this.teacherSkillMapper = teacherSkillMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTeacherSkillResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.teacherSkillRepository.All(skip, take, orderClause);

			return this.teacherSkillMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiTeacherSkillResponseModel> Get(int id)
		{
			var record = await teacherSkillRepository.Get(id);

			return this.teacherSkillMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiTeacherSkillResponseModel>> Create(
			ApiTeacherSkillRequestModel model)
		{
			CreateResponse<ApiTeacherSkillResponseModel> response = new CreateResponse<ApiTeacherSkillResponseModel>(await this.teacherSkillModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.teacherSkillMapper.MapModelToDTO(default (int), model);
				var record = await this.teacherSkillRepository.Create(dto);

				response.SetRecord(this.teacherSkillMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiTeacherSkillRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.teacherSkillModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.teacherSkillMapper.MapModelToDTO(id, model);
				await this.teacherSkillRepository.Update(id, dto);
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
    <Hash>08320e2be3ef2db3b664ee323fbddbfd</Hash>
</Codenesium>*/