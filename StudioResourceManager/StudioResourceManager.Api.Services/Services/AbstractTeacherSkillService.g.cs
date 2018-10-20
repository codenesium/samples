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
	public abstract class AbstractTeacherSkillService : AbstractService
	{
		protected ITeacherSkillRepository TeacherSkillRepository { get; private set; }

		protected IApiTeacherSkillRequestModelValidator TeacherSkillModelValidator { get; private set; }

		protected IBOLTeacherSkillMapper BolTeacherSkillMapper { get; private set; }

		protected IDALTeacherSkillMapper DalTeacherSkillMapper { get; private set; }

		protected IBOLRateMapper BolRateMapper { get; private set; }

		protected IDALRateMapper DalRateMapper { get; private set; }

		protected IBOLTeacherTeacherSkillMapper BolTeacherTeacherSkillMapper { get; private set; }

		protected IDALTeacherTeacherSkillMapper DalTeacherTeacherSkillMapper { get; private set; }

		private ILogger logger;

		public AbstractTeacherSkillService(
			ILogger logger,
			ITeacherSkillRepository teacherSkillRepository,
			IApiTeacherSkillRequestModelValidator teacherSkillModelValidator,
			IBOLTeacherSkillMapper bolTeacherSkillMapper,
			IDALTeacherSkillMapper dalTeacherSkillMapper,
			IBOLRateMapper bolRateMapper,
			IDALRateMapper dalRateMapper,
			IBOLTeacherTeacherSkillMapper bolTeacherTeacherSkillMapper,
			IDALTeacherTeacherSkillMapper dalTeacherTeacherSkillMapper)
			: base()
		{
			this.TeacherSkillRepository = teacherSkillRepository;
			this.TeacherSkillModelValidator = teacherSkillModelValidator;
			this.BolTeacherSkillMapper = bolTeacherSkillMapper;
			this.DalTeacherSkillMapper = dalTeacherSkillMapper;
			this.BolRateMapper = bolRateMapper;
			this.DalRateMapper = dalRateMapper;
			this.BolTeacherTeacherSkillMapper = bolTeacherTeacherSkillMapper;
			this.DalTeacherTeacherSkillMapper = dalTeacherTeacherSkillMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTeacherSkillResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TeacherSkillRepository.All(limit, offset);

			return this.BolTeacherSkillMapper.MapBOToModel(this.DalTeacherSkillMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTeacherSkillResponseModel> Get(int id)
		{
			var record = await this.TeacherSkillRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTeacherSkillMapper.MapBOToModel(this.DalTeacherSkillMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTeacherSkillResponseModel>> Create(
			ApiTeacherSkillRequestModel model)
		{
			CreateResponse<ApiTeacherSkillResponseModel> response = new CreateResponse<ApiTeacherSkillResponseModel>(await this.TeacherSkillModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTeacherSkillMapper.MapModelToBO(default(int), model);
				var record = await this.TeacherSkillRepository.Create(this.DalTeacherSkillMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTeacherSkillMapper.MapBOToModel(this.DalTeacherSkillMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTeacherSkillResponseModel>> Update(
			int id,
			ApiTeacherSkillRequestModel model)
		{
			var validationResult = await this.TeacherSkillModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTeacherSkillMapper.MapModelToBO(id, model);
				await this.TeacherSkillRepository.Update(this.DalTeacherSkillMapper.MapBOToEF(bo));

				var record = await this.TeacherSkillRepository.Get(id);

				return new UpdateResponse<ApiTeacherSkillResponseModel>(this.BolTeacherSkillMapper.MapBOToModel(this.DalTeacherSkillMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTeacherSkillResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.TeacherSkillModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TeacherSkillRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiRateResponseModel>> RatesByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0)
		{
			List<Rate> records = await this.TeacherSkillRepository.RatesByTeacherSkillId(teacherSkillId, limit, offset);

			return this.BolRateMapper.MapBOToModel(this.DalRateMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTeacherTeacherSkillResponseModel>> TeacherTeacherSkillsByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0)
		{
			List<TeacherTeacherSkill> records = await this.TeacherSkillRepository.TeacherTeacherSkillsByTeacherSkillId(teacherSkillId, limit, offset);

			return this.BolTeacherTeacherSkillMapper.MapBOToModel(this.DalTeacherTeacherSkillMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>de475a9439055bc7bbc51e441a75410e</Hash>
</Codenesium>*/