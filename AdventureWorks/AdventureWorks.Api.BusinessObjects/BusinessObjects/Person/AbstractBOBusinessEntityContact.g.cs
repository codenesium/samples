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
	public abstract class AbstractBOBusinessEntityContact: AbstractBOManager
	{
		private IBusinessEntityContactRepository businessEntityContactRepository;
		private IApiBusinessEntityContactRequestModelValidator businessEntityContactModelValidator;
		private IBOLBusinessEntityContactMapper businessEntityContactMapper;
		private ILogger logger;

		public AbstractBOBusinessEntityContact(
			ILogger logger,
			IBusinessEntityContactRepository businessEntityContactRepository,
			IApiBusinessEntityContactRequestModelValidator businessEntityContactModelValidator,
			IBOLBusinessEntityContactMapper businessEntityContactMapper)
			: base()

		{
			this.businessEntityContactRepository = businessEntityContactRepository;
			this.businessEntityContactModelValidator = businessEntityContactModelValidator;
			this.businessEntityContactMapper = businessEntityContactMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBusinessEntityContactResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.businessEntityContactRepository.All(skip, take, orderClause);

			return this.businessEntityContactMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiBusinessEntityContactResponseModel> Get(int businessEntityID)
		{
			var record = await businessEntityContactRepository.Get(businessEntityID);

			return this.businessEntityContactMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiBusinessEntityContactResponseModel>> Create(
			ApiBusinessEntityContactRequestModel model)
		{
			CreateResponse<ApiBusinessEntityContactResponseModel> response = new CreateResponse<ApiBusinessEntityContactResponseModel>(await this.businessEntityContactModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.businessEntityContactMapper.MapModelToDTO(default (int), model);
				var record = await this.businessEntityContactRepository.Create(dto);

				response.SetRecord(this.businessEntityContactMapper.MapDTOToModel(record));
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
				var dto = this.businessEntityContactMapper.MapModelToDTO(businessEntityID, model);
				await this.businessEntityContactRepository.Update(businessEntityID, dto);
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
			List<DTOBusinessEntityContact> records = await this.businessEntityContactRepository.GetContactTypeID(contactTypeID);

			return this.businessEntityContactMapper.MapDTOToModel(records);
		}
		public async Task<List<ApiBusinessEntityContactResponseModel>> GetPersonID(int personID)
		{
			List<DTOBusinessEntityContact> records = await this.businessEntityContactRepository.GetPersonID(personID);

			return this.businessEntityContactMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>3a4f1cdf63945a508f8e11a68e98db3f</Hash>
</Codenesium>*/