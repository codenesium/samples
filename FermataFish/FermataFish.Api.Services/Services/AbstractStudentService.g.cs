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
		protected IStudentRepository StudentRepository { get; private set; }

		protected IApiStudentRequestModelValidator StudentModelValidator { get; private set; }

		protected IBOLStudentMapper BolStudentMapper { get; private set; }

		protected IDALStudentMapper DalStudentMapper { get; private set; }

		protected IBOLLessonXStudentMapper BolLessonXStudentMapper { get; private set; }

		protected IDALLessonXStudentMapper DalLessonXStudentMapper { get; private set; }

		protected IBOLLessonXTeacherMapper BolLessonXTeacherMapper { get; private set; }

		protected IDALLessonXTeacherMapper DalLessonXTeacherMapper { get; private set; }

		protected IBOLStudentXFamilyMapper BolStudentXFamilyMapper { get; private set; }

		protected IDALStudentXFamilyMapper DalStudentXFamilyMapper { get; private set; }

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
			this.StudentRepository = studentRepository;
			this.StudentModelValidator = studentModelValidator;
			this.BolStudentMapper = bolStudentMapper;
			this.DalStudentMapper = dalStudentMapper;
			this.BolLessonXStudentMapper = bolLessonXStudentMapper;
			this.DalLessonXStudentMapper = dalLessonXStudentMapper;
			this.BolLessonXTeacherMapper = bolLessonXTeacherMapper;
			this.DalLessonXTeacherMapper = dalLessonXTeacherMapper;
			this.BolStudentXFamilyMapper = bolStudentXFamilyMapper;
			this.DalStudentXFamilyMapper = dalStudentXFamilyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStudentResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.StudentRepository.All(limit, offset);

			return this.BolStudentMapper.MapBOToModel(this.DalStudentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiStudentResponseModel> Get(int id)
		{
			var record = await this.StudentRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolStudentMapper.MapBOToModel(this.DalStudentMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiStudentResponseModel>> Create(
			ApiStudentRequestModel model)
		{
			CreateResponse<ApiStudentResponseModel> response = new CreateResponse<ApiStudentResponseModel>(await this.StudentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolStudentMapper.MapModelToBO(default(int), model);
				var record = await this.StudentRepository.Create(this.DalStudentMapper.MapBOToEF(bo));

				response.SetRecord(this.BolStudentMapper.MapBOToModel(this.DalStudentMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiStudentResponseModel>> Update(
			int id,
			ApiStudentRequestModel model)
		{
			var validationResult = await this.StudentModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolStudentMapper.MapModelToBO(id, model);
				await this.StudentRepository.Update(this.DalStudentMapper.MapBOToEF(bo));

				var record = await this.StudentRepository.Get(id);

				return new UpdateResponse<ApiStudentResponseModel>(this.BolStudentMapper.MapBOToModel(this.DalStudentMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiStudentResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.StudentModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.StudentRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiLessonXStudentResponseModel>> LessonXStudents(int studentId, int limit = int.MaxValue, int offset = 0)
		{
			List<LessonXStudent> records = await this.StudentRepository.LessonXStudents(studentId, limit, offset);

			return this.BolLessonXStudentMapper.MapBOToModel(this.DalLessonXStudentMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiLessonXTeacherResponseModel>> LessonXTeachers(int studentId, int limit = int.MaxValue, int offset = 0)
		{
			List<LessonXTeacher> records = await this.StudentRepository.LessonXTeachers(studentId, limit, offset);

			return this.BolLessonXTeacherMapper.MapBOToModel(this.DalLessonXTeacherMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiStudentXFamilyResponseModel>> StudentXFamilies(int studentId, int limit = int.MaxValue, int offset = 0)
		{
			List<StudentXFamily> records = await this.StudentRepository.StudentXFamilies(studentId, limit, offset);

			return this.BolStudentXFamilyMapper.MapBOToModel(this.DalStudentXFamilyMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>75b9b5da054cf266e76a3689c54d35fc</Hash>
</Codenesium>*/