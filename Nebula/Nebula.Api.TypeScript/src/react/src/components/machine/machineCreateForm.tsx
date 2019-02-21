import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import MachineMapper from './machineMapper';
import MachineViewModel from './machineViewModel';

interface Props {
    model?:MachineViewModel
}

   const MachineCreateDisplay: React.SFC<FormikProps<MachineViewModel>> = (props: FormikProps<MachineViewModel>) => {

   let status = props.status as CreateResponse<Api.MachineClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof MachineViewModel]  && props.errors[name as keyof MachineViewModel]) {
            response += props.errors[name as keyof MachineViewModel];
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
                        <label htmlFor="name" className={errorExistForField("description") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Description</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="description" className={errorExistForField("description") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("description") && <small className="text-danger">{errorsForField("description")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("jwtKey") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>JwtKey</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="jwtKey" className={errorExistForField("jwtKey") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("jwtKey") && <small className="text-danger">{errorsForField("jwtKey")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("lastIpAddress") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>LastIpAddress</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="lastIpAddress" className={errorExistForField("lastIpAddress") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("lastIpAddress") && <small className="text-danger">{errorsForField("lastIpAddress")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("machineGuid") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>MachineGuid</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="machineGuid" className={errorExistForField("machineGuid") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("machineGuid") && <small className="text-danger">{errorsForField("machineGuid")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("name") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Name</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="name" className={errorExistForField("name") ? "form-control is-invalid" : "form-control"} />
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


const MachineCreate = withFormik<Props, MachineViewModel>({
    mapPropsToValues: props => {
                
		let response = new MachineViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.description,props.model!.id,props.model!.jwtKey,props.model!.lastIpAddress,props.model!.machineGuid,props.model!.name);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<MachineViewModel> = { };

	  if(values.description == '') {
                errors.description = "Required"
                    }if(values.jwtKey == '') {
                errors.jwtKey = "Required"
                    }if(values.lastIpAddress == '') {
                errors.lastIpAddress = "Required"
                    }if(values.machineGuid == undefined) {
                errors.machineGuid = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new MachineMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Machines,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.MachineClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'MachineCreate', 
  })(MachineCreateDisplay);

  interface MachineCreateComponentProps
  {
  }

  interface MachineCreateComponentState
  {
      model?:MachineViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class MachineCreateComponent extends React.Component<MachineCreateComponentProps, MachineCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<MachineCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>2d5bdd01e23a451cc65f51befac3a58c</Hash>
</Codenesium>*/