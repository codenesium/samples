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
	public abstract class AbstractStudentService : AbstractService
	{
		private IStudentRepository studentRepository;

		private IApiStudentRequestModelValidator studentModelValidator;

		private IBOLStudentMapper bolStudentMapper;

		private IDALStudentMapper dalStudentMapper;

		private IBOLLessonXStudentMapper bolLessonXStudentMapper;

		private IDALLessonXStudentMapper dalLessonXStudentMapper;
		private IBOLLessonXTeacherMapper bolLessonXTeacherMapper;

		private IDALLessonXTeacherMapper dalLessonXTeacherMapper;
		private IBOLStudentXFamilyMapper bolStudentXFamilyMapper;

		private IDALStudentXFamilyMapper dalStudentXFamilyMapper;

		private ILogger logger;

		public AbstractStudentService(
			ILogger logger,
			IStudentRepository studentRepository,
			IApiStudentRequestModelValidator studentModelValidator,
			IBOLStudentMapper bolStudentMapper,
			IDALStudentMapper dalStudentMapper,
			IBOLLessonXStudentMapper bolLessonXStudentMapper,
			IDALLessonXStudentMapper dalLessonXStudentMapper,
			IBOLLessonXTeacherMapper bolLessonXTeacherMapper,
			IDALLessonXTeacherMapper dalLessonXTeacherMapper,
			IBOLStudentXFamilyMapper bolStudentXFamilyMapper,
			IDALStudentXFamilyMapper dalStudentXFamilyMapper)
			: base()
		{
			this.studentRepository = studentRepository;
			this.studentModelValidator = studentModelValidator;
			this.bolStudentMapper = bolStudentMapper;
			this.dalStudentMapper = dalStudentMapper;
			this.bolLessonXStudentMapper = bolLessonXStudentMapper;
			this.dalLessonXStudentMapper = dalLessonXStudentMapper;
			this.bolLessonXTeacherMapper = bolLessonXTeacherMapper;
			this.dalLessonXTeacherMapper = dalLessonXTeacherMapper;
			this.bolStudentXFamilyMapper = bolStudentXFamilyMapper;
			this.dalStudentXFamilyMapper = dalStudentXFamilyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStudentResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.studentRepository.All(limit, offset);

			return this.bolStudentMapper.MapBOToModel(this.dalStudentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiStudentResponseModel> Get(int id)
		{
			var record = await this.studentRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolStudentMapper.MapBOToModel(this.dalStudentMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiStudentResponseModel>> Create(
			ApiStudentRequestModel model)
		{
			CreateResponse<ApiStudentResponseModel> response = new CreateResponse<ApiStudentResponseModel>(await this.studentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolStudentMapper.MapModelToBO(default(int), model);
				var record = await this.studentRepository.Create(this.dalStudentMapper.MapBOToEF(bo));

				response.SetRecord(this.bolStudentMapper.MapBOToModel(this.dalStudentMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiStudentResponseModel>> Update(
			int id,
			ApiStudentRequestModel model)
		{
			var validationResult = await this.studentModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolStudentMapper.MapModelToBO(id, model);
				await this.studentRepository.Update(this.dalStudentMapper.MapBOToEF(bo));

				var record = await this.studentRepository.Get(id);

				return new UpdateResponse<ApiStudentResponseModel>(this.bolStudentMapper.MapBOToModel(this.dalStudentMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiStudentResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.studentModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.studentRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiLessonXStudentResponseModel>> LessonXStudents(int studentId, int limit = int.MaxValue, int offset = 0)
		{
			List<LessonXStudent> records = await this.studentRepository.LessonXStudents(studentId, limit, offset);

			return this.bolLessonXStudentMapper.MapBOToModel(this.dalLessonXStudentMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiLessonXTeacherResponseModel>> LessonXTeachers(int studentId, int limit = int.MaxValue, int offset = 0)
		{
			List<LessonXTeacher> records = await this.studentRepository.LessonXTeachers(studentId, limit, offset);

			return this.bolLessonXTeacherMapper.MapBOToModel(this.dalLessonXTeacherMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiStudentXFamilyResponseModel>> StudentXFamilies(int studentId, int limit = int.MaxValue, int offset = 0)
		{
			List<StudentXFamily> records = await this.studentRepository.StudentXFamilies(studentId, limit, offset);

			return this.bolStudentXFamilyMapper.MapBOToModel(this.dalStudentXFamilyMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>55c0c764000f3f4bd93e752a7606f765</Hash>
</Codenesium>*/