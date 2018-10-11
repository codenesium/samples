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
	public abstract class AbstractStudentService : AbstractService
	{
		protected IStudentRepository StudentRepository { get; private set; }

		protected IApiStudentRequestModelValidator StudentModelValidator { get; private set; }

		protected IBOLStudentMapper BolStudentMapper { get; private set; }

		protected IDALStudentMapper DalStudentMapper { get; private set; }

		protected IBOLEventStudentMapper BolEventStudentMapper { get; private set; }

		protected IDALEventStudentMapper DalEventStudentMapper { get; private set; }

		private ILogger logger;

		public AbstractStudentService(
			ILogger logger,
			IStudentRepository studentRepository,
			IApiStudentRequestModelValidator studentModelValidator,
			IBOLStudentMapper bolStudentMapper,
			IDALStudentMapper dalStudentMapper,
			IBOLEventStudentMapper bolEventStudentMapper,
			IDALEventStudentMapper dalEventStudentMapper)
			: base()
		{
			this.StudentRepository = studentRepository;
			this.StudentModelValidator = studentModelValidator;
			this.BolStudentMapper = bolStudentMapper;
			this.DalStudentMapper = dalStudentMapper;
			this.BolEventStudentMapper = bolEventStudentMapper;
			this.DalEventStudentMapper = dalEventStudentMapper;
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

		public async virtual Task<List<ApiEventStudentResponseModel>> EventStudents(int studentId, int limit = int.MaxValue, int offset = 0)
		{
			List<EventStudent> records = await this.StudentRepository.EventStudents(studentId, limit, offset);

			return this.BolEventStudentMapper.MapBOToModel(this.DalEventStudentMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiStudentResponseModel>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0)
		{
			List<Student> records = await this.StudentRepository.ByEventId(eventId, limit, offset);

			return this.BolStudentMapper.MapBOToModel(this.DalStudentMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>642ec9c582101de1d83b1793530da095</Hash>
</Codenesium>*/