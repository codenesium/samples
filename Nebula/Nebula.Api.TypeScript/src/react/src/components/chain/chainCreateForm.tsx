import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ChainMapper from './chainMapper';
import ChainViewModel from './chainViewModel';

interface Props {
    model?:ChainViewModel
}

   const ChainCreateDisplay: React.SFC<FormikProps<ChainViewModel>> = (props: FormikProps<ChainViewModel>) => {

   let status = props.status as CreateResponse<Api.ChainClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof ChainViewModel]  && props.errors[name as keyof ChainViewModel]) {
            response += props.errors[name as keyof ChainViewModel];
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
                        <label htmlFor="name" className={errorExistForField("chainStatusId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ChainStatusId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="chainStatusId" className={errorExistForField("chainStatusId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("chainStatusId") && <small className="text-danger">{errorsForField("chainStatusId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("externalId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ExternalId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="externalId" className={errorExistForField("externalId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("externalId") && <small className="text-danger">{errorsForField("externalId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("name") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Name</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="name" className={errorExistForField("name") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("name") && <small className="text-danger">{errorsForField("name")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("teamId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TeamId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="teamId" className={errorExistForField("teamId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("teamId") && <small className="text-danger">{errorsForField("teamId")}</small>}
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


const ChainCreate = withFormik<Props, ChainViewModel>({
    mapPropsToValues: props => {
                
		let response = new ChainViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.chainStatusId,props.model!.externalId,props.model!.id,props.model!.name,props.model!.teamId);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<ChainViewModel> = { };

	  if(values.chainStatusId == 0) {
                errors.chainStatusId = "Required"
                    }if(values.externalId == undefined) {
                errors.externalId = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }if(values.teamId == 0) {
                errors.teamId = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new ChainMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Chains,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.ChainClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'ChainCreate', 
  })(ChainCreateDisplay);

  interface ChainCreateComponentProps
  {
  }

  interface ChainCreateComponentState
  {
      model?:ChainViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class ChainCreateComponent extends React.Component<ChainCreateComponentProps, ChainCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<ChainCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>e55e1b0820af30bcb2efc1357c3facdd</Hash>
</Codenesium>*/