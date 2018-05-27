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

namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOAdmin: AbstractBOManager
	{
		private IAdminRepository adminRepository;
		private IApiAdminRequestModelValidator adminModelValidator;
		private IBOLAdminMapper adminMapper;
		private ILogger logger;

		public AbstractBOAdmin(
			ILogger logger,
			IAdminRepository adminRepository,
			IApiAdminRequestModelValidator adminModelValidator,
			IBOLAdminMapper adminMapper)
			: base()

		{
			this.adminRepository = adminRepository;
			this.adminModelValidator = adminModelValidator;
			this.adminMapper = adminMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAdminResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.adminRepository.All(skip, take, orderClause);

			return this.adminMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiAdminResponseModel> Get(int id)
		{
			var record = await adminRepository.Get(id);

			return this.adminMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiAdminResponseModel>> Create(
			ApiAdminRequestModel model)
		{
			CreateResponse<ApiAdminResponseModel> response = new CreateResponse<ApiAdminResponseModel>(await this.adminModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.adminMapper.MapModelToDTO(default (int), model);
				var record = await this.adminRepository.Create(dto);

				response.SetRecord(this.adminMapper.MapDTOToModel(record));
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
				var dto = this.adminMapper.MapModelToDTO(id, model);
				await this.adminRepository.Update(id, dto);
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
    <Hash>df9e1acda934f381b4980ebe40755c51</Hash>
</Codenesium>*/