import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import EventStatuMapper from './eventStatuMapper';
import EventStatuViewModel from './eventStatuViewModel';

interface Props {
    model?:EventStatuViewModel
}

   const EventStatuCreateDisplay: React.SFC<FormikProps<EventStatuViewModel>> = (props: FormikProps<EventStatuViewModel>) => {

   let status = props.status as CreateResponse<Api.EventStatuClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof EventStatuViewModel]  && props.errors[name as keyof EventStatuViewModel]) {
            response += props.errors[name as keyof EventStatuViewModel];
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


const EventStatuCreate = withFormik<Props, EventStatuViewModel>({
    mapPropsToValues: props => {
                
		let response = new EventStatuViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.id,props.model!.name);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<EventStatuViewModel> = { };

	  if(values.name == '') {
                errors.name = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new EventStatuMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.EventStatus,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.EventStatuClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'EventStatuCreate', 
  })(EventStatuCreateDisplay);

  interface EventStatuCreateComponentProps
  {
  }

  interface EventStatuCreateComponentState
  {
      model?:EventStatuViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class EventStatuCreateComponent extends React.Component<EventStatuCreateComponentProps, EventStatuCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<EventStatuCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>7d9e53b500ddfe1a4199effa2f47cc9e</Hash>
</Codenesium>*/