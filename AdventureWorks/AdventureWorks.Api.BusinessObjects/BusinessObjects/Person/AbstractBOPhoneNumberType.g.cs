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
	public abstract class AbstractBOPhoneNumberType: AbstractBOManager
	{
		private IPhoneNumberTypeRepository phoneNumberTypeRepository;
		private IApiPhoneNumberTypeRequestModelValidator phoneNumberTypeModelValidator;
		private IBOLPhoneNumberTypeMapper phoneNumberTypeMapper;
		private ILogger logger;

		public AbstractBOPhoneNumberType(
			ILogger logger,
			IPhoneNumberTypeRepository phoneNumberTypeRepository,
			IApiPhoneNumberTypeRequestModelValidator phoneNumberTypeModelValidator,
			IBOLPhoneNumberTypeMapper phoneNumberTypeMapper)
			: base()

		{
			this.phoneNumberTypeRepository = phoneNumberTypeRepository;
			this.phoneNumberTypeModelValidator = phoneNumberTypeModelValidator;
			this.phoneNumberTypeMapper = phoneNumberTypeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPhoneNumberTypeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.phoneNumberTypeRepository.All(skip, take, orderClause);

			return this.phoneNumberTypeMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiPhoneNumberTypeResponseModel> Get(int phoneNumberTypeID)
		{
			var record = await phoneNumberTypeRepository.Get(phoneNumberTypeID);

			return this.phoneNumberTypeMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiPhoneNumberTypeResponseModel>> Create(
			ApiPhoneNumberTypeRequestModel model)
		{
			CreateResponse<ApiPhoneNumberTypeResponseModel> response = new CreateResponse<ApiPhoneNumberTypeResponseModel>(await this.phoneNumberTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.phoneNumberTypeMapper.MapModelToDTO(default (int), model);
				var record = await this.phoneNumberTypeRepository.Create(dto);

				response.SetRecord(this.phoneNumberTypeMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.phoneNumberTypeModelValidator.ValidateUpdateAsync(phoneNumberTypeID, model));

			if (response.Success)
			{
				var dto = this.phoneNumberTypeMapper.MapModelToDTO(phoneNumberTypeID, model);
				await this.phoneNumberTypeRepository.Update(phoneNumberTypeID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int phoneNumberTypeID)
		{
			ActionResponse response = new ActionResponse(await this.phoneNumberTypeModelValidator.ValidateDeleteAsync(phoneNumberTypeID));

			if (response.Success)
			{
				await this.phoneNumberTypeRepository.Delete(phoneNumberTypeID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>61a78b9ff752cd956444a9b1da7a1066</Hash>
</Codenesium>*/