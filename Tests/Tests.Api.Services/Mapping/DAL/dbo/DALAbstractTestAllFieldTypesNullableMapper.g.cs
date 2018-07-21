using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public abstract class DALAbstractTestAllFieldTypesNullableMapper
        {
                public virtual TestAllFieldTypesNullable MapBOToEF(
                        BOTestAllFieldTypesNullable bo)
                {
                        TestAllFieldTypesNullable efTestAllFieldTypesNullable = new TestAllFieldTypesNullable();
                        efTestAllFieldTypesNullable.SetProperties(
                                bo.FieldBigInt,
                                bo.FieldBinary,
                                bo.FieldBit,
                                bo.FieldChar,
                                bo.FieldDate,
                                bo.FieldDateTime,
                                bo.FieldDateTime2,
                                bo.FieldDateTimeOffset,
                                bo.FieldDecimal,
                                bo.FieldFloat,
                                bo.FieldImage,
                                bo.FieldMoney,
                                bo.FieldNChar,
                                bo.FieldNText,
                                bo.FieldNumeric,
                                bo.FieldNVarchar,
                                bo.FieldReal,
                                bo.FieldSmallDateTime,
                                bo.FieldSmallInt,
                                bo.FieldSmallMoney,
                                bo.FieldText,
                                bo.FieldTime,
                                bo.FieldTimestamp,
                                bo.FieldTinyInt,
                                bo.FieldUniqueIdentifier,
                                bo.FieldVarBinary,
                                bo.FieldVarchar,
                                bo.FieldXML,
                                bo.Id);
                        return efTestAllFieldTypesNullable;
                }

                public virtual BOTestAllFieldTypesNullable MapEFToBO(
                        TestAllFieldTypesNullable ef)
                {
                        var bo = new BOTestAllFieldTypesNullable();

                        bo.SetProperties(
                                ef.Id,
                                ef.FieldBigInt,
                                ef.FieldBinary,
                                ef.FieldBit,
                                ef.FieldChar,
                                ef.FieldDate,
                                ef.FieldDateTime,
                                ef.FieldDateTime2,
                                ef.FieldDateTimeOffset,
                                ef.FieldDecimal,
                                ef.FieldFloat,
                                ef.FieldImage,
                                ef.FieldMoney,
                                ef.FieldNChar,
                                ef.FieldNText,
                                ef.FieldNumeric,
                                ef.FieldNVarchar,
                                ef.FieldReal,
                                ef.FieldSmallDateTime,
                                ef.FieldSmallInt,
                                ef.FieldSmallMoney,
                                ef.FieldText,
                                ef.FieldTime,
                                ef.FieldTimestamp,
                                ef.FieldTinyInt,
                                ef.FieldUniqueIdentifier,
                                ef.FieldVarBinary,
                                ef.FieldVarchar,
                                ef.FieldXML);
                        return bo;
                }

                public virtual List<BOTestAllFieldTypesNullable> MapEFToBO(
                        List<TestAllFieldTypesNullable> records)
                {
                        List<BOTestAllFieldTypesNullable> response = new List<BOTestAllFieldTypesNullable>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a3656308ebaa45bd2d47350ab3b4daa8</Hash>
</Codenesium>*/