import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import PipelineStepStepRequirementMapper from './pipelineStepStepRequirementMapper';
import PipelineStepStepRequirementViewModel from './pipelineStepStepRequirementViewModel';

interface Props {
    model?:PipelineStepStepRequirementViewModel
}

   const PipelineStepStepRequirementCreateDisplay: React.SFC<FormikProps<PipelineStepStepRequirementViewModel>> = (props: FormikProps<PipelineStepStepRequirementViewModel>) => {

   let status = props.status as CreateResponse<Api.PipelineStepStepRequirementClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof PipelineStepStepRequirementViewModel]  && props.errors[name as keyof PipelineStepStepRequirementViewModel]) {
            response += props.errors[name as keyof PipelineStepStepRequirementViewModel];
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
                        <label htmlFor="name" className={errorExistForField("detail") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Details</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="detail" className={errorExistForField("detail") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("detail") && <small className="text-danger">{errorsForField("detail")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("pipelineStepId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PipelineStepId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="pipelineStepId" className={errorExistForField("pipelineStepId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("pipelineStepId") && <small className="text-danger">{errorsForField("pipelineStepId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("requirementMet") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>RequirementMet</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="requirementMet" className={errorExistForField("requirementMet") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("requirementMet") && <small className="text-danger">{errorsForField("requirementMet")}</small>}
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


const PipelineStepStepRequirementCreate = withFormik<Props, PipelineStepStepRequirementViewModel>({
    mapPropsToValues: props => {
                
		let response = new PipelineStepStepRequirementViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.detail,props.model!.id,props.model!.pipelineStepId,props.model!.requirementMet);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<PipelineStepStepRequirementViewModel> = { };

	  if(values.detail == '') {
                errors.detail = "Required"
                    }if(values.pipelineStepId == 0) {
                errors.pipelineStepId = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new PipelineStepStepRequirementMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.PipelineStepStepRequirements,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.PipelineStepStepRequirementClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'PipelineStepStepRequirementCreate', 
  })(PipelineStepStepRequirementCreateDisplay);

  interface PipelineStepStepRequirementCreateComponentProps
  {
  }

  interface PipelineStepStepRequirementCreateComponentState
  {
      model?:PipelineStepStepRequirementViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class PipelineStepStepRequirementCreateComponent extends React.Component<PipelineStepStepRequirementCreateComponentProps, PipelineStepStepRequirementCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<PipelineStepStepRequirementCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>1d6f7e73f50cdb72e9b019f16c94bbcd</Hash>
</Codenesium>*/