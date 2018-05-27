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
	public abstract class AbstractBOLessonXTeacher: AbstractBOManager
	{
		private ILessonXTeacherRepository lessonXTeacherRepository;
		private IApiLessonXTeacherRequestModelValidator lessonXTeacherModelValidator;
		private IBOLLessonXTeacherMapper lessonXTeacherMapper;
		private ILogger logger;

		public AbstractBOLessonXTeacher(
			ILogger logger,
			ILessonXTeacherRepository lessonXTeacherRepository,
			IApiLessonXTeacherRequestModelValidator lessonXTeacherModelValidator,
			IBOLLessonXTeacherMapper lessonXTeacherMapper)
			: base()

		{
			this.lessonXTeacherRepository = lessonXTeacherRepository;
			this.lessonXTeacherModelValidator = lessonXTeacherModelValidator;
			this.lessonXTeacherMapper = lessonXTeacherMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLessonXTeacherResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.lessonXTeacherRepository.All(skip, take, orderClause);

			return this.lessonXTeacherMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiLessonXTeacherResponseModel> Get(int id)
		{
			var record = await lessonXTeacherRepository.Get(id);

			return this.lessonXTeacherMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiLessonXTeacherResponseModel>> Create(
			ApiLessonXTeacherRequestModel model)
		{
			CreateResponse<ApiLessonXTeacherResponseModel> response = new CreateResponse<ApiLessonXTeacherResponseModel>(await this.lessonXTeacherModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.lessonXTeacherMapper.MapModelToDTO(default (int), model);
				var record = await this.lessonXTeacherRepository.Create(dto);

				response.SetRecord(this.lessonXTeacherMapper.MapDTOToModel(record));
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
				var dto = this.lessonXTeacherMapper.MapModelToDTO(id, model);
				await this.lessonXTeacherRepository.Update(id, dto);
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
    <Hash>a3866b3260b42f9124a94d0b446135db</Hash>
</Codenesium>*/