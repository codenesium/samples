import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import TestAllFieldTypesNullableViewModel from './testAllFieldTypesNullableViewModel';
import TestAllFieldTypesNullableMapper from './testAllFieldTypesNullableMapper';

interface Props {
    model?:TestAllFieldTypesNullableViewModel
}

  const TestAllFieldTypesNullableEditDisplay = (props: FormikProps<TestAllFieldTypesNullableViewModel>) => {

   let status = props.status as UpdateResponse<Api.TestAllFieldTypesNullableClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof TestAllFieldTypesNullableViewModel]  && props.errors[name as keyof TestAllFieldTypesNullableViewModel]) {
            response += props.errors[name as keyof TestAllFieldTypesNullableViewModel];
        }

        if(status && status.validationErrors && status.validationErrors.find(f => f.propertyName.toLowerCase() == name.toLowerCase())) {
            response += status.validationErrors.filter(f => f.propertyName.toLowerCase() == name.toLowerCase())[0].errorMessage;
        }

        return response;
   }

    
   let errorExistForField = (name:string) : boolean =>
   {
        return errorsForField(name) != '';
   }

   return (

          <form onSubmit={props.handleSubmit} role="form">
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldBigInt") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldBigInt</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldBigInt" className={errorExistForField("fieldBigInt") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldBigInt") && <small className="text-danger">{errorsForField("fieldBigInt")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldBinary") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldBinary</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldBinary" className={errorExistForField("fieldBinary") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldBinary") && <small className="text-danger">{errorsForField("fieldBinary")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldBit") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldBit</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldBit" className={errorExistForField("fieldBit") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldBit") && <small className="text-danger">{errorsForField("fieldBit")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldChar") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldChar</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldChar" className={errorExistForField("fieldChar") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldChar") && <small className="text-danger">{errorsForField("fieldChar")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldDate</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldDate" className={errorExistForField("fieldDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldDate") && <small className="text-danger">{errorsForField("fieldDate")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldDateTime") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldDateTime</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldDateTime" className={errorExistForField("fieldDateTime") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldDateTime") && <small className="text-danger">{errorsForField("fieldDateTime")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldDateTime2") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldDateTime2</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldDateTime2" className={errorExistForField("fieldDateTime2") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldDateTime2") && <small className="text-danger">{errorsForField("fieldDateTime2")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldDateTimeOffset") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldDateTimeOffset</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldDateTimeOffset" className={errorExistForField("fieldDateTimeOffset") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldDateTimeOffset") && <small className="text-danger">{errorsForField("fieldDateTimeOffset")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldDecimal") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldDecimal</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldDecimal" className={errorExistForField("fieldDecimal") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldDecimal") && <small className="text-danger">{errorsForField("fieldDecimal")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldFloat") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldFloat</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldFloat" className={errorExistForField("fieldFloat") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldFloat") && <small className="text-danger">{errorsForField("fieldFloat")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldImage") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldImage</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldImage" className={errorExistForField("fieldImage") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldImage") && <small className="text-danger">{errorsForField("fieldImage")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldMoney") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldMoney</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldMoney" className={errorExistForField("fieldMoney") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldMoney") && <small className="text-danger">{errorsForField("fieldMoney")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldNChar") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldNChar</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldNChar" className={errorExistForField("fieldNChar") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldNChar") && <small className="text-danger">{errorsForField("fieldNChar")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldNText") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldNText</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldNText" className={errorExistForField("fieldNText") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldNText") && <small className="text-danger">{errorsForField("fieldNText")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldNumeric") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldNumeric</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldNumeric" className={errorExistForField("fieldNumeric") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldNumeric") && <small className="text-danger">{errorsForField("fieldNumeric")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldNVarchar") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldNVarchar</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldNVarchar" className={errorExistForField("fieldNVarchar") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldNVarchar") && <small className="text-danger">{errorsForField("fieldNVarchar")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldReal") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldReal</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldReal" className={errorExistForField("fieldReal") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldReal") && <small className="text-danger">{errorsForField("fieldReal")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldSmallDateTime") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldSmallDateTime</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldSmallDateTime" className={errorExistForField("fieldSmallDateTime") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldSmallDateTime") && <small className="text-danger">{errorsForField("fieldSmallDateTime")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldSmallInt") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldSmallInt</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldSmallInt" className={errorExistForField("fieldSmallInt") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldSmallInt") && <small className="text-danger">{errorsForField("fieldSmallInt")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldSmallMoney") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldSmallMoney</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldSmallMoney" className={errorExistForField("fieldSmallMoney") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldSmallMoney") && <small className="text-danger">{errorsForField("fieldSmallMoney")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldText") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldText</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldText" className={errorExistForField("fieldText") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldText") && <small className="text-danger">{errorsForField("fieldText")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldTime") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldTime</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldTime" className={errorExistForField("fieldTime") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldTime") && <small className="text-danger">{errorsForField("fieldTime")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldTimestamp") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldTimestamp</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldTimestamp" className={errorExistForField("fieldTimestamp") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldTimestamp") && <small className="text-danger">{errorsForField("fieldTimestamp")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldTinyInt") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldTinyInt</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldTinyInt" className={errorExistForField("fieldTinyInt") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldTinyInt") && <small className="text-danger">{errorsForField("fieldTinyInt")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldUniqueIdentifier") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldUniqueIdentifier</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldUniqueIdentifier" className={errorExistForField("fieldUniqueIdentifier") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldUniqueIdentifier") && <small className="text-danger">{errorsForField("fieldUniqueIdentifier")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldVarBinary") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldVarBinary</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldVarBinary" className={errorExistForField("fieldVarBinary") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldVarBinary") && <small className="text-danger">{errorsForField("fieldVarBinary")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldVarchar") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldVarchar</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldVarchar" className={errorExistForField("fieldVarchar") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldVarchar") && <small className="text-danger">{errorsForField("fieldVarchar")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fieldXML") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FieldXML</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fieldXML" className={errorExistForField("fieldXML") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fieldXML") && <small className="text-danger">{errorsForField("fieldXML")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("id") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Id</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="id" className={errorExistForField("id") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("id") && <small className="text-danger">{errorsForField("id")}</small>}
                        </div>
                    </div>
			
            <button type="submit" className="btn btn-primary" disabled={false}>
                Submit
            </button>
            <br />
            <br />
            { 
                status && status.success ? (<div className="alert alert-success">Success</div>): (null)
            }
                        
            { 
                status && !status.success ? (<div className="alert alert-danger">Error occurred</div>): (null)
            }
          </form>
  );
}


