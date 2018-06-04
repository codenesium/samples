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
	public abstract class AbstractStudentService: AbstractService
	{
		private IStudentRepository studentRepository;
		private IApiStudentRequestModelValidator studentModelValidator;
		private IBOLStudentMapper BOLStudentMapper;
		private IDALStudentMapper DALStudentMapper;
		private ILogger logger;

		public AbstractStudentService(
			ILogger logger,
			IStudentRepository studentRepository,
			IApiStudentRequestModelValidator studentModelValidator,
			IBOLStudentMapper bolstudentMapper,
			IDALStudentMapper dalstudentMapper)
			: base()

		{
			this.studentRepository = studentRepository;
			this.studentModelValidator = studentModelValidator;
			this.BOLStudentMapper = bolstudentMapper;
			this.DALStudentMapper = dalstudentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStudentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.studentRepository.All(skip, take, orderClause);

			return this.BOLStudentMapper.MapBOToModel(this.DALStudentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiStudentResponseModel> Get(int id)
		{
			var record = await studentRepository.Get(id);

			return this.BOLStudentMapper.MapBOToModel(this.DALStudentMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiStudentResponseModel>> Create(
			ApiStudentRequestModel model)
		{
			CreateResponse<ApiStudentResponseModel> response = new CreateResponse<ApiStudentResponseModel>(await this.studentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLStudentMapper.MapModelToBO(default (int), model);
				var record = await this.studentRepository.Create(this.DALStudentMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLStudentMapper.MapBOToModel(this.DALStudentMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiStudentRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.studentModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLStudentMapper.MapModelToBO(id, model);
				await this.studentRepository.Update(this.DALStudentMapper.MapBOToEF(bo));
			}

			return response;
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
	}
}

/*<Codenesium>
    <Hash>c7fda2273c8c0b2c7376c9b891c52b25</Hash>
</Codenesium>*/