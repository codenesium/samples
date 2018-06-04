using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLBusinessEntityContactMapper
	{
		BOBusinessEntityContact MapModelToBO(
			int businessEntityID,
			ApiBusinessEntityContactRequestModel model);

		ApiBusinessEntityContactResponseModel MapBOToModel(
			BOBusinessEntityContact boBusinessEntityContact);

		List<ApiBusinessEntityContactResponseModel> MapBOToModel(
			List<BOBusinessEntityContact> bos);
	}
}

/*<Codenesium>
    <Hash>b5f994b36ff7014ad099309c0963d950</Hash>
</Codenesium>*/