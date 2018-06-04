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
	public abstract class AbstractBusinessEntityContactService: AbstractService
	{
		private IBusinessEntityContactRepository businessEntityContactRepository;
		private IApiBusinessEntityContactRequestModelValidator businessEntityContactModelValidator;
		private IBOLBusinessEntityContactMapper BOLBusinessEntityContactMapper;
		private IDALBusinessEntityContactMapper DALBusinessEntityContactMapper;
		private ILogger logger;

		public AbstractBusinessEntityContactService(
			ILogger logger,
			IBusinessEntityContactRepository businessEntityContactRepository,
			IApiBusinessEntityContactRequestModelValidator businessEntityContactModelValidator,
			IBOLBusinessEntityContactMapper bolbusinessEntityContactMapper,
			IDALBusinessEntityContactMapper dalbusinessEntityContactMapper)
			: base()

		{
			this.businessEntityContactRepository = businessEntityContactRepository;
			this.businessEntityContactModelValidator = businessEntityContactModelValidator;
			this.BOLBusinessEntityContactMapper = bolbusinessEntityContactMapper;
			this.DALBusinessEntityContactMapper = dalbusinessEntityContactMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBusinessEntityContactResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.businessEntityContactRepository.All(skip, take, orderClause);

			return this.BOLBusinessEntityContactMapper.MapBOToModel(this.DALBusinessEntityContactMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBusinessEntityContactResponseModel> Get(int businessEntityID)
		{
			var record = await businessEntityContactRepository.Get(businessEntityID);

			return this.BOLBusinessEntityContactMapper.MapBOToModel(this.DALBusinessEntityContactMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiBusinessEntityContactResponseModel>> Create(
			ApiBusinessEntityContactRequestModel model)
		{
			CreateResponse<ApiBusinessEntityContactResponseModel> response = new CreateResponse<ApiBusinessEntityContactResponseModel>(await this.businessEntityContactModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLBusinessEntityContactMapper.MapModelToBO(default (int), model);
				var record = await this.businessEntityContactRepository.Create(this.DALBusinessEntityContactMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLBusinessEntityContactMapper.MapBOToModel(this.DALBusinessEntityContactMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiBusinessEntityContactRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityContactModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var bo = this.BOLBusinessEntityContactMapper.MapModelToBO(businessEntityID, model);
				await this.businessEntityContactRepository.Update(this.DALBusinessEntityContactMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityContactModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.businessEntityContactRepository.Delete(businessEntityID);
			}
			return response;
		}

		public async Task<List<ApiBusinessEntityContactResponseModel>> GetContactTypeID(int contactTypeID)
		{
			List<BusinessEntityContact> records = await this.businessEntityContactRepository.GetContactTypeID(contactTypeID);

			return this.BOLBusinessEntityContactMapper.MapBOToModel(this.DALBusinessEntityContactMapper.MapEFToBO(records));
		}
		public async Task<List<ApiBusinessEntityContactResponseModel>> GetPersonID(int personID)
		{
			List<BusinessEntityContact> records = await this.businessEntityContactRepository.GetPersonID(personID);

			return this.BOLBusinessEntityContactMapper.MapBOToModel(this.DALBusinessEntityContactMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>76d5478fbd91ee468a8131957b904876</Hash>
</Codenesium>*/