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
	public abstract class AbstractContactTypeService: AbstractService
	{
		private IContactTypeRepository contactTypeRepository;
		private IApiContactTypeRequestModelValidator contactTypeModelValidator;
		private IBOLContactTypeMapper BOLContactTypeMapper;
		private IDALContactTypeMapper DALContactTypeMapper;
		private ILogger logger;

		public AbstractContactTypeService(
			ILogger logger,
			IContactTypeRepository contactTypeRepository,
			IApiContactTypeRequestModelValidator contactTypeModelValidator,
			IBOLContactTypeMapper bolcontactTypeMapper,
			IDALContactTypeMapper dalcontactTypeMapper)
			: base()

		{
			this.contactTypeRepository = contactTypeRepository;
			this.contactTypeModelValidator = contactTypeModelValidator;
			this.BOLContactTypeMapper = bolcontactTypeMapper;
			this.DALContactTypeMapper = dalcontactTypeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiContactTypeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.contactTypeRepository.All(skip, take, orderClause);

			return this.BOLContactTypeMapper.MapBOToModel(this.DALContactTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiContactTypeResponseModel> Get(int contactTypeID)
		{
			var record = await contactTypeRepository.Get(contactTypeID);

			return this.BOLContactTypeMapper.MapBOToModel(this.DALContactTypeMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiContactTypeResponseModel>> Create(
			ApiContactTypeRequestModel model)
		{
			CreateResponse<ApiContactTypeResponseModel> response = new CreateResponse<ApiContactTypeResponseModel>(await this.contactTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLContactTypeMapper.MapModelToBO(default (int), model);
				var record = await this.contactTypeRepository.Create(this.DALContactTypeMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLContactTypeMapper.MapBOToModel(this.DALContactTypeMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int contactTypeID,
			ApiContactTypeRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.contactTypeModelValidator.ValidateUpdateAsync(contactTypeID, model));

			if (response.Success)
			{
				var bo = this.BOLContactTypeMapper.MapModelToBO(contactTypeID, model);
				await this.contactTypeRepository.Update(this.DALContactTypeMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int contactTypeID)
		{
			ActionResponse response = new ActionResponse(await this.contactTypeModelValidator.ValidateDeleteAsync(contactTypeID));

			if (response.Success)
			{
				await this.contactTypeRepository.Delete(contactTypeID);
			}
			return response;
		}

		public async Task<ApiContactTypeResponseModel> GetName(string name)
		{
			ContactType record = await this.contactTypeRepository.GetName(name);

			return this.BOLContactTypeMapper.MapBOToModel(this.DALContactTypeMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>ab163456013398632293580705d208af</Hash>
</Codenesium>*/