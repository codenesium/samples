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

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBusinessEntityService: AbstractService
	{
		private IBusinessEntityRepository businessEntityRepository;
		private IApiBusinessEntityRequestModelValidator businessEntityModelValidator;
		private IBOLBusinessEntityMapper BOLBusinessEntityMapper;
		private IDALBusinessEntityMapper DALBusinessEntityMapper;
		private ILogger logger;

		public AbstractBusinessEntityService(
			ILogger logger,
			IBusinessEntityRepository businessEntityRepository,
			IApiBusinessEntityRequestModelValidator businessEntityModelValidator,
			IBOLBusinessEntityMapper bolbusinessEntityMapper,
			IDALBusinessEntityMapper dalbusinessEntityMapper)
			: base()

		{
			this.businessEntityRepository = businessEntityRepository;
			this.businessEntityModelValidator = businessEntityModelValidator;
			this.BOLBusinessEntityMapper = bolbusinessEntityMapper;
			this.DALBusinessEntityMapper = dalbusinessEntityMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBusinessEntityResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.businessEntityRepository.All(skip, take, orderClause);

			return this.BOLBusinessEntityMapper.MapBOToModel(this.DALBusinessEntityMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBusinessEntityResponseModel> Get(int businessEntityID)
		{
			var record = await businessEntityRepository.Get(businessEntityID);

			return this.BOLBusinessEntityMapper.MapBOToModel(this.DALBusinessEntityMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiBusinessEntityResponseModel>> Create(
			ApiBusinessEntityRequestModel model)
		{
			CreateResponse<ApiBusinessEntityResponseModel> response = new CreateResponse<ApiBusinessEntityResponseModel>(await this.businessEntityModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLBusinessEntityMapper.MapModelToBO(default (int), model);
				var record = await this.businessEntityRepository.Create(this.DALBusinessEntityMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLBusinessEntityMapper.MapBOToModel(this.DALBusinessEntityMapper.MapEFToBO(record)));
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
				var bo = this.BOLBusinessEntityMapper.MapModelToBO(businessEntityID, model);
				await this.businessEntityRepository.Update(this.DALBusinessEntityMapper.MapBOToEF(bo));
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
    <Hash>82f9f2809bb222d2c193547d3643826b</Hash>
</Codenesium>*/