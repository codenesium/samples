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
	public abstract class AbstractTeacherService : AbstractService
	{
		protected ITeacherRepository TeacherRepository { get; private set; }

		protected IApiTeacherRequestModelValidator TeacherModelValidator { get; private set; }

		protected IBOLTeacherMapper BolTeacherMapper { get; private set; }

		protected IDALTeacherMapper DalTeacherMapper { get; private set; }

		protected IBOLRateMapper BolRateMapper { get; private set; }

		protected IDALRateMapper DalRateMapper { get; private set; }
		protected IBOLTeacherXTeacherSkillMapper BolTeacherXTeacherSkillMapper { get; private set; }

		protected IDALTeacherXTeacherSkillMapper DalTeacherXTeacherSkillMapper { get; private set; }

		private ILogger logger;

		public AbstractTeacherService(
			ILogger logger,
			ITeacherRepository teacherRepository,
			IApiTeacherRequestModelValidator teacherModelValidator,
			IBOLTeacherMapper bolTeacherMapper,
			IDALTeacherMapper dalTeacherMapper,
			IBOLRateMapper bolRateMapper,
			IDALRateMapper dalRateMapper,
			IBOLTeacherXTeacherSkillMapper bolTeacherXTeacherSkillMapper,
			IDALTeacherXTeacherSkillMapper dalTeacherXTeacherSkillMapper)
			: base()
		{
			this.TeacherRepository = teacherRepository;
			this.TeacherModelValidator = teacherModelValidator;
			this.BolTeacherMapper = bolTeacherMapper;
			this.DalTeacherMapper = dalTeacherMapper;
			this.BolRateMapper = bolRateMapper;
			this.DalRateMapper = dalRateMapper;
			this.BolTeacherXTeacherSkillMapper = bolTeacherXTeacherSkillMapper;
			this.DalTeacherXTeacherSkillMapper = dalTeacherXTeacherSkillMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTeacherResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TeacherRepository.All(limit, offset);

			return this.BolTeacherMapper.MapBOToModel(this.DalTeacherMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTeacherResponseModel> Get(int id)
		{
			var record = await this.TeacherRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTeacherMapper.MapBOToModel(this.DalTeacherMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTeacherResponseModel>> Create(
			ApiTeacherRequestModel model)
		{
			CreateResponse<ApiTeacherResponseModel> response = new CreateResponse<ApiTeacherResponseModel>(await this.TeacherModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTeacherMapper.MapModelToBO(default(int), model);
				var record = await this.TeacherRepository.Create(this.DalTeacherMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTeacherMapper.MapBOToModel(this.DalTeacherMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTeacherResponseModel>> Update(
			int id,
			ApiTeacherRequestModel model)
		{
			var validationResult = await this.TeacherModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTeacherMapper.MapModelToBO(id, model);
				await this.TeacherRepository.Update(this.DalTeacherMapper.MapBOToEF(bo));

				var record = await this.TeacherRepository.Get(id);

				return new UpdateResponse<ApiTeacherResponseModel>(this.BolTeacherMapper.MapBOToModel(this.DalTeacherMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTeacherResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.TeacherModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TeacherRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiRateResponseModel>> Rates(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			List<Rate> records = await this.TeacherRepository.Rates(teacherId, limit, offset);

			return this.BolRateMapper.MapBOToModel(this.DalRateMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTeacherXTeacherSkillResponseModel>> TeacherXTeacherSkills(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			List<TeacherXTeacherSkill> records = await this.TeacherRepository.TeacherXTeacherSkills(teacherId, limit, offset);

			return this.BolTeacherXTeacherSkillMapper.MapBOToModel(this.DalTeacherXTeacherSkillMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>88ea7a47d1b88169541d234e548a75d4</Hash>
</Codenesium>*/