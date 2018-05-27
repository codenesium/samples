using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOOrganization: AbstractBOManager
	{
		private IOrganizationRepository organizationRepository;
		private IApiOrganizationRequestModelValidator organizationModelValidator;
		private IBOLOrganizationMapper organizationMapper;
		private ILogger logger;

		public AbstractBOOrganization(
			ILogger logger,
			IOrganizationRepository organizationRepository,
			IApiOrganizationRequestModelValidator organizationModelValidator,
			IBOLOrganizationMapper organizationMapper)
			: base()

		{
			this.organizationRepository = organizationRepository;
			this.organizationModelValidator = organizationModelValidator;
			this.organizationMapper = organizationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiOrganizationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.organizationRepository.All(skip, take, orderClause);

			return this.organizationMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiOrganizationResponseModel> Get(int id)
		{
			var record = await organizationRepository.Get(id);

			return this.organizationMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiOrganizationResponseModel>> Create(
			ApiOrganizationRequestModel model)
		{
			CreateResponse<ApiOrganizationResponseModel> response = new CreateResponse<ApiOrganizationResponseModel>(await this.organizationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.organizationMapper.MapModelToDTO(default (int), model);
				var record = await this.organizationRepository.Create(dto);

				response.SetRecord(this.organizationMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiOrganizationRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.organizationModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.organizationMapper.MapModelToDTO(id, model);
				await this.organizationRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.organizationModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.organizationRepository.Delete(id);
			}
			return response;
		}

		public async Task<ApiOrganizationResponseModel> GetName(string name)
		{
			DTOOrganization record = await this.organizationRepository.GetName(name);

			return this.organizationMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>eb28e0e405efd5cd5868ce1adb6aba88</Hash>
</Codenesium>*/