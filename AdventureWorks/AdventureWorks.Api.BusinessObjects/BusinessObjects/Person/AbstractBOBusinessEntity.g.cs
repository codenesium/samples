using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOBusinessEntity: AbstractBOManager
	{
		private IBusinessEntityRepository businessEntityRepository;
		private IApiBusinessEntityRequestModelValidator businessEntityModelValidator;
		private IBOLBusinessEntityMapper businessEntityMapper;
		private ILogger logger;

		public AbstractBOBusinessEntity(
			ILogger logger,
			IBusinessEntityRepository businessEntityRepository,
			IApiBusinessEntityRequestModelValidator businessEntityModelValidator,
			IBOLBusinessEntityMapper businessEntityMapper)
			: base()

		{
			this.businessEntityRepository = businessEntityRepository;
			this.businessEntityModelValidator = businessEntityModelValidator;
			this.businessEntityMapper = businessEntityMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBusinessEntityResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.businessEntityRepository.All(skip, take, orderClause);

			return this.businessEntityMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiBusinessEntityResponseModel> Get(int businessEntityID)
		{
			var record = await businessEntityRepository.Get(businessEntityID);

			return this.businessEntityMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiBusinessEntityResponseModel>> Create(
			ApiBusinessEntityRequestModel model)
		{
			CreateResponse<ApiBusinessEntityResponseModel> response = new CreateResponse<ApiBusinessEntityResponseModel>(await this.businessEntityModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.businessEntityMapper.MapModelToDTO(default (int), model);
				var record = await this.businessEntityRepository.Create(dto);

				response.SetRecord(this.businessEntityMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiBusinessEntityRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var dto = this.businessEntityMapper.MapModelToDTO(businessEntityID, model);
				await this.businessEntityRepository.Update(businessEntityID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.businessEntityRepository.Delete(businessEntityID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>41a8e8c958490d374928b6d59d2f2e5b</Hash>
</Codenesium>*/