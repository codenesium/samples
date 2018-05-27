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
	public abstract class AbstractBOLessonXStudent: AbstractBOManager
	{
		private ILessonXStudentRepository lessonXStudentRepository;
		private IApiLessonXStudentRequestModelValidator lessonXStudentModelValidator;
		private IBOLLessonXStudentMapper lessonXStudentMapper;
		private ILogger logger;

		public AbstractBOLessonXStudent(
			ILogger logger,
			ILessonXStudentRepository lessonXStudentRepository,
			IApiLessonXStudentRequestModelValidator lessonXStudentModelValidator,
			IBOLLessonXStudentMapper lessonXStudentMapper)
			: base()

		{
			this.lessonXStudentRepository = lessonXStudentRepository;
			this.lessonXStudentModelValidator = lessonXStudentModelValidator;
			this.lessonXStudentMapper = lessonXStudentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLessonXStudentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.lessonXStudentRepository.All(skip, take, orderClause);

			return this.lessonXStudentMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiLessonXStudentResponseModel> Get(int id)
		{
			var record = await lessonXStudentRepository.Get(id);

			return this.lessonXStudentMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiLessonXStudentResponseModel>> Create(
			ApiLessonXStudentRequestModel model)
		{
			CreateResponse<ApiLessonXStudentResponseModel> response = new CreateResponse<ApiLessonXStudentResponseModel>(await this.lessonXStudentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.lessonXStudentMapper.MapModelToDTO(default (int), model);
				var record = await this.lessonXStudentRepository.Create(dto);

				response.SetRecord(this.lessonXStudentMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiLessonXStudentRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.lessonXStudentModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.lessonXStudentMapper.MapModelToDTO(id, model);
				await this.lessonXStudentRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.lessonXStudentModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.lessonXStudentRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>55c36e52da11850984844568271df695</Hash>
</Codenesium>*/