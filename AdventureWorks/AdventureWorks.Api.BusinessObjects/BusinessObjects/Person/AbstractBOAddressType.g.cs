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
	public abstract class AbstractBOAddressType: AbstractBOManager
	{
		private IAddressTypeRepository addressTypeRepository;
		private IApiAddressTypeRequestModelValidator addressTypeModelValidator;
		private IBOLAddressTypeMapper addressTypeMapper;
		private ILogger logger;

		public AbstractBOAddressType(
			ILogger logger,
			IAddressTypeRepository addressTypeRepository,
			IApiAddressTypeRequestModelValidator addressTypeModelValidator,
			IBOLAddressTypeMapper addressTypeMapper)
			: base()

		{
			this.addressTypeRepository = addressTypeRepository;
			this.addressTypeModelValidator = addressTypeModelValidator;
			this.addressTypeMapper = addressTypeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAddressTypeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.addressTypeRepository.All(skip, take, orderClause);

			return this.addressTypeMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiAddressTypeResponseModel> Get(int addressTypeID)
		{
			var record = await addressTypeRepository.Get(addressTypeID);

			return this.addressTypeMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiAddressTypeResponseModel>> Create(
			ApiAddressTypeRequestModel model)
		{
			CreateResponse<ApiAddressTypeResponseModel> response = new CreateResponse<ApiAddressTypeResponseModel>(await this.addressTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.addressTypeMapper.MapModelToDTO(default (int), model);
				var record = await this.addressTypeRepository.Create(dto);

				response.SetRecord(this.addressTypeMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int addressTypeID,
			ApiAddressTypeRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.addressTypeModelValidator.ValidateUpdateAsync(addressTypeID, model));

			if (response.Success)
			{
				var dto = this.addressTypeMapper.MapModelToDTO(addressTypeID, model);
				await this.addressTypeRepository.Update(addressTypeID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int addressTypeID)
		{
			ActionResponse response = new ActionResponse(await this.addressTypeModelValidator.ValidateDeleteAsync(addressTypeID));

			if (response.Success)
			{
				await this.addressTypeRepository.Delete(addressTypeID);
			}
			return response;
		}

		public async Task<ApiAddressTypeResponseModel> GetName(string name)
		{
			DTOAddressType record = await this.addressTypeRepository.GetName(name);

			return this.addressTypeMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>0f0a974f5d80e1c1d2376dcb670ab992</Hash>
</Codenesium>*/