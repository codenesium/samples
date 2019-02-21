import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import HandlerMapper from './handlerMapper';
import HandlerViewModel from './handlerViewModel';

interface Props {
    model?:HandlerViewModel
}

   const HandlerCreateDisplay: React.SFC<FormikProps<HandlerViewModel>> = (props: FormikProps<HandlerViewModel>) => {

   let status = props.status as CreateResponse<Api.HandlerClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof HandlerViewModel]  && props.errors[name as keyof HandlerViewModel]) {
            response += props.errors[name as keyof HandlerViewModel];
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
                        <label htmlFor="name" className={errorExistForField("countryId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CountryId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="countryId" className={errorExistForField("countryId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("countryId") && <small className="text-danger">{errorsForField("countryId")}</small>}
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
                        <label htmlFor="name" className={errorExistForField("firstName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FirstName</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="firstName" className={errorExistForField("firstName") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("firstName") && <small className="text-danger">{errorsForField("firstName")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("lastName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>LastName</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="lastName" className={errorExistForField("lastName") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("lastName") && <small className="text-danger">{errorsForField("lastName")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("phone") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Phone</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="phone" className={errorExistForField("phone") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("phone") && <small className="text-danger">{errorsForField("phone")}</small>}
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


const HandlerCreate = withFormik<Props, HandlerViewModel>({
    mapPropsToValues: props => {
                
		let response = new HandlerViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.countryId,props.model!.email,props.model!.firstName,props.model!.id,props.model!.lastName,props.model!.phone);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<HandlerViewModel> = { };

	  if(values.countryId == 0) {
                errors.countryId = "Required"
                    }if(values.email == '') {
                errors.email = "Required"
                    }if(values.firstName == '') {
                errors.firstName = "Required"
                    }if(values.lastName == '') {
                errors.lastName = "Required"
                    }if(values.phone == '') {
                errors.phone = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new HandlerMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Handlers,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.HandlerClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'HandlerCreate', 
  })(HandlerCreateDisplay);

  interface HandlerCreateComponentProps
  {
  }

  interface HandlerCreateComponentState
  {
      model?:HandlerViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class HandlerCreateComponent extends React.Component<HandlerCreateComponentProps, HandlerCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<HandlerCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>6c54d9859535282d7562060b8e013851</Hash>
</Codenesium>*/