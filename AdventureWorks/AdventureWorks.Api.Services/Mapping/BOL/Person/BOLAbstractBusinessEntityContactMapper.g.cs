using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractBusinessEntityContactMapper
        {
                public virtual BOBusinessEntityContact MapModelToBO(
                        int businessEntityID,
                        ApiBusinessEntityContactRequestModel model
                        )
                {
                        BOBusinessEntityContact boBusinessEntityContact = new BOBusinessEntityContact();
                        boBusinessEntityContact.SetProperties(
                                businessEntityID,
                                model.ContactTypeID,
                                model.ModifiedDate,
                                model.PersonID,
                                model.Rowguid);
                        return boBusinessEntityContact;
                }

                public virtual ApiBusinessEntityContactResponseModel MapBOToModel(
                        BOBusinessEntityContact boBusinessEntityContact)
                {
                        var model = new ApiBusinessEntityContactResponseModel();

                        model.SetProperties(boBusinessEntityContact.BusinessEntityID, boBusinessEntityContact.ContactTypeID, boBusinessEntityContact.ModifiedDate, boBusinessEntityContact.PersonID, boBusinessEntityContact.Rowguid);

                        return model;
                }

                public virtual List<ApiBusinessEntityContactResponseModel> MapBOToModel(
                        List<BOBusinessEntityContact> items)
                {
                        List<ApiBusinessEntityContactResponseModel> response = new List<ApiBusinessEntityContactResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a016c18cb005ebdf69822fe3af35a34a</Hash>
</Codenesium>*/