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
	public abstract class AbstractTeacherService: AbstractService
	{
		private ITeacherRepository teacherRepository;
		private IApiTeacherRequestModelValidator teacherModelValidator;
		private IBOLTeacherMapper bolTeacherMapper;
		private IDALTeacherMapper dalTeacherMapper;
		private ILogger logger;

		public AbstractTeacherService(
			ILogger logger,
			ITeacherRepository teacherRepository,
			IApiTeacherRequestModelValidator teacherModelValidator,
			IBOLTeacherMapper bolteacherMapper,
			IDALTeacherMapper dalteacherMapper)
			: base()

		{
			this.teacherRepository = teacherRepository;
			this.teacherModelValidator = teacherModelValidator;
			this.bolTeacherMapper = bolteacherMapper;
			this.dalTeacherMapper = dalteacherMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTeacherResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.teacherRepository.All(skip, take, orderClause);

			return this.bolTeacherMapper.MapBOToModel(this.dalTeacherMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTeacherResponseModel> Get(int id)
		{
			var record = await teacherRepository.Get(id);

			return this.bolTeacherMapper.MapBOToModel(this.dalTeacherMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiTeacherResponseModel>> Create(
			ApiTeacherRequestModel model)
		{
			CreateResponse<ApiTeacherResponseModel> response = new CreateResponse<ApiTeacherResponseModel>(await this.teacherModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolTeacherMapper.MapModelToBO(default (int), model);
				var record = await this.teacherRepository.Create(this.dalTeacherMapper.MapBOToEF(bo));

				response.SetRecord(this.bolTeacherMapper.MapBOToModel(this.dalTeacherMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiTeacherRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.teacherModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.bolTeacherMapper.MapModelToBO(id, model);
				await this.teacherRepository.Update(this.dalTeacherMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.teacherModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.teacherRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>539dfd330f6edd76f51396a0ccf44913</Hash>
</Codenesium>*/