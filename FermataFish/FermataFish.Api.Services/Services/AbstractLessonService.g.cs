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
	public abstract class AbstractLessonService : AbstractService
	{
		protected ILessonRepository LessonRepository { get; private set; }

		protected IApiLessonRequestModelValidator LessonModelValidator { get; private set; }

		protected IBOLLessonMapper BolLessonMapper { get; private set; }

		protected IDALLessonMapper DalLessonMapper { get; private set; }

		protected IBOLLessonXStudentMapper BolLessonXStudentMapper { get; private set; }

		protected IDALLessonXStudentMapper DalLessonXStudentMapper { get; private set; }

		protected IBOLLessonXTeacherMapper BolLessonXTeacherMapper { get; private set; }

		protected IDALLessonXTeacherMapper DalLessonXTeacherMapper { get; private set; }

		private ILogger logger;

		public AbstractLessonService(
			ILogger logger,
			ILessonRepository lessonRepository,
			IApiLessonRequestModelValidator lessonModelValidator,
			IBOLLessonMapper bolLessonMapper,
			IDALLessonMapper dalLessonMapper,
			IBOLLessonXStudentMapper bolLessonXStudentMapper,
			IDALLessonXStudentMapper dalLessonXStudentMapper,
			IBOLLessonXTeacherMapper bolLessonXTeacherMapper,
			IDALLessonXTeacherMapper dalLessonXTeacherMapper)
			: base()
		{
			this.LessonRepository = lessonRepository;
			this.LessonModelValidator = lessonModelValidator;
			this.BolLessonMapper = bolLessonMapper;
			this.DalLessonMapper = dalLessonMapper;
			this.BolLessonXStudentMapper = bolLessonXStudentMapper;
			this.DalLessonXStudentMapper = dalLessonXStudentMapper;
			this.BolLessonXTeacherMapper = bolLessonXTeacherMapper;
			this.DalLessonXTeacherMapper = dalLessonXTeacherMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLessonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LessonRepository.All(limit, offset);

			return this.BolLessonMapper.MapBOToModel(this.DalLessonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLessonResponseModel> Get(int id)
		{
			var record = await this.LessonRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLessonMapper.MapBOToModel(this.DalLessonMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLessonResponseModel>> Create(
			ApiLessonRequestModel model)
		{
			CreateResponse<ApiLessonResponseModel> response = new CreateResponse<ApiLessonResponseModel>(await this.LessonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolLessonMapper.MapModelToBO(default(int), model);
				var record = await this.LessonRepository.Create(this.DalLessonMapper.MapBOToEF(bo));

				response.SetRecord(this.BolLessonMapper.MapBOToModel(this.DalLessonMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLessonResponseModel>> Update(
			int id,
			ApiLessonRequestModel model)
		{
			var validationResult = await this.LessonModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolLessonMapper.MapModelToBO(id, model);
				await this.LessonRepository.Update(this.DalLessonMapper.MapBOToEF(bo));

				var record = await this.LessonRepository.Get(id);

				return new UpdateResponse<ApiLessonResponseModel>(this.BolLessonMapper.MapBOToModel(this.DalLessonMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiLessonResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.LessonModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.LessonRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiLessonXStudentResponseModel>> LessonXStudents(int lessonId, int limit = int.MaxValue, int offset = 0)
		{
			List<LessonXStudent> records = await this.LessonRepository.LessonXStudents(lessonId, limit, offset);

			return this.BolLessonXStudentMapper.MapBOToModel(this.DalLessonXStudentMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiLessonXTeacherResponseModel>> LessonXTeachers(int lessonId, int limit = int.MaxValue, int offset = 0)
		{
			List<LessonXTeacher> records = await this.LessonRepository.LessonXTeachers(lessonId, limit, offset);

			return this.BolLessonXTeacherMapper.MapBOToModel(this.DalLessonXTeacherMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>e1c8ae407528d9351a1effa4c52c696b</Hash>
</Codenesium>*/