import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import AddressMapper from './addressMapper';
import AddressViewModel from './addressViewModel';

interface Props {
    model?:AddressViewModel
}

   const AddressCreateDisplay: React.SFC<FormikProps<AddressViewModel>> = (props: FormikProps<AddressViewModel>) => {

   let status = props.status as CreateResponse<Api.AddressClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof AddressViewModel]  && props.errors[name as keyof AddressViewModel]) {
            response += props.errors[name as keyof AddressViewModel];
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

   return (<form onSubmit={props.handleSubmit} role="form">            
            			<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("addressLine1") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>AddressLine1</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="addressLine1" className={errorExistForField("addressLine1") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("addressLine1") && <small className="text-danger">{errorsForField("addressLine1")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("addressLine2") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>AddressLine2</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="addressLine2" className={errorExistForField("addressLine2") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("addressLine2") && <small className="text-danger">{errorsForField("addressLine2")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("city") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>City</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="city" className={errorExistForField("city") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("city") && <small className="text-danger">{errorsForField("city")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("modifiedDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ModifiedDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="modifiedDate" className={errorExistForField("modifiedDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("modifiedDate") && <small className="text-danger">{errorsForField("modifiedDate")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("postalCode") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PostalCode</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="postalCode" className={errorExistForField("postalCode") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("postalCode") && <small className="text-danger">{errorsForField("postalCode")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("rowguid") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Rowguid</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="rowguid" className={errorExistForField("rowguid") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("rowguid") && <small className="text-danger">{errorsForField("rowguid")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("stateProvinceID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>StateProvinceID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="stateProvinceID" className={errorExistForField("stateProvinceID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("stateProvinceID") && <small className="text-danger">{errorsForField("stateProvinceID")}</small>}
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
          </form>);
}


const AddressCreate = withFormik<Props, AddressViewModel>({
    mapPropsToValues: props => {
                
		let response = new AddressViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.addressID,props.model!.addressLine1,props.model!.addressLine2,props.model!.city,props.model!.modifiedDate,props.model!.postalCode,props.model!.rowguid,props.model!.stateProvinceID);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<AddressViewModel> = { };

	  if(values.addressLine1 == '') {
                errors.addressLine1 = "Required"
                    }if(values.city == '') {
                errors.city = "Required"
                    }if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.postalCode == '') {
                errors.postalCode = "Required"
                    }if(values.rowguid == undefined) {
                errors.rowguid = "Required"
                    }if(values.stateProvinceID == 0) {
                errors.stateProvinceID = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new AddressMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Addresses,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.AddressClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'AddressCreate', 
  })(AddressCreateDisplay);

  interface AddressCreateComponentProps
  {
  }

  interface AddressCreateComponentState
  {
      model?:AddressViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class AddressCreateComponent extends React.Component<AddressCreateComponentProps, AddressCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<AddressCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>437d45378a1f2a907352e865b0e76ee2</Hash>
</Codenesium>*/