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

		public virtual async Task<ApiTeacherTeacherSkillResponseModel> Get(int teacherId)
		{
			var record = await this.TeacherTeacherSkillRepository.Get(teacherId);

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
			int teacherId,
			ApiTeacherTeacherSkillRequestModel model)
		{
			var validationResult = await this.TeacherTeacherSkillModelValidator.ValidateUpdateAsync(teacherId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTeacherTeacherSkillMapper.MapModelToBO(teacherId, model);
				await this.TeacherTeacherSkillRepository.Update(this.DalTeacherTeacherSkillMapper.MapBOToEF(bo));

				var record = await this.TeacherTeacherSkillRepository.Get(teacherId);

				return new UpdateResponse<ApiTeacherTeacherSkillResponseModel>(this.BolTeacherTeacherSkillMapper.MapBOToModel(this.DalTeacherTeacherSkillMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTeacherTeacherSkillResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int teacherId)
		{
			ActionResponse response = new ActionResponse(await this.TeacherTeacherSkillModelValidator.ValidateDeleteAsync(teacherId));
			if (response.Success)
			{
				await this.TeacherTeacherSkillRepository.Delete(teacherId);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>137ef2f17ac1523f6d03913b9c20fd90</Hash>
</Codenesium>*/