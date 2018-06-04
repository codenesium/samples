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
	public abstract class AbstractAddressTypeService: AbstractService
	{
		private IAddressTypeRepository addressTypeRepository;
		private IApiAddressTypeRequestModelValidator addressTypeModelValidator;
		private IBOLAddressTypeMapper BOLAddressTypeMapper;
		private IDALAddressTypeMapper DALAddressTypeMapper;
		private ILogger logger;

		public AbstractAddressTypeService(
			ILogger logger,
			IAddressTypeRepository addressTypeRepository,
			IApiAddressTypeRequestModelValidator addressTypeModelValidator,
			IBOLAddressTypeMapper boladdressTypeMapper,
			IDALAddressTypeMapper daladdressTypeMapper)
			: base()

		{
			this.addressTypeRepository = addressTypeRepository;
			this.addressTypeModelValidator = addressTypeModelValidator;
			this.BOLAddressTypeMapper = boladdressTypeMapper;
			this.DALAddressTypeMapper = daladdressTypeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAddressTypeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.addressTypeRepository.All(skip, take, orderClause);

			return this.BOLAddressTypeMapper.MapBOToModel(this.DALAddressTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAddressTypeResponseModel> Get(int addressTypeID)
		{
			var record = await addressTypeRepository.Get(addressTypeID);

			return this.BOLAddressTypeMapper.MapBOToModel(this.DALAddressTypeMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiAddressTypeResponseModel>> Create(
			ApiAddressTypeRequestModel model)
		{
			CreateResponse<ApiAddressTypeResponseModel> response = new CreateResponse<ApiAddressTypeResponseModel>(await this.addressTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLAddressTypeMapper.MapModelToBO(default (int), model);
				var record = await this.addressTypeRepository.Create(this.DALAddressTypeMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLAddressTypeMapper.MapBOToModel(this.DALAddressTypeMapper.MapEFToBO(record)));
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
				var bo = this.BOLAddressTypeMapper.MapModelToBO(addressTypeID, model);
				await this.addressTypeRepository.Update(this.DALAddressTypeMapper.MapBOToEF(bo));
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
			AddressType record = await this.addressTypeRepository.GetName(name);

			return this.BOLAddressTypeMapper.MapBOToModel(this.DALAddressTypeMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>f12a934ea4653556801f091efc820aa8</Hash>
</Codenesium>*/