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
	public abstract class AbstractStudentXFamilyService: AbstractService
	{
		private IStudentXFamilyRepository studentXFamilyRepository;
		private IApiStudentXFamilyRequestModelValidator studentXFamilyModelValidator;
		private IBOLStudentXFamilyMapper bolStudentXFamilyMapper;
		private IDALStudentXFamilyMapper dalStudentXFamilyMapper;
		private ILogger logger;

		public AbstractStudentXFamilyService(
			ILogger logger,
			IStudentXFamilyRepository studentXFamilyRepository,
			IApiStudentXFamilyRequestModelValidator studentXFamilyModelValidator,
			IBOLStudentXFamilyMapper bolstudentXFamilyMapper,
			IDALStudentXFamilyMapper dalstudentXFamilyMapper)
			: base()

		{
			this.studentXFamilyRepository = studentXFamilyRepository;
			this.studentXFamilyModelValidator = studentXFamilyModelValidator;
			this.bolStudentXFamilyMapper = bolstudentXFamilyMapper;
			this.dalStudentXFamilyMapper = dalstudentXFamilyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStudentXFamilyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.studentXFamilyRepository.All(skip, take, orderClause);

			return this.bolStudentXFamilyMapper.MapBOToModel(this.dalStudentXFamilyMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiStudentXFamilyResponseModel> Get(int id)
		{
			var record = await studentXFamilyRepository.Get(id);

			return this.bolStudentXFamilyMapper.MapBOToModel(this.dalStudentXFamilyMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiStudentXFamilyResponseModel>> Create(
			ApiStudentXFamilyRequestModel model)
		{
			CreateResponse<ApiStudentXFamilyResponseModel> response = new CreateResponse<ApiStudentXFamilyResponseModel>(await this.studentXFamilyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolStudentXFamilyMapper.MapModelToBO(default (int), model);
				var record = await this.studentXFamilyRepository.Create(this.dalStudentXFamilyMapper.MapBOToEF(bo));

				response.SetRecord(this.bolStudentXFamilyMapper.MapBOToModel(this.dalStudentXFamilyMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiStudentXFamilyRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.studentXFamilyModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.bolStudentXFamilyMapper.MapModelToBO(id, model);
				await this.studentXFamilyRepository.Update(this.dalStudentXFamilyMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.studentXFamilyModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.studentXFamilyRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>636206b383cdefd756c9889a8eeb4f98</Hash>
</Codenesium>*/