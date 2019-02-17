import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import AWBuildVersionMapper from './aWBuildVersionMapper';
import AWBuildVersionViewModel from './aWBuildVersionViewModel';

interface Props {
    model?:AWBuildVersionViewModel
}

   const AWBuildVersionCreateDisplay: React.SFC<FormikProps<AWBuildVersionViewModel>> = (props: FormikProps<AWBuildVersionViewModel>) => {

   let status = props.status as CreateResponse<Api.AWBuildVersionClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof AWBuildVersionViewModel]  && props.errors[name as keyof AWBuildVersionViewModel]) {
            response += props.errors[name as keyof AWBuildVersionViewModel];
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
                        <label htmlFor="name" className={errorExistForField("database_Version") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Database Version</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="database_Version" className={errorExistForField("database_Version") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("database_Version") && <small className="text-danger">{errorsForField("database_Version")}</small>}
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
                        <label htmlFor="name" className={errorExistForField("versionDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>VersionDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="versionDate" className={errorExistForField("versionDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("versionDate") && <small className="text-danger">{errorsForField("versionDate")}</small>}
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


const AWBuildVersionCreate = withFormik<Props, AWBuildVersionViewModel>({
    mapPropsToValues: props => {
                
		let response = new AWBuildVersionViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.database_Version,props.model!.modifiedDate,props.model!.systemInformationID,props.model!.versionDate);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<AWBuildVersionViewModel> = { };

	  if(values.database_Version == '') {
                errors.database_Version = "Required"
                    }if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.versionDate == undefined) {
                errors.versionDate = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new AWBuildVersionMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.AWBuildVersions,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.AWBuildVersionClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'AWBuildVersionCreate', 
  })(AWBuildVersionCreateDisplay);

  interface AWBuildVersionCreateComponentProps
  {
  }

  interface AWBuildVersionCreateComponentState
  {
      model?:AWBuildVersionViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class AWBuildVersionCreateComponent extends React.Component<AWBuildVersionCreateComponentProps, AWBuildVersionCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<AWBuildVersionCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>a86f2abb318ab4c75e367967aa8ea535</Hash>
</Codenesium>*/