const TestAllFieldTypesNullableEdit = withFormik<Props, TestAllFieldTypesNullableViewModel>({
    mapPropsToValues: props => {
        let response = new TestAllFieldTypesNullableViewModel();
		response.setProperties(props.model!.fieldBigInt,props.model!.fieldBinary,props.model!.fieldBit,props.model!.fieldChar,props.model!.fieldDate,props.model!.fieldDateTime,props.model!.fieldDateTime2,props.model!.fieldDateTimeOffset,props.model!.fieldDecimal,props.model!.fieldFloat,props.model!.fieldImage,props.model!.fieldMoney,props.model!.fieldNChar,props.model!.fieldNText,props.model!.fieldNumeric,props.model!.fieldNVarchar,props.model!.fieldReal,props.model!.fieldSmallDateTime,props.model!.fieldSmallInt,props.model!.fieldSmallMoney,props.model!.fieldText,props.model!.fieldTime,props.model!.fieldTimestamp,props.model!.fieldTinyInt,props.model!.fieldUniqueIdentifier,props.model!.fieldVarBinary,props.model!.fieldVarchar,props.model!.fieldXML,props.model!.id);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<TestAllFieldTypesNullableViewModel> = { };

	  if(values.id == 0) {
                errors.id = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new TestAllFieldTypesNullableMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.TestAllFieldTypesNullables +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.TestAllFieldTypesNullableClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
        }, 
		error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
        .then(response =>
        {
            // cleanup
        })
    },
  
    displayName: 'TestAllFieldTypesNullableEdit', 
  })(TestAllFieldTypesNullableEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface TestAllFieldTypesNullableEditComponentProps
  {
     match:IMatch;
  }

  interface TestAllFieldTypesNullableEditComponentState
  {
      model?:TestAllFieldTypesNullableViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class TestAllFieldTypesNullableEditComponent extends React.Component<TestAllFieldTypesNullableEditComponentProps, TestAllFieldTypesNullableEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.TestAllFieldTypesNullables + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.TestAllFieldTypesNullableClientResponseModel;
            
            console.log(response);

			let mapper = new TestAllFieldTypesNullableMapper();

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, 
		error => {
            console.log(error);
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
        })
    }
    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
        else if (this.state.errorOccurred) {
			return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<TestAllFieldTypesNullableEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>e3f0a4d5d6d9d2966ba06049cfd3f7dd</Hash>
</Codenesium>*/