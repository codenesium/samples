using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractPersonMapper
        {
                public virtual BOPerson MapModelToBO(
                        int businessEntityID,
                        ApiPersonRequestModel model
                        )
                {
                        BOPerson boPerson = new BOPerson();

                        boPerson.SetProperties(
                                businessEntityID,
                                model.AdditionalContactInfo,
                                model.Demographics,
                                model.EmailPromotion,
                                model.FirstName,
                                model.LastName,
                                model.MiddleName,
                                model.ModifiedDate,
                                model.NameStyle,
                                model.PersonType,
                                model.Rowguid,
                                model.Suffix,
                                model.Title);
                        return boPerson;
                }

                public virtual ApiPersonResponseModel MapBOToModel(
                        BOPerson boPerson)
                {
                        var model = new ApiPersonResponseModel();

                        model.SetProperties(boPerson.AdditionalContactInfo, boPerson.BusinessEntityID, boPerson.Demographics, boPerson.EmailPromotion, boPerson.FirstName, boPerson.LastName, boPerson.MiddleName, boPerson.ModifiedDate, boPerson.NameStyle, boPerson.PersonType, boPerson.Rowguid, boPerson.Suffix, boPerson.Title);

                        return model;
                }

                public virtual List<ApiPersonResponseModel> MapBOToModel(
                        List<BOPerson> items)
                {
                        List<ApiPersonResponseModel> response = new List<ApiPersonResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>ce2755db4c3b9be5cb33f5226d19d981</Hash>
</Codenesium>*/