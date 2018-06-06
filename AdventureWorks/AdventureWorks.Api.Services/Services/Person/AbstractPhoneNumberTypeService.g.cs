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
	public abstract class AbstractPhoneNumberTypeService: AbstractService
	{
		private IPhoneNumberTypeRepository phoneNumberTypeRepository;
		private IApiPhoneNumberTypeRequestModelValidator phoneNumberTypeModelValidator;
		private IBOLPhoneNumberTypeMapper bolPhoneNumberTypeMapper;
		private IDALPhoneNumberTypeMapper dalPhoneNumberTypeMapper;
		private ILogger logger;

		public AbstractPhoneNumberTypeService(
			ILogger logger,
			IPhoneNumberTypeRepository phoneNumberTypeRepository,
			IApiPhoneNumberTypeRequestModelValidator phoneNumberTypeModelValidator,
			IBOLPhoneNumberTypeMapper bolphoneNumberTypeMapper,
			IDALPhoneNumberTypeMapper dalphoneNumberTypeMapper)
			: base()

		{
			this.phoneNumberTypeRepository = phoneNumberTypeRepository;
			this.phoneNumberTypeModelValidator = phoneNumberTypeModelValidator;
			this.bolPhoneNumberTypeMapper = bolphoneNumberTypeMapper;
			this.dalPhoneNumberTypeMapper = dalphoneNumberTypeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPhoneNumberTypeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.phoneNumberTypeRepository.All(skip, take, orderClause);

			return this.bolPhoneNumberTypeMapper.MapBOToModel(this.dalPhoneNumberTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPhoneNumberTypeResponseModel> Get(int phoneNumberTypeID)
		{
			var record = await phoneNumberTypeRepository.Get(phoneNumberTypeID);

			return this.bolPhoneNumberTypeMapper.MapBOToModel(this.dalPhoneNumberTypeMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiPhoneNumberTypeResponseModel>> Create(
			ApiPhoneNumberTypeRequestModel model)
		{
			CreateResponse<ApiPhoneNumberTypeResponseModel> response = new CreateResponse<ApiPhoneNumberTypeResponseModel>(await this.phoneNumberTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolPhoneNumberTypeMapper.MapModelToBO(default (int), model);
				var record = await this.phoneNumberTypeRepository.Create(this.dalPhoneNumberTypeMapper.MapBOToEF(bo));

				response.SetRecord(this.bolPhoneNumberTypeMapper.MapBOToModel(this.dalPhoneNumberTypeMapper.MapEFToBO(record)));
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
				var bo = this.bolPhoneNumberTypeMapper.MapModelToBO(phoneNumberTypeID, model);
				await this.phoneNumberTypeRepository.Update(this.dalPhoneNumberTypeMapper.MapBOToEF(bo));
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
    <Hash>ffd405c306cd4c13e1e24bbe1e3d5852</Hash>
</Codenesium>*/