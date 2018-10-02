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
	public abstract class AbstractTeacherTeacherSkillService : AbstractService
	{
		protected ITeacherTeacherSkillRepository TeacherTeacherSkillRepository { get; private set; }

		protected IApiTeacherTeacherSkillRequestModelValidator TeacherTeacherSkillModelValidator { get; private set; }

		protected IBOLTeacherTeacherSkillMapper BolTeacherTeacherSkillMapper { get; private set; }

		protected IDALTeacherTeacherSkillMapper DalTeacherTeacherSkillMapper { get; private set; }

		private ILogger logger;

		public AbstractTeacherTeacherSkillService(
			ILogger logger,
			ITeacherTeacherSkillRepository teacherTeacherSkillRepository,
			IApiTeacherTeacherSkillRequestModelValidator teacherTeacherSkillModelValidator,
			IBOLTeacherTeacherSkillMapper bolTeacherTeacherSkillMapper,
			IDALTeacherTeacherSkillMapper dalTeacherTeacherSkillMapper)
			: base()
		{
			this.TeacherTeacherSkillRepository = teacherTeacherSkillRepository;
			this.TeacherTeacherSkillModelValidator = teacherTeacherSkillModelValidator;
			this.BolTeacherTeacherSkillMapper = bolTeacherTeacherSkillMapper;
			this.DalTeacherTeacherSkillMapper = dalTeacherTeacherSkillMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTeacherTeacherSkillResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TeacherTeacherSkillRepository.All(limit, offset);

			return this.BolTeacherTeacherSkillMapper.MapBOToModel(this.DalTeacherTeacherSkillMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTeacherTeacherSkillResponseModel> Get(int id)
		{
			var record = await this.TeacherTeacherSkillRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTeacherTeacherSkillMapper.MapBOToModel(this.DalTeacherTeacherSkillMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTeacherTeacherSkillResponseModel>> Create(
			ApiTeacherTeacherSkillRequestModel model)
		{
			CreateResponse<ApiTeacherTeacherSkillResponseModel> response = new CreateResponse<ApiTeacherTeacherSkillResponseModel>(await this.TeacherTeacherSkillModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTeacherTeacherSkillMapper.MapModelToBO(default(int), model);
				var record = await this.TeacherTeacherSkillRepository.Create(this.DalTeacherTeacherSkillMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTeacherTeacherSkillMapper.MapBOToModel(this.DalTeacherTeacherSkillMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTeacherTeacherSkillResponseModel>> Update(
			int id,
			ApiTeacherTeacherSkillRequestModel model)
		{
			var validationResult = await this.TeacherTeacherSkillModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTeacherTeacherSkillMapper.MapModelToBO(id, model);
				await this.TeacherTeacherSkillRepository.Update(this.DalTeacherTeacherSkillMapper.MapBOToEF(bo));

				var record = await this.TeacherTeacherSkillRepository.Get(id);

				return new UpdateResponse<ApiTeacherTeacherSkillResponseModel>(this.BolTeacherTeacherSkillMapper.MapBOToModel(this.DalTeacherTeacherSkillMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTeacherTeacherSkillResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.TeacherTeacherSkillModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TeacherTeacherSkillRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiTeacherTeacherSkillResponseModel>> ByTeacherId(int teacherId, int limit = 0, int offset = int.MaxValue)
		{
			List<TeacherTeacherSkill> records = await this.TeacherTeacherSkillRepository.ByTeacherId(teacherId, limit, offset);

			return this.BolTeacherTeacherSkillMapper.MapBOToModel(this.DalTeacherTeacherSkillMapper.MapEFToBO(records));
		}

		public async Task<List<ApiTeacherTeacherSkillResponseModel>> ByTeacherSkillId(int teacherSkillId, int limit = 0, int offset = int.MaxValue)
		{
			List<TeacherTeacherSkill> records = await this.TeacherTeacherSkillRepository.ByTeacherSkillId(teacherSkillId, limit, offset);

			return this.BolTeacherTeacherSkillMapper.MapBOToModel(this.DalTeacherTeacherSkillMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>ca84c34bd3e89c946f85f7e243fe8943</Hash>
</Codenesium>*/