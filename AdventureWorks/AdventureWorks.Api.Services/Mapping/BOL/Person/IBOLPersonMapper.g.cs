using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLPersonMapper
	{
		BOPerson MapModelToBO(
			int businessEntityID,
			ApiPersonRequestModel model);

		ApiPersonResponseModel MapBOToModel(
			BOPerson boPerson);

		List<ApiPersonResponseModel> MapBOToModel(
			List<BOPerson> items);
	}
}

/*<Codenesium>
    <Hash>aa24950dc08846c464391eca30096dfd</Hash>
</Codenesium>*/