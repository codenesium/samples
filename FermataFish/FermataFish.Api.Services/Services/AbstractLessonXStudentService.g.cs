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
	public abstract class AbstractLessonXStudentService: AbstractService
	{
		private ILessonXStudentRepository lessonXStudentRepository;
		private IApiLessonXStudentRequestModelValidator lessonXStudentModelValidator;
		private IBOLLessonXStudentMapper BOLLessonXStudentMapper;
		private IDALLessonXStudentMapper DALLessonXStudentMapper;
		private ILogger logger;

		public AbstractLessonXStudentService(
			ILogger logger,
			ILessonXStudentRepository lessonXStudentRepository,
			IApiLessonXStudentRequestModelValidator lessonXStudentModelValidator,
			IBOLLessonXStudentMapper bollessonXStudentMapper,
			IDALLessonXStudentMapper dallessonXStudentMapper)
			: base()

		{
			this.lessonXStudentRepository = lessonXStudentRepository;
			this.lessonXStudentModelValidator = lessonXStudentModelValidator;
			this.BOLLessonXStudentMapper = bollessonXStudentMapper;
			this.DALLessonXStudentMapper = dallessonXStudentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLessonXStudentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.lessonXStudentRepository.All(skip, take, orderClause);

			return this.BOLLessonXStudentMapper.MapBOToModel(this.DALLessonXStudentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLessonXStudentResponseModel> Get(int id)
		{
			var record = await lessonXStudentRepository.Get(id);

			return this.BOLLessonXStudentMapper.MapBOToModel(this.DALLessonXStudentMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiLessonXStudentResponseModel>> Create(
			ApiLessonXStudentRequestModel model)
		{
			CreateResponse<ApiLessonXStudentResponseModel> response = new CreateResponse<ApiLessonXStudentResponseModel>(await this.lessonXStudentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLLessonXStudentMapper.MapModelToBO(default (int), model);
				var record = await this.lessonXStudentRepository.Create(this.DALLessonXStudentMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLLessonXStudentMapper.MapBOToModel(this.DALLessonXStudentMapper.MapEFToBO(record)));
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
				var bo = this.BOLLessonXStudentMapper.MapModelToBO(id, model);
				await this.lessonXStudentRepository.Update(this.DALLessonXStudentMapper.MapBOToEF(bo));
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
    <Hash>8556efb81dbbe93147b60953229c569b</Hash>
</Codenesium>*/