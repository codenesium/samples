import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import VenueViewModel from './venueViewModel';
import VenueMapper from './venueMapper';

interface Props {
    model?:VenueViewModel
}

  const VenueEditDisplay = (props: FormikProps<VenueViewModel>) => {

   let status = props.status as UpdateResponse<Api.VenueClientRequestModel>;
   
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

   return (

          <form onSubmit={props.handleSubmit} role="form">
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
          </form>
  );
}


const VenueEdit = withFormik<Props, VenueViewModel>({
    mapPropsToValues: props => {
        let response = new VenueViewModel();
		response.setProperties(props.model!.address1,props.model!.address2,props.model!.adminId,props.model!.email,props.model!.facebook,props.model!.id,props.model!.name,props.model!.phone,props.model!.provinceId,props.model!.website);	
		return response;
      },
  
    // Custom sync validation
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
                    }if(values.id == 0) {
                errors.id = "Required"
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

        axios.put(Constants.ApiEndpoint + ApiRoutes.Venues +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.VenueClientRequestModel>;
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
  
    displayName: 'VenueEdit', 
  })(VenueEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface VenueEditComponentProps
  {
     match:IMatch;
  }

  interface VenueEditComponentState
  {
      model?:VenueViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class VenueEditComponent extends React.Component<VenueEditComponentProps, VenueEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Venues + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.VenueClientResponseModel;
            
            console.log(response);

			let mapper = new VenueMapper();

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
            return (<VenueEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>1d67e0b475ab1ee8864d5b494981fba5</Hash>
</Codenesium>*/