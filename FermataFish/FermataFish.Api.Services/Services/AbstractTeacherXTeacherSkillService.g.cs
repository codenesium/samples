using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractTeacherXTeacherSkillService : AbstractService
	{
		protected ITeacherXTeacherSkillRepository TeacherXTeacherSkillRepository { get; private set; }

		protected IApiTeacherXTeacherSkillRequestModelValidator TeacherXTeacherSkillModelValidator { get; private set; }

		protected IBOLTeacherXTeacherSkillMapper BolTeacherXTeacherSkillMapper { get; private set; }

		protected IDALTeacherXTeacherSkillMapper DalTeacherXTeacherSkillMapper { get; private set; }

		private ILogger logger;

		public AbstractTeacherXTeacherSkillService(
			ILogger logger,
			ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository,
			IApiTeacherXTeacherSkillRequestModelValidator teacherXTeacherSkillModelValidator,
			IBOLTeacherXTeacherSkillMapper bolTeacherXTeacherSkillMapper,
			IDALTeacherXTeacherSkillMapper dalTeacherXTeacherSkillMapper)
			: base()
		{
			this.TeacherXTeacherSkillRepository = teacherXTeacherSkillRepository;
			this.TeacherXTeacherSkillModelValidator = teacherXTeacherSkillModelValidator;
			this.BolTeacherXTeacherSkillMapper = bolTeacherXTeacherSkillMapper;
			this.DalTeacherXTeacherSkillMapper = dalTeacherXTeacherSkillMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTeacherXTeacherSkillResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TeacherXTeacherSkillRepository.All(limit, offset);

			return this.BolTeacherXTeacherSkillMapper.MapBOToModel(this.DalTeacherXTeacherSkillMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTeacherXTeacherSkillResponseModel> Get(int id)
		{
			var record = await this.TeacherXTeacherSkillRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTeacherXTeacherSkillMapper.MapBOToModel(this.DalTeacherXTeacherSkillMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTeacherXTeacherSkillResponseModel>> Create(
			ApiTeacherXTeacherSkillRequestModel model)
		{
			CreateResponse<ApiTeacherXTeacherSkillResponseModel> response = new CreateResponse<ApiTeacherXTeacherSkillResponseModel>(await this.TeacherXTeacherSkillModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTeacherXTeacherSkillMapper.MapModelToBO(default(int), model);
				var record = await this.TeacherXTeacherSkillRepository.Create(this.DalTeacherXTeacherSkillMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTeacherXTeacherSkillMapper.MapBOToModel(this.DalTeacherXTeacherSkillMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTeacherXTeacherSkillResponseModel>> Update(
			int id,
			ApiTeacherXTeacherSkillRequestModel model)
		{
			var validationResult = await this.TeacherXTeacherSkillModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTeacherXTeacherSkillMapper.MapModelToBO(id, model);
				await this.TeacherXTeacherSkillRepository.Update(this.DalTeacherXTeacherSkillMapper.MapBOToEF(bo));

				var record = await this.TeacherXTeacherSkillRepository.Get(id);

				return new UpdateResponse<ApiTeacherXTeacherSkillResponseModel>(this.BolTeacherXTeacherSkillMapper.MapBOToModel(this.DalTeacherXTeacherSkillMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTeacherXTeacherSkillResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.TeacherXTeacherSkillModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TeacherXTeacherSkillRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bf068d2216a12a1403bc8a4c1a8ff86a</Hash>
</Codenesium>*/