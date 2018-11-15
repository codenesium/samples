using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractAddressTypeService : AbstractService
	{
		protected IAddressTypeRepository AddressTypeRepository { get; private set; }

		protected IApiAddressTypeServerRequestModelValidator AddressTypeModelValidator { get; private set; }

		protected IBOLAddressTypeMapper BolAddressTypeMapper { get; private set; }

		protected IDALAddressTypeMapper DalAddressTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractAddressTypeService(
			ILogger logger,
			IAddressTypeRepository addressTypeRepository,
			IApiAddressTypeServerRequestModelValidator addressTypeModelValidator,
			IBOLAddressTypeMapper bolAddressTypeMapper,
			IDALAddressTypeMapper dalAddressTypeMapper)
			: base()
		{
			this.AddressTypeRepository = addressTypeRepository;
			this.AddressTypeModelValidator = addressTypeModelValidator;
			this.BolAddressTypeMapper = bolAddressTypeMapper;
			this.DalAddressTypeMapper = dalAddressTypeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAddressTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.AddressTypeRepository.All(limit, offset);

			return this.BolAddressTypeMapper.MapBOToModel(this.DalAddressTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAddressTypeServerResponseModel> Get(int addressTypeID)
		{
			var record = await this.AddressTypeRepository.Get(addressTypeID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolAddressTypeMapper.MapBOToModel(this.DalAddressTypeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiAddressTypeServerResponseModel>> Create(
			ApiAddressTypeServerRequestModel model)
		{
			CreateResponse<ApiAddressTypeServerResponseModel> response = ValidationResponseFactory<ApiAddressTypeServerResponseModel>.CreateResponse(await this.AddressTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolAddressTypeMapper.MapModelToBO(default(int), model);
				var record = await this.AddressTypeRepository.Create(this.DalAddressTypeMapper.MapBOToEF(bo));

				response.SetRecord(this.BolAddressTypeMapper.MapBOToModel(this.DalAddressTypeMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiAddressTypeServerResponseModel>> Update(
			int addressTypeID,
			ApiAddressTypeServerRequestModel model)
		{
			var validationResult = await this.AddressTypeModelValidator.ValidateUpdateAsync(addressTypeID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolAddressTypeMapper.MapModelToBO(addressTypeID, model);
				await this.AddressTypeRepository.Update(this.DalAddressTypeMapper.MapBOToEF(bo));

				var record = await this.AddressTypeRepository.Get(addressTypeID);

				return ValidationResponseFactory<ApiAddressTypeServerResponseModel>.UpdateResponse(this.BolAddressTypeMapper.MapBOToModel(this.DalAddressTypeMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiAddressTypeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int addressTypeID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.AddressTypeModelValidator.ValidateDeleteAsync(addressTypeID));

			if (response.Success)
			{
				await this.AddressTypeRepository.Delete(addressTypeID);
			}

			return response;
		}

		public async virtual Task<ApiAddressTypeServerResponseModel> ByName(string name)
		{
			AddressType record = await this.AddressTypeRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolAddressTypeMapper.MapBOToModel(this.DalAddressTypeMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<ApiAddressTypeServerResponseModel> ByRowguid(Guid rowguid)
		{
			AddressType record = await this.AddressTypeRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolAddressTypeMapper.MapBOToModel(this.DalAddressTypeMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>595b7c3d8d0fe6d3bf26fe1dfbacac12</Hash>
</Codenesium>*/