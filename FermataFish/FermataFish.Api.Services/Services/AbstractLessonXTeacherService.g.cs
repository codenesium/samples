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
	public abstract class AbstractLessonXTeacherService: AbstractService
	{
		private ILessonXTeacherRepository lessonXTeacherRepository;
		private IApiLessonXTeacherRequestModelValidator lessonXTeacherModelValidator;
		private IBOLLessonXTeacherMapper BOLLessonXTeacherMapper;
		private IDALLessonXTeacherMapper DALLessonXTeacherMapper;
		private ILogger logger;

		public AbstractLessonXTeacherService(
			ILogger logger,
			ILessonXTeacherRepository lessonXTeacherRepository,
			IApiLessonXTeacherRequestModelValidator lessonXTeacherModelValidator,
			IBOLLessonXTeacherMapper bollessonXTeacherMapper,
			IDALLessonXTeacherMapper dallessonXTeacherMapper)
			: base()

		{
			this.lessonXTeacherRepository = lessonXTeacherRepository;
			this.lessonXTeacherModelValidator = lessonXTeacherModelValidator;
			this.BOLLessonXTeacherMapper = bollessonXTeacherMapper;
			this.DALLessonXTeacherMapper = dallessonXTeacherMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLessonXTeacherResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.lessonXTeacherRepository.All(skip, take, orderClause);

			return this.BOLLessonXTeacherMapper.MapBOToModel(this.DALLessonXTeacherMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLessonXTeacherResponseModel> Get(int id)
		{
			var record = await lessonXTeacherRepository.Get(id);

			return this.BOLLessonXTeacherMapper.MapBOToModel(this.DALLessonXTeacherMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiLessonXTeacherResponseModel>> Create(
			ApiLessonXTeacherRequestModel model)
		{
			CreateResponse<ApiLessonXTeacherResponseModel> response = new CreateResponse<ApiLessonXTeacherResponseModel>(await this.lessonXTeacherModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLLessonXTeacherMapper.MapModelToBO(default (int), model);
				var record = await this.lessonXTeacherRepository.Create(this.DALLessonXTeacherMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLLessonXTeacherMapper.MapBOToModel(this.DALLessonXTeacherMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiLessonXTeacherRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.lessonXTeacherModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLLessonXTeacherMapper.MapModelToBO(id, model);
				await this.lessonXTeacherRepository.Update(this.DALLessonXTeacherMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.lessonXTeacherModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.lessonXTeacherRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0adee72f4bff620995eb92ff671c3e48</Hash>
</Codenesium>*/