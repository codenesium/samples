import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import AirlineMapper from './airlineMapper';
import AirlineViewModel from './airlineViewModel';

interface Props {
    model?:AirlineViewModel
}

   const AirlineCreateDisplay: React.SFC<FormikProps<AirlineViewModel>> = (props: FormikProps<AirlineViewModel>) => {

   let status = props.status as CreateResponse<Api.AirlineClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof AirlineViewModel]  && props.errors[name as keyof AirlineViewModel]) {
            response += props.errors[name as keyof AirlineViewModel];
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
                        <label htmlFor="name" className={errorExistForField("name") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Name</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="name" className={errorExistForField("name") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("name") && <small className="text-danger">{errorsForField("name")}</small>}
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


const AirlineCreate = withFormik<Props, AirlineViewModel>({
    mapPropsToValues: props => {
                
		let response = new AirlineViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.id,props.model!.name);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<AirlineViewModel> = { };

	  if(values.name == '') {
                errors.name = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new AirlineMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Airlines,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.AirlineClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'AirlineCreate', 
  })(AirlineCreateDisplay);

  interface AirlineCreateComponentProps
  {
  }

  interface AirlineCreateComponentState
  {
      model?:AirlineViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class AirlineCreateComponent extends React.Component<AirlineCreateComponentProps, AirlineCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<AirlineCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>f61299bfe9731c33137d1b889ea55f4f</Hash>
</Codenesium>*/