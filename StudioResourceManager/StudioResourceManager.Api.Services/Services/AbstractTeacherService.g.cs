using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractTeacherService : AbstractService
	{
		protected ITeacherRepository TeacherRepository { get; private set; }

		protected IApiTeacherRequestModelValidator TeacherModelValidator { get; private set; }

		protected IBOLTeacherMapper BolTeacherMapper { get; private set; }

		protected IDALTeacherMapper DalTeacherMapper { get; private set; }

		protected IBOLEventTeacherMapper BolEventTeacherMapper { get; private set; }

		protected IDALEventTeacherMapper DalEventTeacherMapper { get; private set; }

		protected IBOLRateMapper BolRateMapper { get; private set; }

		protected IDALRateMapper DalRateMapper { get; private set; }

		protected IBOLTeacherTeacherSkillMapper BolTeacherTeacherSkillMapper { get; private set; }

		protected IDALTeacherTeacherSkillMapper DalTeacherTeacherSkillMapper { get; private set; }

		private ILogger logger;

		public AbstractTeacherService(
			ILogger logger,
			ITeacherRepository teacherRepository,
			IApiTeacherRequestModelValidator teacherModelValidator,
			IBOLTeacherMapper bolTeacherMapper,
			IDALTeacherMapper dalTeacherMapper,
			IBOLEventTeacherMapper bolEventTeacherMapper,
			IDALEventTeacherMapper dalEventTeacherMapper,
			IBOLRateMapper bolRateMapper,
			IDALRateMapper dalRateMapper,
			IBOLTeacherTeacherSkillMapper bolTeacherTeacherSkillMapper,
			IDALTeacherTeacherSkillMapper dalTeacherTeacherSkillMapper)
			: base()
		{
			this.TeacherRepository = teacherRepository;
			this.TeacherModelValidator = teacherModelValidator;
			this.BolTeacherMapper = bolTeacherMapper;
			this.DalTeacherMapper = dalTeacherMapper;
			this.BolEventTeacherMapper = bolEventTeacherMapper;
			this.DalEventTeacherMapper = dalEventTeacherMapper;
			this.BolRateMapper = bolRateMapper;
			this.DalRateMapper = dalRateMapper;
			this.BolTeacherTeacherSkillMapper = bolTeacherTeacherSkillMapper;
			this.DalTeacherTeacherSkillMapper = dalTeacherTeacherSkillMapper;
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

		public async virtual Task<List<ApiEventTeacherResponseModel>> EventTeachers(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			List<EventTeacher> records = await this.TeacherRepository.EventTeachers(teacherId, limit, offset);

			return this.BolEventTeacherMapper.MapBOToModel(this.DalEventTeacherMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiRateResponseModel>> Rates(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			List<Rate> records = await this.TeacherRepository.Rates(teacherId, limit, offset);

			return this.BolRateMapper.MapBOToModel(this.DalRateMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTeacherTeacherSkillResponseModel>> TeacherTeacherSkills(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			List<TeacherTeacherSkill> records = await this.TeacherRepository.TeacherTeacherSkills(teacherId, limit, offset);

			return this.BolTeacherTeacherSkillMapper.MapBOToModel(this.DalTeacherTeacherSkillMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTeacherResponseModel>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0)
		{
			List<Teacher> records = await this.TeacherRepository.ByEventId(eventId, limit, offset);

			return this.BolTeacherMapper.MapBOToModel(this.DalTeacherMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTeacherResponseModel>> ByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0)
		{
			List<Teacher> records = await this.TeacherRepository.ByTeacherSkillId(teacherSkillId, limit, offset);

			return this.BolTeacherMapper.MapBOToModel(this.DalTeacherMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>a91f15e81bc6e243055e43bc18890878</Hash>
</Codenesium>*/