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
		private ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository;

		private IApiTeacherXTeacherSkillRequestModelValidator teacherXTeacherSkillModelValidator;

		private IBOLTeacherXTeacherSkillMapper bolTeacherXTeacherSkillMapper;

		private IDALTeacherXTeacherSkillMapper dalTeacherXTeacherSkillMapper;

		private ILogger logger;

		public AbstractTeacherXTeacherSkillService(
			ILogger logger,
			ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository,
			IApiTeacherXTeacherSkillRequestModelValidator teacherXTeacherSkillModelValidator,
			IBOLTeacherXTeacherSkillMapper bolTeacherXTeacherSkillMapper,
			IDALTeacherXTeacherSkillMapper dalTeacherXTeacherSkillMapper)
			: base()
		{
			this.teacherXTeacherSkillRepository = teacherXTeacherSkillRepository;
			this.teacherXTeacherSkillModelValidator = teacherXTeacherSkillModelValidator;
			this.bolTeacherXTeacherSkillMapper = bolTeacherXTeacherSkillMapper;
			this.dalTeacherXTeacherSkillMapper = dalTeacherXTeacherSkillMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTeacherXTeacherSkillResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.teacherXTeacherSkillRepository.All(limit, offset);

			return this.bolTeacherXTeacherSkillMapper.MapBOToModel(this.dalTeacherXTeacherSkillMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTeacherXTeacherSkillResponseModel> Get(int id)
		{
			var record = await this.teacherXTeacherSkillRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolTeacherXTeacherSkillMapper.MapBOToModel(this.dalTeacherXTeacherSkillMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTeacherXTeacherSkillResponseModel>> Create(
			ApiTeacherXTeacherSkillRequestModel model)
		{
			CreateResponse<ApiTeacherXTeacherSkillResponseModel> response = new CreateResponse<ApiTeacherXTeacherSkillResponseModel>(await this.teacherXTeacherSkillModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolTeacherXTeacherSkillMapper.MapModelToBO(default(int), model);
				var record = await this.teacherXTeacherSkillRepository.Create(this.dalTeacherXTeacherSkillMapper.MapBOToEF(bo));

				response.SetRecord(this.bolTeacherXTeacherSkillMapper.MapBOToModel(this.dalTeacherXTeacherSkillMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTeacherXTeacherSkillResponseModel>> Update(
			int id,
			ApiTeacherXTeacherSkillRequestModel model)
		{
			var validationResult = await this.teacherXTeacherSkillModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolTeacherXTeacherSkillMapper.MapModelToBO(id, model);
				await this.teacherXTeacherSkillRepository.Update(this.dalTeacherXTeacherSkillMapper.MapBOToEF(bo));

				var record = await this.teacherXTeacherSkillRepository.Get(id);

				return new UpdateResponse<ApiTeacherXTeacherSkillResponseModel>(this.bolTeacherXTeacherSkillMapper.MapBOToModel(this.dalTeacherXTeacherSkillMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTeacherXTeacherSkillResponseModel>(validationResult);
			}
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
    <Hash>58a504c96650dc56b35d3cdb91c5bd2b</Hash>
</Codenesium>*/