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
	public abstract class AbstractStudioService : AbstractService
	{
		protected IStudioRepository StudioRepository { get; private set; }

		protected IApiStudioRequestModelValidator StudioModelValidator { get; private set; }

		protected IBOLStudioMapper BolStudioMapper { get; private set; }

		protected IDALStudioMapper DalStudioMapper { get; private set; }

		protected IBOLFamilyMapper BolFamilyMapper { get; private set; }

		protected IDALFamilyMapper DalFamilyMapper { get; private set; }

		protected IBOLLessonStatusMapper BolLessonStatusMapper { get; private set; }

		protected IDALLessonStatusMapper DalLessonStatusMapper { get; private set; }

		protected IBOLAdminMapper BolAdminMapper { get; private set; }

		protected IDALAdminMapper DalAdminMapper { get; private set; }

		protected IBOLLessonMapper BolLessonMapper { get; private set; }

		protected IDALLessonMapper DalLessonMapper { get; private set; }

		protected IBOLLessonXStudentMapper BolLessonXStudentMapper { get; private set; }

		protected IDALLessonXStudentMapper DalLessonXStudentMapper { get; private set; }

		protected IBOLRateMapper BolRateMapper { get; private set; }

		protected IDALRateMapper DalRateMapper { get; private set; }

		protected IBOLSpaceMapper BolSpaceMapper { get; private set; }

		protected IDALSpaceMapper DalSpaceMapper { get; private set; }

		protected IBOLSpaceFeatureMapper BolSpaceFeatureMapper { get; private set; }

		protected IDALSpaceFeatureMapper DalSpaceFeatureMapper { get; private set; }

		protected IBOLSpaceXSpaceFeatureMapper BolSpaceXSpaceFeatureMapper { get; private set; }

		protected IDALSpaceXSpaceFeatureMapper DalSpaceXSpaceFeatureMapper { get; private set; }

		protected IBOLStudentMapper BolStudentMapper { get; private set; }

		protected IDALStudentMapper DalStudentMapper { get; private set; }

		protected IBOLStudentXFamilyMapper BolStudentXFamilyMapper { get; private set; }

		protected IDALStudentXFamilyMapper DalStudentXFamilyMapper { get; private set; }

		protected IBOLTeacherMapper BolTeacherMapper { get; private set; }

		protected IDALTeacherMapper DalTeacherMapper { get; private set; }

		protected IBOLTeacherSkillMapper BolTeacherSkillMapper { get; private set; }

		protected IDALTeacherSkillMapper DalTeacherSkillMapper { get; private set; }

		protected IBOLTeacherXTeacherSkillMapper BolTeacherXTeacherSkillMapper { get; private set; }

		protected IDALTeacherXTeacherSkillMapper DalTeacherXTeacherSkillMapper { get; private set; }

		private ILogger logger;

		public AbstractStudioService(
			ILogger logger,
			IStudioRepository studioRepository,
			IApiStudioRequestModelValidator studioModelValidator,
			IBOLStudioMapper bolStudioMapper,
			IDALStudioMapper dalStudioMapper,
			IBOLFamilyMapper bolFamilyMapper,
			IDALFamilyMapper dalFamilyMapper,
			IBOLLessonStatusMapper bolLessonStatusMapper,
			IDALLessonStatusMapper dalLessonStatusMapper,
			IBOLAdminMapper bolAdminMapper,
			IDALAdminMapper dalAdminMapper,
			IBOLLessonMapper bolLessonMapper,
			IDALLessonMapper dalLessonMapper,
			IBOLLessonXStudentMapper bolLessonXStudentMapper,
			IDALLessonXStudentMapper dalLessonXStudentMapper,
			IBOLRateMapper bolRateMapper,
			IDALRateMapper dalRateMapper,
			IBOLSpaceMapper bolSpaceMapper,
			IDALSpaceMapper dalSpaceMapper,
			IBOLSpaceFeatureMapper bolSpaceFeatureMapper,
			IDALSpaceFeatureMapper dalSpaceFeatureMapper,
			IBOLSpaceXSpaceFeatureMapper bolSpaceXSpaceFeatureMapper,
			IDALSpaceXSpaceFeatureMapper dalSpaceXSpaceFeatureMapper,
			IBOLStudentMapper bolStudentMapper,
			IDALStudentMapper dalStudentMapper,
			IBOLStudentXFamilyMapper bolStudentXFamilyMapper,
			IDALStudentXFamilyMapper dalStudentXFamilyMapper,
			IBOLTeacherMapper bolTeacherMapper,
			IDALTeacherMapper dalTeacherMapper,
			IBOLTeacherSkillMapper bolTeacherSkillMapper,
			IDALTeacherSkillMapper dalTeacherSkillMapper,
			IBOLTeacherXTeacherSkillMapper bolTeacherXTeacherSkillMapper,
			IDALTeacherXTeacherSkillMapper dalTeacherXTeacherSkillMapper)
			: base()
		{
			this.StudioRepository = studioRepository;
			this.StudioModelValidator = studioModelValidator;
			this.BolStudioMapper = bolStudioMapper;
			this.DalStudioMapper = dalStudioMapper;
			this.BolFamilyMapper = bolFamilyMapper;
			this.DalFamilyMapper = dalFamilyMapper;
			this.BolLessonStatusMapper = bolLessonStatusMapper;
			this.DalLessonStatusMapper = dalLessonStatusMapper;
			this.BolAdminMapper = bolAdminMapper;
			this.DalAdminMapper = dalAdminMapper;
			this.BolLessonMapper = bolLessonMapper;
			this.DalLessonMapper = dalLessonMapper;
			this.BolLessonXStudentMapper = bolLessonXStudentMapper;
			this.DalLessonXStudentMapper = dalLessonXStudentMapper;
			this.BolRateMapper = bolRateMapper;
			this.DalRateMapper = dalRateMapper;
			this.BolSpaceMapper = bolSpaceMapper;
			this.DalSpaceMapper = dalSpaceMapper;
			this.BolSpaceFeatureMapper = bolSpaceFeatureMapper;
			this.DalSpaceFeatureMapper = dalSpaceFeatureMapper;
			this.BolSpaceXSpaceFeatureMapper = bolSpaceXSpaceFeatureMapper;
			this.DalSpaceXSpaceFeatureMapper = dalSpaceXSpaceFeatureMapper;
			this.BolStudentMapper = bolStudentMapper;
			this.DalStudentMapper = dalStudentMapper;
			this.BolStudentXFamilyMapper = bolStudentXFamilyMapper;
			this.DalStudentXFamilyMapper = dalStudentXFamilyMapper;
			this.BolTeacherMapper = bolTeacherMapper;
			this.DalTeacherMapper = dalTeacherMapper;
			this.BolTeacherSkillMapper = bolTeacherSkillMapper;
			this.DalTeacherSkillMapper = dalTeacherSkillMapper;
			this.BolTeacherXTeacherSkillMapper = bolTeacherXTeacherSkillMapper;
			this.DalTeacherXTeacherSkillMapper = dalTeacherXTeacherSkillMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStudioResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.StudioRepository.All(limit, offset);

			return this.BolStudioMapper.MapBOToModel(this.DalStudioMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiStudioResponseModel> Get(int id)
		{
			var record = await this.StudioRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolStudioMapper.MapBOToModel(this.DalStudioMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiStudioResponseModel>> Create(
			ApiStudioRequestModel model)
		{
			CreateResponse<ApiStudioResponseModel> response = new CreateResponse<ApiStudioResponseModel>(await this.StudioModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolStudioMapper.MapModelToBO(default(int), model);
				var record = await this.StudioRepository.Create(this.DalStudioMapper.MapBOToEF(bo));

				response.SetRecord(this.BolStudioMapper.MapBOToModel(this.DalStudioMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiStudioResponseModel>> Update(
			int id,
			ApiStudioRequestModel model)
		{
			var validationResult = await this.StudioModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolStudioMapper.MapModelToBO(id, model);
				await this.StudioRepository.Update(this.DalStudioMapper.MapBOToEF(bo));

				var record = await this.StudioRepository.Get(id);

				return new UpdateResponse<ApiStudioResponseModel>(this.BolStudioMapper.MapBOToModel(this.DalStudioMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiStudioResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.StudioModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.StudioRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiFamilyResponseModel>> Families(int id, int limit = int.MaxValue, int offset = 0)
		{
			List<Family> records = await this.StudioRepository.Families(id, limit, offset);

			return this.BolFamilyMapper.MapBOToModel(this.DalFamilyMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiLessonStatusResponseModel>> LessonStatuses(int id, int limit = int.MaxValue, int offset = 0)
		{
			List<LessonStatus> records = await this.StudioRepository.LessonStatuses(id, limit, offset);

			return this.BolLessonStatusMapper.MapBOToModel(this.DalLessonStatusMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiAdminResponseModel>> Admins(int studioId, int limit = int.MaxValue, int offset = 0)
		{
			List<Admin> records = await this.StudioRepository.Admins(studioId, limit, offset);

			return this.BolAdminMapper.MapBOToModel(this.DalAdminMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiLessonResponseModel>> Lessons(int studioId, int limit = int.MaxValue, int offset = 0)
		{
			List<Lesson> records = await this.StudioRepository.Lessons(studioId, limit, offset);

			return this.BolLessonMapper.MapBOToModel(this.DalLessonMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiLessonXStudentResponseModel>> LessonXStudents(int studioId, int limit = int.MaxValue, int offset = 0)
		{
			List<LessonXStudent> records = await this.StudioRepository.LessonXStudents(studioId, limit, offset);

			return this.BolLessonXStudentMapper.MapBOToModel(this.DalLessonXStudentMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiRateResponseModel>> Rates(int studioId, int limit = int.MaxValue, int offset = 0)
		{
			List<Rate> records = await this.StudioRepository.Rates(studioId, limit, offset);

			return this.BolRateMapper.MapBOToModel(this.DalRateMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSpaceResponseModel>> Spaces(int studioId, int limit = int.MaxValue, int offset = 0)
		{
			List<Space> records = await this.StudioRepository.Spaces(studioId, limit, offset);

			return this.BolSpaceMapper.MapBOToModel(this.DalSpaceMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSpaceFeatureResponseModel>> SpaceFeatures(int studioId, int limit = int.MaxValue, int offset = 0)
		{
			List<SpaceFeature> records = await this.StudioRepository.SpaceFeatures(studioId, limit, offset);

			return this.BolSpaceFeatureMapper.MapBOToModel(this.DalSpaceFeatureMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatures(int studioId, int limit = int.MaxValue, int offset = 0)
		{
			List<SpaceXSpaceFeature> records = await this.StudioRepository.SpaceXSpaceFeatures(studioId, limit, offset);

			return this.BolSpaceXSpaceFeatureMapper.MapBOToModel(this.DalSpaceXSpaceFeatureMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiStudentResponseModel>> Students(int studioId, int limit = int.MaxValue, int offset = 0)
		{
			List<Student> records = await this.StudioRepository.Students(studioId, limit, offset);

			return this.BolStudentMapper.MapBOToModel(this.DalStudentMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiStudentXFamilyResponseModel>> StudentXFamilies(int studioId, int limit = int.MaxValue, int offset = 0)
		{
			List<StudentXFamily> records = await this.StudioRepository.StudentXFamilies(studioId, limit, offset);

			return this.BolStudentXFamilyMapper.MapBOToModel(this.DalStudentXFamilyMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTeacherResponseModel>> Teachers(int studioId, int limit = int.MaxValue, int offset = 0)
		{
			List<Teacher> records = await this.StudioRepository.Teachers(studioId, limit, offset);

			return this.BolTeacherMapper.MapBOToModel(this.DalTeacherMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTeacherSkillResponseModel>> TeacherSkills(int studioId, int limit = int.MaxValue, int offset = 0)
		{
			List<TeacherSkill> records = await this.StudioRepository.TeacherSkills(studioId, limit, offset);

			return this.BolTeacherSkillMapper.MapBOToModel(this.DalTeacherSkillMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTeacherXTeacherSkillResponseModel>> TeacherXTeacherSkills(int studioId, int limit = int.MaxValue, int offset = 0)
		{
			List<TeacherXTeacherSkill> records = await this.StudioRepository.TeacherXTeacherSkills(studioId, limit, offset);

			return this.BolTeacherXTeacherSkillMapper.MapBOToModel(this.DalTeacherXTeacherSkillMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>c0c1084e6f834069871170ad1b57ff40</Hash>
</Codenesium>*/