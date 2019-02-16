import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import LinkMapper from './linkMapper';
import LinkViewModel from './linkViewModel';

interface Props {
    model?:LinkViewModel
}

   const LinkCreateDisplay: React.SFC<FormikProps<LinkViewModel>> = (props: FormikProps<LinkViewModel>) => {

   let status = props.status as CreateResponse<Api.LinkClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof LinkViewModel]  && props.errors[name as keyof LinkViewModel]) {
            response += props.errors[name as keyof LinkViewModel];
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
                        <label htmlFor="name" className={errorExistForField("assignedMachineId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>AssignedMachineId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="assignedMachineId" className={errorExistForField("assignedMachineId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("assignedMachineId") && <small className="text-danger">{errorsForField("assignedMachineId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("chainId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ChainId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="chainId" className={errorExistForField("chainId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("chainId") && <small className="text-danger">{errorsForField("chainId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("dateCompleted") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>DateCompleted</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="dateCompleted" className={errorExistForField("dateCompleted") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("dateCompleted") && <small className="text-danger">{errorsForField("dateCompleted")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("dateStarted") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>DateStarted</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="dateStarted" className={errorExistForField("dateStarted") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("dateStarted") && <small className="text-danger">{errorsForField("dateStarted")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("dynamicParameter") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>DynamicParameter</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="dynamicParameter" className={errorExistForField("dynamicParameter") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("dynamicParameter") && <small className="text-danger">{errorsForField("dynamicParameter")}</small>}
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
                        <label htmlFor="name" className={errorExistForField("linkStatusId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>LinkStatusId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="linkStatusId" className={errorExistForField("linkStatusId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("linkStatusId") && <small className="text-danger">{errorsForField("linkStatusId")}</small>}
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
                        <label htmlFor="name" className={errorExistForField("order") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Order</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="order" className={errorExistForField("order") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("order") && <small className="text-danger">{errorsForField("order")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("response") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Response</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="response" className={errorExistForField("response") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("response") && <small className="text-danger">{errorsForField("response")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("staticParameter") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>StaticParameter</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="staticParameter" className={errorExistForField("staticParameter") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("staticParameter") && <small className="text-danger">{errorsForField("staticParameter")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("timeoutInSecond") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TimeoutInSecond</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="timeoutInSecond" className={errorExistForField("timeoutInSecond") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("timeoutInSecond") && <small className="text-danger">{errorsForField("timeoutInSecond")}</small>}
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


const LinkCreate = withFormik<Props, LinkViewModel>({
    mapPropsToValues: props => {
                
		let response = new LinkViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.assignedMachineId,props.model!.chainId,props.model!.dateCompleted,props.model!.dateStarted,props.model!.dynamicParameter,props.model!.externalId,props.model!.id,props.model!.linkStatusId,props.model!.name,props.model!.order,props.model!.response,props.model!.staticParameter,props.model!.timeoutInSecond);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<LinkViewModel> = { };

	  if(values.chainId == 0) {
                errors.chainId = "Required"
                    }if(values.externalId == undefined) {
                errors.externalId = "Required"
                    }if(values.linkStatusId == 0) {
                errors.linkStatusId = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }if(values.order == 0) {
                errors.order = "Required"
                    }if(values.timeoutInSecond == 0) {
                errors.timeoutInSecond = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new LinkMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Links,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.LinkClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'LinkCreate', 
  })(LinkCreateDisplay);

  interface LinkCreateComponentProps
  {
  }

  interface LinkCreateComponentState
  {
      model?:LinkViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class LinkCreateComponent extends React.Component<LinkCreateComponentProps, LinkCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<LinkCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>b7c10c7f6b1c2e203fa5f9a0c90d6d25</Hash>
</Codenesium>*/