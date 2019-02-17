import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import JobCandidateMapper from './jobCandidateMapper';
import JobCandidateViewModel from './jobCandidateViewModel';

interface Props {
    model?:JobCandidateViewModel
}

   const JobCandidateCreateDisplay: React.SFC<FormikProps<JobCandidateViewModel>> = (props: FormikProps<JobCandidateViewModel>) => {

   let status = props.status as CreateResponse<Api.JobCandidateClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof JobCandidateViewModel]  && props.errors[name as keyof JobCandidateViewModel]) {
            response += props.errors[name as keyof JobCandidateViewModel];
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
                        <label htmlFor="name" className={errorExistForField("businessEntityID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>BusinessEntityID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="businessEntityID" className={errorExistForField("businessEntityID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("businessEntityID") && <small className="text-danger">{errorsForField("businessEntityID")}</small>}
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
                        <label htmlFor="name" className={errorExistForField("resume") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Resume</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="resume" className={errorExistForField("resume") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("resume") && <small className="text-danger">{errorsForField("resume")}</small>}
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


const JobCandidateCreate = withFormik<Props, JobCandidateViewModel>({
    mapPropsToValues: props => {
                
		let response = new JobCandidateViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.businessEntityID,props.model!.jobCandidateID,props.model!.modifiedDate,props.model!.resume);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<JobCandidateViewModel> = { };

	  if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new JobCandidateMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.JobCandidates,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.JobCandidateClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'JobCandidateCreate', 
  })(JobCandidateCreateDisplay);

  interface JobCandidateCreateComponentProps
  {
  }

  interface JobCandidateCreateComponentState
  {
      model?:JobCandidateViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class JobCandidateCreateComponent extends React.Component<JobCandidateCreateComponentProps, JobCandidateCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<JobCandidateCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>c0de0807a785e6fefa7e53e8c583b4ce</Hash>
</Codenesium>*/