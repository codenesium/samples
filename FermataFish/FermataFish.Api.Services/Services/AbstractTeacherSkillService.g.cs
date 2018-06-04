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

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractTeacherSkillService: AbstractService
	{
		private ITeacherSkillRepository teacherSkillRepository;
		private IApiTeacherSkillRequestModelValidator teacherSkillModelValidator;
		private IBOLTeacherSkillMapper BOLTeacherSkillMapper;
		private IDALTeacherSkillMapper DALTeacherSkillMapper;
		private ILogger logger;

		public AbstractTeacherSkillService(
			ILogger logger,
			ITeacherSkillRepository teacherSkillRepository,
			IApiTeacherSkillRequestModelValidator teacherSkillModelValidator,
			IBOLTeacherSkillMapper bolteacherSkillMapper,
			IDALTeacherSkillMapper dalteacherSkillMapper)
			: base()

		{
			this.teacherSkillRepository = teacherSkillRepository;
			this.teacherSkillModelValidator = teacherSkillModelValidator;
			this.BOLTeacherSkillMapper = bolteacherSkillMapper;
			this.DALTeacherSkillMapper = dalteacherSkillMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTeacherSkillResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.teacherSkillRepository.All(skip, take, orderClause);

			return this.BOLTeacherSkillMapper.MapBOToModel(this.DALTeacherSkillMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTeacherSkillResponseModel> Get(int id)
		{
			var record = await teacherSkillRepository.Get(id);

			return this.BOLTeacherSkillMapper.MapBOToModel(this.DALTeacherSkillMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiTeacherSkillResponseModel>> Create(
			ApiTeacherSkillRequestModel model)
		{
			CreateResponse<ApiTeacherSkillResponseModel> response = new CreateResponse<ApiTeacherSkillResponseModel>(await this.teacherSkillModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLTeacherSkillMapper.MapModelToBO(default (int), model);
				var record = await this.teacherSkillRepository.Create(this.DALTeacherSkillMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLTeacherSkillMapper.MapBOToModel(this.DALTeacherSkillMapper.MapEFToBO(record)));
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
				var bo = this.BOLTeacherSkillMapper.MapModelToBO(id, model);
				await this.teacherSkillRepository.Update(this.DALTeacherSkillMapper.MapBOToEF(bo));
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
    <Hash>e7f4bd8b5173a9b7603944562e29c42a</Hash>
</Codenesium>*/