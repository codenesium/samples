import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import TimestampCheckMapper from './timestampCheckMapper';
import TimestampCheckViewModel from './timestampCheckViewModel';

interface Props {
    model?:TimestampCheckViewModel
}

   const TimestampCheckCreateDisplay: React.SFC<FormikProps<TimestampCheckViewModel>> = (props: FormikProps<TimestampCheckViewModel>) => {

   let status = props.status as CreateResponse<Api.TimestampCheckClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof TimestampCheckViewModel]  && props.errors[name as keyof TimestampCheckViewModel]) {
            response += props.errors[name as keyof TimestampCheckViewModel];
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
                             <Field type="textbox" name="name" className={errorExistForField("name") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("name") && <small className="text-danger">{errorsForField("name")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("timestamp") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Timestamp</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="timestamp" className={errorExistForField("timestamp") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("timestamp") && <small className="text-danger">{errorsForField("timestamp")}</small>}
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


const TimestampCheckCreate = withFormik<Props, TimestampCheckViewModel>({
    mapPropsToValues: props => {
                
		let response = new TimestampCheckViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.id,props.model!.name,props.model!.timestamp);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<TimestampCheckViewModel> = { };

	  if(values.timestamp == undefined) {
                errors.timestamp = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new TimestampCheckMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.TimestampChecks,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.TimestampCheckClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'TimestampCheckCreate', 
  })(TimestampCheckCreateDisplay);

  interface TimestampCheckCreateComponentProps
  {
  }

  interface TimestampCheckCreateComponentState
  {
      model?:TimestampCheckViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class TimestampCheckCreateComponent extends React.Component<TimestampCheckCreateComponentProps, TimestampCheckCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<TimestampCheckCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>56f8c4fdbc6319c8a2d0f98ceff1e04a</Hash>
</Codenesium>*/