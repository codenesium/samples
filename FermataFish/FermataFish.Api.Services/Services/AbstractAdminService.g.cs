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
	public abstract class AbstractAdminService: AbstractService
	{
		private IAdminRepository adminRepository;
		private IApiAdminRequestModelValidator adminModelValidator;
		private IBOLAdminMapper BOLAdminMapper;
		private IDALAdminMapper DALAdminMapper;
		private ILogger logger;

		public AbstractAdminService(
			ILogger logger,
			IAdminRepository adminRepository,
			IApiAdminRequestModelValidator adminModelValidator,
			IBOLAdminMapper boladminMapper,
			IDALAdminMapper daladminMapper)
			: base()

		{
			this.adminRepository = adminRepository;
			this.adminModelValidator = adminModelValidator;
			this.BOLAdminMapper = boladminMapper;
			this.DALAdminMapper = daladminMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAdminResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.adminRepository.All(skip, take, orderClause);

			return this.BOLAdminMapper.MapBOToModel(this.DALAdminMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAdminResponseModel> Get(int id)
		{
			var record = await adminRepository.Get(id);

			return this.BOLAdminMapper.MapBOToModel(this.DALAdminMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiAdminResponseModel>> Create(
			ApiAdminRequestModel model)
		{
			CreateResponse<ApiAdminResponseModel> response = new CreateResponse<ApiAdminResponseModel>(await this.adminModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLAdminMapper.MapModelToBO(default (int), model);
				var record = await this.adminRepository.Create(this.DALAdminMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLAdminMapper.MapBOToModel(this.DALAdminMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiAdminRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.adminModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLAdminMapper.MapModelToBO(id, model);
				await this.adminRepository.Update(this.DALAdminMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.adminModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.adminRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4e19fb8121d01d6afe76c2a341b0a4f5</Hash>
</Codenesium>*/