import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import VenueMapper from './venueMapper';
import VenueViewModel from './venueViewModel';

interface Props {
    model?:VenueViewModel
}

   const VenueCreateDisplay: React.SFC<FormikProps<VenueViewModel>> = (props: FormikProps<VenueViewModel>) => {

   let status = props.status as CreateResponse<Api.VenueClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof VenueViewModel]  && props.errors[name as keyof VenueViewModel]) {
            response += props.errors[name as keyof VenueViewModel];
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
                        <label htmlFor="name" className={errorExistForField("address1") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Address1</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="address1" className={errorExistForField("address1") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("address1") && <small className="text-danger">{errorsForField("address1")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("address2") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Address2</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="address2" className={errorExistForField("address2") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("address2") && <small className="text-danger">{errorsForField("address2")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("adminId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>AdminId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="adminId" className={errorExistForField("adminId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("adminId") && <small className="text-danger">{errorsForField("adminId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("email") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Email</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="email" className={errorExistForField("email") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("email") && <small className="text-danger">{errorsForField("email")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("facebook") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Facebook</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="facebook" className={errorExistForField("facebook") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("facebook") && <small className="text-danger">{errorsForField("facebook")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("name") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Name</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="name" className={errorExistForField("name") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("name") && <small className="text-danger">{errorsForField("name")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("phone") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Phone</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="phone" className={errorExistForField("phone") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("phone") && <small className="text-danger">{errorsForField("phone")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("provinceId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ProvinceId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="provinceId" className={errorExistForField("provinceId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("provinceId") && <small className="text-danger">{errorsForField("provinceId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("website") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Website</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="website" className={errorExistForField("website") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("website") && <small className="text-danger">{errorsForField("website")}</small>}
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


const VenueCreate = withFormik<Props, VenueViewModel>({
    mapPropsToValues: props => {
                
		let response = new VenueViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.address1,props.model!.address2,props.model!.adminId,props.model!.email,props.model!.facebook,props.model!.id,props.model!.name,props.model!.phone,props.model!.provinceId,props.model!.website);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<VenueViewModel> = { };

	  if(values.address1 == '') {
                errors.address1 = "Required"
                    }if(values.address2 == '') {
                errors.address2 = "Required"
                    }if(values.adminId == 0) {
                errors.adminId = "Required"
                    }if(values.email == '') {
                errors.email = "Required"
                    }if(values.facebook == '') {
                errors.facebook = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }if(values.phone == '') {
                errors.phone = "Required"
                    }if(values.provinceId == 0) {
                errors.provinceId = "Required"
                    }if(values.website == '') {
                errors.website = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new VenueMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Venues,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.VenueClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'VenueCreate', 
  })(VenueCreateDisplay);

  interface VenueCreateComponentProps
  {
  }

  interface VenueCreateComponentState
  {
      model?:VenueViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class VenueCreateComponent extends React.Component<VenueCreateComponentProps, VenueCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<VenueCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>eefd3fbe3408bea91140c5276619a22b</Hash>
</Codenesium>*/