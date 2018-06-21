using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractPersonMapper
        {
                public virtual Person MapBOToEF(
                        BOPerson bo)
                {
                        Person efPerson = new Person();
                        efPerson.SetProperties(
                                bo.AdditionalContactInfo,
                                bo.BusinessEntityID,
                                bo.Demographics,
                                bo.EmailPromotion,
                                bo.FirstName,
                                bo.LastName,
                                bo.MiddleName,
                                bo.ModifiedDate,
                                bo.NameStyle,
                                bo.PersonType,
                                bo.Rowguid,
                                bo.Suffix,
                                bo.Title);
                        return efPerson;
                }

                public virtual BOPerson MapEFToBO(
                        Person ef)
                {
                        var bo = new BOPerson();

                        bo.SetProperties(
                                ef.BusinessEntityID,
                                ef.AdditionalContactInfo,
                                ef.Demographics,
                                ef.EmailPromotion,
                                ef.FirstName,
                                ef.LastName,
                                ef.MiddleName,
                                ef.ModifiedDate,
                                ef.NameStyle,
                                ef.PersonType,
                                ef.Rowguid,
                                ef.Suffix,
                                ef.Title);
                        return bo;
                }

                public virtual List<BOPerson> MapEFToBO(
                        List<Person> records)
                {
                        List<BOPerson> response = new List<BOPerson>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>09e37079f9f3dce4c970cb43e03751cc</Hash>
</Codenesium>*/